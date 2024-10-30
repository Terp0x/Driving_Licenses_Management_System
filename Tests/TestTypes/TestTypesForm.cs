using DVLD_BusinessLayer;
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

namespace MyDVLD_Project
{
    public partial class TestTypesForm : Form
    {
        public TestTypesForm()
        {
            InitializeComponent();
        }


        private void _RefreshAllTestTypes()
        {
            // Set AutoGenerateColumns to false to prevent auto-creation of columns
            dataGridViewAllTestTypes.AutoGenerateColumns = false;

            // Clear any existing columns
            dataGridViewAllTestTypes.Columns.Clear();

            // Manually add columns with proper DataPropertyName

            DataGridViewTextBoxColumn TestTypeIDColumn = new DataGridViewTextBoxColumn();
            TestTypeIDColumn.HeaderText = "TestTypeID";
            TestTypeIDColumn.DataPropertyName = "TestTypeID";
            TestTypeIDColumn.Width = 100;

            DataGridViewTextBoxColumn TestTypeTitleColumn = new DataGridViewTextBoxColumn();
            TestTypeTitleColumn.HeaderText = "TestTypeTitle";
            TestTypeTitleColumn.DataPropertyName = "TestTypeTitle";
            TestTypeTitleColumn.Width = 200;

            DataGridViewTextBoxColumn TestTypeDescriptionColumn = new DataGridViewTextBoxColumn();
            TestTypeDescriptionColumn.HeaderText = "TestTypeDescription";
            TestTypeDescriptionColumn.DataPropertyName = "TestTypeDescription";  // Match the property in your data source
            TestTypeDescriptionColumn.Width = 500;


            DataGridViewTextBoxColumn TestTypeFeesColumn = new DataGridViewTextBoxColumn();
            TestTypeFeesColumn.HeaderText = "TestTypeFees";
            TestTypeFeesColumn.DataPropertyName = "TestTypeFees";
            TestTypeFeesColumn.Width = 150;



            // Add columns to the DataGridView
            dataGridViewAllTestTypes.Columns.Add(TestTypeIDColumn);
            dataGridViewAllTestTypes.Columns.Add(TestTypeTitleColumn);
            dataGridViewAllTestTypes.Columns.Add(TestTypeDescriptionColumn);
            dataGridViewAllTestTypes.Columns.Add(TestTypeFeesColumn);


            DataTable TestsTypesTable = new DataTable();
            TestsTypesTable = ClsTestTypesBusiness.GetAllTestTypesData();

            dataGridViewAllTestTypes.DataSource = TestsTypesTable;




            lbNumRecords.Text = TestsTypesTable.Rows.Count.ToString();
        }



        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TestTypesForm_Load(object sender, EventArgs e)
        {
            _RefreshAllTestTypes();
        }

        private void toolStripMenuItemedit_Click(object sender, EventArgs e)
        {
            UpdateTestTypeForm frm = new UpdateTestTypeForm((int)dataGridViewAllTestTypes.CurrentRow.Cells[0].Value);
            frm.ShowDialog();

            _RefreshAllTestTypes();
        }
    }
}
