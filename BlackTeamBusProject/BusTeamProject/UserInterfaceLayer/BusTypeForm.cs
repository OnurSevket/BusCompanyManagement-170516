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
    public partial class BusTypeForm : Form
    {
        public BusTypeForm()
        {
            InitializeComponent();
        }
        BusTypeBussiness _busTypeBusiness;

        int selectIdD;
        BusType selectedBusType;
        private void dgvAuthoryNameList_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (dgvBusTypeList.SelectedRows.Count > 0)
                {
                    DataGridViewRow dr = dgvBusTypeList.SelectedRows[0];
                    string updateInput = dr.Cells[0].Value.ToString();
                    selectIdD = Convert.ToInt32(updateInput);
                    selectedBusType = _busTypeBusiness.GetBLL(selectIdD);
                    numBackDoorIndex.Value = selectedBusType.BackDoorIndex.Value;
                    numSeatCount.Value = selectedBusType.SeatCount.Value;
                    txtBusTypeName.Text = selectedBusType.Name;

                    lstBusProperty.Items.Clear();
                    foreach (BusProperty item in selectedBusType.BusPropertList)
                    {
                        lstBusProperty.Items.Add(item);
                    }


                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void BusTypeForm_Load(object sender, EventArgs e)
        {
            _busTypeBusiness = new BusTypeBussiness();
            RefreshGrid();
            BusPropertyBussiness _busPropertyBLL = new BusPropertyBussiness();
            cmbBusPropertyTablo.DataSource = _busPropertyBLL.GetAllBLL();
            cmbBusPropertyTablo.ValueMember = "ID";
            cmbBusPropertyTablo.DisplayMember = "Name";




        }

        private void RefreshGrid()
        {
            try
            {
                List<BusType> busTypeList = _busTypeBusiness.GetAllBLL();
                dgvBusTypeList.DataSource = null;
                dgvBusTypeList.DataSource = busTypeList;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnSaveBusRegist_Click(object sender, EventArgs e)
        {
            BusType bustype = new BusType();
            bustype.Name = txtBusTypeName.Text;
            bustype.BackDoorIndex = (int)numBackDoorIndex.Value;
            bustype.SeatCount =(int) numSeatCount.Value;

            foreach (BusProperty item in lstBusProperty.Items)
            {
                bustype.BusPropertList.Add(item);
            }

            _busTypeBusiness.SaveBLL(bustype);

            RefreshGrid();
            ControlsClear();

        }

        private void ControlsClear()
        {
            lstBusProperty.Items.Clear();
            txtBusTypeName.Text = "";
            numSeatCount.Value = 0;
            numBackDoorIndex.Value = 0;
        }

        private void btnDeleteBusRegist_Click(object sender, EventArgs e)
        {
            BusType deleteBustype = selectedBusType;
            _busTypeBusiness.DeleteBLL(deleteBustype);
            RefreshGrid();
            selectedBusType = null;
        }

        private void btnUpdateBusRegist_Click(object sender, EventArgs e)
        {
            try
            {
                BusType updateBusType = selectedBusType;
                updateBusType.Name = txtBusTypeName.Text;
                updateBusType.SeatCount =(int) numSeatCount.Value;
                updateBusType.BackDoorIndex =(int) numBackDoorIndex.Value;
                updateBusType.BusPropertList.Clear();
                
                foreach (BusProperty item in lstBusProperty.Items)
                {
                    updateBusType.BusPropertList.Add(item);
                }

                _busTypeBusiness.UpdateBLL(updateBusType);
                RefreshGrid();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

  

        private void btnAddListBox_Click(object sender, EventArgs e)
        {
            BusProperty useBusProperty = (BusProperty)cmbBusPropertyTablo.SelectedItem;
            lstBusProperty.Items.Add(useBusProperty);
            
        }

        private void btnRemoveListBox_Click(object sender, EventArgs e)
        {
            if (lstBusProperty.SelectedItem != null)
                lstBusProperty.Items.Remove(lstBusProperty.SelectedItem);
        }
    }
}
