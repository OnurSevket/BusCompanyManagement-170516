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
    public partial class TicketForm : Form
    {
        public TicketForm()
        {
            InitializeComponent();
        }

        TicketBussiness _ticketBll = new TicketBussiness();
        int selectedID;

        private void TicketForm_Load(object sender, EventArgs e)
        {
            btnNextStep.Visible = false;

            RefreshGrid();

            cmbEmployeeID.ValueMember = "ID";
            cmbPassengerID.DisplayMember = "ID";
            EmployeeBussiness empBLL = new EmployeeBussiness();
            cmbEmployeeID.DataSource = empBLL.GetAllBLL();

            cmbPassengerID.ValueMember = "ID";
            cmbPassengerID.DisplayMember = "ID";
            PassengerBussiness _pass = new PassengerBussiness();
            cmbPassengerID.DataSource = _pass.GetAllBLL();

            cmbRouteID.ValueMember = "ID";
            cmbRouteID.DisplayMember = "ID";
            RouteMapBussiness _route = new RouteMapBussiness();
            cmbRouteID.DataSource = _route.GetAllBLL();

            cmbSeatID.DisplayMember = "ID";
            cmbSeatID.ValueMember = "ID";
            BusSeatBussiness busType = new BusSeatBussiness();
            cmbSeatID.DataSource = busType.GetAllBLL();

            cmbTicketID.DisplayMember = "ID";
            cmbTicketID.ValueMember = "ID";
            cmbTicketID.DataSource = _ticketBll.GetAllBLL();

            cmbTravelId.ValueMember = "ID";
            cmbTravelId.DisplayMember = "ID";
            TravelBussiness _travel = new TravelBussiness();
            cmbTravelId.DataSource = _travel.GetAllBLL();

            cmbTicketID.ValueMember = "ID";
            cmbTicketID.DisplayMember = "ID";
            PaymentBussiness _payy = new PaymentBussiness();
            cmbTicketID.DataSource = _payy.GetAllBLL();
            
        }

        private void RefreshGrid()
        {
            try
            {

                List<Ticket> districtList = _ticketBll.GetAllBLL();
                dgvTicketlist.DataSource = null;
                dgvTicketlist.DataSource = districtList;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Ticket saveTicket = new Ticket();
            saveTicket.TravelID = (int)cmbTravelId.SelectedValue;
            saveTicket.EmployeeID = (int)cmbEmployeeID.SelectedValue;
            saveTicket.BusSeatID = (int)cmbSeatID.SelectedValue;
            saveTicket.PassangerID = (int)cmbPassengerID.SelectedValue;
            saveTicket.PaymentID = (int)cmbTicketID.SelectedValue;
            saveTicket.RouteMapID = (int)cmbRouteID.SelectedValue;
            saveTicket.CreateTicketDate = Convert.ToDateTime(dtpCreateTime.Text);

            #region veri kaydedilirse buton visible olucak
            if (_ticketBll.SaveBLL(saveTicket))
                btnNextStep.Visible = true; 
            #endregion


            RefreshGrid();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                Ticket deleteTicket = _ticketBll.GetBLL(selectedID);
                selectedID = 0;
                _ticketBll.DeleteBLL(deleteTicket);
                RefreshGrid();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Ticket updateTicket = _ticketBll.GetBLL(selectedID);
            updateTicket.BusSeatID = (int)cmbSeatID.SelectedValue;
            updateTicket.CreateTicketDate = Convert.ToDateTime(dtpCreateTime.Text);
            updateTicket.EmployeeID = (int)cmbEmployeeID.SelectedValue;
            updateTicket.PassangerID = (int)cmbPassengerID.SelectedValue;
            updateTicket.PaymentID = (int)cmbTicketID.SelectedValue;
            updateTicket.RouteMapID = (int)cmbRouteID.SelectedValue;
            updateTicket.TravelID = (int)cmbTravelId.SelectedValue;

            _ticketBll.UpdateBLL(updateTicket);
            RefreshGrid();
        }

        private void dgvTicketlist_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow dr = dgvTicketlist.SelectedRows[0];
                string update = dr.Cells[0].Value.ToString();
                selectedID = Convert.ToInt32(update);
                Ticket updateTicket = _ticketBll.GetBLL(selectedID);
                dtpCreateTime.Text = updateTicket.CreateTicketDate.ToString();
                updateTicket.PaymentID = (int)cmbTicketID.SelectedValue;
                updateTicket.PassangerID = (int)cmbPassengerID.SelectedValue;
                updateTicket.RouteMapID = (int)cmbRouteID.SelectedValue;
                updateTicket.TravelID = (int)cmbTravelId.SelectedValue;
                updateTicket.EmployeeID = (int)cmbEmployeeID.SelectedValue;
                updateTicket.BusSeatID = (int)cmbSeatID.SelectedValue;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnNextStep_Click(object sender, EventArgs e)
        {
            PaymentTypeForm usePaymentType = new PaymentTypeForm();
            usePaymentType.Show();
            this.Hide();
        }
    }
}
