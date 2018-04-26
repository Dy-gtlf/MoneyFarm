using System;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Windows.Forms;

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
            // DataGridViewのComboBoxの内容を設定
            ((DataGridViewComboBoxColumn)LogsDataGridView.Columns[1]).Items.AddRange(Properties.Settings.Default.Categories.Cast<string>().ToArray());
            ((DataGridViewComboBoxColumn)LogsDataGridView.Columns[1]).DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
            ((DataGridViewComboBoxColumn)LogsDataGridView.Columns[3]).DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
            ((DataGridViewComboBoxColumn)NewLogDataGridView.Columns[0]).Items.AddRange(Properties.Settings.Default.Categories.Cast<string>().ToArray());
            ((DataGridViewComboBoxColumn)NewLogDataGridView.Columns[0]).DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
            ((DataGridViewComboBoxColumn)NewLogDataGridView.Columns[2]).DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
            // データベースの内容を同期
            logsTableAdapter.Fill(moneyFarmDataBaseDataSet.Logs);
            // ComboBoxの内容を設定
            CategoriesComboBox.Items.Add("すべてのカテゴリ");
            CategoriesComboBox.Items.AddRange(Properties.Settings.Default.Categories.Cast<string>().ToArray());
            // 未選択状態の空白を表示しない
            CategoriesComboBox.SelectedIndex = 0;
            BalanceComboBox.SelectedIndex = 0;
            // 今日から1ヶ月以内を表示
            DateTimePicker2.Value = DateTime.Now;
            DateTimePicker1.Value = DateTime.Now.AddMonths(-1);
            FilterAndSortDataGridView();

            // 新規データの初期値を設定
            NewLogDataGridView.Rows.Add();
            NewLogDataGridView.Rows[0].Cells["Category"].Value = ((DataGridViewComboBoxColumn)NewLogDataGridView.Columns[0]).Items[0].ToString();
            NewLogDataGridView.Rows[0].Cells["Balance"].Value = ((DataGridViewComboBoxColumn)NewLogDataGridView.Columns[2]).Items[0].ToString();
            NewLogDataGridView.Rows[0].Cells["Amount"].Value = 0;
            NewLogDataGridView.Rows[0].Cells["Date"].Value = DateTime.Now.ToShortDateString();
        }

        /// <summary>
        /// 非アクティブで選択解除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LogsDataGridView_Leave(object sender, System.EventArgs e)
        {
            LogsDataGridView.ClearSelection();
        }

        /// <summary>
        /// 表示更新のボタンをクリックしたときのイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FilterButton_Click(object sender, System.EventArgs e)
        {
            FilterAndSortDataGridView();
        }

        /// <summary>
        /// DataGridViewの表示を更新
        /// </summary>
        private void FilterAndSortDataGridView()
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
        }

        private void AdditionButton_Click(object sender, EventArgs e)
        {
            var table = moneyFarmDataBaseDataSet.Tables["Logs"];
            var newRow = table.NewRow();
            newRow["Category"] = NewLogDataGridView.Rows[0].Cells[0].Value.ToString();
            if (NewLogDataGridView.Rows[0].Cells[1].Value != null)
            {
                newRow["Detail"] = NewLogDataGridView.Rows[0].Cells[1].Value.ToString();
            }
            newRow["Balance"] = NewLogDataGridView.Rows[0].Cells[2].Value.ToString();
            newRow["Amount"] = NewLogDataGridView.Rows[0].Cells[3].Value.ToString();
            newRow["Date"] = DateTime.Now.ToShortTimeString();
            table.Rows.Add(newRow);
            logsTableAdapter.Update(moneyFarmDataBaseDataSet);
        }

        private void DeletionButton_Click(object sender, EventArgs e)
        {
            var table = moneyFarmDataBaseDataSet.Tables["Logs"];
            var result = MessageBox.Show("選択しているデータを削除しますか?","確認",MessageBoxButtons.YesNo,MessageBoxIcon.Exclamation,MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)
            {
                var row = table.Rows[LogsDataGridView.SelectedRows[0].Index];
                row.Delete();
                logsTableAdapter.Update(moneyFarmDataBaseDataSet);
            }
        }
    }
}
