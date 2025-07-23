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

namespace DVLD_Presentation_Layer.People
{
    public partial class frmShowPersonInfocs : Form
    {
        int _PersonID=-1;
        public frmShowPersonInfocs(int ID)
        {
            InitializeComponent();
            _PersonID=ID;   
        }

        private void frmShowPersonInfocs_Load(object sender, EventArgs e)
        {
            ctrlPersonInfo1.LoadedPersonInfo(_PersonID);
        }

        private void ctrlPersonInfo1_Load(object sender, EventArgs e)
        {

        }
    }
}
