using DVLD_Presentation_Layer.Applications.DetainAndReleaseLicenses;
using DVLD_Presentation_Layer.Applications.ManageDrivingLicenseApplications.LocalDrivingLicenseApplications;
using DVLD_Presentation_Layer.Appointments;
using DVLD_Presentation_Layer.Licenses.Local_Licenses;
using DVLD_Presentation_Layer.Login;
using DVLD_Presentation_Layer.People;
using DVLD_Presentation_Layer.People.ApplicationTypes;
using DVLD_Presentation_Layer.Test_Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation_Layer
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new frmTest());
            Application.Run(new frmLoginScreen());
           
        }
    }
}
