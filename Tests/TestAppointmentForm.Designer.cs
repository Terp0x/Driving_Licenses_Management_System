namespace MyDVLD_Project
{
    partial class TestAppointmentForm
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
            this.lbTitle = new System.Windows.Forms.Label();
            this.dataGridViewallappointments = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.btClose = new System.Windows.Forms.Button();
            this.toolStripMenuItemedit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemtaketest = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ctrlDrivingLicenseApplicationsInfo1 = new MyDVLD_Project.CtrlDrivingLicenseApplicationsInfo();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewallappointments)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lbTitle.Location = new System.Drawing.Point(314, 164);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(346, 31);
            this.lbTitle.TabIndex = 1;
            this.lbTitle.Text = "Vision Test Appointments";
            // 
            // dataGridViewallappointments
            // 
            this.dataGridViewallappointments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewallappointments.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridViewallappointments.Location = new System.Drawing.Point(25, 712);
            this.dataGridViewallappointments.Name = "dataGridViewallappointments";
            this.dataGridViewallappointments.Size = new System.Drawing.Size(919, 137);
            this.dataGridViewallappointments.TabIndex = 3;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemedit,
            this.toolStripMenuItemtaketest});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(181, 78);
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::MyDVLD_Project.Properties.Resources.AddAppointment_32;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(879, 652);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(66, 54);
            this.button1.TabIndex = 19;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btClose
            // 
            this.btClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btClose.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btClose.Image = global::MyDVLD_Project.Properties.Resources.Close_32;
            this.btClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btClose.Location = new System.Drawing.Point(818, 855);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(127, 41);
            this.btClose.TabIndex = 18;
            this.btClose.Text = "Close";
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // toolStripMenuItemedit
            // 
            this.toolStripMenuItemedit.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripMenuItemedit.Image = global::MyDVLD_Project.Properties.Resources.edit_322;
            this.toolStripMenuItemedit.Name = "toolStripMenuItemedit";
            this.toolStripMenuItemedit.Size = new System.Drawing.Size(180, 26);
            this.toolStripMenuItemedit.Text = "Edit";
            this.toolStripMenuItemedit.Click += new System.EventHandler(this.toolStripMenuItemedit_Click);
            // 
            // toolStripMenuItemtaketest
            // 
            this.toolStripMenuItemtaketest.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripMenuItemtaketest.Image = global::MyDVLD_Project.Properties.Resources.Test_32;
            this.toolStripMenuItemtaketest.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripMenuItemtaketest.Name = "toolStripMenuItemtaketest";
            this.toolStripMenuItemtaketest.Size = new System.Drawing.Size(180, 26);
            this.toolStripMenuItemtaketest.Text = "Take Test";
            this.toolStripMenuItemtaketest.Click += new System.EventHandler(this.toolStripMenuItemtaketest_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::MyDVLD_Project.Properties.Resources.driving_test_512;
            this.pictureBox1.Location = new System.Drawing.Point(366, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(230, 159);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // ctrlDrivingLicenseApplicationsInfo1
            // 
            this.ctrlDrivingLicenseApplicationsInfo1.Location = new System.Drawing.Point(25, 198);
            this.ctrlDrivingLicenseApplicationsInfo1.Name = "ctrlDrivingLicenseApplicationsInfo1";
            this.ctrlDrivingLicenseApplicationsInfo1.Size = new System.Drawing.Size(920, 448);
            this.ctrlDrivingLicenseApplicationsInfo1.TabIndex = 2;
            // 
            // TestAppointmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(956, 898);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.dataGridViewallappointments);
            this.Controls.Add(this.ctrlDrivingLicenseApplicationsInfo1);
            this.Controls.Add(this.lbTitle);
            this.Controls.Add(this.pictureBox1);
            this.Name = "TestAppointmentForm";
            this.Text = "VisionTestForm";
            this.Load += new System.EventHandler(this.VisionTestForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewallappointments)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbTitle;
        private CtrlDrivingLicenseApplicationsInfo ctrlDrivingLicenseApplicationsInfo1;
        private System.Windows.Forms.DataGridView dataGridViewallappointments;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemedit;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemtaketest;
    }
}