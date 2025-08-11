using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Hotel_Room_Booking_System
{
    public partial class CustomerManagement : Form
    {
        private readonly List<Customer> customers = new();
        private Customer? selectedCustomer = null;

        public CustomerManagement()
        {
            InitializeComponent();
            this.Load += CustomerManagement_Load;
        }

        private void CustomerManagement_Load(object? sender, EventArgs e)
        {
            try
            {
                LoadCustomersFromDb();
                RefreshCustomerGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading customers: " + ex.Message);
            }
        }

        private void btnAdd_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(txtPhone.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            try
            {
                using SqlConnection con = DatabaseHelper.GetConnection();
                using SqlCommand cmd = new(
                    "INSERT INTO Customers (FullName, Phone, Email) VALUES (@FullName, @Phone, @Email);", con);

                cmd.Parameters.AddWithValue("@FullName", txtName.Text);
                cmd.Parameters.AddWithValue("@Phone", txtPhone.Text);
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);

                con.Open();
                cmd.ExecuteNonQuery();

                LoadCustomersFromDb();
                RefreshCustomerGrid();
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding customer: " + ex.Message);
            }
        }

        private void btnUpdate_Click(object? sender, EventArgs e)
        {
            if (selectedCustomer == null)
            {
                MessageBox.Show("Please select a customer to update.");
                return;
            }

            try
            {
                using SqlConnection con = DatabaseHelper.GetConnection();
                using SqlCommand cmd = new(
                    "UPDATE Customers SET FullName = @FullName, Phone = @Phone, Email = @Email WHERE CustomerID = @CustomerID", con);

                cmd.Parameters.AddWithValue("@FullName", txtName.Text);
                cmd.Parameters.AddWithValue("@Phone", txtPhone.Text);
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@CustomerID", selectedCustomer.CustomerID);

                con.Open();
                cmd.ExecuteNonQuery();

                LoadCustomersFromDb();
                RefreshCustomerGrid();
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating customer: " + ex.Message);
            }
        }

        private void btnDelete_Click(object? sender, EventArgs e)
        {
            if (selectedCustomer == null)
            {
                MessageBox.Show("Please select a customer to delete.");
                return;
            }

            try
            {
                using SqlConnection con = DatabaseHelper.GetConnection();
                using SqlCommand cmd = new(
                    "DELETE FROM Customers WHERE CustomerID = @CustomerID", con);

                cmd.Parameters.AddWithValue("@CustomerID", selectedCustomer.CustomerID);

                con.Open();
                cmd.ExecuteNonQuery();

                LoadCustomersFromDb();
                RefreshCustomerGrid();
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting customer: " + ex.Message);
            }
        }

        private void dgvCustomers_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvCustomers.Rows.Count)
                return;

            var row = dgvCustomers.Rows[e.RowIndex];

            if (row.DataBoundItem is Customer cust)
            {
                selectedCustomer = cust;
                txtName.Text = cust.FullName;
                txtPhone.Text = cust.Phone;
                txtEmail.Text = cust.Email;
            }
        }

        private void LoadCustomersFromDb()
        {
            customers.Clear();

            using SqlConnection con = DatabaseHelper.GetConnection();
            using SqlCommand cmd = new("SELECT CustomerID, FullName, Phone, Email FROM Customers", con);

            con.Open();
            using SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                customers.Add(new Customer
                {
                    CustomerID = Convert.ToInt32(reader["CustomerID"]),
                    FullName = reader["FullName"]?.ToString() ?? "",
                    Phone = reader["Phone"]?.ToString() ?? "",
                    Email = reader["Email"]?.ToString() ?? ""
                });
            }
        }

        private void RefreshCustomerGrid()
        {
            dgvCustomers.AutoGenerateColumns = true;
            dgvCustomers.DataSource = null;
            dgvCustomers.DataSource = customers;
            dgvCustomers.ClearSelection();

            if (dgvCustomers.Columns["CustomerID"] != null)
                dgvCustomers.Columns["CustomerID"].Visible = false;
        }

        private void ClearInputs()
        {
            txtName.Text = "";
            txtPhone.Text = "";
            txtEmail.Text = "";
            selectedCustomer = null;
        }
    }

    public class Customer
    {
        public int CustomerID { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
