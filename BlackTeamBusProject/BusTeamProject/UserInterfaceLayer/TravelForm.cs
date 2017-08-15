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
    public partial class TravelForm : Form
    {
        TravelBussiness _travelBLL;
        int selectedID;

        public TravelForm()
        {
            InitializeComponent();
        }
      
        private void dgvTravelList_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (dgvTravelList.SelectedRows.Count > 0)
                {
                    DataGridViewRow dr = dgvTravelList.SelectedRows[0];
                    string updateIdInput = dr.Cells[0].Value.ToString();
                    selectedID = int.Parse(updateIdInput);
                    Travel selectTravel = _travelBLL.GetBLL(selectedID);
                    txtTravelCode.Text = selectTravel.TravelNumberName;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void TravelForm_Load(object sender, EventArgs e)
        {
            _travelBLL = new TravelBussiness();
            RefleshGrid();
        }

        public void RefleshGrid()
        {
            try
            {
                List<Travel> travelList = _travelBLL.GetAllBLL();
                dgvTravelList.DataSource = null;
                dgvTravelList.DataSource = travelList;
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
                Travel newTravel = new Travel();
                newTravel.TravelNumberName = txtTravelCode.Text;
                _travelBLL.SaveBLL(newTravel);
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
                Travel useDistrict = _travelBLL.GetBLL(selectedID);
                selectedID = 0;
                _travelBLL.DeleteBLL(useDistrict);
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
                Travel updateTravel = _travelBLL.GetBLL(selectedID);
                updateTravel.TravelNumberName = txtTravelCode.Text;
                _travelBLL.UpdateBLL(updateTravel);
                RefleshGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
