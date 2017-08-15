using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntitiesLayer;
using BusinessLogicLayer;

namespace UserInterfaceLayer
{
    public partial class LoginForm : Form
    {
        LoginPassangerBussiness _loginPassangerBussiness = new LoginPassangerBussiness();
        public LoginForm()
        {
            InitializeComponent();

        }
       
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Text;
            string passWord = txtPassword.Text;
            LoginPassenger loginPassanger = new LoginPassenger();
            loginPassanger.Name = userName;
            loginPassanger.Password = passWord;
     
            try
            {
                int loginBLL = _loginPassangerBussiness.GetIdCorrectLoginBLL(loginPassanger);
                MessageBox.Show(loginBLL.ToString());
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
         

        }

        private void btnNewUser_Click(object sender, EventArgs e)
        {
            PassangerLoginForm passangerLoginForm = new PassangerLoginForm();
            passangerLoginForm.Show();
        }
    }
}
