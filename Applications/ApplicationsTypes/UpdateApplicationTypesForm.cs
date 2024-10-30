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
    public partial class UpdateApplicationTypesForm : Form
    {
        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;

        int _ApplicationTypeID;

        ClsApplicationTypesBusiness _Application;

        public UpdateApplicationTypesForm(int ApplicationTypeID)
        {
            InitializeComponent();


            _ApplicationTypeID = ApplicationTypeID;

            if (_ApplicationTypeID == -1)
                _Mode = enMode.AddNew;
            else
                _Mode = enMode.Update;
        }


        private void _LoadData()
        {


            //there is no add new mode
            //always update mode

            _Application = ClsApplicationTypesBusiness.Find(_ApplicationTypeID);

            if(_Application == null )
            {

                MessageBox.Show("This form will be closed because No application with ID = " + _Application.ApplicationTypeID);

                return;
            }


            //fill all data
            lbID.Text = _Application.ApplicationTypeID.ToString(); 
            txbTitle.Text = _Application.ApplicationTypeTitle;
            txbFees.Text  = _Application.ApplicationFees.ToString();


        }


        private void btSave_Click(object sender, EventArgs e)
        {

            _Application.ApplicationTypeID = Convert.ToInt32(lbID.Text);
            _Application.ApplicationTypeTitle = txbTitle.Text;
            _Application.ApplicationFees = Convert.ToDecimal(txbFees.Text);


            if(_Application.Save())
                MessageBox.Show("Data Saved Successfully.");
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.");




        }

        private void UpdateApplicationTypesForm_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
