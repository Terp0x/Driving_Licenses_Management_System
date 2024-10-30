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
    public partial class ReleaseDetainedLicenseForm : Form
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;


        private int _LocalDrivingLicenseApplicationID;
        private int _ApplicationID;
        private int _LicenseID;
        private int _FilteredLicenseID;
        private int _CurrentLicenseID;

        ClsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;
        ClsApplicationsBusiness _Application;
        ClsLicenses _License;
        ClsUserBusiness _User;


        ClsApplicationTypesBusiness _ApplicationTypeForFees;
        ClsApplicationsBusiness _NewApplication;
        ClsDetainLicenseBus _DetainLicense;
        ClsLicenses _CurrentLicense;

        public ReleaseDetainedLicenseForm()
        {
            InitializeComponent();
        }

        public ReleaseDetainedLicenseForm(int LicenseID)
        {
            InitializeComponent();

            _CurrentLicenseID = LicenseID;
            _SetForCurrentLicense(_CurrentLicenseID);
        }

        private void _SetForCurrentLicense(int LicenseID)
        {
            _CurrentLicense = ClsLicenses.Find(LicenseID);
            txbLicense.Text = LicenseID.ToString();
            groupBox1.Enabled = false;
            _LoadLicenseInfo();
        }

        private void _LoadLicenseInfo()
        {
            if (_CurrentLicense == null)
            {
                if (int.TryParse(txbLicense.Text, out _FilteredLicenseID))
                {
                    _FilteredLicenseID = int.Parse(txbLicense.Text);
                    _License = ClsLicenses.Find(_FilteredLicenseID);
                }
                else
                    MessageBox.Show("Please enter a valid number ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }else
            {
                 _License = _CurrentLicense;
            }

            if (_License != null)
            {
                _LicenseID = _License.LicenseID;

                _Application = ClsApplicationsBusiness.FindBaseApplication(_License.ApplicationID);
                _LocalDrivingLicenseApplication = ClsLocalDrivingLicenseApplication.FindByAppLicenseID(_Application.ApplicationID);
                _LocalDrivingLicenseApplicationID = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID;
                ctrlDrivingLicenseInfo1.LoadLicenseData(_LocalDrivingLicenseApplicationID);
                _User = ClsUserBusiness.Find(_Application.CreatedByUserID);
                _ApplicationTypeForFees = ClsApplicationTypesBusiness.Find(5);


                //fill application data
                DetainID.Text = "[???]";
                LicenseID.Text = _License.LicenseID.ToString();
                lblCreatedByUser.Text = _User.UserName;
                lbapplicationfees.Text = _ApplicationTypeForFees.ApplicationFees.ToString();


                if (_IsLicenseIsDetained())
                {
                    btnDetainLicense.Enabled = true;
                    llShowLicenseInfo.Enabled = true;

                    
                    _DetainLicense = ClsDetainLicenseBus.FindByLicenseIDNotReleased(_LicenseID);

                    if (_DetainLicense != null)
                    {
                        lblDetainDate.Text = _DetainLicense.DetainDate.ToString();
                        txbDetainFees.Text = _DetainLicense.FineFees.ToString();
                        lbtotalfees.Text = (Convert.ToDecimal(lbapplicationfees.Text) + Convert.ToDecimal(txbDetainFees.Text)).ToString();
                    }
                }
                else
                {
                  
                    btnDetainLicense.Enabled = false;
                    llShowLicenseInfo.Enabled = false;
                    MessageBox.Show("Sorry, License is not Detained, please enter another one ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                           
              
            }
            else
                MessageBox.Show("Sorry, License ID is not Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }

        private bool _IsLicenseIsDetained()
        {
            if (ClsDetainLicenseBus.IsDetainedLicenseExistByLicenseID(_LicenseID))
                return true;

            return false;
        }




        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private bool _IsDetainedLicenseIsReleased()
        {
            
            if (_DetainLicense == null || _DetainLicense.IsReleased == true)
                  return true;
           

            return false;

        }

        private void btnDetainLicense_Click(object sender, EventArgs e)
        {

            if (_IsDetainedLicenseIsReleased())
            {
                btnDetainLicense.Enabled = false;
                MessageBox.Show("Sorry, License is already Released", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (MessageBox.Show("Are you sure you want to Release License [" + _LicenseID + "]", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)

            {

                //add new application
                _NewApplication = new ClsApplicationsBusiness();

                _NewApplication.ApplicantPersonID = _Application.ApplicantPersonID;
                _NewApplication.ApplicationDate = DateTime.Now;
                _NewApplication.ApplicationTypeID = 5;
                _NewApplication.ApplicationStatus = ClsApplicationsBusiness.enApplicationStatus.New;
                _NewApplication.LastStatusDate = DateTime.Now;
                _NewApplication.PaidFees = (float)_ApplicationTypeForFees.ApplicationFees;
                _NewApplication.CreatedByUserID = ClsGlobal.UserID;


                if (_NewApplication.Save())
                {
                    // Detained license should be now in update mode
                    Mode = enMode.Update;

                    _DetainLicense.IsReleased = true;
                    _DetainLicense.ReleaseDate = DateTime.Now;
                    _DetainLicense.ReleasedByUserID = _NewApplication.CreatedByUserID;
                    _DetainLicense.ReleaseApplicationID = _NewApplication.ApplicationID;

                    if (_DetainLicense.Save())
                    {
                        if (ClsLicenses.IsLicenseActiveUpdated(_License.LicenseID, true))
                            MessageBox.Show("license Released successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                    MessageBox.Show("Data is not saved successfully", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _LoadLicenseInfo();
        }
    }
}
