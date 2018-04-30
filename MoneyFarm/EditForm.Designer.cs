namespace MoneyFarm
{
    partial class EditForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.NewLogDataGridView = new System.Windows.Forms.DataGridView();
            this.Balance = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Category = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Detail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new MoneyFarm.CalendarColumn();
            this.OKButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.NewLogDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // NewLogDataGridView
            // 
            this.NewLogDataGridView.AllowUserToAddRows = false;
            this.NewLogDataGridView.AllowUserToDeleteRows = false;
            this.NewLogDataGridView.AllowUserToResizeColumns = false;
            this.NewLogDataGridView.AllowUserToResizeRows = false;
            this.NewLogDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.NewLogDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.NewLogDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.NewLogDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.NewLogDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Balance,
            this.Category,
            this.Detail,
            this.Amount,
            this.Date});
            this.NewLogDataGridView.Location = new System.Drawing.Point(11, 11);
            this.NewLogDataGridView.Margin = new System.Windows.Forms.Padding(2);
            this.NewLogDataGridView.Name = "NewLogDataGridView";
            this.NewLogDataGridView.RowHeadersVisible = false;
            this.NewLogDataGridView.RowTemplate.Height = 27;
            this.NewLogDataGridView.Size = new System.Drawing.Size(621, 42);
            this.NewLogDataGridView.TabIndex = 14;
            // 
            // Balance
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Balance.DefaultCellStyle = dataGridViewCellStyle6;
            this.Balance.HeaderText = "収支";
            this.Balance.Items.AddRange(new object[] {
            "支出",
            "収入"});
            this.Balance.Name = "Balance";
            this.Balance.Resizable = System.Windows.Forms.DataGridViewTriState.True;
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
            // Amount
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N0";
            this.Amount.DefaultCellStyle = dataGridViewCellStyle7;
            this.Amount.HeaderText = "金額";
            this.Amount.MaxInputLength = 10;
            this.Amount.Name = "Amount";
            this.Amount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Date
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.Format = "d";
            this.Date.DefaultCellStyle = dataGridViewCellStyle8;
            this.Date.HeaderText = "日付";
            this.Date.Name = "Date";
            this.Date.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(637, 12);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(97, 41);
            this.OKButton.TabIndex = 15;
            this.OKButton.Text = "編集確定";
            this.OKButton.UseVisualStyleBackColor = true;
            // 
            // EditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(748, 65);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.NewLogDataGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "EditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "EditForm";
            this.Load += new System.EventHandler(this.EditForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.NewLogDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView NewLogDataGridView;
        private System.Windows.Forms.DataGridViewComboBoxColumn Balance;
        private System.Windows.Forms.DataGridViewComboBoxColumn Category;
        private System.Windows.Forms.DataGridViewTextBoxColumn Detail;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private CalendarColumn Date;
        private System.Windows.Forms.Button OKButton;
    }
}