using PhanHe2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PhanHe2.UI.SinhVien
{
    public partial class FormCapNhatSinhVien : Form
    {
        private RoleTablePrivilege _roleTabPriv;
        private DataGridViewRow _row;
        private List<string> _colsCanBeUpdated;
        private SortedDictionary<string, Control> colNameDict;

        public FormCapNhatSinhVien(RoleTablePrivilege roleTabPriv, DataGridViewRow row, List<string> colsCanBeUpdated)
        {
            InitializeComponent();

            _roleTabPriv = roleTabPriv;
            _row = row;
            _colsCanBeUpdated = colsCanBeUpdated;

            colNameDict = new SortedDictionary<string, Control>
            {
                { "HOTEN", txtBoxHoTen },
                { "PHAI", txtBoxPhai },
                { "DCHI", txtBoxDiaChi },
                { "NGSINH", dateNgaySinh },
                { "SDT", txtBoxSDT },
                { "MACT", txtBoxMaCT },
                { "MANGANH", txtBoxMaNganh }
            };
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;

            if (_colsCanBeUpdated.Count == 0)
            {
                _colsCanBeUpdated = colNameDict.Keys.ToList();
            }

            foreach (string colName in _colsCanBeUpdated)
            {
                object updatedValue;

                if (colNameDict[colName] is DateTimePicker dateTimePicker)
                {
                    updatedValue = dateTimePicker.Value;
                }
                else
                {
                    updatedValue = colNameDict[colName].Text;
                }

                if (updatedValue.ToString() != _row.Cells[colName].Value.ToString())
                {
                    bool updateSuccess = DatabaseHandler.UpdateCell(_roleTabPriv.Owner, _roleTabPriv.TableName, colName, updatedValue, "MASV", _row.Cells["MASV"].Value);

                    if (updateSuccess)
                    {
                        MessageBox.Show($"Update cột {colName} bảng {_roleTabPriv.TableName} thành công!", "Update thành công");
                    }
                    else
                    {
                        MessageBox.Show($"Update cột {colName} bảng {_roleTabPriv.TableName} thất bại!", "Update thất bại");
                    }
                }
            }

            Close();
        }

        private void FormCapNhatSinhVien_Load(object sender, EventArgs e)
        {
            foreach (DataGridViewCell cell in _row.Cells)
            {
                if (colNameDict.ContainsKey(cell.OwningColumn.Name))
                {
                    if (colNameDict[cell.OwningColumn.Name] is DateTimePicker dateTimePicker)
                    {
                        dateTimePicker.Value = (DateTime)cell.Value;
                    }
                    else
                    {
                        colNameDict[cell.OwningColumn.Name].Text = cell.Value.ToString();
                    }
                }
            }

            foreach (string colName in _colsCanBeUpdated)
            {
                if (colNameDict[colName] is TextBox txtBox)
                {
                    txtBox.ReadOnly = false;
                }
            }
        }
    }
}
