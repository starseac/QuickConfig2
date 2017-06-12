namespace QuickConfig.Controls.WebSiteSet
{
    partial class ftpSiteInstall
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
            this.label = new System.Windows.Forms.Label();
            this.btn_createftp = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(14, 9);
            this.label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(41, 12);
            this.label.TabIndex = 10;
            this.label.Text = "BDCFTP";
            // 
            // btn_createftp
            // 
            this.btn_createftp.BackColor = System.Drawing.Color.AliceBlue;
            this.btn_createftp.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_createftp.Location = new System.Drawing.Point(237, 4);
            this.btn_createftp.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_createftp.Name = "btn_createftp";
            this.btn_createftp.Size = new System.Drawing.Size(70, 21);
            this.btn_createftp.TabIndex = 12;
            this.btn_createftp.Text = "创建ftp";
            this.btn_createftp.UseVisualStyleBackColor = false;
            this.btn_createftp.Click += new System.EventHandler(this.btn_createftp_Click);
            // 
            // ftpSiteInstall
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.label);
            this.Controls.Add(this.btn_createftp);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ftpSiteInstall";
            this.Size = new System.Drawing.Size(570, 29);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Button btn_createftp;
    }
}
