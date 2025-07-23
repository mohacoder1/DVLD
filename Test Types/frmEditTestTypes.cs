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

namespace DVLD_Presentation_Layer.Test_Types
{
    public partial class frmEditTestTypes : Form
    {
        int _AppID = -1;
        clsTestTypes _TestTypes;

        public frmEditTestTypes(int ID)
        {
            InitializeComponent();
            _AppID = ID;
        }
        void _LoadTestTypeInfo()
        {
            _TestTypes= clsTestTypes.Find(_AppID);
            if (_TestTypes!=null)
            {
                lblID.Text = _TestTypes.ID.ToString();
                lblTitle.Text = _TestTypes.TestTitle;
                txtDesc.Text = _TestTypes.TestDesc;
                txtFees.Text = _TestTypes.Fees.ToString();
                return;
            }
            _resetlabels();
        }
        void _resetlabels()
        {
            lblID.Text = "???";
            lblTitle.Text = "???";
            txtDesc.Text = "";
            txtFees.Text = "-1";
        }
        private void txtFees_Validating(object sender, CancelEventArgs e)
        {
            
        }

        private void frmEditTestTypes_Load(object sender, EventArgs e)
        {
            _LoadTestTypeInfo();
        }
        bool _SaveingProcess()
        {
            _TestTypes.Fees=Convert.ToDouble(txtFees.Text);
            if (_TestTypes.Save())
            {
                return true;
            }
            return false;
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_SaveingProcess())
            {
                MessageBox.Show("Data Saved Successfully !", "Done!", MessageBoxButtons.OK);

            }
            else
            {
                MessageBox.Show("Data doesn\'t Saved Successfully !","Error!",MessageBoxButtons.RetryCancel,MessageBoxIcon.Error);

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar);
        }
    }
}
