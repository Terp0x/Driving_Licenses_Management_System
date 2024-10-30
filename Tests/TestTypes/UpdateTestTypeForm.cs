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
    public partial class UpdateTestTypeForm : Form
    {

        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;

        int _TestTypeID;

        ClsTestTypesBusiness _TestTypes;

        public UpdateTestTypeForm(int TestTypeID)
        {
            InitializeComponent();


            _TestTypeID = TestTypeID;

            if (_TestTypeID == -1)
                _Mode = enMode.AddNew;
            else
                _Mode = enMode.Update;

        }


        private void _LoadData()
        {


            //there is no add new mode
            //always update mode

            _TestTypes = ClsTestTypesBusiness.Find(_TestTypeID);
            if (_TestTypes == null)
            {

                MessageBox.Show("This form will be closed because No application with ID = " + _TestTypes.TestTypeID);

                return;
            }


            //fill all data
            lbID.Text     = _TestTypes.TestTypeID.ToString();
            txbTitle.Text = _TestTypes.TestTypeTitle;
            txbFees.Text  = _TestTypes.TestTypeFees.ToString();
            txbDescribtion.Text = _TestTypes.TestTypeDescription;

        }



        private void btSave_Click(object sender, EventArgs e)
        {

            _TestTypes.TestTypeID = int.Parse(lbID.Text);
            _TestTypes.TestTypeTitle = txbTitle.Text;
            _TestTypes.TestTypeFees = Convert.ToDecimal(txbFees.Text);
            _TestTypes.TestTypeDescription = txbDescribtion.Text;



            if (_TestTypes.Save())
                MessageBox.Show("Data Saved Successfully.");
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.");

        }

        private void UpdateTestTypeForm_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
