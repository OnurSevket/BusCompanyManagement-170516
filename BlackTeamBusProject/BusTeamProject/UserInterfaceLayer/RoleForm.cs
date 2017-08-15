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
    public partial class RoleForm : Form
    {
        public RoleForm()
        {
            InitializeComponent();
        }
        RoleBussiness _roleBll;
        int selectedID;
        Role selectedRole;
        private void dgvRoleNameList_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (dgvRoleNameList.SelectedRows.Count > 0)
                {
                    DataGridViewRow dr = dgvRoleNameList.SelectedRows[0];
                    string updateIdInput = dr.Cells[0].Value.ToString();
                    selectedID = int.Parse(updateIdInput);
                    selectedRole = _roleBll.GetBLL(selectedID);
                    txtRoleName.Text = selectedRole.RoleName;

                    lstAuthory.Items.Clear();
                    foreach (Authory item in selectedRole.AuthoryList)
                    {
                        lstAuthory.Items.Add(item);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void RoleForm_Load(object sender, EventArgs e)
        {
            _roleBll = new RoleBussiness();
            RefleshGrid();
            AuthoryBussiness _authory = new AuthoryBussiness();
            cmbAuthory.DataSource = _authory.GetAllBLL();
            cmbAuthory.ValueMember = "ID";
            cmbAuthory.DisplayMember = "AuthoryName";
        }

        public void RefleshGrid()
        {
            try
            {
                List<Role> roleList = _roleBll.GetAllBLL();
                dgvRoleNameList.DataSource = null;
                dgvRoleNameList.DataSource = roleList;
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
                Role newRole = new Role();
                newRole.RoleName = txtRoleName.Text;
                

                foreach (Authory item in lstAuthory.Items)
                {
                    newRole.AuthoryList.Add(item);
                }
                _roleBll.SaveBLL(newRole);
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
                Role deleteRole = _roleBll.GetBLL(selectedID);
                selectedID = 0;
                _roleBll.DeleteBLL(deleteRole);
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
                Role updateAuthory = _roleBll.GetBLL(selectedID);
                updateAuthory.RoleName = txtRoleName.Text;

                updateAuthory.AuthoryList.Clear();
                foreach (Authory item in lstAuthory.Items)
                {
                    updateAuthory.AuthoryList.Add(item);
                }
                _roleBll.UpdateBLL(updateAuthory);
                RefleshGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAddListBox_Click(object sender, EventArgs e)
        {
            Authory useAuthory = (Authory)cmbAuthory.SelectedItem;
            lstAuthory.Items.Add(useAuthory);
        }

        private void btnRemoveListBox_Click(object sender, EventArgs e)
        {
            if (lstAuthory.SelectedItem != null)
                lstAuthory.Items.Remove(lstAuthory.SelectedItem);
        }
    }
}
