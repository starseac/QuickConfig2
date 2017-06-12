namespace QuickConfig.Controls.DbInit
{
    partial class dbInit
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
            this.btnCreateTablespace = new System.Windows.Forms.Button();
            this.btnCreateUser = new System.Windows.Forms.Button();
            this.btnCreateSde = new System.Windows.Forms.Button();
            this.btnInitSde = new System.Windows.Forms.Button();
            this.btnDmpImport = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.checkAll = new System.Windows.Forms.CheckBox();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCreateTablespace
            // 
            this.btnCreateTablespace.BackColor = System.Drawing.Color.AliceBlue;
            this.btnCreateTablespace.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCreateTablespace.Location = new System.Drawing.Point(54, 2);
            this.btnCreateTablespace.Margin = new System.Windows.Forms.Padding(2);
            this.btnCreateTablespace.Name = "btnCreateTablespace";
            this.btnCreateTablespace.Size = new System.Drawing.Size(92, 21);
            this.btnCreateTablespace.TabIndex = 0;
            this.btnCreateTablespace.Text = "创建表空间";
            this.btnCreateTablespace.UseVisualStyleBackColor = false;
            this.btnCreateTablespace.Click += new System.EventHandler(this.btnCreateTablespace_Click);
            // 
            // btnCreateUser
            // 
            this.btnCreateUser.BackColor = System.Drawing.Color.AliceBlue;
            this.btnCreateUser.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCreateUser.Location = new System.Drawing.Point(150, 2);
            this.btnCreateUser.Margin = new System.Windows.Forms.Padding(2);
            this.btnCreateUser.Name = "btnCreateUser";
            this.btnCreateUser.Size = new System.Drawing.Size(72, 21);
            this.btnCreateUser.TabIndex = 1;
            this.btnCreateUser.Text = "创建用户";
            this.btnCreateUser.UseVisualStyleBackColor = false;
            this.btnCreateUser.Click += new System.EventHandler(this.btnCreateUser_Click);
            // 
            // btnCreateSde
            // 
            this.btnCreateSde.BackColor = System.Drawing.Color.AliceBlue;
            this.btnCreateSde.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCreateSde.Location = new System.Drawing.Point(226, 2);
            this.btnCreateSde.Margin = new System.Windows.Forms.Padding(2);
            this.btnCreateSde.Name = "btnCreateSde";
            this.btnCreateSde.Size = new System.Drawing.Size(102, 21);
            this.btnCreateSde.TabIndex = 2;
            this.btnCreateSde.Text = "创建企业空间库";
            this.btnCreateSde.UseVisualStyleBackColor = false;
            this.btnCreateSde.Click += new System.EventHandler(this.btnCreateSde_Click);
            // 
            // btnInitSde
            // 
            this.btnInitSde.BackColor = System.Drawing.Color.AliceBlue;
            this.btnInitSde.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnInitSde.Location = new System.Drawing.Point(332, 2);
            this.btnInitSde.Margin = new System.Windows.Forms.Padding(2);
            this.btnInitSde.Name = "btnInitSde";
            this.btnInitSde.Size = new System.Drawing.Size(98, 21);
            this.btnInitSde.TabIndex = 3;
            this.btnInitSde.Text = "初始化空间库";
            this.btnInitSde.UseVisualStyleBackColor = false;
            this.btnInitSde.Click += new System.EventHandler(this.btnInitSde_Click);
            // 
            // btnDmpImport
            // 
            this.btnDmpImport.BackColor = System.Drawing.Color.AliceBlue;
            this.btnDmpImport.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDmpImport.Location = new System.Drawing.Point(434, 2);
            this.btnDmpImport.Margin = new System.Windows.Forms.Padding(2);
            this.btnDmpImport.Name = "btnDmpImport";
            this.btnDmpImport.Size = new System.Drawing.Size(73, 21);
            this.btnDmpImport.TabIndex = 4;
            this.btnDmpImport.Text = "导入数据";
            this.btnDmpImport.UseVisualStyleBackColor = false;
            this.btnDmpImport.Click += new System.EventHandler(this.btnDmpImport_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.checkAll);
            this.flowLayoutPanel1.Controls.Add(this.btnCreateTablespace);
            this.flowLayoutPanel1.Controls.Add(this.btnCreateUser);
            this.flowLayoutPanel1.Controls.Add(this.btnCreateSde);
            this.flowLayoutPanel1.Controls.Add(this.btnInitSde);
            this.flowLayoutPanel1.Controls.Add(this.btnDmpImport);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(570, 32);
            this.flowLayoutPanel1.TabIndex = 5;
            // 
            // checkAll
            // 
            this.checkAll.AutoSize = true;
            this.checkAll.Location = new System.Drawing.Point(2, 2);
            this.checkAll.Margin = new System.Windows.Forms.Padding(2);
            this.checkAll.Name = "checkAll";
            this.checkAll.Size = new System.Drawing.Size(48, 16);
            this.checkAll.TabIndex = 5;
            this.checkAll.Text = "全选";
            this.checkAll.UseVisualStyleBackColor = true;
            this.checkAll.CheckedChanged += new System.EventHandler(this.checkAll_CheckedChanged);
            // 
            // dbInit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "dbInit";
            this.Size = new System.Drawing.Size(570, 32);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCreateTablespace;
        private System.Windows.Forms.Button btnCreateUser;
        private System.Windows.Forms.Button btnCreateSde;
        private System.Windows.Forms.Button btnInitSde;
        private System.Windows.Forms.Button btnDmpImport;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.CheckBox checkAll;
    }
}
