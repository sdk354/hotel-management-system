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
            toolStrip1 = new ToolStrip();
            SuspendLayout();
            // 
            // btnCustomers
            // 
            btnCustomers.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            btnCustomers.Location = new Point(327, 308);
            btnCustomers.Margin = new Padding(5, 5, 5, 5);
            btnCustomers.Name = "btnCustomers";
            btnCustomers.Size = new Size(292, 96);
            btnCustomers.TabIndex = 6;
            btnCustomers.Text = "Customers";
            btnCustomers.UseVisualStyleBackColor = true;
            btnCustomers.Click += btnCustomers_Click;
            // 
            // btnRooms
            // 
            btnRooms.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            btnRooms.Location = new Point(327, 178);
            btnRooms.Margin = new Padding(5, 5, 5, 5);
            btnRooms.Name = "btnRooms";
            btnRooms.Size = new Size(292, 96);
            btnRooms.TabIndex = 3;
            btnRooms.Text = "Rooms";
            btnRooms.UseVisualStyleBackColor = true;
            btnRooms.Click += btnRooms_Click;
            // 
            // btnBookings
            // 
            btnBookings.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            btnBookings.Location = new Point(656, 178);
            btnBookings.Margin = new Padding(5, 5, 5, 5);
            btnBookings.Name = "btnBookings";
            btnBookings.Size = new Size(292, 96);
            btnBookings.TabIndex = 4;
            btnBookings.Text = "Bookings";
            btnBookings.UseVisualStyleBackColor = true;
            btnBookings.Click += btnBookings_Click;
            // 
            // btnPayments
            // 
            btnPayments.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            btnPayments.Location = new Point(656, 308);
            btnPayments.Margin = new Padding(5, 5, 5, 5);
            btnPayments.Name = "btnPayments";
            btnPayments.Size = new Size(292, 96);
            btnPayments.TabIndex = 5;
            btnPayments.Text = "Payments";
            btnPayments.UseVisualStyleBackColor = true;
            btnPayments.Click += btnPayments_Click;
            // 
            // btnLogout
            // 
            btnLogout.Font = new Font("Segoe UI", 11F);
            btnLogout.Location = new Point(1115, 52);
            btnLogout.Margin = new Padding(5, 5, 5, 5);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(162, 64);
            btnLogout.TabIndex = 2;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // btnRegister
            // 
            btnRegister.Font = new Font("Segoe UI", 11F);
            btnRegister.Location = new Point(32, 52);
            btnRegister.Margin = new Padding(5, 5, 5, 5);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(162, 64);
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
            lblWelcome.Location = new Point(260, 44);
            lblWelcome.Margin = new Padding(5, 0, 5, 0);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(793, 72);
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = "Welcome to Our Hotel System";
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(32, 32);
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1326, 25);
            toolStrip1.TabIndex = 7;
            toolStrip1.Text = "toolStrip1";
            // 
            // DashboardForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1326, 448);
            Controls.Add(toolStrip1);
            Controls.Add(lblWelcome);
            Controls.Add(btnRegister);
            Controls.Add(btnLogout);
            Controls.Add(btnRooms);
            Controls.Add(btnBookings);
            Controls.Add(btnPayments);
            Controls.Add(btnCustomers);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(5, 5, 5, 5);
            MaximizeBox = false;
            Name = "DashboardForm";
            Text = "Dashboard";
            ResumeLayout(false);
            PerformLayout();
        }
        private ToolStrip toolStrip1;
    }
}