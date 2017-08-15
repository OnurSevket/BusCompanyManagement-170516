using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserInterfaceLayer
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {

            panel2.Width = 285;
            btnMenu.Visible = false;
            btnMenuClose.Visible = true;

        }

        private void btnMenuClose_Click(object sender, EventArgs e)
        {

            panel2.Width = 41;
            btnMenu.Visible = true;
            btnMenuClose.Visible = false;

        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            BusSeatForm busseat = new UserInterfaceLayer.BusSeatForm();
            busseat.Show();

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void btnUserLogin_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }

        private void ctnCloseMainForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEmployeeRegist_Click(object sender, EventArgs e)
        {
            EmployeeRegistration empRegForm = new EmployeeRegistration();
            empRegForm.Owner = this;
            empRegForm.Show();
        }

        private void btnPassangerRegist_Click(object sender, EventArgs e)
        {
            PassangerRegistrationForm pasRegForm = new PassangerRegistrationForm();
            pasRegForm.Owner = this;
            pasRegForm.Show();

        }

        private void btnGetTicket_Click(object sender, EventArgs e)
        {
            RouteSeatSelectionForm routeSeatForm = new RouteSeatSelectionForm();
            routeSeatForm.Owner = this;
            routeSeatForm.Show();
        }

        private void btnTicket_Click(object sender, EventArgs e)
        {
            TicketForm ticketForm = new TicketForm();
            ticketForm.Owner = this;
            ticketForm.Show();

        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            PaymentForm paymentForm = new PaymentForm();
            paymentForm.Owner = this;
            paymentForm.Show();
        }

        private void btnPaymentType_Click(object sender, EventArgs e)
        {
            PaymentTypeForm paymentTypeForm = new PaymentTypeForm();
            paymentTypeForm.Owner = this;
            paymentTypeForm.Show();
        }

        private void btnBusEmployee_Click(object sender, EventArgs e)
        {
            BusEmployeeForm busEmployeeForm = new BusEmployeeForm();
            busEmployeeForm.Owner = this;
            busEmployeeForm.Show();
        }

        private void btnRoute_Click(object sender, EventArgs e)
        {
            RouteMapForm routeMapForm = new RouteMapForm();
            routeMapForm.Owner = this;
            routeMapForm.Show();
        }

        private void btnBusExpense_Click(object sender, EventArgs e)
        {
            RoadExpenseForm roadExpenseForm = new RoadExpenseForm();
            roadExpenseForm.Owner = this;
            roadExpenseForm.Show();
        }

        private void btnBusRoute_Click(object sender, EventArgs e)
        {
            BusRouteSelectionForm busRouteSelectionForm = new BusRouteSelectionForm();
            busRouteSelectionForm.Owner = this;
            busRouteSelectionForm.Show();
        }

        private void btnBusSeat_Click(object sender, EventArgs e)
        {

            BusSeatForm busSeatForm = new BusSeatForm();
            busSeatForm.Owner = this;
            busSeatForm.Show();
        }

        private void btnBusRegistration_Click(object sender, EventArgs e)
        {
            BusRegistrationForm busRegistrationForm = new BusRegistrationForm();
            busRegistrationForm.Owner = this;
            busRegistrationForm.Show();
        }

        private void btnBusType_Click(object sender, EventArgs e)
        {
            BusTypeForm busTypeForm = new BusTypeForm();
            busTypeForm.Owner = this;
            busTypeForm.Show();
        }

        private void btnBusProperty_Click(object sender, EventArgs e)
        {
            BusPropertyForm busPropertyForm = new BusPropertyForm();
            busPropertyForm.Owner = this;
            busPropertyForm.Show();
        }

        private void btnAddress_Click(object sender, EventArgs e)
        {
            AddressForm addressForm = new AddressForm();
            addressForm.Owner = this;
            addressForm.Show();
        }

        private void btnAuthory_Click(object sender, EventArgs e)
        {
            AuthoryForm authoryForm = new AuthoryForm();
            authoryForm.Owner = this;
            authoryForm.Show();

        }

        private void btnOffice_Click(object sender, EventArgs e)
        {
            OfficeForm officeForm = new OfficeForm();
            officeForm.Owner = this;
            officeForm.Show();
        }

        private void btnCity_Click(object sender, EventArgs e)
        {
            CityForm cityForm = new CityForm();
            cityForm.Owner = this;
            cityForm.Show();
        }

        private void btnDistrict_Click(object sender, EventArgs e)
        {

            DistrictForm districtForm = new DistrictForm();
            districtForm.Owner = this;
            districtForm.Show();
        }

        private void btnWorkHour_Click(object sender, EventArgs e)
        {
            WorkHourForm workHourForm = new WorkHourForm();
            workHourForm.Owner = this;
            workHourForm.Show();
        }

        private void btnRole_Click(object sender, EventArgs e)
        {
            RoleForm roleForm = new RoleForm();
            roleForm.Owner = this;
            roleForm.Show();
        }


        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

//        select ID from Login Name='Name' and Password = 'Pas1'

//ID  ->> EmployeID



//select ID from LoginPassenger Name = 'Name' and Password = 'Pas1'

//ID  ->> PassengerID
    }
}
