namespace QuickConfig.Controls.WebSiteSet
{
    partial class serviceInstall
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
            this.service_state = new System.Windows.Forms.Label();
            this.btn_install = new System.Windows.Forms.Button();
            this.btn_start = new System.Windows.Forms.Button();
            this.btn_stop = new System.Windows.Forms.Button();
            this.btn_remove = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.service_label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // service_state
            // 
            this.service_state.AutoSize = true;
            this.service_state.Location = new System.Drawing.Point(218, 10);
            this.service_state.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.service_state.Name = "service_state";
            this.service_state.Size = new System.Drawing.Size(35, 12);
            this.service_state.TabIndex = 10;
            this.service_state.Text = "state";
            // 
            // btn_install
            // 
            this.btn_install.BackColor = System.Drawing.Color.AliceBlue;
            this.btn_install.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_install.Location = new System.Drawing.Point(19, 36);
            this.btn_install.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_install.Name = "btn_install";
            this.btn_install.Size = new System.Drawing.Size(56, 21);
            this.btn_install.TabIndex = 5;
            this.btn_install.Text = "安装服务";
            this.btn_install.UseVisualStyleBackColor = false;
            this.btn_install.Click += new System.EventHandler(this.btn_install_Click);
            // 
            // btn_start
            // 
            this.btn_start.BackColor = System.Drawing.Color.AliceBlue;
            this.btn_start.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_start.Location = new System.Drawing.Point(98, 36);
            this.btn_start.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(56, 21);
            this.btn_start.TabIndex = 6;
            this.btn_start.Text = "启动";
            this.btn_start.UseVisualStyleBackColor = false;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // btn_stop
            // 
            this.btn_stop.BackColor = System.Drawing.Color.AliceBlue;
            this.btn_stop.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_stop.Location = new System.Drawing.Point(188, 36);
            this.btn_stop.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_stop.Name = "btn_stop";
            this.btn_stop.Size = new System.Drawing.Size(56, 21);
            this.btn_stop.TabIndex = 7;
            this.btn_stop.Text = "停止";
            this.btn_stop.UseVisualStyleBackColor = false;
            this.btn_stop.Click += new System.EventHandler(this.btn_stop_Click);
            // 
            // btn_remove
            // 
            this.btn_remove.BackColor = System.Drawing.Color.AliceBlue;
            this.btn_remove.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_remove.Location = new System.Drawing.Point(278, 36);
            this.btn_remove.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_remove.Name = "btn_remove";
            this.btn_remove.Size = new System.Drawing.Size(56, 21);
            this.btn_remove.TabIndex = 8;
            this.btn_remove.Text = "删除";
            this.btn_remove.UseVisualStyleBackColor = false;
            this.btn_remove.Click += new System.EventHandler(this.btn_remove_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(162, 10);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 9;
            this.label5.Text = "状态";
            // 
            // service_label
            // 
            this.service_label.AutoSize = true;
            this.service_label.Location = new System.Drawing.Point(19, 9);
            this.service_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.service_label.Name = "service_label";
            this.service_label.Size = new System.Drawing.Size(41, 12);
            this.service_label.TabIndex = 11;
            this.service_label.Text = "label1";
            // 
            // serviceInstall
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.service_label);
            this.Controls.Add(this.service_state);
            this.Controls.Add(this.btn_install);
            this.Controls.Add(this.btn_stop);
            this.Controls.Add(this.btn_start);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btn_remove);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "serviceInstall";
            this.Size = new System.Drawing.Size(570, 62);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label service_state;
        private System.Windows.Forms.Button btn_install;
        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.Button btn_stop;
        private System.Windows.Forms.Button btn_remove;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label service_label;
    }
}
