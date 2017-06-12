using System.Windows.Forms;
namespace QuickConfig.OneKeyInstall
{
    partial class StartInstallBtn
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
            this.txButton1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txButton1
            // 
            this.txButton1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.txButton1.Location = new System.Drawing.Point(260, 44);
            this.txButton1.Name = "txButton1";
            this.txButton1.Size = new System.Drawing.Size(181, 48);
            this.txButton1.TabIndex = 0;
            this.txButton1.Text = "开始安装";
            this.txButton1.UseVisualStyleBackColor = true;
            this.txButton1.Click += new System.EventHandler(this.txButton1_Click);
            // 
            // StartInstallBtn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(248)))));
            this.Controls.Add(this.txButton1);
            this.Name = "StartInstallBtn";
            this.Size = new System.Drawing.Size(700, 150);
            this.ResumeLayout(false);

        }

        #endregion

        private Button txButton1;
    }
}
