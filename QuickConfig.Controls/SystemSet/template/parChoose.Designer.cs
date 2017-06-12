namespace QuickConfig.Controls.SystemSet.template
{
    partial class parChoose
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
            this.par_key = new System.Windows.Forms.Label();
            this.par_value = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // par_key
            // 
            this.par_key.AutoSize = true;
            this.par_key.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.par_key.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.par_key.Location = new System.Drawing.Point(4, 4);
            this.par_key.Name = "par_key";
            this.par_key.Size = new System.Drawing.Size(47, 12);
            this.par_key.TabIndex = 0;
            this.par_key.Text = "label1";
            // 
            // par_value
            // 
            this.par_value.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.par_value.Location = new System.Drawing.Point(4, 29);
            this.par_value.Name = "par_value";
            this.par_value.Size = new System.Drawing.Size(148, 23);
            this.par_value.TabIndex = 1;
            this.par_value.Text = "label2";
            this.par_value.MouseEnter += new System.EventHandler(this.par_value_MouseEnter);
            // 
            // toolTip1
            // 
            this.toolTip1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // parChoose
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.par_value);
            this.Controls.Add(this.par_key);
            this.Name = "parChoose";
            this.Size = new System.Drawing.Size(155, 55);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.parChoose_MouseDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label par_key;
        private System.Windows.Forms.Label par_value;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
