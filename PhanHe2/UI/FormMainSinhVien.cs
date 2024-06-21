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

            StudentInfo_TabPage_Loaded();

            LookupResult_TabPage_Loaded();

            KHMO_TabPage_Loaded();

            DKHP_TabPage_Loaded();

            ResultDKHP_Tabpage_Loaded();

        }

        // variables
        SinhVien student;


        #region Tabpage 1: student info
        private void StudentInfo_TabPage_Loaded()
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

        #endregion

        #region Tabpage 2: Tra cứu kết quả học tập 

        private DataTable viewTab2;
        private List<string> listYears_Tab2;
        private List<string> listSemester_Tab2;

        private void LookupResult_TabPage_Loaded()
        {
            viewTab2 = DatabaseHandler.GetAllCourseResult();
            resultLookup_dataGridView.DataSource = viewTab2;

            listYears_Tab2 = DatabaseHandler.GetAllYears_Student_Tab2();
            listYears_Tab2.Insert(0, "Tất cả");

            listSemester_Tab2 = DatabaseHandler.GetAllSemesters_Student_Tab2();
            listSemester_Tab2.Insert(0, "Tất cả");

            year_ComboBox.DataSource = listYears_Tab2;
            year_ComboBox.SelectedIndex = 0;

            semester_ComboBox.DataSource = listSemester_Tab2;
            semester_ComboBox.SelectedIndex = 0;

        }

        #endregion


        #region Tabpage 3: Kế hoạch mở môn

        private DataTable viewTab3;
        private List<string> listYears_Tab3;
        private List<string> listSemester_Tab3;

        private void KHMO_TabPage_Loaded()
        {
            viewTab3 = DatabaseHandler.GetAll_KHMO_Tab3();
            KHMO_dataGridView.DataSource = viewTab3;

            listYears_Tab3 = DatabaseHandler.GetAllYears_KHMO_Tab3();
            listYears_Tab3.Insert(0, "Tất cả");

            listSemester_Tab3 = DatabaseHandler.GetAllSemesters_KHMO_Tab3();
            listSemester_Tab3.Insert(0, "Tất cả");

            yearKHM_ComboBox.DataSource = listYears_Tab3;
            yearKHM_ComboBox.SelectedIndex = 0;

            semesterKHMO_ComboBox.DataSource = listSemester_Tab3;
            semesterKHMO_ComboBox.SelectedIndex = 0;
        }

        #endregion


        #region Tabpage 4: Đăng ký học phần
        private void DKHP_TabPage_Loaded()
        {

        }

        #endregion

        #region Tabpage 5: Kết quả đăng ký học phần
        private void ResultDKHP_Tabpage_Loaded()
        {

        }


        #endregion
    }
}
