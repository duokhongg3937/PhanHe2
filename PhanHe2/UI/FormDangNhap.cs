﻿using PhanHe2.UI;
using System;
using System.Windows.Forms;

namespace PhanHe2
{
    public partial class FormDangNhap : Form
    {
        public FormDangNhap()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txt_username.Text.Trim();
            string password = txt_password.Text.Trim();

            ConnectionResult connectionResult = DatabaseHandler.Connect(username, password);

            if (connectionResult.Status == ConnectionStatus.Success)
            {
                Program.role = DatabaseHandler.GetUserRole(username);
                Program.roleTablePrivileges = DatabaseHandler.GetRoleTablePrivileges();
                
                if (DatabaseHandler.IsStudent())
                {
                    FormMainSinhVien formSinhVien = new FormMainSinhVien();
                    formSinhVien.Show();
                } else
                {
                    FormManHinhChinh formManHinhChinh = new FormManHinhChinh();
                    formManHinhChinh.Show();
                }

                
                this.Hide();
            }
            else
            {
                MessageBox.Show(connectionResult.Message);
            }
        }
    }
}
