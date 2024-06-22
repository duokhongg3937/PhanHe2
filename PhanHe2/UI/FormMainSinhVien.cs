using PhanHe2.Models;
using PhanHe2.UI.FormUpdate;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhanHe2.UI
{
    public partial class FormMainSinhVien : Form
    {
        public FormMainSinhVien()
        {
            InitializeComponent();
        }

        private void formSinhVien_Loaded(object sender, EventArgs e)
        {

            AssignData_StudentInfo_TabPage();

        }

        // variables
        PhanHe2.Models.SinhVien student;

        private void AssignData_StudentInfo_TabPage()
        {
            student = DatabaseHandler.GetStudentInfo();
            maSV_TextBox.Text = student.MaSV;
            hoTen_TextBox.Text = student.HoTen;
            gioiTinh_TextBox.Text = student.Phai;

            diaChi_TextBox.Text = student.DChi;
            ngaySinh_TextBox.Text = student.NgSinh.ToString("dd/MM/yyyy");
            SDT_TextBox.Text = student.SDT;

            maCT_TextBox.Text = student.MaCT;
            maNganh_TextBox.Text = student.MaNganh;
            stctl_TextBox.Text = student.SoTCTL.ToString();
            dtbtl_TextBox.Text = student.DTBTL.ToString();
        }

        private void updateInfo_Btn_Click(object sender, EventArgs e)
        {
            FormUpdateStudentInfo updateForm = new FormUpdateStudentInfo(student);
            updateForm.ShowDialog();
        }
    }
}
