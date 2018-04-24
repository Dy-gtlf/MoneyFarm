using MoneyFarm.Model;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace MoneyFarm
{
    public partial class MainForm : Form
    {
        // データ取得
        private SQLiteConnectionStringBuilder connectionString = new SQLiteConnectionStringBuilder
        {
            DataSource = $@"{Directory.GetCurrentDirectory()}\DB\Data.sqlite3"
        };

        private SQLiteConnection connection;
        private DataContext db;
        private IOrderedQueryable<Category> categories;
        private IOrderedQueryable<Log> table;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, System.EventArgs e)
        {
            if (File.Exists(connectionString.DataSource) == false)
            {
                MessageBox.Show($"{connectionString.DataSource}が存在しません。\nプログラムを終了します。");
                Close();
            }
            connection = new SQLiteConnection(connectionString.ToString());
            connection.Open();
            db = new DataContext(connection);
            var bindingSource = new BindingSource();
            // 日付が近い順で
            table = db.GetTable<Log>().OrderByDescending(x => x.Date);
            // DataGridViewにデータベースを同期
            bindingSource.DataSource = table;
            LogsDataGridView.DataSource = bindingSource;
            // 配置を整理
            DataGridViewInit();
        }

        // ヘッダーの編集、文字配置の変更
        private void DataGridViewInit()
        {
            // Idを非表示
            LogsDataGridView.Columns[0].Visible = false;
            foreach (DataGridViewColumn column in LogsDataGridView.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            // 各セルの編集
            LogsDataGridView.Columns[1].HeaderText = "カテゴリ";

            LogsDataGridView.Columns[2].HeaderText = "詳細";

            LogsDataGridView.Columns[3].HeaderText = "収支";
            LogsDataGridView.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            LogsDataGridView.Columns[4].HeaderText = "金額";
            LogsDataGridView.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            LogsDataGridView.Columns[5].HeaderText = "日付";
            LogsDataGridView.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
        
        // 非アクティブで選択解除
        private void LogsDataGridView_Leave(object sender, System.EventArgs e)
        {
            LogsDataGridView.ClearSelection();
        }

        // 並び替え
        private void SortButton_Click(object sender, System.EventArgs e)
        {
            using (var sortForm = new SortForm())
            {
                sortForm.ShowDialog(this);
            }
        }

        // 編集ボタン
        private void EditButton_Click(object sender, System.EventArgs e)
        {
            if (LogsDataGridView.CurrentRow != null)
            {
                using (var editForm = new EditForm(categories, LogsDataGridView.CurrentRow))
                {
                    editForm.ShowDialog(this);
                }
                db.SubmitChanges();
            }
        }
    }
}
