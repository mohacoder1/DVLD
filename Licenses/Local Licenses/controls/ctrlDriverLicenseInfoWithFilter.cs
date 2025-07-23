using DVLD_Business_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation_Layer.Licenses.controls
{
    public partial class ctrlDriverLicenseInfoWithFilter : UserControl
    {
        int _LicenseID = -1;
        public string txtFilterValue
        {
            set { txtFilter.Text = value; }
            get { return txtFilter.Text; }
        }
        public event Action<int> onLicenseSelected;
        protected virtual void LicenseSelected(int ID)
        {
            Action<int> handle = onLicenseSelected;
            if (handle!=null)
            {
                handle(ID);
            }
        }
        public ctrlDriverLicenseInfoWithFilter()
        {
            InitializeComponent();
        }
        bool _FilterEnable = true;
        public bool FilterEnable
        {
            get
            {
                return _FilterEnable;
            }
            set
            {
                _FilterEnable = value;
                groupBox1.Enabled = _FilterEnable;
            }
        }
        public int SelectedIndex
        {
            get
            {
                return cbFilterBy.SelectedIndex;
            }
            set
            {
                cbFilterBy.SelectedIndex = value;
            }
        }
        public clsLicenses SelectedLicense
        {
            get
            {
                return ctrlDriverLicenseInfo1.SelectedLicenseInfo;
            }
        }

        public Button acceptedButton
        {
            get
            {
                return btnSearch;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilter.ResetText();
        }
        public void LoadLicenseInfo(int ID=-1)
        {
            _LicenseID= ID != -1 ?ID:int.Parse(txtFilter.Text);
            _FindNow();

        }
        void _FindNow()
        {
            
            
            switch (cbFilterBy.SelectedIndex)
            {
                
                case 0:ctrlDriverLicenseInfo1.LoadInfo(_LicenseID);break;
                case 1:ctrlDriverLicenseInfo1.LoadInfoByDriverID(_LicenseID);break;
                default:break;
            }
            if (onLicenseSelected!=null&& FilterEnable && SelectedLicense!=null)
            {
                onLicenseSelected(_LicenseID);
            }
            
        }
        private void UserControl1_Load(object sender, EventArgs e)
        {
            
            
            cbFilterBy.SelectedIndex = 0;
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFilter.Text.Trim()))
            {
                MessageBox.Show("This field is required must'nt be blank!", "Warning"
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
                 return;
            }
            LoadLicenseInfo();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txtFilter_Validating(object sender, CancelEventArgs e)
        {

        
        //{
        //    if (!string.IsNullOrEmpty(txtFilter.Text.Trim()))
        //    {
        //        e.Cancel = true;
        //        errorProvider1.SetError(txtFilter, null);
        //        btnSearch.Enabled=true;
        //        return;
        //    }
        //    e.Cancel = false;
        //    errorProvider1.SetError(txtFilter, "This field is required must'nt be blank ");

        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar);
        }

        private void ctrlDriverLicenseInfo1_Load(object sender, EventArgs e)
        {

        }
    }
}
