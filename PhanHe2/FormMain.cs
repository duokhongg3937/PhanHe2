using System.Data;
using System.Windows.Forms;

namespace PhanHe2
{
    public partial class FormMain : Form
    {
        public FormMain(string username)
        {
            InitializeComponent();
            label1.Text = DatabaseHandler.GetUserRole(username);
            DataTable dataTable = DatabaseHandler.GetUserTable(DatabaseHandler.GetUserTableNames(username));
            dataGridView1.DataSource = dataTable;
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
            DatabaseHandler.Disconnect();
        }
    }
}
