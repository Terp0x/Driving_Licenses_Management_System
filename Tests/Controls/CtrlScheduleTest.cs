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
using static DVLD_BusinessLayer.ClsTestTypesBusiness;

namespace MyDVLD_Project
{
    public partial class CtrlScheduleTest : UserControl
    {

        private ClsApplicationsBusiness _Application;
        private ClsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;
        private ClsLicenseClasses _class;
        private ClsTests _Test;
        private ClsTestAppointments _TestAppointments;
        private ClsTestTypesBusiness _TestTypes;

        private int _ApplicationID;
        private int _LocalDrivingLicenseApplicationID;
        private int _TestID;
        private int _TestAppointmentsID;
        public  int _TestTypeID;
        private bool _IsRetake;

        private int _TestTypeFees;
        public int TestAppointmentID
        {
            get { return _TestAppointmentsID; }
        }

        public int LocalDrivingLicenseApplicationID
        {
            get { return _LocalDrivingLicenseApplicationID; }
        }

        public int TestID
        {
            get { return _TestID; }
        }

        public ClsTestAppointments TestAppointments
        {
            get { return _TestAppointments; }
        }

        public ClsTests Tests
        {
            get { return _Test; }
        }
        
        public ClsLocalDrivingLicenseApplication LocalDrivingLicenseApplication
        {
            get { return _LocalDrivingLicenseApplication; }
        }

    
        public CtrlScheduleTest()
        {
            InitializeComponent();
        }


        private void _LoadTestTypeImageAndTitle()
        {
            switch (_TestTypeID)
            {

                case 1:
                    {
                        _TestTypeFees = 10;
                        gbTestType.Text = "Vision Test";
                        pbTestTypeImage.Image = Resources.Vision_512;
                        break;
                    }

                case 2:
                    {
                        _TestTypeFees = 20;
                        gbTestType.Text = "Written Test";
                        pbTestTypeImage.Image = Resources.Written_Test_512;
                        break;
                    }
                case 3:
                    {
                        _TestTypeFees = 30;
                        gbTestType.Text = "Street Test";
                        pbTestTypeImage.Image = Resources.driving_test_512;
                        break;
                    }
            }
        }


        public void FillBasicScheduleInfo(int LocalDrivingLicenseApplicationID, int TestTypeID, int TestAppointmentsID, bool IsRetake)
        {

            _TestTypeID = TestTypeID;
            _TestAppointmentsID = TestAppointmentsID;
            _IsRetake = IsRetake;
            _LoadTestTypeImageAndTitle();

            //Get local driving data
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            _LocalDrivingLicenseApplication = ClsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(LocalDrivingLicenseApplicationID);

            //Get class data
            _class = ClsLicenseClasses.Find(_LocalDrivingLicenseApplication.LicenseClassID);

            //Get application data
            _Application = ClsApplicationsBusiness.FindBaseApplication(_LocalDrivingLicenseApplication.ApplicationID);
            _ApplicationID = _Application.ApplicationID;

            //Get Test type data
            _TestTypes = ClsTestTypesBusiness.Find(TestTypeID);
            lblFees.Text = _TestTypes.TestTypeFees.ToString();

            lblLocalDrivingLicenseAppID.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
            lblDrivingClass.Text = _class.ClassName;
            lblFullName.Text = _Application.ApplicantFullName;
            lblTrial.Text = "0";

            dtpTestDate.MinDate = DateTime.Now;
            dtpTestDate.Text = DateTime.Now.AddDays(1).ToString();

            if ((_TestAppointmentsID != -1) && IsRetake == false)
            {
                if (_IsTestAppointmentLockedTrue(_TestAppointmentsID))
                {
                    dtpTestDate.Enabled = false;
                    btSave.Enabled = false;
                }
            }

            if (IsRetake == false)
                gbRetakeTestInfo.Enabled = false;
            else
            {
                lblTitle.Text = "Schedule Retake Test";
                gbRetakeTestInfo.Enabled = true;
            }
        }


        public void FillRetakeTestInfo()
        {
                     
            //fill the data
            lblRetakeAppFees.Text = "5";
            lblTotalFees.Text = (_TestTypeFees + 5).ToString();
           

        }

        private bool _IsTestAppointmentLockedTrue(int TestAppointmentsID)
        {
            _TestAppointments = ClsTestAppointments.Find(TestAppointmentsID);

            if (_TestAppointments.IsLocked == true)
                return true;

            return false;
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            //application is already saved and a local driving 
            //so you do not have to save them again

            if (_TestAppointmentsID == -1)
            {
                //it means that we are in the add new mode

                // Initialize _TestAppointments *******
                _TestAppointments = new ClsTestAppointments();


                // just wo need to save test appointment data
                _TestAppointments.TestTypeID = _TestTypeID;
                _TestAppointments.LocalDrivingLicenseApplicationID = _LocalDrivingLicenseApplicationID;
                _TestAppointments.AppointmentDate = dtpTestDate.Value;
                _TestAppointments.PaidFees = (float)(_TestTypes.TestTypeFees);
                _TestAppointments.CreatedByUserID = _Application.CreatedByUserID;
                _TestAppointments.IsLocked = false;
                _TestAppointments.RetakeTestApplicationID = -1;


                 if (_TestAppointments.Save())
                    MessageBox.Show("Data Saved Successfully.");
                else
                    MessageBox.Show("Error: Data Is not Saved Successfully.");

            }
            else
            {

                //if we in the retake , we will give the RetakeTestApplicationID application id number + 1
                if (_IsRetake == true)
                {

                    if (ClsTestAppointments.IsTestAppointmentUpdatedRetake(_TestAppointmentsID, _Application.ApplicationID ))
                    {
                        if (ClsTestAppointments.IsTestAppointmentUpdatedIsLocked(_TestAppointmentsID, false))
                        {
                            lblRetakeTestAppID.Text = (_Application.ApplicationID).ToString();
                            MessageBox.Show("Retake Test Scheduled Successfully.");
                        }
                    }
                    else
                        MessageBox.Show("Error: Failed to Schedule Retake Test .");
                }
                else
                {
                    //if not -1 and Is locked is false it means we are in the update mode
                    //only user can update the date only

                    if (ClsTestAppointments.IsTestAppointmentUpdatedDate(_TestAppointmentsID, dtpTestDate.Value))
                        MessageBox.Show("Data Updated Successfully.");
                    else
                        MessageBox.Show("Error: Data Is not Updated Successfully.");

                }

            }



        }

    }
}
