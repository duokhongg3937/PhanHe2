using Oracle.ManagedDataAccess.Client;
using PhanHe2.Models;
using PhanHe2.UI.NhanSu;
using PhanHe2.UI.SinhVien;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace PhanHe2
{
    public partial class FormNhanSu : Form
    {
        private RoleTablePrivilege _roleTabPriv;
        private bool _readOnly = true;

        public FormNhanSu(RoleTablePrivilege roleTabPriv)
        {
            InitializeComponent();
            _roleTabPriv = roleTabPriv;
        }

        private void FormNhanSu_Load(object sender, EventArgs e)
        {
            btnThem.Hide();
            btnXoa.Hide();
            btnCapNhat.Hide();

            try
            {
                DataTable dataTable = DatabaseHandler.GetAll(_roleTabPriv.Owner, _roleTabPriv.TableName);
                gridView.DataSource = dataTable;

                foreach (RoleTablePrivilege roleTabPriv in Program.roleTablePrivileges)
                {
                    if (roleTabPriv.TableName == "NHANSU")
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
                    gridView.Height += 30;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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

            DataGridViewRow selectedRow = gridView.SelectedRows[0];

            DataTable dataTable = (DataTable)(gridView.DataSource);
            FormCapNhatNhanSu formCapNhatNhanSu = new FormCapNhatNhanSu(_roleTabPriv.Owner, _roleTabPriv.TableName, selectedRow, colsCanBeUpdated);
            DialogResult result = formCapNhatNhanSu.ShowDialog();

            if (result == DialogResult.OK)
            {
                dataTable = DatabaseHandler.GetAll(_roleTabPriv.Owner, _roleTabPriv.TableName);
                gridView.DataSource = dataTable;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muôn xóa dòng nhân sự này?", "Xác nhận xóa", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                DataGridViewRow selectedRow = gridView.SelectedRows[0];
                Dictionary<string, object> conditions = new Dictionary<string, object>
                {
                    { "MANV", selectedRow.Cells["MANV"].Value }
                };

                try
                {
                    bool deleteSuccess = DatabaseHandler.Delete(_roleTabPriv.Owner, _roleTabPriv.TableName, conditions);
                    if (deleteSuccess)
                    {
                        MessageBox.Show("Xóa thành công");
                        DataTable dataTable = DatabaseHandler.GetAll(_roleTabPriv.Owner, _roleTabPriv.TableName);
                        gridView.DataSource = dataTable;
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

        private void btnThem_Click(object sender, EventArgs e)
        {
            FormThemNhanSu formThemNhanSu = new FormThemNhanSu(_roleTabPriv.Owner, _roleTabPriv.TableName);
            DialogResult result = formThemNhanSu.ShowDialog();

            if (result == DialogResult.OK)
            {
                DataTable dataTable = DatabaseHandler.GetAll(_roleTabPriv.Owner, _roleTabPriv.TableName);
                gridView.DataSource = dataTable;
            }
        }
    }
}
