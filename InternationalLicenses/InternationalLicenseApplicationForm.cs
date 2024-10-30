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
using static System.Net.Mime.MediaTypeNames;

namespace MyDVLD_Project
{
    public partial class InternationalLicenseApplicationForm : Form
    {


        private int _LocalDrivingLicenseApplicationID;
        private int _ApplicationID;
        private int _LicenseID;

        ClsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;
        ClsApplicationsBusiness _Application;
        ClsLicenses _Licenses;

        public InternationalLicenseApplicationForm()
        {
            InitializeComponent();
        }


        private void _RefreshAllInternationals()
        {
            // Set AutoGenerateColumns to false to prevent auto-creation of columns
            dataGridViewAllInternationalApplications.AutoGenerateColumns = false;

            // Clear any existing columns
            dataGridViewAllInternationalApplications.Columns.Clear();

            // Manually add columns with proper DataPropertyName

            DataGridViewTextBoxColumn InternationalIDColumn = new DataGridViewTextBoxColumn();
            InternationalIDColumn.HeaderText = "InternationalLicenseID";
            InternationalIDColumn.DataPropertyName = "InternationalLicenseID";
            InternationalIDColumn.Width = 200;

            DataGridViewTextBoxColumn ApplicationIDColumn = new DataGridViewTextBoxColumn();
            ApplicationIDColumn.HeaderText = "ApplicationID";
            ApplicationIDColumn.DataPropertyName = "ApplicationID";


            DataGridViewTextBoxColumn DriverIDColumn = new DataGridViewTextBoxColumn();
            DriverIDColumn.HeaderText = "DriverID";
            DriverIDColumn.DataPropertyName = "DriverID";  // Match the property in your data source


            DataGridViewTextBoxColumn IssueLocalLicenseIDColumn = new DataGridViewTextBoxColumn();
            IssueLocalLicenseIDColumn.HeaderText = "L License ID";
            IssueLocalLicenseIDColumn.DataPropertyName = "IssuedUsingLocalLicenseID";
            IssueLocalLicenseIDColumn.Width = 200;

            DataGridViewTextBoxColumn IssueDateColumn = new DataGridViewTextBoxColumn();
            IssueDateColumn.HeaderText = "IssueDate";
            IssueDateColumn.DataPropertyName = "IssueDate";
            IssueDateColumn.Width = 250;

            DataGridViewTextBoxColumn ExpirationDateColumn = new DataGridViewTextBoxColumn();
            ExpirationDateColumn.HeaderText = "ExpirationDate";
            ExpirationDateColumn.DataPropertyName = "ExpirationDate";
            ExpirationDateColumn.Width = 250;

            DataGridViewTextBoxColumn IsActiveColumn = new DataGridViewTextBoxColumn();
            IsActiveColumn.HeaderText = "IsActive";
            IsActiveColumn.DataPropertyName = "IsActive";
            IsActiveColumn.Width = 150;



            // Add columns to the DataGridView
            dataGridViewAllInternationalApplications.Columns.Add(InternationalIDColumn);
            dataGridViewAllInternationalApplications.Columns.Add(ApplicationIDColumn);
            dataGridViewAllInternationalApplications.Columns.Add(DriverIDColumn);
            dataGridViewAllInternationalApplications.Columns.Add(IssueLocalLicenseIDColumn);
            dataGridViewAllInternationalApplications.Columns.Add(IssueDateColumn);
            dataGridViewAllInternationalApplications.Columns.Add(ExpirationDateColumn);
            dataGridViewAllInternationalApplications.Columns.Add(IsActiveColumn);



            DataTable LicenseTable = new DataTable();
            LicenseTable = ClsInternationalLicenseBus.GetAllInternationalLicenses();

            dataGridViewAllInternationalApplications.DataSource = LicenseTable;




            lbNumRecords.Text = LicenseTable.Rows.Count.ToString();
        }

        public void FilterAllInternationalLicenseData()
        {

            DataTable LicenseTable = new DataTable();

            LicenseTable = ClsInternationalLicenseBus.GetAllInternationalLicenses();

            DataView UserDataView = LicenseTable.DefaultView;

            // Now we need to filter all data records
            string FilterText = comboBox1.Text;
            int FilteredIntValue;
            string FilteredStringValue = txbFilter.Text.Trim().ToLower();


            // If no filter is selected or the text box is empty, show all data
            if (FilterText == "Noun" || string.IsNullOrWhiteSpace(FilteredStringValue))
            {

                dataGridViewAllInternationalApplications.DataSource = LicenseTable;
                return;

            }

            switch (FilterText)
            {
                case "InternationalLicenseID":
                case "ApplicationID":
                case "DriverID":
                case "IssuedUsingLocalLicenseID":

                    if (int.TryParse(txbFilter.Text, out FilteredIntValue))
                    {
                        // Use FilteredValue as part of the filter, no need for quotes around it as it's an integer
                        UserDataView.RowFilter = $"{FilterText} =  {FilteredIntValue}";

                        // Bind the filtered DataView to the DataGridView
                        dataGridViewAllInternationalApplications.DataSource = UserDataView;
                    }
                    else
                    {
                        MessageBox.Show("Please enter a valid number ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    break;


                case "IssueDate":
            
                    UserDataView.RowFilter = $"{FilterText} = IssueDate";
                    break;

                case "ExpirationDate":

                    UserDataView.RowFilter = $"{FilterText} = ExpirationDate";
                    break;
                 
                case "IsActive":

                    if (FilteredStringValue == "true" || FilteredStringValue == "false")
                    {
                        // Filter text fields
                        UserDataView.RowFilter = $"{FilterText} = '{FilteredStringValue}'";
                 
                    }
                    else
                    {
                        MessageBox.Show("Please enter a valid input (true/false)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    break;

                 default:
                 MessageBox.Show("Please select a valid filter option.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 return;
            }


            // Bind the filtered DataView to the DataGridView
            dataGridViewAllInternationalApplications.DataSource = UserDataView;

        }


        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void InternationalLicenseApplicationForm_Load(object sender, EventArgs e)
        {
            _RefreshAllInternationals();
        }

        private void txbFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {

                FilterAllInternationalLicenseData();
                dataGridViewAllInternationalApplications.Refresh();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InternationalLicenseForm frm = new InternationalLicenseForm();
            frm.ShowDialog();

            _RefreshAllInternationals();
        }

        private void toolStripMenuItemLicenseInfo_Click(object sender, EventArgs e)
        {
            int LicenseID = (int)dataGridViewAllInternationalApplications.CurrentRow.Cells[3].Value;
            _Licenses = ClsLicenses.Find(LicenseID);
            _Application = ClsApplicationsBusiness.FindBaseApplication(_Licenses.ApplicationID);
            _LocalDrivingLicenseApplication = ClsLocalDrivingLicenseApplication.FindByAppLicenseID(_Application.ApplicationID);
            _LocalDrivingLicenseApplicationID = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID;


            LicenseInfoForm frm = new LicenseInfoForm(_LocalDrivingLicenseApplicationID);
            frm.ShowDialog();


            _RefreshAllInternationals();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int LicenseID = (int)dataGridViewAllInternationalApplications.CurrentRow.Cells[3].Value;
            _Licenses = ClsLicenses.Find(LicenseID);
            _Application = ClsApplicationsBusiness.FindBaseApplication(_Licenses.ApplicationID);
            _LocalDrivingLicenseApplication = ClsLocalDrivingLicenseApplication.FindByAppLicenseID(_Application.ApplicationID);
            _LocalDrivingLicenseApplicationID = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID;


            LicenseHistoryForm frm = new LicenseHistoryForm(_LocalDrivingLicenseApplicationID);
            frm.ShowDialog();

            _RefreshAllInternationals();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            int LicenseID = (int)dataGridViewAllInternationalApplications.CurrentRow.Cells[3].Value;
            _Licenses = ClsLicenses.Find(LicenseID);
            _Application = ClsApplicationsBusiness.FindBaseApplication(_Licenses.ApplicationID);

            ShowPersonInfoForm frm = new ShowPersonInfoForm(_Application.ApplicantPersonID);
            frm.ShowDialog();
                        
        }
    }
}
