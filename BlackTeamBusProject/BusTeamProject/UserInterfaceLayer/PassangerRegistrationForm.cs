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
    public partial class PassangerRegistrationForm : Form
    {
        public PassangerRegistrationForm()
        {
            InitializeComponent();
            RefreshGrid();

        }

        PassengerBussiness __passBLL = new PassengerBussiness();
        int selectedID;

      

        private void RefreshGrid()
        {
            try
            {
                List<Passenger> passengerList = __passBLL.GetAllBLL();
                dgvPassangerList.DataSource = null;
                dgvPassangerList.DataSource = passengerList;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void dgvPassangerList_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow dr = dgvPassangerList.SelectedRows[0];
                string updateInput = dr.Cells[0].Value.ToString();
                selectedID = Convert.ToInt32(updateInput);
                Passenger updatePassenger = __passBLL.GetBLL(selectedID);

                txtEmail.Text = updatePassenger.Email;
                txtFirstName.Text = updatePassenger.FirstName;
                txtLastName.Text = updatePassenger.LastName;
                mtxtPhone.Text = updatePassenger.Telephone;
                mtxtSocialNumber.Text = updatePassenger.SocialNumber;
                if (cmbGender.SelectedIndex == 0)
                    updatePassenger.Gender = false;
                else
                    updatePassenger.Gender = true;
              
              

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Passenger usePassenger = new Passenger();
                usePassenger.Email = txtEmail.Text;
                usePassenger.FirstName = txtFirstName.Text;
                usePassenger.LastName = txtLastName.Text;
                usePassenger.SocialNumber = mtxtSocialNumber.Text;
                usePassenger.Telephone = mtxtPhone.Text;

                if (cmbGender.SelectedIndex == 0)
                    usePassenger.Gender = false;
                else
                    usePassenger.Gender = true;

                __passBLL.SaveBLL(usePassenger);
                RefreshGrid();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                Passenger usePassenger = __passBLL.GetBLL(selectedID);
                selectedID = 0;
                __passBLL.DeleteBLL(usePassenger);
                RefreshGrid();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Passenger usePassenger = __passBLL.GetBLL(selectedID);
            usePassenger.Email = txtEmail.Text;
            usePassenger.FirstName = txtFirstName.Text;
            usePassenger.LastName = txtLastName.Text;
            usePassenger.SocialNumber = mtxtSocialNumber.Text;
            usePassenger.Telephone = mtxtPhone.Text;

            if (cmbGender.SelectedIndex == 0)
                usePassenger.Gender = false;
            else
                usePassenger.Gender = true;

            __passBLL.UpdateBLL(usePassenger);
            RefreshGrid();
        }
    }
}
