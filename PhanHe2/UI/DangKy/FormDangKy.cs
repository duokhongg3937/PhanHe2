using PhanHe2.Models;
using PhanHe2.UI.DangKy;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace PhanHe2
{
    public partial class FormDangKy : Form
    {
        private RoleTablePrivilege _roleTabPriv;
        private bool _readOnly = true;
        public FormDangKy(RoleTablePrivilege roleTabPriv)
        {
            InitializeComponent();
            _roleTabPriv = roleTabPriv;
        }

        private void FormDangKy_Load(object sender, EventArgs e)
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
                    if (roleTabPriv.TableName == "DANGKY")
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

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Vui lòng chọn một dòng để cập nhật!");
                return;
            }

            List<string> colsCanBeUpdated = new List<string>();

            foreach (RoleTablePrivilege priv in Program.roleTablePrivileges)
            {
                if (priv.TableName == _roleTabPriv.TableName && priv.ColumnName != null && priv.Privilege == "UPDATE")
                {
                    colsCanBeUpdated.Add(priv.ColumnName);
                }
            }

            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
            FormCapNhatDangKy formCapNhatDangKy = new FormCapNhatDangKy(_roleTabPriv, selectedRow, colsCanBeUpdated);
            DialogResult result = formCapNhatDangKy.ShowDialog();

            if (result == DialogResult.OK)
            {
                DataTable dataTable = DatabaseHandler.GetAll(_roleTabPriv.Owner, _roleTabPriv.TableName);
                dataGridView1.DataSource = dataTable;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muôn xóa dòng đăng ký này?", "Xác nhận xóa", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                Dictionary<string, object> conditions = new Dictionary<string, object>
                {
                    { "MASV", selectedRow.Cells["MASV"].Value },
                    { "MAGV", selectedRow.Cells["MAGV"].Value },
                    { "MAHP", selectedRow.Cells["MAHP"].Value },
                    { "HK", selectedRow.Cells["HK"].Value },
                    { "NAM", selectedRow.Cells["NAM"].Value },
                    { "MACT", selectedRow.Cells["MACT"].Value },
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
                } catch (Exception ex)
                {
                    MessageBox.Show($"Xóa lỗi: {ex.Message}");
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            FormThemDangKy formThemDangKy = new FormThemDangKy(_roleTabPriv.Owner, _roleTabPriv.TableName);
            DialogResult result = formThemDangKy.ShowDialog();

            if (result == DialogResult.OK)
            {
                DataTable dataTable = DatabaseHandler.GetAll(_roleTabPriv.Owner, _roleTabPriv.TableName);
                dataGridView1.DataSource = dataTable;
            }
        }
    }
}
