using System;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;

namespace Hotel_Room_Booking_System
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string query = "SELECT COUNT(*) FROM Admins WHERE Username=@username AND Password=@password";
            using (SqlConnection con = DatabaseHelper.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@username", txtUsername.Text);
                cmd.Parameters.AddWithValue("@password", txtPassword.Text);
                con.Open();
                int count = (int)cmd.ExecuteScalar();
                if (count > 0)
                {
                    SessionManager.Username = txtUsername.Text;
                    this.Hide();
                    new DashboardForm().Show();
                }
                else
                {
                    MessageBox.Show("Invalid credentials.");
                }
            }
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
