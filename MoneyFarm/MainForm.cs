using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace MoneyFarm
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// フォームロード時のイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, System.EventArgs e)
        {
            // LogsDataGridViewの設定
            // データをバインドしているとき、["カラム名"]指定だとnullになるのでカラムのインデックスで指定
            var expenseCategories = Properties.Settings.Default.ExpenseCategories.Cast<string>().ToArray();
            var incomeCategories = Properties.Settings.Default.IncomeCategories.Cast<string>().ToArray();
            var allCategories = expenseCategories.Concat(incomeCategories).Concat(new[] { "その他" }).ToArray();

            ((DataGridViewComboBoxColumn)LogsDataGridView.Columns["Category1"]).Items.AddRange(allCategories);
            ((DataGridViewComboBoxColumn)LogsDataGridView.Columns["Category1"]).DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
            ((DataGridViewComboBoxColumn)LogsDataGridView.Columns["Balance1"]).DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
            LogsDataGridView.Columns["Balance1"].ReadOnly = true;

            // NewLogDataGridViewの設定
            ((DataGridViewComboBoxColumn)NewLogDataGridView.Columns["Category"]).Items.AddRange(allCategories);
            ((DataGridViewComboBoxColumn)NewLogDataGridView.Columns["Category"]).DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
            ((DataGridViewComboBoxColumn)NewLogDataGridView.Columns["Balance"]).DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
            // データベースの内容を同期
            logsTableAdapter.Fill(moneyFarmDataBaseDataSet.Logs);
            // フィルターのComboBoxの内容を設定
            CategoriesComboBox.Items.Add("すべてのカテゴリ");
            CategoriesComboBox.Items.AddRange(allCategories);
            // 未選択状態の空白を表示しない
            CategoriesComboBox.SelectedIndex = 0;
            BalanceComboBox.SelectedIndex = 0;
            // 今日から1ヶ月以内を表示
            DateTimePicker2.Value = DateTime.Now;
            DateTimePicker1.Value = DateTime.Now.AddMonths(-1);
            FilterAndSortLogsDataGridView();
            // 新規データの初期値を設定
            NewLogDataGridView.Rows.Add();
            NewLogDataGridViewInit();

            // 編集モードになっているので解除
            LogsDataGridView.EndEdit();
            NewLogDataGridView.EndEdit();

            BalanceChartUpdate();
        }

        /// <summary>
        /// 表示更新のボタンをクリックしたときのイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FilterButton_Click(object sender, System.EventArgs e)
        {
            FilterAndSortLogsDataGridView();
        }

        /// <summary>
        /// LogsDataGridViewの表示を更新
        /// </summary>
        private void FilterAndSortLogsDataGridView()
        {
            // フィルター用の文字列
            string filter = "";
            if (CategoriesComboBox.SelectedIndex != 0)
            {
                filter += string.Format($"Category LIKE '{CategoriesComboBox.Text}' AND ");
            }
            if (BalanceComboBox.SelectedIndex != 0)
            {
                filter += string.Format($"Balance LIKE '{BalanceComboBox.Text}' AND ");
            }
            filter += string.Format($"Date >= '{DateTimePicker1.Value.ToShortDateString()}' AND ");
            filter += string.Format($"Date <= '{DateTimePicker2.Value.ToShortDateString()}'");
            // フィルターにセット
            logsBindingSource.Filter = filter;
            logsBindingSource.Sort = "Date";
            LogsDataGridView.ClearSelection();
        }

        /// <summary>
        /// 編集終了時にデータベースを更新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LogsDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            logsTableAdapter.Update(moneyFarmDataBaseDataSet);
            BalanceChartUpdate();
        }

        /// <summary>
        /// 新規データの初期化
        /// </summary>
        private void NewLogDataGridViewInit()
        {
            NewLogDataGridView.Rows[0].Cells["Category"].Value = ((DataGridViewComboBoxColumn)NewLogDataGridView.Columns["Category"]).Items[0].ToString();
            NewLogDataGridView.Rows[0].Cells["Detail"].Value = null;
            NewLogDataGridView.Rows[0].Cells["Balance"].Value = ((DataGridViewComboBoxColumn)NewLogDataGridView.Columns["Balance"]).Items[0].ToString();
            NewLogDataGridView.Rows[0].Cells["Amount"].Value = 0;
            NewLogDataGridView.Rows[0].Cells["Date"].Value = DateTime.Now.ToShortDateString();
        }

        /// <summary>
        /// 追加ボタンをクリックしたときのイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AdditionButton_Click(object sender, EventArgs e)
        {
            // 新規データ行の作成
            var table = moneyFarmDataBaseDataSet.Tables["Logs"];
            var newRow = table.NewRow();
            newRow["Category"] = NewLogDataGridView.Rows[0].Cells["Category"].Value;
            if (string.IsNullOrWhiteSpace((string)NewLogDataGridView.Rows[0].Cells["Detail"].Value))
            {
                newRow["Detail"] = null;
            } 
            else
            {
                newRow["Detail"] = NewLogDataGridView.Rows[0].Cells["Detail"].Value;
            }
            newRow["Balance"] = NewLogDataGridView.Rows[0].Cells["Balance"].Value;
            newRow["Amount"] = NewLogDataGridView.Rows[0].Cells["Amount"].Value;
            newRow["Date"] = NewLogDataGridView.Rows[0].Cells["Date"].Value;

            // 新規データの追加
            table.Rows.Add(newRow);
            logsTableAdapter.Update(moneyFarmDataBaseDataSet);
            // 入力項目の初期化
            NewLogDataGridViewInit();
            // 選択状態を解除
            LogsDataGridView.ClearSelection();
            NewLogDataGridView.ClearSelection();
        }

        /// <summary>
        /// 削除ボタンをクリックしたときのイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeletionButton_Click(object sender, EventArgs e)
        {
            // 選択しているデータがあるなら
            if (LogsDataGridView.SelectedRows.Count == 1)
            {
                var table = moneyFarmDataBaseDataSet.Tables["Logs"];
                var result = MessageBox.Show(this, "選択しているデータを削除しますか?", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
                // Yesを選択したなら削除
                if (result == DialogResult.Yes)
                {
                    var row = table.Rows[LogsDataGridView.SelectedRows[0].Index];
                    row.Delete();
                    logsTableAdapter.Update(moneyFarmDataBaseDataSet);
                    // 選択状態をクリア
                    LogsDataGridView.ClearSelection();
                }
            }
            // データが選択されていないなら
            else
            {
                MessageBox.Show(this, "データが選択されていません。", "データ未選択", MessageBoxButtons.OK ,MessageBoxIcon.Exclamation);
            }
        }

        /// <summary>
        /// LogsDataGridViewのアクティブなセルを編集モードにする
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LogsDataGridView_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            LogsDataGridView.BeginEdit(true);
        }

        /// <summary>
        /// NewLogDataGridViewのアクティブなセルを編集モードにする
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewLogDataGridView_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            NewLogDataGridView.BeginEdit(true);
        }

        /// <summary>
        /// 既存データの入力チェック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LogsDataGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            // 金額がintに変換できないなら
            if (e.ColumnIndex == LogsDataGridView.Columns["Amount1"].Index && int.TryParse(e.FormattedValue.ToString(), out int result) == false)
            {
                MessageBox.Show(this, $"{LogsDataGridView.Columns[e.ColumnIndex].HeaderText} には数値のみ入力できます。", "入力値エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ((DataGridView)sender).CancelEdit();
                e.Cancel = true;
            }
            // 支出のとき、新しいカテゴリが支出カテゴリに含まれていないなら却下
            else if (e.ColumnIndex == LogsDataGridView.Columns["Category1"].Index && (string)LogsDataGridView.Rows[e.RowIndex].Cells["Balance1"].Value == "支出")
            {
                var expenseCategories = Properties.Settings.Default.ExpenseCategories.Cast<string>().ToArray().Concat(new[] { "その他" }).ToArray();
                if (expenseCategories.Contains((string)e.FormattedValue) == false)
                { 
                    MessageBox.Show(this, $"支出のカテゴリでは、\n\n{string.Join("\n", expenseCategories)}\n\nが選択可能です。", "入力値エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ((DataGridView)sender).CancelEdit();
                    e.Cancel = true;
                }
            }
            // 収入のとき、新しい値が収入カテゴリに含まれていないなら却下
            else if (e.ColumnIndex == LogsDataGridView.Columns["Category1"].Index && (string)LogsDataGridView.Rows[e.RowIndex].Cells["Balance1"].Value == "収入")
            {
                var incomeCategories = Properties.Settings.Default.IncomeCategories.Cast<string>().ToArray().Concat(new[] { "その他" }).ToArray();
                if (incomeCategories.Contains((string)e.FormattedValue) == false)
                {
                    MessageBox.Show(this, $"収入のカテゴリでは、\n\n{string.Join("\n", incomeCategories)}\n\nが選択可能です。", "入力値エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ((DataGridView)sender).CancelEdit();
                    e.Cancel = true;
                }
            }
        }

        /// <summary>
        /// 新規データの入力チェック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewLogDataGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            // 金額がintに変換できないなら
            if (e.ColumnIndex == NewLogDataGridView.Columns["Amount"].Index && int.TryParse(e.FormattedValue.ToString(), out int result) == false)
            {
                MessageBox.Show(this, $"{NewLogDataGridView.Columns[e.ColumnIndex].HeaderText} には数値のみ入力できます。", "入力値エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ((DataGridView)sender).CancelEdit();
                e.Cancel = true;
            }
            // 収支が変更されていたなら
            if (e.ColumnIndex == NewLogDataGridView.Columns["Balance"].Index && (string)e.FormattedValue != (string)NewLogDataGridView.CurrentCell.Value)
            {
                if ((string)NewLogDataGridView.Rows[e.RowIndex].Cells["Category"].Value != "その他")
                {
                    MessageBox.Show(this, $"収支が、変更されました。\nカテゴリが「その他」に変更されます。", "終始変更", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    NewLogDataGridView.Rows[e.RowIndex].Cells["Category"].Value = ((DataGridViewComboBoxColumn)NewLogDataGridView.Columns["Category"]).Items[((DataGridViewComboBoxColumn)NewLogDataGridView.Columns["Category"]).Items.IndexOf("その他")].ToString();
                }
                // カテゴリの候補を変更
                if ((string)e.FormattedValue == "支出")
                {
                    var expenseCategories = Properties.Settings.Default.ExpenseCategories.Cast<string>().ToArray().Concat(new[] { "その他" }).ToArray();
                    ((DataGridViewComboBoxColumn)NewLogDataGridView.Columns["Category"]).DataSource = expenseCategories;
                }
                else if ((string)e.FormattedValue == "収入")
                {
                    var incomeCategories = Properties.Settings.Default.IncomeCategories.Cast<string>().ToArray().Concat(new[] { "その他" }).ToArray();
                    ((DataGridViewComboBoxColumn)NewLogDataGridView.Columns["Category"]).DataSource = incomeCategories;
                }
            }
            // 支出のとき、新しいカテゴリが支出カテゴリに含まれていないなら却下
            else if (e.ColumnIndex == NewLogDataGridView.Columns["Balance"].Index && (string)e.FormattedValue == "支出")
            {
                var expenseCategories = Properties.Settings.Default.ExpenseCategories.Cast<string>().ToArray().Concat(new[] { "その他" }).ToArray();
                if (expenseCategories.Contains((string)NewLogDataGridView.Rows[e.RowIndex].Cells["Category"].Value) == false)
                {
                    MessageBox.Show(this, $"支出のカテゴリでは、\n\n{string.Join("\n", expenseCategories)}\n\nが選択可能です。", "入力値エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    ((DataGridView)sender).CancelEdit();
                    e.Cancel = true;
                }
            }
            // 収入のとき、新しいカテゴリが収入カテゴリに含まれていないなら却下
            else if (e.ColumnIndex == NewLogDataGridView.Columns["Balance"].Index && (string)e.FormattedValue == "収入")
            {
                var incomeCategories = Properties.Settings.Default.IncomeCategories.Cast<string>().ToArray().Concat(new[] { "その他" }).ToArray();
                if (incomeCategories.Contains((string)NewLogDataGridView.Rows[e.RowIndex].Cells["Category"].Value) == false)
                {
                    MessageBox.Show(this, $"収入のカテゴリでは、\n\n{string.Join("\n", incomeCategories)}\n\nが選択可能です。", "入力値エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    ((DataGridView)sender).CancelEdit();
                    e.Cancel = true;
                }
            }
        }

        /// <summary>
        /// 円グラフの設定
        /// </summary>
        private void BalanceChartUpdate()
        {
            // 支出のグラフ作成
            ExpensesChart.Series[0].Points.Clear();
            // 各カテゴリの合計を算出し、円グラフに追加
            var expenseCategories = Properties.Settings.Default.ExpenseCategories.Cast<string>().ToArray();
            foreach (var category in expenseCategories)
            {
                // 支出の各合計
                var expenseTotals = LogsDataGridView.Rows.Cast<DataGridViewRow>().Where(row => (string)row.Cells["Category1"].Value == category && (string)row.Cells["Balance1"].Value == "支出").Sum(row => (int)row.Cells["Amount1"].Value);
                var point = new DataPoint
                {
                    Label = category,
                    XValue = 0,
                    YValues = new double[] { expenseTotals }
                };
                ExpensesChart.Series[0].Points.Add(point);
            }
            // 金額で降順にする
            ExpensesChart.Series[0].Sort(PointSortOrder.Descending);

            // その他の支出
            var otherExpensesTotal = LogsDataGridView.Rows.Cast<DataGridViewRow>().Where(row => (string)row.Cells["Category1"].Value == "その他" && (string)row.Cells["Balance1"].Value == "支出").Sum(row => (int)row.Cells["Amount1"].Value);
            var otherExpensesPoint = new DataPoint
            {
                Label = "その他",
                XValue = 0,
                YValues = new double[] { otherExpensesTotal }
            };
            ExpensesChart.Series[0].Points.Add(otherExpensesPoint);

            // 収入のグラフ作成
            IncomesChart.Series[0].Points.Clear();
            // 各カテゴリの合計を算出し、円グラフに追加
            var incomeCategories = Properties.Settings.Default.IncomeCategories.Cast<string>().ToArray();
            foreach (var category in incomeCategories)
            {
                // 収入の各合計
                var incomeTotals = LogsDataGridView.Rows.Cast<DataGridViewRow>().Where(row => (string)row.Cells["Category1"].Value == category && (string)row.Cells["Balance1"].Value == "収入").Sum(row => (int)row.Cells["Amount1"].Value);
                var point = new DataPoint
                {
                    Label = category,
                    XValue = 0,
                    YValues = new double[] { incomeTotals }
                };
                IncomesChart.Series[0].Points.Add(point);
            }
            // 金額で降順にする
            IncomesChart.Series[0].Sort(PointSortOrder.Descending);

            // その他の収入を末尾に追加
            var otherIncomesTotal = LogsDataGridView.Rows.Cast<DataGridViewRow>().Where(row => (string)row.Cells["Category1"].Value == "その他" && (string)row.Cells["Balance1"].Value == "収入").Sum(row => (int)row.Cells["Amount1"].Value);
            var otherIncomesPoint = new DataPoint
            {
                Label = "その他",
                XValue = 0,
                YValues = new double[] { otherIncomesTotal }
            };
            IncomesChart.Series[0].Points.Add(otherIncomesPoint);
        }

        /// <summary>
        /// 円グラフの内容を更新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LogsDataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            BalanceChartUpdate();
        }

        /// <summary>
        /// 円グラフの内容を更新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LogsDataGridView_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            BalanceChartUpdate();
        }
    }
}
