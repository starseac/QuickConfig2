namespace QuickConfig.Controls.WebSiteSet
{
    partial class gxmlInstall
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
            this.btn_creategxml = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(13, 9);
            this.label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(53, 12);
            this.label.TabIndex = 11;
            this.label.Text = "共享目录";
            // 
            // btn_creategxml
            // 
            this.btn_creategxml.BackColor = System.Drawing.Color.AliceBlue;
            this.btn_creategxml.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_creategxml.Location = new System.Drawing.Point(236, 5);
            this.btn_creategxml.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_creategxml.Name = "btn_creategxml";
            this.btn_creategxml.Size = new System.Drawing.Size(70, 21);
            this.btn_creategxml.TabIndex = 13;
            this.btn_creategxml.Text = "创建共享";
            this.btn_creategxml.UseVisualStyleBackColor = false;
            this.btn_creategxml.Click += new System.EventHandler(this.btn_creategxml_Click);
            // 
            // gxmlInstall
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.label);
            this.Controls.Add(this.btn_creategxml);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "gxmlInstall";
            this.Size = new System.Drawing.Size(570, 29);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Button btn_creategxml;
    }
}
