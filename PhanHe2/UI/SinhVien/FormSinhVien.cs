using System.Data;
using System;
using System.Windows.Forms;
using PhanHe2.Models;
using System.Collections.Generic;
using PhanHe2.UI.SinhVien;

namespace PhanHe2
{
    public partial class FormSinhVien : Form
    {
        private RoleTablePrivilege _roleTabPriv;
        private bool _readOnly = true;
        public FormSinhVien(RoleTablePrivilege roleTabPriv)
        {
            InitializeComponent();
            _roleTabPriv = roleTabPriv;
        }

        private void FormSinhVien_Load(object sender, System.EventArgs e)
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
                    if (roleTabPriv.TableName == "SINHVIEN")
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
            FormThemSinhVien formThemSinhVien = new FormThemSinhVien(_roleTabPriv.Owner, _roleTabPriv.TableName);
            DialogResult result = formThemSinhVien.ShowDialog();

            if (result == DialogResult.OK)
            {
                DataTable dataTable = DatabaseHandler.GetAll(_roleTabPriv.Owner, _roleTabPriv.TableName);
                dataGridView1.DataSource = dataTable;
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
            FormCapNhatSinhVien formCapNhatSinhVien = new FormCapNhatSinhVien(_roleTabPriv, selectedRow, colsCanBeUpdated);
            DialogResult result = formCapNhatSinhVien.ShowDialog();

            if (result == DialogResult.OK)
            {
                DataTable dataTable = DatabaseHandler.GetAll(_roleTabPriv.Owner, _roleTabPriv.TableName);
                dataGridView1.DataSource = dataTable;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

        }
    }
}
