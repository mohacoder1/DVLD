using DVLD_Business_Layer;
using DVLD_Presentation_Layer.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace DVLD_Presentation_Layer.People
{
    public partial class ctrlPersonInfo : UserControl
    {
        clsPeople _Person;

         int _PersonID = -1;

        public int PersonID
        {
            get { return _PersonID; }
        }

       public clsPeople SelectedPerson
        {
            get { return _Person; }
        }

        public ctrlPersonInfo()
        {
            InitializeComponent();
        }
        void ResetLables()
        {
            lblName.Text = "[???]";
            lblDate.Text = "[???]";
            lblCountry.Text = "[???]";
            lblAddress.Text = "[???]";
            lblPhone.Text = "[???]";
            lblAddress.Text = "[???]";
            lblEmail.Text = "[???]";
            lblGendor.Text = "[???]";
            lblID.Text = "[???]";
            pbPersonImage.Image = Resources.Male_512;

        }
        bool _checkExists( dynamic var)
        {
            _Person = clsPeople.FindPerson(var);
            if (_Person == null)
            {
                ResetLables();
                return false;
            }
            _FillInformation();
            return true;
        }
        public void LoadedPersonInfo(dynamic var)
        {
           _checkExists(var);
        }
       
        void  LoadPersonImage()
        {
            if (_Person.ImagePath == null || _Person.ImagePath == "")
            {
                if (_Person.Gendor == 0)
                    pbPersonImage.Image = Resources.Male_512;

                else pbPersonImage.Image = Resources.Female_512;
                return;
            }
            pbPersonImage.ImageLocation = _Person.ImagePath;
        }
            
        void _FillInformation()
        {
            _PersonID = _Person.PersonID;

            lblName.Text = _Person.fullName;
            lblDate.Text = _Person.DateOfBirth.ToShortDateString();
            lblCountry.Text = _Person.CountryInfo.CountryName;
            lblAddress.Text = _Person.Address;
            lblPhone.Text = _Person.Phone;
            lblAddress.Text = _Person.Address;
            lblEmail.Text =  _Person.Email ;
            lblNationalNo.Text = _Person.NationalNo;
            lblGendor.Text = _Person.Gendor == 0 ? "Male" : "Female";
            lblID.Text = _Person.PersonID.ToString();
            LoadPersonImage();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
