using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Hotel_Room_Booking_System
{
    public partial class UserManagement : Form
    {


        private List<User> users = new List<User>();
        private int selectedIndex = -1;

       

        private void btnAdd_Click(object sender, EventArgs e) // Used to to add user to the list
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(txtPhone.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            users.Add(new User
            {
                Name = txtName.Text,
                Phone = txtPhone.Text,
                Email = txtEmail.Text
            });

            ClearInputs();
            RefreshUserGrid();
        }

        private void UserManagement_Load(object sender, EventArgs e)
        {
            users.Add(new User { Name = "Alice", Phone = "123", Email = "alice@example.com" });
            users.Add(new User { Name = "Bob", Phone = "456", Email = "bob@example.com" });
            RefreshUserGrid();
        }

        private void btnUpdate_Click(object sender, EventArgs e) 
        {
            if (selectedIndex < 0 || selectedIndex >= users.Count)
            {
                MessageBox.Show("Please select a user to update.");
                return;
            }

            users[selectedIndex].Name = txtName.Text;
            users[selectedIndex].Phone = txtPhone.Text;
            users[selectedIndex].Email = txtEmail.Text;

            ClearInputs();
            RefreshUserGrid();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedIndex < 0 || selectedIndex >= users.Count)
            {
                MessageBox.Show("Please select a user to delete.");
                return;
            }

            var result = MessageBox.Show("Are you sure you want to delete this user?", "Confirm Delete", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                users.RemoveAt(selectedIndex);
                ClearInputs();
                RefreshUserGrid();
            }
        }

        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ignore header clicks or invalid index
            if (e.RowIndex < 0)
                return;

            // Get the current row
            DataGridViewRow row = dgvUsers.Rows[e.RowIndex];

            // Update selected index
            selectedIndex = e.RowIndex;

            // Fill textboxes from row cells
            txtName.Text = row.Cells["Name"].Value?.ToString();
            txtPhone.Text = row.Cells["Phone"].Value?.ToString();
            txtEmail.Text = row.Cells["Email"].Value?.ToString();
        }



        private void RefreshUserGrid()
        {
            dgvUsers.DataSource = null;
            dgvUsers.DataSource = users;
            dgvUsers.ClearSelection(); // this deselects any rows for better usage
        }

        private void ClearInputs()
        {
            txtName.Text = "";
            txtPhone.Text = "";
            txtEmail.Text = "";
            selectedIndex = -1;
        }
        public UserManagement()
        {
            InitializeComponent();
            this.Load += UserManagement_Load;
            RefreshUserGrid();
        }
    }
}
