namespace Hotel_Room_Booking_System
{
    partial class RoomForm1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
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
            dataGridView1 = new DataGridView();
            lblViewRoom = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // textRoomType
            // 
            textRoomType.Location = new Point(238, 15);
            textRoomType.Name = "textRoomType";
            textRoomType.Size = new Size(179, 27);
            textRoomType.TabIndex = 0;
            // 
            // txtPric
            // 
            txtPric.Location = new Point(238, 57);
            txtPric.Name = "txtPric";
            txtPric.Size = new Size(179, 27);
            txtPric.TabIndex = 1;
            // 
            // lblRoomType
            // 
            lblRoomType.AutoSize = true;
            lblRoomType.Location = new Point(166, 15);
            lblRoomType.Name = "lblRoomType";
            lblRoomType.Size = new Size(40, 20);
            lblRoomType.TabIndex = 2;
            lblRoomType.Text = "Type";
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Location = new Point(166, 60);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(41, 20);
            lblPrice.TabIndex = 3;
            lblPrice.Text = "Price";
            // 
            // cmbStatus
            // 
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Location = new Point(238, 105);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(151, 28);
            cmbStatus.TabIndex = 4;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(166, 108);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(49, 20);
            lblStatus.TabIndex = 5;
            lblStatus.Text = "Status";
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(255, 154);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(94, 29);
            btnAdd.TabIndex = 6;
            btnAdd.Text = "Add Room";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(255, 202);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(114, 29);
            btnUpdate.TabIndex = 7;
            btnUpdate.Text = "Update Room";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnLoad
            // 
            btnLoad.Location = new Point(255, 308);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(94, 29);
            btnLoad.TabIndex = 8;
            btnLoad.Text = "Refresh";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += btnLoad_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(255, 255);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(114, 29);
            btnDelete.TabIndex = 9;
            btnDelete.Text = "Delete Room";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(457, 202);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(300, 188);
            dataGridView1.TabIndex = 10;
            // 
            // lblViewRoom
            // 
            lblViewRoom.AutoSize = true;
            lblViewRoom.Location = new Point(570, 158);
            lblViewRoom.Name = "lblViewRoom";
            lblViewRoom.Size = new Size(91, 20);
            lblViewRoom.TabIndex = 11;
            lblViewRoom.Text = "View Rooms";
            // 
            // RoomForm1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblViewRoom);
            Controls.Add(dataGridView1);
            Controls.Add(btnDelete);
            Controls.Add(btnLoad);
            Controls.Add(btnUpdate);
            Controls.Add(btnAdd);
            Controls.Add(lblStatus);
            Controls.Add(cmbStatus);
            Controls.Add(lblPrice);
            Controls.Add(lblRoomType);
            Controls.Add(txtPric);
            Controls.Add(textRoomType);
            Name = "RoomForm1";
            Text = "RoomForm1";
            Load += RoomForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

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
        private DataGridView dataGridView1;
        private Label lblViewRoom;
    }
}