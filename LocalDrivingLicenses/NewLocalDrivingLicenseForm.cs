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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace MyDVLD_Project
{
    public partial class NewLocalDrivingLicenseForm : Form
    {

        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;

        int _LocalDrivingLicenseApplicationID;
        int _UserID;
        ClsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;

        ClsPeopleBusiness _Person;
        ClsUserBusiness _User;
        ClsLicenseClasses _LicenseClasses;
        ClsApplicationsBusiness _Application;

        ClsApplicationsBusiness _previousApplication;
        ClsLocalDrivingLicenseApplication _previousLocalDrivingLicenseApplication;
        public NewLocalDrivingLicenseForm(int LocalDrivingLicenseApplicationID)
        {
            InitializeComponent();


            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;

            if (LocalDrivingLicenseApplicationID == -1)

                _Mode = enMode.AddNew;
            else
                _Mode = enMode.Update;

        }


        private bool _IsApplicationHasTheSameClass()
        {

            _previousApplication = ClsApplicationsBusiness.FindBaseApplicationPersonID(ctrlPersonCardWithFilter1.PersonId);
           
            if (_previousApplication == null)
            {   
                //it means the person has no previous applications 
                return false;
            }

            _previousLocalDrivingLicenseApplication = ClsLocalDrivingLicenseApplication.FindByAppLicenseID(_previousApplication.ApplicationID);
            if (_previousLocalDrivingLicenseApplication.LicenseClassID == comboBox1.SelectedIndex + 1)
            {
                return true;
            }

            return true;
        }

        private bool _IsApplicationStatusIsNew()
        {

            if (_previousApplication.ApplicationStatus == ClsApplicationsBusiness.enApplicationStatus.New)
            {
                return true;
            }
            return false;
        }

        private void _FillAllClassesNameData()
        {

            DataTable dataTable = ClsLicenseClasses.GetAllLicenseClassesName();

            comboBox1.DataSource = dataTable;

            comboBox1.DisplayMember = "ClassName";
            comboBox1.ValueMember = "ClassName";

            if (dataTable.Rows.Count == 0)
            {
                MessageBox.Show("No data found.");
            }

        }


        private void _LoadData()
        {
            _FillAllClassesNameData();
            comboBox1.SelectedIndex = 0;


            if (_Mode == enMode.AddNew)
            {
                lbHeader.Text = "New Driving License Application";
                _Application = new ClsApplicationsBusiness();
                _LocalDrivingLicenseApplication = new ClsLocalDrivingLicenseApplication();

                lbDateappli.Text = DateTime.Now.ToString();
                lbUsername.Text = ClsGlobal.CurrentUserName;
                lbFees.Text = "15";
                return;
            }

        

            _LocalDrivingLicenseApplication = ClsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(_LocalDrivingLicenseApplicationID);

            if (_LocalDrivingLicenseApplication == null)
            {
                MessageBox.Show("This form will be closed because No Local Driving License ApplicationID = " + _LocalDrivingLicenseApplication.ApplicationID);


                return;
            }



            // fill the person data

            _Application = ClsApplicationsBusiness.FindBaseApplication(_LocalDrivingLicenseApplication.ApplicationID);
            _UserID = _Application.CreatedByUserID;
            _User = ClsUserBusiness.Find(_UserID);
            ctrlPersonCardWithFilter1.LoadPersonData(_Application.ApplicantPersonID);

            //fill user data


            lbappId.Text = _Application.ApplicationID.ToString();
            lbDateappli.Text = _Application.ApplicationDate.ToString();
            lbUsername.Text = _User.UserName;
            lbFees.Text = "15";
           
         
            //this will select the country in the combobox.
            comboBox1.SelectedIndex = comboBox1.FindString(ClsLicenseClasses.Find(_LocalDrivingLicenseApplication.LicenseClassID).ClassName);


        }

        private bool _CheckPersonClass()
        {
            if (_IsApplicationHasTheSameClass())
            {
                if (_IsApplicationStatusIsNew())
                    return true;
            }

            return false;
        }


        private void btSave_Click(object sender, EventArgs e)
        {

            if (_Mode == enMode.Update)
            {
                MessageBox.Show("Sorry: You Can not update data.");
            }

            //Fill application data
            _Application.ApplicantPersonID = ctrlPersonCardWithFilter1.PersonId;
            _Application.ApplicationDate = DateTime.Now;
            _Application.ApplicationTypeID = 1;
            _Application.ApplicationStatus = ClsApplicationsBusiness.enApplicationStatus.New;
            _Application.LastStatusDate = DateTime.Now;
            _Application.PaidFees = 15;
            _Application.CreatedByUserID = ClsGlobal.UserID;

            if (!_CheckPersonClass())
            {
                if (_Application.Save())

                {

                    //fill Local Driving License Application  after save a application 
                    _LocalDrivingLicenseApplication.LicenseClassID = comboBox1.SelectedIndex + 1;// because it stats from zero
                    _LocalDrivingLicenseApplication.ApplicationID = _Application.ApplicationID;  // now you have the application id


                    if (_LocalDrivingLicenseApplication.Save())
                        MessageBox.Show("Data Saved Successfully.");

                }
                else
                    MessageBox.Show("Error: Data Is not Saved Successfully.");
            }
            else
                MessageBox.Show("Error: You can't applicate to the same class , you have already one, choose another class .", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);




        }

        private void NewLocalDrivingLicenseForm_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void btNext_Click(object sender, EventArgs e)
        {

            tabControl1.SelectedTab = tabPage2;
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}
