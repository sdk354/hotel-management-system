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
            // Basic statuses; adjust if you have a fixed list
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

        // Load rooms; optionally ensure a specific room number is included (for editing an existing booking)
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

                // Make grid tidy
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

        private async void btnBook_Click(object sender, EventArgs e)
        {
            if (!TryGetSelectedInt(cmbCustomers, out var customerId) ||
                !TryGetSelectedInt(cmbRooms, out var roomNumber))
            {
                MessageBox.Show("Please select both a customer and a room.");
                return;
            }

            var checkIn = dtpCheckIn.Value.Date;
            var checkOut = dtpCheckOut.Value.Date;
            if (checkOut <= checkIn)
            {
                MessageBox.Show("Check-out date must be after check-in date.");
                return;
            }

            var status = cmbStatus.SelectedItem?.ToString() ?? "Confirmed";

            using var con = DatabaseHelper.GetConnection();
            if (con == null) return;

            try
            {
                await con.OpenAsync();
                using var tx = await con.BeginTransactionAsync();

                // Overlap check
                using (var checkCmd = new SqlCommand(@"
                    SELECT COUNT(1)
                    FROM Bookings WITH (UPDLOCK, HOLDLOCK)
                    WHERE RoomNumber = @RoomNumber
                      AND NOT (@CheckOut <= CheckIn OR @CheckIn >= CheckOut);", con, (SqlTransaction)tx))
                {
                    checkCmd.Parameters.AddWithValue("@RoomNumber", roomNumber);
                    checkCmd.Parameters.AddWithValue("@CheckIn", checkIn);
                    checkCmd.Parameters.AddWithValue("@CheckOut", checkOut);

                    var conflicts = (int)await checkCmd.ExecuteScalarAsync();
                    if (conflicts > 0)
                    {
                        await tx.RollbackAsync();
                        MessageBox.Show("Selected room is not available for the chosen dates.");
                        return;
                    }
                }

                int bookingId;
                using (var insertCmd = new SqlCommand(@"
                    INSERT INTO Bookings (CustomerID, RoomNumber, CheckIn, CheckOut, Status)
                    VALUES (@CustomerID, @RoomNumber, @CheckIn, @CheckOut, @Status);
                    SELECT CAST(SCOPE_IDENTITY() AS INT);", con, (SqlTransaction)tx))
                {
                    insertCmd.Parameters.AddWithValue("@CustomerID", customerId);
                    insertCmd.Parameters.AddWithValue("@RoomNumber", roomNumber);
                    insertCmd.Parameters.AddWithValue("@CheckIn", checkIn);
                    insertCmd.Parameters.AddWithValue("@CheckOut", checkOut);
                    insertCmd.Parameters.AddWithValue("@Status", status);

                    bookingId = (int)await insertCmd.ExecuteScalarAsync();
                }

                using (var updateRoomCmd = new SqlCommand("UPDATE Rooms SET IsAvailable = 0 WHERE RoomNumber = @RoomNumber;", con, (SqlTransaction)tx))
                {
                    updateRoomCmd.Parameters.AddWithValue("@RoomNumber", roomNumber);
                    await updateRoomCmd.ExecuteNonQueryAsync();
                }


                await tx.CommitAsync();

                MessageBox.Show(
                    $"Booking #{bookingId} confirmed for {cmbCustomers.Text} in room {roomNumber} from {checkIn:d} to {checkOut:d}.",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                await LoadBookingsAsync();
                ClearForm();
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show("Database error while booking:\n" + sqlEx.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected error:\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedBookingId is null)
            {
                MessageBox.Show("Select a booking from the table to update.");
                return;
            }

            if (!TryGetSelectedInt(cmbCustomers, out var customerId) ||
                !TryGetSelectedInt(cmbRooms, out var roomNumber))
            {
                MessageBox.Show("Please select both a customer and a room.");
                return;
            }

            var checkIn = dtpCheckIn.Value.Date;
            var checkOut = dtpCheckOut.Value.Date;
            if (checkOut <= checkIn)
            {
                MessageBox.Show("Check-out date must be after check-in date.");
                return;
            }

            var status = cmbStatus.SelectedItem?.ToString() ?? "Confirmed";

            using var con = DatabaseHelper.GetConnection();
            if (con == null) return;

            try
            {
                await con.OpenAsync();
                using var tx = await con.BeginTransactionAsync();

                // Overlap check excluding this booking
                using (var checkCmd = new SqlCommand(@"
                    SELECT COUNT(1)
                    FROM Bookings WITH (UPDLOCK, HOLDLOCK)
                    WHERE RoomNumber = @RoomNumber
                      AND BookingID <> @BookingID
                      AND NOT (@CheckOut <= CheckIn OR @CheckIn >= CheckOut);", con, (SqlTransaction)tx))
                {
                    checkCmd.Parameters.AddWithValue("@RoomNumber", roomNumber);
                    checkCmd.Parameters.AddWithValue("@CheckIn", checkIn);
                    checkCmd.Parameters.AddWithValue("@CheckOut", checkOut);
                    checkCmd.Parameters.AddWithValue("@BookingID", selectedBookingId.Value);

                    var conflicts = (int)await checkCmd.ExecuteScalarAsync();
                    if (conflicts > 0)
                    {
                        await tx.RollbackAsync();
                        MessageBox.Show("Selected room is not available for the chosen dates.");
                        return;
                    }
                }

                using (var updateCmd = new SqlCommand(@"
                    UPDATE Bookings
                    SET CustomerID = @CustomerID,
                        RoomNumber = @RoomNumber,
                        CheckIn = @CheckIn,
                        CheckOut = @CheckOut,
                        Status = @Status
                    WHERE BookingID = @BookingID;", con, (SqlTransaction)tx))
                {
                    updateCmd.Parameters.AddWithValue("@CustomerID", customerId);
                    updateCmd.Parameters.AddWithValue("@RoomNumber", roomNumber);
                    updateCmd.Parameters.AddWithValue("@CheckIn", checkIn);
                    updateCmd.Parameters.AddWithValue("@CheckOut", checkOut);
                    updateCmd.Parameters.AddWithValue("@Status", status);
                    updateCmd.Parameters.AddWithValue("@BookingID", selectedBookingId.Value);

                    await updateCmd.ExecuteNonQueryAsync();
                }

                await tx.CommitAsync();

                MessageBox.Show("Booking updated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                await LoadBookingsAsync();
                ClearForm();
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show("Database error while updating booking:\n" + sqlEx.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected error:\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedBookingId is null)
            {
                MessageBox.Show("Select a booking to delete.");
                return;
            }

            var confirm = MessageBox.Show("Delete the selected booking? Any related payments will also be deleted.",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes) return;

            using var con = DatabaseHelper.GetConnection();
            if (con == null) return;

            try
            {
                await con.OpenAsync();
                using var tx = await con.BeginTransactionAsync();

                // Remove dependent payments first to satisfy FK (no cascade in schema)
                using (var delPay = new SqlCommand("DELETE FROM Payments WHERE BookingID = @BookingID;", con, (SqlTransaction)tx))
                {
                    delPay.Parameters.AddWithValue("@BookingID", selectedBookingId.Value);
                    await delPay.ExecuteNonQueryAsync();
                }

                using (var delBooking = new SqlCommand("DELETE FROM Bookings WHERE BookingID = @BookingID;", con, (SqlTransaction)tx))
                {
                    delBooking.Parameters.AddWithValue("@BookingID", selectedBookingId.Value);
                    var rows = await delBooking.ExecuteNonQueryAsync();
                    if (rows == 0)
                    {
                        await tx.RollbackAsync();
                        MessageBox.Show("Booking was not found.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }

                await tx.CommitAsync();

                MessageBox.Show("Booking deleted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                await LoadBookingsAsync();
                ClearForm();
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show("Database error while deleting booking:\n" + sqlEx.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected error:\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            await LoadBookingsAsync();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

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

            // Ensure current room appears even if IsAvailable = 0
            selectedRoomNumberForEdit = roomNo;
            await LoadRoomsAsync(forceIncludeRoomNumber: roomNo);

            // Select values in controls
            SelectComboByValue(cmbCustomers, custId);
            SelectComboByValue(cmbRooms, roomNo);

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
                // Fallback for non-bound, should not happen here
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
    }
}
