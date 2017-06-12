namespace QuickConfig.Controls.NetWorkSet
{
    partial class serviceSet
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
            this.service_port = new System.Windows.Forms.TextBox();
            this.service_ip = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.service_label = new System.Windows.Forms.Label();
            this.service_folderPath = new System.Windows.Forms.TextBox();
            this.btnChoose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // service_port
            // 
            this.service_port.Location = new System.Drawing.Point(411, 36);
            this.service_port.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.service_port.Name = "service_port";
            this.service_port.Size = new System.Drawing.Size(76, 21);
            this.service_port.TabIndex = 3;
            // 
            // service_ip
            // 
            this.service_ip.Location = new System.Drawing.Point(138, 36);
            this.service_ip.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.service_ip.Name = "service_ip";
            this.service_ip.Size = new System.Drawing.Size(184, 21);
            this.service_ip.TabIndex = 2;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(83, 41);
            this.label18.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(41, 12);
            this.label18.TabIndex = 0;
            this.label18.Text = "ip地址";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(350, 38);
            this.label19.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(29, 12);
            this.label19.TabIndex = 1;
            this.label19.Text = "端口";
            // 
            // service_label
            // 
            this.service_label.Location = new System.Drawing.Point(3, 12);
            this.service_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.service_label.Name = "service_label";
            this.service_label.Size = new System.Drawing.Size(74, 41);
            this.service_label.TabIndex = 6;
            this.service_label.Text = "label1";
            // 
            // service_folderPath
            // 
            this.service_folderPath.Location = new System.Drawing.Point(81, 9);
            this.service_folderPath.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.service_folderPath.Name = "service_folderPath";
            this.service_folderPath.Size = new System.Drawing.Size(406, 21);
            this.service_folderPath.TabIndex = 5;
            // 
            // btnChoose
            // 
            this.btnChoose.BackColor = System.Drawing.Color.AliceBlue;
            this.btnChoose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnChoose.Location = new System.Drawing.Point(503, 10);
            this.btnChoose.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnChoose.Name = "btnChoose";
            this.btnChoose.Size = new System.Drawing.Size(56, 21);
            this.btnChoose.TabIndex = 4;
            this.btnChoose.Text = "选择";
            this.btnChoose.UseVisualStyleBackColor = false;
            this.btnChoose.Click += new System.EventHandler(this.btnChoose_Click);
            // 
            // serviceSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.service_label);
            this.Controls.Add(this.service_folderPath);
            this.Controls.Add(this.btnChoose);
            this.Controls.Add(this.service_port);
            this.Controls.Add(this.service_ip);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label19);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "serviceSet";
            this.Size = new System.Drawing.Size(570, 62);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox service_port;
        private System.Windows.Forms.TextBox service_ip;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label service_label;
        private System.Windows.Forms.TextBox service_folderPath;
        private System.Windows.Forms.Button btnChoose;
    }
}
