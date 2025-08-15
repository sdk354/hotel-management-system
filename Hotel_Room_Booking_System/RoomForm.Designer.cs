namespace Hotel_Room_Booking_System
{
    partial class RoomForm
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox txtRoomNumber;
        private TextBox textRoomType;
        private TextBox txtPric;
        private ComboBox cmbStatus;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnLoad;
        private Button btnClear;
        private DataGridView dataGridView1;
        private Label lblRoomNumber;
        private Label lblRoomType;
        private Label lblPrice;
        private Label lblStatus;
        private Label lblViewRoom;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            txtRoomNumber = new TextBox();
            textRoomType = new TextBox();
            txtPric = new TextBox();
            cmbStatus = new ComboBox();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnLoad = new Button();
            btnClear = new Button();
            dataGridView1 = new DataGridView();
            lblRoomNumber = new Label();
            lblRoomType = new Label();
            lblPrice = new Label();
            lblStatus = new Label();
            lblViewRoom = new Label();
            lblHeader = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // txtRoomNumber
            // 
            txtRoomNumber.Font = new Font("Segoe UI", 12F);
            txtRoomNumber.Location = new Point(153, 102);
            txtRoomNumber.MaxLength = 6;
            txtRoomNumber.Name = "txtRoomNumber";
            txtRoomNumber.Size = new Size(200, 34);
            txtRoomNumber.TabIndex = 1;
            // 
            // textRoomType
            // 
            textRoomType.Font = new Font("Segoe UI", 12F);
            textRoomType.Location = new Point(153, 152);
            textRoomType.Name = "textRoomType";
            textRoomType.Size = new Size(200, 34);
            textRoomType.TabIndex = 3;
            // 
            // txtPric
            // 
            txtPric.Font = new Font("Segoe UI", 12F);
            txtPric.Location = new Point(153, 202);
            txtPric.Name = "txtPric";
            txtPric.Size = new Size(200, 34);
            txtPric.TabIndex = 5;
            // 
            // cmbStatus
            // 
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.Font = new Font("Segoe UI", 12F);
            cmbStatus.Location = new Point(153, 252);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(200, 36);
            cmbStatus.TabIndex = 7;
            // 
            // btnAdd
            // 
            btnAdd.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnAdd.Location = new Point(383, 102);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(120, 36);
            btnAdd.TabIndex = 8;
            btnAdd.Text = "Add Room";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnUpdate.Location = new Point(383, 152);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(120, 36);
            btnUpdate.TabIndex = 9;
            btnUpdate.Text = "Update Room";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnDelete.Location = new Point(383, 202);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(120, 36);
            btnDelete.TabIndex = 10;
            btnDelete.Text = "Delete Room";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnLoad
            // 
            btnLoad.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnLoad.Location = new Point(383, 252);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(120, 36);
            btnLoad.TabIndex = 11;
            btnLoad.Text = "Refresh";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += btnLoad_Click;
            // 
            // btnClear
            // 
            btnClear.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnClear.Location = new Point(383, 302);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(120, 36);
            btnClear.TabIndex = 12;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeight = 29;
            dataGridView1.Location = new Point(33, 395);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(872, 132);
            dataGridView1.TabIndex = 14;
            // 
            // lblRoomNumber
            // 
            lblRoomNumber.AutoSize = true;
            lblRoomNumber.Font = new Font("Segoe UI", 12F);
            lblRoomNumber.Location = new Point(33, 105);
            lblRoomNumber.Name = "lblRoomNumber";
            lblRoomNumber.Size = new Size(100, 28);
            lblRoomNumber.TabIndex = 0;
            lblRoomNumber.Text = "Room No.";
            // 
            // lblRoomType
            // 
            lblRoomType.AutoSize = true;
            lblRoomType.Font = new Font("Segoe UI", 12F);
            lblRoomType.Location = new Point(33, 155);
            lblRoomType.Name = "lblRoomType";
            lblRoomType.Size = new Size(53, 28);
            lblRoomType.TabIndex = 2;
            lblRoomType.Text = "Type";
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Font = new Font("Segoe UI", 12F);
            lblPrice.Location = new Point(33, 205);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(54, 28);
            lblPrice.TabIndex = 4;
            lblPrice.Text = "Price";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 12F);
            lblStatus.Location = new Point(33, 255);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(65, 28);
            lblStatus.TabIndex = 6;
            lblStatus.Text = "Status";
            // 
            // lblViewRoom
            // 
            lblViewRoom.AutoSize = true;
            lblViewRoom.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblViewRoom.Location = new Point(33, 355);
            lblViewRoom.Name = "lblViewRoom";
            lblViewRoom.Size = new Size(128, 28);
            lblViewRoom.TabIndex = 13;
            lblViewRoom.Text = "View Rooms";
            // 
            // lblHeader
            // 
            lblHeader.AutoSize = true;
            lblHeader.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblHeader.ForeColor = Color.DarkSlateBlue;
            lblHeader.Location = new Point(307, 27);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(335, 46);
            lblHeader.TabIndex = 15;
            lblHeader.Text = "Room Management";
            // 
            // RoomForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(942, 550);
            Controls.Add(lblHeader);
            Controls.Add(lblRoomNumber);
            Controls.Add(txtRoomNumber);
            Controls.Add(lblRoomType);
            Controls.Add(textRoomType);
            Controls.Add(lblPrice);
            Controls.Add(txtPric);
            Controls.Add(lblStatus);
            Controls.Add(cmbStatus);
            Controls.Add(btnAdd);
            Controls.Add(btnUpdate);
            Controls.Add(btnDelete);
            Controls.Add(btnLoad);
            Controls.Add(btnClear);
            Controls.Add(lblViewRoom);
            Controls.Add(dataGridView1);
            Name = "RoomForm";
            Text = "Rooms";
            Load += RoomForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        private Label lblHeader;
    }
}
