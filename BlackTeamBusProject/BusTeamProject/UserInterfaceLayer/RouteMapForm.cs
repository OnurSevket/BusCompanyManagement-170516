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
    public partial class RouteMapForm : Form
    {
        public RouteMapForm()
        {
            InitializeComponent();
        }
        RouteMapBussiness _routeMapBLL;
        private void RouteMapForm_Load(object sender, EventArgs e)
        {
            _routeMapBLL = new RouteMapBussiness();
            RefreshGrid();

            
            cmbDepartureID.ValueMember = "ID";
            cmbDepartureID.DisplayMember = "Name";
            DistrictBusiness _district = new DistrictBusiness();
            cmbDepartureID.DataSource = _district.GetAllBLL();

            cmbBeforeID.ValueMember = "ID";
            cmbBeforeID.DisplayMember = "Name";
            RouteMap _routeMap = new RouteMap();
            cmbBeforeID.DataSource = _routeMapBLL.GetAllBLL();

            cmbArrivalID.ValueMember = "ID";
            cmbArrivalID.DisplayMember = "Name";
            //buda arrival için
            cmbArrivalID.DataSource = _district.GetAllBLL();


            cmbTravelID.ValueMember = "ID";
            cmbTravelID.DisplayMember = "ID";
            cmbTravelID.DataSource = _district.GetAllBLL();




        }

        private void RefreshGrid()
        {
            try
            {
                List<RouteMap> routeMapList = new List<RouteMap>();
                dgvRouteMapList.DataSource = null;
                dgvRouteMapList.DataSource = routeMapList;
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
                RouteMap useRouteMap = new RouteMap();
                useRouteMap.Arrival = (int)cmbArrivalID.SelectedValue;
                useRouteMap.BeforeRouteID = (int)cmbBeforeID.SelectedValue;
                useRouteMap.TravelID = (int)cmbTravelID.SelectedValue;
                useRouteMap.Departure = (int)cmbDepartureID.SelectedValue;
                useRouteMap.Price = (decimal)numPrice.Value;
                useRouteMap.StartDate = Convert.ToDateTime(mtxtStartDate.Text);
                useRouteMap.EndDate = Convert.ToDateTime(mtxtEndDate.Text);
                _routeMapBLL.SaveBLL(useRouteMap);
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
                RouteMap useRouteMap = _routeMapBLL.GetBLL(selectedID);
                selectedID = 0;
                _routeMapBLL.DeleteBLL(useRouteMap);
                RefreshGrid();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            RouteMap updateRouteMap = _routeMapBLL.GetBLL(selectedID);
            updateRouteMap.Price = Convert.ToDecimal(numPrice.Value);
            updateRouteMap.Arrival = Convert.ToInt32(cmbArrivalID.SelectedValue);
            updateRouteMap.BeforeRouteID = Convert.ToInt32(cmbBeforeID.SelectedValue);
            updateRouteMap.Departure = Convert.ToInt32(cmbDepartureID.SelectedValue);
            updateRouteMap.TravelID = Convert.ToInt32(cmbTravelID.SelectedValue);
            updateRouteMap.StartDate = Convert.ToDateTime(mtxtStartDate.Text);
            updateRouteMap.EndDate = Convert.ToDateTime(mtxtEndDate.Text);

            _routeMapBLL.UpdateBLL(updateRouteMap);
            RefreshGrid();
        }
        int selectedID;
        private void dgvRouteMapList_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (dgvRouteMapList.SelectedRows.Count>0)
                {
                    DataGridViewRow dr = dgvRouteMapList.SelectedRows[0];
                    string updateInput = dr.Cells[0].Value.ToString();
                    selectedID = int.Parse(updateInput);
                    RouteMap updateRouteMap = _routeMapBLL.GetBLL(selectedID);

                    cmbTravelID.SelectedValue = updateRouteMap.TravelID;
                    cmbDepartureID.SelectedValue = updateRouteMap.Departure;
                    cmbBeforeID.SelectedValue = updateRouteMap.BeforeRouteID;
                    cmbArrivalID.SelectedValue = updateRouteMap.Arrival;
                    mtxtStartDate.Text = updateRouteMap.StartDate.ToString();
                    mtxtEndDate.Text = updateRouteMap.EndDate.ToString();
                    numPrice.Value = updateRouteMap.Price.Value;
                    
                    
                    



                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
