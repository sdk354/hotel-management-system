using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;

namespace Hotel_Room_Booking_System
{
    public partial class RoomForm : Form
    {
        private int? selectedRoomNumber = null;

        public RoomForm()
        {
            InitializeComponent();
        }

        private void RoomForm_Load(object sender, EventArgs e)
        {
            cmbStatus.Items.Clear();
            cmbStatus.Items.AddRange(new string[] { "Available", "Occupied", "Maintenance" });
            cmbStatus.SelectedIndex = 0;

            dataGridView1.SelectionChanged += DataGridView1_SelectionChanged;
            LoadRoomsToGrid();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtRoomNumber.Text.Trim(), out int roomNumber))
            {
                MessageBox.Show("Please enter a valid numeric Room Number (e.g., 201).");
                return;
            }

            string type = textRoomType.Text.Trim();
            if (string.IsNullOrWhiteSpace(type))
            {
                MessageBox.Show("Please enter a room type.");
                return;
            }

            if (!decimal.TryParse(txtPric.Text.Trim(), out decimal price) || price < 0)
            {
                MessageBox.Show("Please enter a valid non-negative price.");
                return;
            }

            string status = cmbStatus.SelectedItem?.ToString() ?? "Available";
            bool isAvailable = status.Equals("Available", StringComparison.OrdinalIgnoreCase);

            var conn = DatabaseHelper.GetConnection();
            if (conn == null) return;

            using (conn)
            using (var cmd = new SqlCommand(
                @"INSERT INTO Rooms (RoomNumber, RoomType, Price, IsAvailable)
                  VALUES (@RoomNumber, @RoomType, @Price, @IsAvailable);", conn))
            {
                cmd.Parameters.AddWithValue("@RoomNumber", roomNumber);
                cmd.Parameters.AddWithValue("@RoomType", type);
                cmd.Parameters.AddWithValue("@Price", price);
                cmd.Parameters.AddWithValue("@IsAvailable", isAvailable);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    LoadRoomsToGrid();
                    ClearInputs();
                }
                catch (SqlException ex) when (ex.Number == 2627 || ex.Number == 2601)
                {
                    MessageBox.Show("That room number already exists. Please choose a different number.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error adding room: " + ex.Message);
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedRoomNumber == null)
            {
                MessageBox.Show("Please select a room to update.");
                return;
            }

            int roomNumber = selectedRoomNumber.Value;
            string type = textRoomType.Text.Trim();
            if (string.IsNullOrWhiteSpace(type))
            {
                MessageBox.Show("Please enter a room type.");
                return;
            }

            if (!decimal.TryParse(txtPric.Text.Trim(), out decimal price) || price < 0)
            {
                MessageBox.Show("Please enter a valid non-negative price.");
                return;
            }

            string status = cmbStatus.SelectedItem?.ToString() ?? "Available";
            bool isAvailable = status.Equals("Available", StringComparison.OrdinalIgnoreCase);

            var conn = DatabaseHelper.GetConnection();
            if (conn == null) return;

            using (conn)
            using (var cmd = new SqlCommand(
                @"UPDATE Rooms
                  SET RoomType = @RoomType, Price = @Price, IsAvailable = @IsAvailable
                  WHERE RoomNumber = @RoomNumber;", conn))
            {
                cmd.Parameters.AddWithValue("@RoomType", type);
                cmd.Parameters.AddWithValue("@Price", price);
                cmd.Parameters.AddWithValue("@IsAvailable", isAvailable);
                cmd.Parameters.AddWithValue("@RoomNumber", roomNumber);

                try
                {
                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();
                    if (rows == 0)
                    {
                        MessageBox.Show("Room not found. It may have been deleted.");
                    }
                    LoadRoomsToGrid();
                    ClearInputs();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating room: " + ex.Message);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedRoomNumber == null)
            {
                MessageBox.Show("Please select a room to delete.");
                return;
            }

            if (MessageBox.Show("Are you sure you want to delete this room?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
            {
                return;
            }

            var conn = DatabaseHelper.GetConnection();
            if (conn == null) return;

            using (conn)
            using (var cmd = new SqlCommand(
                @"DELETE FROM Rooms WHERE RoomNumber = @RoomNumber;", conn))
            {
                cmd.Parameters.AddWithValue("@RoomNumber", selectedRoomNumber.Value);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    LoadRoomsToGrid();
                    ClearInputs();
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 547)
                        MessageBox.Show("Cannot delete: this room has related bookings.");
                    else
                        MessageBox.Show("Error deleting room: " + ex.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting room: " + ex.Message);
                }
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadRoomsToGrid();
        }

        private void LoadRoomsToGrid()
        {
            var conn = DatabaseHelper.GetConnection();
            if (conn == null) return;

            using (conn)
            using (var da = new SqlDataAdapter(
                @"SELECT RoomNumber, RoomType, Price,
                  CASE WHEN IsAvailable = 1 THEN 'Available' ELSE 'Occupied' END AS Status
                  FROM Rooms ORDER BY RoomNumber;", conn))
            {
                var dt = new DataTable();
                try
                {
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    dataGridView1.ClearSelection();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading rooms: " + ex.Message);
                }
            }
        }

        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0) return;

            var row = dataGridView1.SelectedRows[0];
            if (row.Cells["RoomNumber"].Value == null) return;

            selectedRoomNumber = Convert.ToInt32(row.Cells["RoomNumber"].Value);

            txtRoomNumber.Text = selectedRoomNumber.Value.ToString();
            textRoomType.Text = row.Cells["RoomType"]?.Value?.ToString() ?? "";
            txtPric.Text = row.Cells["Price"]?.Value?.ToString() ?? "";

            var status = row.Cells["Status"]?.Value?.ToString() ?? "Available";
            cmbStatus.SelectedItem = cmbStatus.Items.Contains(status) ? status : "Available";

            txtRoomNumber.Enabled = false;
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearInputs();
        }

        private void ClearInputs()
        {
            txtRoomNumber.Clear();
            textRoomType.Clear();
            txtPric.Clear();
            cmbStatus.SelectedIndex = 0;
            selectedRoomNumber = null;
            txtRoomNumber.Enabled = true;
            dataGridView1.ClearSelection();
        }
    }
}
