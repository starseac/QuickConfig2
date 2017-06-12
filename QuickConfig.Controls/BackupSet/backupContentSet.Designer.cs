namespace QuickConfig.Controls.BackupSet
{
    partial class backupContentSet
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.treeView3 = new System.Windows.Forms.TreeView();
            this.treeView2 = new System.Windows.Forms.TreeView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.设置排除文件夹ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.排除表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BackupSet_delete_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flowLayoutPanel1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.treeView1);
            this.flowLayoutPanel1.Controls.Add(this.treeView3);
            this.flowLayoutPanel1.Controls.Add(this.treeView2);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(570, 238);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // treeView1
            // 
            this.treeView1.CheckBoxes = true;
            this.treeView1.Location = new System.Drawing.Point(2, 2);
            this.treeView1.Margin = new System.Windows.Forms.Padding(2);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(173, 236);
            this.treeView1.TabIndex = 0;
            this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
            this.treeView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.treeView1_MouseDown);
            // 
            // treeView3
            // 
            this.treeView3.CheckBoxes = true;
            this.treeView3.Location = new System.Drawing.Point(179, 2);
            this.treeView3.Margin = new System.Windows.Forms.Padding(2);
            this.treeView3.Name = "treeView3";
            this.treeView3.Size = new System.Drawing.Size(181, 236);
            this.treeView3.TabIndex = 2;
            this.treeView3.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView3_NodeMouseClick);
            this.treeView3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.treeView1_MouseDown);
            // 
            // treeView2
            // 
            this.treeView2.CheckBoxes = true;
            this.treeView2.Location = new System.Drawing.Point(364, 2);
            this.treeView2.Margin = new System.Windows.Forms.Padding(2);
            this.treeView2.Name = "treeView2";
            this.treeView2.Size = new System.Drawing.Size(200, 236);
            this.treeView2.TabIndex = 1;
            this.treeView2.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView2_NodeMouseClick);
            this.treeView2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.treeView1_MouseDown);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.设置排除文件夹ToolStripMenuItem,
            this.排除表ToolStripMenuItem,
            this.BackupSet_delete_ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(166, 92);
            // 
            // 设置排除文件夹ToolStripMenuItem
            // 
            this.设置排除文件夹ToolStripMenuItem.Name = "设置排除文件夹ToolStripMenuItem";
            this.设置排除文件夹ToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.设置排除文件夹ToolStripMenuItem.Text = "排除文件/文件夹";
            this.设置排除文件夹ToolStripMenuItem.Click += new System.EventHandler(this.BackupSet_ToolStripMenuItem_Click);
            // 
            // 排除表ToolStripMenuItem
            // 
            this.排除表ToolStripMenuItem.Name = "排除表ToolStripMenuItem";
            this.排除表ToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.排除表ToolStripMenuItem.Text = "排除表";
            this.排除表ToolStripMenuItem.Click += new System.EventHandler(this.BackupSet_ToolStripMenuItem_Click);
            // 
            // BackupSet_delete_ToolStripMenuItem
            // 
            this.BackupSet_delete_ToolStripMenuItem.Name = "BackupSet_delete_ToolStripMenuItem";
            this.BackupSet_delete_ToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.BackupSet_delete_ToolStripMenuItem.Text = "删除";
            this.BackupSet_delete_ToolStripMenuItem.Click += new System.EventHandler(this.BackupSet_delete_ToolStripMenuItem_Click);
            // 
            // backupContentSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "backupContentSet";
            this.Size = new System.Drawing.Size(570, 238);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.TreeView treeView2;
        private System.Windows.Forms.TreeView treeView3;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 设置排除文件夹ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 排除表ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem BackupSet_delete_ToolStripMenuItem;



    }
}
