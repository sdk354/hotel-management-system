using System;
using System.Linq;
using System.Windows.Forms;

namespace Hotel_Room_Booking_System
{
    public partial class DashboardForm : Form
    {
        public DashboardForm()
        {
            InitializeComponent();
        }

        private void ShowSingleForm<T>() where T : Form, new()
        {
            var form = Application.OpenForms.OfType<T>().FirstOrDefault();
            if (form != null)
            {
                if (form.WindowState == FormWindowState.Minimized)
                    form.WindowState = FormWindowState.Normal;
                form.BringToFront();
            }
            else
            {
                new T().Show();
            }
        }

        private void btnCustomers_Click(object sender, EventArgs e)
            => ShowSingleForm<CustomerManagement>();

        private void btnRooms_Click(object sender, EventArgs e)
            => ShowSingleForm<RoomForm>();

        private void btnBookings_Click(object sender, EventArgs e)
            => ShowSingleForm<BookingForm>();

        private void btnPayments_Click(object sender, EventArgs e)
            => ShowSingleForm<PaymentForm>();

        private void btnRegister_Click(object sender, EventArgs e)
            => ShowSingleForm<RegistrationForm>();

        private void btnLogout_Click(object sender, EventArgs e)
        {
            SessionManager.Clear();
            Hide();
            ShellContext.Current.Relogin();
        }
    }
}
