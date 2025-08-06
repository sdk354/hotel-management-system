namespace Hotel_Room_Booking_System
{
    partial class BookingForm
    {
        private System.ComponentModel.IContainer components = null;

        private ComboBox cmbCustomers;
        private ComboBox cmbRooms;
        private DateTimePicker dtpCheckIn;
        private DateTimePicker dtpCheckOut;
        private Button btnBook;
        private Label lblCustomer;
        private Label lblRoom;
        private Label lblCheckIn;
        private Label lblCheckOut;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            cmbCustomers = new ComboBox();
            cmbRooms = new ComboBox();
            dtpCheckIn = new DateTimePicker();
            dtpCheckOut = new DateTimePicker();
            btnBook = new Button();
            lblCustomer = new Label();
            lblRoom = new Label();
            lblCheckIn = new Label();
            lblCheckOut = new Label();

            SuspendLayout();

            // ComboBox Customers
            cmbCustomers.Location = new System.Drawing.Point(150, 30);
            cmbCustomers.Size = new System.Drawing.Size(200, 28);
            cmbCustomers.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCustomers.Items.AddRange(new object[] { "Customer 1", "Customer 2" }); // Replace with dynamic data

            // ComboBox Rooms
            cmbRooms.Location = new System.Drawing.Point(150, 70);
            cmbRooms.Size = new System.Drawing.Size(200, 28);
            cmbRooms.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRooms.Items.AddRange(new object[] { "Room 101", "Room 102" }); // Replace with dynamic data

            // DateTimePicker Check-in
            dtpCheckIn.Location = new System.Drawing.Point(150, 110);
            dtpCheckIn.Size = new System.Drawing.Size(200, 27);

            // DateTimePicker Check-out
            dtpCheckOut.Location = new System.Drawing.Point(150, 150);
            dtpCheckOut.Size = new System.Drawing.Size(200, 27);

            // Book Button
            btnBook.Text = "Book";
            btnBook.Location = new System.Drawing.Point(150, 190);
            btnBook.Size = new System.Drawing.Size(100, 30);
            btnBook.Click += btnBook_Click;

            // Labels
            lblCustomer.Text = "Customer:";
            lblCustomer.Location = new System.Drawing.Point(50, 30);

            lblRoom.Text = "Room:";
            lblRoom.Location = new System.Drawing.Point(50, 70);

            lblCheckIn.Text = "Check-In:";
            lblCheckIn.Location = new System.Drawing.Point(50, 110);

            lblCheckOut.Text = "Check-Out:";
            lblCheckOut.Location = new System.Drawing.Point(50, 150);

            // Form
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(400, 250);
            Controls.Add(lblCustomer);
            Controls.Add(lblRoom);
            Controls.Add(lblCheckIn);
            Controls.Add(lblCheckOut);
            Controls.Add(cmbCustomers);
            Controls.Add(cmbRooms);
            Controls.Add(dtpCheckIn);
            Controls.Add(dtpCheckOut);
            Controls.Add(btnBook);
            Name = "BookingForm";
            Text = "Booking Form";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
