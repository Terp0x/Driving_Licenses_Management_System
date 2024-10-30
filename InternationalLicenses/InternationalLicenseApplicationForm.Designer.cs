namespace MyDVLD_Project
{
    partial class InternationalLicenseApplicationForm
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
            this.components = new System.ComponentModel.Container();
            this.lbNumRecords = new System.Windows.Forms.Label();
            this.lbRecords = new System.Windows.Forms.Label();
            this.txbFilter = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.lbFilter = new System.Windows.Forms.Label();
            this.dataGridViewAllInternationalApplications = new System.Windows.Forms.DataGridView();
            this.lbHeader = new System.Windows.Forms.Label();
            this.contextMenuStripDetails = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btClose = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.toolStripMenuItemLicenseInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAllInternationalApplications)).BeginInit();
            this.contextMenuStripDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbNumRecords
            // 
            this.lbNumRecords.AutoSize = true;
            this.lbNumRecords.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNumRecords.Location = new System.Drawing.Point(119, 798);
            this.lbNumRecords.Name = "lbNumRecords";
            this.lbNumRecords.Size = new System.Drawing.Size(0, 18);
            this.lbNumRecords.TabIndex = 30;
            // 
            // lbRecords
            // 
            this.lbRecords.AutoSize = true;
            this.lbRecords.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRecords.Location = new System.Drawing.Point(8, 798);
            this.lbRecords.Name = "lbRecords";
            this.lbRecords.Size = new System.Drawing.Size(93, 19);
            this.lbRecords.TabIndex = 29;
            this.lbRecords.Text = "#Records:";
            // 
            // txbFilter
            // 
            this.txbFilter.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbFilter.Location = new System.Drawing.Point(296, 281);
            this.txbFilter.Name = "txbFilter";
            this.txbFilter.Size = new System.Drawing.Size(161, 26);
            this.txbFilter.TabIndex = 28;
            this.txbFilter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbFilter_KeyPress);
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Noun",
            "InternationalLicenseID",
            "ApplicationID",
            "DriverID",
            "IssuedUsingLocalLicenseID",
            "IssueDate",
            "ExpirationDate",
            "IsActive"});
            this.comboBox1.Location = new System.Drawing.Point(112, 282);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(163, 25);
            this.comboBox1.TabIndex = 25;
            // 
            // lbFilter
            // 
            this.lbFilter.AutoSize = true;
            this.lbFilter.Font = new System.Drawing.Font("Ebrima", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFilter.Location = new System.Drawing.Point(18, 281);
            this.lbFilter.Name = "lbFilter";
            this.lbFilter.Size = new System.Drawing.Size(76, 21);
            this.lbFilter.TabIndex = 24;
            this.lbFilter.Text = "Filter By:";
            // 
            // dataGridViewAllInternationalApplications
            // 
            this.dataGridViewAllInternationalApplications.AllowUserToAddRows = false;
            this.dataGridViewAllInternationalApplications.AllowUserToDeleteRows = false;
            this.dataGridViewAllInternationalApplications.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAllInternationalApplications.ContextMenuStrip = this.contextMenuStripDetails;
            this.dataGridViewAllInternationalApplications.Location = new System.Drawing.Point(12, 327);
            this.dataGridViewAllInternationalApplications.Name = "dataGridViewAllInternationalApplications";
            this.dataGridViewAllInternationalApplications.ReadOnly = true;
            this.dataGridViewAllInternationalApplications.RowHeadersWidth = 50;
            this.dataGridViewAllInternationalApplications.Size = new System.Drawing.Size(1221, 456);
            this.dataGridViewAllInternationalApplications.TabIndex = 23;
            // 
            // lbHeader
            // 
            this.lbHeader.AutoSize = true;
            this.lbHeader.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHeader.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lbHeader.Location = new System.Drawing.Point(399, 195);
            this.lbHeader.Name = "lbHeader";
            this.lbHeader.Size = new System.Drawing.Size(420, 29);
            this.lbHeader.TabIndex = 22;
            this.lbHeader.Text = "International License Applications";
            // 
            // contextMenuStripDetails
            // 
            this.contextMenuStripDetails.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contextMenuStripDetails.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemLicenseInfo,
            this.toolStripMenuItem1,
            this.toolStripMenuItem2});
            this.contextMenuStripDetails.Name = "contextMenuStripDetails";
            this.contextMenuStripDetails.Size = new System.Drawing.Size(229, 82);
            this.contextMenuStripDetails.Text = "Show person Details";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::MyDVLD_Project.Properties.Resources.International_324;
            this.pictureBox2.Location = new System.Drawing.Point(698, 71);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(67, 51);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 31;
            this.pictureBox2.TabStop = false;
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::MyDVLD_Project.Properties.Resources.New_Application_641;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(1153, 266);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 54);
            this.button1.TabIndex = 27;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btClose
            // 
            this.btClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btClose.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btClose.Image = global::MyDVLD_Project.Properties.Resources.Close_32;
            this.btClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btClose.Location = new System.Drawing.Point(1109, 789);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(124, 41);
            this.btClose.TabIndex = 26;
            this.btClose.Text = "Close";
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::MyDVLD_Project.Properties.Resources.Applications;
            this.pictureBox1.Location = new System.Drawing.Point(499, 7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(221, 185);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 21;
            this.pictureBox1.TabStop = false;
            // 
            // toolStripMenuItemLicenseInfo
            // 
            this.toolStripMenuItemLicenseInfo.Image = global::MyDVLD_Project.Properties.Resources.License_View_322;
            this.toolStripMenuItemLicenseInfo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripMenuItemLicenseInfo.Name = "toolStripMenuItemLicenseInfo";
            this.toolStripMenuItemLicenseInfo.Size = new System.Drawing.Size(228, 26);
            this.toolStripMenuItemLicenseInfo.Text = "Show License Info";
            this.toolStripMenuItemLicenseInfo.Click += new System.EventHandler(this.toolStripMenuItemLicenseInfo_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Image = global::MyDVLD_Project.Properties.Resources.PersonLicenseHistory_321;
            this.toolStripMenuItem1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(228, 26);
            this.toolStripMenuItem1.Text = "Show License History";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Image = global::MyDVLD_Project.Properties.Resources.PersonDetails_323;
            this.toolStripMenuItem2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(228, 26);
            this.toolStripMenuItem2.Text = "Show Person Details";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // InternationalLicenseApplicationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1233, 835);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.lbNumRecords);
            this.Controls.Add(this.lbRecords);
            this.Controls.Add(this.txbFilter);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.lbFilter);
            this.Controls.Add(this.dataGridViewAllInternationalApplications);
            this.Controls.Add(this.lbHeader);
            this.Controls.Add(this.pictureBox1);
            this.Name = "InternationalLicenseApplicationForm";
            this.Text = "InternationalLicenseApplicationForm";
            this.Load += new System.EventHandler(this.InternationalLicenseApplicationForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAllInternationalApplications)).EndInit();
            this.contextMenuStripDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbNumRecords;
        private System.Windows.Forms.Label lbRecords;
        private System.Windows.Forms.TextBox txbFilter;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label lbFilter;
        private System.Windows.Forms.DataGridView dataGridViewAllInternationalApplications;
        private System.Windows.Forms.Label lbHeader;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripDetails;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemLicenseInfo;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
    }
}