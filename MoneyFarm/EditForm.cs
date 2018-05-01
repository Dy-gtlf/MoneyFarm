using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MoneyFarm
{
    public partial class EditForm : Form
    {
        private DataGridViewRow targetRow = new DataGridViewRow();

        public EditForm(DataGridViewRow row)
        {
            InitializeComponent();
            targetRow = row;
        }

        private void EditForm_Load(object sender, EventArgs e)
        {
            // 初期値の設定
            EditLogDataGridView.Rows.Add();
            var balance = (string)targetRow.Cells["Balance1"].Value;
            // 収支によって編集可能なカテゴリを設定
            if (balance == "支出")
            {
                var expenseCategories = Properties.Settings.Default.ExpenseCategories.Cast<string>().ToArray();
                ((DataGridViewComboBoxColumn)EditLogDataGridView.Columns["Category"]).Items.AddRange(expenseCategories.Concat(new[] { "その他" }).ToArray());
            }
            else if (balance == "収入")
            {
                var incomeCategories = Properties.Settings.Default.IncomeCategories.Cast<string>().ToArray();
                ((DataGridViewComboBoxColumn)EditLogDataGridView.Columns["Category"]).Items.AddRange(incomeCategories.Concat(new[] { "その他" }).ToArray());
            }
            // 選択データの値を初期値とする
            EditLogDataGridView.Rows[0].Cells["Balance"].Value = ((DataGridViewComboBoxColumn)EditLogDataGridView.Columns["Balance"]).Items[((DataGridViewComboBoxColumn)EditLogDataGridView.Columns["Balance"]).Items.IndexOf(balance)];
            EditLogDataGridView.Rows[0].Cells["Category"].Value = ((DataGridViewComboBoxColumn)EditLogDataGridView.Columns["Category"]).Items[((DataGridViewComboBoxColumn)EditLogDataGridView.Columns["Category"]).Items.IndexOf(targetRow.Cells["Category1"].Value)];
            EditLogDataGridView.Rows[0].Cells["Detail"].Value = targetRow.Cells["Detail1"].Value;
            EditLogDataGridView.Rows[0].Cells["Amount"].Value = targetRow.Cells["Amount1"].Value;
            EditLogDataGridView.Rows[0].Cells["Date"].Value = DateTime.Now.ToShortDateString();
            EditLogDataGridView.EndEdit();
        }

        /// <summary>
        /// アクティブなセルを編集モードにする
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditLogDataGridView_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            EditLogDataGridView.BeginEdit(true);
        }

        /// <summary>
        /// 入力チェック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditLogDataGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            // 金額がintに変換できないなら
            if (e.ColumnIndex == EditLogDataGridView.Columns["Amount"].Index && int.TryParse((string)e.FormattedValue, out int result) == false)
            {
                MessageBox.Show(this, $"{EditLogDataGridView.Columns[e.ColumnIndex].HeaderText} には0以上の数値のみ入力できます。", "入力値エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ((DataGridView)sender).CancelEdit();
                e.Cancel = true;
            }
            // 金額が負の数値なら
            else if (e.ColumnIndex == EditLogDataGridView.Columns["Amount"].Index && int.Parse((string)e.FormattedValue) < 0)
            {
                MessageBox.Show(this, $"{EditLogDataGridView.Columns[e.ColumnIndex].HeaderText} には0以上の数値のみ入力できます。", "入力値エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ((DataGridView)sender).CancelEdit();
                e.Cancel = true;
            }
            // 収支が変更されていたなら
            if (e.ColumnIndex == EditLogDataGridView.Columns["Balance"].Index && (string)e.FormattedValue != (string)EditLogDataGridView.CurrentCell.Value)
            {
                // その他に選択肢を退避させる
                if ((string)EditLogDataGridView.Rows[e.RowIndex].Cells["Category"].Value != "その他")
                {
                    EditLogDataGridView.Rows[e.RowIndex].Cells["Category"].Value = ((DataGridViewComboBoxColumn)EditLogDataGridView.Columns["Category"]).Items[((DataGridViewComboBoxColumn)EditLogDataGridView.Columns["Category"]).Items.IndexOf("その他")];
                }
                // カテゴリの候補を変更
                if ((string)e.FormattedValue == "支出")
                {
                    var expenseCategories = Properties.Settings.Default.ExpenseCategories.Cast<string>().ToArray().Concat(new[] { "その他" }).ToArray();
                    ((DataGridViewComboBoxColumn)EditLogDataGridView.Columns["Category"]).DataSource = expenseCategories;
                }
                else if ((string)e.FormattedValue == "収入")
                {
                    var incomeCategories = Properties.Settings.Default.IncomeCategories.Cast<string>().ToArray().Concat(new[] { "その他" }).ToArray();
                    ((DataGridViewComboBoxColumn)EditLogDataGridView.Columns["Category"]).DataSource = incomeCategories;
                }
                // 初期値に設定
                EditLogDataGridView.Rows[e.RowIndex].Cells["Category"].Value = ((DataGridViewComboBoxColumn)EditLogDataGridView.Columns["Category"]).Items[0];
            }
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            targetRow.Cells["Category1"].Value = EditLogDataGridView.Rows[0].Cells["Category"].Value;
            targetRow.Cells["Balance1"].Value = EditLogDataGridView.Rows[0].Cells["Balance"].Value;
            targetRow.Cells["Detail1"].Value = EditLogDataGridView.Rows[0].Cells["Detail"].Value;
            targetRow.Cells["Amount1"].Value = EditLogDataGridView.Rows[0].Cells["Amount"].Value;
            targetRow.Cells["Date1"].Value = EditLogDataGridView.Rows[0].Cells["Date"].Value;
            Close();
        }
    }
}
