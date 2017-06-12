using System.Windows.Forms;
namespace QuickConfig.OneKeyInstall
{
    partial class StartConfig
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
            this.mainPath = new System.Windows.Forms.TextBox();
            this.ChooseInstallFolder = new System.Windows.Forms.Button();
            this.db_ip = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.db_datasource = new System.Windows.Forms.TextBox();
            this.db_password = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnTestConnect = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.app_ip = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // mainPath
            // 
            this.mainPath.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.mainPath.ForeColor = System.Drawing.SystemColors.WindowText;
            this.mainPath.Location = new System.Drawing.Point(120, 2);
            this.mainPath.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.mainPath.Name = "mainPath";
            this.mainPath.Size = new System.Drawing.Size(318, 21);
            this.mainPath.TabIndex = 0;
            // 
            // ChooseInstallFolder
            // 
            this.ChooseInstallFolder.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ChooseInstallFolder.Location = new System.Drawing.Point(445, 2);
            this.ChooseInstallFolder.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ChooseInstallFolder.Name = "ChooseInstallFolder";
            this.ChooseInstallFolder.Size = new System.Drawing.Size(74, 22);
            this.ChooseInstallFolder.TabIndex = 1;
            this.ChooseInstallFolder.Text = "浏览";
            this.ChooseInstallFolder.UseVisualStyleBackColor = true;
            this.ChooseInstallFolder.Click += new System.EventHandler(this.ChooseInstallFolder_Click);
            // 
            // db_ip
            // 
            this.db_ip.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.db_ip.ForeColor = System.Drawing.SystemColors.WindowText;
            this.db_ip.Location = new System.Drawing.Point(120, 46);
            this.db_ip.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.db_ip.Name = "db_ip";
            this.db_ip.Size = new System.Drawing.Size(169, 21);
            this.db_ip.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(8, 47);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 14);
            this.label1.TabIndex = 3;
            this.label1.Text = "数据库服务器 IP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(8, 70);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 14);
            this.label2.TabIndex = 4;
            this.label2.Text = "数据源";
            // 
            // db_datasource
            // 
            this.db_datasource.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.db_datasource.ForeColor = System.Drawing.SystemColors.WindowText;
            this.db_datasource.Location = new System.Drawing.Point(121, 69);
            this.db_datasource.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.db_datasource.Name = "db_datasource";
            this.db_datasource.Size = new System.Drawing.Size(168, 21);
            this.db_datasource.TabIndex = 5;
            // 
            // db_password
            // 
            this.db_password.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.db_password.ForeColor = System.Drawing.SystemColors.WindowText;
            this.db_password.Location = new System.Drawing.Point(339, 70);
            this.db_password.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.db_password.Name = "db_password";
            this.db_password.Size = new System.Drawing.Size(99, 21);
            this.db_password.TabIndex = 6;
            this.db_password.TextChanged += new System.EventHandler(this.db_password_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(302, 74);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 14);
            this.label3.TabIndex = 7;
            this.label3.Text = "密码";
            // 
            // btnTestConnect
            // 
            this.btnTestConnect.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnTestConnect.Location = new System.Drawing.Point(446, 31);
            this.btnTestConnect.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnTestConnect.Name = "btnTestConnect";
            this.btnTestConnect.Size = new System.Drawing.Size(74, 61);
            this.btnTestConnect.TabIndex = 9;
            this.btnTestConnect.Text = "测试链接";
            this.btnTestConnect.UseVisualStyleBackColor = true;
            this.btnTestConnect.Click += new System.EventHandler(this.btnTestConnect_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(6, 7);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 14);
            this.label4.TabIndex = 10;
            this.label4.Text = "安装路径";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(7, 27);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 14);
            this.label5.TabIndex = 11;
            this.label5.Text = "程序服务器 IP";
            // 
            // app_ip
            // 
            this.app_ip.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.app_ip.ForeColor = System.Drawing.SystemColors.WindowText;
            this.app_ip.Location = new System.Drawing.Point(120, 25);
            this.app_ip.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.app_ip.Name = "app_ip";
            this.app_ip.Size = new System.Drawing.Size(169, 21);
            this.app_ip.TabIndex = 12;
            // 
            // StartConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(248)))));
            this.Controls.Add(this.app_ip);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnTestConnect);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.db_password);
            this.Controls.Add(this.db_datasource);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.db_ip);
            this.Controls.Add(this.ChooseInstallFolder);
            this.Controls.Add(this.mainPath);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "StartConfig";
            this.Size = new System.Drawing.Size(525, 99);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox mainPath;
        private Button ChooseInstallFolder;
        private TextBox db_ip;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private TextBox db_datasource;
        private TextBox db_password;
        private System.Windows.Forms.Label label3;
        private Button btnTestConnect;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private TextBox app_ip;

    }
}
