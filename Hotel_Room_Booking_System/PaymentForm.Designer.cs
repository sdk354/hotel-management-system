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
            components = new System.ComponentModel.Container();

            // Controls
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

            var mainLayout = new TableLayoutPanel();
            var formLayout = new TableLayoutPanel();
            var buttonsLayout = new FlowLayoutPanel();

            SuspendLayout();

            // Main layout
            mainLayout.ColumnCount = 1;
            mainLayout.RowCount = 2;
            mainLayout.Dock = DockStyle.Fill;
            mainLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            mainLayout.Padding = new Padding(16);
            mainLayout.BackColor = SystemColors.Control;

            // Top form layout (labels + inputs)
            formLayout.ColumnCount = 2;
            formLayout.RowCount = 6;
            formLayout.Dock = DockStyle.Top;
            formLayout.AutoSize = true;
            formLayout.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            formLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 220F));
            formLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            for (int i = 0; i < 5; i++)
            {
                formLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            }
            formLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize)); // buttons row

            // Labels
            lblBookingID.AutoSize = true;
            lblBookingID.Text = "Booking";
            lblBookingID.Margin = new Padding(0, 0, 8, 8);

            lblGuestName.AutoSize = true;
            lblGuestName.Text = "Guest Name";
            lblGuestName.Margin = new Padding(0, 0, 8, 8);

            lblAmount.AutoSize = true;
            lblAmount.Text = "Amount";
            lblAmount.Margin = new Padding(0, 0, 8, 8);

            lblPaymentMethod.AutoSize = true;
            lblPaymentMethod.Text = "Payment Method";
            lblPaymentMethod.Margin = new Padding(0, 0, 8, 8);

            lblPaymentDate.AutoSize = true;
            lblPaymentDate.Text = "Payment Date";
            lblPaymentDate.Margin = new Padding(0, 0, 8, 8);

            // Inputs
            cmbBooking.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBooking.Margin = new Padding(0, 0, 0, 8);
            cmbBooking.Dock = DockStyle.Fill; // full width
            cmbBooking.SelectedIndexChanged += cmbBooking_SelectedIndexChanged;

            txtGuestName.ReadOnly = true;
            txtGuestName.Margin = new Padding(0, 0, 0, 8);
            txtGuestName.Dock = DockStyle.Fill; // full width

            txtAmount.Margin = new Padding(0, 0, 0, 8);
            txtAmount.Dock = DockStyle.Fill; // consistent fill

            cmbPaymentMethod.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPaymentMethod.Items.AddRange(new object[] { "Cash", "Credit Card", "Debit Card", "Online Payment" });
            cmbPaymentMethod.Margin = new Padding(0, 0, 0, 8);
            cmbPaymentMethod.Dock = DockStyle.Fill; // ensure room for long options
            cmbPaymentMethod.IntegralHeight = false; // allow full dropdown height
            cmbPaymentMethod.DropDownWidth = 260;    // ensure full text visible when dropped down

            dtpPaymentDate.Format = DateTimePickerFormat.Short;
            dtpPaymentDate.Margin = new Padding(0, 0, 0, 8);
            dtpPaymentDate.Dock = DockStyle.Fill;

            // Buttons layout
            buttonsLayout.FlowDirection = FlowDirection.LeftToRight;
            buttonsLayout.AutoSize = true;
            buttonsLayout.WrapContents = false;
            buttonsLayout.Dock = DockStyle.Fill;
            buttonsLayout.Margin = new Padding(0, 8, 0, 8);

            btnSubmit.Text = "Add Payment";
            btnSubmit.AutoSize = true;
            btnSubmit.Click += btnSubmit_Click;

            btnUpdate = new Button
            {
                Text = "Update Payment",
                AutoSize = true,
                Enabled = false
            };
            btnUpdate.Click += btnUpdate_Click;

            btnClear.Text = "Clear";
            btnClear.AutoSize = true;
            btnClear.Click += btnClear_Click;

            btnViewPayments.Text = "Refresh Payments";
            btnViewPayments.AutoSize = true;
            btnViewPayments.Click += btnViewPayments_Click;

            buttonsLayout.Controls.Add(btnSubmit);
            buttonsLayout.Controls.Add(btnUpdate);
            buttonsLayout.Controls.Add(btnClear);
            buttonsLayout.Controls.Add(btnViewPayments);

            // Add rows to form layout
            formLayout.Controls.Add(lblBookingID, 0, 0);
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

            // DataGridView (bottom)
            dataGridViewPayments.Dock = DockStyle.Fill;
            dataGridViewPayments.BackgroundColor = SystemColors.Window;
            dataGridViewPayments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewPayments.RowHeadersVisible = false;

            // Assemble
            mainLayout.Controls.Add(formLayout, 0, 0);
            mainLayout.Controls.Add(dataGridViewPayments, 0, 1);

            // Form
            AutoScaleDimensions = new SizeF(10F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Text = "Payments";
            StartPosition = FormStartPosition.CenterScreen;
            MinimumSize = new Size(950, 600);
            ClientSize = new Size(1100, 700);
            Controls.Add(mainLayout);

            ((System.ComponentModel.ISupportInitialize)dataGridViewPayments).EndInit();
            ResumeLayout(false);
        }

        #endregion
    }
}
