using PhanHe2.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace PhanHe2
{
    public partial class FormCapNhatNhanSu : Form
    {
        private string _owner;
        private string _tableName;
        private DataRow _row;
        private List<string> _colsCanBeUpdated;
        private SortedDictionary<string, TextBox> colNameDict;
        public FormCapNhatNhanSu(string owner, string tableName, DataRow row, List<string> colsCanBeUpdated)
        {
            InitializeComponent();
            _owner = owner;
            _tableName = tableName;
            _row = row;
            _colsCanBeUpdated = colsCanBeUpdated;

            colNameDict = new SortedDictionary<string, TextBox>
            {
                { "MANV", txtBoxMaNV },
                { "HOTEN", txtBoxHoTen },
                { "PHAI", txtBoxPhai },
                { "NGSINH", txtBoxNgaySinh },
                { "PHUCAP", txtBoxPhuCap },
                { "SDT", txtBoxSDT },
                { "VAITRO", txtBoxVaiTro },
                { "MADV", txtBoxMaDV },
            };

        }

        private void FormCapNhatNhanSu_Load(object sender, EventArgs e)
        {
            foreach (DataColumn col in _row.Table.Columns)
            {
                colNameDict[col.ColumnName].Text = _row[col.ColumnName].ToString();
            }

            foreach (string colName in _colsCanBeUpdated)
            {
                colNameDict[colName].ReadOnly = false;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;

            foreach (string colName in _colsCanBeUpdated)
            {
                string updatedValue = colNameDict[colName].Text.ToString();
                bool updateSuccess = DatabaseHandler.UpdateCell(_owner, _tableName, colName, updatedValue);

                if (updateSuccess)
                {
                    MessageBox.Show($"Update cột {colName} bảng {_tableName} thành công!", "Update thành công");
                }
                else
                {
                    MessageBox.Show($"Update cột {colName} bảng {_tableName} thất bại!", "Update thất bại");
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
