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
    public partial class BusRouteSelectionForm : Form
    {
        public BusRouteSelectionForm()
        {
            InitializeComponent();
        }

        private void BusRouteSelectionForm_Load(object sender, EventArgs e)
        {
            changeEnabled(false);
            DistrictBusiness _districtFrom = new DistrictBusiness();
            cmbFirstDeparture.DataSource = _districtFrom.GetAllBLL();
            cmbFirstDeparture.ValueMember = "CityID";
            cmbFirstDeparture.DisplayMember = "Name";
            DistrictBusiness _districtTo = new DistrictBusiness();
            cmbLastArrival.DataSource = _districtTo.GetAllBLL();
            cmbLastArrival.ValueMember = "CityID";
            cmbLastArrival.DisplayMember = "Name";
            DistrictBusiness _districtDepature = new DistrictBusiness();
            cmbMiddleDeparture.DataSource = _districtDepature.GetAllBLL();
            cmbMiddleDeparture.ValueMember = "CityID";
            cmbMiddleDeparture.DisplayMember = "Name";
            DistrictBusiness _districtArrival = new DistrictBusiness();
            cmbMiddleArrival.DataSource = _districtArrival.GetAllBLL();
            cmbMiddleArrival.ValueMember = "CityID";
            cmbMiddleArrival.DisplayMember = "Name";


        }
        private void changeEnabled(bool value)
        {
            cmbMiddleDeparture.Enabled = value;
            cmbMiddleArrival.Enabled = value;
            txtMiddleDepartureHour.Enabled = value;
            txtMiddleArrivalHour.Enabled = value;
            btnAddListBox.Enabled = value;
            btnRemoveListBox.Enabled = value;
            lstMiddleRouteStop.Items.Clear();
            btnCreateRoute.Enabled = !value;
            btnSave.Enabled = value;
            cmbFirstDeparture.Enabled = !value;
            cmbLastArrival.Enabled = !value;
            txtDepartureHour.Enabled = !value;
        }

        private void btnCreateRoute_Click(object sender, EventArgs e)
        {
            changeEnabled(true);
            if (cmbFirstDeparture.Text == "" || cmbLastArrival.Text == "" || txtDepartureHour.Text == "")
            { return; }
            else
            {
                string kalkisString = (cmbFirstDeparture.SelectedValue + "");
                int kalkisInt = int.Parse(kalkisString);
                if (kalkisInt / 10 <= 0)
                {
                    kalkisString = 0 + "" + kalkisString;
                }
                string varisString = (cmbLastArrival.SelectedValue + "");
                int varisInt = int.Parse(varisString);
                if (varisInt / 10 <= 0)
                {
                    varisString = 0 + "" + varisString;
                }
                lblTravelNumber.Text = kalkisString + "" + varisString + txtDepartureHour.Text;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            changeEnabled(false);
            txtMiddleDepartureHour.Text = "";
            txtMiddleArrivalHour.Text = "";
            lstMiddleRouteStop.Items.Clear();
            lblTravelNumber.Text = "";
        }
        int before = 0;
        List<RouteMap> _roadList = new List<RouteMap>();
        private void btnAddListBox_Click(object sender, EventArgs e)
        {
            routeMapBLL = new RouteMapBussiness();
            if (cmbMiddleDeparture.SelectedItem == null || cmbMiddleArrival.SelectedItem == null || txtMiddleDepartureHour.Text == "" || txtMiddleArrivalHour.Text == "")
            {
                MessageBox.Show("Lütfen boş alanları doldurunuz");
                return;
            }
            else
            {
                RouteMap _routeMapMiddle = new RouteMap();
                _routeMapMiddle.Departure = (int)cmbMiddleDeparture.SelectedValue;
                _routeMapMiddle.Arrival = (int)cmbMiddleArrival.SelectedValue;
                _routeMapMiddle.StartDate = DateTime.Parse(txtMiddleDepartureHour.Text);
                _routeMapMiddle.EndDate = DateTime.Parse(txtMiddleArrivalHour.Text);
                _routeMapMiddle.Price = decimal.Parse(mtbPrice.Text);
                if (before == 0)
                    _routeMapMiddle.BeforeRouteID = (int)cmbFirstDeparture.SelectedValue;
                else
                    _routeMapMiddle.BeforeRouteID = before;
                before = (int)_routeMapMiddle.Departure;
                _roadList.Add(_routeMapMiddle);
                lstMiddleRouteStop.DataSource = null;
                lstMiddleRouteStop.DataSource = _roadList;

            }
        }

        private void btnRemoveListBox_Click(object sender, EventArgs e)
        {

        }
        RouteMapBussiness routeMapBLL;
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (RouteMap item in lstMiddleRouteStop.Items)
                {
                    item.TravelID =int.Parse( lblTravelNumber.Text);
                    RouteMapBussiness _routeMap = new RouteMapBussiness();
                    bool  result= _routeMap.SaveBLL(item);
                    if(!result)
                        MessageBox.Show("Hata : Route Map gelmedi");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
