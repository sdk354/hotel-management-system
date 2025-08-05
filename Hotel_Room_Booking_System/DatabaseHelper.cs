using Microsoft.Data.SqlClient;

namespace Hotel_Room_Booking_System
{
    public static class DatabaseHelper
    {
        private static readonly string connectionString = "Data Source=localhost; Initial Catalog=HotelDB; Integrated Security=True; TrustServerCertificate=true";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
