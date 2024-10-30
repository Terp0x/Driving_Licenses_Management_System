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
    public partial class CtrlUserCard : UserControl
    {

        private ClsUserBusiness _User;


        private int _UserId;


        public int UserId
        {
            get { return _UserId; }
        }

        public ClsUserBusiness User
        {
            get { return _User; }
        }



        public CtrlUserCard()
        {
            InitializeComponent();
        }



        public void LoadUserInfo(int UserID)
        {
            _User = ClsUserBusiness.Find(UserID);


            if (User == null)
            {
                ResetUserInfo();
                MessageBox.Show("No User with UserID = " + UserID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;


            }

            _FillUserInfo();
        }



        private void _FillUserInfo()
        {

            // Fill person card
            ctrlPersonCard1.LoadPersonInfo(User.PersonID);

            //fill User info

            lbUserIDValue.Text = User.UserID.ToString();
            lbUserName.Text = User.UserName;

            if(User.IsActive)
                 lbIsActive.Text = "true";
            else
                lbIsActive.Text = "false";

        }


        public void ResetUserInfo()
        {
            //Reset person card
            ctrlPersonCard1.ResetPersonInfo();

            //Reset user card
            lbUserIDValue.Text = "???";
            lbUserName.Text = "???";
            lbIsActive.Text = "???";    

        }

    }
}
