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
    public partial class frmShowDriverLicenseInfo : Form
    {
        int _LicenseID = -1;
        public frmShowDriverLicenseInfo(int ID)
        {
            InitializeComponent();
            _LicenseID = ID;
        }

        private void frmShowDriverLicenseInfo_Load(object sender, EventArgs e)
        {
            ctrlDriverLicenseInfo1.LoadInfo(_LicenseID);
        }
    }
}
