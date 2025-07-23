using DVLD_Business_Layer;
using DVLD_Presentation_Layer.Global;
using DVLD_Presentation_Layer.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace DVLD_Presentation_Layer.People
{
    public partial class frmAddEditPerson : Form
    {
        enum enMode
        {
            AddNew=0,Update=1
        }

        enMode _Mode=enMode.AddNew;
       private clsPeople  _person = null;
       int _PersonID = -1;


        //update
       /*1*/ public frmAddEditPerson(int ID)
        {
            InitializeComponent(); 
            _PersonID = ID;
            _Mode = enMode.Update;

        }
               
     /*3*/    void _LoadedTheInfoToBoxes()
        {
            _person = clsPeople.FindPerson(_PersonID);
            if (_person==null)
            {

                    MessageBox.Show("There is No Person with Given ID" , "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
                
            }
            lblID.Text =_PersonID.ToString(); 
            txtNationalNo.Text = _person.NationalNo;
            txtFirstName.Text = _person.FirstName;
            txtSecondName.Text = _person.SecondName;
            txtThirdName.Text = _person.ThirdName;
            txtLastName.Text = _person.LastName;
            txtPhoneNo.Text = _person.Phone;
            txtEmail.Text = _person.Email;
            txtAddress.Text = _person.Address;
            dtpDateOfBirth.Value = _person.DateOfBirth;
            cbCountry.SelectedIndex = cbCountry.FindString(_person.CountryInfo.CountryName);
            if (_person.Gendor == 0)
             rbMale.Checked = true; 

            else
                rbFemale.Checked = true; 

            llRemoveImage.Visible = (_person.ImagePath!=null);
            if (_person.ImagePath!=null)
            {
                pfpPersonImage.ImageLocation = _person.ImagePath;
            }

            else
            pfpPersonImage.Image = (rbMale.Checked)? Resources.Male_512: Resources.Female_512;
        }
        //Add
        public frmAddEditPerson()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }
        void _FillCountries()
        {
            foreach (DataRow item in clsCountry.GetAllCountries().Rows)
            {
                cbCountry.Items.Add(item["CountryName"]);
            }
            cbCountry .SelectedIndex = cbCountry.FindString("Iraq");
        }
        void _ResetBoxes()
        {
            _FillCountries();
            lblID.Text = "[???]";
            txtNationalNo.ResetText();
            txtFirstName.ResetText(); 
            txtSecondName.ResetText();
            txtThirdName.ResetText();
            txtLastName.ResetText();
            txtPhoneNo.ResetText();
            txtEmail.ResetText();
            txtAddress.ResetText();
            dtpDateOfBirth.Value = DateTime.Now.AddYears(-18);
            dtpDateOfBirth.MinDate=DateTime.Now.AddYears(-50);
            dtpDateOfBirth.MaxDate=DateTime.Now.AddYears(-18);
            rbMale.Checked = true;
            llRemoveImage.Visible = false;
            pfpPersonImage.Image = Resources.Male_512;

            if (_Mode == enMode.AddNew)
            {
                lblFormStatus.Text = "Add New Person";
                _person = new clsPeople();
              
            }
            else
            {
                lblFormStatus.Text = "Update Person";
                //_person =  clsPeople.FindPerson(_PersonID);
            }
        }

        //Both
        
        bool _SaveInformationToObject()
             {
            if (!ValidateChildren())
            {
                MessageBox.Show("There Are some Fields Mustnt be blank !","Error Validation",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return false;
            }
            _person.FirstName= txtFirstName.Text.Trim();
            _person.SecondName=txtSecondName.Text.Trim();
            _person.LastName=txtLastName.Text.Trim();
            _person.ThirdName= txtThirdName.Text.Trim();
            _person.NationalNo=txtNationalNo.Text.Trim();
            _person.Email=txtEmail.Text.Trim();
            _person.Phone=txtPhoneNo.Text.Trim();
            _person.Address=txtAddress.Text.Trim();
            _person.Gendor = (short)((rbFemale.Checked==true) ? 1 : 0);
            _person.CountryID = cbCountry.SelectedIndex + 1;
            _person.DateOfBirth=dtpDateOfBirth.Value;
            _person.ImagePath = (pfpPersonImage.Image == Resources.Male_512 || pfpPersonImage.Image == Resources.Male_512)
                ? "" : pfpPersonImage.ImageLocation;

            if (_person.Save())
            {
                MessageBox.Show($"This Person Was Adding Successfully , its Releated with ID {_person.PersonID}", "Successfully Saving!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _Mode = enMode.Update;
                lblFormStatus.Text = "Update Person";
                lblID.Text=_person.PersonID.ToString();
                return true;
            }
            else{
                MessageBox.Show("Error");
                return false;

            }
        
        } 
        private void frmAddEditPerson_Load(object sender, EventArgs e)
        {
            _ResetBoxes();

            if (_Mode==enMode.Update)
                _LoadedTheInfoToBoxes();
            
        }
        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            if (rbMale.Checked) { pfpPersonImage.Image = Resources.Male_512; } else { pfpPersonImage.Image = Resources.Female_512; }
        }
        bool _validateChildren()
        {
            return IsBoxesValid & IsEmailValid;
        }
        bool IsBoxesValid=false, IsEmailValid = false;
       
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!_PersonImageHandelr())
            {
                return;
            }
            if (!_validateChildren())
            {
                MessageBox.Show("Some fields are not valid , please put the mouse over the red icon(s) to see the error", "Validation Error!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }



            if (_SaveInformationToObject())
            {
                this.Close();
            }
            

        }
        bool _CheckError( TextBox box)
        {
            return !string.IsNullOrEmpty(box.Text.Trim());
        }
        private void txtNationalNo_Validating(object sender, CancelEventArgs e)
        {
            if (_CheckError(txtNationalNo))
            {
                if (!clsPeople.IsExists(txtNationalNo.Text.Trim()))
                {
                    errorProvider1.SetError(txtNationalNo, null);
                    IsBoxesValid = true;
                }
                else
                {
                    errorProvider1.SetError(txtNationalNo, $"NationalNo ={txtNationalNo.Text} Is Uesd , try another one!");
                    IsBoxesValid = false;
                }
            }
            else
            {
                errorProvider1.SetError(txtNationalNo, "This Field Is Required!"); 
                txtNationalNo.Focus();
                IsBoxesValid=false;

            }
        }
        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            TextBox box = (TextBox)sender;
            if (_CheckError(box))
            {
                IsBoxesValid=true;
                errorProvider1.SetError(box, null);
               
            }
            else
            {
                errorProvider1.SetError(box, "This Field Is Required!");
                box.Focus();   
                IsBoxesValid=false;
            }
        }
        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

            if (clsValidation.Validate(txtEmail.Text.Trim()))
            {
                errorProvider1.SetError(txtEmail, null);
                IsEmailValid = true;
            }
            else
            { 
                errorProvider1.SetError(txtEmail, "This Email Does NOT Valid !");
                txtEmail.Focus();
                IsEmailValid=false;
            }
        }
        private void txtFirstName_Validating(object sender, CancelEventArgs e)
        {
            if (_CheckError(txtFirstName))
            {
                IsBoxesValid=true;
                errorProvider1.SetError(txtFirstName, null);
            }
            else
            {
                errorProvider1.SetError(txtFirstName, "This Field Is Required!");
                txtFirstName.Focus(); 
                IsBoxesValid=false;
            }
        }
        private void txtPhoneNo_TextChanged(object sender, EventArgs e)
        {

        }
        private void txtPhoneNo_KeyPress(object sender, KeyPressEventArgs e)
        {
         e.Handled = !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar);

        }
        private void llSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pfpPersonImage.ImageLocation = openFileDialog1.FileName;
                llRemoveImage.Visible = true;
            }
        }

        private void txtFirstName_TextChanged(object sender, EventArgs e)
        {

        }

        private void llRemoveImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pfpPersonImage.ImageLocation = null;

            pfpPersonImage.Image = rbMale.Checked ? Resources.Male_512 : Resources.Female_512;
        }

        bool _PersonImageHandelr()
        {
             if (_person.ImagePath/* صورة الشخص   */ != pfpPersonImage.ImageLocation )
            {

                if (_person.ImagePath != "")
                {
                    try
                    {
                        File.Delete(_person.ImagePath);
                    }
                    catch (IOException iox)
                    { }

                }
                if (pfpPersonImage.ImageLocation != null)
                {
                    string SourceFile = pfpPersonImage.ImageLocation;
                    if (clsUtil.CopyImageToProjectImagesFolder(ref SourceFile))
                    {
                        pfpPersonImage.ImageLocation = SourceFile;
                        return true;

                    }
                    else 
                        {
                        MessageBox.Show("Error Copying Image File !","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                        }
                }

            }
            return true;
            
        }
    }
}
