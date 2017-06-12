namespace QuickConfig.Controls.DbInit
{
    partial class dmpChoose
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.dmp_label = new System.Windows.Forms.CheckBox();
            this.dmp_filePath = new System.Windows.Forms.TextBox();
            this.btnChoose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dmp_label
            // 
            this.dmp_label.AutoSize = true;
            this.dmp_label.Location = new System.Drawing.Point(5, 5);
            this.dmp_label.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dmp_label.Name = "dmp_label";
            this.dmp_label.Size = new System.Drawing.Size(72, 16);
            this.dmp_label.TabIndex = 41;
            this.dmp_label.Text = "基础平台";
            this.dmp_label.UseVisualStyleBackColor = true;
            // 
            // dmp_filePath
            // 
            this.dmp_filePath.Location = new System.Drawing.Point(82, 2);
            this.dmp_filePath.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dmp_filePath.Name = "dmp_filePath";
            this.dmp_filePath.Size = new System.Drawing.Size(410, 21);
            this.dmp_filePath.TabIndex = 40;
            // 
            // btnChoose
            // 
            this.btnChoose.BackColor = System.Drawing.Color.AliceBlue;
            this.btnChoose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnChoose.Location = new System.Drawing.Point(505, 2);
            this.btnChoose.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnChoose.Name = "btnChoose";
            this.btnChoose.Size = new System.Drawing.Size(56, 21);
            this.btnChoose.TabIndex = 39;
            this.btnChoose.Text = "选择";
            this.btnChoose.UseVisualStyleBackColor = false;
            this.btnChoose.Click += new System.EventHandler(this.btnChoose_Click);
            // 
            // dmpChoose
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.dmp_label);
            this.Controls.Add(this.dmp_filePath);
            this.Controls.Add(this.btnChoose);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "dmpChoose";
            this.Size = new System.Drawing.Size(570, 24);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox dmp_label;
        private System.Windows.Forms.TextBox dmp_filePath;
        private System.Windows.Forms.Button btnChoose;
    }
}
