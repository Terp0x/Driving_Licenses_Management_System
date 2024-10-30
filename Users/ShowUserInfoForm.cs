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
    public partial class ShowUserInfoForm : Form
    {

        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;

        int _UserID;
      
        ClsUserBusiness _User;



        public ShowUserInfoForm(int UserID)
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

            _User = ClsUserBusiness.Find(_UserID);

            ctrlPersonCard1.LoadPersonInfo(_User.PersonID);


             lbUserIDValue.Text = _User.UserID.ToString();
             lbUserName.Text = _User.UserName;
           

            if (_User.IsActive)
                lbIsActive.Text = "true";
            else
                lbIsActive.Text = "false";


        }


        private void ShowPersonInfoForm_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ctrlPersonCard1_Load(object sender, EventArgs e)
        {

        }
    }
}
