using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Hotel_Room_Booking_System
{
    partial class BookingForm
    {
        private IContainer components = null;
        private ComboBox cmbCustomers;
        private ComboBox cmbRooms;
        private DateTimePicker dtpCheckIn;
        private DateTimePicker dtpCheckOut;
        private ComboBox cmbStatus;
        private Button btnBook;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnRefresh;
        private Button btnClear;
        private Label lblCustomer;
        private Label lblRoom;
        private Label lblCheckIn;
        private Label lblCheckOut;
        private Label lblStatus;
        private DataGridView dgvBookings;
        private Label lblCount;

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
            cmbStatus = new ComboBox();
            btnBook = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnRefresh = new Button();
            btnClear = new Button();
            lblCustomer = new Label();
            lblRoom = new Label();
            lblCheckIn = new Label();
            lblCheckOut = new Label();
            lblStatus = new Label();
            dgvBookings = new DataGridView();
            lblCount = new Label();
            lblHeader = new Label();
            ((ISupportInitialize)dgvBookings).BeginInit();
            SuspendLayout();
            // 
            // cmbCustomers
            // 
            cmbCustomers.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCustomers.Font = new Font("Segoe UI", 12F);
            cmbCustomers.Location = new Point(292, 162);
            cmbCustomers.Margin = new Padding(5, 5, 5, 5);
            cmbCustomers.Name = "cmbCustomers";
            cmbCustomers.Size = new Size(518, 53);
            cmbCustomers.TabIndex = 0;
            // 
            // cmbRooms
            // 
            cmbRooms.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRooms.Font = new Font("Segoe UI", 12F);
            cmbRooms.Location = new Point(292, 239);
            cmbRooms.Margin = new Padding(5, 5, 5, 5);
            cmbRooms.Name = "cmbRooms";
            cmbRooms.Size = new Size(518, 53);
            cmbRooms.TabIndex = 1;
            // 
            // dtpCheckIn
            // 
            dtpCheckIn.Font = new Font("Segoe UI", 12F);
            dtpCheckIn.Location = new Point(292, 316);
            dtpCheckIn.Margin = new Padding(5, 5, 5, 5);
            dtpCheckIn.Name = "dtpCheckIn";
            dtpCheckIn.Size = new Size(518, 50);
            dtpCheckIn.TabIndex = 2;
            dtpCheckIn.ValueChanged += dtpCheckIn_ValueChanged;
            // 
            // dtpCheckOut
            // 
            dtpCheckOut.Font = new Font("Segoe UI", 12F);
            dtpCheckOut.Location = new Point(292, 393);
            dtpCheckOut.Margin = new Padding(5, 5, 5, 5);
            dtpCheckOut.Name = "dtpCheckOut";
            dtpCheckOut.Size = new Size(518, 50);
            dtpCheckOut.TabIndex = 3;
            // 
            // cmbStatus
            // 
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.Font = new Font("Segoe UI", 12F);
            cmbStatus.Location = new Point(292, 470);
            cmbStatus.Margin = new Padding(5, 5, 5, 5);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(518, 53);
            cmbStatus.TabIndex = 4;
            // 
            // btnBook
            // 
            btnBook.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnBook.Location = new Point(849, 162);
            btnBook.Margin = new Padding(5, 5, 5, 5);
            btnBook.Name = "btnBook";
            btnBook.Size = new Size(211, 58);
            btnBook.TabIndex = 5;
            btnBook.Text = "Add";
            btnBook.Click += btnBook_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnUpdate.Location = new Point(849, 234);
            btnUpdate.Margin = new Padding(5, 5, 5, 5);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(211, 58);
            btnUpdate.TabIndex = 6;
            btnUpdate.Text = "Update";
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnDelete.Location = new Point(849, 309);
            btnDelete.Margin = new Padding(5, 5, 5, 5);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(211, 58);
            btnDelete.TabIndex = 7;
            btnDelete.Text = "Delete";
            btnDelete.Click += btnDelete_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnRefresh.Location = new Point(849, 385);
            btnRefresh.Margin = new Padding(5, 5, 5, 5);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(211, 58);
            btnRefresh.TabIndex = 8;
            btnRefresh.Text = "Refresh";
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnClear
            // 
            btnClear.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnClear.Location = new Point(849, 463);
            btnClear.Margin = new Padding(5, 5, 5, 5);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(211, 58);
            btnClear.TabIndex = 9;
            btnClear.Text = "Clear";
            btnClear.Click += btnClear_Click;
            // 
            // lblCustomer
            // 
            lblCustomer.AutoSize = true;
            lblCustomer.Font = new Font("Segoe UI", 12F);
            lblCustomer.Location = new Point(39, 169);
            lblCustomer.Margin = new Padding(5, 0, 5, 0);
            lblCustomer.Name = "lblCustomer";
            lblCustomer.Size = new Size(165, 45);
            lblCustomer.TabIndex = 10;
            lblCustomer.Text = "Customer:";
            // 
            // lblRoom
            // 
            lblRoom.AutoSize = true;
            lblRoom.Font = new Font("Segoe UI", 12F);
            lblRoom.Location = new Point(39, 246);
            lblRoom.Margin = new Padding(5, 0, 5, 0);
            lblRoom.Name = "lblRoom";
            lblRoom.Size = new Size(111, 45);
            lblRoom.TabIndex = 11;
            lblRoom.Text = "Room:";
            // 
            // lblCheckIn
            // 
            lblCheckIn.AutoSize = true;
            lblCheckIn.Font = new Font("Segoe UI", 12F);
            lblCheckIn.Location = new Point(39, 322);
            lblCheckIn.Margin = new Padding(5, 0, 5, 0);
            lblCheckIn.Name = "lblCheckIn";
            lblCheckIn.Size = new Size(153, 45);
            lblCheckIn.TabIndex = 12;
            lblCheckIn.Text = "Check-In:";
            // 
            // lblCheckOut
            // 
            lblCheckOut.AutoSize = true;
            lblCheckOut.Font = new Font("Segoe UI", 12F);
            lblCheckOut.Location = new Point(39, 399);
            lblCheckOut.Margin = new Padding(5, 0, 5, 0);
            lblCheckOut.Name = "lblCheckOut";
            lblCheckOut.Size = new Size(179, 45);
            lblCheckOut.TabIndex = 13;
            lblCheckOut.Text = "Check-Out:";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 12F);
            lblStatus.Location = new Point(39, 476);
            lblStatus.Margin = new Padding(5, 0, 5, 0);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(113, 45);
            lblStatus.TabIndex = 14;
            lblStatus.Text = "Status:";
            // 
            // dgvBookings
            // 
            dgvBookings.AllowUserToAddRows = false;
            dgvBookings.AllowUserToDeleteRows = false;
            dgvBookings.AllowUserToOrderColumns = true;
            dgvBookings.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvBookings.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBookings.BackgroundColor = SystemColors.Window;
            dgvBookings.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBookings.Location = new Point(39, 562);
            dgvBookings.Margin = new Padding(5, 5, 5, 5);
            dgvBookings.MultiSelect = false;
            dgvBookings.Name = "dgvBookings";
            dgvBookings.ReadOnly = true;
            dgvBookings.RowHeadersVisible = false;
            dgvBookings.RowHeadersWidth = 82;
            dgvBookings.RowTemplate.Height = 33;
            dgvBookings.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBookings.Size = new Size(1342, 474);
            dgvBookings.TabIndex = 15;
            dgvBookings.CellClick += dgvBookings_SelectionChanged;
            // 
            // lblCount
            // 
            lblCount.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblCount.ForeColor = Color.FromArgb(30, 60, 114);
            lblCount.Location = new Point(39, 1051);
            lblCount.Margin = new Padding(5, 0, 5, 0);
            lblCount.Name = "lblCount";
            lblCount.Size = new Size(488, 58);
            lblCount.TabIndex = 16;
            lblCount.Text = "Total bookings: 0";
            lblCount.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblHeader
            // 
            lblHeader.AutoSize = true;
            lblHeader.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblHeader.ForeColor = Color.DarkSlateBlue;
            lblHeader.Location = new Point(410, 46);
            lblHeader.Margin = new Padding(5, 0, 5, 0);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(565, 72);
            lblHeader.TabIndex = 18;
            lblHeader.Text = "Booking Registration";
            lblHeader.Click += lblWelcome_Click;
            // 
            // BookingForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1420, 1148);
            Controls.Add(lblHeader);
            Controls.Add(cmbCustomers);
            Controls.Add(cmbRooms);
            Controls.Add(dtpCheckIn);
            Controls.Add(dtpCheckOut);
            Controls.Add(cmbStatus);
            Controls.Add(btnBook);
            Controls.Add(btnUpdate);
            Controls.Add(btnDelete);
            Controls.Add(btnRefresh);
            Controls.Add(btnClear);
            Controls.Add(lblCustomer);
            Controls.Add(lblRoom);
            Controls.Add(lblCheckIn);
            Controls.Add(lblCheckOut);
            Controls.Add(lblStatus);
            Controls.Add(dgvBookings);
            Controls.Add(lblCount);
            Margin = new Padding(5, 5, 5, 5);
            Name = "BookingForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Bookings";
            ((ISupportInitialize)dgvBookings).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        private Label lblHeader;
    }
}
