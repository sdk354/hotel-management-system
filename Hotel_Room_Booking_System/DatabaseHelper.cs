using Microsoft.Data.SqlClient;
using System;
using System.Windows.Forms;

namespace Hotel_Room_Booking_System
{
    public static class DatabaseHelper
    {
        private static readonly string connectionString = "Data Source=localhost; Initial Catalog=HotelDB; Integrated Security=True; TrustServerCertificate=true";


        public static SqlConnection GetConnection()
        {
            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                return con;
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show("Database connection error:\n" + sqlEx.Message, "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected error:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
