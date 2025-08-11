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
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblWelcome.Text = "Welcome to Our Hotel";
            lblWelcome.Location = new Point((892 - 332) / 2, 20);
            lblWelcome.Size = new Size(332, 41);

            // 
            // btnRegister (Top Left)
            // 
            btnRegister.Font = new Font("Segoe UI", 12F);
            btnRegister.Location = new Point(20, 20);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(91, 36);
            btnRegister.TabIndex = 1;
            btnRegister.Text = "Admins";
            btnRegister.UseVisualStyleBackColor = true;
            btnRegister.Click += btnRegister_Click;

            // 
            // btnLogout (Top Right)
            // 
            btnLogout.Font = new Font("Segoe UI", 12F);
            btnLogout.Location = new Point(781, 20);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(91, 36);
            btnLogout.TabIndex = 2;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;

            // 
            // btnRooms (Top Left of Center Grid)
            // 
            btnRooms.Font = new Font("Segoe UI", 12F);
            btnRooms.Location = new Point(256, 100); // centered grid left
            btnRooms.Name = "btnRooms";
            btnRooms.Size = new Size(180, 60);
            btnRooms.TabIndex = 3;
            btnRooms.Text = "Rooms";
            btnRooms.UseVisualStyleBackColor = true;
            btnRooms.Click += btnRooms_Click;

            // 
            // btnBookings (Top Right of Center Grid)
            // 
            btnBookings.Font = new Font("Segoe UI", 12F);
            btnBookings.Location = new Point(456, 100); // centered grid right
            btnBookings.Name = "btnBookings";
            btnBookings.Size = new Size(180, 60);
            btnBookings.TabIndex = 4;
            btnBookings.Text = "Bookings";
            btnBookings.UseVisualStyleBackColor = true;
            btnBookings.Click += btnBookings_Click;

            // 
            // btnPayments (Bottom Left of Center Grid)
            // 
            btnPayments.Font = new Font("Segoe UI", 12F);
            btnPayments.Location = new Point(256, 180); // centered grid left
            btnPayments.Name = "btnPayments";
            btnPayments.Size = new Size(180, 60);
            btnPayments.TabIndex = 5;
            btnPayments.Text = "Payments";
            btnPayments.UseVisualStyleBackColor = true;
            btnPayments.Click += btnPayments_Click;

            // 
            // btnCustomers (Bottom Right of Center Grid)
            // 
            btnCustomers.Font = new Font("Segoe UI", 12F);
            btnCustomers.Location = new Point(456, 180); // centered grid right
            btnCustomers.Name = "btnCustomers";
            btnCustomers.Size = new Size(180, 60);
            btnCustomers.TabIndex = 6;
            btnCustomers.Text = "Customers";
            btnCustomers.UseVisualStyleBackColor = true;
            btnCustomers.Click += btnCustomers_Click;

            // 
            // DashboardForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientInactiveCaption;
            ClientSize = new Size(892, 300);
            Controls.Add(lblWelcome);
            Controls.Add(btnRegister);
            Controls.Add(btnLogout);
            Controls.Add(btnRooms);
            Controls.Add(btnBookings);
            Controls.Add(btnPayments);
            Controls.Add(btnCustomers);
            Name = "DashboardForm";
            Text = "Dashboard";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
