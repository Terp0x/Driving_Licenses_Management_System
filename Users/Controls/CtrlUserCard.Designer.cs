namespace MyDVLD_Project
{
    partial class CtrlUserCard
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ctrlPersonCard1 = new MyDVLD_Project.CtrlPersonCard();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbIsActive = new System.Windows.Forms.Label();
            this.lbUserName = new System.Windows.Forms.Label();
            this.lbActive = new System.Windows.Forms.Label();
            this.lbUser = new System.Windows.Forms.Label();
            this.lbUserIDValue = new System.Windows.Forms.Label();
            this.lbUserId = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ctrlPersonCard1
            // 
            this.ctrlPersonCard1.Location = new System.Drawing.Point(12, 13);
            this.ctrlPersonCard1.Name = "ctrlPersonCard1";
            this.ctrlPersonCard1.Size = new System.Drawing.Size(847, 423);
            this.ctrlPersonCard1.TabIndex = 0;
           
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbIsActive);
            this.groupBox1.Controls.Add(this.lbUserName);
            this.groupBox1.Controls.Add(this.lbActive);
            this.groupBox1.Controls.Add(this.lbUser);
            this.groupBox1.Controls.Add(this.lbUserIDValue);
            this.groupBox1.Controls.Add(this.lbUserId);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 456);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(847, 112);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Login Information";
            // 
            // lbIsActive
            // 
            this.lbIsActive.AutoSize = true;
            this.lbIsActive.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbIsActive.Location = new System.Drawing.Point(708, 57);
            this.lbIsActive.Name = "lbIsActive";
            this.lbIsActive.Size = new System.Drawing.Size(33, 19);
            this.lbIsActive.TabIndex = 5;
            this.lbIsActive.Text = "???";
            // 
            // lbUserName
            // 
            this.lbUserName.AutoSize = true;
            this.lbUserName.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUserName.Location = new System.Drawing.Point(419, 57);
            this.lbUserName.Name = "lbUserName";
            this.lbUserName.Size = new System.Drawing.Size(33, 19);
            this.lbUserName.TabIndex = 4;
            this.lbUserName.Text = "???";
            // 
            // lbActive
            // 
            this.lbActive.AutoSize = true;
            this.lbActive.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbActive.Location = new System.Drawing.Point(616, 57);
            this.lbActive.Name = "lbActive";
            this.lbActive.Size = new System.Drawing.Size(76, 19);
            this.lbActive.TabIndex = 3;
            this.lbActive.Text = "Is Active:";
            // 
            // lbUser
            // 
            this.lbUser.AutoSize = true;
            this.lbUser.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUser.Location = new System.Drawing.Point(305, 57);
            this.lbUser.Name = "lbUser";
            this.lbUser.Size = new System.Drawing.Size(93, 19);
            this.lbUser.TabIndex = 2;
            this.lbUser.Text = "User Name:";
            // 
            // lbUserIDValue
            // 
            this.lbUserIDValue.AutoSize = true;
            this.lbUserIDValue.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUserIDValue.Location = new System.Drawing.Point(182, 57);
            this.lbUserIDValue.Name = "lbUserIDValue";
            this.lbUserIDValue.Size = new System.Drawing.Size(33, 19);
            this.lbUserIDValue.TabIndex = 1;
            this.lbUserIDValue.Text = "???";
            // 
            // lbUserId
            // 
            this.lbUserId.AutoSize = true;
            this.lbUserId.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUserId.Location = new System.Drawing.Point(77, 57);
            this.lbUserId.Name = "lbUserId";
            this.lbUserId.Size = new System.Drawing.Size(69, 19);
            this.lbUserId.TabIndex = 0;
            this.lbUserId.Text = "User ID:";
            // 
            // CtrlUserCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ctrlPersonCard1);
            this.Name = "CtrlUserCard";
            this.Size = new System.Drawing.Size(891, 587);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private CtrlPersonCard ctrlPersonCard1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbIsActive;
        private System.Windows.Forms.Label lbUserName;
        private System.Windows.Forms.Label lbActive;
        private System.Windows.Forms.Label lbUser;
        private System.Windows.Forms.Label lbUserIDValue;
        private System.Windows.Forms.Label lbUserId;
    }
}
