namespace MoneyFarm
{
    partial class MainForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            this.LogsDataGridView = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new MoneyFarm.CalendarColumn();
            this.categoryDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.detailDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.balanceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.amountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateDataGridViewTextBoxColumn = new MoneyFarm.CalendarColumn();
            this.logsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.moneyFarmDataBaseDataSet = new MoneyFarm.MoneyFarmDataBaseDataSet();
            this.DateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.DateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.CategoriesComboBox = new System.Windows.Forms.ComboBox();
            this.FilterButton = new System.Windows.Forms.Button();
            this.BalanceComboBox = new System.Windows.Forms.ComboBox();
            this.logsTableAdapter = new MoneyFarm.MoneyFarmDataBaseDataSetTableAdapters.LogsTableAdapter();
            this.moneyFarmDataBaseDataSet1 = new MoneyFarm.MoneyFarmDataBaseDataSet();
            this.NewLogDataGridView = new System.Windows.Forms.DataGridView();
            this.Category = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Detail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Balance = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new MoneyFarm.CalendarColumn();
            this.AdditionButton = new System.Windows.Forms.Button();
            this.DeletionButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.LogsDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.moneyFarmDataBaseDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.moneyFarmDataBaseDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NewLogDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // LogsDataGridView
            // 
            this.LogsDataGridView.AllowUserToAddRows = false;
            this.LogsDataGridView.AllowUserToDeleteRows = false;
            this.LogsDataGridView.AllowUserToResizeColumns = false;
            this.LogsDataGridView.AllowUserToResizeRows = false;
            this.LogsDataGridView.AutoGenerateColumns = false;
            this.LogsDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.LogsDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.LogsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.LogsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.categoryDataGridViewTextBoxColumn,
            this.detailDataGridViewTextBoxColumn,
            this.balanceDataGridViewTextBoxColumn,
            this.amountDataGridViewTextBoxColumn,
            this.dateDataGridViewTextBoxColumn});
            this.LogsDataGridView.DataSource = this.logsBindingSource;
            this.LogsDataGridView.Location = new System.Drawing.Point(18, 12);
            this.LogsDataGridView.Margin = new System.Windows.Forms.Padding(4);
            this.LogsDataGridView.MultiSelect = false;
            this.LogsDataGridView.Name = "LogsDataGridView";
            this.LogsDataGridView.RowHeadersVisible = false;
            this.LogsDataGridView.RowTemplate.Height = 21;
            this.LogsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.LogsDataGridView.Size = new System.Drawing.Size(932, 344);
            this.LogsDataGridView.TabIndex = 3;
            this.LogsDataGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.LogsDataGridView_CellEndEdit);
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.idDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.idDataGridViewTextBoxColumn.Visible = false;
            // 
            // categoryDataGridViewTextBoxColumn
            // 
            this.categoryDataGridViewTextBoxColumn.DataPropertyName = "Category";
            this.categoryDataGridViewTextBoxColumn.HeaderText = "カデゴリ";
            this.categoryDataGridViewTextBoxColumn.Name = "categoryDataGridViewTextBoxColumn";
            this.categoryDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.categoryDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // detailDataGridViewTextBoxColumn
            // 
            this.detailDataGridViewTextBoxColumn.DataPropertyName = "Detail";
            this.detailDataGridViewTextBoxColumn.HeaderText = "詳細";
            this.detailDataGridViewTextBoxColumn.Name = "detailDataGridViewTextBoxColumn";
            // 
            // balanceDataGridViewTextBoxColumn
            // 
            this.balanceDataGridViewTextBoxColumn.DataPropertyName = "Balance";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.balanceDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle10;
            this.balanceDataGridViewTextBoxColumn.HeaderText = "収支";
            this.balanceDataGridViewTextBoxColumn.Items.AddRange(new object[] {
            "収支",
            "支出",
            "収入"});
            this.balanceDataGridViewTextBoxColumn.Name = "balanceDataGridViewTextBoxColumn";
            this.balanceDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.balanceDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // amountDataGridViewTextBoxColumn
            // 
            this.amountDataGridViewTextBoxColumn.DataPropertyName = "Amount";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle11.Format = "C0";
            dataGridViewCellStyle11.NullValue = "0";
            this.amountDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle11;
            this.amountDataGridViewTextBoxColumn.HeaderText = "金額";
            this.amountDataGridViewTextBoxColumn.Name = "amountDataGridViewTextBoxColumn";
            // 
            // dateDataGridViewTextBoxColumn
            // 
            this.dateDataGridViewTextBoxColumn.DataPropertyName = "Date";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.Format = "d";
            dataGridViewCellStyle12.NullValue = null;
            this.dateDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle12;
            this.dateDataGridViewTextBoxColumn.HeaderText = "日付";
            this.dateDataGridViewTextBoxColumn.Name = "dateDataGridViewTextBoxColumn";
            this.dateDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dateDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // logsBindingSource
            // 
            this.logsBindingSource.DataMember = "Logs";
            this.logsBindingSource.DataSource = this.moneyFarmDataBaseDataSet;
            // 
            // moneyFarmDataBaseDataSet
            // 
            this.moneyFarmDataBaseDataSet.DataSetName = "MoneyFarmDataBaseDataSet";
            this.moneyFarmDataBaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // DateTimePicker1
            // 
            this.DateTimePicker1.Location = new System.Drawing.Point(957, 84);
            this.DateTimePicker1.Name = "DateTimePicker1";
            this.DateTimePicker1.Size = new System.Drawing.Size(200, 25);
            this.DateTimePicker1.TabIndex = 4;
            this.DateTimePicker1.Value = new System.DateTime(2018, 4, 1, 0, 0, 0, 0);
            // 
            // DateTimePicker2
            // 
            this.DateTimePicker2.Location = new System.Drawing.Point(957, 144);
            this.DateTimePicker2.Name = "DateTimePicker2";
            this.DateTimePicker2.Size = new System.Drawing.Size(200, 25);
            this.DateTimePicker2.TabIndex = 5;
            this.DateTimePicker2.Value = new System.DateTime(2018, 4, 30, 0, 0, 0, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1042, 118);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 18);
            this.label1.TabIndex = 6;
            this.label1.Text = "↓";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CategoriesComboBox
            // 
            this.CategoriesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CategoriesComboBox.FormattingEnabled = true;
            this.CategoriesComboBox.Location = new System.Drawing.Point(957, 12);
            this.CategoriesComboBox.Name = "CategoriesComboBox";
            this.CategoriesComboBox.Size = new System.Drawing.Size(200, 26);
            this.CategoriesComboBox.TabIndex = 11;
            // 
            // FilterButton
            // 
            this.FilterButton.Location = new System.Drawing.Point(956, 175);
            this.FilterButton.Name = "FilterButton";
            this.FilterButton.Size = new System.Drawing.Size(201, 32);
            this.FilterButton.TabIndex = 1;
            this.FilterButton.Text = "表示更新";
            this.FilterButton.UseVisualStyleBackColor = true;
            this.FilterButton.Click += new System.EventHandler(this.FilterButton_Click);
            // 
            // BalanceComboBox
            // 
            this.BalanceComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.BalanceComboBox.FormattingEnabled = true;
            this.BalanceComboBox.Items.AddRange(new object[] {
            "収支",
            "支出",
            "収入"});
            this.BalanceComboBox.Location = new System.Drawing.Point(957, 48);
            this.BalanceComboBox.Name = "BalanceComboBox";
            this.BalanceComboBox.Size = new System.Drawing.Size(200, 26);
            this.BalanceComboBox.TabIndex = 12;
            // 
            // logsTableAdapter
            // 
            this.logsTableAdapter.ClearBeforeFill = true;
            // 
            // moneyFarmDataBaseDataSet1
            // 
            this.moneyFarmDataBaseDataSet1.DataSetName = "MoneyFarmDataBaseDataSet";
            this.moneyFarmDataBaseDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // NewLogDataGridView
            // 
            this.NewLogDataGridView.AllowUserToAddRows = false;
            this.NewLogDataGridView.AllowUserToDeleteRows = false;
            this.NewLogDataGridView.AllowUserToResizeColumns = false;
            this.NewLogDataGridView.AllowUserToResizeRows = false;
            this.NewLogDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.NewLogDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.NewLogDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.NewLogDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.NewLogDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Category,
            this.Detail,
            this.Balance,
            this.Amount,
            this.Date});
            this.NewLogDataGridView.Location = new System.Drawing.Point(18, 363);
            this.NewLogDataGridView.Name = "NewLogDataGridView";
            this.NewLogDataGridView.RowHeadersVisible = false;
            this.NewLogDataGridView.RowTemplate.Height = 27;
            this.NewLogDataGridView.Size = new System.Drawing.Size(932, 63);
            this.NewLogDataGridView.TabIndex = 13;
            // 
            // Category
            // 
            this.Category.HeaderText = "カテゴリ";
            this.Category.Name = "Category";
            this.Category.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Detail
            // 
            this.Detail.HeaderText = "詳細";
            this.Detail.MaxInputLength = 20;
            this.Detail.Name = "Detail";
            this.Detail.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Balance
            // 
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Balance.DefaultCellStyle = dataGridViewCellStyle14;
            this.Balance.HeaderText = "収支";
            this.Balance.Items.AddRange(new object[] {
            "支出",
            "収入"});
            this.Balance.Name = "Balance";
            this.Balance.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Amount
            // 
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle15.Format = "C0";
            this.Amount.DefaultCellStyle = dataGridViewCellStyle15;
            this.Amount.HeaderText = "金額";
            this.Amount.Name = "Amount";
            this.Amount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Date
            // 
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle16.Format = "d";
            this.Date.DefaultCellStyle = dataGridViewCellStyle16;
            this.Date.HeaderText = "日付";
            this.Date.Name = "Date";
            this.Date.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // AdditionButton
            // 
            this.AdditionButton.Location = new System.Drawing.Point(956, 363);
            this.AdditionButton.Name = "AdditionButton";
            this.AdditionButton.Size = new System.Drawing.Size(100, 63);
            this.AdditionButton.TabIndex = 14;
            this.AdditionButton.Text = "新規追加";
            this.AdditionButton.UseVisualStyleBackColor = true;
            this.AdditionButton.Click += new System.EventHandler(this.AdditionButton_Click);
            // 
            // DeletionButton
            // 
            this.DeletionButton.Location = new System.Drawing.Point(1057, 363);
            this.DeletionButton.Name = "DeletionButton";
            this.DeletionButton.Size = new System.Drawing.Size(100, 63);
            this.DeletionButton.TabIndex = 15;
            this.DeletionButton.Text = "削除";
            this.DeletionButton.UseVisualStyleBackColor = true;
            this.DeletionButton.Click += new System.EventHandler(this.DeletionButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1176, 692);
            this.Controls.Add(this.DeletionButton);
            this.Controls.Add(this.AdditionButton);
            this.Controls.Add(this.NewLogDataGridView);
            this.Controls.Add(this.BalanceComboBox);
            this.Controls.Add(this.CategoriesComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DateTimePicker2);
            this.Controls.Add(this.DateTimePicker1);
            this.Controls.Add(this.LogsDataGridView);
            this.Controls.Add(this.FilterButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainForm";
            this.Text = "MoneyFarm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.LogsDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.moneyFarmDataBaseDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.moneyFarmDataBaseDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NewLogDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MoneyFarmDataBaseDataSet moneyFarmDataBaseDataSet;
        private System.Windows.Forms.BindingSource logsBindingSource;
        private MoneyFarmDataBaseDataSetTableAdapters.LogsTableAdapter logsTableAdapter;
        private System.Windows.Forms.DataGridView LogsDataGridView;
        private System.Windows.Forms.DateTimePicker DateTimePicker1;
        private System.Windows.Forms.DateTimePicker DateTimePicker2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CategoriesComboBox;
        private System.Windows.Forms.Button FilterButton;
        private System.Windows.Forms.ComboBox BalanceComboBox;
        private MoneyFarmDataBaseDataSet moneyFarmDataBaseDataSet1;
        private System.Windows.Forms.DataGridView NewLogDataGridView;
        private System.Windows.Forms.Button AdditionButton;
        private CalendarColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn categoryDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn detailDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn balanceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn amountDataGridViewTextBoxColumn;
        private CalendarColumn dateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn Category;
        private System.Windows.Forms.DataGridViewTextBoxColumn Detail;
        private System.Windows.Forms.DataGridViewComboBoxColumn Balance;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private CalendarColumn Date;
        private System.Windows.Forms.Button DeletionButton;
    }
}

