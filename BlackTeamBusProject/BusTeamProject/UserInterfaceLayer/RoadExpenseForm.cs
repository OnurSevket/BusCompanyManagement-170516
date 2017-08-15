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
    public partial class RoadExpenseForm : Form
    {
        public RoadExpenseForm()
        {
            InitializeComponent();
        }
        RoadExpenseBussiness _roadExpenseBll;

        private void RoadExpenseForm_Load(object sender, EventArgs e)
        {
            _roadExpenseBll = new RoadExpenseBussiness();
            RefreshGrid();

            cmbBusID.ValueMember = "ID";
            cmbBusID.DisplayMember = "ExpenseName";

            BusBussiness _BusBusiness = new BusBussiness();
            cmbBusID.DataSource = _BusBusiness.GetAllBLL();
            
        }
        

        private void RefreshGrid()
        {
            try
            {

                List<RoadExpense> roadExpenseList = _roadExpenseBll.GetAllBLL();
                dgvRoadExpense.DataSource = null;
                dgvRoadExpense.DataSource = roadExpenseList;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        int selectedID;
        private void dgvRoadExpense_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (dgvRoadExpense.SelectedRows.Count > 0)
                {
                    DataGridViewRow dr = dgvRoadExpense.SelectedRows[0];
                    string updateInput = dr.Cells[0].Value.ToString();
                    selectedID = int.Parse(updateInput);
                    RoadExpense updateRoadExpense = _roadExpenseBll.GetBLL(selectedID);
                    txtExpenseName.Text = updateRoadExpense.ExpenseName;
                    txtTotalPrice.Text = updateRoadExpense.TotalPrice.ToString();
                    Bus UseBus = new Bus();
                    UseBus = (Bus)cmbBusID.SelectedItem;
                    updateRoadExpense.ID = UseBus.ID;
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
                RoadExpense newRoadExpense = new RoadExpense();
                Bus useBus = new Bus();
                newRoadExpense.ExpenseName = txtExpenseName.Text;
                newRoadExpense.TotalPrice = Convert.ToDecimal(txtTotalPrice.Text);
                newRoadExpense.BusID = (int)cmbBusID.SelectedValue;
                _roadExpenseBll.SaveBLL(newRoadExpense);
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
                RoadExpense newRoadExpense = _roadExpenseBll.GetBLL(selectedID);
                selectedID = 0;
                _roadExpenseBll.DeleteBLL(newRoadExpense);
                RefreshGrid();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            RoadExpense updateRoadexpense = _roadExpenseBll.GetBLL(selectedID);
            updateRoadexpense.ExpenseName = txtExpenseName.Text;
            updateRoadexpense.TotalPrice = Convert.ToDecimal(txtTotalPrice.Text);
            
            updateRoadexpense.BusID = (int)cmbBusID.SelectedValue;
           
            _roadExpenseBll.UpdateBLL(updateRoadexpense);
            RefreshGrid();
            
        }

       
    }
}
