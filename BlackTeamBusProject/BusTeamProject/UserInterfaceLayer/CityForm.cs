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
    public partial class CityForm : Form
    {
        CityBussiness _cityBll;
        int selectedID;

        public CityForm()
        {
            InitializeComponent();
        }
       
        private void dgvCityList_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            try
            {
                if (dgvCityList.SelectedRows.Count > 0)
                {
                    DataGridViewRow dr = dgvCityList.SelectedRows[0];
                    string updateIdInput = dr.Cells[0].Value.ToString();
                    selectedID = int.Parse(updateIdInput);
                    City updateAuthory = _cityBll.GetBLL(selectedID);
                    txtCityName.Text = updateAuthory.Name;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void CityForm_Load(object sender, EventArgs e)
        {

            _cityBll = new CityBussiness();
            RefleshGrid();

        }

        public void RefleshGrid()
        {
            try
            {
                List<City> cityList = _cityBll.GetAllBLL();
                dgvCityList.DataSource = null;
                dgvCityList.DataSource = cityList;
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
                City newCity = new City();
                newCity.Name = txtCityName.Text;
                _cityBll.SaveBLL(newCity);
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
                City updateCity = _cityBll.GetBLL(selectedID);
                updateCity.Name = txtCityName.Text;
                _cityBll.UpdateBLL(updateCity);
                RefleshGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
