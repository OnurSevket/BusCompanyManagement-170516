using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogicLayer;
using EntitiesLayer;


namespace UserInterfaceLayer
{
    public partial class PaymentForm : Form
    {
        public PaymentForm()
        {
            InitializeComponent();

        }
        PaymentBussiness _payBuss = new PaymentBussiness();
        int selectedID;

        private void PaymentForm_Load(object sender, EventArgs e)
        {
            refreshGrid();

            //cmbPaymentID.ValueMember = "ID";
            //cmbPaymentID.DisplayMember = "PaymentyTypeName";
            PaymentTypeBussiness payTypBuss = new PaymentTypeBussiness();
            cmbPaymentID.DataSource = payTypBuss.GetAllBLL();
        }

        private void refreshGrid()
        {
            try
            {

                List<Payment> paymentList = _payBuss.GetAllBLL();
                dgvPaymentList.DataSource = null;
                dgvPaymentList.DataSource = paymentList;
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
                Payment savePayment = new Payment();
                PaymentType ptype =(PaymentType) cmbPaymentID.SelectedItem;
                savePayment.PaymentTypeID =ptype.ID ;
                savePayment.TotalPrice = Convert.ToDecimal(txtTotalPrice.Text);
                savePayment.CreatePaymentDate = Convert.ToDateTime(dtpCreateDate.Value);

                _payBuss.SaveBLL(savePayment);
                refreshGrid();
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
                Payment deletePayment = _payBuss.GetBLL(selectedID);
                selectedID = 0;
                _payBuss.DeleteBLL(deletePayment);
                refreshGrid();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Payment updatePayment = _payBuss.GetBLL(selectedID);
            updatePayment.CreatePaymentDate = Convert.ToDateTime(dtpCreateDate.Value);
            PaymentType ptype = (PaymentType)cmbPaymentID.SelectedItem;
            updatePayment.PaymentTypeID =ptype.ID;
            
            updatePayment.TotalPrice = decimal.Parse( txtTotalPrice.Text);

            _payBuss.UpdateBLL(updatePayment);
            refreshGrid();
        }

        private void dgvPaymentList_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (dgvPaymentList.SelectedRows.Count > 0)
                {
                    DataGridViewRow dr = dgvPaymentList.SelectedRows[0];
                    string updateInput = dr.Cells[0].Value.ToString();
                    selectedID = int.Parse(updateInput);
                    Payment usePayment = _payBuss.GetBLL(selectedID);
                    dtpCreateDate.Text = usePayment.CreatePaymentDate.ToString();
                    txtTotalPrice.Text =usePayment.TotalPrice.ToString();
                    PaymentTypeBussiness byB = new PaymentTypeBussiness();
                    cmbPaymentID.SelectedItem= byB.GetBLL((int)usePayment.PaymentTypeID);
                    //cmbPaymentID.SelectedItem =(int) usePayment.PaymentTypeID;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
             
        }
    }
}
