using DVLD_Business_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation_Layer.People.controls
{
    public partial class ctrlPersonInfoWithFilter : UserControl
    {
        public event Action<int> onPersonSelected;
        protected virtual void PersonSelected(int personId)
        {
            Action<int> handler = onPersonSelected ;
            if (handler!=null)
            {
                handler(personId);
            }
        }
        public void LoadPersonInfo(int personId)
        {
            ctrlPersonInfo1.LoadedPersonInfo(personId);
        }
        public void LoadPersonInfo(string NationalNO)
        {
            ctrlPersonInfo1.LoadedPersonInfo(NationalNO);
        }

        public ctrlPersonInfoWithFilter()
        {
            InitializeComponent();
        }
        clsPeople Person=null;
        int PersonID = -1;
        public string value
        {
            set
            {
                txtFilter.Text = value;
            }
        }
        public clsPeople SelectedPerson
        {
            get { return ctrlPersonInfo1.SelectedPerson; }
        }
        public int SelectedPersonID
        {
            get
            {


                return ctrlPersonInfo1.SelectedPerson.PersonID;

                
               
            }
        }
        bool _FilterEnable = true;
        public bool FilterEnable
        {
            set
            {
                gbFilter.Enabled = value;
            }
            get
            {
                return _FilterEnable;
            }
        }
        private void ctrlPersonInfoWithFilter_Load(object sender, EventArgs e)
        {
            cbFilter.SelectedIndex = 1;
           
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilter.ResetText();
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
       txtFilter.ResetText();

        }
        void _FindNow()
        {
            switch (cbFilter.SelectedIndex)
            {

                case 1: ctrlPersonInfo1.LoadedPersonInfo (int.Parse(txtFilter.Text.Trim())); break; 
                case 2: ctrlPersonInfo1.LoadedPersonInfo((txtFilter.Text.Trim())); break;
                default:
                    break;
            }

            try
            {
                if (!string.IsNullOrEmpty(txtFilter.Text.Trim()) && cbFilter.SelectedIndex != 0 && ctrlPersonInfo1.SelectedPerson != null)
                {
                    onPersonSelected(SelectedPersonID);
                }
                else
                {
                    MessageBox.Show("there's no Person With Given ID", "error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                }
            }
            catch(Exception ex) 
            {
            }
        }
        public void FilterFocus()
        {
            txtFilter.Focus();  
        }

        private void ctrlPersonInfo1_Load(object sender, EventArgs e)
     {

        }

        private void k(object sender, EventArgs e)
        {

        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
          if(cbFilter.SelectedIndex==1)  e.Handled = !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            _FindNow();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            frmAddEditPerson frm    = new frmAddEditPerson();
            frm.ShowDialog();
        }
    }
}
