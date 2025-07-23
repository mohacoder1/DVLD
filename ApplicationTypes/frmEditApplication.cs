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
    public partial class frmEditApplication : Form
    {
        int _AppID = -1;
        clsApplicationTypes ApplicationTypes = null;    

        public frmEditApplication(int ID)
        {
            InitializeComponent();
            _AppID = ID;
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
        //   // if (!string.IsNullOrEmpty(txtFees.Text.Trim()))
        //    {
        //        e.Cancel = true;
        //        errorProvider1.SetError(txtFees, null);

        //    }
        //    else
        //    {
        //        e.Cancel = false;
        //        errorProvider1.SetError(txtFees, "Must Not Be A blank !");

        //    }
        }

        private void frmEditApplication_Load(object sender, EventArgs e)
        {
            _LoadApplicationData();  
        }
        bool _SaveApplicationData()
        {

          //  ApplicationTypes.FeeS = Convert.ToDouble(//txtFees.Text);
            if (ApplicationTypes.Save())
            {

                return true;
            }
            return false;
        }
        void _LoadApplicationData()
        {
            ApplicationTypes = clsApplicationTypes.Find(_AppID);

            if (ApplicationTypes != null)
            {
             //   lblID.Text = ApplicationTypes.ID.ToString();
              //  lblTitle.Text = ApplicationTypes.Title.ToString();
              //  txtFees.Text = ApplicationTypes.FeeS.ToString();
                
                return;
            }
            MessageBox.Show("sry This ApplicationType ID Does Not Exists", "Error!", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            this.Close();
        }
        private void txtFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_SaveApplicationData())
            {
                MessageBox.Show("Data Saved", "Done!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Data doesnt Saved!", "Error!", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
