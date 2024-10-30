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
    public partial class MianForm : Form
    {

        private int _PersonID;

        ClsPeopleBusiness _Person;
        ClsUserBusiness _User;

        public MianForm()
        {
            InitializeComponent();
        }

        private void _LoadCurrentData()
        {
            _User = ClsGlobal._CurrentUser;
           

        }


        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManagePeople frm = new ManagePeople();
            frm.ShowDialog();

        }

        private void employeesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageUsersForm frm = new ManageUsersForm();
            frm.ShowDialog();

        }

        private void currentUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowUserInfoForm frm = new ShowUserInfoForm(_User.UserID);
            frm.ShowDialog();


        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePasswordForm frm = new ChangePasswordForm(_User.UserID);
            frm.ShowDialog();


        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            //LoginForm frm = new LoginForm();
            //frm.ShowDialog();

            Application.Restart();

        }

        private void MianForm_Load(object sender, EventArgs e)
        {
            _LoadCurrentData();
        }

        private void manageTestTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TestTypesForm frm = new TestTypesForm();
            frm.ShowDialog();

        }

        private void manageApplicationTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ApplicationTypesForm frm = new ApplicationTypesForm();
            frm.ShowDialog();
        }

        private void manageLocalDrivingLicenseApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LocalDrivingLicenseApplicationsForm frm  = new LocalDrivingLicenseApplicationsForm();
            frm.ShowDialog();

        }

        private void localLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewLocalDrivingLicenseForm frm = new NewLocalDrivingLicenseForm(-1);
            frm.ShowDialog();

        }

        private void driversToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageDriversForm frm = new ManageDriversForm();
            frm.ShowDialog();

        }

        private void internationalLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InternationalLicenseForm frm = new InternationalLicenseForm();
            frm.ShowDialog();

        }

        private void ManageInternationaDrivingLicenseToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            InternationalLicenseApplicationForm frm = new InternationalLicenseApplicationForm();
            frm.ShowDialog();

        }

        private void renewDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RenewLicenseForm frm = new RenewLicenseForm();
            frm.ShowDialog();

        }

        private void ReplacementLostOrDamagedDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReplacementForDamageOrLostForm frm = new ReplacementForDamageOrLostForm();
            frm.ShowDialog();
        }

        private void detainLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DetainLicenseForm frm = new DetainLicenseForm();
            frm.ShowDialog();
        }

        private void releaseDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReleaseDetainedLicenseForm frm = new ReleaseDetainedLicenseForm();
            frm.ShowDialog();

        }

        private void releaseDetainedDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReleaseDetainedLicenseForm frm = new ReleaseDetainedLicenseForm();
            frm.ShowDialog();
        }

        private void ManageDetainedLicensestoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ListDetainedLicensesForm frm = new ListDetainedLicensesForm();
            frm.ShowDialog();

        }
    }
}
