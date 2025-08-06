using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Hotel_Room_Booking_System
{
    public partial class PaymentForm : Form
    {
        private List<Payment> paymentList = new List<Payment>();

        public PaymentForm()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            // Validate inputs
            if (string.IsNullOrWhiteSpace(txtBookingID.Text) ||
                string.IsNullOrWhiteSpace(txtGuestName.Text) ||
                !decimal.TryParse(txtAmount.Text, out decimal amount) ||
                cmbPaymentMethod.SelectedIndex < 0)
            {
                MessageBox.Show("Please fill all fields with valid data.");
                return;
            }

            Payment payment = new Payment
            {
                BookingID = txtBookingID.Text.Trim(),
                GuestName = txtGuestName.Text.Trim(),
                Amount = amount,
                PaymentMethod = cmbPaymentMethod.SelectedItem.ToString(),
                PaymentDate = dtpPaymentDate.Value.Date
            };

            paymentList.Add(payment);

            MessageBox.Show("Payment recorded successfully!");

            ClearForm();
            LoadPaymentsToGrid();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void btnViewPayments_Click(object sender, EventArgs e)
        {
            LoadPaymentsToGrid();
        }

        private void LoadPaymentsToGrid()
        {
            dataGridViewPayments.DataSource = null;
            dataGridViewPayments.DataSource = paymentList.Select(p => new
            {
                p.BookingID,
                p.GuestName,
                p.Amount,
                p.PaymentMethod,
                PaymentDate = p.PaymentDate.ToShortDateString()
            }).ToList();
        }

        private void ClearForm()
        {
            txtBookingID.Clear();
            txtGuestName.Clear();
            txtAmount.Clear();
            cmbPaymentMethod.SelectedIndex = 0;
            dtpPaymentDate.Value = DateTime.Today;
        }

        private class Payment
        {
            public string BookingID { get; set; }
            public string GuestName { get; set; }
            public decimal Amount { get; set; }
            public string PaymentMethod { get; set; }
            public DateTime PaymentDate { get; set; }
        }
    }
}
