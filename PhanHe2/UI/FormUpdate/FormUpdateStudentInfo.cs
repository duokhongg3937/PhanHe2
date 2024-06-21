using PhanHe2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhanHe2.UI.FormUpdate
{
    public partial class FormUpdateStudentInfo : Form
    {
        public FormUpdateStudentInfo(SinhVien student)
        {
            InitializeComponent();

            // binding value
            sdt_TextBox.Text = student.SDT.ToString();
            diaChi_TextBox.Text = student.DChi;
        }

        private void updateInfo_Btn_Click(object sender, EventArgs e)
        {
            string sdt = sdt_TextBox.Text;
            string diachi = diaChi_TextBox.Text;

            if (DatabaseHandler.UpdateStudentInfo(sdt, diachi))
            {
                MessageBox.Show("Cập nhật thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra. Cập nhật thông tin không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
