using PhanHe2.Models;
using System;
using System.Windows.Forms;

namespace PhanHe2
{
    public partial class FormNVCoBan : Form
    {
        public FormNVCoBan()
        {
            InitializeComponent();
        }

        private void FormNVCoBan_FormClosing(object sender, FormClosingEventArgs e)
        {

            Application.Exit();
            DatabaseHandler.Disconnect();
        }

        private void FormNVCoBan_Load(object sender, EventArgs e)
        {
            foreach(var roleTablePriv in Program.roleTablePrivileges)
            {
                if (roleTablePriv.Privilege == "SELECT")
                {
                    switch (roleTablePriv.TableName)
                    {
                        case "SINHVIEN":
                            FormSinhVien formSinhVien = new FormSinhVien(roleTablePriv.Owner) { TopLevel = false };
                            panel2.Controls.Add(formSinhVien);
                            formSinhVien.Show();
                            break;
                        case "UV_XEMTHONGTINCANHAN":
                            FormNhanSu formThongTinCaNhan = new FormNhanSu(roleTablePriv.Owner, roleTablePriv.TableName) { TopLevel = false };
                            panel1.Controls.Add(formThongTinCaNhan);
                            formThongTinCaNhan.Show();
                            break;
                        case "NHANSU":
                            FormNhanSu formNhanSu = new FormNhanSu(roleTablePriv.Owner, roleTablePriv.TableName) { TopLevel = false };
                            panel1.Controls.Add(formNhanSu);
                            formNhanSu.Show();
                            break;
                        case "DONVI":
                            FormDonVi formDonVi = new FormDonVi() { TopLevel = false };
                            tabPageDonVi.Controls.Add(formDonVi);
                            formDonVi.Show();
                            break;
                        case "HOCPHAN":
                            FormHocPhan formHocPhan = new FormHocPhan() { TopLevel = false };
                            tabPageHocPhan.Controls.Add(formHocPhan);
                            formHocPhan.Show();
                            break;
                        case "KHMO":
                            FormKeHoachMo formKHMo = new FormKeHoachMo() { TopLevel = false };
                            tabPageKHMo.Controls.Add(formKHMo);
                            formKHMo.Show();
                            break;
                    }
                }
            }
        }
    }
}
