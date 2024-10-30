using DVLD_BusinessLayer;
using MyDVLD_Project.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
 
namespace MyDVLD_Project
{
    public partial class TestAppointmentForm : Form
    {

        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;

        private int _TestAppointmentID;
        private int _ApplicationID;
        private int _LocalDrivingLicenseApplicationID;
        private int _TestTypeID;
        private int _TestAppointmentIDForRetakeTest;

        ClsTestAppointments _TestAppointment;
        ClsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;
        ClsApplicationsBusiness _Application;
        ClsTests _Test;
        ClsTestTypesBusiness.enTestTypes _testTypes = ClsTestTypesBusiness.enTestTypes.VisionTest;
        ClsTestAppointments _TestAppointments;

        public TestAppointmentForm(int LocalDrivingLicenseApplicationID, ClsTestTypesBusiness.enTestTypes testTypes)
        {
            InitializeComponent();


            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            _testTypes = testTypes;

            if (LocalDrivingLicenseApplicationID == -1)

                _Mode = enMode.AddNew;
            else
                _Mode = enMode.Update;
        }



        private void _LoadTestTypeImageAndTitle()
        {
            switch (_testTypes)
            {

                case ClsTestTypesBusiness.enTestTypes.VisionTest:
                    {
                        _TestTypeID = 1;
                        lbTitle.Text = "Vision Test Appointments";
                        this.Text = lbTitle.Text;
                        pictureBox1.Image = Resources.Vision_512;
                        break;
                    }

                case ClsTestTypesBusiness.enTestTypes.WrittenTest:
                    {
                        _TestTypeID = 2;
                        lbTitle.Text = "Written Test Appointments";
                        this.Text = lbTitle.Text;
                        pictureBox1.Image = Resources.Written_Test_512;
                        break;
                    }
                case ClsTestTypesBusiness.enTestTypes.StreetTest:
                    {
                        _TestTypeID = 3; 
                        lbTitle.Text = "Street Test Appointments";
                        this.Text = lbTitle.Text;
                        pictureBox1.Image = Resources.driving_test_512;
                        break;
                    }
            }
        }

        private void _RefreshAllAppointments()
        {
            // Set AutoGenerateColumns to false to prevent auto-creation of columns
            dataGridViewallappointments.AutoGenerateColumns = false;

            // Clear any existing columns
            dataGridViewallappointments.Columns.Clear();

            // Manually add columns with proper DataPropertyName

            DataGridViewTextBoxColumn TestAppointmentIDColumn = new DataGridViewTextBoxColumn();
            TestAppointmentIDColumn.HeaderText = "TestAppointmentID";
            TestAppointmentIDColumn.DataPropertyName = "TestAppointmentID";
            TestAppointmentIDColumn.Width = 200;

            DataGridViewTextBoxColumn AppointmentDateColumn = new DataGridViewTextBoxColumn();
            AppointmentDateColumn.HeaderText = "AppointmentDate";
            AppointmentDateColumn.DataPropertyName = "AppointmentDate";
            AppointmentDateColumn.Width = 250;

            DataGridViewTextBoxColumn PaidFeesColumn = new DataGridViewTextBoxColumn();
           PaidFeesColumn.HeaderText = "PaidFees";
           PaidFeesColumn.DataPropertyName = "PaidFees";  // Match the property in your data source
           PaidFeesColumn.Width = 200;

            DataGridViewTextBoxColumn IsLockedColumn = new DataGridViewTextBoxColumn();
           IsLockedColumn.HeaderText = "IsLocked";
           IsLockedColumn.DataPropertyName = "IsLocked";
           IsLockedColumn.Width = 200;


         

            // Add columns to the DataGridView
           
            dataGridViewallappointments.Columns.Add(TestAppointmentIDColumn);
            dataGridViewallappointments.Columns.Add(AppointmentDateColumn);
            dataGridViewallappointments.Columns.Add(PaidFeesColumn);
            dataGridViewallappointments.Columns.Add(IsLockedColumn);



            DataTable AppointmentTable = new DataTable();
            AppointmentTable = ClsTestAppointments.GetAllTestAppointmentsUpdatedPerTestID(_LocalDrivingLicenseApplicationID, _TestTypeID);

            dataGridViewallappointments.DataSource = AppointmentTable;


            _FillAllVisionTestData();
            //-------------------------
        }

        private bool _IsTestHasAnyPreviousAppointments()
        {

            if (dataGridViewallappointments.Rows.Count > 1)
                return true;


            return false;

        }

        private bool _IsTestAppointmentsIsLockedTrue()
        {
            DataTable AppointmentTable = new DataTable();
            AppointmentTable = ClsTestAppointments.GetAllTestAppointmentsUpdatedPerTestID(_LocalDrivingLicenseApplicationID, _TestTypeID);


          
                foreach (DataRow AppointmentRow in AppointmentTable.Rows)
                {

                    if ((bool)AppointmentRow["IsLocked"] == Convert.ToBoolean(1))
                    {
                        // it means he is taking the test, whatever the result is (fail or pass)
                        // after that, you need to check if they passed or failed
                        return true;
                    }
                }


            return false;
        }

        private bool _IsTestAppointmentsIsLockedFalse()
        {

            DataTable AppointmentTable = new DataTable();
            AppointmentTable = ClsTestAppointments.GetAllTestAppointmentsUpdatedPerTestID(_LocalDrivingLicenseApplicationID, _TestTypeID);

            foreach (DataRow AppointmentRow in AppointmentTable.Rows)
            {

                if ((bool)AppointmentRow["IsLocked"] == Convert.ToBoolean(0))
                {
                    // it means he is taking the test, whatever the result is (fail or pass)
                    // after that, you need to check if they passed or failed
                    return true;
                }
            }
                      
            return false;
        }

        private bool _IsTestIsAppointmentPassed()
        {
            int appointmentId = (int)dataGridViewallappointments.CurrentRow.Cells[0].Value;

            _Test = ClsTests.FindByTestAppointmentID(appointmentId);

            if (_Test == null)
                return false;

            DataTable TestsTable = new DataTable();
            TestsTable = ClsTests.GetAllTestsDataPerAppointmentID(appointmentId);

            foreach (DataRow TestsDataRow in TestsTable.Rows)
            {
                   _Test = ClsTests.Find((int)TestsDataRow["TestID"]);
                    
                    // Ensure _Test is not null before accessing TestResult
                    if (_Test != null && _Test.TestResult == Convert.ToBoolean(1))
                    {
                        return true;
                    }
                
            }
            return false;

        }

        private bool _IsTestIsAppointmentFail()
        {
            int appointmentId = (int)dataGridViewallappointments.CurrentRow.Cells[0].Value;

           
            DataTable TestsTable = new DataTable();
            TestsTable = ClsTests.GetAllTestsDataPerAppointmentID(appointmentId);


            foreach (DataRow TestsDataRow in TestsTable.Rows)
            {
                _Test = ClsTests.Find((int)TestsDataRow["TestID"]);

                // Ensure _Test is not null before accessing TestResult
                if (_Test != null && _Test.TestResult == Convert.ToBoolean(0))
                {
                    _TestAppointmentIDForRetakeTest = (int)TestsDataRow["TestAppointmentID"];
                    return true;
                }

            }
            return false;

        }

   
        private bool _IsPersonCanScheduleTest()
        {
            //has no any appointments yet
            if (!_IsTestHasAnyPreviousAppointments() )
                return true;

          
            return false;

        }

        private bool _IsPersonCanRetakeScheduleTest()
        {
           
            if (_IsTestIsAppointmentPassed())
                return false;

            if(_IsTestAppointmentsIsLockedFalse())
                return false;

            if (_IsTestAppointmentsIsLockedTrue() && _IsTestIsAppointmentFail())
                return true;
          

            return false;

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (_IsPersonCanScheduleTest())
            {

                ScheduleTestForm form = new ScheduleTestForm(_LocalDrivingLicenseApplicationID, _TestTypeID, -1);
                form.ShowDialog();

                _RefreshAllAppointments();


            }
            else if (_IsPersonCanRetakeScheduleTest())
            {
                ScheduleRetakeTestForm frm = new ScheduleRetakeTestForm(_LocalDrivingLicenseApplicationID, _TestTypeID, _TestAppointmentIDForRetakeTest, true);
                frm.ShowDialog();

                _RefreshAllAppointments();
            }
            else
            {
                MessageBox.Show("Sorry, You are already passed the test or have an active retake schedule appointment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

           
        }

        private void VisionTestForm_Load(object sender, EventArgs e)
        {
            _LoadTestTypeImageAndTitle();
            _RefreshAllAppointments();
          
        }


        private void _FillAllVisionTestData()
        {
           

            _LocalDrivingLicenseApplication = ClsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(_LocalDrivingLicenseApplicationID);
            _Application = ClsApplicationsBusiness.FindBaseApplication(_LocalDrivingLicenseApplication.ApplicationID);


            ctrlDrivingLicenseApplicationsInfo1.LoadApplicationVisionTestData(_Application.ApplicationID, _TestTypeID);

        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripMenuItemedit_Click(object sender, EventArgs e)
        {
            // Ensure the cell value is not null
            if (dataGridViewallappointments.Rows.Count > 1)
            {
                //finally you got the test appointment id 
                int TestAppointmentID = (int)dataGridViewallappointments.CurrentRow.Cells[0].Value;
                _TestAppointmentID = TestAppointmentID;

                ScheduleTestForm frm = new ScheduleTestForm(_LocalDrivingLicenseApplicationID, _TestTypeID, TestAppointmentID);
                frm.ShowDialog();

                _RefreshAllAppointments();
            }
        }


        private bool _IsTestAppointmentLockedTrue(int TestAppointmentsID)
        {
           
             _TestAppointments = ClsTestAppointments.Find(TestAppointmentsID);
            
             if (_TestAppointments.IsLocked == true)
                 return true;
            
             return false;
           

        }

        private bool _IsTestAppointmentIsPassed(int TestAppointmentsID)
        {
            _TestAppointments = ClsTestAppointments.Find(TestAppointmentsID);
            _Test = ClsTests.FindByTestAppointmentID(_TestAppointments.TestAppointmentID);

            if (_Test.TestResult == true)
                return true;

            return false;
        }

        private void toolStripMenuItemtaketest_Click(object sender, EventArgs e)
        {
            // Ensure the cell value is not null
            if (dataGridViewallappointments.Rows.Count > 1)
            {
                int TestAppointmentID = (int)dataGridViewallappointments.CurrentRow.Cells[0].Value;

                if (!_IsTestAppointmentLockedTrue(TestAppointmentID))
                {

                    TakeTestForm frm = new TakeTestForm(_LocalDrivingLicenseApplicationID, _TestTypeID, TestAppointmentID);
                    frm.ShowDialog();

                    _RefreshAllAppointments();

                }
                else
                    MessageBox.Show("Sorry, You are already taked the test ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

      
    }
}


