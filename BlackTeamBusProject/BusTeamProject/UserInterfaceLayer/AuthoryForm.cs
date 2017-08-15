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
    public partial class AuthoryForm : Form
    {
        public AuthoryForm()
        {
            InitializeComponent();
        }
        AuthoryBussiness _authoryBll;
        private void dgvAuthoryNameList_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (dgvAuthoryNameList.SelectedRows.Count > 0)
                {
                    DataGridViewRow dr = dgvAuthoryNameList.SelectedRows[0];
                    string updateIdInput = dr.Cells[0].Value.ToString();
                    selectedID = int.Parse(updateIdInput);
                    Authory updateAuthory = _authoryBll.GetBLL(selectedID);
                    txtAuthoryName.Text = updateAuthory.AuthoryName;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        int selectedID;
        private void AuthoryForm_Load(object sender, EventArgs e)
        {
            _authoryBll = new AuthoryBussiness();
            RefleshGrid();
        }
        public void RefleshGrid()
        {
            try
            {
                List<Authory> authoryList = _authoryBll.GetAllBLL();
                dgvAuthoryNameList.DataSource = null;
                dgvAuthoryNameList.DataSource = authoryList;
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
                Authory newAuthory = new Authory();
                newAuthory.AuthoryName = txtAuthoryName.Text;
                _authoryBll.SaveBLL(newAuthory);
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
                Authory deleteAuthory = _authoryBll.GetBLL(selectedID);
                selectedID = 0;
                _authoryBll.DeleteBLL(deleteAuthory);
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
                Authory updateAuthory = _authoryBll.GetBLL(selectedID);
                updateAuthory.AuthoryName = txtAuthoryName.Text;
                _authoryBll.UpdateBLL(updateAuthory);
                RefleshGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
