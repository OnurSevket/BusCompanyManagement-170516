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
    public partial class WorkHourForm : Form
    {
        public WorkHourForm()
        {
            InitializeComponent();
        }
        WorkHourBussiness _workHourBll;
        private void WorkHourForm_Load(object sender, EventArgs e)
        {
            _workHourBll = new WorkHourBussiness();
            cmbEmployeeID.ValueMember = "ID";
            cmbEmployeeID.DisplayMember = "SocialNumber";
            EmployeeBussiness _employeBLL = new EmployeeBussiness();
            cmbEmployeeID.DataSource = _employeBLL.GetAllBLL();


            RefleshGrid();
        }
        public void RefleshGrid()
        {
            try
            {
                List<WorkHour> workHourList = _workHourBll.GetAllBLL();
                dgvWorkHourList.DataSource = null;
                dgvWorkHourList.DataSource = workHourList;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        int selectedID;
        private void dgvWorkHourList_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (dgvWorkHourList.SelectedRows.Count > 0)
                {
                    DataGridViewRow dr = dgvWorkHourList.SelectedRows[0];
                    string updateIdInput = dr.Cells[0].Value.ToString();
                    selectedID = int.Parse(updateIdInput);
                    WorkHour updateAuthory = _workHourBll.GetBLL(selectedID);
                    txtWorkHourName.Text = updateAuthory.Name;
                    mtxtStartHour.Text = updateAuthory.StartHour;
                    mtxtEndHour.Text = updateAuthory.EndHour;
                    cmbEmployeeID.SelectedItem = updateAuthory.EmployeeId;
                }

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
                WorkHour newWorkHour = new WorkHour();
               
                newWorkHour.Name = txtWorkHourName.Text;
                newWorkHour.StartHour = mtxtStartHour.Text;
                newWorkHour.EndHour = mtxtEndHour.Text;
                newWorkHour.EmployeeId = (int)cmbEmployeeID.SelectedValue;

                _workHourBll.SaveBLL(newWorkHour);
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
                WorkHour deleteWorkHour = _workHourBll.GetBLL(selectedID);
                selectedID = 0;
                _workHourBll.DeleteBLL(deleteWorkHour);
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
                WorkHour updateWorkHour = _workHourBll.GetBLL(selectedID);
                updateWorkHour.Name = txtWorkHourName.Text;
                updateWorkHour.StartHour = mtxtStartHour.Text;
                updateWorkHour.EndHour = mtxtEndHour.Text;
                updateWorkHour.EmployeeId =(int) cmbEmployeeID.SelectedValue;

                
                _workHourBll.UpdateBLL(updateWorkHour);
                RefleshGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
