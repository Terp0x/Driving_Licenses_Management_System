using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_BusinessLayer;


namespace MyDVLD_Project
{
    public partial class ManagePeople : Form
    {

       
        public ManagePeople()
        {
            InitializeComponent();
                      
        }

        private void _RefreshAllPersons()
        {
            // Set AutoGenerateColumns to false to prevent auto-creation of columns
            dataGridViewAllPersons.AutoGenerateColumns = false;

            // Clear any existing columns
            dataGridViewAllPersons.Columns.Clear();

            // Manually add columns with proper DataPropertyName

            DataGridViewTextBoxColumn PersonIDColumn = new DataGridViewTextBoxColumn();
            PersonIDColumn.HeaderText = "PersonID";
            PersonIDColumn.DataPropertyName = "PersonID";

            DataGridViewTextBoxColumn NationalNoColumn = new DataGridViewTextBoxColumn();
            NationalNoColumn.HeaderText = "NationalNo";
            NationalNoColumn.DataPropertyName = "NationalNo";


            DataGridViewTextBoxColumn firstNameColumn = new DataGridViewTextBoxColumn();
            firstNameColumn.HeaderText = "FirstName";
            firstNameColumn.DataPropertyName = "FirstName";  // Match the property in your data source


            DataGridViewTextBoxColumn SecondNameColumn = new DataGridViewTextBoxColumn();
            SecondNameColumn.HeaderText = "SecondName";
            SecondNameColumn.DataPropertyName = "SecondName";


            DataGridViewTextBoxColumn ThirdNameColumn = new DataGridViewTextBoxColumn();
            ThirdNameColumn.HeaderText = "ThirdName";
            ThirdNameColumn.DataPropertyName = "ThirdName";

            DataGridViewTextBoxColumn lastNameColumn = new DataGridViewTextBoxColumn();
            lastNameColumn.HeaderText = "LastName";
            lastNameColumn.DataPropertyName = "LastName";  // Match the property in your data source
            lastNameColumn.Width = 150;

            DataGridViewTextBoxColumn GendorColumn = new DataGridViewTextBoxColumn();
            GendorColumn.HeaderText = "Gendor";
            GendorColumn.DataPropertyName = "Gendor";


            DataGridViewTextBoxColumn DateOfBirthColumn = new DataGridViewTextBoxColumn();
            DateOfBirthColumn.HeaderText = "DateOfBirth";
            DateOfBirthColumn.DataPropertyName = "DateOfBirth";
            DateOfBirthColumn.Width = 150;

            DataGridViewTextBoxColumn CountryNameColumn = new DataGridViewTextBoxColumn();
            CountryNameColumn.HeaderText = "CountryName";
            CountryNameColumn.DataPropertyName = "CountryName";

            DataGridViewTextBoxColumn PhoneColumn = new DataGridViewTextBoxColumn();
            PhoneColumn.HeaderText = "Phone";
            PhoneColumn.DataPropertyName = "Phone";


            DataGridViewTextBoxColumn EmailColumn = new DataGridViewTextBoxColumn();
            EmailColumn.HeaderText = "Email";
            EmailColumn.DataPropertyName = "Email";
            EmailColumn.Width = 200;



            // Add columns to the DataGridView
            dataGridViewAllPersons.Columns.Add(PersonIDColumn);
            dataGridViewAllPersons.Columns.Add(NationalNoColumn);
            dataGridViewAllPersons.Columns.Add(firstNameColumn);
            dataGridViewAllPersons.Columns.Add(SecondNameColumn);
            dataGridViewAllPersons.Columns.Add(ThirdNameColumn);
            dataGridViewAllPersons.Columns.Add(lastNameColumn);
            dataGridViewAllPersons.Columns.Add(GendorColumn);
            dataGridViewAllPersons.Columns.Add(DateOfBirthColumn);
            dataGridViewAllPersons.Columns.Add(CountryNameColumn);
            dataGridViewAllPersons.Columns.Add(PhoneColumn);
            dataGridViewAllPersons.Columns.Add(EmailColumn);


            DataTable PersonsTable = new DataTable();

            PersonsTable = ClsPeopleBusiness.GetAllPersons();

            dataGridViewAllPersons.DataSource = PersonsTable;


            lbNumRecords.Text = PersonsTable.Rows.Count.ToString();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            _RefreshAllPersons();
        }



        public void FilterPersonsData()
        {

            DataTable PersonsTable = new DataTable();

            PersonsTable = ClsPeopleBusiness.GetAllPersons();

            DataView PersonDataView = PersonsTable.DefaultView;

            // Now we need to filter all data records
            string FilterText = comboBox1.Text;
            int FilteredIntValue;
            string FilteredStringValue = txbFilter.Text;


            // If no filter is selected or the text box is empty, show all data
            if (FilterText == "Noun" || string.IsNullOrWhiteSpace(FilteredStringValue))
            {

                dataGridViewAllPersons.DataSource = PersonsTable;
                return;

            }

            switch (FilterText)
            {
                case "PersonID":

                    if (int.TryParse(txbFilter.Text, out FilteredIntValue))
                    {
                        // Use FilteredValue as part of the filter, no need for quotes around it as it's an integer
                        PersonDataView.RowFilter = $"PersonID = {FilteredIntValue}";

                        // Bind the filtered DataView to the DataGridView
                        dataGridViewAllPersons.DataSource = PersonDataView;
                    }
                    else
                    {
                        MessageBox.Show("Please enter a valid number for PersonID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    break;

               
                case "Nationality":

                    // Assuming Nationality is actually CountryName
                    PersonDataView.RowFilter = $"CountryName = '{FilteredStringValue}'";
                    break;

                case "NationalNo":
                case "FirstName":
                case "SecondName":
                case "ThirdName":
                case "LastName":
                case "Gendor":
                case "Phone":
                case "Email":
                    // Filter text fields
                    PersonDataView.RowFilter = $"{FilterText} = '{FilteredStringValue}'";
                    break;

                default:
                    MessageBox.Show("Please select a valid filter option.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
            }


            // Bind the filtered DataView to the DataGridView
            dataGridViewAllPersons.DataSource = PersonDataView;


           

        }

        private void txbFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {

                FilterPersonsData();
                dataGridViewAllPersons.Refresh();
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
           
            AddNewPersonForm frm = new AddNewPersonForm(-1);
            frm.ShowDialog();

          

            _RefreshAllPersons();
        }

  

        private void toolStripMenuItemAdd_Click(object sender, EventArgs e)
        {

            AddNewPersonForm frm = new AddNewPersonForm(-1);
            frm.ShowDialog();



            _RefreshAllPersons();
        }

        private void toolStripMenuItemEdit_Click(object sender, EventArgs e)
        {
            AddNewPersonForm frm = new AddNewPersonForm((int)dataGridViewAllPersons.CurrentRow.Cells[0].Value); // this mean the parameter isn't -1 (Update mode) 
            frm.ShowDialog();



            _RefreshAllPersons();
        }

        private void toolStripMenuItemDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete contact [" + dataGridViewAllPersons.CurrentRow.Cells[0].Value + "]", "Confirm Delete", MessageBoxButtons.OKCancel) == DialogResult.OK)

            {

                //Perform Delete and refresh
                if (ClsPeopleBusiness.Delete((int)dataGridViewAllPersons.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Person Deleted Successfully.", "Information" , MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefreshAllPersons();
                }

                else
                    MessageBox.Show("Person is not deleted.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
