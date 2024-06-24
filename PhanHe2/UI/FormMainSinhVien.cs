using PhanHe2.UI.FormUpdate;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
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

        private DataTable viewTab4_1;
        private DataTable viewTab4_2;


        private void DKHP_TabPage_Loaded()
        {
            // check ngày hiện tại => học kỳ + năm 
            DateTime currentDate = DateTime.Now;
            int day = currentDate.Day;
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

            // Kiểm tra có phải khoảng thời gian đăng ký/ hiệu chỉnh học phần hay không
            bool canRegister = DatabaseHandler.CanRegisterCourses(day, month, year, semester);

            if (canRegister)
            {
                viewTab4_1 = DatabaseHandler.GetResultCourseRegister(year, semester);

                // Đánh số hàng
                for (int i = 0; i < viewTab4_1.Rows.Count; i++)
                {
                    viewTab4_1.Rows[i]["STT"] = i + 1;
                }

                courseRegister1_dataGridView.DataSource = viewTab4_1;

                viewTab4_2 = DatabaseHandler.GetAll_KHMO_UnRegister_Tab4(year, semester);

                // Đánh số hàng
                for (int i = 0; i < viewTab4_2.Rows.Count; i++)
                {
                    viewTab4_2.Rows[i]["STT"] = i + 1;
                }

                courseRegister2_dataGridView.DataSource = viewTab4_2;


            } else
            {
                DKHP_heading1_label.Text = "Hiện tại chưa đến thời điểm đăng ký học phần!";
                DKHP_heading1_label.ForeColor = Color.Red;

                DKHP_heading2_label.Visible = false;
                courseRegister1_dataGridView.Visible = false;
                courseRegister2_dataGridView.Visible = false;
                unRegister_Btn.Visible = false;
                courseRegister_Btn.Visible = false;
            }
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

        #region Xử lý tra cứu tab 2 + tab 3
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
        #endregion

        #region Xử lý đăng ký + hủy đăng ký học phần
        private void unRegister_Btn_Click(object sender, EventArgs e)
        {
            if (courseRegister1_dataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một hàng trước khi tiếp tục.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }


            foreach (DataGridViewRow row in courseRegister1_dataGridView.SelectedRows)
            {
                int nam = Convert.ToInt32(row.Cells["NAM"].Value); // Lấy giá trị của cột "NAM"
                int hk = Convert.ToInt32(row.Cells["HK"].Value); // Lấy giá trị của cột "HK"
                string maHP = row.Cells["MAHP"].Value.ToString(); // Lấy giá trị của cột "MAHP"

                string tenHP = row.Cells["TENHP"].Value.ToString(); // Lấy giá trị của cột "TENHP"

                var dk = new Models.DangKy
                {
                    Nam = nam,
                    HK = hk,
                    MaHP = maHP,
                };

                if (DatabaseHandler.HandleUnRegisterCourse(dk))
                {
                    //  hiển thị lên MessageBox
                    string message = $"Hủy đăng ký học phần {tenHP} thành công!";
                    MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    DKHP_TabPage_Loaded();
                    ResultDKHP_Tabpage_Loaded();

                }
                else
                {
                    MessageBox.Show("Có lỗi xảy ra, vui lòng thử lại sau.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        } 

        private void courseRegister_Btn_Click(object sender, EventArgs e)
        {
                if (courseRegister2_dataGridView.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn ít nhất một hàng trước khi tiếp tục.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

            foreach (DataGridViewRow row in courseRegister2_dataGridView.SelectedRows)
            {
                int nam = Convert.ToInt32(row.Cells["NAM"].Value); // Lấy giá trị của cột "NAM"
                int hk = Convert.ToInt32(row.Cells["HK"].Value); // Lấy giá trị của cột "HK"
                string maHP = row.Cells["MAHP"].Value.ToString(); // Lấy giá trị của cột "MAHP"

                string tenHP = row.Cells["TENHP"].Value.ToString(); // Lấy giá trị của cột "TENHP"

                var dk = new Models.DangKy
                {
                    Nam = nam,
                    HK = hk,
                    MaHP = maHP,
                };

                if (DatabaseHandler.HandleRegisterCourse(dk))
                {
                    //  hiển thị lên MessageBox
                    string message = $"Đăng ký học phần {tenHP} thành công!";
                    MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    DKHP_TabPage_Loaded();
                    ResultDKHP_Tabpage_Loaded();


                }
                else
                {
                    MessageBox.Show("Có lỗi xảy ra, vui lòng thử lại sau.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion

        private void FormMainSinhVien_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
            DatabaseHandler.Disconnect();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormDangXuat formDangXuat = new FormDangXuat();
            DialogResult dialogResult = formDangXuat.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                DatabaseHandler.Disconnect();
                this.Hide();
                FormDangNhap formDangNhap = new FormDangNhap();
                formDangNhap.Show();
            }
        }
    }
}
