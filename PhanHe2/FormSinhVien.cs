using System.Windows.Forms;

namespace PhanHe2
{
    public partial class FormSinhVien : Form
    {
        private string _owner;
        public FormSinhVien(string owner)
        {
            InitializeComponent();
            _owner = owner;
        }
    }
}
