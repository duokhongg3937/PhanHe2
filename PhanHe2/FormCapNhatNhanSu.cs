using System;
using System.Data;
using System.Windows.Forms;

namespace PhanHe2
{
    public partial class FormCapNhatNhanSu : Form
    {
        private DataRow _row;
        public FormCapNhatNhanSu(DataRow row)
        {
            InitializeComponent();
            _row = row;
        }

        private void FormCapNhatNhanSu_Load(object sender, EventArgs e)
        {
            txtBoxMaNV.Text = _row["MANV"].ToString();
            txtBoxHoTen.Text = _row["HOTEN"].ToString();
            txtBoxPhai.Text = _row["PHAI"].ToString();
            txtBoxNgaySinh.Text = _row["NGSINH"].ToString();
            txtBoxPhuCap.Text = _row["PHUCAP"].ToString();
            txtBoxSDT.Text = _row["SDT"].ToString();
            txtBoxVaiTro.Text = _row["VAITRO"].ToString();
            txtBoxMaDV.Text = _row["MADV"].ToString();

            txtBoxSDT.ReadOnly = false;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;

            string updatedSDT = txtBoxSDT.Text;
            if (updatedSDT != _row["SDT"].ToString())
            {

            }

            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
