namespace QuickConfig.Controls.NetWorkSet
{
    partial class webSiteSet
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
            this.label20 = new System.Windows.Forms.Label();
            this.web_label = new System.Windows.Forms.Label();
            this.web_ip = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.web_port = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.web_folderPath = new System.Windows.Forms.TextBox();
            this.btnChoose = new System.Windows.Forms.Button();
            this.web_32bit = new System.Windows.Forms.CheckBox();
            this.web_siteName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(80, 32);
            this.label20.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(53, 12);
            this.label20.TabIndex = 2;
            this.label20.Text = "站点名称";
            // 
            // web_label
            // 
            this.web_label.Location = new System.Drawing.Point(2, 8);
            this.web_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.web_label.Name = "web_label";
            this.web_label.Size = new System.Drawing.Size(73, 34);
            this.web_label.TabIndex = 4;
            this.web_label.Text = "网站名称";
            // 
            // web_ip
            // 
            this.web_ip.Location = new System.Drawing.Point(134, 54);
            this.web_ip.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.web_ip.Name = "web_ip";
            this.web_ip.Size = new System.Drawing.Size(188, 21);
            this.web_ip.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(80, 56);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "ip";
            // 
            // web_port
            // 
            this.web_port.Location = new System.Drawing.Point(412, 27);
            this.web_port.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.web_port.Name = "web_port";
            this.web_port.Size = new System.Drawing.Size(72, 21);
            this.web_port.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(348, 30);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "端口号";
            // 
            // web_folderPath
            // 
            this.web_folderPath.Location = new System.Drawing.Point(82, 4);
            this.web_folderPath.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.web_folderPath.Name = "web_folderPath";
            this.web_folderPath.Size = new System.Drawing.Size(403, 21);
            this.web_folderPath.TabIndex = 12;
            // 
            // btnChoose
            // 
            this.btnChoose.BackColor = System.Drawing.Color.AliceBlue;
            this.btnChoose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnChoose.Location = new System.Drawing.Point(502, 6);
            this.btnChoose.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnChoose.Name = "btnChoose";
            this.btnChoose.Size = new System.Drawing.Size(56, 21);
            this.btnChoose.TabIndex = 11;
            this.btnChoose.Text = "选择";
            this.btnChoose.UseVisualStyleBackColor = false;
            this.btnChoose.Click += new System.EventHandler(this.btnChoose_Click);
            // 
            // web_32bit
            // 
            this.web_32bit.AutoSize = true;
            this.web_32bit.Location = new System.Drawing.Point(352, 56);
            this.web_32bit.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.web_32bit.Name = "web_32bit";
            this.web_32bit.Size = new System.Drawing.Size(54, 16);
            this.web_32bit.TabIndex = 14;
            this.web_32bit.Text = "32bit";
            this.web_32bit.UseVisualStyleBackColor = true;
            // 
            // web_siteName
            // 
            this.web_siteName.Location = new System.Drawing.Point(135, 28);
            this.web_siteName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.web_siteName.Name = "web_siteName";
            this.web_siteName.Size = new System.Drawing.Size(187, 21);
            this.web_siteName.TabIndex = 15;
            // 
            // webSiteSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.web_siteName);
            this.Controls.Add(this.web_32bit);
            this.Controls.Add(this.web_folderPath);
            this.Controls.Add(this.btnChoose);
            this.Controls.Add(this.web_port);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.web_ip);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.web_label);
            this.Controls.Add(this.label20);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "webSiteSet";
            this.Size = new System.Drawing.Size(570, 78);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

       
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label web_label;
        private System.Windows.Forms.TextBox web_ip;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox web_port;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox web_folderPath;
        private System.Windows.Forms.Button btnChoose;
        private System.Windows.Forms.CheckBox web_32bit;
        private System.Windows.Forms.TextBox web_siteName;
    }
}
