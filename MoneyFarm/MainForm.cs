using MoneyFarm.Model;
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
        // データ取得
        private string connectionString = $@"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename={Directory.GetCurrentDirectory()
    }\DB\MoneyFarmDataBase.mdf;Integrated Security = True; Connect Timeout = 30";
        
        private SqlConnection connection;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, System.EventArgs e)
        {
            // TODO: このコード行はデータを 'moneyFarmDataBaseDataSet.Logs' テーブルに読み込みます。必要に応じて移動、または削除をしてください。
            this.logsTableAdapter.Fill(this.moneyFarmDataBaseDataSet.Logs);
            connection = new SqlConnection(connectionString);
            connection.Open();
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
                using (var editForm = new EditForm())
                {
                    editForm.ShowDialog(this);
                }
            }
        }

    }
}
