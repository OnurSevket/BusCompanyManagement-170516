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
    public partial class BusPropertyForm : Form
    {
        public BusPropertyForm()
        {
            InitializeComponent();
        }
        BusPropertyBussiness _busPropertBll;
        private void BusPropertyForm_Load(object sender, EventArgs e)
        {
            _busPropertBll = new BusPropertyBussiness();
            RefleshGrid();

        }
        public void RefleshGrid()
        {

            try
            {
                List<BusProperty> properyList = _busPropertBll.GetAllBLL();
                dgvBusProperyList.DataSource = null;
                dgvBusProperyList.DataSource = properyList;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        int selectedID;

        private void dgvBusProperyList_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (dgvBusProperyList.SelectedRows.Count > 0)
                {
                    DataGridViewRow dr = dgvBusProperyList.SelectedRows[0];
                    string updateIdInput = dr.Cells[0].Value.ToString();
                    selectedID = int.Parse(updateIdInput);
                    BusProperty updateBusProperty = _busPropertBll.GetBLL(selectedID);
                    txtBusProperty.Text = updateBusProperty.Name;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSaveBusRegist_Click(object sender, EventArgs e)
        {
            try
            {
                BusProperty newBusPropery = new BusProperty();
                newBusPropery.Name = txtBusProperty.Text;
                _busPropertBll.SaveBLL(newBusPropery);


                RefleshGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDeleteBusRegist_Click(object sender, EventArgs e)
        {
            try
            {
                BusProperty deleteProp = _busPropertBll.GetBLL(selectedID);
                selectedID = 0;
                _busPropertBll.DeleteBLL(deleteProp);
                RefleshGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdateBusRegist_Click(object sender, EventArgs e)
        {
            try
            {
                BusProperty updateBusPropery = _busPropertBll.GetBLL(selectedID);
                updateBusPropery.Name = txtBusProperty.Text;
                _busPropertBll.UpdateBLL(updateBusPropery);




                RefleshGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


    }
}
