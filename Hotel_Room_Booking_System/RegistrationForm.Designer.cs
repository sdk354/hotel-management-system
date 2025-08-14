using System;
using System.Drawing;
using System.Windows.Forms;

namespace Hotel_Room_Booking_System
{
    partial class RegistrationForm
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private ComboBox cmbRole;
        private Button btnSave;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnRefresh;
        private Button btnClear;
        private Label lblUsername;
        private Label lblPassword;
        private Label lblRole;
        private DataGridView dgvAdmins;
        private Label lblHeader;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            cmbRole = new ComboBox();
            btnSave = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnRefresh = new Button();
            btnClear = new Button();
            lblUsername = new Label();
            lblPassword = new Label();
            lblRole = new Label();
            dgvAdmins = new DataGridView();
            lblHeader = new Label();

            ((System.ComponentModel.ISupportInitialize)dgvAdmins).BeginInit();
            SuspendLayout();

            // Header
            // 
            lblHeader.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblHeader.Location = new Point(24, 18);
            lblHeader.Text = "Admin Registration";

            // Username
            lblUsername.AutoSize = true;
            lblUsername.Location = new Point(24, 72);
            lblUsername.Text = "Username";
            txtUsername.Location = new Point(150, 68);
            txtUsername.Size = new Size(260, 35);

            // Password
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(24, 120);
            lblPassword.Text = "Password";
            txtPassword.Location = new Point(150, 116);
            txtPassword.Size = new Size(260, 35);
            txtPassword.PasswordChar = '•';

            // Role
            lblRole.AutoSize = true;
            lblRole.Location = new Point(24, 168);
            lblRole.Text = "Role";
            cmbRole.Location = new Point(150, 164);
            cmbRole.Size = new Size(260, 38);
            cmbRole.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRole.Items.AddRange(new object[] { "SuperAdmin", "Admin", "Manager" });

            // Buttons
            btnSave.Location = new Point(24, 220);
            btnSave.Size = new Size(120, 40);
            btnSave.Text = "Save";
            btnSave.Click += btnSave_Click;

            btnUpdate.Location = new Point(154, 220);
            btnUpdate.Size = new Size(120, 40);
            btnUpdate.Text = "Update";
            btnUpdate.Click += btnUpdate_Click;

            btnDelete.Location = new Point(284, 220);
            btnDelete.Size = new Size(120, 40);
            btnDelete.Text = "Delete";
            btnDelete.Click += btnDelete_Click;

            btnRefresh.Location = new Point(414, 220);
            btnRefresh.Size = new Size(120, 40);
            btnRefresh.Text = "Refresh";
            btnRefresh.Click += btnRefresh_Click;

            btnClear.Location = new Point(544, 220);
            btnClear.Size = new Size(120, 40);
            btnClear.Text = "Clear";
            btnClear.Click += btnClear_Click;

            // Grid
            dgvAdmins.AllowUserToAddRows = false;
            dgvAdmins.AllowUserToDeleteRows = false;
            dgvAdmins.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvAdmins.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAdmins.Location = new Point(24, 280);
            dgvAdmins.MultiSelect = false;
            dgvAdmins.Name = "dgvAdmins";
            dgvAdmins.ReadOnly = true;
            dgvAdmins.RowHeadersWidth = 51;
            dgvAdmins.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAdmins.Size = new Size(640, 260);
            dgvAdmins.TabIndex = 100;

            // Form
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(690, 560);
            Controls.Add(lblHeader);
            Controls.Add(lblUsername);
            Controls.Add(txtUsername);
            Controls.Add(lblPassword);
            Controls.Add(txtPassword);
            Controls.Add(lblRole);
            Controls.Add(cmbRole);
            Controls.Add(btnSave);
            Controls.Add(btnUpdate);
            Controls.Add(btnDelete);
            Controls.Add(btnRefresh);
            Controls.Add(btnClear);
            Controls.Add(dgvAdmins);
            Name = "RegistrationForm";
            Text = "Admin Registration";
            Load += RegistrationForm_Load;

            ((System.ComponentModel.ISupportInitialize)dgvAdmins).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
