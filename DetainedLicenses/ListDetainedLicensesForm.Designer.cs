namespace MyDVLD_Project
{
    partial class ListDetainedLicensesForm
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
            this.dataGridViewAllDetainedLicenses = new System.Windows.Forms.DataGridView();
            this.lbHeader = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnRelease = new System.Windows.Forms.Button();
            this.btnDetain = new System.Windows.Forms.Button();
            this.btClose = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.toolStripMenuItemPerson = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemLicenseDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemHistory = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemRelease = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAllDetainedLicenses)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbNumRecords
            // 
            this.lbNumRecords.AutoSize = true;
            this.lbNumRecords.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNumRecords.Location = new System.Drawing.Point(111, 735);
            this.lbNumRecords.Name = "lbNumRecords";
            this.lbNumRecords.Size = new System.Drawing.Size(0, 18);
            this.lbNumRecords.TabIndex = 20;
            // 
            // lbRecords
            // 
            this.lbRecords.AutoSize = true;
            this.lbRecords.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRecords.Location = new System.Drawing.Point(12, 734);
            this.lbRecords.Name = "lbRecords";
            this.lbRecords.Size = new System.Drawing.Size(93, 19);
            this.lbRecords.TabIndex = 19;
            this.lbRecords.Text = "#Records:";
            // 
            // txbFilter
            // 
            this.txbFilter.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbFilter.Location = new System.Drawing.Point(283, 306);
            this.txbFilter.Name = "txbFilter";
            this.txbFilter.Size = new System.Drawing.Size(155, 26);
            this.txbFilter.TabIndex = 18;
            this.txbFilter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbFilter_KeyPress);
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Noun",
            "DetainID",
            "LicenseID",
            "ReleaseApplicationID",
            "IsReleased",
            "NationalNo",
            "FullName"});
            this.comboBox1.Location = new System.Drawing.Point(105, 306);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(153, 25);
            this.comboBox1.TabIndex = 15;
            // 
            // lbFilter
            // 
            this.lbFilter.AutoSize = true;
            this.lbFilter.Font = new System.Drawing.Font("Ebrima", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFilter.Location = new System.Drawing.Point(6, 306);
            this.lbFilter.Name = "lbFilter";
            this.lbFilter.Size = new System.Drawing.Size(76, 21);
            this.lbFilter.TabIndex = 14;
            this.lbFilter.Text = "Filter By:";
            // 
            // dataGridViewAllDetainedLicenses
            // 
            this.dataGridViewAllDetainedLicenses.AllowUserToAddRows = false;
            this.dataGridViewAllDetainedLicenses.AllowUserToDeleteRows = false;
            this.dataGridViewAllDetainedLicenses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAllDetainedLicenses.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridViewAllDetainedLicenses.Location = new System.Drawing.Point(10, 349);
            this.dataGridViewAllDetainedLicenses.Name = "dataGridViewAllDetainedLicenses";
            this.dataGridViewAllDetainedLicenses.ReadOnly = true;
            this.dataGridViewAllDetainedLicenses.RowHeadersWidth = 50;
            this.dataGridViewAllDetainedLicenses.Size = new System.Drawing.Size(1317, 362);
            this.dataGridViewAllDetainedLicenses.TabIndex = 13;
            // 
            // lbHeader
            // 
            this.lbHeader.AutoSize = true;
            this.lbHeader.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHeader.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lbHeader.Location = new System.Drawing.Point(495, 258);
            this.lbHeader.Name = "lbHeader";
            this.lbHeader.Size = new System.Drawing.Size(278, 29);
            this.lbHeader.TabIndex = 12;
            this.lbHeader.Text = "List Detained Licenses";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemPerson,
            this.toolStripMenuItemLicenseDetails,
            this.toolStripMenuItemHistory,
            this.toolStripMenuItemRelease});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(269, 108);
            // 
            // btnRelease
            // 
            this.btnRelease.BackgroundImage = global::MyDVLD_Project.Properties.Resources.Release_Detained_License_64;
            this.btnRelease.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnRelease.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRelease.Location = new System.Drawing.Point(1171, 293);
            this.btnRelease.Name = "btnRelease";
            this.btnRelease.Size = new System.Drawing.Size(63, 50);
            this.btnRelease.TabIndex = 21;
            this.btnRelease.UseVisualStyleBackColor = true;
            this.btnRelease.Click += new System.EventHandler(this.btnRelease_Click);
            // 
            // btnDetain
            // 
            this.btnDetain.BackgroundImage = global::MyDVLD_Project.Properties.Resources.Detain_642;
            this.btnDetain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDetain.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetain.Location = new System.Drawing.Point(1251, 293);
            this.btnDetain.Name = "btnDetain";
            this.btnDetain.Size = new System.Drawing.Size(63, 50);
            this.btnDetain.TabIndex = 17;
            this.btnDetain.UseVisualStyleBackColor = true;
            this.btnDetain.Click += new System.EventHandler(this.btnDetain_Click);
            // 
            // btClose
            // 
            this.btClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btClose.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btClose.Image = global::MyDVLD_Project.Properties.Resources.Close_32;
            this.btClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btClose.Location = new System.Drawing.Point(1197, 734);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(117, 36);
            this.btClose.TabIndex = 16;
            this.btClose.Text = "Close";
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::MyDVLD_Project.Properties.Resources.Detain_5121;
            this.pictureBox1.Location = new System.Drawing.Point(490, 25);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(271, 215);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // toolStripMenuItemPerson
            // 
            this.toolStripMenuItemPerson.Image = global::MyDVLD_Project.Properties.Resources.PersonDetails_324;
            this.toolStripMenuItemPerson.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripMenuItemPerson.Name = "toolStripMenuItemPerson";
            this.toolStripMenuItemPerson.Size = new System.Drawing.Size(268, 26);
            this.toolStripMenuItemPerson.Text = "Show Person Details";
            this.toolStripMenuItemPerson.Click += new System.EventHandler(this.toolStripMenuItemPerson_Click);
            // 
            // toolStripMenuItemLicenseDetails
            // 
            this.toolStripMenuItemLicenseDetails.Image = global::MyDVLD_Project.Properties.Resources.License_View_323;
            this.toolStripMenuItemLicenseDetails.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripMenuItemLicenseDetails.Name = "toolStripMenuItemLicenseDetails";
            this.toolStripMenuItemLicenseDetails.Size = new System.Drawing.Size(268, 26);
            this.toolStripMenuItemLicenseDetails.Text = "Show License Details";
            this.toolStripMenuItemLicenseDetails.Click += new System.EventHandler(this.toolStripMenuItemLicenseDetails_Click);
            // 
            // toolStripMenuItemHistory
            // 
            this.toolStripMenuItemHistory.Image = global::MyDVLD_Project.Properties.Resources.PersonLicenseHistory_322;
            this.toolStripMenuItemHistory.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripMenuItemHistory.Name = "toolStripMenuItemHistory";
            this.toolStripMenuItemHistory.Size = new System.Drawing.Size(268, 26);
            this.toolStripMenuItemHistory.Text = "Show License History ";
            this.toolStripMenuItemHistory.Click += new System.EventHandler(this.toolStripMenuItemHistory_Click);
            // 
            // toolStripMenuItemRelease
            // 
            this.toolStripMenuItemRelease.Image = global::MyDVLD_Project.Properties.Resources.Release_Detained_License_322;
            this.toolStripMenuItemRelease.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripMenuItemRelease.Name = "toolStripMenuItemRelease";
            this.toolStripMenuItemRelease.Size = new System.Drawing.Size(268, 26);
            this.toolStripMenuItemRelease.Text = "Release Detained License";
            this.toolStripMenuItemRelease.Click += new System.EventHandler(this.toolStripMenuItemRelease_Click);
            // 
            // ListDetainedLicensesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1325, 774);
            this.Controls.Add(this.btnRelease);
            this.Controls.Add(this.lbNumRecords);
            this.Controls.Add(this.lbRecords);
            this.Controls.Add(this.txbFilter);
            this.Controls.Add(this.btnDetain);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.lbFilter);
            this.Controls.Add(this.dataGridViewAllDetainedLicenses);
            this.Controls.Add(this.lbHeader);
            this.Controls.Add(this.pictureBox1);
            this.Name = "ListDetainedLicensesForm";
            this.Text = "ListDetainedLicensesForm";
            this.Load += new System.EventHandler(this.ListDetainedLicensesForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAllDetainedLicenses)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbNumRecords;
        private System.Windows.Forms.Label lbRecords;
        private System.Windows.Forms.TextBox txbFilter;
        private System.Windows.Forms.Button btnDetain;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label lbFilter;
        private System.Windows.Forms.DataGridView dataGridViewAllDetainedLicenses;
        private System.Windows.Forms.Label lbHeader;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnRelease;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemPerson;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemLicenseDetails;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemHistory;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemRelease;
    }
}