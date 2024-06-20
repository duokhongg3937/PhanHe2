using PhanHe2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PhanHe2.UI.KeHoachMo
{
    public partial class FormCapNhatKeHoachMo : Form
    {
        private RoleTablePrivilege _roleTabPriv;
        private DataGridViewRow _row;
        private List<string> _colsCanBeUpdated;
        private SortedDictionary<string, Control> _colNameDict;

        public FormCapNhatKeHoachMo(RoleTablePrivilege roleTabPriv, DataGridViewRow row, List<string> colsCanBeUpdated)
        {
            InitializeComponent();
            
            _roleTabPriv = roleTabPriv;
            _row = row;
            _colsCanBeUpdated = colsCanBeUpdated;

            _colNameDict = new SortedDictionary<string, Control>()
            {
                { "MACT", txtBoxMaCT },
                { "MAHP", txtBoxMaHP },
                { "HK", numHK },
                { "NAM", numNam },
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
            List<string> colNames;
            Dictionary<string, object> updates = new Dictionary<string, object>();
            Dictionary<string, object> conditions = new Dictionary<string, object>()
            {
                { "MAHP", _row.Cells["MAHP"].Value },
                { "MACT", _row.Cells["MACT"].Value },
                { "HK", _row.Cells["HK"].Value },
                { "NAM", _row.Cells["NAM"].Value },
            };

            if (_colsCanBeUpdated.Count == 0)
            {
                colNames = conditions.Keys.ToList();
            } 
            else
            {
                colNames = _colsCanBeUpdated;
            }

            foreach (string colName in colNames)
            {
                object updatedValue;

                if (_colNameDict[colName] is NumericUpDown numericUpDown)
                {
                    updatedValue = (float)numericUpDown.Value;
                }
                else
                {
                    updatedValue = _colNameDict[colName].Text;
                }

                if (updatedValue.ToString() != _row.Cells[colName].Value.ToString())
                {
                    updates.Add(colName, updatedValue);
                }
            }
            try
            {
                bool updateSuccess = DatabaseHandler.UpdateCell(_roleTabPriv.Owner, _roleTabPriv.TableName, updates, conditions);

                if (updateSuccess)
                {
                    MessageBox.Show($"Update bảng {_roleTabPriv.TableName} thành công!", "Update thành công");
                }
                else
                {
                    MessageBox.Show($"Update bảng {_roleTabPriv.TableName} thất bại!", "Update thất bại");
                }
            } 
            catch (Exception ex)
            {
                MessageBox.Show($"Update lỗi: {ex.Message}", "Update thất bại");
            }
            

            Close();
        }

        private void FormCapNhatKeHoachMo_Load(object sender, EventArgs e)
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
                    }
                    else if (_colNameDict[colName] is NumericUpDown numericUpDown)
                    {
                        numericUpDown.ReadOnly = false;
                    }
                }
            }
        }
    }
}
