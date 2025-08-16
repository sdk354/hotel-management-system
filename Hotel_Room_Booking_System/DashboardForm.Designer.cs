// ... (existing using statements)

namespace Hotel_Room_Booking_System
{
    partial class DashboardForm
    {
        private System.ComponentModel.IContainer components = null;

        private Button btnCustomers;
        private Button btnRooms;
        private Button btnBookings;
        private Button btnPayments;
        private Button btnLogout;
        private Label lblWelcome;
        private Button btnRegister;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            btnCustomers = new Button();
            btnRooms = new Button();
            btnBookings = new Button();
            btnPayments = new Button();
            btnLogout = new Button();
            btnRegister = new Button();
            lblWelcome = new Label();
            SuspendLayout();
            // 
            // btnCustomers
            // 
            btnCustomers.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            btnCustomers.Location = new Point(340, 180);
            btnCustomers.Name = "btnCustomers";
            btnCustomers.Size = new Size(180, 60);
            btnCustomers.TabIndex = 6;
            btnCustomers.Text = "Customers";
            btnCustomers.UseVisualStyleBackColor = true;
            btnCustomers.Click += btnCustomers_Click;
            // 
            // btnRooms
            // 
            btnRooms.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            btnRooms.Location = new Point(120, 100);
            btnRooms.Name = "btnRooms";
            btnRooms.Size = new Size(180, 60);
            btnRooms.TabIndex = 3;
            btnRooms.Text = "Rooms";
            btnRooms.UseVisualStyleBackColor = true;
            btnRooms.Click += btnRooms_Click;
            // 
            // btnBookings
            // 
            btnBookings.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            btnBookings.Location = new Point(340, 100);
            btnBookings.Name = "btnBookings";
            btnBookings.Size = new Size(180, 60);
            btnBookings.TabIndex = 4;
            btnBookings.Text = "Bookings";
            btnBookings.UseVisualStyleBackColor = true;
            btnBookings.Click += btnBookings_Click;
            // 
            // btnPayments
            // 
            btnPayments.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            btnPayments.Location = new Point(560, 100);
            btnPayments.Name = "btnPayments";
            btnPayments.Size = new Size(180, 60);
            btnPayments.TabIndex = 5;
            btnPayments.Text = "Payments";
            btnPayments.UseVisualStyleBackColor = true;
            btnPayments.Click += btnPayments_Click;
            // 
            // btnLogout
            // 
            btnLogout.Font = new Font("Segoe UI", 11F);
            btnLogout.Location = new Point(760, 20);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(100, 40);
            btnLogout.TabIndex = 2;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // btnRegister
            // 
            btnRegister.Font = new Font("Segoe UI", 11F);
            btnRegister.Location = new Point(20, 20);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(100, 40);
            btnRegister.TabIndex = 1;
            btnRegister.Text = "Admins";
            btnRegister.UseVisualStyleBackColor = true;
            btnRegister.Click += btnRegister_Click;
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblWelcome.ForeColor = Color.DarkSlateBlue;
            lblWelcome.Location = new Point(204, 20);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(499, 46);
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = "Welcome to Our Hotel System";
            // 
            // DashboardForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(880, 280);
            Controls.Add(lblWelcome);
            Controls.Add(btnRegister);
            Controls.Add(btnLogout);
            Controls.Add(btnRooms);
            Controls.Add(btnBookings);
            Controls.Add(btnPayments);
            Controls.Add(btnCustomers);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "DashboardForm";
            Text = "Dashboard";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}