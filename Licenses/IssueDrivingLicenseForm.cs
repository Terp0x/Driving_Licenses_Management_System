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
using static DVLD_BusinessLayer.ClsTestTypesBusiness;

namespace MyDVLD_Project
{
    public partial class IssueDrivingLicenseForm : Form
    {
        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;

        private int _LocalDrivingLicenseApplicationID;
        private int _ApplicationID;
        private int _PersonID;
        private int _DriverID;
        private int _LicenseID;


        ClsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;
        ClsApplicationsBusiness _Application;
        ClsPeopleBusiness _People;
        ClsDrivers _Driver;
        ClsLicenses _License;

        public IssueDrivingLicenseForm(int LocalDrivingLicenseApplicationID)
        {

            InitializeComponent();

            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
          

            if (LocalDrivingLicenseApplicationID == -1)

                _Mode = enMode.AddNew;
            else
                _Mode = enMode.Update;
        }



        private void _FillDrivingLicenseApplicationsInfo()
        {
            _LocalDrivingLicenseApplication = ClsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(_LocalDrivingLicenseApplicationID);

            _Application = ClsApplicationsBusiness.FindBaseApplication(_LocalDrivingLicenseApplication.ApplicationID);
            _ApplicationID = _Application.ApplicationID;

            ctrlDrivingLicenseApplicationsInfo1.LoadApplicationControlData(_Application.ApplicationID);


        }




        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void IssueDrivingLicenseForm_Load(object sender, EventArgs e)
        {
            _FillDrivingLicenseApplicationsInfo();
        }


        private void _CalculateFeesDate()
        {

            switch(_LocalDrivingLicenseApplication.LicenseClassID)
            {

                case 1:
                    {
                        _License.PaidFees = Convert.ToDecimal(15.00);
                        break;
                    }
                case 2:
                    {
                        _License.PaidFees = Convert.ToDecimal(30.00);
                        break;
                    }
                case 3:
                    {
                        _License.PaidFees = Convert.ToDecimal(20.00);
                        break;
                    }
                case 4:
                    {
                        _License.PaidFees = Convert.ToDecimal(200.00);
                        break;
                    }
                case 5:
                    {
                        _License.PaidFees = Convert.ToDecimal(50.00);
                        break;
                    }
                case 6:
                    {
                        _License.PaidFees = Convert.ToDecimal(250.00);
                        break;
                    }
                case 7:
                    {
                        _License.PaidFees = Convert.ToDecimal(300.00);
                        break;
                    }
                default:
                    {
                        _License.PaidFees = Convert.ToDecimal(50.00);
                        break;
                    }

            }
        }

        private void _CalculateExpirationDate()
        {

            switch (_LocalDrivingLicenseApplication.LicenseClassID)
            {

                case 1:
                case 2:
                    {
                        _License.ExpirationDate = DateTime.Now.AddYears(5);
                        break;
                    }
                case 3:
                case 4:
                case 5:
                case 6:
                case 7:
                    {
                        _License.ExpirationDate = DateTime.Now.AddYears(10);
                        break;
                    }
                default:
                    {
                        _License.ExpirationDate = DateTime.Now.AddYears(5);
                        break;
                    }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            //add  new driver and  then add new license
            _People = ClsPeopleBusiness.Find(_Application.ApplicantPersonID);

            //initial new driver
            _Driver = new ClsDrivers();

            _Driver.PersonID = _Application.ApplicantPersonID;
            _Driver.CreatedByUserID = _Application.CreatedByUserID;
            _Driver.CreatedDate = DateTime.Now;


            if(_Driver.Save())
            {

                //initial new license
                _License = new ClsLicenses();

                _License.ApplicationID = _Application.ApplicationID;
                _License.DriverID = _Driver.DriverID;
                _License.LicenseClass = _LocalDrivingLicenseApplication.LicenseClassID;
                _License.IssueDate = DateTime.Now;
                _CalculateExpirationDate();
                _License.Notes = txbNote.Text;
                _CalculateFeesDate();
                _License.IsActive = true;
                _License.IssueReason = 1;
                _License.CreatedByUserID = _Application.CreatedByUserID;

                if(_License.Save())
                    MessageBox.Show("license added successfully .", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Error : license not added successfully .", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

      
    }
}
