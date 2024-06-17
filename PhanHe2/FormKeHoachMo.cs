using PhanHe2.Models;
using System;
using System.Data;
using System.Windows.Forms;

namespace PhanHe2
{
    public partial class FormKeHoachMo : Form
    {
        private RoleTablePrivilege _roleTabPriv;
        public FormKeHoachMo(RoleTablePrivilege roleTabPriv)
        {
            InitializeComponent();
            _roleTabPriv = roleTabPriv;
        }

        private void FormKeHoachMo_Load(object sender, EventArgs e)
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
