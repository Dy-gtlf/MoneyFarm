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
            // LogsDataGridViewの設定
            // データをバインドしているとき、["カラム名"]指定だとnullになるのでカラムのインデックスで指定
            ((DataGridViewComboBoxColumn)LogsDataGridView.Columns[1]).Items.AddRange(Properties.Settings.Default.Categories.Cast<string>().ToArray());
            ((DataGridViewComboBoxColumn)LogsDataGridView.Columns[1]).DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
            ((DataGridViewComboBoxColumn)LogsDataGridView.Columns[3]).DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
            // NewLogDataGridViewの設定
            ((DataGridViewComboBoxColumn)NewLogDataGridView.Columns["Category"]).Items.AddRange(Properties.Settings.Default.Categories.Cast<string>().ToArray());
            ((DataGridViewComboBoxColumn)NewLogDataGridView.Columns["Category"]).DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
            ((DataGridViewComboBoxColumn)NewLogDataGridView.Columns["Balance"]).DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
            // データベースの内容を同期
            logsTableAdapter.Fill(moneyFarmDataBaseDataSet.Logs);
            // フィルターのComboBoxの内容を設定
            CategoriesComboBox.Items.Add("すべてのカテゴリ");
            CategoriesComboBox.Items.AddRange(Properties.Settings.Default.Categories.Cast<string>().ToArray());
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
            if (string.IsNullOrWhiteSpace(NewLogDataGridView.Rows[0].Cells["Detail"].Value.ToString()))
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
        /// 新規データの入力チェック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void LogsDataGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            // 金額がintに変換できないなら
            if (e.ColumnIndex == 4 && int.TryParse(e.FormattedValue.ToString(), out int result) == false)
            {
                MessageBox.Show(this, string.Format($"{LogsDataGridView.Columns[e.ColumnIndex].HeaderText} には数値のみ入力できます。"), "入力値エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ((DataGridView)sender).CancelEdit();
                e.Cancel = true;      
            }
        }

        private void NewLogDataGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            // 金額がintに変換できないなら
            if (e.ColumnIndex == 3 && int.TryParse(e.FormattedValue.ToString(), out int result) == false)
            {
                MessageBox.Show(this, string.Format($"{NewLogDataGridView.Columns[e.ColumnIndex].HeaderText} には数値のみ入力できます。"), "入力値エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ((DataGridView)sender).CancelEdit();
                e.Cancel = true;
            }
        }
    }
}
