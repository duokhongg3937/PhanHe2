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
        private string _tableName;
        private string _owner;

        public FormNhanSu(string owner, string tableName)
        {
            InitializeComponent();
            _tableName = tableName;
            _owner = owner;
        }

        private void FormNhanSu_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dataTable = DatabaseHandler.GetAll(_owner, _tableName);
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
                if (priv.TableName == _tableName && priv.ColumnName != null && priv.Privilege == "UPDATE")
                {
                    colsCanBeUpdated.Add(priv.ColumnName);
                }
            }

            DataTable dataTable = (DataTable)(gridView.DataSource);
            FormCapNhatNhanSu formCapNhatNhanSu = new FormCapNhatNhanSu(_owner, _tableName, dataTable.Rows[0], colsCanBeUpdated);
            DialogResult result = formCapNhatNhanSu.ShowDialog();

            if (result == DialogResult.OK)
            {
                dataTable = DatabaseHandler.GetAll(_owner, _tableName);
                gridView.DataSource = dataTable;
            }
        }
    }
}
