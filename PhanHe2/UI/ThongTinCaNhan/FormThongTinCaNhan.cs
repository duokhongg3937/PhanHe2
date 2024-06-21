using PhanHe2.Models;
using System.Data;
using System;
using System.Windows.Forms;
using PhanHe2.UI.HocPhan;
using System.Collections.Generic;

namespace PhanHe2.UI.ThongTinCaNhan
{
    public partial class FormThongTinCaNhan : Form
    {
        private RoleTablePrivilege _roleTabPriv;
        private bool _readOnly = true;
        public FormThongTinCaNhan(RoleTablePrivilege roleTabPriv)
        {
            InitializeComponent();
            _roleTabPriv = roleTabPriv;
        }

        private void FormThongTinCaNhan_Load(object sender, System.EventArgs e)
        {
            btnCapNhat.Hide();

            try
            {
                DataTable dataTable = DatabaseHandler.GetAll(_roleTabPriv.Owner, _roleTabPriv.TableName);
                gridView.DataSource = dataTable;

                foreach (RoleTablePrivilege roleTabPriv in Program.roleTablePrivileges)
                {
                    if (roleTabPriv.TableName == "UV_XEMTHONGTINCANHAN")
                    {
                        switch (roleTabPriv.Privilege)
                        {
                            case "UPDATE":
                                btnCapNhat.Show();
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

        private void btnCapNhat_Click(object sender, System.EventArgs e)
        {
            List<string> colsCanBeUpdated = new List<string>();

            foreach (RoleTablePrivilege priv in Program.roleTablePrivileges)
            {
                if (priv.TableName == _roleTabPriv.TableName && priv.ColumnName != null && priv.Privilege == "UPDATE")
                {
                    colsCanBeUpdated.Add(priv.ColumnName);
                }
            }

            DataTable dataTable = (DataTable)gridView.DataSource;
            DataRow selectedRow = dataTable.Rows[0];
            FormCapNhatTTCaNhan formCapNhatTTCaNhan = new FormCapNhatTTCaNhan(_roleTabPriv.Owner, _roleTabPriv.TableName, selectedRow, colsCanBeUpdated);
            DialogResult result = formCapNhatTTCaNhan.ShowDialog();

            if (result == DialogResult.OK)
            {
                dataTable = DatabaseHandler.GetAll(_roleTabPriv.Owner, _roleTabPriv.TableName);
                gridView.DataSource = dataTable;
            }
        }
    }
}
