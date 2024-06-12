﻿using System;
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
            string username = txtBoxUsername.Text.Trim();
            string password = txtBoxPassword.Text.Trim();

            ConnectionResult connectionResult = DatabaseHandler.Connect(username, password);

            if (connectionResult.Status == ConnectionStatus.Success)
            {
                Program.role = DatabaseHandler.GetUserRole(username);
                if (Program.role == "C##RL_NHANVIENCOBAN")
                {
                    FormNVCoBan formNVCoBan = new FormNVCoBan();
                    formNVCoBan.Show();
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
