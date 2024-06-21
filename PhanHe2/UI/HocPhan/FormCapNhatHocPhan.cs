using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PhanHe2.UI.HocPhan
{
    public partial class FormCapNhatHocPhan : Form
    {
        private string _owner;
        private string _tableName;
        private DataGridViewRow _row;
        private List<string> _colsCanBeUpdated;
        private Dictionary<string, Control> _colNameDict;
        public FormCapNhatHocPhan(string owner, string tableName, DataGridViewRow row, List<string> colsCanBeUpdated)
        {
            InitializeComponent();
            _owner = owner;
            _tableName = tableName;
            _row = row;
            _colsCanBeUpdated = colsCanBeUpdated;

            _colNameDict = new Dictionary<string, Control>()
            {
                { "MAHP", txtBoxMaHP },
                { "TENHP", txtBoxTenHP },
                { "MADV", txtBoxMaDV },
                { "STLT", numSTLT },
                { "STTH", numSTTH },
                { "SOSVTD", numSOSVTD }
            };
        }

        private void FormCapNhatHocPhan_Load(object sender, EventArgs e)
        {
            foreach (DataGridViewCell cell in _row.Cells)
            {
                if (_colNameDict.ContainsKey(cell.OwningColumn.Name))
                {
                    _colNameDict[cell.OwningColumn.Name].Text = cell.Value.ToString();
                }
            }

            if (_colsCanBeUpdated.Count == 0)
            {
                foreach (Control control in _colNameDict.Values)
                {
                    if (control is TextBox txtBox)
                    {
                        txtBox.ReadOnly = false;
                    }
                    else if (control is NumericUpDown numericUpDown)
                    {
                        numericUpDown.ReadOnly = false;
                    }
                }
            }
            else
            {
                foreach (string colName in _colsCanBeUpdated)
                {
                    if (_colNameDict[colName] is TextBox txtBox)
                    {
                        txtBox.ReadOnly = false;
                    } else if (_colNameDict[colName] is NumericUpDown numericUpDown)
                    {
                        numericUpDown.ReadOnly = false;
                    }
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
                updatedColNames = _colNameDict.Keys.ToList();
            }
            else
            {
                updatedColNames = _colsCanBeUpdated;
            }

            foreach (string colName in updatedColNames)
            {
                string updatedValue = _colNameDict[colName].Text.ToString();
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
