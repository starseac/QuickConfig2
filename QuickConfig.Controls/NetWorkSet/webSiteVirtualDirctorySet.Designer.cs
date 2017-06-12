namespace QuickConfig.Controls.NetWorkSet
{
    partial class webSiteVirtualDirctorySet
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_virtualName = new System.Windows.Forms.TextBox();
            this.txt_path = new System.Windows.Forms.TextBox();
            this.btn_choose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "虚拟目录";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "名称";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "路径";
            // 
            // txt_virtualName
            // 
            this.txt_virtualName.Location = new System.Drawing.Point(74, 2);
            this.txt_virtualName.Name = "txt_virtualName";
            this.txt_virtualName.Size = new System.Drawing.Size(416, 21);
            this.txt_virtualName.TabIndex = 3;
            // 
            // txt_path
            // 
            this.txt_path.Location = new System.Drawing.Point(74, 29);
            this.txt_path.Name = "txt_path";
            this.txt_path.Size = new System.Drawing.Size(416, 21);
            this.txt_path.TabIndex = 4;
            // 
            // btn_choose
            // 
            this.btn_choose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_choose.Location = new System.Drawing.Point(504, 28);
            this.btn_choose.Name = "btn_choose";
            this.btn_choose.Size = new System.Drawing.Size(43, 22);
            this.btn_choose.TabIndex = 5;
            this.btn_choose.Text = "浏览";
            this.btn_choose.UseVisualStyleBackColor = true;
            this.btn_choose.Click += new System.EventHandler(this.btn_choose_Click);
            // 
            // webSiteVirtualDirctorySet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.btn_choose);
            this.Controls.Add(this.txt_path);
            this.Controls.Add(this.txt_virtualName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "webSiteVirtualDirctorySet";
            this.Size = new System.Drawing.Size(570, 56);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_virtualName;
        private System.Windows.Forms.TextBox txt_path;
        private System.Windows.Forms.Button btn_choose;
    }
}
