namespace UserInterfaceLayer
{
    partial class RouteSeatSelectionForm
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
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRouteSearch = new System.Windows.Forms.Button();
            this.dtpRouteSearchDate = new System.Windows.Forms.DateTimePicker();
            this.cmbLastPointCity = new System.Windows.Forms.ComboBox();
            this.cmbFirstCityPoint = new System.Windows.Forms.ComboBox();
            this.dgvPassangerList = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.grpboxSeatSelection = new System.Windows.Forms.GroupBox();
            this.btnNextStep = new System.Windows.Forms.Button();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPassangerList)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.btnRouteSearch);
            this.groupBox4.Controls.Add(this.dtpRouteSearchDate);
            this.groupBox4.Controls.Add(this.cmbLastPointCity);
            this.groupBox4.Controls.Add(this.cmbFirstCityPoint);
            this.groupBox4.Location = new System.Drawing.Point(27, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1028, 122);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 10F);
            this.label3.ForeColor = System.Drawing.Color.DarkGray;
            this.label3.Location = new System.Drawing.Point(597, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Kalkış Tarihi";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 10F);
            this.label2.ForeColor = System.Drawing.Color.DarkGray;
            this.label2.Location = new System.Drawing.Point(299, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Nereye";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 10F);
            this.label1.ForeColor = System.Drawing.Color.DarkGray;
            this.label1.Location = new System.Drawing.Point(19, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Nereden";
            // 
            // btnRouteSearch
            // 
            this.btnRouteSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSeaGreen;
            this.btnRouteSearch.Location = new System.Drawing.Point(869, 45);
            this.btnRouteSearch.Name = "btnRouteSearch";
            this.btnRouteSearch.Size = new System.Drawing.Size(150, 46);
            this.btnRouteSearch.TabIndex = 3;
            this.btnRouteSearch.Text = "Sefer Ara";
            this.btnRouteSearch.UseVisualStyleBackColor = true;
            this.btnRouteSearch.Click += new System.EventHandler(this.btnRouteSearch_Click);
            // 
            // dtpRouteSearchDate
            // 
            this.dtpRouteSearchDate.Location = new System.Drawing.Point(601, 55);
            this.dtpRouteSearchDate.Name = "dtpRouteSearchDate";
            this.dtpRouteSearchDate.Size = new System.Drawing.Size(253, 22);
            this.dtpRouteSearchDate.TabIndex = 2;
            // 
            // cmbLastPointCity
            // 
            this.cmbLastPointCity.FormattingEnabled = true;
            this.cmbLastPointCity.Location = new System.Drawing.Point(303, 55);
            this.cmbLastPointCity.Name = "cmbLastPointCity";
            this.cmbLastPointCity.Size = new System.Drawing.Size(259, 24);
            this.cmbLastPointCity.TabIndex = 1;
            // 
            // cmbFirstCityPoint
            // 
            this.cmbFirstCityPoint.FormattingEnabled = true;
            this.cmbFirstCityPoint.Location = new System.Drawing.Point(13, 57);
            this.cmbFirstCityPoint.Name = "cmbFirstCityPoint";
            this.cmbFirstCityPoint.Size = new System.Drawing.Size(259, 24);
            this.cmbFirstCityPoint.TabIndex = 1;
            // 
            // dgvPassangerList
            // 
            this.dgvPassangerList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPassangerList.Location = new System.Drawing.Point(6, 21);
            this.dgvPassangerList.Name = "dgvPassangerList";
            this.dgvPassangerList.RowTemplate.Height = 24;
            this.dgvPassangerList.Size = new System.Drawing.Size(1037, 517);
            this.dgvPassangerList.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvPassangerList);
            this.groupBox2.Font = new System.Drawing.Font("Verdana", 10F);
            this.groupBox2.ForeColor = System.Drawing.Color.DarkGray;
            this.groupBox2.Location = new System.Drawing.Point(27, 153);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1035, 544);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Yolcu Kayıt Listesi";
            // 
            // grpboxSeatSelection
            // 
            this.grpboxSeatSelection.Font = new System.Drawing.Font("Verdana", 10F);
            this.grpboxSeatSelection.ForeColor = System.Drawing.Color.DarkGray;
            this.grpboxSeatSelection.Location = new System.Drawing.Point(1068, 12);
            this.grpboxSeatSelection.Name = "grpboxSeatSelection";
            this.grpboxSeatSelection.Size = new System.Drawing.Size(411, 755);
            this.grpboxSeatSelection.TabIndex = 17;
            this.grpboxSeatSelection.TabStop = false;
            this.grpboxSeatSelection.Text = "Koltuk Seçimi";
            // 
            // btnNextStep
            // 
            this.btnNextStep.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SeaGreen;
            this.btnNextStep.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNextStep.Font = new System.Drawing.Font("Verdana", 10.2F);
            this.btnNextStep.ForeColor = System.Drawing.Color.DarkGray;
            this.btnNextStep.Location = new System.Drawing.Point(843, 718);
            this.btnNextStep.Name = "btnNextStep";
            this.btnNextStep.Size = new System.Drawing.Size(212, 49);
            this.btnNextStep.TabIndex = 18;
            this.btnNextStep.Text = "Sonraki Adıma Geç";
            this.btnNextStep.UseVisualStyleBackColor = true;
            this.btnNextStep.Click += new System.EventHandler(this.btnNextStep_Click);
            // 
            // RouteSeatSelectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(36)))), ((int)(((byte)(59)))));
            this.ClientSize = new System.Drawing.Size(1491, 779);
            this.Controls.Add(this.btnNextStep);
            this.Controls.Add(this.grpboxSeatSelection);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Name = "RouteSeatSelectionForm";
            this.Text = "RouteSeatSelectionForm";
            this.Load += new System.EventHandler(this.RouteSeatSelectionForm_Load);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPassangerList)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnRouteSearch;
        private System.Windows.Forms.DateTimePicker dtpRouteSearchDate;
        private System.Windows.Forms.ComboBox cmbLastPointCity;
        private System.Windows.Forms.ComboBox cmbFirstCityPoint;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvPassangerList;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox grpboxSeatSelection;
        private System.Windows.Forms.Button btnNextStep;
    }
}