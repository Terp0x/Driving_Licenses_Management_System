using DVLD_BusinessLayer;
using MyDVLD_Project.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MyDVLD_Project
{
    public partial class CtrlPersonCard : UserControl
    {

        private ClsPeopleBusiness _Person;

       
        private int _PersonId;


        public int PersonId
        {
            get { return _PersonId; } 
        }

        public ClsPeopleBusiness Person
        {
            get { return _Person; }
        }


        public CtrlPersonCard()
        {
            InitializeComponent();

        }

        

        public void LoadPersonInfo(int  PersonId)
        {
            _Person = ClsPeopleBusiness.Find(PersonId);
           

            if (Person == null) 
            {
                ResetPersonInfo();
                MessageBox.Show("No Person with PersonID = " + PersonId.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;


            }

            _FillPersonInfo();
        }


        public void LoadPersonInfo(string NationalNo)
        {
            _Person = ClsPeopleBusiness.Find(NationalNo);


            if (Person == null)
            {
                ResetPersonInfo();
                MessageBox.Show("No Person with NationalNo = " + NationalNo , "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;


            }

            _FillPersonInfo();
        }



        private void _FillPersonInfo()
        {
             linkLabel1.Visible = true;
             lbID.Text = _Person.PersonID.ToString();
             lbName.Text = (_Person.FirstName + " " + _Person.SecondName + " " + _Person.ThirdName + " " + _Person.LastName).ToString();
             lbNational.Text = _Person.NationalNo.ToString();

             lbGendor.Text = _Person.Gendor == 0 ? "Male" : "Female";
             lbEmail.Text = _Person.Email;
             lbAddre.Text = _Person.Address;


            lbDate.Text    = _Person.DateOfBirth.ToShortDateString();
            lbCountry.Text = ClsCountriesBusiness.Find(_Person.NationalityCountryID).CountryName;
            lbPhone.Text   = _Person.Phone;

            if (_Person.ImagePath != "")
                  pictureBoxrealImage.Load(_Person.ImagePath);
            else
                pictureBoxrealImage.Image = Resources.Male_512;



            //------------
            //fill person id
             _PersonId = _Person.PersonID;

        }


        public void ResetPersonInfo()
        {

            _PersonId = -1;
            lbID.Text   = "[????]";
            lbName.Text = "[????]";
            lbNational.Text = "[????]";
            lbGendor.Text = "[????]";
            lbEmail.Text = "[????]";
            lbAddre.Text = "[????]";

            lbDate.Text = "[????]";
            lbCountry.Text = "[????]"; 
            lbPhone.Text = "[????]";
            pictureBoxrealImage.Image = Resources.Male_512;


        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            AddNewPersonForm frm = new AddNewPersonForm(_PersonId);

            frm.ShowDialog();

            //refresh
            LoadPersonInfo(_PersonId);


        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
