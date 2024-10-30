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
    public partial class RenewLicenseForm : Form
    {

        private int _LocalDrivingLicenseApplicationID;
        private int _ApplicationID;
        private int _LicenseID;
        private int _InternationalLicensesID;
        private int _FilteredLicenseID;

        ClsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;
        ClsApplicationsBusiness _Application;
        ClsLicenses _License;
        ClsUserBusiness _User;
        ClsInternationalLicenseBus _InternationalLicense;


        ClsApplicationTypesBusiness _ApplicationTypeForFees;
        ClsDrivers _Driver;
        ClsApplicationsBusiness _NewApplication;
        ClsLicenses _NewLicense;

        public RenewLicenseForm()
        {
            InitializeComponent();
        }

        private bool _IsLicenseExpirationDateEnded()
        {
            if (_License.ExpirationDate < DateTime.Now )
            {
                return true;
            }

            return false;

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
                lblRenewapplicationID.Text = "[???]";
                lblApplicationDate.Text = DateTime.Now.ToString();
                lblIssueDate.Text = _License.IssueDate.ToString();
                lbapplicationfees.Text = _Application.PaidFees.ToString();
                lblFees.Text = _License.PaidFees.ToString();
                lbtotalfees.Text = (Convert.ToDouble(lbapplicationfees.Text) + Convert.ToDouble(lblFees.Text)).ToString();
                lbrenewlicense.Text = "[???]";
                lblLocalLicenseID.Text = _License.LicenseID.ToString();
                lblExpirationDate.Text = _License.ExpirationDate.ToString();
                lblCreatedByUser.Text = _User.UserName;

                if (_IsLicenseExpirationDateEnded())
                {
                    btnRenewLicense.Enabled = true;
                    llShowLicenseInfo.Enabled = false;
                }
                else
                {
                    btnRenewLicense.Enabled = false;
                    llShowLicenseInfo.Enabled = true;
                    MessageBox.Show("Sorry, License doesn't exceed Expiration date yet, it will be in [" + _License.ExpirationDate + "]", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
                MessageBox.Show("Sorry, License ID is not Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }

        private void _SetExpirationDateForEachType()
        {

            switch(_License.LicenseClass)
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    
        private void btnRenewLicense_Click(object sender, EventArgs e)
        {
            //you need to add new application and new license with new id

            //just to ensue that license is in ended expiration date
            if(_IsLicenseIsNotActive())
            {
                llShowLicenseInfo.Enabled = true;
                MessageBox.Show("Sorry, you have already a renewed you license or your license in a active period", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        
            if (MessageBox.Show("Are you sure you want to Renew License [" + _LicenseID + "]", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)

            {
                //add new application
                _NewApplication = new ClsApplicationsBusiness();

                _ApplicationTypeForFees = ClsApplicationTypesBusiness.Find(2);
                _NewApplication.ApplicantPersonID = _Application.ApplicantPersonID;
                _NewApplication.ApplicationDate = DateTime.Now;
                _NewApplication.ApplicationTypeID = 2;
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
                        _NewLicense.Notes = txbnotes.Text;
                        _NewLicense.PaidFees = _License.PaidFees;
                        _NewLicense.IsActive = true;
                        _NewLicense.IssueReason = 2;
                        _NewLicense.CreatedByUserID = _License.CreatedByUserID;


                        if (_NewLicense.Save())
                        {
                            btnRenewLicense.Enabled = false;
                            llShowLicenseInfo.Enabled = true;
                            //and license will be updated to not active
                            if (ClsLicenses.IsLicenseActiveUpdated(_License.LicenseID, false))
                                MessageBox.Show("license Renewed successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                            MessageBox.Show("Data is not saved successfully", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _LoadLicenseInfo();
        }

        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(_LocalDrivingLicenseApplication != null)
            {
                LicenseInfoForm frm = new LicenseInfoForm(_LocalDrivingLicenseApplicationID);
                frm.ShowDialog();
            }else
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
    }
}
