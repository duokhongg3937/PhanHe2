using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PhanHe2.UI.HocPhan
{
    public partial class FormThemHocPhan : Form
    {
        private string _owner;
        private string _tableName;
        public FormThemHocPhan(string owner, string tableName)
        {
            InitializeComponent();
            _owner = owner;
            _tableName = tableName;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string maHP = string.IsNullOrEmpty(txtBoxMaHP.Text) ? null : txtBoxMaHP.Text;
            string tenHP = string.IsNullOrEmpty(txtBoxTenHP.Text) ? null : txtBoxTenHP.Text;
            string maDV = string.IsNullOrEmpty(txtBoxMaDV.Text) ? null : txtBoxMaDV.Text;
            int soTCLT = (int)numSTLT.Value;
            int soTCTH = (int)numSTTH.Value;
            int soTC = soTCLT + soTCTH;
            int soSVTD = (int)numSOSVTD.Value;

            Dictionary<string, object> colValues = new Dictionary<string, object>()
            {
                { "MAHP", maHP }, { "TENHP", tenHP }, { "MADV", maDV },
                { "STLT", soTCLT }, { "STTH", soTCTH }, { "SOTC", soTC },
                { "SOSVTD", soSVTD }
            };

            bool insertSuccess = DatabaseHandler.Insert(_owner, _tableName, colValues);

            if (insertSuccess)
            {
                DialogResult = DialogResult.OK;
                MessageBox.Show($"Thành công thêm học phần!", "Insert thành công");
            }
            else
            {
                DialogResult = DialogResult.Cancel;
                MessageBox.Show($"Không thể thêm học phần!", "Insert thất bại");
            }

            Close();
        }
    }
}
