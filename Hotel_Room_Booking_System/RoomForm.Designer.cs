namespace Hotel_Room_Booking_System
{
    partial class RoomForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lblRoomNumber = new Label();
            txtRoomNumber = new TextBox();
            textRoomType = new TextBox();
            txtPric = new TextBox();
            lblRoomType = new Label();
            lblPrice = new Label();
            cmbStatus = new ComboBox();
            lblStatus = new Label();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnLoad = new Button();
            btnDelete = new Button();
            btnClear = new Button();
            dataGridView1 = new DataGridView();
            lblViewRoom = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // lblRoomNumber
            // 
            lblRoomNumber.AutoSize = true;
            lblRoomNumber.Location = new Point(24, 24);
            lblRoomNumber.Margin = new Padding(5, 0, 5, 0);
            lblRoomNumber.Name = "lblRoomNumber";
            lblRoomNumber.Size = new Size(123, 32);
            lblRoomNumber.TabIndex = 100;
            lblRoomNumber.Text = "Room No.";
            // 
            // txtRoomNumber
            // 
            txtRoomNumber.Location = new Point(180, 20);
            txtRoomNumber.Margin = new Padding(5);
            txtRoomNumber.MaxLength = 6;
            txtRoomNumber.Name = "txtRoomNumber";
            txtRoomNumber.Size = new Size(300, 39);
            txtRoomNumber.TabIndex = 0;
            // 
            // lblRoomType
            // 
            lblRoomType.AutoSize = true;
            lblRoomType.Location = new Point(24, 76);
            lblRoomType.Margin = new Padding(5, 0, 5, 0);
            lblRoomType.Name = "lblRoomType";
            lblRoomType.Size = new Size(65, 32);
            lblRoomType.TabIndex = 3;
            lblRoomType.Text = "Type";
            // 
            // textRoomType
            // 
            textRoomType.Location = new Point(180, 72);
            textRoomType.Margin = new Padding(5);
            textRoomType.Name = "textRoomType";
            textRoomType.Size = new Size(300, 39);
            textRoomType.TabIndex = 1;
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Location = new Point(24, 128);
            lblPrice.Margin = new Padding(5, 0, 5, 0);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(65, 32);
            lblPrice.TabIndex = 4;
            lblPrice.Text = "Price";
            // 
            // txtPric
            // 
            txtPric.Location = new Point(180, 124);
            txtPric.Margin = new Padding(5);
            txtPric.Name = "txtPric";
            txtPric.Size = new Size(300, 39);
            txtPric.TabIndex = 2;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(24, 180);
            lblStatus.Margin = new Padding(5, 0, 5, 0);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(78, 32);
            lblStatus.TabIndex = 5;
            lblStatus.Text = "Status";
            // 
            // cmbStatus
            // 
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Location = new Point(180, 176);
            cmbStatus.Margin = new Padding(5);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(300, 40);
            cmbStatus.TabIndex = 3;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(520, 20);
            btnAdd.Margin = new Padding(5);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(200, 44);
            btnAdd.TabIndex = 4;
            btnAdd.Text = "Add Room";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(520, 76);
            btnUpdate.Margin = new Padding(5);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(200, 44);
            btnUpdate.TabIndex = 5;
            btnUpdate.Text = "Update Room";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(520, 132);
            btnDelete.Margin = new Padding(5);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(200, 44);
            btnDelete.TabIndex = 6;
            btnDelete.Text = "Delete Room";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnLoad
            // 
            btnLoad.Location = new Point(520, 188);
            btnLoad.Margin = new Padding(5);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(200, 44);
            btnLoad.TabIndex = 7;
            btnLoad.Text = "Refresh";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += btnLoad_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(520, 244);
            btnClear.Margin = new Padding(5);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(200, 44);
            btnClear.TabIndex = 8;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            Controls.Add(btnClear);
            // 
            // lblViewRoom
            // 
            lblViewRoom.AutoSize = true;
            lblViewRoom.Location = new Point(24, 280);
            lblViewRoom.Margin = new Padding(5, 0, 5, 0);
            lblViewRoom.Name = "lblViewRoom";
            lblViewRoom.Size = new Size(144, 32);
            lblViewRoom.TabIndex = 9;
            lblViewRoom.Text = "View Rooms";
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                                    | System.Windows.Forms.AnchorStyles.Left)
                                    | System.Windows.Forms.AnchorStyles.Right)));
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(24, 320);
            dataGridView1.Margin = new Padding(5);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(1252, 364);
            dataGridView1.TabIndex = 8;
            // 
            // RoomForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1300, 720);
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
            Controls.Add(lblViewRoom);
            Controls.Add(dataGridView1);
            Margin = new Padding(5);
            Name = "RoomForm";
            Text = "Rooms";
            Load += RoomForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtRoomNumber;
        private Label lblRoomNumber;
        private TextBox textRoomType;
        private TextBox txtPric;
        private Label lblRoomType;
        private Label lblPrice;
        private ComboBox cmbStatus;
        private Label lblStatus;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnLoad;
        private Button btnDelete;
        private Button btnClear;
        private DataGridView dataGridView1;
        private Label lblViewRoom;
    }
}
