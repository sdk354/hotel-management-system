using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
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
            components = new Container();

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

            SuspendLayout();

            // ComboBoxes and Labels
            cmbCustomers.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCustomers.Location = new Point(180, 24);
            cmbCustomers.Size = new Size(320, 40);

            cmbRooms.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRooms.Location = new Point(180, 72);
            cmbRooms.Size = new Size(320, 40);

            dtpCheckIn.Location = new Point(180, 120);
            dtpCheckIn.Size = new Size(320, 39);
            dtpCheckIn.ValueChanged += dtpCheckIn_ValueChanged;

            dtpCheckOut.Location = new Point(180, 168);
            dtpCheckOut.Size = new Size(320, 39);

            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.Location = new Point(180, 216);
            cmbStatus.Size = new Size(320, 40);

            // Buttons
            btnBook.Location = new Point(520, 24);
            btnBook.Size = new Size(130, 40);
            btnBook.Text = "Add";
            btnBook.Click += btnBook_Click;

            btnUpdate.Location = new Point(520, 72);
            btnUpdate.Size = new Size(130, 40);
            btnUpdate.Text = "Update";
            btnUpdate.Click += btnUpdate_Click;

            btnDelete.Location = new Point(520, 120);
            btnDelete.Size = new Size(130, 40);
            btnDelete.Text = "Delete";
            btnDelete.Click += btnDelete_Click;

            btnRefresh.Location = new Point(520, 168);
            btnRefresh.Size = new Size(130, 40);
            btnRefresh.Text = "Refresh";
            btnRefresh.Click += btnRefresh_Click;

            btnClear.Location = new Point(520, 216);
            btnClear.Size = new Size(130, 40);
            btnClear.Text = "Clear";
            btnClear.Click += btnClear_Click;

            // Labels
            lblCustomer.Location = new Point(24, 24);
            lblCustomer.Size = new Size(150, 32);
            lblCustomer.Text = "Customer:";

            lblRoom.Location = new Point(24, 72);
            lblRoom.Size = new Size(150, 32);
            lblRoom.Text = "Room:";

            lblCheckIn.Location = new Point(24, 120);
            lblCheckIn.Size = new Size(150, 32);
            lblCheckIn.Text = "Check-In:";

            lblCheckOut.Location = new Point(24, 168);
            lblCheckOut.Size = new Size(150, 32);
            lblCheckOut.Text = "Check-Out:";

            lblStatus.Location = new Point(24, 216);
            lblStatus.Size = new Size(150, 32);
            lblStatus.Text = "Status:";

            // Grid
            dgvBookings.AllowUserToAddRows = false;
            dgvBookings.AllowUserToDeleteRows = false;
            dgvBookings.AllowUserToOrderColumns = true;
            dgvBookings.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells; // Auto-resize by content
            dgvBookings.BackgroundColor = SystemColors.Window;
            dgvBookings.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBookings.Location = new Point(24, 280);
            dgvBookings.Size = new Size(826, 320);
            dgvBookings.ReadOnly = true;
            dgvBookings.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBookings.MultiSelect = false;
            dgvBookings.RowHeadersVisible = false;
            dgvBookings.RowTemplate.Height = 33;
            dgvBookings.SelectionChanged += dgvBookings_SelectionChanged;

            // Fit after data binds and when columns mutate
            dgvBookings.DataBindingComplete += (_, __) => BeginInvoke((Action)ResizeToFitGrid);
            dgvBookings.ColumnAdded += (_, __) => BeginInvoke((Action)ResizeToFitGrid);
            dgvBookings.ColumnRemoved += (_, __) => BeginInvoke((Action)ResizeToFitGrid);
            dgvBookings.ColumnWidthChanged += (_, __) => BeginInvoke((Action)ResizeToFitGrid);

            // Count Label (prominent)
            lblCount.Text = "Total bookings: 0";
            lblCount.AutoSize = false;
            lblCount.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblCount.ForeColor = Color.FromArgb(30, 60, 114);
            lblCount.TextAlign = ContentAlignment.MiddleLeft;
            lblCount.Location = new Point(24, 610); // will be repositioned by ResizeToFitGrid
            lblCount.Size = new Size(300, 36);
            lblCount.Anchor = AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right;

            // Add controls
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

            // Form
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(874, 650);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Bookings";

            // Run a fit on first show
            Shown += (_, __) => ResizeToFitGrid();

            ResumeLayout(false);
        }

        private void ResizeToFitGrid()
        {
            if (dgvBookings.Columns.Count == 0) return;

            // Force column autosize to get actual widths
            dgvBookings.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

            // Total width of visible columns + row headers (if any)
            int columnsWidth = (dgvBookings.RowHeadersVisible ? dgvBookings.RowHeadersWidth : 0);
            foreach (DataGridViewColumn col in dgvBookings.Columns)
            {
                if (col.Visible) columnsWidth += col.Width;
            }

            // Account for vertical scrollbar (if rows exceed display)
            bool vScrollVisible = dgvBookings.RowCount > dgvBookings.DisplayedRowCount(false);
            int vScrollReserve = vScrollVisible ? SystemInformation.VerticalScrollBarWidth : 0;

            // Apply grid width so no horizontal scroll is needed
            int gridSidePadding = 2; // minor fudge for borders
            dgvBookings.Width = columnsWidth + vScrollReserve + gridSidePadding;

            // Reposition and enlarge the count label just below the grid
            int outerMargin = 24;
            int spacing = 16;
            int labelHeight = 36;

            lblCount.Location = new Point(outerMargin, dgvBookings.Bottom + spacing);
            lblCount.Size = new Size(
                Math.Max(300, dgvBookings.Left + dgvBookings.Width - (outerMargin * 2)),
                labelHeight
            );

            // Compute desired client size so nothing is clipped
            int rightPadding = outerMargin + 8;
            int bottomPadding = outerMargin;

            int desiredClientWidth = dgvBookings.Left + dgvBookings.Width + rightPadding;
            int desiredClientHeight = lblCount.Top + lblCount.Height + bottomPadding;

            // Set ClientSize big enough to fully show grid and label
            ClientSize = new Size(
                Math.Max(desiredClientWidth, ClientSize.Width),
                Math.Max(desiredClientHeight, ClientSize.Height)
            );

            // Keep a sensible minimum so the user can’t shrink past content
            int nonClientW = Width - ClientSize.Width;
            int nonClientH = Height - ClientSize.Height;
            MinimumSize = new Size(ClientSize.Width + nonClientW, ClientSize.Height + nonClientH);
        }
    }
}
