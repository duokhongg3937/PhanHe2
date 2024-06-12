using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.Windows.Forms;

namespace PhanHe2
{
    public partial class FormNhanSu : Form
    {
        public FormNhanSu()
        {
            InitializeComponent();
        }

        private void FormNhanSu_Load(object sender, EventArgs e)
        {
            string query = $"SELECT * FROM QLTRUONGHOC.UV_XEMTHONGTINCANHAN";
            OracleCommand command = new OracleCommand(query, DatabaseHandler.Conn);

            try
            {
                DataTable dataTable = new DataTable();
                OracleDataAdapter adapter = new OracleDataAdapter(command);
                adapter.Fill(dataTable);

                gridView.DataSource = dataTable;
            } 
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            DataTable dataTable = (DataTable)(gridView.DataSource);
            FormCapNhatNhanSu formCapNhatNhanSu = new FormCapNhatNhanSu(dataTable.Rows[0]);
            formCapNhatNhanSu.ShowDialog();
        }
    }
}
