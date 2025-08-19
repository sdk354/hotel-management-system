using System;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Hotel_Room_Booking_System
{
    public partial class BookingForm : Form
    {
        private int? selectedBookingId = null;
        private int? selectedRoomNumberForEdit = null; // ensures current room appears even if IsAvailable = 0

        public BookingForm()
        {
            InitializeComponent();
            Load += BookingForm_Load;
        }

        private async void BookingForm_Load(object sender, EventArgs e)
        {
            ConfigureDatePickers();
            ConfigureStatus();
            await LoadCustomersAsync();
            await LoadRoomsAsync(); // initial, no forced room
            await LoadBookingsAsync();
        }

        private void ConfigureDatePickers()
        {
            dtpCheckIn.MinDate = DateTime.Today;
            dtpCheckOut.MinDate = DateTime.Today.AddDays(1);
            dtpCheckIn.ValueChanged += dtpCheckIn_ValueChanged;
            dtpCheckOut.Value = DateTime.Today.AddDays(1);
        }

        private void ConfigureStatus()
        {
            cmbStatus.Items.Clear();
            cmbStatus.Items.AddRange(new object[] { "Confirmed", "Pending", "Cancelled", "Completed" });
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.SelectedIndex = 0;
        }

        private void dtpCheckIn_ValueChanged(object sender, EventArgs e)
        {
            var minOut = dtpCheckIn.Value.Date.AddDays(1);
            if (dtpCheckOut.Value.Date <= dtpCheckIn.Value.Date)
                dtpCheckOut.Value = minOut;
            dtpCheckOut.MinDate = minOut;
        }

        private async Task LoadCustomersAsync()
        {
            using var con = DatabaseHelper.GetConnection();
            if (con == null) return;

            try
            {
                await con.OpenAsync();
                using var cmd = new SqlCommand(
                    "SELECT CustomerID AS Id, FullName FROM Customers ORDER BY FullName;", con);

                using var reader = await cmd.ExecuteReaderAsync();
                var table = new DataTable();
                table.Load(reader);

                cmbCustomers.DataSource = table;
                cmbCustomers.DisplayMember = "FullName";
                cmbCustomers.ValueMember = "Id";
                cmbCustomers.SelectedIndex = table.Rows.Count > 0 ? 0 : -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load customers:\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadRoomsAsync(int? forceIncludeRoomNumber = null)
        {
            using var con = DatabaseHelper.GetConnection();
            if (con == null) return;

            try
            {
                await con.OpenAsync();

                string sql =
                    "SELECT RoomNumber AS Id, CONVERT(VARCHAR(10), RoomNumber) AS RoomDisplay " +
                    "FROM Rooms " +
                    "WHERE ISNULL(IsAvailable, 1) = 1 ";

                if (forceIncludeRoomNumber.HasValue)
                {
                    sql += "OR RoomNumber = @ForceRoom ";
                }

                sql += "ORDER BY RoomNumber;";

                using var cmd = new SqlCommand(sql, con);
                if (forceIncludeRoomNumber.HasValue)
                    cmd.Parameters.AddWithValue("@ForceRoom", forceIncludeRoomNumber.Value);

                using var reader = await cmd.ExecuteReaderAsync();
                var table = new DataTable();
                table.Load(reader);

                cmbRooms.DataSource = table;
                cmbRooms.DisplayMember = "RoomDisplay";
                cmbRooms.ValueMember = "Id";
                cmbRooms.SelectedIndex = table.Rows.Count > 0 ? 0 : -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load rooms:\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        b.CustomerID,
                        c.FullName AS CustomerName,
                        b.RoomNumber,
                        b.CheckIn,
                        b.CheckOut,
                        b.Status
                    FROM Bookings b
                    INNER JOIN Customers c ON c.CustomerID = b.CustomerID
                    ORDER BY b.BookingID DESC;", con);

                using var reader = await cmd.ExecuteReaderAsync();
                var table = new DataTable();
                table.Load(reader);

                dgvBookings.DataSource = table;

                this.ClientSize = new Size(
                    dgvBookings.Location.X + dgvBookings.Width + 24,
                    this.ClientSize.Height
                );

                if (dgvBookings.Columns["BookingID"] != null) dgvBookings.Columns["BookingID"].Width = 90;
                if (dgvBookings.Columns["CustomerName"] != null) dgvBookings.Columns["CustomerName"].Width = 180;
                if (dgvBookings.Columns["RoomNumber"] != null) dgvBookings.Columns["RoomNumber"].Width = 120;
                if (dgvBookings.Columns["CheckIn"] != null) dgvBookings.Columns["CheckIn"].Width = 110;
                if (dgvBookings.Columns["CheckOut"] != null) dgvBookings.Columns["CheckOut"].Width = 110;
                if (dgvBookings.Columns["Status"] != null) dgvBookings.Columns["Status"].Width = 110;
                if (dgvBookings.Columns["CustomerID"] != null) dgvBookings.Columns["CustomerID"].Visible = false;

                lblCount.Text = $"Total bookings: {table.Rows.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load bookings:\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnBook_Click(object sender, EventArgs e) { /* unchanged */ }
        private async void btnUpdate_Click(object sender, EventArgs e) { /* unchanged */ }
        private async void btnDelete_Click(object sender, EventArgs e) { /* unchanged */ }
        private async void btnRefresh_Click(object sender, EventArgs e) { await LoadBookingsAsync(); }
        private void btnClear_Click(object sender, EventArgs e) { ClearForm(); }

        private void ClearForm()
        {
            selectedBookingId = null;
            selectedRoomNumberForEdit = null;

            if (cmbCustomers.Items.Count > 0) cmbCustomers.SelectedIndex = 0;
            if (cmbRooms.Items.Count > 0) cmbRooms.SelectedIndex = 0;

            dtpCheckIn.Value = DateTime.Today;
            dtpCheckOut.Value = DateTime.Today.AddDays(1);
            cmbStatus.SelectedIndex = 0;

            dgvBookings.ClearSelection();
        }

        // 🔹 Updated method
        private async void dgvBookings_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvBookings.CurrentRow == null || dgvBookings.CurrentRow.DataBoundItem == null)
                return;

            var row = (dgvBookings.CurrentRow.DataBoundItem as DataRowView)?.Row;
            if (row == null) return;

            selectedBookingId = Convert.ToInt32(row["BookingID"]);
            var custId = Convert.ToInt32(row["CustomerID"]);
            var roomNo = Convert.ToInt32(row["RoomNumber"]);
            var checkIn = Convert.ToDateTime(row["CheckIn"]);
            var checkOut = Convert.ToDateTime(row["CheckOut"]);
            var status = row["Status"]?.ToString() ?? "Confirmed";

            selectedRoomNumberForEdit = roomNo;
            await LoadRoomsAsync(forceIncludeRoomNumber: roomNo);

            SelectComboByValue(cmbCustomers, custId);
            SelectComboByValue(cmbRooms, roomNo);

            // ✅ Adjust MinDate dynamically so historical dates are allowed
            dtpCheckIn.MinDate = checkIn < DateTime.Today ? checkIn : DateTime.Today;
            dtpCheckOut.MinDate = checkOut < DateTime.Today ? checkOut : DateTime.Today.AddDays(1);

            dtpCheckIn.Value = checkIn;
            dtpCheckOut.Value = checkOut;

            var statusIndex = cmbStatus.Items.IndexOf(status);
            cmbStatus.SelectedIndex = statusIndex >= 0 ? statusIndex : 0;
        }

        private static bool TryGetSelectedInt(ComboBox cmb, out int value)
        {
            value = 0;
            try
            {
                if (cmb.SelectedValue == null) return false;
                value = Convert.ToInt32(cmb.SelectedValue);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private static void SelectComboByValue(ComboBox cmb, int value)
        {
            if (cmb.DataSource != null)
            {
                cmb.SelectedValue = value;
            }
            else
            {
                for (int i = 0; i < cmb.Items.Count; i++)
                {
                    if (int.TryParse(cmb.Items[i]?.ToString(), out var v) && v == value)
                    {
                        cmb.SelectedIndex = i;
                        break;
                    }
                }
            }
        }

        private void lblWelcome_Click(object sender, EventArgs e) { }
    }
}
