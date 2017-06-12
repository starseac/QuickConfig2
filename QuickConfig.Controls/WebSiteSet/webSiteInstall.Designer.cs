namespace QuickConfig.Controls.WebSiteSet
{
    partial class webSiteInstall
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
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label40 = new System.Windows.Forms.Label();
            this.btn_createweb = new System.Windows.Forms.Button();
            this.checkAll = new System.Windows.Forms.CheckBox();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.flowLayoutPanel1);
            this.groupBox6.Location = new System.Drawing.Point(2, 5);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox6.Size = new System.Drawing.Size(566, 82);
            this.groupBox6.TabIndex = 16;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "网站";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(2, 16);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(562, 64);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.ForeColor = System.Drawing.Color.Red;
            this.label40.Location = new System.Drawing.Point(14, 93);
            this.label40.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(101, 12);
            this.label40.TabIndex = 5;
            this.label40.Text = "勾选要创建的网站";
            this.label40.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_createweb
            // 
            this.btn_createweb.BackColor = System.Drawing.Color.AliceBlue;
            this.btn_createweb.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_createweb.Location = new System.Drawing.Point(238, 89);
            this.btn_createweb.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_createweb.Name = "btn_createweb";
            this.btn_createweb.Size = new System.Drawing.Size(70, 21);
            this.btn_createweb.TabIndex = 4;
            this.btn_createweb.Text = "创建网站";
            this.btn_createweb.UseVisualStyleBackColor = false;
            this.btn_createweb.Click += new System.EventHandler(this.btn_createweb_Click);
            // 
            // checkAll
            // 
            this.checkAll.AutoSize = true;
            this.checkAll.Location = new System.Drawing.Point(136, 90);
            this.checkAll.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.checkAll.Name = "checkAll";
            this.checkAll.Size = new System.Drawing.Size(48, 16);
            this.checkAll.TabIndex = 17;
            this.checkAll.Text = "全选";
            this.checkAll.UseVisualStyleBackColor = true;
            this.checkAll.CheckedChanged += new System.EventHandler(this.checkAll_CheckedChanged);
            // 
            // webSiteInstall
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.checkAll);
            this.Controls.Add(this.label40);
            this.Controls.Add(this.btn_createweb);
            this.Controls.Add(this.groupBox6);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "webSiteInstall";
            this.Size = new System.Drawing.Size(570, 113);
            this.groupBox6.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.Button btn_createweb;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.CheckBox checkAll;
    }
}
