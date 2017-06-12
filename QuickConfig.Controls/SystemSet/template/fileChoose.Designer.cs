namespace QuickConfig.Controls.SystemSet.template
{
    partial class fileChoose
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
            this.btn_brower = new System.Windows.Forms.Button();
            this.txt_path = new System.Windows.Forms.TextBox();
            this.btn_load = new System.Windows.Forms.Button();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.btn_confim = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_brower
            // 
            this.btn_brower.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_brower.Location = new System.Drawing.Point(79, 35);
            this.btn_brower.Name = "btn_brower";
            this.btn_brower.Size = new System.Drawing.Size(75, 23);
            this.btn_brower.TabIndex = 0;
            this.btn_brower.Text = "浏览";
            this.btn_brower.UseVisualStyleBackColor = true;
            this.btn_brower.Click += new System.EventHandler(this.btn_brower_Click);
            // 
            // txt_path
            // 
            this.txt_path.Location = new System.Drawing.Point(6, 8);
            this.txt_path.Name = "txt_path";
            this.txt_path.Size = new System.Drawing.Size(353, 21);
            this.txt_path.TabIndex = 1;
            // 
            // btn_load
            // 
            this.btn_load.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_load.Location = new System.Drawing.Point(182, 35);
            this.btn_load.Name = "btn_load";
            this.btn_load.Size = new System.Drawing.Size(75, 23);
            this.btn_load.TabIndex = 2;
            this.btn_load.Text = "加载";
            this.btn_load.UseVisualStyleBackColor = true;
            this.btn_load.Click += new System.EventHandler(this.btn_load_Click);
            // 
            // treeView1
            // 
            this.treeView1.CheckBoxes = true;
            this.treeView1.Location = new System.Drawing.Point(7, 65);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(350, 393);
            this.treeView1.TabIndex = 3;
            // 
            // btn_confim
            // 
            this.btn_confim.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_confim.Location = new System.Drawing.Point(134, 464);
            this.btn_confim.Name = "btn_confim";
            this.btn_confim.Size = new System.Drawing.Size(75, 23);
            this.btn_confim.TabIndex = 4;
            this.btn_confim.Text = "确定";
            this.btn_confim.UseVisualStyleBackColor = true;
            this.btn_confim.Click += new System.EventHandler(this.btn_confim_Click);
            // 
            // fileChoose
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btn_confim);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.btn_load);
            this.Controls.Add(this.txt_path);
            this.Controls.Add(this.btn_brower);
            this.Name = "fileChoose";
            this.Size = new System.Drawing.Size(367, 495);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_brower;
        private System.Windows.Forms.TextBox txt_path;
        private System.Windows.Forms.Button btn_load;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Button btn_confim;
    }
}
