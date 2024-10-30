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
    public partial class ManageUsersForm : Form
    {
        private bool _IsActive = false;

        ClsUserBusiness _User;

        public ManageUsersForm()
        {
            InitializeComponent();
        }


        private bool _IsUserActive()
        {
            int UserID = (int)dataGridViewAllUsers.CurrentRow.Cells[0].Value;

           _User = ClsUserBusiness.Find(UserID);

            if (_User.IsActive == true)
            {
                _IsActive = true;
                return true;
            }
            else
                _IsActive = false;

            return false;

        }

        private void _RefreshAllUsers()
        {
            // Set AutoGenerateColumns to false to prevent auto-creation of columns
            dataGridViewAllUsers.AutoGenerateColumns = false;

            // Clear any existing columns
            dataGridViewAllUsers.Columns.Clear();

            // Manually add columns with proper DataPropertyName

            DataGridViewTextBoxColumn UserIDColumn = new DataGridViewTextBoxColumn();
            UserIDColumn.HeaderText = "UserID";
            UserIDColumn.DataPropertyName = "UserID";

            DataGridViewTextBoxColumn PersonIDColumn = new DataGridViewTextBoxColumn();
            PersonIDColumn.HeaderText = "PersonID";
            PersonIDColumn.DataPropertyName = "PersonID";


            DataGridViewTextBoxColumn FullNameColumn = new DataGridViewTextBoxColumn();
            FullNameColumn.HeaderText = "FullName";
            FullNameColumn.DataPropertyName = "FullName";  // Match the property in your data source
            FullNameColumn.Width = 350;

            DataGridViewTextBoxColumn UserNameColumn = new DataGridViewTextBoxColumn();
            UserNameColumn.HeaderText = "UserName";
            UserNameColumn.DataPropertyName = "UserName";
            UserNameColumn.Width = 150;


            DataGridViewTextBoxColumn IsActiveColumn = new DataGridViewTextBoxColumn();
            IsActiveColumn.HeaderText = "IsActive";
            IsActiveColumn.DataPropertyName = "IsActive";
            IsActiveColumn.Width = 150;



            // Add columns to the DataGridView
            dataGridViewAllUsers.Columns.Add(UserIDColumn);
            dataGridViewAllUsers.Columns.Add(PersonIDColumn);
            dataGridViewAllUsers.Columns.Add(FullNameColumn);
            dataGridViewAllUsers.Columns.Add(UserNameColumn);
            dataGridViewAllUsers.Columns.Add(IsActiveColumn);
           


            DataTable UsersTable = new DataTable();
            UsersTable = ClsUserBusiness.GetAllUsers();

            dataGridViewAllUsers.DataSource = UsersTable;


                      

           lbNumRecords.Text = UsersTable.Rows.Count.ToString();
        }

        private void ManageUsersForm_Load(object sender, EventArgs e)
        {
            _RefreshAllUsers();
        }


        public void FilterUsersData()
        {

            DataTable UsersTable = new DataTable();

            UsersTable = ClsUserBusiness.GetAllUsers();

            DataView UserDataView = UsersTable.DefaultView;

            // Now we need to filter all data records
            string FilterText = comboBox1.Text;
            int FilteredIntValue;
            string FilteredStringValue = txbFilter.Text;


            // If no filter is selected or the text box is empty, show all data
            if (FilterText == "Noun" || string.IsNullOrWhiteSpace(FilteredStringValue))
            {

                dataGridViewAllUsers.DataSource = UsersTable;
                return;

            }

            switch (FilterText)
            {
                case "UserID":
                case "PersonID":

                    if (int.TryParse(txbFilter.Text, out FilteredIntValue))
                    {
                        // Use FilteredValue as part of the filter, no need for quotes around it as it's an integer
                        UserDataView.RowFilter = $"{FilterText} =  {FilteredIntValue}";

                        // Bind the filtered DataView to the DataGridView
                        dataGridViewAllUsers.DataSource = UserDataView;
                    }
                    else
                    {
                        MessageBox.Show("Please enter a valid number ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    break;


                case "FullName":
                                  
                case "UserName":
                case "IsActive":
            
                    // Filter text fields
                    UserDataView.RowFilter = $"{FilterText} = '{FilteredStringValue}'";
                    break;

                default:
                    MessageBox.Show("Please select a valid filter option.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
            }


            // Bind the filtered DataView to the DataGridView
            dataGridViewAllUsers.DataSource = UserDataView;




        }

        private void txbFilter_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Enter)
            {

                FilterUsersData();
                dataGridViewAllUsers.Refresh();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddNewUserForm frm = new AddNewUserForm(-1);
            frm.ShowDialog();

            _RefreshAllUsers();
        }

        private void toolStripMenuItemedit_Click(object sender, EventArgs e)
        {
            AddNewUserForm frm = new AddNewUserForm((int)dataGridViewAllUsers.CurrentRow.Cells[0].Value); // this mean the parameter isn't -1 (Update mode) 
            frm.ShowDialog();


            _RefreshAllUsers();

        }

        private void toolStripMenuItemAdd_Click(object sender, EventArgs e)
        {
            AddNewUserForm frm = new AddNewUserForm(-1); // this mean the parameter isn't -1 (Update mode) 
            frm.ShowDialog();


            _RefreshAllUsers();
        }

        private void toolStripMenuItemDelete_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Are you sure you want to delete User [" + dataGridViewAllUsers.CurrentRow.Cells[0].Value + "]", "Confirm Delete", MessageBoxButtons.OKCancel) == DialogResult.OK)

            {

                //if he is active user , can not deleted
                if (!_IsUserActive())
                {

                    //Perform Delete and refresh
                    if (ClsUserBusiness.Delete((int)dataGridViewAllUsers.CurrentRow.Cells[0].Value))
                    {
                        MessageBox.Show("User Deleted Successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _RefreshAllUsers();
                    }

                    else
                        MessageBox.Show("User is not deleted.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }else
                {
                    MessageBox.Show("User can not deleted, becuase he is active", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void toolStripMenuItemDetails_Click(object sender, EventArgs e)
        {

            ShowUserInfoForm frm = new ShowUserInfoForm((int)dataGridViewAllUsers.CurrentRow.Cells[0].Value);
            frm.ShowDialog();


            _RefreshAllUsers();

        }

        private void toolStripMenuItempass_Click(object sender, EventArgs e)
        {

            ChangePasswordForm frm = new ChangePasswordForm((int)dataGridViewAllUsers.CurrentRow.Cells[0].Value);

            frm.ShowDialog();

            _RefreshAllUsers();
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
