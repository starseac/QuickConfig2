namespace QuickConfig.Controls.ToolSet
{
    partial class InputSet
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
            this.input_label = new System.Windows.Forms.Label();
            this.input_value = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // input_label
            // 
            this.input_label.Location = new System.Drawing.Point(4, 2);
            this.input_label.Name = "input_label";
            this.input_label.Size = new System.Drawing.Size(135, 26);
            this.input_label.TabIndex = 0;
            this.input_label.Text = "label1";
            this.input_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // input_value
            // 
            this.input_value.Location = new System.Drawing.Point(145, 2);
            this.input_value.Multiline = true;
            this.input_value.Name = "input_value";
            this.input_value.Size = new System.Drawing.Size(412, 26);
            this.input_value.TabIndex = 1;
            // 
            // InputSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.input_value);
            this.Controls.Add(this.input_label);
            this.Name = "InputSet";
            this.Size = new System.Drawing.Size(570, 34);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label input_label;
        private System.Windows.Forms.TextBox input_value;
    }
}
