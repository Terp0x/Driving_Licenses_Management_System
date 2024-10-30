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
    public partial class DetainLicenseForm : Form
    {

        private int _LocalDrivingLicenseApplicationID;
        private int _ApplicationID;
        private int _LicenseID;
        private int _FilteredLicenseID;

        ClsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;
        ClsApplicationsBusiness _Application;
        ClsLicenses _License;
        ClsUserBusiness _User;


        ClsApplicationTypesBusiness _ApplicationTypeForFees;
        ClsDrivers _Driver;
        ClsApplicationsBusiness _NewApplication;
        ClsLicenses _NewLicense;
        ClsDetainLicenseBus _DetainLicense;

        public DetainLicenseForm()
        {
            InitializeComponent();
        }


        private bool _IsLicenseIsNotActive()
        {
            if (_License.IsActive == false)
                return true;


            return false;

        }


        private void _LoadLicenseInfo()
        {

            if (int.TryParse(txbLicense.Text, out _FilteredLicenseID))
            {
                _FilteredLicenseID = int.Parse(txbLicense.Text);
                _License = ClsLicenses.Find(_FilteredLicenseID);
            }
            else
                MessageBox.Show("Please enter a valid number ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);



            if (_License != null)
            {
                _LicenseID = _License.LicenseID;

                _Application = ClsApplicationsBusiness.FindBaseApplication(_License.ApplicationID);
                _LocalDrivingLicenseApplication = ClsLocalDrivingLicenseApplication.FindByAppLicenseID(_Application.ApplicationID);
                _LocalDrivingLicenseApplicationID = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID;
                ctrlDrivingLicenseInfo1.LoadLicenseData(_LocalDrivingLicenseApplicationID);
                _User = ClsUserBusiness.Find(_Application.CreatedByUserID);


                //fill application data
                DetainID.Text = "[???]";
                lblDetainDate.Text = DateTime.Now.ToString();
                LicenseID.Text = _License.LicenseID.ToString();
                lblCreatedByUser.Text = _User.UserName;

                if (_IsLicenseIsNotActive())
                {
                    btnDetainLicense.Enabled = false;
                    llShowLicenseInfo.Enabled = false;
                    MessageBox.Show("Sorry, License is not active, please enter active one ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    btnDetainLicense.Enabled = true;
                    llShowLicenseInfo.Enabled = true;

                }

            }
            else
                MessageBox.Show("Sorry, License ID is not Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }

        private bool _IsLicenseIsDetained()
        {
            if(ClsDetainLicenseBus.IsDetainedLicenseExistByLicenseID(_LicenseID))
                return true;

            return false;
        }



        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _LoadLicenseInfo();
        }

        private void btnDetainLicense_Click(object sender, EventArgs e)
        {

            //here we go ... 
            if (_IsLicenseIsNotActive())
            {
                btnDetainLicense.Enabled = false;
                llShowLicenseInfo.Enabled = false;
                MessageBox.Show("Sorry, License is not active ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show("Are you sure you want to Detain License [" + _LicenseID + "]", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)

            {
              
                    //add new detain license
                _DetainLicense = new ClsDetainLicenseBus();

                _DetainLicense.LicenseID = _License.LicenseID;
                _DetainLicense.DetainDate = DateTime.Now;
                _DetainLicense.FineFees = Convert.ToDecimal(txbDetainFees.Text);
                _DetainLicense.CreatedByUserID = _License.CreatedByUserID;
                _DetainLicense.IsReleased = false;
                _DetainLicense.ReleaseDate = DateTime.MinValue;
                _DetainLicense.ReleasedByUserID = -1;
                _DetainLicense.ReleaseApplicationID = -1;

                if (_DetainLicense.Save())
                {
                    if (ClsLicenses.IsLicenseActiveUpdated(_License.LicenseID, false))
                        MessageBox.Show("license Detained successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Data is not saved successfully", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void llShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_LocalDrivingLicenseApplication != null)
            {
                LicenseHistoryForm frm = new LicenseHistoryForm(_LocalDrivingLicenseApplicationID);
                frm.ShowDialog();
            }
            else
                MessageBox.Show("Error: you application does not contain any local licenses", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    

        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_LocalDrivingLicenseApplication != null)
            {
                LicenseInfoForm frm = new LicenseInfoForm(_LocalDrivingLicenseApplicationID);
                frm.ShowDialog();
            }
            else
                MessageBox.Show("Error: you application does not contain any local licenses", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
    }
}

