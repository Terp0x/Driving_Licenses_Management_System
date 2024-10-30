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
    public partial class LicenseInfoForm : Form
    {
        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;



        private int _LocalDrivingLicenseApplicationID;
        private int _ApplicationID;
       

        ClsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;
        ClsApplicationsBusiness _Application;


        public LicenseInfoForm(int LocalDrivingLicenseApplicationID)
        {

            InitializeComponent();

            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;


            if (LocalDrivingLicenseApplicationID == -1)

                _Mode = enMode.AddNew;
            else
                _Mode = enMode.Update;

        }


        private void _FillLicenseInfoData()
        {

            ctrlDrivingLicenseInfo1.LoadLicenseData(_LocalDrivingLicenseApplicationID);
        }



        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LicenseInfoForm_Load(object sender, EventArgs e)
        {
            _FillLicenseInfoData();
        }
    }
}
