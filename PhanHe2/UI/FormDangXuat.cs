using System;
using System.Windows.Forms;

namespace PhanHe2
{
    public partial class FormDangXuat : Form
    {
        public FormDangXuat()
        {
            InitializeComponent();
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
