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

namespace DVLD_Presentation_Layer.Drivers
{
    public partial class frmDriverLicenseHistory : Form
    {
        int _PersonID = -1;
        clsDrivers _Drivers;   
        public frmDriverLicenseHistory(int PersonID)
        {
            InitializeComponent();
            _PersonID = PersonID;
            _Drivers =  clsDrivers.FindByPerson(PersonID);
        }

        private void ctrlDriverLicenseInfoWithFilter1_onLicenseSelected(int obj)
        {
          //  ctrlDriverLicenses1.LoadLocalLicensesInfo(ctrlDriverLicenseInfoWithFilter1.SelectedLicense);
        }

        private void frmDriverLicenseHistory_Load(object sender, EventArgs e)
        {
            ctrlPersonInfoWithFilter1.LoadPersonInfo(_PersonID);
            ctrlPersonInfoWithFilter1.value=_PersonID.ToString();
            ctrlPersonInfoWithFilter1.FilterEnable = false;
            ctrlDriverLicenses1.LoadInfoByPerson(_PersonID);
        }
    }
}
