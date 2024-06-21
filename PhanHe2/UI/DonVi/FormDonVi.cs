using PhanHe2.Models;
using PhanHe2.UI.DonVi;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace PhanHe2
{
    public partial class FormDonVi : Form
    {
        private RoleTablePrivilege _roleTabPriv;
        private bool _readOnly = true;
        public FormDonVi(RoleTablePrivilege roleTabPriv)
        {
            InitializeComponent();
            _roleTabPriv = roleTabPriv;
        }

        private void FormDonVi_Load(object sender, EventArgs e)
        {
            btnThem.Hide();
            btnCapNhat.Hide();
            btnXoa.Hide();
            try
            {
                DataTable dataTable = DatabaseHandler.GetAll(_roleTabPriv.Owner, _roleTabPriv.TableName);
                dataGridView1.DataSource = dataTable;

                foreach (RoleTablePrivilege roleTabPriv in Program.roleTablePrivileges)
                {
                    if (roleTabPriv.TableName == "DONVI")
                    {
                        switch (roleTabPriv.Privilege)
                        {
                            case "INSERT":
                                btnThem.Show();
                                _readOnly = false;
                                break;
                            case "UPDATE": 
                                btnCapNhat.Show();
                                _readOnly = false;
                                break;
                            case "DELETE":
                                btnXoa.Show();
                                _readOnly = false;
                                break;
                        }
                    }
                }

                if (_readOnly)
                {
                    groupBox1.Location = new System.Drawing.Point(12, 12);
                    groupBox1.Height += 30;
                    dataGridView1.Height += 30;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            FormThemDonVi formThemDonVi = new FormThemDonVi(_roleTabPriv.Owner, _roleTabPriv.TableName);
            DialogResult result = formThemDonVi.ShowDialog();

            if (result == DialogResult.OK)
            {
                DataTable dataTable = DatabaseHandler.GetAll(_roleTabPriv.Owner, _roleTabPriv.TableName);
                dataGridView1.DataSource = dataTable;
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            List<string> colsCanBeUpdated = new List<string>();

            foreach (RoleTablePrivilege priv in Program.roleTablePrivileges)
            {
                if (priv.TableName == _roleTabPriv.TableName && priv.ColumnName != null && priv.Privilege == "UPDATE")
                {
                    colsCanBeUpdated.Add(priv.ColumnName);
                }
            } 

            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
            FormCapNhatDonVi formCapNhatDonVi = new FormCapNhatDonVi(_roleTabPriv.Owner, _roleTabPriv.TableName, selectedRow, colsCanBeUpdated);
            DialogResult result = formCapNhatDonVi.ShowDialog();

            if (result == DialogResult.OK)
            {
                DataTable dataTable = DatabaseHandler.GetAll(_roleTabPriv.Owner, _roleTabPriv.TableName);
                dataGridView1.DataSource = dataTable;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muôn xóa dòng đơn vị này?", "Xác nhận xóa", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                Dictionary<string, object> conditions = new Dictionary<string, object>
                {
                    { "MADC", selectedRow.Cells["MADV"].Value },
                };

                try
                {
                    bool deleteSuccess = DatabaseHandler.Delete(_roleTabPriv.Owner, _roleTabPriv.TableName, conditions);
                    if (deleteSuccess)
                    {
                        MessageBox.Show("Xóa thành công");
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Xóa lỗi: {ex.Message}");
                }
            }
        }
    }
}
