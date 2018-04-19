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
            this.LogDataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.LogDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // LogDataGridView
            // 
            this.LogDataGridView.AllowUserToAddRows = false;
            this.LogDataGridView.AllowUserToDeleteRows = false;
            this.LogDataGridView.AllowUserToResizeColumns = false;
            this.LogDataGridView.AllowUserToResizeRows = false;
            this.LogDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.LogDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.LogDataGridView.Location = new System.Drawing.Point(12, 12);
            this.LogDataGridView.Name = "LogDataGridView";
            this.LogDataGridView.ReadOnly = true;
            this.LogDataGridView.RowHeadersVisible = false;
            this.LogDataGridView.RowTemplate.Height = 27;
            this.LogDataGridView.Size = new System.Drawing.Size(960, 330);
            this.LogDataGridView.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1478, 944);
            this.Controls.Add(this.LogDataGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainForm";
            this.Text = "MoneyFarm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.LogDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView LogDataGridView;
    }
}

