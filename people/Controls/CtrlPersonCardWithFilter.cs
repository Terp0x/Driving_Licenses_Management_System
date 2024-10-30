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
    public partial class CtrlPersonCardWithFilter : UserControl
    {



        private ClsPeopleBusiness _Person;


        private int _PersonId  ;


        public int PersonId
        {
            get { return _PersonId; }
        }

        public ClsPeopleBusiness Person
        {
            get { return _Person; }
        }


        public CtrlPersonCardWithFilter()
        {
            InitializeComponent();
        }


        
        


        public void FilterPersonsData()
        {

            DataTable PersonsTable = new DataTable();

            PersonsTable = ClsPeopleBusiness.GetAllPersons();

            DataView PersonDataView = PersonsTable.DefaultView;

            // Now we need to filter all data records
            string FilterText = comboBox1.Text;
            int FilteredIntValue;
            string FilteredStringValue = txbFilter.Text;


            // If no filter is selected or the text box is empty, show all data
            if (FilterText == "Noun" || string.IsNullOrWhiteSpace(FilteredStringValue))
            {

                ctrlPersonCard1.ResetPersonInfo();
                return;

            }

            switch (FilterText)
            {
                case "PersonID":

                    if (int.TryParse(txbFilter.Text, out FilteredIntValue))
                    {
                        // Use FilteredValue as part of the filter, no need for quotes around it as it's an integer
                        PersonDataView.RowFilter = $"PersonID = {FilteredIntValue}";
                      
                        ctrlPersonCard1.LoadPersonInfo(int.Parse(txbFilter.Text));
                       
                    }
                    else
                    {
                        MessageBox.Show("Please enter a valid number for PersonID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    break;


                case "NationalNo":
            
                    PersonDataView.RowFilter = $"NationalNo = '{FilteredStringValue}'";
                    ctrlPersonCard1.LoadPersonInfo(FilteredStringValue);
                    break;

                default:
                    MessageBox.Show("Please select a valid filter option.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
            }



            //fill person Id
            _PersonId = ctrlPersonCard1.PersonId;

            _Person = ctrlPersonCard1.Person;

        }




        private void btFind_Click(object sender, EventArgs e)
        {
            FilterPersonsData();
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            AddNewPersonForm frm = new AddNewPersonForm(-1);
            frm.ShowDialog();



        }


        public void LoadPersonData(int PersonId)
        {

            groupBox1.Enabled = false;
            ctrlPersonCard1.LoadPersonInfo(PersonId);

        }
    }
}
