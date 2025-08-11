using System;
using System.Data;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Hotel_Room_Booking_System
{
    public partial class PaymentForm : Form
    {
        private int? _editingPaymentId = null;
        private bool _suppressBookingChange = false;

        public PaymentForm()
        {
            InitializeComponent();
            Load += PaymentForm_Load;
        }

        private async void PaymentForm_Load(object? sender, EventArgs e)
        {
            try
            {
                cmbPaymentMethod.DropDownStyle = ComboBoxStyle.DropDownList;
                if (cmbPaymentMethod.Items.Count > 0 && cmbPaymentMethod.SelectedIndex < 0)
                    cmbPaymentMethod.SelectedIndex = 0;

                txtAmount.ReadOnly = false; // editable override allowed

                // Grid defaults
                dataGridViewPayments.ReadOnly = true;
                dataGridViewPayments.MultiSelect = false;
                dataGridViewPayments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridViewPayments.RowHeadersVisible = false;
                dataGridViewPayments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                await LoadBookingsAsync();
                await LoadPaymentsAsync();

                // Wire selection after first load
                dataGridViewPayments.SelectionChanged += dataGridViewPayments_SelectionChanged;
                btnUpdate.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to initialize Payment Form:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadBookingsAsync()
        {
            using var con = DatabaseHelper.GetConnection();
            if (con == null) return;

            try
            {
                await con.OpenAsync();

                using var cmd = new SqlCommand(@"
                    SELECT 
                        b.BookingID,
                        c.FullName,
                        b.RoomNumber,
                        CONVERT(varchar(10), b.CheckIn, 23)  AS CheckInDate,
                        CONVERT(varchar(10), b.CheckOut, 23) AS CheckOutDate,
                        DATEDIFF(DAY, b.CheckIn, b.CheckOut) AS Nights,
                        CAST(r.Price AS decimal(10,2)) AS RatePerNight,
                        CAST(CAST(r.Price AS decimal(10,2)) * DATEDIFF(DAY, b.CheckIn, b.CheckOut) AS decimal(10,2)) AS Amount
                    FROM Bookings b
                    INNER JOIN Customers c ON c.CustomerID = b.CustomerID
                    INNER JOIN Rooms r ON r.RoomNumber = b.RoomNumber
                    ORDER BY b.BookingID DESC;", con);

                using var reader = await cmd.ExecuteReaderAsync();
                var table = new DataTable();
                table.Load(reader);

                table.Columns.Add("Display", typeof(string));
                foreach (DataRow row in table.Rows)
                {
                    var id = row["BookingID"];
                    var name = row["FullName"];
                    var room = row["RoomNumber"];
                    var ci = row["CheckInDate"];
                    var co = row["CheckOutDate"];
                    var nights = row["Nights"];
                    var rate = row["RatePerNight"];
                    var amt = row["Amount"];
                    row["Display"] = $"#{id} - {name} - Room {room} - {ci} to {co} ({nights} nights @ {rate} = {amt})";
                }

                cmbBooking.DataSource = table;
                cmbBooking.DisplayMember = "Display";
                cmbBooking.ValueMember = "BookingID";

                if (table.Rows.Count > 0)
                {
                    cmbBooking.SelectedIndex = 0;
                    txtGuestName.Text = table.Rows[0]["FullName"]?.ToString() ?? "";
                    txtAmount.Text = Convert.ToDecimal(table.Rows[0]["Amount"]).ToString("0.00");
                }
                else
                {
                    cmbBooking.SelectedIndex = -1;
                    txtGuestName.Clear();
                    txtAmount.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load bookings:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadPaymentsAsync()
        {
            using var con = DatabaseHelper.GetConnection();
            if (con == null) return;

            try
            {
                await con.OpenAsync();
                using var cmd = new SqlCommand(@"
                    SELECT 
                        p.PaymentID,
                        p.BookingID,
                        c.FullName     AS CustomerName,
                        CAST(p.Amount AS decimal(10,2)) AS Amount,
                        p.PaymentMethod,
                        CONVERT(varchar(10), p.PaymentDate, 23) AS PaymentDate
                    FROM Payments p
                    INNER JOIN Bookings b ON b.BookingID = p.BookingID
                    INNER JOIN Customers c ON c.CustomerID = b.CustomerID
                    ORDER BY p.PaymentDate DESC, p.PaymentID DESC;", con);

                using var reader = await cmd.ExecuteReaderAsync();
                var table = new DataTable();
                table.Load(reader);

                dataGridViewPayments.DataSource = table;

                // Nice widths
                SetColumnWidth("PaymentID", 110);
                SetColumnWidth("BookingID", 110);
                SetColumnWidth("CustomerName", 200);
                SetColumnWidth("Amount", 120);
                SetColumnWidth("PaymentMethod", 160);
                SetColumnWidth("PaymentDate", 140);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load payments:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetColumnWidth(string columnName, int width)
        {
            var col = dataGridViewPayments.Columns[columnName];
            if (col != null) col.Width = width;
        }

        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!ValidateForm(out var bookingId, out var amount, out var method, out var date))
                return;

            using var con = DatabaseHelper.GetConnection();
            if (con == null) return;

            try
            {
                await con.OpenAsync();

                using var cmd = new SqlCommand(@"
                    INSERT INTO Payments (BookingID, Amount, PaymentMethod, PaymentDate)
                    VALUES (@BookingID, @Amount, @Method, @Date);", con);

                cmd.Parameters.AddWithValue("@BookingID", bookingId);
                cmd.Parameters.AddWithValue("@Amount", amount);
                cmd.Parameters.AddWithValue("@Method", method);
                cmd.Parameters.AddWithValue("@Date", date);

                await cmd.ExecuteNonQueryAsync();

                MessageBox.Show("Payment recorded successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                ClearForm();
                await LoadPaymentsAsync();
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show("Database error:\n" + sqlEx.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected error:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnUpdate_Click(object? sender, EventArgs e)
        {
            if (_editingPaymentId is null)
            {
                MessageBox.Show("Select a payment from the table to edit.");
                return;
            }

            if (!ValidateForm(out var bookingId, out var amount, out var method, out var date))
                return;

            using var con = DatabaseHelper.GetConnection();
            if (con == null) return;

            try
            {
                await con.OpenAsync();

                using var cmd = new SqlCommand(@"
                    UPDATE Payments
                    SET BookingID = @BookingID,
                        Amount = @Amount,
                        PaymentMethod = @Method,
                        PaymentDate = @Date
                    WHERE PaymentID = @PaymentID;", con);

                cmd.Parameters.AddWithValue("@PaymentID", _editingPaymentId.Value);
                cmd.Parameters.AddWithValue("@BookingID", bookingId);
                cmd.Parameters.AddWithValue("@Amount", amount);
                cmd.Parameters.AddWithValue("@Method", method);
                cmd.Parameters.AddWithValue("@Date", date);

                var rows = await cmd.ExecuteNonQueryAsync();
                if (rows == 0)
                {
                    MessageBox.Show("No rows updated. It may have been modified by another user.");
                }
                else
                {
                    MessageBox.Show("Payment updated successfully!", "Updated",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                ClearForm();
                await LoadPaymentsAsync();
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show("Database error:\n" + sqlEx.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected error:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateForm(out int bookingId, out decimal amount, out string method, out DateTime date)
        {
            bookingId = 0;
            amount = 0;
            method = "";
            date = DateTime.Today;

            if (cmbBooking.SelectedItem is not DataRowView drv)
            {
                MessageBox.Show("Please select a booking.");
                return false;
            }

            if (cmbPaymentMethod.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a payment method.");
                return false;
            }

            if (!decimal.TryParse(txtAmount.Text, NumberStyles.Number, CultureInfo.InvariantCulture, out amount) || amount <= 0)
            {
                MessageBox.Show("Please enter a valid amount.");
                return false;
            }

            bookingId = Convert.ToInt32(drv.Row["BookingID"]);
            method = cmbPaymentMethod.SelectedItem.ToString()!;
            date = dtpPaymentDate.Value.Date;
            return true;
        }

        private async void btnViewPayments_Click(object sender, EventArgs e)
        {
            await LoadPaymentsAsync();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            _editingPaymentId = null;
            btnUpdate.Enabled = false;

            if (cmbBooking.Items.Count > 0)
            {
                _suppressBookingChange = true;
                try { cmbBooking.SelectedIndex = 0; }
                finally { _suppressBookingChange = false; }
            }
            else
            {
                cmbBooking.SelectedIndex = -1;
            }

            txtGuestName.Clear();
            txtAmount.Clear();

            if (cmbPaymentMethod.Items.Count > 0)
                cmbPaymentMethod.SelectedIndex = 0;

            dtpPaymentDate.Value = DateTime.Today;
        }

        private void cmbBooking_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (_suppressBookingChange) return;

            if (cmbBooking.SelectedItem is DataRowView drv)
            {
                txtGuestName.Text = drv.Row["FullName"]?.ToString() ?? "";
                if (drv.Row["Amount"] != DBNull.Value)
                {
                    try
                    {
                        txtAmount.Text = Convert.ToDecimal(drv.Row["Amount"]).ToString("0.00");
                    }
                    catch
                    {
                        txtAmount.Clear();
                    }
                }
                else
                {
                    txtAmount.Clear();
                }
            }
            else
            {
                txtGuestName.Clear();
                txtAmount.Clear();
            }
        }

        private void dataGridViewPayments_SelectionChanged(object? sender, EventArgs e)
        {
            if (dataGridViewPayments.CurrentRow == null || dataGridViewPayments.CurrentRow.DataBoundItem is not DataRowView view)
            {
                _editingPaymentId = null;
                btnUpdate.Enabled = false;
                return;
            }

            var row = view.Row;

            // Load selection into form
            _editingPaymentId = Convert.ToInt32(row["PaymentID"]);
            btnUpdate.Enabled = true;

            // Set booking in combo without overriding amount via SelectedIndexChanged logic
            _suppressBookingChange = true;
            try
            {
                var bookingId = Convert.ToInt32(row["BookingID"]);
                cmbBooking.SelectedValue = bookingId;

                // Guest name is for display
                txtGuestName.Text = row["CustomerName"]?.ToString() ?? "";

                // Amount
                if (row["Amount"] != DBNull.Value)
                    txtAmount.Text = Convert.ToDecimal(row["Amount"]).ToString("0.00");

                // Method
                var method = row["PaymentMethod"]?.ToString();
                if (!string.IsNullOrWhiteSpace(method))
                    cmbPaymentMethod.SelectedItem = method;

                // Date (stored as yyyy-MM-dd from SELECT)
                var dateStr = row["PaymentDate"]?.ToString() ?? "";
                if (DateTime.TryParseExact(dateStr, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out var dt))
                    dtpPaymentDate.Value = dt;
            }
            finally
            {
                _suppressBookingChange = false;
            }
        }
    }
}
