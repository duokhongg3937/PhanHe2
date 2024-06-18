using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PhanHe2
{
    public partial class FormManHinhChinh : Form
    {
        private Dictionary<string, TabPage> _backupTabs;
        public FormManHinhChinh()
        {
            InitializeComponent();
            _backupTabs = new Dictionary<string, TabPage>
            {
                { "PHANCONG", tabPhanCong },
                { "DANGKY", tabPageDangKy },
            };
        }

        private void FormManHinhChinh_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
            DatabaseHandler.Disconnect();
        }

        private void FormManHinhChinh_Load(object sender, EventArgs e)
        {
            tabControl1.TabPages.RemoveByKey("tabPhanCong");
            tabControl1.TabPages.RemoveByKey("tabPageDangKy");
            foreach(var roleTablePriv in Program.roleTablePrivileges)
            {
                if (roleTablePriv.Privilege == "SELECT")
                {
                    switch (roleTablePriv.TableName)
                    {
                        case "SINHVIEN":
                            FormSinhVien formSinhVien = new FormSinhVien(roleTablePriv) { TopLevel = false };
                            panel2.Controls.Add(formSinhVien);
                            formSinhVien.Show();
                            break;
                        case "UV_XEMTHONGTINCANHAN":
                            FormNhanSu formThongTinCaNhan = new FormNhanSu(roleTablePriv) { TopLevel = false };
                            panel1.Controls.Add(formThongTinCaNhan);
                            formThongTinCaNhan.Show();
                            break;
                        case "NHANSU":
                            FormNhanSu formNhanSu = new FormNhanSu(roleTablePriv) { TopLevel = false };
                            panel1.Controls.Add(formNhanSu);
                            formNhanSu.Show();
                            break;
                        case "DONVI":
                            FormDonVi formDonVi = new FormDonVi(roleTablePriv) { TopLevel = false };
                            panel3.Controls.Add(formDonVi);
                            formDonVi.Show();
                            break;
                        case "HOCPHAN":
                            FormHocPhan formHocPhan = new FormHocPhan(roleTablePriv) { TopLevel = false };
                            panel4.Controls.Add(formHocPhan);
                            formHocPhan.Show();
                            break;
                        case "KHMO":
                            FormKeHoachMo formKHMo = new FormKeHoachMo(roleTablePriv) { TopLevel = false };
                            panel5.Controls.Add(formKHMo);
                            formKHMo.Show();
                            break;
                        case "PHANCONG":
                            tabControl1.TabPages.Add(_backupTabs["PHANCONG"]);
                            FormPhanCong formPhanCong = new FormPhanCong(roleTablePriv) { TopLevel = false}; ;
                            panel6.Controls.Add(formPhanCong);
                            formPhanCong.Show();
                            break;
                        case "DANGKY":
                            tabControl1.TabPages.Add(_backupTabs["DANGKY"]);
                            FormDangKy formDangKy = new FormDangKy(roleTablePriv) { TopLevel = false }; ;
                            panel7.Controls.Add(formDangKy);
                            formDangKy.Show();
                            break;
                    }
                }
            }
        }
    }
}
