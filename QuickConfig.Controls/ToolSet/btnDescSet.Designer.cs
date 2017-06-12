namespace QuickConfig.Controls.ToolSet
{
    partial class btnDescSet
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
            this.btn_desc = new System.Windows.Forms.Label();
            this.btn_exec = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_desc
            // 
            this.btn_desc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btn_desc.Location = new System.Drawing.Point(3, 1);
            this.btn_desc.Name = "btn_desc";
            this.btn_desc.Size = new System.Drawing.Size(457, 70);
            this.btn_desc.TabIndex = 0;
            this.btn_desc.Text = "label1";
            // 
            // btn_exec
            // 
            this.btn_exec.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_exec.Location = new System.Drawing.Point(481, 11);
            this.btn_exec.Name = "btn_exec";
            this.btn_exec.Size = new System.Drawing.Size(75, 50);
            this.btn_exec.TabIndex = 1;
            this.btn_exec.Text = "执行";
            this.btn_exec.UseVisualStyleBackColor = true;
            this.btn_exec.Click += new System.EventHandler(this.btn_exec_Click);
            // 
            // btnDescSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btn_exec);
            this.Controls.Add(this.btn_desc);
            this.Name = "btnDescSet";
            this.Size = new System.Drawing.Size(570, 73);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label btn_desc;
        private System.Windows.Forms.Button btn_exec;
    }
}
