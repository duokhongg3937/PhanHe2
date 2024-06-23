using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PhanHe2.UI.NhanSu
{
    public partial class FormThemNhanSu : Form
    {
        private string _owner;
        private string _tableName;
        public FormThemNhanSu(string owner, string tableName)
        {
            InitializeComponent();
            _owner = owner;
            _tableName = tableName; 
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnOk_Click(object sender, System.EventArgs e)
        {
            string maDV = string.IsNullOrEmpty(txtBoxMaDV.Text) ? null : txtBoxMaDV.Text;
            string hoTen = string.IsNullOrEmpty(txtBoxHoTen.Text) ? null : txtBoxHoTen.Text;
            string phai = string.IsNullOrEmpty(txtBoxPhai.Text) ? null : txtBoxPhai.Text;
            string sdt = string.IsNullOrEmpty(txtBoxSDT.Text) ? null : txtBoxSDT.Text;
            string vaiTro = string.IsNullOrEmpty(txtBoxVaiTro.Text) ? null : txtBoxVaiTro.Text;
            int phuCap = (int)numPhuCap.Value;
            DateTime ngaySinh = dateNgaySinh.Value;

            Dictionary<string, object> colValues = new Dictionary<string, object>
            {
                { "MADV", maDV }, { "HOTEN", hoTen },
                { "PHAI", phai }, { "NGSINH", ngaySinh }, {"SDT", sdt},
                { "VAITRO", vaiTro }, { "PHUCAP", phuCap }
            };

            bool insertSuccess = DatabaseHandler.Insert(_owner, _tableName, colValues);

            if (insertSuccess)
            {
                DialogResult = DialogResult.OK;
                MessageBox.Show($"Thành công thêm nhân sự!", "Insert thành công");
            }
            else
            {
                DialogResult = DialogResult.Cancel;
                MessageBox.Show($"Không thể thêm nhân sự!", "Insert thất bại");
            }

            Close();
        }
    }
}
