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
    public partial class LicenseHistoryForm : Form
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
        ClsInternationalLicenseBus _InternationalLicense;

        public LicenseHistoryForm(int LocalDrivingLicenseApplicationID)
        {

            InitializeComponent();

            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;


            if (LocalDrivingLicenseApplicationID == -1)

                _Mode = enMode.AddNew;
            else
                _Mode = enMode.Update;
        }

        private void _SelectAllLicensesLocalOrInternational()
        {
                       

            switch(tabControl1.SelectedTab.Name)
            {
                case "tabPage1":
                    {
                        _RefreshAllLocalLicense();
                        break;
                    }
                case "tabPage2":
                    {
                       _RefreshAllInternationalLicense();
                        break;
                    }
                default:
                    _RefreshAllLocalLicense();
                    break;

            }
           

        }

        private void _RefreshAllLocalLicense()
            
        {
            // Set AutoGenerateColumns to false to prevent auto-creation of columns
            dataGridViewLocal.AutoGenerateColumns = false;

            // Clear any existing columns
            dataGridViewLocal.Columns.Clear();

            // Manually add columns with proper DataPropertyName

            DataGridViewTextBoxColumn LicenseIDColumn = new DataGridViewTextBoxColumn();
            LicenseIDColumn.HeaderText = "LicenseID";
            LicenseIDColumn.DataPropertyName = "LicenseID";

            DataGridViewTextBoxColumn ApplicationIDColumn = new DataGridViewTextBoxColumn();
            ApplicationIDColumn.HeaderText = "ApplicationID";
            ApplicationIDColumn.DataPropertyName = "ApplicationID";


            DataGridViewTextBoxColumn ClassNameColumn = new DataGridViewTextBoxColumn();
            ClassNameColumn.HeaderText = "ClassName";
            ClassNameColumn.DataPropertyName = "ClassName";
            ClassNameColumn.Width = 300;


            DataGridViewTextBoxColumn IssueDateColumn = new DataGridViewTextBoxColumn();
            IssueDateColumn.HeaderText = "IssueDate";
            IssueDateColumn.DataPropertyName = "IssueDate";  // Match the property in your data source
            IssueDateColumn.Width = 200;



            DataGridViewTextBoxColumn ExpirationDateColumn = new DataGridViewTextBoxColumn();
            ExpirationDateColumn.HeaderText = "ExpirationDate";
            ExpirationDateColumn.DataPropertyName = "ExpirationDate";
            ExpirationDateColumn.Width = 200;

            DataGridViewTextBoxColumn IsActiveColumn = new DataGridViewTextBoxColumn();
            IsActiveColumn.HeaderText = "IsActive";
            IsActiveColumn.DataPropertyName = "IsActive";
            IsActiveColumn.Width = 150;



            // Add columns to the DataGridView
            dataGridViewLocal.Columns.Add(LicenseIDColumn);
            dataGridViewLocal.Columns.Add(ApplicationIDColumn);
            dataGridViewLocal.Columns.Add(ClassNameColumn);
            dataGridViewLocal.Columns.Add(IssueDateColumn);
            dataGridViewLocal.Columns.Add(ExpirationDateColumn);
            dataGridViewLocal.Columns.Add(IsActiveColumn);

            DataTable LicenseTable = new DataTable();
            LicenseTable = ClsLicenses.GetAllLicenseHistoryData(_Application.ApplicantPersonID);

            dataGridViewLocal.DataSource = LicenseTable;
                      
            lbNumRecords.Text = LicenseTable.Rows.Count.ToString();

        }

        private void _RefreshAllInternationalLicense()

        {
            // Set AutoGenerateColumns to false to prevent auto-creation of columns
            dataGridViewInternational.AutoGenerateColumns = false;

            // Clear any existing columns
            dataGridViewInternational.Columns.Clear();

            // Manually add columns with proper DataPropertyName

            DataGridViewTextBoxColumn InternationalLicenseIDColumn = new DataGridViewTextBoxColumn();
            InternationalLicenseIDColumn.HeaderText = "InternationalLicenseID";
            InternationalLicenseIDColumn.DataPropertyName = "InternationalLicenseID";
            InternationalLicenseIDColumn.Width = 200;

            DataGridViewTextBoxColumn ApplicationIDColumn = new DataGridViewTextBoxColumn();
            ApplicationIDColumn.HeaderText = "ApplicationID";
            ApplicationIDColumn.DataPropertyName = "ApplicationID";
            ApplicationIDColumn.Width = 150;

            DataGridViewTextBoxColumn IssuedUsingLocalLicenseIDColumn = new DataGridViewTextBoxColumn();
            IssuedUsingLocalLicenseIDColumn.HeaderText = "IssuedUsingLocalLicenseID";
            IssuedUsingLocalLicenseIDColumn.DataPropertyName = "IssuedUsingLocalLicenseID";  
            IssuedUsingLocalLicenseIDColumn.Width = 150;

            DataGridViewTextBoxColumn IssueDateColumn = new DataGridViewTextBoxColumn();
            IssueDateColumn.HeaderText = "IssueDate";
            IssueDateColumn.DataPropertyName = "IssueDate";
            IssueDateColumn.Width = 200;

            DataGridViewTextBoxColumn ExpirationDateColumn = new DataGridViewTextBoxColumn();
            ExpirationDateColumn.HeaderText = "ExpirationDate";
            ExpirationDateColumn.DataPropertyName = "ExpirationDate";
            ExpirationDateColumn.Width = 200;

            DataGridViewTextBoxColumn IsActiveColumn = new DataGridViewTextBoxColumn();
            IsActiveColumn.HeaderText = "IsActive";
            IsActiveColumn.DataPropertyName = "IsActive";
            IsActiveColumn.Width = 150;

       

            // Add columns to the DataGridView
            dataGridViewInternational.Columns.Add(InternationalLicenseIDColumn);
            dataGridViewInternational.Columns.Add(ApplicationIDColumn);
            dataGridViewInternational.Columns.Add(IssuedUsingLocalLicenseIDColumn);
            dataGridViewInternational.Columns.Add(IssueDateColumn);
            dataGridViewInternational.Columns.Add(ExpirationDateColumn);
            dataGridViewInternational.Columns.Add(IsActiveColumn);
           

            DataTable LicenseTable = new DataTable();

            LicenseTable = _IsDriverHasAInternationalLicense(LicenseTable);
            dataGridViewInternational.DataSource = LicenseTable;


            lbNumRecords.Text = LicenseTable.Rows.Count.ToString();

        }

        private DataTable _IsDriverHasAInternationalLicense(DataTable DriverTable)
        {
            DataTable LicenseTable = new DataTable();
            DataTable TempTable = new DataTable();

            LicenseTable = ClsDrivers.GetAllDriversDataPerPerson(_Application.ApplicantPersonID);

            foreach(DataRow DriverRow in LicenseTable.Rows) 
            {
                if(LicenseTable != null)
                {
                    TempTable = ClsInternationalLicenseBus.GetDriverInternationalLicenses((int)DriverRow["DriverID"]);
                    if (TempTable.Rows.Count > 0)
                          DriverTable = TempTable;
                         
                }
            
            }

            return DriverTable;
        }

        private void _FillControlData()
        {
            _LocalDrivingLicenseApplication = ClsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(_LocalDrivingLicenseApplicationID);
            _Application = ClsApplicationsBusiness.FindBaseApplication(_LocalDrivingLicenseApplication.ApplicationID);

            ctrlPersonCardWithFilter1.LoadPersonData(_Application.ApplicantPersonID);
        }



        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LicenseHistoryForm_Load(object sender, EventArgs e)
        {
            _FillControlData();
            _SelectAllLicensesLocalOrInternational();
        }

        private void btClose_Click_1(object sender, EventArgs e)
        {
            this.Close();  
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            _SelectAllLicensesLocalOrInternational();
        }
    }
}
