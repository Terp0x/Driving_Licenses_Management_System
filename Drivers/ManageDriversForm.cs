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
    public partial class ManageDriversForm : Form
    {
        ClsDrivers _Drivers;

        public ManageDriversForm()
        {
            InitializeComponent();
        }



        private void _RefreshAllDrivers()
        {
            // Set AutoGenerateColumns to false to prevent auto-creation of columns
            dataGridViewAllDrivers.AutoGenerateColumns = false;

            // Clear any existing columns
            dataGridViewAllDrivers.Columns.Clear();

            // Manually add columns with proper DataPropertyName

            DataGridViewTextBoxColumn DriverIDColumn = new DataGridViewTextBoxColumn();
            DriverIDColumn.HeaderText = "DriverID";
            DriverIDColumn.DataPropertyName = "DriverID";
         
            DataGridViewTextBoxColumn PersonIDColumn = new DataGridViewTextBoxColumn();
            PersonIDColumn.HeaderText = "PersonID";
            PersonIDColumn.DataPropertyName = "PersonID";


            DataGridViewTextBoxColumn NationalNoColumn = new DataGridViewTextBoxColumn();
            NationalNoColumn.HeaderText = "NationalNo";
            NationalNoColumn.DataPropertyName = "NationalNo";
            NationalNoColumn.Width = 150;


            DataGridViewTextBoxColumn FullNameColumn = new DataGridViewTextBoxColumn();
            FullNameColumn.HeaderText = "FullName";
            FullNameColumn.DataPropertyName = "FullName";  // Match the property in your data source
            FullNameColumn.Width = 400;

          

            DataGridViewTextBoxColumn CreatedDateColumn = new DataGridViewTextBoxColumn();
            CreatedDateColumn.HeaderText = "CreatedDate";
            CreatedDateColumn.DataPropertyName = "CreatedDate";
            CreatedDateColumn.Width = 200;

            DataGridViewTextBoxColumn NumberOfActiveLicenseColumn = new DataGridViewTextBoxColumn();
            NumberOfActiveLicenseColumn.HeaderText = "NumberOfActiveLicenses";
            NumberOfActiveLicenseColumn.DataPropertyName = "NumberOfActiveLicenses";
            NumberOfActiveLicenseColumn.Width = 200;



            // Add columns to the DataGridView
            dataGridViewAllDrivers.Columns.Add(DriverIDColumn);
            dataGridViewAllDrivers.Columns.Add(PersonIDColumn);
            dataGridViewAllDrivers.Columns.Add(NationalNoColumn);
            dataGridViewAllDrivers.Columns.Add(FullNameColumn);
            dataGridViewAllDrivers.Columns.Add(CreatedDateColumn);
            dataGridViewAllDrivers.Columns.Add(NumberOfActiveLicenseColumn);



            DataTable DriversTable = new DataTable();
            DriversTable = ClsDrivers.GetAllDriversData();

            dataGridViewAllDrivers.DataSource = DriversTable;


            lbNumRecords.Text = DriversTable.Rows.Count.ToString();
        }


        public void FilterDriversData()
        {

            DataTable DriversTable = new DataTable();
            DriversTable = ClsDrivers.GetAllDriversData();

            DataView DriverDataView = DriversTable.DefaultView;

            // Now we need to filter all data records
            string FilterText = comboBox1.Text;
            int FilteredIntValue;
            string FilteredStringValue = txbfilteredValue.Text;


            // If no filter is selected or the text box is empty, show all data
            if (FilterText == "Noun" || string.IsNullOrWhiteSpace(FilteredStringValue))
            {

                dataGridViewAllDrivers.DataSource = DriversTable;
                return;

            }

            switch (FilterText)
            {
                case "DriverID":
                case "PersonID":
                    {
                        if (int.TryParse(txbfilteredValue.Text, out FilteredIntValue))
                        {
                            DriverDataView.RowFilter = $"{FilterText} =  {FilteredIntValue}";
                            // Bind the filtered DataView to the DataGridView
                            dataGridViewAllDrivers.DataSource = DriverDataView;
                        }
                        else
                        {
                            MessageBox.Show("Please enter a valid number ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        break;
                    }
                case "NationalNo":
                case "FullName":
                    {
                        DriverDataView.RowFilter = $"{FilterText} =  '{FilteredStringValue}'";
                        // Bind the filtered DataView to the DataGridView
                        dataGridViewAllDrivers.DataSource = DriverDataView;
                        break;
                    }
                case "CreatedDate":
                    {
                        DriverDataView.RowFilter = $"{FilterText} =  CreatedDate";
                        // Bind the filtered DataView to the DataGridView
                        dataGridViewAllDrivers.DataSource = DriverDataView;
                        break;
                    }
                case "NumberOfActiveLicenses":
                    {
                        DriverDataView.RowFilter = $"{FilterText} =  NumberOfActiveLicenses";
                        // Bind the filtered DataView to the DataGridView
                        dataGridViewAllDrivers.DataSource = DriverDataView;
                        break;
                    }
                default:
                    MessageBox.Show("Please select a valid filter option.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
            }


            // Bind the filtered DataView to the DataGridView
            dataGridViewAllDrivers.DataSource = DriverDataView;


        }



        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ManageDriversForm_Load(object sender, EventArgs e)
        {
            _RefreshAllDrivers();
        }

     

        private void txbfilteredValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {

                FilterDriversData();
                dataGridViewAllDrivers.Refresh();

            }
        }
    }
}
