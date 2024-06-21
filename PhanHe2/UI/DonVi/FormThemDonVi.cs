using System.Collections.Generic;
using System.Windows.Forms;

namespace PhanHe2.UI.DonVi
{
    public partial class FormThemDonVi : Form
    {
        private string _owner;
        private string _tableName;
        public FormThemDonVi(string owner, string tableName)
        {
            InitializeComponent();
            _owner = owner;
            _tableName = tableName;
            txtBoxTenDV.ReadOnly = false;
            txtBoxTRGDV.ReadOnly = false;   
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnOk_Click(object sender, System.EventArgs e)
        {
            string tenDV = txtBoxTenDV.Text;
            string trgDV = txtBoxTRGDV.Text;

            if (trgDV.Length == 0) { trgDV = null; }

            Dictionary<string, object> colValues = new Dictionary<string, object>()
            {
                { "TENDV", tenDV }, { "TRGDV", trgDV }
            };

            bool insertSuccess = DatabaseHandler.Insert(_owner, _tableName, colValues);

            if (insertSuccess)
            {
                DialogResult = DialogResult.OK;
                MessageBox.Show($"Thành công thêm đơn vị!", "Insert thành công");
            }
            else
            {
                DialogResult = DialogResult.Cancel;
                MessageBox.Show($"Không thể thêm đơn vị!", "Insert thất bại");
            }

            Close();
        }
    }
}
