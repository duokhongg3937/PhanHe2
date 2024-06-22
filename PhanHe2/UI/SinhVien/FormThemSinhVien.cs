using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhanHe2.UI.SinhVien
{
    public partial class FormThemSinhVien : Form
    {
        private string _owner;
        private string _tableName;

        public FormThemSinhVien(string owner, string tableName)
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
            string hoTen = string.IsNullOrEmpty(txtBoxHoTen.Text) ? null : txtBoxHoTen.Text;
            string phai = string.IsNullOrEmpty(txtBoxPhai.Text) ? null : txtBoxPhai.Text; 
            DateTime ngSinh = dateNgaySinh.Value;
            string sdt = string.IsNullOrEmpty(txtBoxSDT.Text) ? null : txtBoxSDT.Text;
            string diaChi = string.IsNullOrEmpty(txtBoxDiaChi.Text) ? null : txtBoxDiaChi.Text;
            string maCT = string.IsNullOrEmpty(txtBoxMaCT.Text) ? null : txtBoxMaCT.Text;
            string maNganh = string.IsNullOrEmpty(txtBoxMaNganh.Text) ? null : txtBoxMaNganh.Text;

            Dictionary<string, object> colValues = new Dictionary<string, object>
            {
                { "HOTEN", hoTen }, { "PHAI", phai },
                { "NGSINH", ngSinh }, { "SDT", sdt },
                { "DCHI", diaChi }, { "MACT", maCT },
                { "MANGANH", maNganh }
            };

            bool insertSuccess = DatabaseHandler.Insert(_owner, _tableName, colValues);

            if (insertSuccess)
            {
                DialogResult = DialogResult.OK;
                MessageBox.Show($"Thành công thêm sinh viên!", "Insert thành công");
            }
            else
            {
                DialogResult = DialogResult.Cancel;
                MessageBox.Show($"Không thể thêm sinh viên!", "Insert thất bại");
            }

            Close();
        }
    }
}
