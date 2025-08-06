using System;
using System.Windows.Forms;

namespace Hotel_Room_Booking_System
{
    public partial class BookingForm : Form
    {
        public BookingForm()
        {
            InitializeComponent();
        }

        private void btnBook_Click(object sender, EventArgs e)
        {
            string customer = cmbCustomers.SelectedItem?.ToString();
            string room = cmbRooms.SelectedItem?.ToString();
            DateTime checkIn = dtpCheckIn.Value;
            DateTime checkOut = dtpCheckOut.Value;

            if (string.IsNullOrWhiteSpace(customer) || string.IsNullOrWhiteSpace(room))
            {
                MessageBox.Show("Please select both a customer and a room.");
                return;
            }

            if (checkOut <= checkIn)
            {
                MessageBox.Show("Check-out date must be after check-in date.");
                return;
            }

            MessageBox.Show($"Booking confirmed for {customer} in room {room} from {checkIn.ToShortDateString()} to {checkOut.ToShortDateString()}.");
        }
    }
}
