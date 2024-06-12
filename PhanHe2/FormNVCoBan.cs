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
            FormNhanSu formNhanSu = new FormNhanSu();
            formNhanSu.TopLevel = false;
            tabPageNhanSu.Controls.Add(formNhanSu);
            formNhanSu.Show();
        }
    }
}
