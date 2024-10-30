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
    public partial class CtrlDrivingLicenseApplicationsInfo : UserControl
    {

        private ClsApplicationsBusiness _Application;
        private ClsApplicationTypesBusiness _ApplicationTypes;
        private ClsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;
        ClsLicenseClasses _class;
        ClsTestTypesBusiness _TestTypes;
        ClsTests _Test;
      
        private int _ApplicationID;
        private int _ApplicationTypeID;
        private int _LocalDrivingLicenseApplicationID;
        private int _TestTypeID;
     
        public int ApplicationID
        {
            get { return _ApplicationID; }
        }

        public int ApplicationTypeID
        {
            get { return _ApplicationTypeID; }
        }


        public int LocalDrivingLicenseApplicationID
        {
            get { return _LocalDrivingLicenseApplicationID; }
        }

        public ClsApplicationsBusiness Application
        {
            get { return _Application; }
        }

        public ClsApplicationTypesBusiness ApplicationType
        {
            get { return _ApplicationTypes; }
        }


        public ClsLocalDrivingLicenseApplication LocalDrivingLicenseApplication
        {
            get { return _LocalDrivingLicenseApplication; }
        }

        public CtrlDrivingLicenseApplicationsInfo()
        {
            InitializeComponent();
        }

      
        private bool _IsPersonHasAPreviousLicenses(int LocalDrivingLicenseApplicationID)
        {
            ClsLicenses _License;
            _LocalDrivingLicenseApplication = ClsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(LocalDrivingLicenseApplicationID);

            _License = ClsLicenses.FindByApplicationID(_LocalDrivingLicenseApplication.ApplicationID);

            if (_License != null)
                return true;

            return false;
        }

        private void _FillBasicApplicationsInfo(int ApplicationID)
        {
           
            _LocalDrivingLicenseApplication = ClsLocalDrivingLicenseApplication.FindByAppLicenseID(ApplicationID);
            _class = ClsLicenseClasses.Find(_LocalDrivingLicenseApplication.LicenseClassID);


            ctrlApplicationBasicInfo1.LoadApplicationInfo(ApplicationID);
            
            _ApplicationTypeID = ctrlApplicationBasicInfo1.ApplicationTypeID;

            //fill all IDs
            _ApplicationID = ApplicationID;
            _LocalDrivingLicenseApplicationID = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID;

        }

     
        public void _FillDrivingLicenseApplicationsInfo()
        {

           // int counter = _countTestIsAppointmentPassed();
         

            _ApplicationTypes = ctrlApplicationBasicInfo1.ApplicationType;
            lblLocalDrivingLicenseApplicationID.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
            lblAppliedFor.Text = _class.ClassName;
            lblPassedTests.Text =  "0/3";

        }

        public void LoadApplicationVisionTestData(int ApplicationID, int TestTypeID)
        {
            _ApplicationID = ApplicationID;
            _TestTypeID = TestTypeID;
            


            _FillBasicApplicationsInfo(ApplicationID);
            _FillDrivingLicenseApplicationsInfo();

        }

        public void LoadApplicationControlData(int ApplicationID)
        {
            _ApplicationID = ApplicationID;
          
            _FillBasicApplicationsInfo(ApplicationID);
            _FillDrivingLicenseApplicationsInfo();

        }


        private void llShowLicenceInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //-------------------------------------
            if (_IsPersonHasAPreviousLicenses(_LocalDrivingLicenseApplicationID))
            {
                LicenseInfoForm frm = new LicenseInfoForm(_LocalDrivingLicenseApplicationID);
                frm.ShowDialog();
            }else
                MessageBox.Show("Sorry, You don't have any license .", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

    }
}
