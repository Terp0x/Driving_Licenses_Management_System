namespace MyDVLD_Project
{
    partial class ApplicationTypesForm
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
            this.lbHeader = new System.Windows.Forms.Label();
            this.lbNumRecords = new System.Windows.Forms.Label();
            this.lbRecords = new System.Windows.Forms.Label();
            this.dataGridViewAllApplication = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btClose = new System.Windows.Forms.Button();
            this.toolStripMenuItemedit = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAllApplication)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbHeader
            // 
            this.lbHeader.AutoSize = true;
            this.lbHeader.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHeader.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lbHeader.Location = new System.Drawing.Point(221, 240);
            this.lbHeader.Name = "lbHeader";
            this.lbHeader.Size = new System.Drawing.Size(400, 33);
            this.lbHeader.TabIndex = 13;
            this.lbHeader.Text = "Manage   Application   Types";
            // 
            // lbNumRecords
            // 
            this.lbNumRecords.AutoSize = true;
            this.lbNumRecords.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNumRecords.Location = new System.Drawing.Point(142, 731);
            this.lbNumRecords.Name = "lbNumRecords";
            this.lbNumRecords.Size = new System.Drawing.Size(0, 18);
            this.lbNumRecords.TabIndex = 24;
            // 
            // lbRecords
            // 
            this.lbRecords.AutoSize = true;
            this.lbRecords.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRecords.Location = new System.Drawing.Point(31, 731);
            this.lbRecords.Name = "lbRecords";
            this.lbRecords.Size = new System.Drawing.Size(93, 19);
            this.lbRecords.TabIndex = 23;
            this.lbRecords.Text = "#Records:";
            // 
            // dataGridViewAllApplication
            // 
            this.dataGridViewAllApplication.AllowUserToAddRows = false;
            this.dataGridViewAllApplication.AllowUserToDeleteRows = false;
            this.dataGridViewAllApplication.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAllApplication.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridViewAllApplication.Location = new System.Drawing.Point(15, 350);
            this.dataGridViewAllApplication.Name = "dataGridViewAllApplication";
            this.dataGridViewAllApplication.ReadOnly = true;
            this.dataGridViewAllApplication.RowHeadersWidth = 50;
            this.dataGridViewAllApplication.Size = new System.Drawing.Size(853, 366);
            this.dataGridViewAllApplication.TabIndex = 21;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemedit});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(181, 56);
            // 
            // btClose
            // 
            this.btClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btClose.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btClose.Image = global::MyDVLD_Project.Properties.Resources.Close_32;
            this.btClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btClose.Location = new System.Drawing.Point(744, 722);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(124, 41);
            this.btClose.TabIndex = 22;
            this.btClose.Text = "Close";
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // toolStripMenuItemedit
            // 
            this.toolStripMenuItemedit.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripMenuItemedit.Image = global::MyDVLD_Project.Properties.Resources.edit_321;
            this.toolStripMenuItemedit.Name = "toolStripMenuItemedit";
            this.toolStripMenuItemedit.Size = new System.Drawing.Size(180, 30);
            this.toolStripMenuItemedit.Text = "Edit";
            this.toolStripMenuItemedit.Click += new System.EventHandler(this.toolStripMenuItemedit_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::MyDVLD_Project.Properties.Resources.Application_Types_512;
            this.pictureBox1.Location = new System.Drawing.Point(272, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(307, 225);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // ApplicationTypesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 794);
            this.Controls.Add(this.lbNumRecords);
            this.Controls.Add(this.lbRecords);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.dataGridViewAllApplication);
            this.Controls.Add(this.lbHeader);
            this.Controls.Add(this.pictureBox1);
            this.Name = "ApplicationTypesForm";
            this.Text = "ApplicationTypesForm";
            this.Load += new System.EventHandler(this.ApplicationTypesForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAllApplication)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbHeader;
        private System.Windows.Forms.Label lbNumRecords;
        private System.Windows.Forms.Label lbRecords;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.DataGridView dataGridViewAllApplication;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemedit;
    }
}