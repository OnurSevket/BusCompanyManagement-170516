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
    public partial class PaymentTypeForm : Form
    {
        public PaymentTypeForm()
        {
            InitializeComponent();
        }
        PaymentTypeBussiness _paymentTypeBll;
        private void PaymentTypeForm_Load(object sender, EventArgs e)
        {
            btnNextStep.Visible = false;

            _paymentTypeBll = new PaymentTypeBussiness();
            RefleshGrid();
        }
        public void RefleshGrid()
        {
            try
            {
                List<PaymentType> paymentTypeList = _paymentTypeBll.GetAllBLL();
                dgvPaymentTypeList.DataSource = null;
                dgvPaymentTypeList.DataSource = paymentTypeList;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        int selectedID;
        private void dgvPaymentTypeList_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (dgvPaymentTypeList.SelectedRows.Count > 0)
                {
                    DataGridViewRow dr = dgvPaymentTypeList.SelectedRows[0];
                    string updateIdInput = dr.Cells[0].Value.ToString();
                    selectedID = int.Parse(updateIdInput);
                    PaymentType updatePaymentType = _paymentTypeBll.GetBLL(selectedID);
                    txtPaymentType.Text = updatePaymentType.PaymentTypeName;
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
                PaymentType newPaymentType = new PaymentType();
                newPaymentType.PaymentTypeName = txtPaymentType.Text;

                #region veri kaydedilirse buton visible olucak sonraki adıma geçicek
                if (_paymentTypeBll.SaveBLL(newPaymentType))
                    btnNextStep.Visible = true; 
                #endregion

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
                PaymentType deletePayment = _paymentTypeBll.GetBLL(selectedID);
                selectedID = 0;
                _paymentTypeBll.DeleteBLL(deletePayment);
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
                PaymentType updatePaymentType = _paymentTypeBll.GetBLL(selectedID);
                updatePaymentType.PaymentTypeName = txtPaymentType.Text;
                _paymentTypeBll.UpdateBLL(updatePaymentType);
                RefleshGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnNextStep_Click(object sender, EventArgs e)
        {
            PaymentForm usePaymentForm = new PaymentForm();
            usePaymentForm.Show();
            this.Hide();
        }
    }
}
