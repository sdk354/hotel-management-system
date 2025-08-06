using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Hotel_Room_Booking_System
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            txtPassword.UseSystemPasswordChar = true;  // Hide password input initially
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter username and password.");
                return;
            }

            try
            {
                using (SqlConnection con = DatabaseHelper.GetConnection())
                using (SqlCommand cmd = new SqlCommand("SELECT Password FROM Admins WHERE Username = @username", con))
                {
                    cmd.Parameters.Add("@username", SqlDbType.NVarChar, 50).Value = username;
                    con.Open();

                    var storedPasswordObj = cmd.ExecuteScalar();

                    if (storedPasswordObj == null)
                    {
                        MessageBox.Show("Invalid username or password.");
                        return;
                    }

                    string storedPassword = storedPasswordObj.ToString();

                    if (password == storedPassword)  // Simple plain text comparison
                    {
                        SessionManager.Username = username;
                        this.Hide();
                        new DashboardForm().Show();
                    }
                    else
                    {
                        MessageBox.Show("Invalid username or password.");
                        txtPassword.Clear();
                        txtPassword.Focus();
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Checkbox event handler to show/hide password
        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
        }
    }
}
