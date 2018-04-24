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
            this.LogsDataGridView = new System.Windows.Forms.DataGridView();
            this.SortButton = new System.Windows.Forms.Button();
            this.EditButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.LogsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // LogsDataGridView
            // 
            this.LogsDataGridView.AllowUserToAddRows = false;
            this.LogsDataGridView.AllowUserToDeleteRows = false;
            this.LogsDataGridView.AllowUserToResizeColumns = false;
            this.LogsDataGridView.AllowUserToResizeRows = false;
            this.LogsDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.LogsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.LogsDataGridView.Location = new System.Drawing.Point(12, 12);
            this.LogsDataGridView.MultiSelect = false;
            this.LogsDataGridView.Name = "LogsDataGridView";
            this.LogsDataGridView.ReadOnly = true;
            this.LogsDataGridView.RowHeadersVisible = false;
            this.LogsDataGridView.RowTemplate.Height = 27;
            this.LogsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.LogsDataGridView.Size = new System.Drawing.Size(960, 330);
            this.LogsDataGridView.TabIndex = 0;
            this.LogsDataGridView.Leave += new System.EventHandler(this.LogsDataGridView_Leave);
            // 
            // SortButton
            // 
            this.SortButton.Location = new System.Drawing.Point(978, 12);
            this.SortButton.Name = "SortButton";
            this.SortButton.Size = new System.Drawing.Size(200, 31);
            this.SortButton.TabIndex = 1;
            this.SortButton.Text = "並び替え";
            this.SortButton.UseVisualStyleBackColor = true;
            this.SortButton.Click += new System.EventHandler(this.SortButton_Click);
            // 
            // EditButton
            // 
            this.EditButton.Location = new System.Drawing.Point(978, 49);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(200, 32);
            this.EditButton.TabIndex = 2;
            this.EditButton.Text = "編集";
            this.EditButton.UseVisualStyleBackColor = true;
            this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1478, 944);
            this.Controls.Add(this.EditButton);
            this.Controls.Add(this.SortButton);
            this.Controls.Add(this.LogsDataGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainForm";
            this.Text = "MoneyFarm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.LogsDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView LogsDataGridView;
        private System.Windows.Forms.Button SortButton;
        private System.Windows.Forms.Button EditButton;
    }
}

