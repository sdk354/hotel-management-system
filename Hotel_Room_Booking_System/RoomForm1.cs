using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Hotel_Room_Booking_System
{
    public partial class RoomForm1 : Form
    {
        private List<Room> roomList = new List<Room>();
        private int? selectedRoomId = null;
        private int roomIdCounter = 1;

        public RoomForm1()
        {
            InitializeComponent();
        }

        private void RoomForm_Load(object sender, EventArgs e)
        {
            cmbStatus.Items.AddRange(new string[] { "Available", "Occupied", "Maintenance" });
            cmbStatus.SelectedIndex = 0;
            LoadRoomsToGrid();
            dataGridView1.SelectionChanged += DataGridView1_SelectionChanged;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string type = textRoomType.Text.Trim();
            string priceText = txtPric.Text.Trim();
            string status = cmbStatus.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(type) || string.IsNullOrEmpty(priceText) || !decimal.TryParse(priceText, out decimal price))
            {
                MessageBox.Show("Please enter valid room details.");
                return;
            }

            Room newRoom = new Room
            {
                Id = roomIdCounter++,
                Type = type,
                Price = price,
                Status = status
            };

            roomList.Add(newRoom);
            LoadRoomsToGrid();
            ClearInputs();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedRoomId == null)
            {
                MessageBox.Show("Please select a room to update.");
                return;
            }

            var room = roomList.FirstOrDefault(r => r.Id == selectedRoomId);
            if (room != null)
            {
                room.Type = textRoomType.Text.Trim();
                room.Status = cmbStatus.SelectedItem?.ToString();
                if (decimal.TryParse(txtPric.Text.Trim(), out decimal updatedPrice))
                {
                    room.Price = updatedPrice;
                }
                else
                {
                    MessageBox.Show("Invalid price.");
                    return;
                }

                LoadRoomsToGrid();
                ClearInputs();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedRoomId == null)
            {
                MessageBox.Show("Please select a room to delete.");
                return;
            }

            var room = roomList.FirstOrDefault(r => r.Id == selectedRoomId);
            if (room != null)
            {
                roomList.Remove(room);
                LoadRoomsToGrid();
                ClearInputs();
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadRoomsToGrid();
        }

        private void LoadRoomsToGrid()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = roomList.Select(r => new
            {
                r.Id,
                r.Type,
                r.Price,
                r.Status
            }).ToList();

            dataGridView1.ClearSelection();
        }

        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var row = dataGridView1.SelectedRows[0];
                selectedRoomId = Convert.ToInt32(row.Cells["Id"].Value);
                textRoomType.Text = row.Cells["Type"].Value.ToString();
                txtPric.Text = row.Cells["Price"].Value.ToString();
                cmbStatus.SelectedItem = row.Cells["Status"].Value.ToString();
            }
        }

        private void ClearInputs()
        {
            textRoomType.Clear();
            txtPric.Clear();
            cmbStatus.SelectedIndex = 0;
            selectedRoomId = null;
        }

        // Room class
        private class Room
        {
            public int Id { get; set; }
            public string Type { get; set; }
            public decimal Price { get; set; }
            public string Status { get; set; }
        }
    }
}
