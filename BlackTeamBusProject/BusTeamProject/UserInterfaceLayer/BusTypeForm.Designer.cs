namespace UserInterfaceLayer
{
    partial class BusTypeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BusTypeForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtBusTypeName = new System.Windows.Forms.TextBox();
            this.btnRemoveListBox = new System.Windows.Forms.Button();
            this.btnAddListBox = new System.Windows.Forms.Button();
            this.lstBusProperty = new System.Windows.Forms.ListBox();
            this.numSeatCount = new System.Windows.Forms.NumericUpDown();
            this.numBackDoorIndex = new System.Windows.Forms.NumericUpDown();
            this.cmbBusPropertyTablo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvBusTypeList = new System.Windows.Forms.DataGridView();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnSaveBusRegist = new System.Windows.Forms.Button();
            this.btnUpdateBusRegist = new System.Windows.Forms.Button();
            this.btnDeleteBusRegist = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSeatCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBackDoorIndex)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBusTypeList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtBusTypeName);
            this.groupBox1.Controls.Add(this.btnRemoveListBox);
            this.groupBox1.Controls.Add(this.btnAddListBox);
            this.groupBox1.Controls.Add(this.lstBusProperty);
            this.groupBox1.Controls.Add(this.numSeatCount);
            this.groupBox1.Controls.Add(this.numBackDoorIndex);
            this.groupBox1.Controls.Add(this.cmbBusPropertyTablo);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Verdana", 10F);
            this.groupBox1.ForeColor = System.Drawing.Color.DarkGray;
            this.groupBox1.Location = new System.Drawing.Point(12, 411);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(973, 350);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Otobüs Tipi Kayıt";
            // 
            // txtBusTypeName
            // 
            this.txtBusTypeName.Location = new System.Drawing.Point(279, 42);
            this.txtBusTypeName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtBusTypeName.Name = "txtBusTypeName";
            this.txtBusTypeName.Size = new System.Drawing.Size(219, 28);
            this.txtBusTypeName.TabIndex = 6;
            // 
            // btnRemoveListBox
            // 
            this.btnRemoveListBox.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SeaGreen;
            this.btnRemoveListBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveListBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnRemoveListBox.Location = new System.Drawing.Point(564, 292);
            this.btnRemoveListBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRemoveListBox.Name = "btnRemoveListBox";
            this.btnRemoveListBox.Size = new System.Drawing.Size(113, 38);
            this.btnRemoveListBox.TabIndex = 5;
            this.btnRemoveListBox.Text = "Sil";
            this.btnRemoveListBox.UseVisualStyleBackColor = true;
            this.btnRemoveListBox.Click += new System.EventHandler(this.btnRemoveListBox_Click);
            // 
            // btnAddListBox
            // 
            this.btnAddListBox.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SeaGreen;
            this.btnAddListBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddListBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnAddListBox.Location = new System.Drawing.Point(279, 292);
            this.btnAddListBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAddListBox.Name = "btnAddListBox";
            this.btnAddListBox.Size = new System.Drawing.Size(120, 38);
            this.btnAddListBox.TabIndex = 5;
            this.btnAddListBox.Text = "Ekle";
            this.btnAddListBox.UseVisualStyleBackColor = true;
            this.btnAddListBox.Click += new System.EventHandler(this.btnAddListBox_Click);
            // 
            // lstBusProperty
            // 
            this.lstBusProperty.FormattingEnabled = true;
            this.lstBusProperty.ItemHeight = 20;
            this.lstBusProperty.Location = new System.Drawing.Point(564, 50);
            this.lstBusProperty.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lstBusProperty.Name = "lstBusProperty";
            this.lstBusProperty.Size = new System.Drawing.Size(379, 204);
            this.lstBusProperty.TabIndex = 4;
            // 
            // numSeatCount
            // 
            this.numSeatCount.Location = new System.Drawing.Point(279, 171);
            this.numSeatCount.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.numSeatCount.Name = "numSeatCount";
            this.numSeatCount.Size = new System.Drawing.Size(120, 28);
            this.numSeatCount.TabIndex = 3;
            // 
            // numBackDoorIndex
            // 
            this.numBackDoorIndex.Location = new System.Drawing.Point(279, 110);
            this.numBackDoorIndex.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.numBackDoorIndex.Name = "numBackDoorIndex";
            this.numBackDoorIndex.Size = new System.Drawing.Size(120, 28);
            this.numBackDoorIndex.TabIndex = 3;
            // 
            // cmbBusPropertyTablo
            // 
            this.cmbBusPropertyTablo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBusPropertyTablo.FormattingEnabled = true;
            this.cmbBusPropertyTablo.Items.AddRange(new object[] {
            "Rahat    2+1",
            "Normal 2+2"});
            this.cmbBusPropertyTablo.Location = new System.Drawing.Point(279, 246);
            this.cmbBusPropertyTablo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbBusPropertyTablo.Name = "cmbBusPropertyTablo";
            this.cmbBusPropertyTablo.Size = new System.Drawing.Size(219, 28);
            this.cmbBusPropertyTablo.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 10F);
            this.label3.ForeColor = System.Drawing.Color.DarkGray;
            this.label3.Location = new System.Drawing.Point(45, 178);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Koltuk Sayısı";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 10F);
            this.label2.ForeColor = System.Drawing.Color.DarkGray;
            this.label2.Location = new System.Drawing.Point(45, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(180, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Arka Kapı Numarası";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 10F);
            this.label4.ForeColor = System.Drawing.Color.DarkGray;
            this.label4.Location = new System.Drawing.Point(45, 254);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(160, 20);
            this.label4.TabIndex = 1;
            this.label4.Text = "Otobüs Özellikleri";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 10F);
            this.label1.ForeColor = System.Drawing.Color.DarkGray;
            this.label1.Location = new System.Drawing.Point(45, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Otobüs Tipi Adı:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvBusTypeList);
            this.groupBox2.Font = new System.Drawing.Font("Verdana", 10F);
            this.groupBox2.ForeColor = System.Drawing.Color.DarkGray;
            this.groupBox2.Location = new System.Drawing.Point(12, 17);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(1467, 386);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Otobüs Tipi Kayıt Listesi";
            // 
            // dgvBusTypeList
            // 
            this.dgvBusTypeList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBusTypeList.Location = new System.Drawing.Point(5, 21);
            this.dgvBusTypeList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvBusTypeList.Name = "dgvBusTypeList";
            this.dgvBusTypeList.RowTemplate.Height = 24;
            this.dgvBusTypeList.Size = new System.Drawing.Size(1453, 359);
            this.dgvBusTypeList.TabIndex = 0;
            this.dgvBusTypeList.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvAuthoryNameList_RowHeaderMouseClick);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(125, 132);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(29, 30);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 4;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(125, 194);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(29, 30);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(125, 70);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(29, 30);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // btnSaveBusRegist
            // 
            this.btnSaveBusRegist.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SeaGreen;
            this.btnSaveBusRegist.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveBusRegist.Location = new System.Drawing.Point(125, 70);
            this.btnSaveBusRegist.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSaveBusRegist.Name = "btnSaveBusRegist";
            this.btnSaveBusRegist.Size = new System.Drawing.Size(228, 30);
            this.btnSaveBusRegist.TabIndex = 5;
            this.btnSaveBusRegist.Text = "Kaydet";
            this.btnSaveBusRegist.UseVisualStyleBackColor = true;
            this.btnSaveBusRegist.Click += new System.EventHandler(this.btnSaveBusRegist_Click);
            // 
            // btnUpdateBusRegist
            // 
            this.btnUpdateBusRegist.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SeaGreen;
            this.btnUpdateBusRegist.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateBusRegist.Location = new System.Drawing.Point(125, 194);
            this.btnUpdateBusRegist.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnUpdateBusRegist.Name = "btnUpdateBusRegist";
            this.btnUpdateBusRegist.Size = new System.Drawing.Size(228, 30);
            this.btnUpdateBusRegist.TabIndex = 5;
            this.btnUpdateBusRegist.Text = "Güncelle";
            this.btnUpdateBusRegist.UseVisualStyleBackColor = true;
            this.btnUpdateBusRegist.Click += new System.EventHandler(this.btnUpdateBusRegist_Click);
            // 
            // btnDeleteBusRegist
            // 
            this.btnDeleteBusRegist.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SeaGreen;
            this.btnDeleteBusRegist.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteBusRegist.Location = new System.Drawing.Point(125, 132);
            this.btnDeleteBusRegist.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDeleteBusRegist.Name = "btnDeleteBusRegist";
            this.btnDeleteBusRegist.Size = new System.Drawing.Size(228, 30);
            this.btnDeleteBusRegist.TabIndex = 5;
            this.btnDeleteBusRegist.Text = "Sil";
            this.btnDeleteBusRegist.UseVisualStyleBackColor = true;
            this.btnDeleteBusRegist.Click += new System.EventHandler(this.btnDeleteBusRegist_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.pictureBox3);
            this.groupBox3.Controls.Add(this.pictureBox2);
            this.groupBox3.Controls.Add(this.pictureBox1);
            this.groupBox3.Controls.Add(this.btnSaveBusRegist);
            this.groupBox3.Controls.Add(this.btnUpdateBusRegist);
            this.groupBox3.Controls.Add(this.btnDeleteBusRegist);
            this.groupBox3.Font = new System.Drawing.Font("Verdana", 10F);
            this.groupBox3.ForeColor = System.Drawing.Color.DarkGray;
            this.groupBox3.Location = new System.Drawing.Point(1007, 411);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Size = new System.Drawing.Size(472, 350);
            this.groupBox3.TabIndex = 21;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "İşlemler";
            // 
            // BusTypeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(36)))), ((int)(((byte)(59)))));
            this.ClientSize = new System.Drawing.Size(1498, 777);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "BusTypeForm";
            this.Text = "BusTypeForm";
            this.Load += new System.EventHandler(this.BusTypeForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSeatCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBackDoorIndex)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBusTypeList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown numSeatCount;
        private System.Windows.Forms.NumericUpDown numBackDoorIndex;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvBusTypeList;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnSaveBusRegist;
        private System.Windows.Forms.Button btnUpdateBusRegist;
        private System.Windows.Forms.Button btnDeleteBusRegist;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListBox lstBusProperty;
        private System.Windows.Forms.ComboBox cmbBusPropertyTablo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnRemoveListBox;
        private System.Windows.Forms.Button btnAddListBox;
        private System.Windows.Forms.TextBox txtBusTypeName;
    }
}