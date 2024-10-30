using DVLD_BusinessLayer;
using MyDVLD_Project.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace MyDVLD_Project
{
    public partial class CtrlApplicationBasicInfo : UserControl
    {


        private ClsApplicationsBusiness _Application;
        private ClsApplicationTypesBusiness _ApplicationTypes;
        private ClsUserBusiness _User;


        private int _ApplicationID;
        private int _ApplicationTypeID;

        public int ApplicationID
        {
            get { return _ApplicationID; }
        }

        public int ApplicationTypeID
        {
            get { return _ApplicationTypeID; }
        }

        public ClsApplicationsBusiness Application
        {
            get { return _Application; }
        }

        public ClsApplicationTypesBusiness ApplicationType
        {
            get { return _ApplicationTypes; }
        }


        public CtrlApplicationBasicInfo()
        {
            InitializeComponent();
        }

        public void CheckApplicationStatus()
        {
            switch (_Application.ApplicationStatus)
            {
                case ClsApplicationsBusiness.enApplicationStatus.New:
                    lblStatus.Text = "New";
                    break;
                case ClsApplicationsBusiness.enApplicationStatus.Cancelled:
                    lblStatus.Text = "Cancelled";
                    break;
                case ClsApplicationsBusiness.enApplicationStatus.Completed:
                    lblStatus.Text = "Completed";
                    break;

                default:
                    lblStatus.Text = "New";
                    break;

            }
        }


        public void CheckApplicationType()
        {
            _ApplicationTypeID = _Application.ApplicationTypeID;
            _ApplicationTypes = ClsApplicationTypesBusiness.Find(_Application.ApplicationTypeID);

            lblType.Text = _ApplicationTypes.ApplicationTypeTitle;
           
        }




        //ClsApplicationsBusiness.enApplicationType.NewDrivingLicense.ToString();

        private void _FillApplicationInfo()
        {
           
            CheckApplicationType();
            lblApplicationID.Text = _Application.ApplicationID.ToString();
            CheckApplicationStatus();
            lblFees.Text = _Application.PaidFees.ToString();
            lblApplicant.Text = _Application.ApplicantFullName.ToString();
            lblDate.Text = _Application.ApplicationDate.ToString();
            lblStatusDate.Text = _Application.LastStatusDate.ToString();

            _User = ClsUserBusiness.Find(_Application.CreatedByUserID);

            lblCreatedByUser.Text = _User.UserName;


           _ApplicationID = _Application.ApplicationID;

        }


        public void ResetApplicationInfo()
        {

            _Application.ApplicationID = -1;
            lblApplicationID.Text = "[????]";
            lblStatus.Text = "[????]";
            lblFees.Text = "[????]";
            lblType.Text = "[????]";
            lblType.Text = "[????]";
            lblApplicant.Text = "[????]";
            lblDate.Text = "[????]";

            lblStatusDate.Text = "[????]";
            lblCreatedByUser.Text = "[????]";
           

        }



        public void LoadApplicationInfo(int ApplicationID)
        {
            _Application = ClsApplicationsBusiness.FindBaseApplication(ApplicationID);


            if (Application == null)
            {
                ResetApplicationInfo();
                MessageBox.Show("No application with application id = " + ApplicationID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;


            }

            _FillApplicationInfo();

        }



        private void llViewPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
             ShowPersonInfoForm frm = new ShowPersonInfoForm (_Application.ApplicantPersonID);
            frm.ShowDialog();

            //Resresh
            LoadApplicationInfo(ApplicationID);

        }
    }
}
