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

    public partial class CtrlDrivingLicenseInfoWithFilter : UserControl
    {
        private int _LocalDrivingLicenseApplicationID;
        private int _ApplicationID;
        private int _LicenseID;
        private int _FilteredLicenseID;



        ClsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;
        ClsApplicationsBusiness _Application;
        ClsLicenses _License;
        ClsInternationalLicenseBus _InternationalLicense;
        ClsUserBusiness _User;
        public int  LicenseID
        {
            get { return Convert.ToInt32(_FilteredLicenseID); }
        }


        public int LocalDrivingLicenseApplicationID
        {
            get { return Convert.ToInt32(_LocalDrivingLicenseApplicationID); }
        }

        public ClsLicenses License
        {
            get { return _License; }
        }

        public ClsLocalDrivingLicenseApplication LocalDrivingLicenseApplication
        {
            get { return _LocalDrivingLicenseApplication; }
        }

        public CtrlDrivingLicenseInfoWithFilter()
        {
            InitializeComponent();
        }


        private void _FillControlData()
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
                _LoadLicenseInfo();


            }
            else
                MessageBox.Show("License id is not exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


        }


      
        private void _LoadLicenseInfo()
        {
                  
            _User = ClsUserBusiness.Find(_Application.CreatedByUserID);

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

        private void button1_Click(object sender, EventArgs e)
        {
            _FillControlData();

        }
    }
}
