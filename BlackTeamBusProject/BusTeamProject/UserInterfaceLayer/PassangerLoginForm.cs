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
    public partial class PassangerLoginForm : Form
    {
        public PassangerLoginForm()
        {
            InitializeComponent();
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            Passenger nPassenger = new Passenger();
            nPassenger.SocialNumber = mtxtSocialNumber.Text;
            nPassenger.FirstName = txtFirstName.Text;
            nPassenger.LastName = txtLastName.Text;
            if (cmbGender.SelectedIndex == 0)
                nPassenger.Gender = false;
            else
                nPassenger.Gender = true;
            nPassenger.Telephone = mtxtPhone.Text;
            nPassenger.Email = txtEmail.Text;
            nPassenger.Login.Name = txtUserName.Text;
            if (mtxtPassword.Text==mtxtPasswordRepeat.Text)
            {
                nPassenger.Login.Password = mtxtPassword.Text;
                _passengerBLL.SaveBLL(nPassenger);
                MessageBox.Show("Kayıt Başarılı");
            }
            else
            {
                MessageBox.Show("Lütfen Aynı Şifreyi Giriniz");
            }
           
           
        }
        PassengerBussiness _passengerBLL;
        
        private void PassangerLoginForm_Load(object sender, EventArgs e)
        {
            _passengerBLL = new PassengerBussiness();

            
        }
       
    }
}
