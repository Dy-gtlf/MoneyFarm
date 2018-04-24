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
            this.CategorylistBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // CategorylistBox
            // 
            this.CategorylistBox.FormattingEnabled = true;
            this.CategorylistBox.ItemHeight = 18;
            this.CategorylistBox.Location = new System.Drawing.Point(12, 12);
            this.CategorylistBox.Name = "CategorylistBox";
            this.CategorylistBox.Size = new System.Drawing.Size(165, 40);
            this.CategorylistBox.TabIndex = 0;
            // 
            // EditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(423, 343);
            this.Controls.Add(this.CategorylistBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "EditForm";
            this.Text = "EditForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox CategorylistBox;
    }
}