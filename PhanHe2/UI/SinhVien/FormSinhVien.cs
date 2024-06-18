using System.Data;
using System;
using System.Windows.Forms;
using PhanHe2.Models;

namespace PhanHe2
{
    public partial class FormSinhVien : Form
    {
        private RoleTablePrivilege _roleTabPriv;
        public FormSinhVien(RoleTablePrivilege roleTabPriv)
        {
            InitializeComponent();
            _roleTabPriv = roleTabPriv;
        }

        private void FormSinhVien_Load(object sender, System.EventArgs e)
        {
            try
            {
                DataTable dataTable = DatabaseHandler.GetAll(_roleTabPriv.Owner, _roleTabPriv.TableName);
                dataGridView1.DataSource = dataTable;

                if (Program.role != "C##RL_GIAOVU")
                {
                    btnThem.Hide();
                    btnCapNhat.Hide();
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
    }
}
