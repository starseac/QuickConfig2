namespace QuickConfig.Controls.DbInit
{
    partial class gdbChoose
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
            this.btnChoose = new System.Windows.Forms.Button();
            this.gdb_folderPath = new System.Windows.Forms.TextBox();
            this.gdb_label = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnChoose
            // 
            this.btnChoose.BackColor = System.Drawing.Color.AliceBlue;
            this.btnChoose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnChoose.Location = new System.Drawing.Point(506, 2);
            this.btnChoose.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnChoose.Name = "btnChoose";
            this.btnChoose.Size = new System.Drawing.Size(56, 21);
            this.btnChoose.TabIndex = 90;
            this.btnChoose.Text = "选择";
            this.btnChoose.UseVisualStyleBackColor = false;
            this.btnChoose.Click += new System.EventHandler(this.btnChoose_Click);
            // 
            // gdb_folderPath
            // 
            this.gdb_folderPath.Location = new System.Drawing.Point(81, 2);
            this.gdb_folderPath.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gdb_folderPath.Name = "gdb_folderPath";
            this.gdb_folderPath.Size = new System.Drawing.Size(413, 21);
            this.gdb_folderPath.TabIndex = 89;
            // 
            // gdb_label
            // 
            this.gdb_label.AutoSize = true;
            this.gdb_label.Location = new System.Drawing.Point(5, 5);
            this.gdb_label.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gdb_label.Name = "gdb_label";
            this.gdb_label.Size = new System.Drawing.Size(60, 16);
            this.gdb_label.TabIndex = 88;
            this.gdb_label.Text = "临时库";
            this.gdb_label.UseVisualStyleBackColor = true;
            // 
            // gdbChoose
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.btnChoose);
            this.Controls.Add(this.gdb_folderPath);
            this.Controls.Add(this.gdb_label);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "gdbChoose";
            this.Size = new System.Drawing.Size(570, 24);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnChoose;
        private System.Windows.Forms.TextBox gdb_folderPath;
        private System.Windows.Forms.CheckBox gdb_label;
    }
}
