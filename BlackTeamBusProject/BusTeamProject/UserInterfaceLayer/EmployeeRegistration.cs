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
    public partial class EmployeeRegistration : Form
    {
        public EmployeeRegistration()
        {
            InitializeComponent();
        }

        EmployeeBussiness _employeeBLL;
        int selectedID;

        //Eğer işi bırakma tarihi boş gelirse diye method
        public void ifnottheFinishWork()
        {
            if (dtpFinishWorkDay.Checked == true)
            {
                dtpFinishWorkDay.Enabled = true;
                dtpFinishWorkDay.Format = DateTimePickerFormat.Short;
            }
            else
            {
                dtpFinishWorkDay.Enabled = false;
                dtpFinishWorkDay.Format = DateTimePickerFormat.Custom;
                dtpFinishWorkDay.CustomFormat = " ";
            }
        }

        private void dgvEmployeeList_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (dgvEmployeeList.SelectedRows.Count > 0)
                {
                    DataGridViewRow dr = dgvEmployeeList.SelectedRows[0];
                    string updateIdInput = dr.Cells[0].Value.ToString();
                    selectedID = int.Parse(updateIdInput);
                    Employee updateEmployee = _employeeBLL.GetBLL(selectedID);
                    txtsocialNumber.Text = updateEmployee.SocialNumber;
                    txtFirstName.Text = updateEmployee.FirstName;
                    txtLastName.Text = updateEmployee.LastName;
                    bool genderStatus;
                    if (cmbGender.SelectedIndex == 0)
                    {
                        genderStatus = false;
                    }
                    else
                    {
                        genderStatus = true;
                    }
                    genderStatus = (bool)updateEmployee.Gender;
                    dtpDateofBirth.Value = updateEmployee.DateOfBirth;
                    cmbRoleID.SelectedIndex = (int)updateEmployee.RoleID;
                    txtPhoneNumber.Text = updateEmployee.Telephone;
                    txtEmail.Text = updateEmployee.Email;
                    dtpStarWorkDay.Value = updateEmployee.StartWorkDate;
                    dtpFinishWorkDay.Value = updateEmployee.FinishWorkDate;

                    bool checkedboxValue;
                    if (checkBoxIsAvailable.Checked)
                    {
                        checkedboxValue = true;
                    }
                    else
                    {
                        checkedboxValue = false;
                    }
                    //checkedboxValue=
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void RefreshGrid()
        {
            try
            {

                List<Employee> employeeList = _employeeBLL.GetAllBLL();
                dgvEmployeeList.DataSource = null;
                dgvEmployeeList.DataSource = employeeList;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void EmployeeRegistration_Load(object sender, EventArgs e)
        {
            _employeeBLL = new EmployeeBussiness();
            RoleBussiness _roleBussines = new RoleBussiness();
            cmbRoleID.DataSource = _roleBussines.GetAllBLL();
            cmbRoleID.DisplayMember = "RoleName";
            cmbRoleID.ValueMember = "ID";

            RefreshGrid();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Employee newEmploye = new Employee();
            newEmploye.FirstName = txtFirstName.Text;
            newEmploye.LastName = txtLastName.Text;
            newEmploye.SocialNumber = txtsocialNumber.Text;
            if (cmbGender.SelectedIndex == 0)
                newEmploye.Gender = false;
            else
                newEmploye.Gender = true;
            newEmploye.DateOfBirth = DateTime .Parse(dtpDateofBirth.Text);
            newEmploye.StartWorkDate = DateTime.Parse(dtpStarWorkDay.Text);
            newEmploye.FinishWorkDate = DateTime.Parse(dtpFinishWorkDay.Text);
            newEmploye.CreatedEmployeeID = 1;////Değişecek
            newEmploye.RoleID = (int)cmbRoleID.SelectedValue;
            newEmploye.Telephone = txtPhoneNumber.Text;
            newEmploye.Email = txtEmail.Text;
            newEmploye.IsAvaible = checkBoxIsAvailable.Checked;
            newEmploye.Login.Name = txtUserName.Text;
            newEmploye.Login.Password = txtPassword.Text;
            _employeeBLL.SaveBLL(newEmploye);
            RefreshGrid();

        }

       


    }
}
