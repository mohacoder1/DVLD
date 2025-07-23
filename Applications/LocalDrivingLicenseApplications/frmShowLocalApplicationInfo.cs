using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation_Layer.Applications.ManageDrivingLicenseApplications.LocalDrivingLicenseApplications
{
    public partial class frmShowLocalApplicationInfo : Form
    {
        int _LocalAppID = -1;

        public frmShowLocalApplicationInfo(int ID)
        {
            InitializeComponent();
            _LocalAppID=ID;
        }

        private void frmShowLocalApplicationInfo_Load(object sender, EventArgs e)
        {
            _FindNow();

        }
        void _FindNow()
        {
            ctrlLocalApplicationInfo1.LoadLocalApplicationInfo(_LocalAppID);
        }
    }
}
