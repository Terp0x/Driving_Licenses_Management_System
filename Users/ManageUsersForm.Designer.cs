namespace MyDVLD_Project
{
    partial class ManageUsersForm
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
            this.dataGridViewAllUsers = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.lbHeader = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btClose = new System.Windows.Forms.Button();
            this.toolStripMenuItemDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemedit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItempass = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItememail = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemcall = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAllUsers)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbNumRecords
            // 
            this.lbNumRecords.AutoSize = true;
            this.lbNumRecords.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNumRecords.Location = new System.Drawing.Point(135, 729);
            this.lbNumRecords.Name = "lbNumRecords";
            this.lbNumRecords.Size = new System.Drawing.Size(0, 18);
            this.lbNumRecords.TabIndex = 20;
            // 
            // lbRecords
            // 
            this.lbRecords.AutoSize = true;
            this.lbRecords.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRecords.Location = new System.Drawing.Point(24, 729);
            this.lbRecords.Name = "lbRecords";
            this.lbRecords.Size = new System.Drawing.Size(93, 19);
            this.lbRecords.TabIndex = 19;
            this.lbRecords.Text = "#Records:";
            // 
            // txbFilter
            // 
            this.txbFilter.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbFilter.Location = new System.Drawing.Point(271, 289);
            this.txbFilter.Name = "txbFilter";
            this.txbFilter.Size = new System.Drawing.Size(161, 26);
            this.txbFilter.TabIndex = 18;
            this.txbFilter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbFilter_KeyPress);
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Noun",
            "UserID",
            "PersonID",
            "UserName",
            "FullName",
            "IsActive"});
            this.comboBox1.Location = new System.Drawing.Point(114, 289);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(138, 25);
            this.comboBox1.TabIndex = 15;
            // 
            // lbFilter
            // 
            this.lbFilter.AutoSize = true;
            this.lbFilter.Font = new System.Drawing.Font("Ebrima", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFilter.Location = new System.Drawing.Point(8, 289);
            this.lbFilter.Name = "lbFilter";
            this.lbFilter.Size = new System.Drawing.Size(76, 21);
            this.lbFilter.TabIndex = 14;
            this.lbFilter.Text = "Filter By:";
            // 
            // dataGridViewAllUsers
            // 
            this.dataGridViewAllUsers.AllowUserToAddRows = false;
            this.dataGridViewAllUsers.AllowUserToDeleteRows = false;
            this.dataGridViewAllUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAllUsers.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridViewAllUsers.Location = new System.Drawing.Point(12, 349);
            this.dataGridViewAllUsers.Name = "dataGridViewAllUsers";
            this.dataGridViewAllUsers.ReadOnly = true;
            this.dataGridViewAllUsers.RowHeadersWidth = 50;
            this.dataGridViewAllUsers.Size = new System.Drawing.Size(920, 366);
            this.dataGridViewAllUsers.TabIndex = 13;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(17, 17);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemDetails,
            this.toolStripMenuItem1,
            this.toolStripMenuItemAdd,
            this.toolStripMenuItemedit,
            this.toolStripMenuItemDelete,
            this.toolStripMenuItempass,
            this.toolStripMenuItem2,
            this.toolStripMenuItememail,
            this.toolStripMenuItemcall});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(182, 206);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(178, 6);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(178, 6);
            // 
            // lbHeader
            // 
            this.lbHeader.AutoSize = true;
            this.lbHeader.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHeader.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lbHeader.Location = new System.Drawing.Point(354, 204);
            this.lbHeader.Name = "lbHeader";
            this.lbHeader.Size = new System.Drawing.Size(179, 29);
            this.lbHeader.TabIndex = 12;
            this.lbHeader.Text = "Manage Users";
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::MyDVLD_Project.Properties.Resources.Users_2_400;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(852, 289);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 54);
            this.button1.TabIndex = 17;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btClose
            // 
            this.btClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btClose.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btClose.Image = global::MyDVLD_Project.Properties.Resources.Close_32;
            this.btClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btClose.Location = new System.Drawing.Point(808, 721);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(124, 41);
            this.btClose.TabIndex = 16;
            this.btClose.Text = "Close";
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // toolStripMenuItemDetails
            // 
            this.toolStripMenuItemDetails.Image = global::MyDVLD_Project.Properties.Resources.PersonDetails_32;
            this.toolStripMenuItemDetails.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripMenuItemDetails.Name = "toolStripMenuItemDetails";
            this.toolStripMenuItemDetails.Size = new System.Drawing.Size(181, 24);
            this.toolStripMenuItemDetails.Text = "Users Details";
            this.toolStripMenuItemDetails.Click += new System.EventHandler(this.toolStripMenuItemDetails_Click);
            // 
            // toolStripMenuItemAdd
            // 
            this.toolStripMenuItemAdd.Image = global::MyDVLD_Project.Properties.Resources.Add_New_User_72;
            this.toolStripMenuItemAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripMenuItemAdd.Name = "toolStripMenuItemAdd";
            this.toolStripMenuItemAdd.Size = new System.Drawing.Size(181, 24);
            this.toolStripMenuItemAdd.Text = "Add New User";
            this.toolStripMenuItemAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolStripMenuItemAdd.Click += new System.EventHandler(this.toolStripMenuItemAdd_Click);
            // 
            // toolStripMenuItemedit
            // 
            this.toolStripMenuItemedit.Image = global::MyDVLD_Project.Properties.Resources.edit_32;
            this.toolStripMenuItemedit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripMenuItemedit.Name = "toolStripMenuItemedit";
            this.toolStripMenuItemedit.Size = new System.Drawing.Size(181, 24);
            this.toolStripMenuItemedit.Text = "Edit";
            this.toolStripMenuItemedit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolStripMenuItemedit.Click += new System.EventHandler(this.toolStripMenuItemedit_Click);
            // 
            // toolStripMenuItemDelete
            // 
            this.toolStripMenuItemDelete.Image = global::MyDVLD_Project.Properties.Resources.Delete_32;
            this.toolStripMenuItemDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripMenuItemDelete.Name = "toolStripMenuItemDelete";
            this.toolStripMenuItemDelete.Size = new System.Drawing.Size(181, 24);
            this.toolStripMenuItemDelete.Text = "Delete";
            this.toolStripMenuItemDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolStripMenuItemDelete.Click += new System.EventHandler(this.toolStripMenuItemDelete_Click);
            // 
            // toolStripMenuItempass
            // 
            this.toolStripMenuItempass.Image = global::MyDVLD_Project.Properties.Resources.Password_32;
            this.toolStripMenuItempass.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripMenuItempass.Name = "toolStripMenuItempass";
            this.toolStripMenuItempass.Size = new System.Drawing.Size(181, 24);
            this.toolStripMenuItempass.Text = "Change Password";
            this.toolStripMenuItempass.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolStripMenuItempass.Click += new System.EventHandler(this.toolStripMenuItempass_Click);
            // 
            // toolStripMenuItememail
            // 
            this.toolStripMenuItememail.Image = global::MyDVLD_Project.Properties.Resources.send_email_32;
            this.toolStripMenuItememail.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripMenuItememail.Name = "toolStripMenuItememail";
            this.toolStripMenuItememail.Size = new System.Drawing.Size(181, 24);
            this.toolStripMenuItememail.Text = "Send Email";
            this.toolStripMenuItememail.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // toolStripMenuItemcall
            // 
            this.toolStripMenuItemcall.Image = global::MyDVLD_Project.Properties.Resources.Phone_321;
            this.toolStripMenuItemcall.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripMenuItemcall.Name = "toolStripMenuItemcall";
            this.toolStripMenuItemcall.Size = new System.Drawing.Size(181, 24);
            this.toolStripMenuItemcall.Text = "Phone Call";
            this.toolStripMenuItemcall.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::MyDVLD_Project.Properties.Resources.Users_2_400;
            this.pictureBox1.Location = new System.Drawing.Point(350, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(194, 172);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // ManageUsersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(940, 767);
            this.Controls.Add(this.lbNumRecords);
            this.Controls.Add(this.lbRecords);
            this.Controls.Add(this.txbFilter);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.lbFilter);
            this.Controls.Add(this.dataGridViewAllUsers);
            this.Controls.Add(this.lbHeader);
            this.Controls.Add(this.pictureBox1);
            this.Name = "ManageUsersForm";
            this.Text = "ManageUsersForm";
            this.Load += new System.EventHandler(this.ManageUsersForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAllUsers)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
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
        private System.Windows.Forms.DataGridView dataGridViewAllUsers;
        private System.Windows.Forms.Label lbHeader;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemDetails;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAdd;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemedit;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemDelete;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItempass;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItememail;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemcall;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
    }
}