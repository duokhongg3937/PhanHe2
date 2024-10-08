﻿using PhanHe2.UI.ThongTinCaNhan;
using System;
using System.Collections.Generic;
using System.Data;
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
                { "NHANSU", tabPageNhanSu },
                { "UV_XEMTHONGTINCANHAN", tabPageTTCaNhan },

            };
        }

        private void FormManHinhChinh_FormClosing(object sender, FormClosingEventArgs e)
        {
            DatabaseHandler.Disconnect();
            Application.Exit();
        }

        private void FormManHinhChinh_Load(object sender, EventArgs e)
        {
            tabControl1.TabPages.RemoveByKey("tabPhanCong");
            tabControl1.TabPages.RemoveByKey("tabPageDangKy");
            tabControl1.TabPages.RemoveByKey("tabPageNhanSu");
            tabControl1.TabPages.RemoveByKey("tabPageTTCaNhan");


            foreach (var roleTablePriv in Program.roleTablePrivileges)
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
                            tabControl1.TabPages.Add(_backupTabs["UV_XEMTHONGTINCANHAN"]);
                            FormThongTinCaNhan formThongTinCaNhan = new FormThongTinCaNhan(roleTablePriv) { TopLevel = false };
                            panel8.Controls.Add(formThongTinCaNhan);
                            formThongTinCaNhan.Show();
                            break;
                        case "NHANSU":
                            tabControl1.TabPages.Add(_backupTabs["NHANSU"]);
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
            Notification_TabPage_Loaded();

        }

        private void Notification_TabPage_Loaded()
        {
            DataTable notification = DatabaseHandler.GetNotification();
            notification_dataGridView.DataSource = notification;
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
