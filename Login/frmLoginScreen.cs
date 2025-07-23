using DVLD_Business_Layer;
using DVLD_Presentation_Layer.Global;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation_Layer.Login
{
               
    // CurrentUser.CurrentUserInfo=clsUser.FindUser(txtUsername.Text);
    public partial class frmLoginScreen : Form
    { 
        clsUser User=null;    
        public frmLoginScreen()
        {
            InitializeComponent();
        }
        
        void _ResetValues()
        {
            txtUsername.ResetText();
            txtPassword.ResetText();
            chkRememberMe.Checked = false;
        }
        private void frmLoginScreen_Load(object sender, EventArgs e)
        {
            if (_CheckStoredPerson())
                 return;
            
            _ResetValues();
        }
        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            TextBox textBox1 =(TextBox)sender ;
            if(string.IsNullOrEmpty(textBox1.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(textBox1, "this Field Must Not Be A blanck !");
                textBox1.Focus();
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(textBox1, null);
            }
        }
        bool _CheckStoredPerson()
        {
            clsCurrentUser Current = clsCurrentUser.GetCurrentUser();
            if (Current == null)
            {
                return false;
            }
            txtUsername.Text = Current.UserInfo.UserName;
            txtPassword.Text = Current.UserInfo.Password;
            chkRememberMe.Checked = true;
            clsGlobal.CurrentUserInfo = Current.UserInfo;
            return true;
        }
        bool _CheckUserExists(string username,string password)
        {
            User = clsUser.FindUserByUsernameAndPassword(username, password);
            return User != null;
          
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (!_CheckUserExists(txtUsername.Text.Trim(), txtPassword.Text.Trim()))
            {
                MessageBox.Show("Invalid Username/Password try again","Error",MessageBoxButtons.RetryCancel,MessageBoxIcon.Error);
                return;
            }

            if (!User.isActive)
            {
                MessageBox.Show("Sry, This user is Not Active ,Contact Your Admin", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                return;
            }
            if (chkRememberMe.Checked)
            {
                clsCurrentUser.UpdateCurrentUser(txtUsername.Text.Trim(), txtPassword.Text.Trim());
            }
            else
            {
                clsCurrentUser.UpdateCurrentUser("", "");
            }
            clsGlobal.CurrentUserInfo = User;
            Form1 form1 = new Form1(this);
            form1.ShowDialog();
        }
       
    }
}
