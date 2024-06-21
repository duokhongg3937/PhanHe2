using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PhanHe2.UI.KeHoachMo
{
    public partial class FormThemKeHoachMo : Form
    {
        private string _owner;
        private string _tableName;
        public FormThemKeHoachMo(string owner, string tableName)
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
            string maCT = string.IsNullOrEmpty(txtBoxMaCT.Text) ? null : txtBoxMaCT.Text;
            int HK =  (int)numHK.Value;
            int nam = (int)numNam.Value;

            Dictionary<string, object> colValues = new Dictionary<string, object>
            {
                { "MAHP", maHP }, { "MACT", maCT },
                { "HK", HK }, { "NAM", nam },
            };

            bool insertSuccess = DatabaseHandler.Insert(_owner, _tableName, colValues);

            if (insertSuccess)
            {
                DialogResult = DialogResult.OK;
                MessageBox.Show($"Thành công thêm kế hoạch mở!", "Insert thành công");
            }
            else
            {
                DialogResult = DialogResult.Cancel;
                MessageBox.Show($"Không thể thêm kế hoạch mở!", "Insert thất bại");
            }

            Close();
        }
    }
}
