using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PhanHe2.UI.PhanCong
{
    public partial class FormThemPhanCong : Form
    {
        private string _owner;
        private string _tableName;
        public FormThemPhanCong(string owner, string tableName)
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
            string maGV = string.IsNullOrEmpty(txtBoxMaGV.Text) ? null : txtBoxMaGV.Text;
            string maHP = string.IsNullOrEmpty(txtBoxMaHP.Text) ? null : txtBoxMaHP.Text;
            string maCT = string.IsNullOrEmpty(txtBoxMaCT.Text) ? null : txtBoxMaCT.Text;
            int HK = (int)numHK.Value;
            int nam = (int)numNam.Value;

            if (maGV == null)
            {
                MessageBox.Show("Mã sinh viên không được để trống");
                return;
            }

            if (maHP == null)
            {
                MessageBox.Show("Mã học phần không được để trống");
                return;
            }

            if (maCT == null)
            {
                MessageBox.Show("Mã chương trình không được để trống");
                return;
            }

            Dictionary<string, object> colValues = new Dictionary<string, object>
            {
                { "MAHP", maHP }, { "MACT", maCT },
                { "HK", HK }, { "NAM", nam }, {"MAGV", maGV}
            };

            bool insertSuccess = DatabaseHandler.Insert(_owner, _tableName, colValues);

            if (insertSuccess)
            {
                DialogResult = DialogResult.OK;
                MessageBox.Show($"Thành công thêm phân công!", "Insert thành công");
            }
            else
            {
                DialogResult = DialogResult.Cancel;
                MessageBox.Show($"Không thể thêm phân công!", "Insert thất bại");
            }

            Close();
        }
    }
}
