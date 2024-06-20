using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PhanHe2.UI.DonVi
{
    public partial class FormCapNhatDonVi : Form
    {
        private string _owner;
        private string _tableName;
        private DataGridViewRow _row;
        private List<string> _colsCanBeUpdated;
        private SortedDictionary<string, TextBox> colNameDict;
        public FormCapNhatDonVi(string owner, string tableName, DataGridViewRow row, List<string> colsCanBeUpdated)
        {
            InitializeComponent();
            _owner = owner;
            _tableName = tableName;
            _row = row;
            _colsCanBeUpdated = colsCanBeUpdated;

            colNameDict = new SortedDictionary<string, TextBox>
            {
                { "TENDV", txtBoxTenDV },
                { "TRGDV", txtBoxTRGDV }
            };
        }

        private void FormCapNhatDonVi_Load(object sender, System.EventArgs e)
        {
            foreach (DataGridViewCell cell in _row.Cells)
            {
                if (colNameDict.ContainsKey(cell.OwningColumn.Name))
                {
                    colNameDict[cell.OwningColumn.Name].Text = cell.Value.ToString();   
                }
            }

            if (_colsCanBeUpdated.Count == 0)
            {
                foreach (TextBox txtBox in colNameDict.Values)
                {
                    txtBox.ReadOnly = false;
                }
            } 
            else
            {
                foreach (string colName in _colsCanBeUpdated)
                {
                    colNameDict[colName].ReadOnly = false;
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            List<string> updatedColNames;

            if (_colsCanBeUpdated.Count == 0)
            {
                updatedColNames = colNameDict.Keys.ToList();
            } 
            else
            {
                updatedColNames = _colsCanBeUpdated;
            }

            foreach (string colName in updatedColNames)
            {
                string updatedValue = colNameDict[colName].Text.ToString();
                bool updateSuccess = DatabaseHandler.UpdateCell(_owner, _tableName, colName, updatedValue, "MADV", _row.Cells["MADV"].Value);

                if (updateSuccess)
                {
                    DialogResult = DialogResult.OK;
                    MessageBox.Show($"Update cột {colName} bảng {_tableName} thành công!", "Update thành công");
                }
                else
                {
                    MessageBox.Show($"Update cột {colName} bảng {_tableName} thất bại!", "Update thất bại");
                }
            }

            Close();
        }
    }
}
