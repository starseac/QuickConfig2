namespace QuickConfig.Controls.SystemSet.show
{
    partial class showSet
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
            this.txt_desc = new System.Windows.Forms.Label();
            this.txt_value = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // txt_desc
            // 
            this.txt_desc.AutoSize = true;
            this.txt_desc.Location = new System.Drawing.Point(25, 4);
            this.txt_desc.Name = "txt_desc";
            this.txt_desc.Size = new System.Drawing.Size(41, 12);
            this.txt_desc.TabIndex = 0;
            this.txt_desc.Text = "label1";
            // 
            // txt_value
            // 
            this.txt_value.AutoSize = true;
            this.txt_value.Location = new System.Drawing.Point(133, 4);
            this.txt_value.Name = "txt_value";
            this.txt_value.Size = new System.Drawing.Size(48, 16);
            this.txt_value.TabIndex = 1;
            this.txt_value.Text = "显示";
            this.txt_value.UseVisualStyleBackColor = true;
            this.txt_value.CheckedChanged += new System.EventHandler(this.txt_value_CheckedChanged);
            // 
            // showSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txt_value);
            this.Controls.Add(this.txt_desc);
            this.Name = "showSet";
            this.Size = new System.Drawing.Size(391, 28);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label txt_desc;
        private System.Windows.Forms.CheckBox txt_value;
    }
}
