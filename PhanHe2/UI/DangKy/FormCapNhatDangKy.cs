using PhanHe2.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PhanHe2
{
    public partial class FormCapNhatDangKy : Form
    {
        private RoleTablePrivilege _roleTabPriv;
        private DataGridViewRow _row;
        private List<string> _colsCanBeUpdated;
        private SortedDictionary<string, Control> colNameDict;

        public FormCapNhatDangKy(RoleTablePrivilege roleTabPriv, DataGridViewRow row, List<string> colsCanBeUpdated)
        {
            InitializeComponent();
            
            _roleTabPriv = roleTabPriv;
            _row = row;
            _colsCanBeUpdated = colsCanBeUpdated;

            colNameDict = new SortedDictionary<string, Control>
            {
                { "MASV", txtBoxMaSV },
                { "MAGV", txtBoxMaGV },
                { "MAHP", txtBoxMaHP },
                { "HK", txtBoxHocKy },
                { "NAM", txtBoxNam },
                { "MACT", txtBoxMaCT },
                { "DIEMTH", numDTH },
                { "DIEMQT", numDQT },
                { "DIEMCK", numDCK },
                { "DIEMTK", numDTK },
            };
        }

        private void FormCapNhatDangKy_Load(object sender, System.EventArgs e)
        {
            foreach (DataGridViewCell cell in _row.Cells)
            {
                if (colNameDict[cell.OwningColumn.Name] is NumericUpDown numericUpDown)
                {
                    numericUpDown.Value = Convert.ToDecimal(cell.Value);
                } 
                else
                {
                    colNameDict[cell.OwningColumn.Name].Text = cell.Value.ToString();
                }  
            }

            foreach (string colName in _colsCanBeUpdated)
            {
                if (colNameDict[colName] is NumericUpDown numericUpDown)
                {
                    numericUpDown.ReadOnly = false;
                }
                else if (colNameDict[colName] is TextBox txtBox)
                {
                    txtBox.ReadOnly = false;
                }
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;

            foreach (string colName in _colsCanBeUpdated)
            {
                object updatedValue;

                if (colNameDict[colName] is NumericUpDown numericUpDown)
                {
                    updatedValue = (float) numericUpDown.Value;
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
