namespace QuickConfig.Controls.NetWorkSet
{
    partial class ftpSiteSet
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
            this.btnCreateFolder = new System.Windows.Forms.Button();
            this.btnChoose = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.ftp_folderPath = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.ftp_password = new System.Windows.Forms.TextBox();
            this.ftp_user = new System.Windows.Forms.TextBox();
            this.ftp_ip = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCreateFolder
            // 
            this.btnCreateFolder.BackColor = System.Drawing.Color.AliceBlue;
            this.btnCreateFolder.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCreateFolder.Location = new System.Drawing.Point(488, 2);
            this.btnCreateFolder.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCreateFolder.Name = "btnCreateFolder";
            this.btnCreateFolder.Size = new System.Drawing.Size(74, 21);
            this.btnCreateFolder.TabIndex = 12;
            this.btnCreateFolder.Text = "创建文件夹";
            this.btnCreateFolder.UseVisualStyleBackColor = false;
            this.btnCreateFolder.Click += new System.EventHandler(this.btnCreateFolder_Click);
            // 
            // btnChoose
            // 
            this.btnChoose.BackColor = System.Drawing.Color.AliceBlue;
            this.btnChoose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnChoose.Location = new System.Drawing.Point(423, 2);
            this.btnChoose.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnChoose.Name = "btnChoose";
            this.btnChoose.Size = new System.Drawing.Size(51, 21);
            this.btnChoose.TabIndex = 11;
            this.btnChoose.Text = "选择";
            this.btnChoose.UseVisualStyleBackColor = false;
            this.btnChoose.Click += new System.EventHandler(this.btnChoose_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(86, 11);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 10;
            this.label3.Text = "路径";
            // 
            // ftp_folderPath
            // 
            this.ftp_folderPath.Location = new System.Drawing.Point(136, 4);
            this.ftp_folderPath.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ftp_folderPath.Name = "ftp_folderPath";
            this.ftp_folderPath.Size = new System.Drawing.Size(237, 21);
            this.ftp_folderPath.TabIndex = 9;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(388, 60);
            this.label23.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(29, 12);
            this.label23.TabIndex = 8;
            this.label23.Text = "密码";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(84, 58);
            this.label22.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(29, 12);
            this.label22.TabIndex = 7;
            this.label22.Text = "用户";
            // 
            // ftp_password
            // 
            this.ftp_password.Location = new System.Drawing.Point(430, 56);
            this.ftp_password.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ftp_password.Name = "ftp_password";
            this.ftp_password.Size = new System.Drawing.Size(132, 21);
            this.ftp_password.TabIndex = 6;
            // 
            // ftp_user
            // 
            this.ftp_user.Location = new System.Drawing.Point(135, 56);
            this.ftp_user.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ftp_user.Name = "ftp_user";
            this.ftp_user.Size = new System.Drawing.Size(238, 21);
            this.ftp_user.TabIndex = 5;
            // 
            // ftp_ip
            // 
            this.ftp_ip.Location = new System.Drawing.Point(135, 30);
            this.ftp_ip.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ftp_ip.Name = "ftp_ip";
            this.ftp_ip.Size = new System.Drawing.Size(238, 21);
            this.ftp_ip.TabIndex = 4;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(84, 34);
            this.label21.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(41, 12);
            this.label21.TabIndex = 3;
            this.label21.Text = "ip地址";
            // 
            // label
            // 
            this.label.Location = new System.Drawing.Point(4, 9);
            this.label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(76, 41);
            this.label.TabIndex = 13;
            this.label.Text = "label1";
            // 
            // ftpSiteSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.label);
            this.Controls.Add(this.btnCreateFolder);
            this.Controls.Add(this.btnChoose);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ftp_ip);
            this.Controls.Add(this.ftp_folderPath);
            this.Controls.Add(this.ftp_user);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.ftp_password);
            this.Controls.Add(this.label22);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ftpSiteSet";
            this.Size = new System.Drawing.Size(570, 82);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCreateFolder;
        private System.Windows.Forms.Button btnChoose;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ftp_folderPath;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox ftp_password;
        private System.Windows.Forms.TextBox ftp_user;
        private System.Windows.Forms.TextBox ftp_ip;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label;
    }
}
