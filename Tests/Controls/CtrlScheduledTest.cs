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

namespace MyDVLD_Project
{
    public partial class CtrlScheduledTest : UserControl
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
        public int _TestTypeID;

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


        public CtrlScheduledTest()
        {
            InitializeComponent();
        }


        private void _LoadTestTypeImageAndTitle()
        {
            switch (_TestTypeID)
            {

                case 1:
                    {
                        gbTestType.Text = "Vision Test";
                        pbTestTypeImage.Image = Resources.Vision_512;
                        break;
                    }

                case 2:
                    {
                        gbTestType.Text = "Written Test";
                        pbTestTypeImage.Image = Resources.Written_Test_512;
                        break;
                    }
                case 3:
                    {
                        gbTestType.Text = "Street Test";
                        pbTestTypeImage.Image = Resources.driving_test_512;
                        break;
                    }
            }
        }


        public void FillBasicScheduledInfo(int LocalDrivingLicenseApplicationID, int TestTypeID, int TestAppointmentsID)
        {

            _TestTypeID = TestTypeID;
            _TestAppointmentsID = TestAppointmentsID;
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

            //Get Test appointment data
            _TestAppointments = ClsTestAppointments.Find(_TestAppointmentsID);
            lblDate.Text = _TestAppointments.AppointmentDate.ToString();

          
        }

        private void btSave_Click(object sender, EventArgs e)
        {

            if (_TestAppointmentsID != -1)
            {
                //it means he in the update mode or ready to take test

                // Initialize _Test *******
                _Test = new ClsTests();

                _Test.TestAppointmentID = _TestAppointmentsID;

                if (radioButtonpass.Checked)
                    _Test.TestResult = true;
                else
                    _Test.TestResult = false;

                _Test.Notes = txbNotes.Text;
                _Test.CreatedByUserID = _Application.CreatedByUserID;


                if (_Test.Save())
                {
                    //change is locked to true
                    ClsTestAppointments.IsTestAppointmentUpdatedIsLocked(_TestAppointmentsID, true);
                    MessageBox.Show("Data Saved Successfully.");
                }
                else
                    MessageBox.Show("Error: Data Is not Saved Successfully.");
            }


        }



    }
}
