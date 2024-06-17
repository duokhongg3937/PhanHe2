using PhanHe2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhanHe2
{
    public partial class FormDangKy : Form
    {
        private RoleTablePrivilege _roleTabPriv;
        public FormDangKy(RoleTablePrivilege roleTabPriv)
        {
            InitializeComponent();
            _roleTabPriv = roleTabPriv;
        }

        private void FormDangKy_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dataTable = DatabaseHandler.GetAll(_roleTabPriv.Owner, _roleTabPriv.TableName);
                dataGridView1.DataSource = dataTable;

                if (Program.role == "C##RL_GIANGVIEN")
                {
                    btnThem.Hide();
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
    }
}
