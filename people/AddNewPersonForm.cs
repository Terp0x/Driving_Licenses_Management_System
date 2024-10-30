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
using System.Xml.Linq;
using System.Text.RegularExpressions;
using MyDVLD_Project.Properties;

namespace MyDVLD_Project
{
    public partial class AddNewPersonForm : Form
    {


        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;

        int _PersonID;
        ClsPeopleBusiness _Person;




        public AddNewPersonForm(int PersonID)
        {
            InitializeComponent();


            _PersonID = PersonID;

            if (_PersonID == -1)

                _Mode = enMode.AddNew;
            else
                _Mode = enMode.Update;


        }





        private void _FillAllCountriesData()
        {

            DataTable dataTable = ClsCountriesBusiness.GetAllCountries();

            comboBox1.DataSource = dataTable;

            comboBox1.DisplayMember = "CountryName";
            comboBox1.ValueMember = "CountryID";

            if (dataTable.Rows.Count == 0)
            {
                MessageBox.Show("No data found.");
            }

        }



        private void _LoadData()
        {

            _FillAllCountriesData();
            comboBox1.SelectedIndex = 0;

            if (_Mode == enMode.AddNew)
            {
                lbHeader.Text = "Add New Person";
                _Person = new ClsPeopleBusiness();
                return;
            }

            _Person = ClsPeopleBusiness.Find(_PersonID);

            if (_Person == null)
            {
                MessageBox.Show("This form will be closed because No Contact with ID = " + _PersonID);
                //this.Close();

                return;
            }

            lbHeader.Text = "Edit Person ID = " + _PersonID;
            lbIDValue.Text = _PersonID.ToString();
            txbfirst.Text = _Person.FirstName;
            txbSecod.Text = _Person.SecondName;
            txbThird.Text = _Person.ThirdName;
            txbLast.Text = _Person.LastName;
            txbNational.Text = _Person.NationalNo;
            dateTimePicker1.Value = _Person.DateOfBirth;
            txbPhone.Text = _Person.Phone;
            txbEmail.Text = _Person.Email;
            txAddress.Text = _Person.Address;


          
            if (_Person.Gendor == 0)
            {
                rdbMale.Checked = true;
                
            }
            else
            {
                rdbFemale.Checked = true;
            }


            if (_Person.ImagePath != "")
            {
                pictureBoxrealImage.Load(_Person.ImagePath);
            }
           

            linkLabel2.Visible = (_Person.ImagePath != ""); //if there are a picture (true)

            //this will select the country in the combobox.
            comboBox1.SelectedIndex = comboBox1.FindString(ClsCountriesBusiness.Find(_Person.NationalityCountryID).CountryName);


        }

        private void AddNewPersonForm_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void btSave_Click(object sender, EventArgs e)
        {

            int CountryID = ClsCountriesBusiness.Find(comboBox1.Text).CountryID;


            _Person.FirstName = txbfirst.Text;
            _Person.SecondName = txbSecod.Text;
            _Person.ThirdName = txbThird.Text;
            _Person.LastName = txbLast.Text;
            _Person.NationalNo = txbNational.Text;
            _Person.DateOfBirth = dateTimePicker1.Value;

            _Person.Phone = txbPhone.Text;
            _Person.Email = txbEmail.Text;
            _Person.Address = txAddress.Text;
            _Person.NationalityCountryID = CountryID;

            if (rdbMale.Checked)
            {
                _Person.Gendor = 0;

            }
            else
            {
                _Person.Gendor = 1;
            }



            if (pictureBoxrealImage.ImageLocation != null)
            {
                _Person.ImagePath = pictureBoxrealImage.ImageLocation.ToString();
            }
            else
            {
                _Person.ImagePath = "";
               
            }


            if (_Person.Save())
                MessageBox.Show("Data Saved Successfully.");
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.");



            _Mode = enMode.Update;
            lbHeader.Text = "Edit Contact ID = " + _PersonID;
            lbIDValue.Text = _PersonID.ToString();
        }




        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {


            openFileDialog1.InitialDirectory = @"C:\Users\c.city\OneDrive\Pictures";

            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Process the selected file
                string selectedFilePath = openFileDialog1.FileName;
                //MessageBox.Show("Selected Image is:" + selectedFilePath);

                pictureBoxrealImage.Load(selectedFilePath);
                // ...
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
          
        }

        private void linkLabel2_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {

            pictureBoxrealImage.ImageLocation = null;
            linkLabel2.Visible = false;

           
                       
        }

        private void txbfirst_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrEmpty(txbfirst.Text))
            {
                e.Cancel = true;
                txbfirst.Focus();
                errorProvider1.SetError(txbfirst, "First Name is required");


            }
            else
            {
                e.Cancel = false;
                txbSecod.Focus();
                errorProvider1.SetError(txbfirst, "");
            }

        }

        private void txbSecod_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrEmpty(txbSecod.Text))
            {
                e.Cancel = true;
                txbSecod.Focus();
                errorProvider1.SetError(txbSecod, "Second Name is required");


            }
            else
            {
                e.Cancel = false;
                txbThird.Focus();
                errorProvider1.SetError(txbSecod, "");
            }
        }

        private void txbLast_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrEmpty(txbLast.Text))
            {
                e.Cancel = true;
                txbLast.Focus();
                errorProvider1.SetError(txbLast, "Last Name is required");


            }
            else
            {
                e.Cancel = false;
                txbNational.Focus();
                errorProvider1.SetError(txbLast, "");
            }
        }



        // Function to validate NationalNo Exists

        private bool IsNationalNoExists()
        {

            if(ClsPeopleBusiness.IsExistsNationalNo(txbNational.Text))
            
                return true;
            else
                return false;
        }


        private void txbNational_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrEmpty(txbNational.Text))
            {
                e.Cancel = true;
                txbNational.Focus();
                errorProvider1.SetError(txbNational, "NationalNo  is required");


            }
            else
            {
                if (IsNationalNoExists())
                {
                    e.Cancel = true;
                    txbNational.Focus();
                    errorProvider1.SetError(txbNational, "NationalNo  is Exists");
                }
                else
                {
                    e.Cancel = false;
                    dateTimePicker1.Focus();
                    errorProvider1.SetError(txbNational, "");
                }
            }
        }

        private void dateTimePicker1_Validating(object sender, CancelEventArgs e)
        {


            // Calculate the date 18 years ago from today
            DateTime maxDate = DateTime.Now.AddYears(-18);

            // Set the MaxDate property of the DateTimePicker to the calculated date
            dateTimePicker1.MaxDate = maxDate;


            if (string.IsNullOrEmpty(dateTimePicker1.Text))
            {
                e.Cancel = true;
                dateTimePicker1.Focus();
                errorProvider1.SetError(dateTimePicker1, "Date  is required");


            }
            else
            {
                e.Cancel = false;
                txbPhone.Focus();
                errorProvider1.SetError(dateTimePicker1, "");
            }
        }

        private void comboBox1_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrEmpty(comboBox1.Text))
            {
                e.Cancel = true;
                comboBox1.Focus();
                errorProvider1.SetError(comboBox1, "Country  is required");


            }
            else
            {
                e.Cancel = false;
                txAddress.Focus();
                errorProvider1.SetError(comboBox1, "");
            }
        }

        private void txbPhone_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrEmpty(txbPhone.Text))
            {
                e.Cancel = true;
                txbPhone.Focus();
                errorProvider1.SetError(txbPhone, "Phone  is required");


            }
            else
            {
                e.Cancel = false;
                txbEmail.Focus();
                errorProvider1.SetError(txbPhone, "");
            }
        }

        private void txAddress_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrEmpty(txAddress.Text))
            {
                e.Cancel = true;
                txAddress.Focus();
                errorProvider1.SetError(txAddress, "Address  is required");


            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txAddress, "");
            }
        }


        // Function to validate email format
        private bool IsValidEmail(string email)
        {
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern);
        }



        private void txbEmail_Validating(object sender, CancelEventArgs e)
        {

            if (!string.IsNullOrEmpty(txbEmail.Text))
            {
                

                if(!IsValidEmail(txbEmail.Text))
                {
                    e.Cancel = true;
                    txbEmail.Focus();
                    errorProvider1.SetError(txbEmail, "Wrong Email format");
                }else
                {
                    e.Cancel = false;
                    comboBox1.Focus();
                    errorProvider1.SetError(txbEmail, "");
                }
               


            }
            else
            {
                e.Cancel = false;
                comboBox1.Focus();
                errorProvider1.SetError(txbEmail, "");
            }
        }

      
    }
}
