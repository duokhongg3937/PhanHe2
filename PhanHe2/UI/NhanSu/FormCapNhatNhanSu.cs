using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace PhanHe2
{
    public partial class FormCapNhatNhanSu : Form
    {
        private string _owner;
        private string _tableName;
        private DataGridViewRow _row;
        private List<string> _colsCanBeUpdated;
        private SortedDictionary<string, Control> _colNameDict;
        public FormCapNhatNhanSu(string owner, string tableName, DataGridViewRow row, List<string> colsCanBeUpdated)
        {
            InitializeComponent();
            _owner = owner;
            _tableName = tableName;
            _row = row;
            _colsCanBeUpdated = colsCanBeUpdated;

            _colNameDict = new SortedDictionary<string, Control>
            {
                { "MANV", txtBoxMaNV },
                { "HOTEN", txtBoxHoTen },
                { "PHAI", txtBoxPhai },
                { "NGSINH", dateNgaySinh },
                { "PHUCAP", numPhuCap },
                { "SDT", txtBoxSDT },
                { "VAITRO", txtBoxVaiTro },
                { "MADV", txtBoxMaDV },
            };

        }

        private void FormCapNhatNhanSu_Load(object sender, EventArgs e)
        {
            foreach (DataGridViewCell cell in _row.Cells)
            {
                if (_colNameDict[cell.OwningColumn.Name] is NumericUpDown numericUpDown)
                {
                    numericUpDown.Value = Convert.ToDecimal(cell.Value);
                }
                else
                {
                    _colNameDict[cell.OwningColumn.Name].Text = cell.Value.ToString();
                }
            }

            if (_colsCanBeUpdated.Count == 0)
            {
                _colsCanBeUpdated = _colNameDict.Keys.ToList();
                foreach (Control control in _colNameDict.Values)
                {
                    if (control is TextBox txtBox && txtBox != txtBoxMaNV)
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
                    if (_colNameDict[colName] is TextBox txtBox && colName != "MANV")
                    {
                        txtBox.ReadOnly = false;
                    }
                    else if (_colNameDict[colName] is NumericUpDown numericUpDown)
                    {
                        numericUpDown.ReadOnly = false;
                    }
                }
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;

            foreach (string colName in _colsCanBeUpdated)
            {
                object updatedValue = null;

                if (_colNameDict[colName] is TextBox textBox) updatedValue = textBox.Text;
                else if (_colNameDict[colName] is NumericUpDown numericUpDown) updatedValue = numericUpDown.Value;
                else if (_colNameDict[colName] is DateTimePicker dateTimePicker) updatedValue = dateTimePicker.Value;

                if (updatedValue.ToString() != _row.Cells[colName].Value.ToString())
                {
                    bool updateSuccess = DatabaseHandler.UpdateCell(_owner, _tableName, colName, updatedValue, "MANV", _colNameDict["MANV"].Text);

                    if (updateSuccess)
                    {
                        MessageBox.Show($"Update cột {colName} bảng {_tableName} thành công!", "Update thành công");
                    }
                    else
                    {
                        MessageBox.Show($"Update cột {colName} bảng {_tableName} thất bại!", "Update thất bại");
                    }
                }
            }

            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
