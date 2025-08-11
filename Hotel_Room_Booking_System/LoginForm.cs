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
            txtPassword.UseSystemPasswordChar = true;   // Hide password input initially
            this.AcceptButton = btnLogin;               // Press Enter to trigger login
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
                using (SqlCommand cmd = new SqlCommand(
                    "SELECT Password, Role FROM Admins WHERE Username = @username", con))
                {
                    cmd.Parameters.Add("@username", SqlDbType.NVarChar, 50).Value = username;
                    con.Open();

                    using (var reader = cmd.ExecuteReader(CommandBehavior.SingleRow))
                    {
                        if (!reader.Read())
                        {
                            MessageBox.Show("Username not found.");
                            return;
                        }

                        string storedPassword = reader.IsDBNull(0) ? "" : reader.GetString(0);
                        string role = reader.IsDBNull(1) ? "" : reader.GetString(1);

                        if (password == storedPassword) // Plain text comparison for now
                        {
                            SessionManager.Username = username;
                            SessionManager.CurrentUserRole = role?.Trim() ?? "";

                            this.DialogResult = DialogResult.OK; // success
                            this.Close();                         // return control to ShellContext
                        }
                        else
                        {
                            MessageBox.Show("Invalid password.");
                            txtPassword.Clear();
                            txtPassword.Focus();
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Show/hide password
        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
        }

        // Ensure closing via [X] returns a non-OK result so the app exits
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (this.DialogResult == DialogResult.None)
                this.DialogResult = DialogResult.Cancel;
        }
    }
}
