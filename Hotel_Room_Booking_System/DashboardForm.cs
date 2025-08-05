using Hotel_Room_Booking_System;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            //new CustomerForm().Show();
        }

        private void btnRooms_Click(object sender, EventArgs e)
        {
            //new RoomForm().Show();
        }

        private void btnBookings_Click(object sender, EventArgs e)
        {
            //new BookingForm().Show();
        }

        private void btnPayments_Click(object sender, EventArgs e)
        {
            //new PaymentForm().Show();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            SessionManager.Clear();
            this.Hide();
            new LoginForm().Show();
        }
    }
}
