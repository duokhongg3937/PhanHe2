using PhanHe2.Models;
using PhanHe2.UI.PhanCong;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace PhanHe2
{
    public partial class FormPhanCong : Form
    {
        private RoleTablePrivilege _roleTabPriv;
        private DataTable _dataTable;
        private bool _readOnly = true;
        public FormPhanCong(RoleTablePrivilege roleTabPriv)
        {

            InitializeComponent();
            _roleTabPriv = roleTabPriv;
        }

        private void FormPhanCong_Load(object sender, EventArgs e)
        {
            btnCapNhat.Hide();
            btnThem.Hide();
            btnXoa.Hide();
            checkBox1.Hide();

            _dataTable = DatabaseHandler.GetAll(_roleTabPriv.Owner, _roleTabPriv.TableName);
            dataGridView1.DataSource = _dataTable;

            try
            {
                foreach (RoleTablePrivilege roleTabPriv in Program.roleTablePrivileges)
                {
                    if (roleTabPriv.TableName == "PHANCONG")
                    {
                        switch (roleTabPriv.Privilege)
                        {
                            case "INSERT":
                                btnThem.Show();
                                _readOnly = false;
                                break;
                            case "UPDATE":
                                btnCapNhat.Show();
                                checkBox1.Show();
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

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muôn xóa dòng phân công này?", "Xác nhận xóa", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                Dictionary<string, object> conditions = new Dictionary<string, object>
                {
                    { "MAGV", selectedRow.Cells["MAGV"].Value },
                    { "MAHP", selectedRow.Cells["MAHP"].Value },
                    { "MACT", selectedRow.Cells["MACT"].Value },
                    { "HK", selectedRow.Cells["HK"].Value },
                    { "NAM", selectedRow.Cells["NAM"].Value },
                };

                try
                {
                    bool deleteSuccess = DatabaseHandler.Delete(_roleTabPriv.Owner, _roleTabPriv.TableName, conditions);
                    if (deleteSuccess)
                    {
                        MessageBox.Show("Xóa thành công");
                        DataTable dataTable = DatabaseHandler.GetAll(_roleTabPriv.Owner, _roleTabPriv.TableName);
                        dataGridView1.DataSource = dataTable;
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
            FormCapNhatPhanCong formCapNhatPhanCong = new FormCapNhatPhanCong(_roleTabPriv, selectedRow, colsCanBeUpdated);
            DialogResult result = formCapNhatPhanCong.ShowDialog();

            if (result == DialogResult.OK)
            {
                DataTable dataTable = DatabaseHandler.GetAll(_roleTabPriv.Owner, _roleTabPriv.TableName);
                dataGridView1.DataSource = dataTable;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            FormThemPhanCong formThemPhanCong = new FormThemPhanCong(_roleTabPriv.Owner, _roleTabPriv.TableName);
            DialogResult result = formThemPhanCong.ShowDialog();

            if (result == DialogResult.OK)
            {
                DataTable dataTable = DatabaseHandler.GetAll(_roleTabPriv.Owner, _roleTabPriv.TableName);
                dataGridView1.DataSource = dataTable;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked && (Program.role == "C##RL_GIAOVU" || Program.role == "C##RL_TRUONGKHOA"))
            {
                _dataTable = DatabaseHandler.GetAll(_roleTabPriv.Owner, _roleTabPriv.TableName, "MAHP IN (SELECT MAHP FROM QLTRUONGHOC.HOCPHAN WHERE MADV = 'DV001')");
                dataGridView1.DataSource = _dataTable;
            } 
            else
            {
                _dataTable = DatabaseHandler.GetAll(_roleTabPriv.Owner, _roleTabPriv.TableName);
                dataGridView1.DataSource = _dataTable;
            }
        }
    }
}
