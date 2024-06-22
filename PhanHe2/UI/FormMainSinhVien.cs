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
        PhanHe2.Models.SinhVien student;


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

            // reload info
            StudentInfo_TabPage_Loaded();
        }

        #endregion

        #region Tabpage 2: Tra cứu kết quả học tập 

        private DataTable viewTab2;
        private List<string> listYears_Tab2;
        private List<string> listSemester_Tab2;

        private void LookupResult_TabPage_Loaded()
        {
            viewTab2 = DatabaseHandler.GetAllCourseResult(-1, -1);


            // Đánh số hàng
            for (int i = 0; i < viewTab2.Rows.Count; i++)
            {
              viewTab2.Rows[i]["STT"] = i + 1;
            }

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

            viewTab3 = DatabaseHandler.GetAll_KHMO_Tab3(-1, -1);

            // Đánh số hàng
            for (int i = 0; i < viewTab3.Rows.Count; i++)
            {
                viewTab3.Rows[i]["STT"] = i + 1;
            }

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

        private DataTable viewTab5;

        private void ResultDKHP_Tabpage_Loaded()
        {
            // lấy ngày/tháng/năm hiện tại => học kỳ hiện tại
            // tháng 1-4 => HK 1
            // tháng 5-8 => HK 2
            // tháng 9 -12 => HK3
            // => HK, NAM -> get data from db

            // Lấy ngày tháng năm hiện tại từ hệ thống
            DateTime currentDate = DateTime.Now;
            int year = currentDate.Year;
            int month = currentDate.Month;

            // Xác định học kỳ dựa trên tháng hiện tại
            int semester;
            if (month >= 1 && month <= 4)
            {
                semester = 1; // Học kỳ 1
            }
            else if (month >= 5 && month <= 8)
            {
                semester = 2; // Học kỳ 2
            }
            else // month >= 9 && month <= 12
            {
                semester = 3; // Học kỳ 3
            }

            viewTab5 = DatabaseHandler.GetResultCourseRegister(year, semester);


            // Đánh số hàng
            for (int i = 0; i < viewTab5.Rows.Count; i++)
            {
                viewTab5.Rows[i]["STT"] = i + 1;

            }
            resultCourseRegister_dataGridView.DataSource = viewTab5;

        }


        #endregion

        private void lookUp_Btn_Click(object sender, EventArgs e)
        {
            // tab 2

            // get selected value of year and semeseter
            string year = year_ComboBox.SelectedItem as string;
            string semester = semester_ComboBox.SelectedItem as string;

            if (year == null || semester == null) { return; }

            int yearValue, semesterValue;
            if (year.Equals("Tất cả")) {
                yearValue = -1;
            } else
            {
                yearValue = Int32.Parse(year);
            }

            if (semester.Equals("Tất cả"))
            {
                semesterValue = -1;
            } else
            {
                semesterValue = Int32.Parse(semester);
            }

            viewTab2 = DatabaseHandler.GetAllCourseResult(yearValue, semesterValue);

            // Đánh số hàng
            for (int i = 0; i < viewTab2.Rows.Count; i++)
            {
                viewTab2.Rows[i]["STT"] = i + 1;
            }

            resultLookup_dataGridView.DataSource = viewTab2;
        }

        private void lookupKHMO_Btn_Click(object sender, EventArgs e)
        {
            // tab 3

            // get selected value of year and semeseter
            string year = yearKHM_ComboBox.SelectedItem as string;
            string semester = semesterKHMO_ComboBox.SelectedItem as string;

            if (year == null || semester == null) { return; }

            int yearValue, semesterValue;
            if (year.Equals("Tất cả"))
            {
                yearValue = -1;
            }
            else
            {
                yearValue = Int32.Parse(year);
            }

            if (semester.Equals("Tất cả"))
            {
                semesterValue = -1;
            }
            else
            {
                semesterValue = Int32.Parse(semester);
            }

            viewTab3 = DatabaseHandler.GetAll_KHMO_Tab3(yearValue, semesterValue);


            // Đánh số hàng
            for (int i = 0; i < viewTab3.Rows.Count; i++)
            {
                viewTab3.Rows[i]["STT"] = i + 1;
            }


            KHMO_dataGridView.DataSource = viewTab3;

        }
    }
}
