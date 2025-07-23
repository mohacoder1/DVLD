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

namespace DVLD_Presentation_Layer.ApplicationTypes
{
    public partial class frmAddEditApplicationTypes : Form
    {
        int ID = -1;
        clsApplicationTypes ApplicationTypes = null;

        public frmAddEditApplicationTypes(int SelectedID)
        {
            InitializeComponent();
            ID = SelectedID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAddEditApplicationTypes_Load(object sender, EventArgs e)
        {
             _LoadApplicationData();
        }
        void _LoadApplicationData()
        {
            ApplicationTypes = clsApplicationTypes.Find(ID);
            if (ApplicationTypes != null)
            {
                lblID.Text = ApplicationTypes.ID.ToString();
                lblTitle.Text = ApplicationTypes.Title.ToString();
                txtFees.Text=ApplicationTypes.FeeS.ToString();
                return;
            }
            MessageBox.Show("No Application releted with this ID","Error!",MessageBoxButtons.RetryCancel,MessageBoxIcon.Error);
        }
        bool _SavedInformation()
        {
            ApplicationTypes.FeeS=Convert.ToDouble(txtFees.Text);
            if (ApplicationTypes.Save())
            {
                return true;
            }
            return false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (_SavedInformation())
            {
            MessageBox.Show("Data Saved Successfully", "Done!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
            else
            {
            MessageBox.Show("Data Doesnt Saved Successfully" , "Error!", MessageBoxButtons.RetryCancel, MessageBoxIcon.Exclamation);
            }
            this.Close();
        }

        private void txtFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar);
        }

        private void txtFees_Validating(object sender, CancelEventArgs e)
        {

            //if (!string.IsNullOrEmpty(txtFees.Text.Trim()))
            //{
            //    e.Cancel = true;
            //    errorProvider1.SetError(txtFees, null);

            //}
            //else
            //{
            //    e.Cancel = false;
            //    errorProvider1.SetError(txtFees, "Must Not Be A blank !");

            //}
        }
    }
}