using System;
using System.Windows.Forms;
using System.Drawing;

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
            lblWelcome = new Label();
            SuspendLayout();
            // 
            // btnCustomers
            // 
            btnCustomers.Font = new Font("Segoe UI", 12F);
            btnCustomers.Location = new Point(611, 169);
            btnCustomers.Name = "btnCustomers";
            btnCustomers.Size = new Size(200, 60);
            btnCustomers.TabIndex = 1;
            btnCustomers.Text = "User";
            btnCustomers.UseVisualStyleBackColor = true;
            btnCustomers.Click += btnCustomers_Click;
            // 
            // btnRooms
            // 
            btnRooms.Font = new Font("Segoe UI", 12F);
            btnRooms.Location = new Point(98, 169);
            btnRooms.Name = "btnRooms";
            btnRooms.Size = new Size(200, 60);
            btnRooms.TabIndex = 2;
            btnRooms.Text = "Rooms";
            btnRooms.UseVisualStyleBackColor = true;
            btnRooms.Click += btnRooms_Click;
            // 
            // btnBookings
            // 
            btnBookings.Font = new Font("Segoe UI", 12F);
            btnBookings.Location = new Point(354, 257);
            btnBookings.Name = "btnBookings";
            btnBookings.Size = new Size(200, 60);
            btnBookings.TabIndex = 3;
            btnBookings.Text = "Bookings";
            btnBookings.UseVisualStyleBackColor = true;
            btnBookings.Click += btnBookings_Click;
            // 
            // btnPayments
            // 
            btnPayments.Font = new Font("Segoe UI", 12F);
            btnPayments.Location = new Point(354, 99);
            btnPayments.Name = "btnPayments";
            btnPayments.Size = new Size(200, 60);
            btnPayments.TabIndex = 4;
            btnPayments.Text = "Payments";
            btnPayments.UseVisualStyleBackColor = true;
            btnPayments.Click += btnPayments_Click;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = SystemColors.Control;
            btnLogout.Font = new Font("Segoe UI", 12F);
            btnLogout.Location = new Point(797, 302);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(91, 36);
            btnLogout.TabIndex = 5;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblWelcome.Location = new Point(293, 24);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(332, 41);
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = "Welcome to Our Hotel";
            // 
            // DashboardForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientInactiveCaption;
            ClientSize = new Size(892, 341);
            Controls.Add(lblWelcome);
            Controls.Add(btnCustomers);
            Controls.Add(btnRooms);
            Controls.Add(btnBookings);
            Controls.Add(btnPayments);
            Controls.Add(btnLogout);
            Name = "DashboardForm";
            Text = "Dashboard";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
