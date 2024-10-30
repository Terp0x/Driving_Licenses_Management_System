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
    public partial class CtrlDrivingLicenseInfo : UserControl
    {


        private int _LocalDrivingLicenseApplicationID;
        private int _ApplicationID;
        private int _PersonID;
        private int _DriverID;
        private int _LicenseID;
        private int _ClassID;

        ClsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;
        ClsApplicationsBusiness _Application;
        ClsPeopleBusiness _People;
        ClsDrivers _Driver;
        ClsLicenses _License;
        ClsLicenseClasses _LicenseClasses;
        

        public CtrlDrivingLicenseInfo()
        {
            InitializeComponent();
        }

        
        private void _FillDrivingLicenseInfo(int LocalDrivingLicenseApplicationID)
        {

            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            _LocalDrivingLicenseApplication = ClsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(_LocalDrivingLicenseApplicationID);
            _Application = ClsApplicationsBusiness.FindBaseApplication(_LocalDrivingLicenseApplication.ApplicationID);
            _LicenseClasses = ClsLicenseClasses.Find(_LocalDrivingLicenseApplication.LicenseClassID);
            _License = ClsLicenses.FindByApplicationID(_LocalDrivingLicenseApplication.ApplicationID);
            _People = ClsPeopleBusiness.Find(_Application.ApplicantPersonID);
            _Driver = ClsDrivers.FindByPersonID(_Application.ApplicantPersonID);

            lblClass.Text = _LicenseClasses.ClassName;
            lblFullName.Text = _Application.ApplicantFullName;
            lblLicenseID.Text = _License.LicenseID.ToString();
            lblNationalNo.Text = _People.NationalNo;

            if (_People.Gendor == 0)
                lblGendor.Text = "Male";
            else
                lblGendor.Text = "Female";

            lblIssueDate.Text = _License.IssueDate.ToString();
            _IssueReasons();

            if (_License.Notes == "")
               lblNotes.Text = "No Notes";

            if (_License.IsActive == true)
                lblIsActive.Text = "Yes";
            else
                lblIsActive.Text = "Nop";

            pbPersonImage.ImageLocation = _People.ImagePath;
            lblDateOfBirth.Text = _People.DateOfBirth.ToString();
            lblDriverID.Text = _Driver.DriverID.ToString();
            lblExpirationDate.Text = _License.ExpirationDate.ToString();
            lblIsDetained.Text = "Nop"; 


        }

       
        private void _IssueReasons()
        {

            switch(_License.IssueReason)
            {
                case 1:
                    {
                        lblIssueReason.Text = "FirstTime";
                        break;
                    }
                case 2:
                    {
                        lblIssueReason.Text = "Renew";
                        break;
                    }
                case 3:
                    {
                        lblIssueReason.Text = "Replacement for Damaged";
                        break;
                    }
                case 4:
                    {
                        lblIssueReason.Text = "Replacement for Lost";
                        break;
                    }
              

            }
        }


        public void LoadLicenseData(int LocalDrivingLicenseApplicationID)
        {
            _FillDrivingLicenseInfo(LocalDrivingLicenseApplicationID);
        }

    }
}
