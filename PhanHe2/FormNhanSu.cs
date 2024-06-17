using Oracle.ManagedDataAccess.Client;
using PhanHe2.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace PhanHe2
{
    public partial class FormNhanSu : Form
    {
        private RoleTablePrivilege _roleTabPriv;

        public FormNhanSu(RoleTablePrivilege roleTabPriv)
        {
            InitializeComponent();
            _roleTabPriv = roleTabPriv;
        }

        private void FormNhanSu_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dataTable = DatabaseHandler.GetAll(_roleTabPriv.Owner, _roleTabPriv.TableName);
                gridView.DataSource = dataTable;
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

            DataTable dataTable = (DataTable)(gridView.DataSource);
            FormCapNhatNhanSu formCapNhatNhanSu = new FormCapNhatNhanSu(_roleTabPriv.Owner, _roleTabPriv.TableName, dataTable.Rows[0], colsCanBeUpdated);
            DialogResult result = formCapNhatNhanSu.ShowDialog();

            if (result == DialogResult.OK)
            {
                dataTable = DatabaseHandler.GetAll(_roleTabPriv.Owner, _roleTabPriv.TableName);
                gridView.DataSource = dataTable;
            }
        }
    }
}
