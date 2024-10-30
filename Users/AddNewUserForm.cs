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

namespace MyDVLD_Project
{
    public partial class AddNewUserForm : Form
    {

        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;

        int _UserID;
        ClsUserBusiness _User;
        ClsPeopleBusiness _Person;

        public AddNewUserForm(int UserID)
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


            if (_Mode == enMode.AddNew)
            {
                lbHeader.Text = "Add New User";
                _User = new ClsUserBusiness();
                return;
            }

            // ****  I sent the person id not user id

            _User = ClsUserBusiness.Find(_UserID);

            if (_User == null)
            {
                MessageBox.Show("This form will be closed because No User with ID = " + _User.UserID);
               

                return;
            }



            // fill the person data
           


            _Person = ClsPeopleBusiness.Find(_User.PersonID);
            ctrlPersonCardWithFilter1.LoadPersonData(_Person.PersonID);

            //fill user data


            lbUserId.Text = _User.UserID.ToString();
            txbUser.Text = _User.UserName;
            txbPass.Text =  _User.Password;
            txbconfirm.Text = _User.Password;

            if (_User.IsActive == true)
                checkBox1.Checked = true;
            else
                checkBox1.Checked = false;


          

        }



        private void btNext_Click(object sender, EventArgs e)
        {

            //checking user is exist
            if (!_IsPersonHasUser())
            {
                tabControl1.SelectedTab = tabPage2;
            }
            else
            {
                MessageBox.Show("The person has already a user", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void AddNewUserForm_Load(object sender, EventArgs e)
        {
            _LoadData();
        }




        private bool _IsPersonHasUser()
        {

            //I use person id not user id , because there is no data sent to form when you add new user by button not 
            // mouse right click (context menu)


            //one for if you fill person data by find button and the second for edit  (context menu) 
            //and ctrlPersonCardWithFilter1.PersonId not quale to _User.personID , because if you go to
            //button you send only person id by ctl and if you go to edit you send user id 
            //
            if (ClsUserBusiness.IsUserExistsByPersonID(ctrlPersonCardWithFilter1.PersonId) || ClsUserBusiness.IsUserExists(_UserID))
            {
                //Does not have User
                return true;
            }

            return false;

        }






        private void btSave_Click(object sender, EventArgs e)
        {

            _User.PersonID = ctrlPersonCardWithFilter1.PersonId;
            _User.UserName = txbUser.Text;
            _User.Password = txbconfirm.Text;

             if(checkBox1.Checked)
                _User.IsActive = true;
             else
                _User.IsActive = false;


            if (_IsMatchedPassword())
            {

                if (_User.Save())
                    MessageBox.Show("Data Saved Successfully.");
                else
                    MessageBox.Show("Error: Data Is not Saved Successfully.");
            }else
            {
                MessageBox.Show("Error: Password are not matched.");
            }


            _Mode = enMode.Update;
            lbHeader.Text = "Edit User ID = " + _User.UserID;
            
        }

      
        private bool _IsMatchedPassword()
        {
            if (txbconfirm.Text != txbPass.Text)
                return false;
            else 
                return true;

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
                if (_IsMatchedPassword())
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

        private void txbUser_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txbUser.Text))
            {
                e.Cancel = true;
                txbUser.Focus();
                errorProvider1.SetError(txbUser, "User Name is required");


            }
            else
            {
                e.Cancel = false;
                txbPass.Focus();
                errorProvider1.SetError(txbUser, "");
            }


        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}
