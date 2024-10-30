using DVLD_BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;



namespace MyDVLD_Project
{
    public partial class LoginForm : Form
    {
        ClsUserBusiness _User;
        

        public LoginForm()
        {
            InitializeComponent();
        }


        private bool _ChickLoginInfo()
        {

            string UserName = txtUserName.Text;
            string Password = txtPassword.Text;

          
            if(_IsUserExists())
            {
                if(_IsPasswordTrue())
                {
                    if (_IsActiveTrue())
                        return true;
                    else
                        return false;
                }
                else
                {
                    MessageBox.Show("wrong user name or password!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            else
            {
                MessageBox.Show("wrong user name or password!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            return false;

        }


        private bool _IsUserExists()
        {

            string UserName = txtUserName.Text;
            string Password = txtPassword.Text;

           
            //Assign UserName
            _User = ClsUserBusiness.FindByUserName(UserName);

            if(_User != null)
            {
                ClsGlobal.CurrentUserName = UserName;
                return true;
            }
            return false;
        }


        private bool _IsPasswordTrue()
        {
           
            if(_User.Password == txtPassword.Text)
                   return true;

            return false;

        }

        private bool _IsActiveTrue()
        {
            if(_User.IsActive == true)
                return true;
            else
                MessageBox.Show("Your account is not activated, please contact your admin", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            
            return false;

        }


        private void btnLogin_Click(object sender, EventArgs e)
        {

            if(_ChickLoginInfo())
            {
                ClsGlobal.AssignCurrentUserData();

                MianForm frm = new MianForm();
                frm.ShowDialog();


            }


        }


        public void ClearLoginInfo()
        {
            txtUserName.Clear();
            txtPassword.Clear();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            ClearLoginInfo();

        }
    }
}
