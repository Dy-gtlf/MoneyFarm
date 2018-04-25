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
            // TODO: このコード行はデータを 'moneyFarmDataBaseDataSet.Logs' テーブルに読み込みます。必要に応じて移動、または削除をしてください。
            logsTableAdapter.Fill(moneyFarmDataBaseDataSet.Logs);
            CategoriesComboBox.Items.Add("すべてのカテゴリ");
            CategoriesComboBox.Items.AddRange(Properties.Settings.Default.Categories.Cast<string>().ToArray());
            CategoriesComboBox.Items.Add("その他");

            CategoriesComboBox.SelectedIndex = 0;
            BalanceComboBox.SelectedIndex = 0;
            // 今から1ヶ月以内を表示
            DateTimePicker2.Value = DateTime.Now;
            DateTimePicker1.Value = DateTime.Now.AddMonths(-1);
            FilterAndSortDataGridView();
        }
        
        // 非アクティブで選択解除
        private void LogsDataGridView_Leave(object sender, System.EventArgs e)
        {
            LogsDataGridView.ClearSelection();
        }

        
        private void SortButton_Click(object sender, System.EventArgs e)
        {
            FilterAndSortDataGridView();
        }

        // 表示更新
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
        }

        // 編集ボタン
        private void EditButton_Click(object sender, System.EventArgs e)
        {
            if (LogsDataGridView.CurrentRow != null)
            {
                using (var editForm = new EditForm())
                {
                    editForm.ShowDialog(this);
                }
            }
        }
    }
}
