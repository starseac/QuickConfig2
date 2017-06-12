namespace QuickConfig.Controls.SystemSet.template
{
    partial class addConfigFolder
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
            this.label1 = new System.Windows.Forms.Label();
            this.txt_configfolder = new System.Windows.Forms.TextBox();
            this.btn_createConfigFolder = new System.Windows.Forms.Button();
            this.cb_applist = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "配置文件夹";
            // 
            // txt_configfolder
            // 
            this.txt_configfolder.Location = new System.Drawing.Point(90, 38);
            this.txt_configfolder.Name = "txt_configfolder";
            this.txt_configfolder.Size = new System.Drawing.Size(183, 21);
            this.txt_configfolder.TabIndex = 1;
            // 
            // btn_createConfigFolder
            // 
            this.btn_createConfigFolder.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_createConfigFolder.Location = new System.Drawing.Point(198, 72);
            this.btn_createConfigFolder.Name = "btn_createConfigFolder";
            this.btn_createConfigFolder.Size = new System.Drawing.Size(75, 23);
            this.btn_createConfigFolder.TabIndex = 2;
            this.btn_createConfigFolder.Text = "创建";
            this.btn_createConfigFolder.UseVisualStyleBackColor = true;
            this.btn_createConfigFolder.Click += new System.EventHandler(this.btn_createConfigFolder_Click);
            // 
            // cb_applist
            // 
            this.cb_applist.FormattingEnabled = true;
            this.cb_applist.Location = new System.Drawing.Point(90, 7);
            this.cb_applist.Name = "cb_applist";
            this.cb_applist.Size = new System.Drawing.Size(183, 20);
            this.cb_applist.TabIndex = 3;
            this.cb_applist.SelectedIndexChanged += new System.EventHandler(this.cb_applist_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "选择程序";
            // 
            // addConfigFolder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cb_applist);
            this.Controls.Add(this.btn_createConfigFolder);
            this.Controls.Add(this.txt_configfolder);
            this.Controls.Add(this.label1);
            this.Name = "addConfigFolder";
            this.Size = new System.Drawing.Size(291, 104);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_configfolder;
        private System.Windows.Forms.Button btn_createConfigFolder;
        private System.Windows.Forms.ComboBox cb_applist;
        private System.Windows.Forms.Label label2;
    }
}
