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
    public partial class BusSeatForm : Form
    {
        BusSeatBussiness _busSeatBLL;
        int selectedID;

        public BusSeatForm()
        {
            InitializeComponent();
        }

        private void dgvBusSeatList_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (dgvBusSeatList.SelectedRows.Count > 0)
                {
                    DataGridViewRow dr = dgvBusSeatList.SelectedRows[0];
                    string updateInput = dr.Cells[0].Value.ToString();
                    selectedID = int.Parse(updateInput);
                    BusSeat updateBusSeat = _busSeatBLL.GetBLL(selectedID);

                    cmbBusID.SelectedValue = updateBusSeat.BusID;
                    cmbBusTypeID.SelectedValue = updateBusSeat.BusTypeID;
                    numSeatNumber.Value = updateBusSeat.SeatNumber.Value;
                    bool checkedboxValue;
                    if (checkbIsWindow.Checked)
                    {
                        checkedboxValue = true;
                    }
                    else
                    {
                        checkedboxValue = false;
                    }
                    checkedboxValue = (bool)updateBusSeat.IsWindow;
                  
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
                List<BusSeat> busSeatList = _busSeatBLL.GetAllBLL();
                dgvBusSeatList.DataSource = null;
                dgvBusSeatList.DataSource = busSeatList;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void BusSeatForm_Load(object sender, EventArgs e)
        {
            _busSeatBLL = new BusSeatBussiness();
            RefreshGrid();


            cmbBusID.ValueMember = "ID";
            cmbBusID.DisplayMember = "Name";
            BusBussiness _busBll = new BusBussiness();
            cmbBusID.DataSource = _busBll.GetAllBLL();

            cmbBusTypeID.ValueMember = "ID";
            cmbBusTypeID.DisplayMember = "Name";
            BusTypeBussiness _busTypeBll = new BusTypeBussiness();
            cmbBusTypeID.DataSource = _busTypeBll.GetAllBLL();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            try
            {
                BusSeat useBusSeat = new BusSeat();

                useBusSeat.BusID = (int)cmbBusID.SelectedValue;
                useBusSeat.BusTypeID = (int)cmbBusTypeID.SelectedValue;
                useBusSeat.SeatNumber = (int)numSeatNumber.Value;
                bool checkedboxValue;
                if (checkbIsWindow.Checked)
                {
                    checkedboxValue = true;
                }
                else
                {
                    checkedboxValue = false;
                }
                useBusSeat.IsWindow = checkedboxValue;
                    
                _busSeatBLL.SaveBLL(useBusSeat);
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
                BusSeat useBusSeat = _busSeatBLL.GetBLL(selectedID);
                selectedID = 0;
                _busSeatBLL.DeleteBLL(useBusSeat);
                RefreshGrid();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            BusSeat updateBusSeat = _busSeatBLL.GetBLL(selectedID);

            updateBusSeat.BusID = (int)cmbBusID.SelectedValue;
            updateBusSeat.BusTypeID = (int)cmbBusTypeID.SelectedValue;
            updateBusSeat.SeatNumber = (int)numSeatNumber.Value;
            bool checkedboxValue;
            if (checkbIsWindow.Checked)
            {
                checkedboxValue = true;
            }
            else
            {
                checkedboxValue = false;
            }
            updateBusSeat.IsWindow = checkedboxValue;

            _busSeatBLL.UpdateBLL(updateBusSeat);
            RefreshGrid();

        }
    }
}
