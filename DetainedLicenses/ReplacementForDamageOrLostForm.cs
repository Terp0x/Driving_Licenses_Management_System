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
    public partial class ReplacementForDamageOrLostForm : Form
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

        public ReplacementForDamageOrLostForm()
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
                lblRApplicationID.Text = "[???]";
                lblApplicationDate.Text = DateTime.Now.ToString();
                lbApplicationlFees.Text = _Application.PaidFees.ToString();
                lbReplacementLicenseID.Text = "[???]";          
                lblLocalLicenseID.Text = _License.LicenseID.ToString();
                lblExpirationDate.Text = _License.ExpirationDate.ToString();
                lblCreatedByUser.Text = _User.UserName;

                if (_IsLicenseIsNotActive())
                {
                    btnReplacementIssueLicense.Enabled = false;
                    llShowLicenseInfo.Enabled = false;
                    MessageBox.Show("Sorry, License is not active, please enter active one ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    btnReplacementIssueLicense.Enabled = true;
                    llShowLicenseInfo.Enabled = true;
                   
                }

            }
            else
                MessageBox.Show("Sorry, License ID is not Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _SetExpirationDateForEachType()
        {

            switch (_License.LicenseClass)
            {
                case 1:
                case 2:
                    _NewLicense.ExpirationDate = DateTime.Now.AddYears(5);
                    break;
                case 3:
                case 4:
                case 5:
                case 6:
                case 7:
                    _NewLicense.ExpirationDate = DateTime.Now.AddYears(10);
                    break;
                default:
                    _NewLicense.ExpirationDate = DateTime.Now.AddYears(5);
                    break;

            }

        }

        private void btnReplacementIssueLicense_Click(object sender, EventArgs e)
        {

            //you need to add new application and new license with new id

            if (_IsLicenseIsNotActive())
            {
                btnReplacementIssueLicense.Enabled = false;
                llShowLicenseInfo.Enabled = false;
                MessageBox.Show("Sorry, License is not active, please enter active one ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (MessageBox.Show("Are you sure you want to Issue Replacement License [" + _LicenseID + "]", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)

            {
                //add new application
                _NewApplication = new ClsApplicationsBusiness();

               
                _NewApplication.ApplicantPersonID = _Application.ApplicantPersonID;
                _NewApplication.ApplicationDate = DateTime.Now;

                if (radioButtonDamagedLicense.Checked)
                {
                    _ApplicationTypeForFees = ClsApplicationTypesBusiness.Find(4);
                    _NewApplication.ApplicationTypeID = 4;
                }
                else
                {
                    _ApplicationTypeForFees = ClsApplicationTypesBusiness.Find(3);
                    _NewApplication.ApplicationTypeID = 3;
                }

              
                _NewApplication.ApplicationStatus = ClsApplicationsBusiness.enApplicationStatus.New;
                _NewApplication.LastStatusDate = DateTime.Now;
                _NewApplication.PaidFees = (float)_ApplicationTypeForFees.ApplicationFees;
                _NewApplication.CreatedByUserID = ClsGlobal.UserID;


                if (_NewApplication.Save())
                {

                    //add new driver
                    _Driver = new ClsDrivers();

                    _Driver.PersonID = _NewApplication.ApplicantPersonID;
                    _Driver.CreatedByUserID = _NewApplication.CreatedByUserID;
                    _Driver.CreatedDate = DateTime.Now;

                    if (_Driver.Save())
                    {
                        //add new license
                        _NewLicense = new ClsLicenses();

                        _NewLicense.ApplicationID = _NewApplication.ApplicationID;
                        _NewLicense.DriverID = _Driver.DriverID;
                        _NewLicense.LicenseClass = _License.LicenseClass;
                        _NewLicense.IssueDate = DateTime.Now;
                        _SetExpirationDateForEachType();
                        _NewLicense.Notes = _License.Notes;
                        _NewLicense.PaidFees = _License.PaidFees;
                        _NewLicense.IsActive = true;

                        if (radioButtonDamagedLicense.Checked)
                            _NewLicense.IssueReason = 3;
                        else
                            _NewLicense.IssueReason = 4;


                       _NewLicense.CreatedByUserID = _License.CreatedByUserID;


                        if (_NewLicense.Save())
                        {
                            btnReplacementIssueLicense.Enabled = false;
                            llShowLicenseInfo.Enabled = true;
                            //and license will be updated to not active
                            if (ClsLicenses.IsLicenseActiveUpdated(_License.LicenseID, false))
                                MessageBox.Show("license replacement issued successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                            MessageBox.Show("Data is not saved successfully", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    else
                        MessageBox.Show("Data is not saved successfully", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            }
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

        private void button1_Click(object sender, EventArgs e)
        {
            _LoadLicenseInfo();
        }
    }
}
