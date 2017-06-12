using System.Windows.Forms;
namespace QuickConfig.OneKeyInstall
{
    partial class StartAgree
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
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.txCheckBox1 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // txButton1
            // 
            this.txButton1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.txButton1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txButton1.Location = new System.Drawing.Point(593, 0);
            this.txButton1.Name = "txButton1";
            this.txButton1.Size = new System.Drawing.Size(100, 30);
            this.txButton1.TabIndex = 5;
            this.txButton1.Text = "自定义设置";
            this.txButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.txButton1.UseVisualStyleBackColor = true;
            this.txButton1.Click += new System.EventHandler(this.txButton1_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.linkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabel1.Location = new System.Drawing.Point(123, 6);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(103, 15);
            this.linkLabel1.TabIndex = 4;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "软件许可协议";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // txCheckBox1
            // 
            this.txCheckBox1.AutoSize = true;
            this.txCheckBox1.Location = new System.Drawing.Point(5, 5);
            this.txCheckBox1.MinimumSize = new System.Drawing.Size(20, 20);
            this.txCheckBox1.Name = "txCheckBox1";
            this.txCheckBox1.Size = new System.Drawing.Size(104, 20);
            this.txCheckBox1.TabIndex = 3;
            this.txCheckBox1.Text = "阅读并同意";
            this.txCheckBox1.UseVisualStyleBackColor = true;
            // 
            // StartAgree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(248)))));
            this.Controls.Add(this.txButton1);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.txCheckBox1);
            this.Name = "StartAgree";
            this.Size = new System.Drawing.Size(700, 30);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button txButton1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private CheckBox txCheckBox1;
    }
}
