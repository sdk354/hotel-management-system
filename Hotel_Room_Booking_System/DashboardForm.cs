using System;
using System.Windows.Forms;

namespace Hotel_Room_Booking_System
{
    public partial class DashboardForm : Form
    {
        public DashboardForm()
        {
            InitializeComponent();
        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            new UserManagement().Show();  
        }

        private void btnRooms_Click(object sender, EventArgs e)
        {
            new RoomForm1().Show(); 
        }

        private void btnBookings_Click(object sender, EventArgs e)
        {
            new BookingForm().Show();
        }

        private void btnPayments_Click(object sender, EventArgs e)
        {
            new PaymentForm().Show();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            SessionManager.Clear();
            this.Hide();
            new LoginForm().Show();
        }
    }
}
