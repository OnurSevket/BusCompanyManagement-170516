namespace UserInterfaceLayer
{
    partial class BusRegistrationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BusRegistrationForm));
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtModel = new System.Windows.Forms.TextBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnSaveBusRegist = new System.Windows.Forms.Button();
            this.btnUpdateBusRegist = new System.Windows.Forms.Button();
            this.btnDeleteBusRegist = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvBusList = new System.Windows.Forms.DataGridView();
            this.txtPlate = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbBusTypeID = new System.Windows.Forms.ComboBox();
            this.txtBrand = new System.Windows.Forms.TextBox();
            this.mtxtYear = new System.Windows.Forms.MaskedTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBusList)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 10F);
            this.label2.ForeColor = System.Drawing.Color.DarkGray;
            this.label2.Location = new System.Drawing.Point(36, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Model";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 10F);
            this.label1.ForeColor = System.Drawing.Color.DarkGray;
            this.label1.Location = new System.Drawing.Point(36, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Marka";
            // 
            // txtModel
            // 
            this.txtModel.Location = new System.Drawing.Point(180, 95);
            this.txtModel.Name = "txtModel";
            this.txtModel.Size = new System.Drawing.Size(219, 28);
            this.txtModel.TabIndex = 0;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(125, 132);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(30, 29);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 4;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(125, 194);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(30, 29);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(125, 70);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(30, 29);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
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
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(472, 350);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "İşlemler";
            // 
            // btnSaveBusRegist
            // 
            this.btnSaveBusRegist.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SeaGreen;
            this.btnSaveBusRegist.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveBusRegist.Location = new System.Drawing.Point(125, 70);
            this.btnSaveBusRegist.Name = "btnSaveBusRegist";
            this.btnSaveBusRegist.Size = new System.Drawing.Size(228, 29);
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
            this.btnUpdateBusRegist.Name = "btnUpdateBusRegist";
            this.btnUpdateBusRegist.Size = new System.Drawing.Size(228, 29);
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
            this.btnDeleteBusRegist.Name = "btnDeleteBusRegist";
            this.btnDeleteBusRegist.Size = new System.Drawing.Size(228, 29);
            this.btnDeleteBusRegist.TabIndex = 5;
            this.btnDeleteBusRegist.Text = "Sil";
            this.btnDeleteBusRegist.UseVisualStyleBackColor = true;
            this.btnDeleteBusRegist.Click += new System.EventHandler(this.btnDeleteBusRegist_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvBusList);
            this.groupBox2.Font = new System.Drawing.Font("Verdana", 10F);
            this.groupBox2.ForeColor = System.Drawing.Color.DarkGray;
            this.groupBox2.Location = new System.Drawing.Point(12, 17);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1466, 386);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Otobüs Kayıt Listesi";
            // 
            // dgvBusList
            // 
            this.dgvBusList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBusList.Location = new System.Drawing.Point(6, 21);
            this.dgvBusList.Name = "dgvBusList";
            this.dgvBusList.RowTemplate.Height = 24;
            this.dgvBusList.Size = new System.Drawing.Size(1454, 359);
            this.dgvBusList.TabIndex = 0;
            this.dgvBusList.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvBusList_RowHeaderMouseClick);
            // 
            // txtPlate
            // 
            this.txtPlate.Location = new System.Drawing.Point(180, 239);
            this.txtPlate.Name = "txtPlate";
            this.txtPlate.Size = new System.Drawing.Size(219, 28);
            this.txtPlate.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 10F);
            this.label5.ForeColor = System.Drawing.Color.DarkGray;
            this.label5.Location = new System.Drawing.Point(36, 194);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 20);
            this.label5.TabIndex = 1;
            this.label5.Text = "Otobüs Tipi";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 10F);
            this.label4.ForeColor = System.Drawing.Color.DarkGray;
            this.label4.Location = new System.Drawing.Point(36, 243);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 20);
            this.label4.TabIndex = 1;
            this.label4.Text = "Plaka";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 10F);
            this.label3.ForeColor = System.Drawing.Color.DarkGray;
            this.label3.Location = new System.Drawing.Point(36, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Yıl";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.mtxtYear);
            this.groupBox1.Controls.Add(this.cmbBusTypeID);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtModel);
            this.groupBox1.Controls.Add(this.txtBrand);
            this.groupBox1.Controls.Add(this.txtPlate);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Font = new System.Drawing.Font("Verdana", 10F);
            this.groupBox1.ForeColor = System.Drawing.Color.DarkGray;
            this.groupBox1.Location = new System.Drawing.Point(12, 411);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(974, 350);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Araç Kayıt";
            // 
            // cmbBusTypeID
            // 
            this.cmbBusTypeID.FormattingEnabled = true;
            this.cmbBusTypeID.Location = new System.Drawing.Point(180, 191);
            this.cmbBusTypeID.Name = "cmbBusTypeID";
            this.cmbBusTypeID.Size = new System.Drawing.Size(219, 28);
            this.cmbBusTypeID.TabIndex = 2;
            // 
            // txtBrand
            // 
            this.txtBrand.Location = new System.Drawing.Point(180, 47);
            this.txtBrand.Name = "txtBrand";
            this.txtBrand.Size = new System.Drawing.Size(219, 28);
            this.txtBrand.TabIndex = 0;
            // 
            // mtxtYear
            // 
            this.mtxtYear.Location = new System.Drawing.Point(180, 142);
            this.mtxtYear.Mask = "00/00/0000";
            this.mtxtYear.Name = "mtxtYear";
            this.mtxtYear.Size = new System.Drawing.Size(219, 28);
            this.mtxtYear.TabIndex = 4;
            this.mtxtYear.ValidatingType = typeof(System.DateTime);
            // 
            // BusRegistrationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(36)))), ((int)(((byte)(59)))));
            this.ClientSize = new System.Drawing.Size(1491, 779);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "BusRegistrationForm";
            this.Text = "BusRegistrationForm";
            this.Load += new System.EventHandler(this.BusRegistrationForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBusList)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtModel;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvBusList;
        private System.Windows.Forms.TextBox txtPlate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtBrand;
        private System.Windows.Forms.Button btnSaveBusRegist;
        private System.Windows.Forms.Button btnUpdateBusRegist;
        private System.Windows.Forms.Button btnDeleteBusRegist;
        private System.Windows.Forms.ComboBox cmbBusTypeID;
        private System.Windows.Forms.MaskedTextBox mtxtYear;
    }
}