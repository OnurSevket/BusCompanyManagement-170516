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
    public partial class DistrictForm : Form
    {
        DistrictBusiness _districtBll;
        int selecteID;

        public DistrictForm()
        {
            InitializeComponent();
        }
       
        private void DistrictForm_Load(object sender, EventArgs e)
        {
            _districtBll = new DistrictBusiness();
            RefreshDataGrid();

            cmbCityID.ValueMember = "ID";
            cmbCityID.DisplayMember = "Name";

            CityBussiness _cityBLL = new CityBussiness();
            cmbCityID.DataSource = _cityBLL.GetAllBLL();
        }

        private void RefreshDataGrid()
        {
            try
            {

                List<District> districtList = _districtBll.GetAllBLL();
                dgvDistrictList.DataSource = null;
                dgvDistrictList.DataSource = districtList;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
      
        private void dgvDistrictList_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (dgvDistrictList.SelectedRows.Count > 0)
                {
                    DataGridViewRow dr = dgvDistrictList.SelectedRows[0];
                    string updateDistrict = dr.Cells[0].Value.ToString();
                    selecteID = Convert.ToInt32(updateDistrict);
                    District UpdataValueDistrict = _districtBll.GetBLL(selecteID);                
                    UpdataValueDistrict.ID =(int) cmbCityID.SelectedValue;

                    txtDistrict.Text = UpdataValueDistrict.Name;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            District useDistrict = new District();
            useDistrict.Name = txtDistrict.Text;
            useDistrict.CityID = (int)cmbCityID.SelectedValue;
            _districtBll.SaveBLL(useDistrict);
            RefreshDataGrid();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                District useDistrict = _districtBll.GetBLL(selecteID);
                selecteID = 0;
                _districtBll.DeleteBLL(useDistrict);
                RefreshDataGrid();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            District useDistrict = _districtBll.GetBLL(selecteID);
            useDistrict.Name = txtDistrict.Text;
            useDistrict.CityID = (int)cmbCityID.SelectedValue;
            _districtBll.UpdateBLL(useDistrict);
            RefreshDataGrid();
        }
    }
}
