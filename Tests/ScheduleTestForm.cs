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
    public partial class ScheduleTestForm : Form
    {


        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;

        private int _TestAppointmentID;
        private int _ApplicationID;
        private int _LocalDrivingLicenseApplicationID;
        private int _TestTypeID;

        ClsTestAppointments _TestAppointment;
        ClsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;
        ClsApplicationsBusiness _Application;


        
        public ScheduleTestForm(int LocalDrivingLicenseApplicationID, int TestTypeID, int TestAppointmentID)
        {
            InitializeComponent();


            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            _TestTypeID = TestTypeID;
            _TestAppointmentID = TestAppointmentID;

            if (LocalDrivingLicenseApplicationID == -1)

                _Mode = enMode.AddNew;
            else
                _Mode = enMode.Update;
        }


        private void _FillCtrlScheduleTest()
        {

            ctrlScheduleTest1.FillBasicScheduleInfo(_LocalDrivingLicenseApplicationID, _TestTypeID, _TestAppointmentID, false);

            
        }




        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ScheduleTestForm_Load(object sender, EventArgs e)
        {
            _FillCtrlScheduleTest();
        }

       
    }
}
