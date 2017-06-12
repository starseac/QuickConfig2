namespace QuickConfig.Controls.SystemSet.template
{
    partial class configTree
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
            this.components = new System.ComponentModel.Container();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.init_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addFolder_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addFile_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reImport_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.delet_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(325, 490);
            this.treeView1.TabIndex = 0;
            this.treeView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.treeView1_MouseDown);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.init_ToolStripMenuItem,
            this.addFolder_ToolStripMenuItem,
            this.addFile_ToolStripMenuItem,
            this.reImport_ToolStripMenuItem,
            this.delet_ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(161, 114);
            // 
            // init_ToolStripMenuItem
            // 
            this.init_ToolStripMenuItem.Name = "init_ToolStripMenuItem";
            this.init_ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.init_ToolStripMenuItem.Text = "初始化配置模板";
            this.init_ToolStripMenuItem.Click += new System.EventHandler(this.init_ToolStripMenuItem_Click);
            // 
            // addFolder_ToolStripMenuItem
            // 
            this.addFolder_ToolStripMenuItem.Name = "addFolder_ToolStripMenuItem";
            this.addFolder_ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.addFolder_ToolStripMenuItem.Text = "添加文件夹";
            this.addFolder_ToolStripMenuItem.Click += new System.EventHandler(this.addFolder_ToolStripMenuItem_Click);
            // 
            // addFile_ToolStripMenuItem
            // 
            this.addFile_ToolStripMenuItem.Name = "addFile_ToolStripMenuItem";
            this.addFile_ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.addFile_ToolStripMenuItem.Text = "添加文件";
            this.addFile_ToolStripMenuItem.Click += new System.EventHandler(this.addFile_ToolStripMenuItem_Click);
            // 
            // reImport_ToolStripMenuItem
            // 
            this.reImport_ToolStripMenuItem.Name = "reImport_ToolStripMenuItem";
            this.reImport_ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.reImport_ToolStripMenuItem.Text = "重新导入";
            this.reImport_ToolStripMenuItem.Click += new System.EventHandler(this.reImport_ToolStripMenuItem_Click);
            // 
            // delet_ToolStripMenuItem
            // 
            this.delet_ToolStripMenuItem.Name = "delet_ToolStripMenuItem";
            this.delet_ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.delet_ToolStripMenuItem.Text = "删除";
            this.delet_ToolStripMenuItem.Click += new System.EventHandler(this.delet_ToolStripMenuItem_Click);
            // 
            // configTree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.treeView1);
            this.Name = "configTree";
            this.Size = new System.Drawing.Size(325, 490);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem init_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addFolder_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addFile_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reImport_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem delet_ToolStripMenuItem;
    }
}
