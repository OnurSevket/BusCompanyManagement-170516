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
    public partial class BusRegistrationForm : Form
    {
        public BusRegistrationForm()
        {
            InitializeComponent();
        }

        BusBussiness _busBLL;
        //Bus _busSelected;
        int selectedID;

        private void BusRegistrationForm_Load(object sender, EventArgs e)
        {
            _busBLL = new BusBussiness();
            refreshGrid();

            cmbBusTypeID.ValueMember = "ID";
            cmbBusTypeID.DisplayMember = "Name";
            BusTypeBussiness useBusType = new BusTypeBussiness();
            cmbBusTypeID.DataSource = useBusType.GetAllBLL();         
        }

        private void refreshGrid()
        {
            try
            {
                List<Bus> BusList = _busBLL.GetAllBLL();
                dgvBusList.DataSource = null;
                dgvBusList.DataSource = BusList;
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
                Bus saveBus = new Bus();
                saveBus.Brand = txtBrand.Text;
                saveBus.Model = txtModel.Text;
                saveBus.Plate = txtPlate.Text;
                saveBus.Year = Convert.ToDateTime(mtxtYear.Text);
                saveBus.BusTypeID = (int)cmbBusTypeID.SelectedValue;
                _busBLL.SaveBLL(saveBus);
                refreshGrid();
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
                Bus useBus = new Bus();
                selectedID = 0;
                _busBLL.DeleteBLL(useBus);
                refreshGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdateBusRegist_Click(object sender, EventArgs e)
        {
            Bus updateBus = new Bus();
            updateBus.Brand = txtBrand.Text;
            updateBus.Model = txtModel.Text;
            updateBus.Plate = txtPlate.Text;
            updateBus.Year = Convert.ToDateTime(mtxtYear.Text);
            updateBus.BusTypeID = (int)cmbBusTypeID.SelectedValue;
            _busBLL.UpdateBLL(updateBus);
            refreshGrid();
        }

        private void dgvBusList_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (dgvBusList.SelectedRows.Count > 0 )
                {
                    DataGridViewRow dr = dgvBusList.SelectedRows[0];
                    string updateInput = dr.Cells[0].Value.ToString();
                    selectedID = Convert.ToInt32(updateInput);


                    Bus UpdateBus = _busBLL.GetBLL(selectedID);
                    txtBrand.Text = UpdateBus.Brand;
                    txtModel.Text = UpdateBus.Model;
                    mtxtYear.Text = UpdateBus.Year.ToString();
                    txtPlate.Text = UpdateBus.Plate;

                    UpdateBus.ID = (int)cmbBusTypeID.SelectedValue;

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
