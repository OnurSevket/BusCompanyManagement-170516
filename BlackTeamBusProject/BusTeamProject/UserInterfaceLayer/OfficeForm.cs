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
    public partial class OfficeForm : Form
    {
        public OfficeForm()
        {
            InitializeComponent();
        }
        OfficeBussiness _officeBll;
        private void OfficeForm_Load(object sender, EventArgs e)
        {
            _officeBll = new OfficeBussiness();
            DistrictBusiness _districtBussines = new DistrictBusiness();
            cmbDistrict.DataSource = _districtBussines.GetAllBLL();
            cmbDistrict.ValueMember = "ID";
            cmbDistrict.DisplayMember = "Name";
            EmployeeBussiness _employeeBussiness = new EmployeeBussiness();
            cmbEmplyee.DataSource = _employeeBussiness.GetAllBLL();
            RefleshGrid();
        }
        public void RefleshGrid()
        {

            try
            {
                List<Office> officeList = _officeBll.GetAllBLL();
                dgvOfficeList.DataSource = null;
                dgvOfficeList.DataSource = officeList;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        int selectedID;
        Office selectOffice;
        private void dgvOfficeList_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (dgvOfficeList.SelectedRows.Count > 0)
                {
                    DataGridViewRow dr = dgvOfficeList.SelectedRows[0];
                    string updateIdInput = dr.Cells[0].Value.ToString();
                    selectedID = int.Parse(updateIdInput);
                    selectOffice = _officeBll.GetBLL(selectedID);
                    txtOfficeName.Text = selectOffice.OfficeName;
                    chkOffice.Checked = (bool)selectOffice.IsCenterOffice;
                    cmbDistrict.SelectedItem = selectOffice.DistictID;

                    lstEmployee.Items.Clear();
                    foreach (Employee item in selectOffice.EmployeeList)
                    {
                        lstEmployee.Items.Add(item);
                    }
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
                Office newOffice = new Office();
                newOffice.OfficeName = txtOfficeName.Text;
                newOffice.IsCenterOffice = chkOffice.Checked;
                newOffice.DistictID =(int)cmbDistrict.SelectedValue;

                foreach (Employee item in lstEmployee.Items)
                {
                    newOffice.EmployeeList.Add(item);
                }

                _officeBll.SaveBLL(newOffice);
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
                Office deleteOffice = _officeBll.GetBLL(selectedID);
                selectedID = 0;
                _officeBll.DeleteBLL(deleteOffice);
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
                Office updateOffice = _officeBll.GetBLL(selectedID);
                updateOffice.OfficeName = txtOfficeName.Text;
                updateOffice.IsCenterOffice = chkOffice.Checked;
                updateOffice.DistictID = (int)cmbDistrict.SelectedValue;

                updateOffice.EmployeeList.Clear();
                foreach (Employee item in lstEmployee.Items)
                {
                    updateOffice.EmployeeList.Add(item);
                }
                _officeBll.UpdateBLL(updateOffice);
                RefleshGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAddListBox_Click(object sender, EventArgs e)
        {
            Employee useEmployee = (Employee)cmbEmplyee.SelectedItem;
            lstEmployee.Items.Add(useEmployee);
        }

        private void btnRemoveListBox_Click(object sender, EventArgs e)
        {
            if (lstEmployee.SelectedItem != null)
                lstEmployee.Items.Remove(lstEmployee.SelectedItem);
        }
    }
}
