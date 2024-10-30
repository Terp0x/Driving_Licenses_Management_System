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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MyDVLD_Project
{
    public partial class LocalDrivingLicenseApplicationsForm : Form
    {
        private int _LocalDrivingLicenseApplicationID;
        private bool _IsThreeTestsPassed = false;

        ClsLocalDrivingLicenseApplication _localDrivingLicenseApplication;
        ClsApplicationsBusiness _Application;
        ClsTestAppointments _TestAppointments;
        ClsLicenses _Licenses;
        public LocalDrivingLicenseApplicationsForm()
        {
            InitializeComponent();
        }


        private void _RefreshAllLocalLicense()
        {

            // Set AutoGenerateColumns to false to prevent auto-creation of columns
            dgvLocalDrivingLicenseApplications.AutoGenerateColumns = false;

            // Clear any existing columns
            dgvLocalDrivingLicenseApplications.Columns.Clear();

            // Manually add columns with proper DataPropertyName

            DataGridViewTextBoxColumn LocalDrivingLicenseApplicationIDColumn = new DataGridViewTextBoxColumn();
            LocalDrivingLicenseApplicationIDColumn.HeaderText = "LocalDrivingLicenseApplicationID";
            LocalDrivingLicenseApplicationIDColumn.DataPropertyName = "LocalDrivingLicenseApplicationID";
            LocalDrivingLicenseApplicationIDColumn.Width = 100;

            DataGridViewTextBoxColumn DrivingClassColumn = new DataGridViewTextBoxColumn();
            DrivingClassColumn.HeaderText = "Driving Class";
            DrivingClassColumn.DataPropertyName = "ClassName";
            DrivingClassColumn.Width = 300;

            DataGridViewTextBoxColumn NationalNoColumn = new DataGridViewTextBoxColumn();
            NationalNoColumn.HeaderText = "NationalNo";
            NationalNoColumn.DataPropertyName = "NationalNo";  // Match the property in your data source
            NationalNoColumn.Width = 100;
           

            DataGridViewTextBoxColumn FullNameColumn = new DataGridViewTextBoxColumn();
            FullNameColumn.HeaderText = "FullName";
            FullNameColumn.DataPropertyName = "FullName";
            FullNameColumn.Width = 250;


            DataGridViewTextBoxColumn ApplicationDateColumn = new DataGridViewTextBoxColumn();
            ApplicationDateColumn.HeaderText = "ApplicationDate";
            ApplicationDateColumn.DataPropertyName = "ApplicationDate";
            ApplicationDateColumn.Width = 200;

            DataGridViewTextBoxColumn PassedTestCountColumn = new DataGridViewTextBoxColumn();
           PassedTestCountColumn.HeaderText = "PassedTestCount";
           PassedTestCountColumn.DataPropertyName = "PassedTestCount";
            PassedTestCountColumn.Width = 100;


            DataGridViewTextBoxColumn StatusColumn = new DataGridViewTextBoxColumn();
            StatusColumn.HeaderText = "Status";
            StatusColumn.DataPropertyName = "Status";
            StatusColumn.Width = 150;



            // Add columns to the DataGridView
            dgvLocalDrivingLicenseApplications.Columns.Add(LocalDrivingLicenseApplicationIDColumn);
            dgvLocalDrivingLicenseApplications.Columns.Add(DrivingClassColumn);
            dgvLocalDrivingLicenseApplications.Columns.Add(NationalNoColumn);
            dgvLocalDrivingLicenseApplications.Columns.Add(FullNameColumn);
            dgvLocalDrivingLicenseApplications.Columns.Add(ApplicationDateColumn);
            dgvLocalDrivingLicenseApplications.Columns.Add(PassedTestCountColumn);
            dgvLocalDrivingLicenseApplications.Columns.Add(StatusColumn);


            DataTable LocalLicenseTable = new DataTable();
            LocalLicenseTable = ClsLocalDrivingLicenseApplication.GetAllLocalDrivingLicenseApplications();

            dgvLocalDrivingLicenseApplications.DataSource = LocalLicenseTable;

           


            lblRecordsCount.Text = LocalLicenseTable.Rows.Count.ToString();
        }



        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LocalDrivingLicenseApplicationsForm_Load(object sender, EventArgs e)
        {
            _RefreshAllLocalLicense();
        }

        public void FilterLocalDrivingData()
        {

            DataTable LocalLicenseTable = new DataTable();

            LocalLicenseTable = ClsLocalDrivingLicenseApplication.GetAllLocalDrivingLicenseApplications();

            DataView UserDataView = LocalLicenseTable.DefaultView;

            // Now we need to filter all data records
            string FilterText = cbFilterBy.Text;
            int FilteredIntValue;
            string FilteredStringValue = txtFilterValue.Text;


            // If no filter is selected or the text box is empty, show all data
            if (FilterText == "Noun" || string.IsNullOrWhiteSpace(FilteredStringValue))
            {

                dgvLocalDrivingLicenseApplications.DataSource = LocalLicenseTable;
                return;

            }

            switch (FilterText)
            {
                case "LDLAppID":
               
                    if (int.TryParse(txtFilterValue.Text, out FilteredIntValue))
                    {
                        // Use FilteredValue as part of the filter, no need for quotes around it as it's an integer
                        UserDataView.RowFilter = $"LocalDrivingLicenseApplicationID =  {FilteredIntValue}";

                        // Bind the filtered DataView to the DataGridView
                        dgvLocalDrivingLicenseApplications.DataSource = UserDataView;
                    }
                    else
                    {
                        MessageBox.Show("Please enter a valid number ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    break;


                case "NationalNo":
                case "FullName":
                case "Status":

                    // Filter text fields
                    UserDataView.RowFilter = $"{FilterText} = '{FilteredStringValue}'";
                    break;

                default:
                    MessageBox.Show("Please select a valid filter option.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
            }


            // Bind the filtered DataView to the DataGridView
            dgvLocalDrivingLicenseApplications.DataSource = UserDataView;

         
            
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {

                FilterLocalDrivingData();
                dgvLocalDrivingLicenseApplications.Refresh();
            }
        }

        private void btnAddNewApplication_Click(object sender, EventArgs e)
        {
            NewLocalDrivingLicenseForm frm = new NewLocalDrivingLicenseForm(-1);
            frm.ShowDialog();

            _RefreshAllLocalLicense();
                
        }



        public bool IsStatusNew()
        {
            _LocalDrivingLicenseApplicationID = (int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value;
            _localDrivingLicenseApplication = ClsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(_LocalDrivingLicenseApplicationID);

            _Application = ClsApplicationsBusiness.FindBaseApplication(_localDrivingLicenseApplication.ApplicationID);

            if ((byte)_Application.ApplicationStatus == 1)
            {
               
                return true;
            }

            return false;

        }

        public bool IsStatusCancelled()
        {
            _LocalDrivingLicenseApplicationID = (int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value;
            _localDrivingLicenseApplication = ClsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(_LocalDrivingLicenseApplicationID);

            _Application = ClsApplicationsBusiness.FindBaseApplication(_localDrivingLicenseApplication.ApplicationID);

            if ((byte)_Application.ApplicationStatus == 2)
            {

                return true;
            }

            return false;

        }


        private void CancelApplicaitonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to change license status [" + dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value + "]", "Confirm status", MessageBoxButtons.OKCancel) == DialogResult.OK)

            {
                if (IsStatusNew())
                {
                    //change status in the data base to cancelled (update)  
                    _Application.Cancel();
                    _RefreshAllLocalLicense();
                }
                else
                    MessageBox.Show("license status is not New.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewLocalDrivingLicenseForm frm = new NewLocalDrivingLicenseForm((int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value);
            frm.ShowDialog();

            _RefreshAllLocalLicense();

        }

        private void DeleteApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            if (MessageBox.Show("Are you sure you want to delete license [" + dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value + "]", "Confirm Delete", MessageBoxButtons.OKCancel) == DialogResult.OK)

            {
                if (IsStatusCancelled())
                {
                    //delete application as well
                    //Perform Delete and refresh
                    if (ClsLocalDrivingLicenseApplication.Delete((int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value))
                    {
                        if (ClsApplicationsBusiness.Delete(_Application.ApplicationID))
                        {

                            MessageBox.Show("license Deleted Successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            _RefreshAllLocalLicense();
                        }
                    }
                                       
                    else
                        MessageBox.Show("license is not deleted.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                        MessageBox.Show("license status is not Cancelled.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool _IsPersonHasAPreviousLicenses(int LocalDrivingLicenseApplicationID)
        {
            ClsLicenses _License;
            _localDrivingLicenseApplication = ClsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(LocalDrivingLicenseApplicationID);

            _License =  ClsLicenses.FindByApplicationID(_localDrivingLicenseApplication.ApplicationID);
           
            if(_License != null)
                return true;

            return false;
        }


        private void _DisableOperationWhenThreeTestsPassed(bool _IsIssuePassed)
        {
            if(_IsIssuePassed)
            {
                showDetailsToolStripMenuItem.Enabled = false;
                editToolStripMenuItem.Enabled=false;
                DeleteApplicationToolStripMenuItem.Enabled = false;
                CancelApplicaitonToolStripMenuItem.Enabled = false;
                ScheduleTestsMenue.Enabled = false;
                issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = false;
            }else
            {
                showDetailsToolStripMenuItem.Enabled = true;
                editToolStripMenuItem.Enabled = true;
                DeleteApplicationToolStripMenuItem.Enabled = true;
                CancelApplicaitonToolStripMenuItem.Enabled = true;
                ScheduleTestsMenue.Enabled = true;
                issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = true;
            }
        }

        private void _HowMuchTestAppointmentPassedTests()
        {
            int passedTests = (int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[5].Value;
            int LocalDrivingLicenseApplicationID = (int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value;

            switch (passedTests)
            {
                case 0:
                    {
                        //disable the two tests 2, 3
                        issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = false;
                        showLicenseToolStripMenuItem.Enabled = false;
                        
                        scheduleVisionTestToolStripMenuItem.Enabled = true;
                        scheduleWrittenTestToolStripMenuItem.Enabled = false;
                        scheduleStreetTestToolStripMenuItem.Enabled = false;
                        break;
                    }
                case 1:
                    {
                        //disable the two tests 1, 3
                        issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = false;
                        showLicenseToolStripMenuItem.Enabled = false;

                        scheduleVisionTestToolStripMenuItem.Enabled = false;
                        scheduleWrittenTestToolStripMenuItem.Enabled = true;
                        scheduleStreetTestToolStripMenuItem.Enabled = false;
                        break;
                    }
                case 2:
                    {
                        //disable the two tests 1, 2   
                        issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = false;
                        showLicenseToolStripMenuItem.Enabled = false;

                        scheduleVisionTestToolStripMenuItem.Enabled = false;
                        scheduleWrittenTestToolStripMenuItem.Enabled = false;
                        scheduleStreetTestToolStripMenuItem.Enabled = true;
                        break;
                    }
                case 3:
                    {
                        //disable the three tests 1, 2, 3
                        if (!_IsPersonHasAPreviousLicenses(LocalDrivingLicenseApplicationID))
                        {
                            issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = true;
                            showLicenseToolStripMenuItem.Enabled = true;
                        }

                        scheduleVisionTestToolStripMenuItem.Enabled = false;
                        scheduleWrittenTestToolStripMenuItem.Enabled = false;
                        scheduleStreetTestToolStripMenuItem.Enabled = false;

                        break;
                    }
                default:
                    {
                        // Handle cases where `passedTests` doesn't match any case
                       
                        scheduleVisionTestToolStripMenuItem.Enabled = true;
                        scheduleWrittenTestToolStripMenuItem.Enabled = false;
                        scheduleStreetTestToolStripMenuItem.Enabled = false;
                        break;
                    }
            }
        }

      
        private void _PersonHasPreviousDrivingLicenses()
        {
            int LocalDrivingLicenseApplicationID = (int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value;

            if (_IsPersonHasAPreviousLicenses(LocalDrivingLicenseApplicationID))
                _DisableOperationWhenThreeTestsPassed(true);
            else
                _DisableOperationWhenThreeTestsPassed(false);
           

        }

        private void _ScheduleTest(ClsTestTypesBusiness.enTestTypes testTypes)
        {
           
            int LocalDrivingLicenseApplicationID = (int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value;

            TestAppointmentForm frm = new TestAppointmentForm(LocalDrivingLicenseApplicationID, testTypes);
            frm.ShowDialog();

            _RefreshAllLocalLicense();
           
        }


        private void scheduleVisionTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ScheduleTest(ClsTestTypesBusiness.enTestTypes.VisionTest);
        }

        private void scheduleWrittenTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ScheduleTest(ClsTestTypesBusiness.enTestTypes.WrittenTest);
        }

        private void scheduleStreetTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ScheduleTest(ClsTestTypesBusiness.enTestTypes.StreetTest);
        }

       
        private void dgvLocalDrivingLicenseApplications_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _PersonHasPreviousDrivingLicenses();
            _HowMuchTestAppointmentPassedTests();
            
        }

        private void issueDrivingLicenseFirstTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LocalDrivingLicenseApplicationID = (int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value;

            IssueDrivingLicenseForm frm = new IssueDrivingLicenseForm(LocalDrivingLicenseApplicationID);
            frm.ShowDialog();

            _RefreshAllLocalLicense();

          
           //issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = false;

        }

        private void showLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LocalDrivingLicenseApplicationID = (int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value;

            if (_IsPersonHasAPreviousLicenses(LocalDrivingLicenseApplicationID))
            {
                LicenseInfoForm frm = new LicenseInfoForm(LocalDrivingLicenseApplicationID);
                frm.ShowDialog();

                _RefreshAllLocalLicense();
            }else
                MessageBox.Show("Sorry, You don't have any license .", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LocalDrivingLicenseApplicationID = (int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value;

            LicenseHistoryForm frm = new LicenseHistoryForm(LocalDrivingLicenseApplicationID);
            frm.ShowDialog();

            _RefreshAllLocalLicense();

        }
    }
}
