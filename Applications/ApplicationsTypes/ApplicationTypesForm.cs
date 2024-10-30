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
    public partial class ApplicationTypesForm : Form
    {



        public ApplicationTypesForm()
        {
            InitializeComponent();
        }



        private void _RefreshAllApplication()
        {
            // Set AutoGenerateColumns to false to prevent auto-creation of columns
            dataGridViewAllApplication.AutoGenerateColumns = false;

            // Clear any existing columns
            dataGridViewAllApplication.Columns.Clear();

            // Manually add columns with proper DataPropertyName

            DataGridViewTextBoxColumn ApplicationTypeIDColumn = new DataGridViewTextBoxColumn();
            ApplicationTypeIDColumn.HeaderText = "ApplicationTypeID";
            ApplicationTypeIDColumn.DataPropertyName = "ApplicationTypeID";
            ApplicationTypeIDColumn.Width = 150;

            DataGridViewTextBoxColumn ApplicationTypeTitleColumn = new DataGridViewTextBoxColumn();
            ApplicationTypeTitleColumn.HeaderText = "ApplicationTypeTitle";
            ApplicationTypeTitleColumn.DataPropertyName = "ApplicationTypeTitle";
            ApplicationTypeTitleColumn.Width = 500;

            DataGridViewTextBoxColumn ApplicationFeesColumn = new DataGridViewTextBoxColumn();
            ApplicationFeesColumn.HeaderText = "ApplicationFees";
            ApplicationFeesColumn.DataPropertyName = "ApplicationFees";  // Match the property in your data source
            ApplicationFeesColumn.Width = 150;

      

            // Add columns to the DataGridView
            dataGridViewAllApplication.Columns.Add(ApplicationTypeIDColumn);
            dataGridViewAllApplication.Columns.Add(ApplicationTypeTitleColumn);
            dataGridViewAllApplication.Columns.Add(ApplicationFeesColumn);
          

            DataTable ApplicationsTable = new DataTable();
            ApplicationsTable = ClsApplicationTypesBusiness.GetAllApplications();

            dataGridViewAllApplication.DataSource = ApplicationsTable;




            lbNumRecords.Text = ApplicationsTable.Rows.Count.ToString();
        }


        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ApplicationTypesForm_Load(object sender, EventArgs e)
        {
            _RefreshAllApplication();
        }

        private void toolStripMenuItemedit_Click(object sender, EventArgs e)
        {
            UpdateApplicationTypesForm frm = new UpdateApplicationTypesForm((int)dataGridViewAllApplication.CurrentRow.Cells[0].Value);
            frm.ShowDialog();

            _RefreshAllApplication();
        }
    }
}
