namespace QuickConfig.Controls.ParsSet
{
    partial class parSet
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
            this.par_label = new System.Windows.Forms.Label();
            this.par_value = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // par_label
            // 
            this.par_label.AutoSize = true;
            this.par_label.Location = new System.Drawing.Point(18, 8);
            this.par_label.Name = "par_label";
            this.par_label.Size = new System.Drawing.Size(52, 15);
            this.par_label.TabIndex = 6;
            this.par_label.Text = "省简称";
            // 
            // par_value
            // 
            this.par_value.Location = new System.Drawing.Point(170, 3);
            this.par_value.Multiline = true;
            this.par_value.Name = "par_value";
            this.par_value.Size = new System.Drawing.Size(587, 24);
            this.par_value.TabIndex = 5;
            // 
            // parSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.par_label);
            this.Controls.Add(this.par_value);
            this.Name = "parSet";
            this.Size = new System.Drawing.Size(760, 30);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label par_label;
        private System.Windows.Forms.TextBox par_value;
    }
}
