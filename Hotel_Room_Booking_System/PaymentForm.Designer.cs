using System.Drawing;
using System.Windows.Forms;

namespace Hotel_Room_Booking_System
{
    partial class PaymentForm
    {
        private System.ComponentModel.IContainer components = null;

        private ComboBox cmbBooking;
        private TextBox txtGuestName;
        private TextBox txtAmount;
        private ComboBox cmbPaymentMethod;
        private DateTimePicker dtpPaymentDate;
        private Button btnSubmit;
        private Button btnUpdate;
        private Button btnClear;
        private Button btnViewPayments;
        private DataGridView dataGridViewPayments;
        private Label lblBookingID;
        private Label lblGuestName;
        private Label lblAmount;
        private Label lblPaymentMethod;
        private Label lblPaymentDate;
        private Label lblHeader;           // ← new

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            cmbBooking = new ComboBox();
            txtGuestName = new TextBox();
            txtAmount = new TextBox();
            cmbPaymentMethod = new ComboBox();
            dtpPaymentDate = new DateTimePicker();
            btnSubmit = new Button();
            btnUpdate = new Button();
            btnClear = new Button();
            btnViewPayments = new Button();
            dataGridViewPayments = new DataGridView();
            lblBookingID = new Label();
            lblGuestName = new Label();
            lblAmount = new Label();
            lblPaymentMethod = new Label();
            lblPaymentDate = new Label();
            lblHeader = new Label();
            mainLayout = new TableLayoutPanel();
            formLayout = new TableLayoutPanel();
            buttonsLayout = new FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)dataGridViewPayments).BeginInit();
            mainLayout.SuspendLayout();
            formLayout.SuspendLayout();
            buttonsLayout.SuspendLayout();
            SuspendLayout();
            // 
            // cmbBooking
            // 
            cmbBooking.Dock = DockStyle.Fill;
            cmbBooking.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBooking.Location = new Point(286, 0);
            cmbBooking.Margin = new Padding(0, 0, 0, 13);
            cmbBooking.Name = "cmbBooking";
            cmbBooking.Size = new Size(1094, 40);
            cmbBooking.TabIndex = 1;
            cmbBooking.SelectedIndexChanged += cmbBooking_SelectedIndexChanged;
            // 
            // txtGuestName
            // 
            txtGuestName.Dock = DockStyle.Fill;
            txtGuestName.Location = new Point(286, 53);
            txtGuestName.Margin = new Padding(0, 0, 0, 13);
            txtGuestName.Name = "txtGuestName";
            txtGuestName.ReadOnly = true;
            txtGuestName.Size = new Size(1094, 39);
            txtGuestName.TabIndex = 3;
            // 
            // txtAmount
            // 
            txtAmount.Dock = DockStyle.Fill;
            txtAmount.Location = new Point(286, 105);
            txtAmount.Margin = new Padding(0, 0, 0, 13);
            txtAmount.Name = "txtAmount";
            txtAmount.Size = new Size(1094, 39);
            txtAmount.TabIndex = 5;
            // 
            // cmbPaymentMethod
            // 
            cmbPaymentMethod.Dock = DockStyle.Fill;
            cmbPaymentMethod.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPaymentMethod.DropDownWidth = 260;
            cmbPaymentMethod.IntegralHeight = false;
            cmbPaymentMethod.Items.AddRange(new object[] { "Cash", "Credit Card", "Debit Card", "Online Payment" });
            cmbPaymentMethod.Location = new Point(286, 157);
            cmbPaymentMethod.Margin = new Padding(0, 0, 0, 13);
            cmbPaymentMethod.Name = "cmbPaymentMethod";
            cmbPaymentMethod.Size = new Size(1094, 40);
            cmbPaymentMethod.TabIndex = 7;
            // 
            // dtpPaymentDate
            // 
            dtpPaymentDate.Dock = DockStyle.Fill;
            dtpPaymentDate.Format = DateTimePickerFormat.Short;
            dtpPaymentDate.Location = new Point(286, 210);
            dtpPaymentDate.Margin = new Padding(0, 0, 0, 13);
            dtpPaymentDate.Name = "dtpPaymentDate";
            dtpPaymentDate.Size = new Size(1094, 39);
            dtpPaymentDate.TabIndex = 9;
            // 
            // btnSubmit
            // 
            btnSubmit.AutoSize = true;
            btnSubmit.Location = new Point(4, 5);
            btnSubmit.Margin = new Padding(4, 5, 4, 5);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(216, 67);
            btnSubmit.TabIndex = 0;
            btnSubmit.Text = "Add Payment";
            btnSubmit.Click += btnSubmit_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(228, 5);
            btnUpdate.Margin = new Padding(4, 5, 4, 5);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(98, 37);
            btnUpdate.TabIndex = 1;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnClear
            // 
            btnClear.AutoSize = true;
            btnClear.Location = new Point(334, 5);
            btnClear.Margin = new Padding(4, 5, 4, 5);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(101, 67);
            btnClear.TabIndex = 2;
            btnClear.Text = "Clear";
            btnClear.Click += btnClear_Click;
            // 
            // btnViewPayments
            // 
            btnViewPayments.AutoSize = true;
            btnViewPayments.Location = new Point(443, 5);
            btnViewPayments.Margin = new Padding(4, 5, 4, 5);
            btnViewPayments.Name = "btnViewPayments";
            btnViewPayments.Size = new Size(276, 67);
            btnViewPayments.TabIndex = 3;
            btnViewPayments.Text = "Refresh Payments";
            btnViewPayments.Click += btnViewPayments_Click;
            // 
            // dataGridViewPayments
            // 
            dataGridViewPayments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewPayments.BackgroundColor = SystemColors.Window;
            dataGridViewPayments.ColumnHeadersHeight = 46;
            dataGridViewPayments.Dock = DockStyle.Fill;
            dataGridViewPayments.Location = new Point(25, 478);
            dataGridViewPayments.Margin = new Padding(4, 5, 4, 5);
            dataGridViewPayments.Name = "dataGridViewPayments";
            dataGridViewPayments.RowHeadersVisible = false;
            dataGridViewPayments.RowHeadersWidth = 82;
            dataGridViewPayments.Size = new Size(1380, 611);
            dataGridViewPayments.TabIndex = 1;
            // 
            // lblBookingID
            // 
            lblBookingID.AutoSize = true;
            lblBookingID.Location = new Point(0, 0);
            lblBookingID.Margin = new Padding(0, 0, 10, 13);
            lblBookingID.Name = "lblBookingID";
            lblBookingID.Size = new Size(102, 32);
            lblBookingID.TabIndex = 0;
            lblBookingID.Text = "Booking";
            // 
            // lblGuestName
            // 
            lblGuestName.AutoSize = true;
            lblGuestName.Location = new Point(0, 53);
            lblGuestName.Margin = new Padding(0, 0, 10, 13);
            lblGuestName.Name = "lblGuestName";
            lblGuestName.Size = new Size(146, 32);
            lblGuestName.TabIndex = 2;
            lblGuestName.Text = "Guest Name";
            // 
            // lblAmount
            // 
            lblAmount.AutoSize = true;
            lblAmount.Location = new Point(0, 105);
            lblAmount.Margin = new Padding(0, 0, 10, 13);
            lblAmount.Name = "lblAmount";
            lblAmount.Size = new Size(100, 32);
            lblAmount.TabIndex = 4;
            lblAmount.Text = "Amount";
            // 
            // lblPaymentMethod
            // 
            lblPaymentMethod.AutoSize = true;
            lblPaymentMethod.Location = new Point(0, 157);
            lblPaymentMethod.Margin = new Padding(0, 0, 10, 13);
            lblPaymentMethod.Name = "lblPaymentMethod";
            lblPaymentMethod.Size = new Size(198, 32);
            lblPaymentMethod.TabIndex = 6;
            lblPaymentMethod.Text = "Payment Method";
            // 
            // lblPaymentDate
            // 
            lblPaymentDate.AutoSize = true;
            lblPaymentDate.Location = new Point(0, 210);
            lblPaymentDate.Margin = new Padding(0, 0, 10, 13);
            lblPaymentDate.Name = "lblPaymentDate";
            lblPaymentDate.Size = new Size(163, 32);
            lblPaymentDate.TabIndex = 8;
            lblPaymentDate.Text = "Payment Date";
            // 
            // lblHeader
            // 
            lblHeader.AutoSize = true;
            lblHeader.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblHeader.ForeColor = Color.DarkSlateBlue;
            lblHeader.Location = new Point(24, 26);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(604, 72);
            lblHeader.TabIndex = 0;
            lblHeader.Text = "Payment Management";
            // 
            // mainLayout
            // 
            mainLayout.BackColor = SystemColors.Control;
            mainLayout.ColumnCount = 1;
            mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            mainLayout.Controls.Add(formLayout, 0, 1);
            mainLayout.Controls.Add(dataGridViewPayments, 0, 2);
            mainLayout.Controls.Add(lblHeader, 0, 0);
            mainLayout.Dock = DockStyle.Fill;
            mainLayout.Location = new Point(0, 0);
            mainLayout.Margin = new Padding(4, 5, 4, 5);
            mainLayout.Name = "mainLayout";
            mainLayout.Padding = new Padding(21, 26, 21, 26);
            mainLayout.RowCount = 3;
            mainLayout.RowStyles.Add(new RowStyle());
            mainLayout.RowStyles.Add(new RowStyle());
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            mainLayout.Size = new Size(1430, 1120);
            mainLayout.TabIndex = 0;
            // 
            // formLayout
            // 
            formLayout.AutoSize = true;
            formLayout.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            formLayout.ColumnCount = 2;
            formLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 286F));
            formLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            formLayout.Controls.Add(cmbBooking, 1, 0);
            formLayout.Controls.Add(lblGuestName, 0, 1);
            formLayout.Controls.Add(txtGuestName, 1, 1);
            formLayout.Controls.Add(lblAmount, 0, 2);
            formLayout.Controls.Add(txtAmount, 1, 2);
            formLayout.Controls.Add(lblPaymentMethod, 0, 3);
            formLayout.Controls.Add(cmbPaymentMethod, 1, 3);
            formLayout.Controls.Add(lblPaymentDate, 0, 4);
            formLayout.Controls.Add(dtpPaymentDate, 1, 4);
            formLayout.Controls.Add(buttonsLayout, 1, 5);
            formLayout.Controls.Add(lblBookingID, 0, 0);
            formLayout.Dock = DockStyle.Top;
            formLayout.Location = new Point(25, 103);
            formLayout.Margin = new Padding(4, 5, 4, 5);
            formLayout.Name = "formLayout";
            formLayout.RowCount = 6;
            formLayout.RowStyles.Add(new RowStyle());
            formLayout.RowStyles.Add(new RowStyle());
            formLayout.RowStyles.Add(new RowStyle());
            formLayout.RowStyles.Add(new RowStyle());
            formLayout.RowStyles.Add(new RowStyle());
            formLayout.RowStyles.Add(new RowStyle());
            formLayout.Size = new Size(1380, 365);
            formLayout.TabIndex = 0;
            // 
            // buttonsLayout
            // 
            buttonsLayout.AutoSize = true;
            buttonsLayout.Controls.Add(btnSubmit);
            buttonsLayout.Controls.Add(btnUpdate);
            buttonsLayout.Controls.Add(btnClear);
            buttonsLayout.Controls.Add(btnViewPayments);
            buttonsLayout.Dock = DockStyle.Fill;
            buttonsLayout.Location = new Point(286, 275);
            buttonsLayout.Margin = new Padding(0, 13, 0, 13);
            buttonsLayout.Name = "buttonsLayout";
            buttonsLayout.Size = new Size(1094, 77);
            buttonsLayout.TabIndex = 10;
            buttonsLayout.WrapContents = false;
            // 
            // PaymentForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1430, 1120);
            Controls.Add(mainLayout);
            Margin = new Padding(4, 5, 4, 5);
            MinimumSize = new Size(1227, 917);
            Name = "PaymentForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Payments";
            ((System.ComponentModel.ISupportInitialize)dataGridViewPayments).EndInit();
            mainLayout.ResumeLayout(false);
            mainLayout.PerformLayout();
            formLayout.ResumeLayout(false);
            formLayout.PerformLayout();
            buttonsLayout.ResumeLayout(false);
            buttonsLayout.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel mainLayout;
        private TableLayoutPanel formLayout;
        private FlowLayoutPanel buttonsLayout;
    }
}
