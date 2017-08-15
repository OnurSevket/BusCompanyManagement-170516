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
    public partial class AddressForm : Form
    {
        public AddressForm()
        {
            InitializeComponent();
        }
        AddressBussiness _addressBll;

        private void AddressForm_Load(object sender, EventArgs e)
        {
            _addressBll = new AddressBussiness();
            cmbCityID.ValueMember = "ID";
            cmbCityID.DisplayMember = "Name";
            CityBussiness _cityBLL = new CityBussiness();
            cmbCityID.DataSource = _cityBLL.GetAllBLL();

            cmbDistrictID.ValueMember = "ID";
            cmbDistrictID.DisplayMember = "Name";
            DistrictBusiness _districtBLL = new DistrictBusiness();
            cmbDistrictID.DataSource = _districtBLL.GetAllBLL();

            cmbEmployeeID.ValueMember = "ID";
            cmbEmployeeID.DisplayMember = "SocialNumber";
            EmployeeBussiness _employeeBLL = new EmployeeBussiness();
            
            cmbEmployeeID.DataSource = _employeeBLL.GetAllBLL();


            RefleshGrid();
        }
        public void RefleshGrid()
        {
            try
            {
                List<Address> addressList = _addressBll.GetAllBLL();
                dgvAddressList.DataSource = null;
                dgvAddressList.DataSource = addressList;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        int selectedID;

        
        private void dgvAddressList_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (dgvAddressList.SelectedRows.Count > 0)
                {
                    DataGridViewRow dr = dgvAddressList.SelectedRows[0];
                    string updateIdInput = dr.Cells[0].Value.ToString();
                    selectedID = int.Parse(updateIdInput);
                    Address saveAdress = _addressBll.GetBLL(selectedID);
                    txtAddress.Text = saveAdress.Name;
                    cmbCityID.SelectedValue = (int)saveAdress.City;
                    cmbDistrictID.SelectedValue = (int)saveAdress.District;
                    cmbEmployeeID.SelectedValue = (int)saveAdress.EmployeeID;
                    string a;
                }

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
                Address newAddress = new Address();

                newAddress.Name = txtAddress.Text;
                newAddress.City = (int)cmbCityID.SelectedValue;
                newAddress.District = (int)cmbDistrictID.SelectedValue;
                newAddress.EmployeeID = (int)cmbEmployeeID.SelectedValue;
                _addressBll.SaveBLL(newAddress);
                RefleshGrid();
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
                Address deleteAddress = _addressBll.GetBLL(selectedID);
                selectedID = 0;
                _addressBll.DeleteBLL(deleteAddress);
                RefleshGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                Address updateAddress = _addressBll.GetBLL(selectedID);
                updateAddress.Name = txtAddress.Text;
                updateAddress.City = (int)cmbCityID.SelectedValue;
                updateAddress.District = (int)cmbDistrictID.SelectedValue;
                updateAddress.EmployeeID = (int)cmbEmployeeID.SelectedValue;


                _addressBll.UpdateBLL(updateAddress);
                RefleshGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
