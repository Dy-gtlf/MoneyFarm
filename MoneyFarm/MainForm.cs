using MoneyFarm.Model;
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

        public MainForm()
        {
            InitializeComponent();
        }

        private void AddData()
        {
            using (var connection = new SQLiteConnection(connectionString.ToString()))
            {
                connection.Open();
                using (var db = new DataContext(connection))
                {
                    // データ追加
                    var data = new Log { Content = "test", Category = "", Memo = "", Date = "" };
                    var table = db.GetTable<Log>();
                    table.InsertOnSubmit(data);
                    db.SubmitChanges();
                }
            }
        }

        private void DeleteData()
        {
            using (var connection = new SQLiteConnection(connectionString.ToString()))
            {
                connection.Open();
                using (var db = new DataContext(connection))
                {
                    // データ削除
                    var table = db.GetTable<Log>();
                    var data = table.ToList().Last();
                    table.DeleteOnSubmit(data);
                    db.SubmitChanges();
                }
            }
        }

        private void UpdateData()
        {
            using (var connection = new SQLiteConnection(connectionString.ToString()))
            {
                connection.Open();
                using (var db = new DataContext(connection))
                {
                    // データ更新
                    var table = db.GetTable<Log>();
                    //var data = table.ToList().Last();
                    //data.Content = "aaaaaa";
                    db.SubmitChanges();
                }
            }
        }

        private void MainForm_Load(object sender, System.EventArgs e)
        {
            using (var connection = new SQLiteConnection(connectionString.ToString()))
            {
                connection.Open();
                using (var db = new DataContext(connection))
                {
                    // データグリッドに同期
                    BindingSource bindingSource = new BindingSource();
                    var table = db.GetTable<Log>();
                    bindingSource.DataSource = table;
                    LogDataGridView.DataSource = bindingSource;
                    LogDataGridView.Columns[0].Visible = false;
                }
            }
        }
    }
}
