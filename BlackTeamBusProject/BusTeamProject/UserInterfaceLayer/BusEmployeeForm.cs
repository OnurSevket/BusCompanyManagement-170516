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
    public partial class BusEmployeeForm : Form
    {
        public BusEmployeeForm()
        {
            InitializeComponent();
        }
        BusEmployeeBussiness _BuEmpBLL = new BusEmployeeBussiness();
        

        private void BusEmployeeForm_Load(object sender, EventArgs e)
        {
            RefreshGrid();

            cmbBusID.ValueMember = "ID";
            cmbBusID.DisplayMember = "ID";
            BusBussiness busBLL = new BusBussiness();
            cmbBusID.DataSource = busBLL.GetAllBLL();

            cmbEmployeeID.ValueMember = "ID";
            cmbEmployeeID.DisplayMember = "ID";
            EmployeeBussiness empBLL = new EmployeeBussiness();
            cmbEmployeeID.DataSource = empBLL.GetAllBLL();

            cmbRouteMapID.ValueMember = "ID";
            cmbRouteMapID.DisplayMember = "ID";
            RouteMapBussiness routeBLL = new RouteMapBussiness();
            cmbRouteMapID.DataSource = routeBLL.GetAllBLL();
        }

        private void RefreshGrid()
        {
            try
            {

                List<BusEmployee> busEmployeeList = _BuEmpBLL.GetAllBLL();
                dgvBusEmployee.DataSource = null;
                dgvBusEmployee.DataSource = busEmployeeList;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            BusEmployee saveBusEmp = new BusEmployee();
            saveBusEmp.BusID = (int)cmbBusID.SelectedValue;
            saveBusEmp.Employee = (int)cmbEmployeeID.SelectedValue;
            saveBusEmp.RouteMapID = (int)cmbRouteMapID.SelectedValue;
            saveBusEmp.CreateDate = Convert.ToDateTime(dtpCreateDate.Value);

            _BuEmpBLL.SaveBLL(saveBusEmp);
            RefreshGrid();
        }

        int selectedID;
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                BusEmployee deleteBusEmployee = _BuEmpBLL.GetBLL(selectedID);
                selectedID = 0;
                _BuEmpBLL.DeleteBLL(deleteBusEmployee);
                RefreshGrid();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            BusEmployee updateBusEmp = _BuEmpBLL.GetBLL(selectedID);
            updateBusEmp.BusID = (int)cmbBusID.SelectedValue;
            updateBusEmp.CreateDate = Convert.ToDateTime(dtpCreateDate.Value);
            updateBusEmp.RouteMapID = Convert.ToInt32(cmbRouteMapID.SelectedValue);
            updateBusEmp.Employee = (int)cmbEmployeeID.SelectedValue;

            _BuEmpBLL.UpdateBLL(updateBusEmp);
            RefreshGrid();
        }

        private void dgvBusEmployee_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
               if(dgvBusEmployee.SelectedRows.Count > 0 )
                {
                    DataGridViewRow dr = dgvBusEmployee.SelectedRows[0];
                    string updateBusEmployee = dr.Cells[0].Value.ToString();
                    selectedID = int.Parse(updateBusEmployee);
                    BusEmployee updateBusValue = _BuEmpBLL.GetBLL(selectedID);
                    updateBusValue.BusID = (int)cmbBusID.SelectedValue;
                    updateBusValue.Employee = (int)cmbEmployeeID.SelectedValue;
                    updateBusValue.RouteMapID = (int)cmbRouteMapID.SelectedValue;
                    updateBusValue.CreateDate = Convert.ToDateTime(dtpCreateDate.Value);
                   
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
