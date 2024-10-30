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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace MyDVLD_Project
{
    public partial class ChangePasswordForm : Form
    {

        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;

        int _UserID;
      
        ClsUserBusiness _User;


        public ChangePasswordForm(int UserID)
        {
            InitializeComponent();


            _UserID = UserID;

            if (_UserID == -1)

                _Mode = enMode.AddNew;
            else
                _Mode = enMode.Update;
        }


        private void _LoadData()
        {

            //fill data for control user
            ctrlUserCard1.LoadUserInfo(_UserID);

            

        }


        private bool _IsCurrentPassTrue()
        {
            //matched user comes from ctrl to user in this form 
            _User = ctrlUserCard1.User; 

            if (txbCurrentpass.Text == _User.Password.ToString())
                return true;
            else
                return false;
        }







        private void ChangePasswordForm_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void txbCurrentpass_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrEmpty(txbCurrentpass.Text))
            {
                e.Cancel = true;
                txbCurrentpass.Focus();
                errorProvider1.SetError(txbCurrentpass, "Current User is required");


            }
            else
            {
                if (!_IsCurrentPassTrue())
                {
                    e.Cancel = true;
                    txbCurrentpass.Focus();
                    errorProvider1.SetError(txbCurrentpass, "Current User is wrong");
                }
                else
                {
                    e.Cancel = false;
                    txbPass.Focus();
                    errorProvider1.SetError(txbCurrentpass, "");
                }
            }


        }

        private void txbPass_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txbPass.Text))
            {

                e.Cancel = true;
                txbPass.Focus();
                errorProvider1.SetError(txbPass, "Password is required");


            }
            else
            {

                e.Cancel = false;
                txbconfirm.Focus();
                errorProvider1.SetError(txbPass, "");


            }
        }

        private void txbconfirm_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrEmpty(txbconfirm.Text))
            {

                e.Cancel = true;
                txbconfirm.Focus();
                errorProvider1.SetError(txbconfirm, "Password is required");


            }
            else
            {
                if (txbconfirm.Text != txbPass.Text)
                {
                    e.Cancel = false;
                    txbPass.Focus();
                    errorProvider1.SetError(txbPass, "Passwords are not matched ");
                }
                else
                {

                    e.Cancel = false;
                    errorProvider1.SetError(txbconfirm, "");
                }

            }
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btSave_Click(object sender, EventArgs e)
        {

            //confirm changes
            _User.Password = txbconfirm.Text;

          



            if (_User.Save())
                MessageBox.Show("Data Saved Successfully.");
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.");



            _Mode = enMode.Update;
            lbHeader.Text = "Edit User ID = " + _User.UserID;
        }

    }
}
