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
    public partial class ListDetainedLicensesForm : Form
    {
        private int _PersonID;
        private int _LicensesID;

        ClsPeopleBusiness _Persons;
        ClsLicenses _Licenses;
        ClsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;
        ClsApplicationsBusiness _Applications;
        public ListDetainedLicensesForm()
        {
            InitializeComponent();
        }

        private void _RefreshAllDetainedLicenses()
        {
            // Set AutoGenerateColumns to false to prevent auto-creation of columns
            dataGridViewAllDetainedLicenses.AutoGenerateColumns = false;

            // Clear any existing columns
            dataGridViewAllDetainedLicenses.Columns.Clear();

            // Manually add columns with proper DataPropertyName

            DataGridViewTextBoxColumn DetainIDIDColumn = new DataGridViewTextBoxColumn();
            DetainIDIDColumn.HeaderText = "DetainID";
            DetainIDIDColumn.DataPropertyName = "DetainID";


            DataGridViewTextBoxColumn LicenseIDColumn = new DataGridViewTextBoxColumn();
            LicenseIDColumn.HeaderText = "LicenseID";
            LicenseIDColumn.DataPropertyName = "LicenseID";  // Match the property in your data source


            DataGridViewTextBoxColumn DetainDateColumn = new DataGridViewTextBoxColumn();
            DetainDateColumn.HeaderText = "DetainDate";
            DetainDateColumn.DataPropertyName = "DetainDate";


            DataGridViewTextBoxColumn IsReleasedColumn = new DataGridViewTextBoxColumn();
            IsReleasedColumn.HeaderText = "IsReleased";
            IsReleasedColumn.DataPropertyName = "IsReleased";

            DataGridViewTextBoxColumn FineFeesColumn = new DataGridViewTextBoxColumn();
            FineFeesColumn.HeaderText = "FineFees";
            FineFeesColumn.DataPropertyName = "FineFees";  // Match the property in your data source
            FineFeesColumn.Width = 150;


            DataGridViewTextBoxColumn ReleaseDateColumn = new DataGridViewTextBoxColumn();
            ReleaseDateColumn.HeaderText = "ReleaseDate";
            ReleaseDateColumn.DataPropertyName = "ReleaseDate";


            DataGridViewTextBoxColumn NationalNoColumn = new DataGridViewTextBoxColumn();
            NationalNoColumn.HeaderText = "NationalNo";
            NationalNoColumn.DataPropertyName = "NationalNo";

        
            DataGridViewTextBoxColumn FullNameColumn = new DataGridViewTextBoxColumn();
            FullNameColumn.HeaderText = "FullName";
            FullNameColumn.DataPropertyName = "FullName";
            FullNameColumn.Width = 350;

            DataGridViewTextBoxColumn ReleaseApplicationIDColumn = new DataGridViewTextBoxColumn();
            ReleaseApplicationIDColumn.HeaderText = "R.A.ID";
            ReleaseApplicationIDColumn.DataPropertyName = "ReleaseApplicationID";
            ReleaseApplicationIDColumn.Width = 200;



            // Add columns to the DataGridView
            dataGridViewAllDetainedLicenses.Columns.Add(DetainIDIDColumn);
            dataGridViewAllDetainedLicenses.Columns.Add(LicenseIDColumn);
            dataGridViewAllDetainedLicenses.Columns.Add(DetainDateColumn);
            dataGridViewAllDetainedLicenses.Columns.Add(IsReleasedColumn);
            dataGridViewAllDetainedLicenses.Columns.Add(FineFeesColumn);
            dataGridViewAllDetainedLicenses.Columns.Add(ReleaseDateColumn);
            dataGridViewAllDetainedLicenses.Columns.Add(NationalNoColumn);
            dataGridViewAllDetainedLicenses.Columns.Add(FullNameColumn);
            dataGridViewAllDetainedLicenses.Columns.Add(ReleaseApplicationIDColumn);


            DataTable LicensesTable = new DataTable();

            LicensesTable = ClsDetainLicenseBus.GetAllDetainedLicenses();

            dataGridViewAllDetainedLicenses.DataSource = LicensesTable;


            lbNumRecords.Text = LicensesTable.Rows.Count.ToString();
        }

        public void FilterAllDetainedLicesesData()
        {

            DataTable LicensesTable = new DataTable();

            LicensesTable = ClsDetainLicenseBus.GetAllDetainedLicenses();

            DataView LicensesDataView = LicensesTable.DefaultView;

            // Now we need to filter all data records
            string FilterText = comboBox1.Text;
            int FilteredIntValue;
            string FilteredStringValue = txbFilter.Text;


            // If no filter is selected or the text box is empty, show all data
            if (FilterText == "Noun" || string.IsNullOrWhiteSpace(FilteredStringValue))
            {

                dataGridViewAllDetainedLicenses.DataSource = LicensesTable;
                return;

            }

            switch (FilterText)
            {
                case "DetainID":
                case "LicenseID":
                case "ReleaseApplicationID":

                    if (int.TryParse(txbFilter.Text, out FilteredIntValue))
                    {
                        // Use FilteredValue as part of the filter, no need for quotes around it as it's an integer
                        LicensesDataView.RowFilter = $"{FilterText} =  {FilteredIntValue}";

                        // Bind the filtered DataView to the DataGridView
                        dataGridViewAllDetainedLicenses.DataSource = LicensesDataView;
                    }
                    else
                    {
                        MessageBox.Show("Please enter a valid number for PersonID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    break;

                case "NationalNo":
                case "FullName":
                    // Filter text fields
                    LicensesDataView.RowFilter = $"{FilterText} = '{FilteredStringValue}'";
                    break;

                case "IsReleased":

                    if (FilteredStringValue == "true" || FilteredStringValue == "false")
                    {
                        // Filter text fields
                        LicensesDataView.RowFilter = $"{FilterText} = '{FilteredStringValue}'";

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
            dataGridViewAllDetainedLicenses.DataSource = LicensesDataView;

        }


        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ListDetainedLicensesForm_Load(object sender, EventArgs e)
        {
            _RefreshAllDetainedLicenses(); 
        }

        private void txbFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {

                FilterAllDetainedLicesesData();
                dataGridViewAllDetainedLicenses.Refresh();
            }
        }

        private void btnDetain_Click(object sender, EventArgs e)
        {
            DetainLicenseForm form = new DetainLicenseForm();
            form.ShowDialog();

            _RefreshAllDetainedLicenses();
        }

        private void btnRelease_Click(object sender, EventArgs e)
        {
            ReleaseDetainedLicenseForm form = new ReleaseDetainedLicenseForm();
            form.ShowDialog();

            _RefreshAllDetainedLicenses();
        }

        private void toolStripMenuItemPerson_Click(object sender, EventArgs e)
        {
            string NationalNo = (string)dataGridViewAllDetainedLicenses.CurrentRow.Cells[6].Value;

            _Persons = ClsPeopleBusiness.Find(NationalNo);
            ShowPersonInfoForm frm = new ShowPersonInfoForm(_Persons.PersonID);
            frm.ShowDialog();

        }

        private void toolStripMenuItemLicenseDetails_Click(object sender, EventArgs e)
        {

            int LicenseID = (int)dataGridViewAllDetainedLicenses.CurrentRow.Cells[1].Value;
            _Licenses = ClsLicenses.Find(LicenseID);
            _Applications = ClsApplicationsBusiness.FindBaseApplication(_Licenses.ApplicationID);
            _LocalDrivingLicenseApplication = ClsLocalDrivingLicenseApplication.FindByAppLicenseID(_Applications.ApplicationID);

            if (_LocalDrivingLicenseApplication != null)
            {
                LicenseInfoForm frm = new LicenseInfoForm(_LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID);
                frm.ShowDialog();
            }

        }

        private void toolStripMenuItemHistory_Click(object sender, EventArgs e)
        {
            int LicenseID = (int)dataGridViewAllDetainedLicenses.CurrentRow.Cells[1].Value;
            _Licenses = ClsLicenses.Find(LicenseID);
            _Applications = ClsApplicationsBusiness.FindBaseApplication(_Licenses.ApplicationID);
            _LocalDrivingLicenseApplication = ClsLocalDrivingLicenseApplication.FindByAppLicenseID(_Applications.ApplicationID);

            if (_LocalDrivingLicenseApplication != null)
            {
                LicenseHistoryForm frm = new LicenseHistoryForm(_LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID);
                frm.ShowDialog();
            }
        }

        private void toolStripMenuItemRelease_Click(object sender, EventArgs e)
        {
            int LicenseID = (int)dataGridViewAllDetainedLicenses.CurrentRow.Cells[1].Value;

            ReleaseDetainedLicenseForm frm = new ReleaseDetainedLicenseForm(LicenseID);
            frm.ShowDialog();

            _RefreshAllDetainedLicenses();
        }
    }
}
