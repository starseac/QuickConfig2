namespace QuickConfig.Controls.NetWorkSet
{
    partial class gxmlSet
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
            this.gxml_folderPath = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.gxml_ip = new System.Windows.Forms.TextBox();
            this.gxml_password = new System.Windows.Forms.TextBox();
            this.gxml_user = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCreateFolder
            // 
            this.btnCreateFolder.BackColor = System.Drawing.Color.AliceBlue;
            this.btnCreateFolder.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCreateFolder.Location = new System.Drawing.Point(485, 4);
            this.btnCreateFolder.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCreateFolder.Name = "btnCreateFolder";
            this.btnCreateFolder.Size = new System.Drawing.Size(74, 21);
            this.btnCreateFolder.TabIndex = 9;
            this.btnCreateFolder.Text = "创建文件夹";
            this.btnCreateFolder.UseVisualStyleBackColor = false;
            this.btnCreateFolder.Click += new System.EventHandler(this.btnCreateFolder_Click);
            // 
            // btnChoose
            // 
            this.btnChoose.BackColor = System.Drawing.Color.AliceBlue;
            this.btnChoose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnChoose.Location = new System.Drawing.Point(420, 5);
            this.btnChoose.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnChoose.Name = "btnChoose";
            this.btnChoose.Size = new System.Drawing.Size(51, 21);
            this.btnChoose.TabIndex = 8;
            this.btnChoose.Text = "选择";
            this.btnChoose.UseVisualStyleBackColor = false;
            this.btnChoose.Click += new System.EventHandler(this.btnChoose_Click);
            // 
            // gxml_folderPath
            // 
            this.gxml_folderPath.Location = new System.Drawing.Point(137, 5);
            this.gxml_folderPath.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gxml_folderPath.Name = "gxml_folderPath";
            this.gxml_folderPath.Size = new System.Drawing.Size(232, 21);
            this.gxml_folderPath.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(86, 8);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "路径";
            // 
            // gxml_ip
            // 
            this.gxml_ip.Location = new System.Drawing.Point(137, 31);
            this.gxml_ip.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gxml_ip.Name = "gxml_ip";
            this.gxml_ip.Size = new System.Drawing.Size(232, 21);
            this.gxml_ip.TabIndex = 5;
            // 
            // gxml_password
            // 
            this.gxml_password.Location = new System.Drawing.Point(415, 58);
            this.gxml_password.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gxml_password.Name = "gxml_password";
            this.gxml_password.Size = new System.Drawing.Size(144, 21);
            this.gxml_password.TabIndex = 4;
            // 
            // gxml_user
            // 
            this.gxml_user.Location = new System.Drawing.Point(137, 58);
            this.gxml_user.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gxml_user.Name = "gxml_user";
            this.gxml_user.Size = new System.Drawing.Size(232, 21);
            this.gxml_user.TabIndex = 3;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(381, 62);
            this.label26.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(29, 12);
            this.label26.TabIndex = 2;
            this.label26.Text = "密码";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(87, 62);
            this.label25.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(29, 12);
            this.label25.TabIndex = 1;
            this.label25.Text = "用户";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(86, 31);
            this.label24.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(41, 12);
            this.label24.TabIndex = 0;
            this.label24.Text = "ip地址";
            // 
            // label
            // 
            this.label.Location = new System.Drawing.Point(3, 9);
            this.label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(78, 34);
            this.label.TabIndex = 10;
            this.label.Text = "label1";
            // 
            // gxmlSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.label);
            this.Controls.Add(this.btnCreateFolder);
            this.Controls.Add(this.btnChoose);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.gxml_folderPath);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.gxml_ip);
            this.Controls.Add(this.gxml_user);
            this.Controls.Add(this.gxml_password);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "gxmlSet";
            this.Size = new System.Drawing.Size(570, 84);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCreateFolder;
        private System.Windows.Forms.Button btnChoose;
        private System.Windows.Forms.TextBox gxml_folderPath;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox gxml_ip;
        private System.Windows.Forms.TextBox gxml_password;
        private System.Windows.Forms.TextBox gxml_user;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label;
    }
}
