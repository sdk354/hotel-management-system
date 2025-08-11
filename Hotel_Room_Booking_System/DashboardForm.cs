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
            new CustomerManagement().Show();
        }

        private void btnRooms_Click(object sender, EventArgs e)
        {
            new RoomForm().Show();
        }

        private void btnBookings_Click(object sender, EventArgs e)
        {
            new BookingForm().Show();
        }

        private void btnPayments_Click(object sender, EventArgs e)
        {
            new PaymentForm().Show();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            new RegistrationForm().Show();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            // Clear session and delegate the flow to ShellContext
            SessionManager.Clear();
            this.Hide();

            // Do NOT call this.Close() here; let ShellContext orchestrate closure + relogin
            ShellContext.Current.Relogin();
        }
    }
}
