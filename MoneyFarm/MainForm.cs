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

        private void MainForm_Load(object sender, System.EventArgs e)
        {
            // DataGridViewのComboBoxの内容を設定
            ((DataGridViewComboBoxColumn)logsDataGridView.Columns[1]).Items.AddRange(Properties.Settings.Default.Categories.Cast<string>().ToArray());
            ((DataGridViewComboBoxColumn)logsDataGridView.Columns[1]).DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
            ((DataGridViewComboBoxColumn)logsDataGridView.Columns[3]).Items.AddRange(new string[] { "支出", "収入" });
            ((DataGridViewComboBoxColumn)logsDataGridView.Columns[3]).DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
            // データベースの内容を同期
            logsTableAdapter.Fill(moneyFarmDataBaseDataSet.Logs);
            categoriesComboBox.Items.Add("すべてのカテゴリ");
            categoriesComboBox.Items.AddRange(Properties.Settings.Default.Categories.Cast<string>().ToArray());
            categoriesComboBox.SelectedIndex = 0;
            balanceComboBox.SelectedIndex = 0;
            // 今から1ヶ月以内を表示
            dateTimePicker2.Value = DateTime.Now;
            dateTimePicker1.Value = DateTime.Now.AddMonths(-1);
            FilterAndSortDataGridView();
        }
        
        // 非アクティブで選択解除
        private void LogsDataGridView_Leave(object sender, System.EventArgs e)
        {
            logsDataGridView.ClearSelection();
        }

        // フィルター
        private void FilterButton_Click(object sender, System.EventArgs e)
        {
            FilterAndSortDataGridView();
        }

        // 表示更新
        private void FilterAndSortDataGridView()
        {
            // フィルター用の文字列
            string filter = "";
            if (categoriesComboBox.SelectedIndex != 0)
            {
                filter += string.Format($"Category LIKE '{categoriesComboBox.Text}' AND ");
            }
            if (balanceComboBox.SelectedIndex != 0)
            {
                filter += string.Format($"Balance LIKE '{balanceComboBox.Text}' AND ");
            }
            filter += string.Format($"Date >= '{dateTimePicker1.Value.ToShortDateString()}' AND ");
            filter += string.Format($"Date <= '{dateTimePicker2.Value.ToShortDateString()}'");
            // フィルターにセット
            logsBindingSource.Filter = filter;
            logsBindingSource.Sort = "Date";
            logsDataGridView.ClearSelection();
        }

        // 編集ボタン
        private void EditButton_Click(object sender, System.EventArgs e)
        {
            if (logsDataGridView.CurrentRow != null)
            {
                using (var editForm = new EditForm())
                {
                    editForm.ShowDialog();
                }
            }
        }

    }
}
