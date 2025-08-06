namespace Hotel_Room_Booking_System
{
    partial class PaymentForm
    {
        private System.ComponentModel.IContainer components = null;

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
            txtBookingID = new TextBox();
            txtGuestName = new TextBox();
            txtAmount = new TextBox();
            cmbPaymentMethod = new ComboBox();
            dtpPaymentDate = new DateTimePicker();
            btnSubmit = new Button();
            btnClear = new Button();
            btnViewPayments = new Button();
            dataGridViewPayments = new DataGridView();
            lblBookingID = new Label();
            lblGuestName = new Label();
            lblAmount = new Label();
            lblPaymentMethod = new Label();
            lblPaymentDate = new Label();

            ((System.ComponentModel.ISupportInitialize)dataGridViewPayments).BeginInit();
            SuspendLayout();

            // 
            // txtBookingID
            // 
            txtBookingID.Location = new Point(180, 20);
            txtBookingID.Name = "txtBookingID";
            txtBookingID.Size = new Size(200, 27);
            txtBookingID.TabIndex = 0;
            // 
            // txtGuestName
            // 
            txtGuestName.Location = new Point(180, 60);
            txtGuestName.Name = "txtGuestName";
            txtGuestName.Size = new Size(200, 27);
            txtGuestName.TabIndex = 1;
            // 
            // txtAmount
            // 
            txtAmount.Location = new Point(180, 100);
            txtAmount.Name = "txtAmount";
            txtAmount.Size = new Size(200, 27);
            txtAmount.TabIndex = 2;
            // 
            // cmbPaymentMethod
            // 
            cmbPaymentMethod.FormattingEnabled = true;
            cmbPaymentMethod.Items.AddRange(new object[] {
                "Cash",
                "Credit Card",
                "Debit Card",
                "Online Payment"
            });
            cmbPaymentMethod.Location = new Point(180, 140);
            cmbPaymentMethod.Name = "cmbPaymentMethod";
            cmbPaymentMethod.Size = new Size(200, 28);
            cmbPaymentMethod.TabIndex = 3;
            cmbPaymentMethod.SelectedIndex = 0;
            // 
            // dtpPaymentDate
            // 
            dtpPaymentDate.Format = DateTimePickerFormat.Short;
            dtpPaymentDate.Location = new Point(180, 180);
            dtpPaymentDate.Name = "dtpPaymentDate";
            dtpPaymentDate.Size = new Size(200, 27);
            dtpPaymentDate.TabIndex = 4;
            // 
            // btnSubmit
            // 
            btnSubmit.Location = new Point(180, 220);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(94, 29);
            btnSubmit.TabIndex = 5;
            btnSubmit.Text = "Submit";
            btnSubmit.UseVisualStyleBackColor = true;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(290, 220);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(90, 29);
            btnClear.TabIndex = 6;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnViewPayments
            // 
            btnViewPayments.Location = new Point(180, 260);
            btnViewPayments.Name = "btnViewPayments";
            btnViewPayments.Size = new Size(200, 29);
            btnViewPayments.TabIndex = 7;
            btnViewPayments.Text = "View Payments";
            btnViewPayments.UseVisualStyleBackColor = true;
            btnViewPayments.Click += btnViewPayments_Click;
            // 
            // dataGridViewPayments
            // 
            dataGridViewPayments.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewPayments.Location = new Point(400, 20);
            dataGridViewPayments.Name = "dataGridViewPayments";
            dataGridViewPayments.RowHeadersWidth = 51;
            dataGridViewPayments.Size = new Size(500, 300);
            dataGridViewPayments.TabIndex = 8;
            // 
            // Labels
            // 
            lblBookingID.AutoSize = true;
            lblBookingID.Location = new Point(50, 23);
            lblBookingID.Name = "lblBookingID";
            lblBookingID.Size = new Size(95, 20);
            lblBookingID.Text = "Booking ID";

            lblGuestName.AutoSize = true;
            lblGuestName.Location = new Point(50, 63);
            lblGuestName.Name = "lblGuestName";
            lblGuestName.Size = new Size(102, 20);
            lblGuestName.Text = "Guest Name";

            lblAmount.AutoSize = true;
            lblAmount.Location = new Point(50, 103);
            lblAmount.Name = "lblAmount";
            lblAmount.Size = new Size(63, 20);
            lblAmount.Text = "Amount";

            lblPaymentMethod.AutoSize = true;
            lblPaymentMethod.Location = new Point(50, 143);
            lblPaymentMethod.Name = "lblPaymentMethod";
            lblPaymentMethod.Size = new Size(123, 20);
            lblPaymentMethod.Text = "Payment Method";

            lblPaymentDate.AutoSize = true;
            lblPaymentDate.Location = new Point(50, 183);
            lblPaymentDate.Name = "lblPaymentDate";
            lblPaymentDate.Size = new Size(103, 20);
            lblPaymentDate.Text = "Payment Date";

            // 
            // PaymentForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(930, 350);
            Controls.Add(lblBookingID);
            Controls.Add(txtBookingID);
            Controls.Add(lblGuestName);
            Controls.Add(txtGuestName);
            Controls.Add(lblAmount);
            Controls.Add(txtAmount);
            Controls.Add(lblPaymentMethod);
            Controls.Add(cmbPaymentMethod);
            Controls.Add(lblPaymentDate);
            Controls.Add(dtpPaymentDate);
            Controls.Add(btnSubmit);
            Controls.Add(btnClear);
            Controls.Add(btnViewPayments);
            Controls.Add(dataGridViewPayments);
            Name = "PaymentForm";
            Text = "PaymentForm";

            ((System.ComponentModel.ISupportInitialize)dataGridViewPayments).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtBookingID;
        private TextBox txtGuestName;
        private TextBox txtAmount;
        private ComboBox cmbPaymentMethod;
        private DateTimePicker dtpPaymentDate;
        private Button btnSubmit;
        private Button btnClear;
        private Button btnViewPayments;
        private DataGridView dataGridViewPayments;
        private Label lblBookingID;
        private Label lblGuestName;
        private Label lblAmount;
        private Label lblPaymentMethod;
        private Label lblPaymentDate;
    }
}
