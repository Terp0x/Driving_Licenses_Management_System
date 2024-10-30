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
    public partial class InternationalLicenseForm : Form
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
        

        ClsApplicationsBusiness.enApplicationType ApplicationType = ClsApplicationsBusiness.enApplicationType.NewInternationalLicense;
        ClsApplicationTypesBusiness _ApplicationTypeForFees;
        ClsDrivers _Driver;
        ClsApplicationsBusiness _NewApplication;

       

        public InternationalLicenseForm()
        {
            InitializeComponent();
        }

        private bool _IsDriverHasAInternationalLicense()
        {
            DataTable LicenseTable = new DataTable();
            
            LicenseTable = ClsDrivers.GetAllDriversDataPerPerson(_Application.ApplicantPersonID);

            foreach (DataRow DriverRow in LicenseTable.Rows)
            {
                if (LicenseTable != null)
                {
                   if(ClsInternationalLicenseBus.IsInternationalLicensesExists((int)DriverRow["DriverID"]))
                   {
                        _InternationalLicense = ClsInternationalLicenseBus.FindByDriverID((int)DriverRow["DriverID"]);
                        return true;
                   }

                }

            }

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

                _Application = ClsApplicationsBusiness.FindBaseApplication(_License.ApplicationID);
                _LocalDrivingLicenseApplication = ClsLocalDrivingLicenseApplication.FindByAppLicenseID(_Application.ApplicationID);
                _LocalDrivingLicenseApplicationID = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID;
                ctrlDrivingLicenseInfo1.LoadLicenseData(_LocalDrivingLicenseApplicationID);
                _User = ClsUserBusiness.Find(_Application.CreatedByUserID);


                if (_IsDriverHasAInternationalLicense())
                {
                    btnIssueLicense.Enabled = false;
                    llShowLicenseInfo.Enabled = true;
                }
                else
                {
                    btnIssueLicense.Enabled = true;
                    llShowLicenseInfo.Enabled = false;
                }

                //fill application data
                lblApplicationID.Text = _Application.ApplicationID.ToString();
                lblApplicationDate.Text = _Application.ApplicationDate.ToString();
                lblIssueDate.Text = _License.IssueDate.ToString();
                lblFees.Text = _Application.PaidFees.ToString();
                lblInternationalLicenseID.Text = "[???]";
                lblLocalLicenseID.Text = _License.LicenseID.ToString();
                lblExpirationDate.Text = _License.ExpirationDate.ToString();
                lblCreatedByUser.Text = _User.UserName;


            }
            else
                MessageBox.Show("License id is not exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);



        }

    

        private void llShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LicenseHistoryForm frm = new LicenseHistoryForm(_LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID);
            frm.ShowDialog();


        }
              

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool _CheckLocalLicenseActiveAndClass3()
        {
            if(_LocalDrivingLicenseApplication.LicenseClassID == 3 && _License.IsActive == true)
                return true;


            return false;
        }

        private void btnIssueLicense_Click(object sender, EventArgs e)
        {
            //here you need to save international license
            //user have to had a local license to get a international
            //the local license must be in class 3
            //and active


            if (_IsDriverHasAInternationalLicense())
            {
                btnIssueLicense.Enabled = false;
                llShowLicenseInfo.Enabled = true;
                MessageBox.Show("Sorry, you have already a international license ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show("Are you sure you want to Renew License [" + _LicenseID + "]", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)

            {

                //add new application
                _NewApplication = new ClsApplicationsBusiness();

                _ApplicationTypeForFees = ClsApplicationTypesBusiness.Find(6);
                _NewApplication.ApplicantPersonID = _Application.ApplicantPersonID;
                _NewApplication.ApplicationDate = DateTime.Now;
                _NewApplication.ApplicationTypeID = 6;
                _NewApplication.ApplicationStatus = ClsApplicationsBusiness.enApplicationStatus.New;
                _NewApplication.LastStatusDate = DateTime.Now;
                _NewApplication.PaidFees = (float)_ApplicationTypeForFees.ApplicationFees;
                _NewApplication.CreatedByUserID = ClsGlobal.UserID;


                if (_NewApplication.Save())
                {
                    if (!_CheckLocalLicenseActiveAndClass3())
                    {
                        MessageBox.Show("Your local license is not active or not class three", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    //add new driver
                    _Driver = new ClsDrivers();

                    _Driver.PersonID = _NewApplication.ApplicantPersonID;
                    _Driver.CreatedByUserID = _NewApplication.CreatedByUserID;
                    _Driver.CreatedDate = DateTime.Now;

                    if (_Driver.Save())
                    {
                        //now we can add new international license

                        _InternationalLicense = new ClsInternationalLicenseBus();

                        _InternationalLicense.ApplicationID = _NewApplication.ApplicationID;
                        _InternationalLicense.DriverID = _Driver.DriverID;
                        _InternationalLicense.IssuedUsingLocalLicenseID = _FilteredLicenseID;
                        _InternationalLicense.IssueDate = DateTime.Now;
                        _InternationalLicense.ExpirationDate = _InternationalLicense.IssueDate.AddYears(1);
                        _InternationalLicense.IsActive = true;
                        _InternationalLicense.CreatedByUserID = _NewApplication.CreatedByUserID;

                        if (_InternationalLicense.Save())
                        {
                            llShowLicenseInfo.Enabled = true;
                            MessageBox.Show("International license saved successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                            MessageBox.Show("Data is not saved successfully", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }


                }
            }


        }

        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LicenseInfoForm frm = new LicenseInfoForm(_LocalDrivingLicenseApplicationID);
            frm.ShowDialog();


        }

       
        private void button1_Click(object sender, EventArgs e)
        {
            _LoadLicenseInfo();
        }
    }
}
