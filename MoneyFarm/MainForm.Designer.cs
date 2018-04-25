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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.EditButton = new System.Windows.Forms.Button();
            this.LogsDataGridView = new System.Windows.Forms.DataGridView();
            this.logsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.moneyFarmDataBaseDataSet = new MoneyFarm.MoneyFarmDataBaseDataSet();
            this.logsTableAdapter = new MoneyFarm.MoneyFarmDataBaseDataSetTableAdapters.LogsTableAdapter();
            this.DateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.DateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.ExpenseRadioButton = new System.Windows.Forms.RadioButton();
            this.IncomeRadioButton = new System.Windows.Forms.RadioButton();
            this.BalanceRadioButton1 = new System.Windows.Forms.RadioButton();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.categoryDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.detailDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.balanceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CategoriesComboBox = new System.Windows.Forms.ComboBox();
            this.SortButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.LogsDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.moneyFarmDataBaseDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // EditButton
            // 
            this.EditButton.Location = new System.Drawing.Point(977, 362);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(200, 32);
            this.EditButton.TabIndex = 2;
            this.EditButton.Text = "編集";
            this.EditButton.UseVisualStyleBackColor = true;
            this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // LogsDataGridView
            // 
            this.LogsDataGridView.AllowUserToAddRows = false;
            this.LogsDataGridView.AllowUserToDeleteRows = false;
            this.LogsDataGridView.AllowUserToResizeColumns = false;
            this.LogsDataGridView.AllowUserToResizeRows = false;
            this.LogsDataGridView.AutoGenerateColumns = false;
            this.LogsDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.LogsDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
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
            this.LogsDataGridView.Size = new System.Drawing.Size(952, 344);
            this.LogsDataGridView.TabIndex = 3;
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
            // logsTableAdapter
            // 
            this.logsTableAdapter.ClearBeforeFill = true;
            // 
            // DateTimePicker1
            // 
            this.DateTimePicker1.Location = new System.Drawing.Point(977, 128);
            this.DateTimePicker1.Name = "DateTimePicker1";
            this.DateTimePicker1.Size = new System.Drawing.Size(200, 25);
            this.DateTimePicker1.TabIndex = 4;
            this.DateTimePicker1.Value = new System.DateTime(2018, 4, 1, 0, 0, 0, 0);
            // 
            // DateTimePicker2
            // 
            this.DateTimePicker2.Location = new System.Drawing.Point(977, 188);
            this.DateTimePicker2.Name = "DateTimePicker2";
            this.DateTimePicker2.Size = new System.Drawing.Size(200, 25);
            this.DateTimePicker2.TabIndex = 5;
            this.DateTimePicker2.Value = new System.DateTime(2018, 4, 30, 0, 0, 0, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1062, 162);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 18);
            this.label1.TabIndex = 6;
            this.label1.Text = "↓";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ExpenseRadioButton
            // 
            this.ExpenseRadioButton.AutoSize = true;
            this.ExpenseRadioButton.Location = new System.Drawing.Point(977, 72);
            this.ExpenseRadioButton.Name = "ExpenseRadioButton";
            this.ExpenseRadioButton.Size = new System.Drawing.Size(69, 22);
            this.ExpenseRadioButton.TabIndex = 7;
            this.ExpenseRadioButton.Text = "支出";
            this.ExpenseRadioButton.UseVisualStyleBackColor = true;
            // 
            // IncomeRadioButton
            // 
            this.IncomeRadioButton.AutoSize = true;
            this.IncomeRadioButton.Location = new System.Drawing.Point(977, 100);
            this.IncomeRadioButton.Name = "IncomeRadioButton";
            this.IncomeRadioButton.Size = new System.Drawing.Size(69, 22);
            this.IncomeRadioButton.TabIndex = 8;
            this.IncomeRadioButton.Text = "収入";
            this.IncomeRadioButton.UseVisualStyleBackColor = true;
            // 
            // BalanceRadioButton1
            // 
            this.BalanceRadioButton1.AutoSize = true;
            this.BalanceRadioButton1.Checked = true;
            this.BalanceRadioButton1.Location = new System.Drawing.Point(977, 44);
            this.BalanceRadioButton1.Name = "BalanceRadioButton1";
            this.BalanceRadioButton1.Size = new System.Drawing.Size(69, 22);
            this.BalanceRadioButton1.TabIndex = 10;
            this.BalanceRadioButton1.TabStop = true;
            this.BalanceRadioButton1.Text = "収支";
            this.BalanceRadioButton1.UseVisualStyleBackColor = true;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDataGridViewTextBoxColumn.Visible = false;
            // 
            // categoryDataGridViewTextBoxColumn
            // 
            this.categoryDataGridViewTextBoxColumn.DataPropertyName = "Category";
            this.categoryDataGridViewTextBoxColumn.HeaderText = "カデゴリ";
            this.categoryDataGridViewTextBoxColumn.Name = "categoryDataGridViewTextBoxColumn";
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
            this.balanceDataGridViewTextBoxColumn.HeaderText = "収支";
            this.balanceDataGridViewTextBoxColumn.Name = "balanceDataGridViewTextBoxColumn";
            // 
            // amountDataGridViewTextBoxColumn
            // 
            this.amountDataGridViewTextBoxColumn.DataPropertyName = "Amount";
            this.amountDataGridViewTextBoxColumn.HeaderText = "金額";
            this.amountDataGridViewTextBoxColumn.Name = "amountDataGridViewTextBoxColumn";
            // 
            // dateDataGridViewTextBoxColumn
            // 
            this.dateDataGridViewTextBoxColumn.DataPropertyName = "Date";
            this.dateDataGridViewTextBoxColumn.HeaderText = "日付";
            this.dateDataGridViewTextBoxColumn.Name = "dateDataGridViewTextBoxColumn";
            // 
            // CategoriesComboBox
            // 
            this.CategoriesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CategoriesComboBox.FormattingEnabled = true;
            this.CategoriesComboBox.Location = new System.Drawing.Point(977, 12);
            this.CategoriesComboBox.Name = "CategoriesComboBox";
            this.CategoriesComboBox.Size = new System.Drawing.Size(200, 26);
            this.CategoriesComboBox.TabIndex = 11;
            // 
            // SortButton
            // 
            this.SortButton.Location = new System.Drawing.Point(977, 219);
            this.SortButton.Name = "SortButton";
            this.SortButton.Size = new System.Drawing.Size(200, 32);
            this.SortButton.TabIndex = 1;
            this.SortButton.Text = "表示更新";
            this.SortButton.UseVisualStyleBackColor = true;
            this.SortButton.Click += new System.EventHandler(this.SortButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1251, 692);
            this.Controls.Add(this.CategoriesComboBox);
            this.Controls.Add(this.BalanceRadioButton1);
            this.Controls.Add(this.IncomeRadioButton);
            this.Controls.Add(this.ExpenseRadioButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DateTimePicker2);
            this.Controls.Add(this.DateTimePicker1);
            this.Controls.Add(this.LogsDataGridView);
            this.Controls.Add(this.EditButton);
            this.Controls.Add(this.SortButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainForm";
            this.Text = "MoneyFarm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.LogsDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.moneyFarmDataBaseDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button EditButton;
        private MoneyFarmDataBaseDataSet moneyFarmDataBaseDataSet;
        private System.Windows.Forms.BindingSource logsBindingSource;
        private MoneyFarmDataBaseDataSetTableAdapters.LogsTableAdapter logsTableAdapter;
        private System.Windows.Forms.DataGridView LogsDataGridView;
        private System.Windows.Forms.DateTimePicker DateTimePicker1;
        private System.Windows.Forms.DateTimePicker DateTimePicker2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton ExpenseRadioButton;
        private System.Windows.Forms.RadioButton IncomeRadioButton;
        private System.Windows.Forms.RadioButton BalanceRadioButton1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn categoryDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn detailDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn balanceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn amountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateDataGridViewTextBoxColumn;
        private System.Windows.Forms.ComboBox CategoriesComboBox;
        private System.Windows.Forms.Button SortButton;
    }
}

