using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PhanHe2.UI.DangKy
{
    public partial class FormThemDangKy : Form
    {
        private string _owner;
        private string _tableName;

        public FormThemDangKy(string owner, string tableName)
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
            string maSV = string.IsNullOrEmpty(txtBoxMaSV.Text) ? null : txtBoxMaSV.Text;
            string maGV = string.IsNullOrEmpty(txtBoxMaGV.Text) ? null : txtBoxMaGV.Text;
            string maHP = string.IsNullOrEmpty(txtBoxMaHP.Text) ? null : txtBoxMaHP.Text;
            string maCT = string.IsNullOrEmpty(txtBoxMaCT.Text) ? null : txtBoxMaCT.Text;
            int HK = (int)numHK.Value;
            int nam = (int)numNam.Value;
            int DTH = (int)numDTH.Value;
            int DQT = (int)numDQT.Value;
            int DCK = (int)numDCK.Value;
            int DTK = (int)numDTK.Value;
            

            Dictionary<string, object> colValues = new Dictionary<string, object>
            {
                { "MAHP", maHP }, { "MACT", maCT },
                { "HK", HK }, { "NAM", nam },
                { "MAGV", maGV }, { "MASV", maSV },
                { "DIEMTH", DTH }, { "DIEMQT", DQT },
                { "DIEMCK", DCK }, { "DIEMTK", DTK },
            };

            
                bool insertSuccess = DatabaseHandler.Insert(_owner, _tableName, colValues);

                if (insertSuccess)
                {
                    DialogResult = DialogResult.OK;
                    MessageBox.Show($"Thành công thêm đăng ký!", "Insert thành công");
                }
                else
                {
                    DialogResult = DialogResult.Cancel;
                    MessageBox.Show($"Không thể thêm đăng ký!", "Insert thất bại");
                }

                Close();

        }
    }
}
