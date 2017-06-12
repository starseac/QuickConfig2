namespace QuickConfig.Controls.BackupSet
{
    partial class backupSet
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
            this.lab_backupServicesState = new System.Windows.Forms.Label();
            this.label48 = new System.Windows.Forms.Label();
            this.label47 = new System.Windows.Forms.Label();
            this.tab_backup = new System.Windows.Forms.TabControl();
            this.type_day = new System.Windows.Forms.TabPage();
            this.backup_day_starttime = new System.Windows.Forms.DateTimePicker();
            this.label50 = new System.Windows.Forms.Label();
            this.type_week = new System.Windows.Forms.TabPage();
            this.backup_week_starttime = new System.Windows.Forms.DateTimePicker();
            this.label51 = new System.Windows.Forms.Label();
            this.backup_week_check7 = new System.Windows.Forms.CheckBox();
            this.backup_week_check6 = new System.Windows.Forms.CheckBox();
            this.backup_week_check5 = new System.Windows.Forms.CheckBox();
            this.backup_week_check4 = new System.Windows.Forms.CheckBox();
            this.backup_week_check3 = new System.Windows.Forms.CheckBox();
            this.backup_week_check2 = new System.Windows.Forms.CheckBox();
            this.backup_week_check1 = new System.Windows.Forms.CheckBox();
            this.type_month = new System.Windows.Forms.TabPage();
            this.backup_month_starttime = new System.Windows.Forms.DateTimePicker();
            this.label52 = new System.Windows.Forms.Label();
            this.backup_month_check31 = new System.Windows.Forms.CheckBox();
            this.backup_month_check30 = new System.Windows.Forms.CheckBox();
            this.backup_month_check29 = new System.Windows.Forms.CheckBox();
            this.backup_month_check28 = new System.Windows.Forms.CheckBox();
            this.backup_month_check27 = new System.Windows.Forms.CheckBox();
            this.backup_month_check26 = new System.Windows.Forms.CheckBox();
            this.backup_month_check25 = new System.Windows.Forms.CheckBox();
            this.backup_month_check24 = new System.Windows.Forms.CheckBox();
            this.backup_month_check23 = new System.Windows.Forms.CheckBox();
            this.backup_month_check22 = new System.Windows.Forms.CheckBox();
            this.backup_month_check18 = new System.Windows.Forms.CheckBox();
            this.backup_month_check17 = new System.Windows.Forms.CheckBox();
            this.backup_month_check19 = new System.Windows.Forms.CheckBox();
            this.backup_month_check20 = new System.Windows.Forms.CheckBox();
            this.backup_month_check21 = new System.Windows.Forms.CheckBox();
            this.backup_month_check12 = new System.Windows.Forms.CheckBox();
            this.backup_month_check13 = new System.Windows.Forms.CheckBox();
            this.backup_month_check14 = new System.Windows.Forms.CheckBox();
            this.backup_month_check15 = new System.Windows.Forms.CheckBox();
            this.backup_month_check16 = new System.Windows.Forms.CheckBox();
            this.backup_month_check7 = new System.Windows.Forms.CheckBox();
            this.backup_month_check8 = new System.Windows.Forms.CheckBox();
            this.backup_month_check9 = new System.Windows.Forms.CheckBox();
            this.backup_month_check10 = new System.Windows.Forms.CheckBox();
            this.backup_month_check11 = new System.Windows.Forms.CheckBox();
            this.backup_month_check2 = new System.Windows.Forms.CheckBox();
            this.backup_month_check3 = new System.Windows.Forms.CheckBox();
            this.backup_month_check4 = new System.Windows.Forms.CheckBox();
            this.backup_month_check5 = new System.Windows.Forms.CheckBox();
            this.backup_month_check6 = new System.Windows.Forms.CheckBox();
            this.backup_month_check1 = new System.Windows.Forms.CheckBox();
            this.btn_backup_serviceUninstall = new System.Windows.Forms.Button();
            this.btn_backup_serviceStop = new System.Windows.Forms.Button();
            this.btn_backup_serviceStart = new System.Windows.Forms.Button();
            this.btn_backup_serviceInstall = new System.Windows.Forms.Button();
            this.btn_backup = new System.Windows.Forms.Button();
            this.tab_backup.SuspendLayout();
            this.type_day.SuspendLayout();
            this.type_week.SuspendLayout();
            this.type_month.SuspendLayout();
            this.SuspendLayout();
            // 
            // lab_backupServicesState
            // 
            this.lab_backupServicesState.AutoSize = true;
            this.lab_backupServicesState.Location = new System.Drawing.Point(212, 6);
            this.lab_backupServicesState.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lab_backupServicesState.Name = "lab_backupServicesState";
            this.lab_backupServicesState.Size = new System.Drawing.Size(41, 12);
            this.lab_backupServicesState.TabIndex = 30;
            this.lab_backupServicesState.Text = "未安装";
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Location = new System.Drawing.Point(140, 6);
            this.label48.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(65, 12);
            this.label48.TabIndex = 29;
            this.label48.Text = "服务状态：";
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Location = new System.Drawing.Point(8, 3);
            this.label47.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(77, 12);
            this.label47.TabIndex = 28;
            this.label47.Text = "自动备份设置";
            // 
            // tab_backup
            // 
            this.tab_backup.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.tab_backup.Controls.Add(this.type_day);
            this.tab_backup.Controls.Add(this.type_week);
            this.tab_backup.Controls.Add(this.type_month);
            this.tab_backup.Location = new System.Drawing.Point(5, 22);
            this.tab_backup.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tab_backup.Name = "tab_backup";
            this.tab_backup.SelectedIndex = 0;
            this.tab_backup.Size = new System.Drawing.Size(556, 112);
            this.tab_backup.TabIndex = 27;
            // 
            // type_day
            // 
            this.type_day.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.type_day.Controls.Add(this.backup_day_starttime);
            this.type_day.Controls.Add(this.label50);
            this.type_day.Location = new System.Drawing.Point(4, 25);
            this.type_day.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.type_day.Name = "type_day";
            this.type_day.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.type_day.Size = new System.Drawing.Size(548, 83);
            this.type_day.TabIndex = 0;
            this.type_day.Text = "每天";
            this.type_day.UseVisualStyleBackColor = true;
            // 
            // backup_day_starttime
            // 
            this.backup_day_starttime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.backup_day_starttime.Location = new System.Drawing.Point(212, 13);
            this.backup_day_starttime.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.backup_day_starttime.Name = "backup_day_starttime";
            this.backup_day_starttime.ShowUpDown = true;
            this.backup_day_starttime.Size = new System.Drawing.Size(151, 21);
            this.backup_day_starttime.TabIndex = 2;
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.Location = new System.Drawing.Point(133, 17);
            this.label50.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(77, 12);
            this.label50.TabIndex = 1;
            this.label50.Text = "开始执行时间";
            // 
            // type_week
            // 
            this.type_week.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.type_week.Controls.Add(this.backup_week_starttime);
            this.type_week.Controls.Add(this.label51);
            this.type_week.Controls.Add(this.backup_week_check7);
            this.type_week.Controls.Add(this.backup_week_check6);
            this.type_week.Controls.Add(this.backup_week_check5);
            this.type_week.Controls.Add(this.backup_week_check4);
            this.type_week.Controls.Add(this.backup_week_check3);
            this.type_week.Controls.Add(this.backup_week_check2);
            this.type_week.Controls.Add(this.backup_week_check1);
            this.type_week.Location = new System.Drawing.Point(4, 25);
            this.type_week.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.type_week.Name = "type_week";
            this.type_week.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.type_week.Size = new System.Drawing.Size(548, 83);
            this.type_week.TabIndex = 1;
            this.type_week.Text = "每周";
            this.type_week.UseVisualStyleBackColor = true;
            // 
            // backup_week_starttime
            // 
            this.backup_week_starttime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.backup_week_starttime.Location = new System.Drawing.Point(208, 29);
            this.backup_week_starttime.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.backup_week_starttime.Name = "backup_week_starttime";
            this.backup_week_starttime.ShowUpDown = true;
            this.backup_week_starttime.Size = new System.Drawing.Size(151, 21);
            this.backup_week_starttime.TabIndex = 8;
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.Location = new System.Drawing.Point(127, 33);
            this.label51.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(77, 12);
            this.label51.TabIndex = 7;
            this.label51.Text = "开始执行时间";
            // 
            // backup_week_check7
            // 
            this.backup_week_check7.AutoSize = true;
            this.backup_week_check7.Location = new System.Drawing.Point(435, 5);
            this.backup_week_check7.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.backup_week_check7.Name = "backup_week_check7";
            this.backup_week_check7.Size = new System.Drawing.Size(60, 16);
            this.backup_week_check7.TabIndex = 6;
            this.backup_week_check7.Text = "星期日";
            this.backup_week_check7.UseVisualStyleBackColor = true;
            // 
            // backup_week_check6
            // 
            this.backup_week_check6.AutoSize = true;
            this.backup_week_check6.Location = new System.Drawing.Point(364, 6);
            this.backup_week_check6.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.backup_week_check6.Name = "backup_week_check6";
            this.backup_week_check6.Size = new System.Drawing.Size(60, 16);
            this.backup_week_check6.TabIndex = 5;
            this.backup_week_check6.Text = "星期六";
            this.backup_week_check6.UseVisualStyleBackColor = true;
            // 
            // backup_week_check5
            // 
            this.backup_week_check5.AutoSize = true;
            this.backup_week_check5.Location = new System.Drawing.Point(294, 5);
            this.backup_week_check5.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.backup_week_check5.Name = "backup_week_check5";
            this.backup_week_check5.Size = new System.Drawing.Size(60, 16);
            this.backup_week_check5.TabIndex = 4;
            this.backup_week_check5.Text = "星期五";
            this.backup_week_check5.UseVisualStyleBackColor = true;
            // 
            // backup_week_check4
            // 
            this.backup_week_check4.AutoSize = true;
            this.backup_week_check4.Location = new System.Drawing.Point(224, 5);
            this.backup_week_check4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.backup_week_check4.Name = "backup_week_check4";
            this.backup_week_check4.Size = new System.Drawing.Size(60, 16);
            this.backup_week_check4.TabIndex = 3;
            this.backup_week_check4.Text = "星期四";
            this.backup_week_check4.UseVisualStyleBackColor = true;
            // 
            // backup_week_check3
            // 
            this.backup_week_check3.AutoSize = true;
            this.backup_week_check3.Location = new System.Drawing.Point(153, 6);
            this.backup_week_check3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.backup_week_check3.Name = "backup_week_check3";
            this.backup_week_check3.Size = new System.Drawing.Size(60, 16);
            this.backup_week_check3.TabIndex = 2;
            this.backup_week_check3.Text = "星期三";
            this.backup_week_check3.UseVisualStyleBackColor = true;
            // 
            // backup_week_check2
            // 
            this.backup_week_check2.AutoSize = true;
            this.backup_week_check2.Location = new System.Drawing.Point(82, 6);
            this.backup_week_check2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.backup_week_check2.Name = "backup_week_check2";
            this.backup_week_check2.Size = new System.Drawing.Size(60, 16);
            this.backup_week_check2.TabIndex = 1;
            this.backup_week_check2.Text = "星期二";
            this.backup_week_check2.UseVisualStyleBackColor = true;
            // 
            // backup_week_check1
            // 
            this.backup_week_check1.AutoSize = true;
            this.backup_week_check1.Location = new System.Drawing.Point(12, 6);
            this.backup_week_check1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.backup_week_check1.Name = "backup_week_check1";
            this.backup_week_check1.Size = new System.Drawing.Size(60, 16);
            this.backup_week_check1.TabIndex = 0;
            this.backup_week_check1.Text = "星期一";
            this.backup_week_check1.UseVisualStyleBackColor = true;
            // 
            // type_month
            // 
            this.type_month.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.type_month.Controls.Add(this.backup_month_starttime);
            this.type_month.Controls.Add(this.label52);
            this.type_month.Controls.Add(this.backup_month_check31);
            this.type_month.Controls.Add(this.backup_month_check30);
            this.type_month.Controls.Add(this.backup_month_check29);
            this.type_month.Controls.Add(this.backup_month_check28);
            this.type_month.Controls.Add(this.backup_month_check27);
            this.type_month.Controls.Add(this.backup_month_check26);
            this.type_month.Controls.Add(this.backup_month_check25);
            this.type_month.Controls.Add(this.backup_month_check24);
            this.type_month.Controls.Add(this.backup_month_check23);
            this.type_month.Controls.Add(this.backup_month_check22);
            this.type_month.Controls.Add(this.backup_month_check18);
            this.type_month.Controls.Add(this.backup_month_check17);
            this.type_month.Controls.Add(this.backup_month_check19);
            this.type_month.Controls.Add(this.backup_month_check20);
            this.type_month.Controls.Add(this.backup_month_check21);
            this.type_month.Controls.Add(this.backup_month_check12);
            this.type_month.Controls.Add(this.backup_month_check13);
            this.type_month.Controls.Add(this.backup_month_check14);
            this.type_month.Controls.Add(this.backup_month_check15);
            this.type_month.Controls.Add(this.backup_month_check16);
            this.type_month.Controls.Add(this.backup_month_check7);
            this.type_month.Controls.Add(this.backup_month_check8);
            this.type_month.Controls.Add(this.backup_month_check9);
            this.type_month.Controls.Add(this.backup_month_check10);
            this.type_month.Controls.Add(this.backup_month_check11);
            this.type_month.Controls.Add(this.backup_month_check2);
            this.type_month.Controls.Add(this.backup_month_check3);
            this.type_month.Controls.Add(this.backup_month_check4);
            this.type_month.Controls.Add(this.backup_month_check5);
            this.type_month.Controls.Add(this.backup_month_check6);
            this.type_month.Controls.Add(this.backup_month_check1);
            this.type_month.Location = new System.Drawing.Point(4, 25);
            this.type_month.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.type_month.Name = "type_month";
            this.type_month.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.type_month.Size = new System.Drawing.Size(548, 83);
            this.type_month.TabIndex = 2;
            this.type_month.Text = "每月";
            this.type_month.UseVisualStyleBackColor = true;
            // 
            // backup_month_starttime
            // 
            this.backup_month_starttime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.backup_month_starttime.Location = new System.Drawing.Point(194, 55);
            this.backup_month_starttime.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.backup_month_starttime.Name = "backup_month_starttime";
            this.backup_month_starttime.ShowUpDown = true;
            this.backup_month_starttime.Size = new System.Drawing.Size(151, 21);
            this.backup_month_starttime.TabIndex = 32;
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Location = new System.Drawing.Point(110, 60);
            this.label52.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(83, 12);
            this.label52.TabIndex = 31;
            this.label52.Text = "开始执行时间:";
            // 
            // backup_month_check31
            // 
            this.backup_month_check31.AutoSize = true;
            this.backup_month_check31.Location = new System.Drawing.Point(10, 46);
            this.backup_month_check31.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.backup_month_check31.Name = "backup_month_check31";
            this.backup_month_check31.Size = new System.Drawing.Size(36, 16);
            this.backup_month_check31.TabIndex = 30;
            this.backup_month_check31.Text = "31";
            this.backup_month_check31.UseVisualStyleBackColor = true;
            // 
            // backup_month_check30
            // 
            this.backup_month_check30.AutoSize = true;
            this.backup_month_check30.Location = new System.Drawing.Point(505, 25);
            this.backup_month_check30.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.backup_month_check30.Name = "backup_month_check30";
            this.backup_month_check30.Size = new System.Drawing.Size(36, 16);
            this.backup_month_check30.TabIndex = 29;
            this.backup_month_check30.Text = "30";
            this.backup_month_check30.UseVisualStyleBackColor = true;
            // 
            // backup_month_check29
            // 
            this.backup_month_check29.AutoSize = true;
            this.backup_month_check29.Location = new System.Drawing.Point(462, 25);
            this.backup_month_check29.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.backup_month_check29.Name = "backup_month_check29";
            this.backup_month_check29.Size = new System.Drawing.Size(36, 16);
            this.backup_month_check29.TabIndex = 28;
            this.backup_month_check29.Text = "29";
            this.backup_month_check29.UseVisualStyleBackColor = true;
            // 
            // backup_month_check28
            // 
            this.backup_month_check28.AutoSize = true;
            this.backup_month_check28.Location = new System.Drawing.Point(424, 25);
            this.backup_month_check28.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.backup_month_check28.Name = "backup_month_check28";
            this.backup_month_check28.Size = new System.Drawing.Size(36, 16);
            this.backup_month_check28.TabIndex = 27;
            this.backup_month_check28.Text = "28";
            this.backup_month_check28.UseVisualStyleBackColor = true;
            // 
            // backup_month_check27
            // 
            this.backup_month_check27.AutoSize = true;
            this.backup_month_check27.Location = new System.Drawing.Point(387, 26);
            this.backup_month_check27.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.backup_month_check27.Name = "backup_month_check27";
            this.backup_month_check27.Size = new System.Drawing.Size(36, 16);
            this.backup_month_check27.TabIndex = 26;
            this.backup_month_check27.Text = "27";
            this.backup_month_check27.UseVisualStyleBackColor = true;
            // 
            // backup_month_check26
            // 
            this.backup_month_check26.AutoSize = true;
            this.backup_month_check26.Location = new System.Drawing.Point(355, 25);
            this.backup_month_check26.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.backup_month_check26.Name = "backup_month_check26";
            this.backup_month_check26.Size = new System.Drawing.Size(36, 16);
            this.backup_month_check26.TabIndex = 25;
            this.backup_month_check26.Text = "26";
            this.backup_month_check26.UseVisualStyleBackColor = true;
            // 
            // backup_month_check25
            // 
            this.backup_month_check25.AutoSize = true;
            this.backup_month_check25.Location = new System.Drawing.Point(320, 26);
            this.backup_month_check25.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.backup_month_check25.Name = "backup_month_check25";
            this.backup_month_check25.Size = new System.Drawing.Size(36, 16);
            this.backup_month_check25.TabIndex = 24;
            this.backup_month_check25.Text = "25";
            this.backup_month_check25.UseVisualStyleBackColor = true;
            // 
            // backup_month_check24
            // 
            this.backup_month_check24.AutoSize = true;
            this.backup_month_check24.Location = new System.Drawing.Point(286, 25);
            this.backup_month_check24.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.backup_month_check24.Name = "backup_month_check24";
            this.backup_month_check24.Size = new System.Drawing.Size(36, 16);
            this.backup_month_check24.TabIndex = 23;
            this.backup_month_check24.Text = "24";
            this.backup_month_check24.UseVisualStyleBackColor = true;
            // 
            // backup_month_check23
            // 
            this.backup_month_check23.AutoSize = true;
            this.backup_month_check23.Location = new System.Drawing.Point(251, 26);
            this.backup_month_check23.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.backup_month_check23.Name = "backup_month_check23";
            this.backup_month_check23.Size = new System.Drawing.Size(36, 16);
            this.backup_month_check23.TabIndex = 22;
            this.backup_month_check23.Text = "23";
            this.backup_month_check23.UseVisualStyleBackColor = true;
            // 
            // backup_month_check22
            // 
            this.backup_month_check22.AutoSize = true;
            this.backup_month_check22.Location = new System.Drawing.Point(217, 25);
            this.backup_month_check22.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.backup_month_check22.Name = "backup_month_check22";
            this.backup_month_check22.Size = new System.Drawing.Size(36, 16);
            this.backup_month_check22.TabIndex = 21;
            this.backup_month_check22.Text = "22";
            this.backup_month_check22.UseVisualStyleBackColor = true;
            // 
            // backup_month_check18
            // 
            this.backup_month_check18.AutoSize = true;
            this.backup_month_check18.Location = new System.Drawing.Point(79, 26);
            this.backup_month_check18.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.backup_month_check18.Name = "backup_month_check18";
            this.backup_month_check18.Size = new System.Drawing.Size(36, 16);
            this.backup_month_check18.TabIndex = 20;
            this.backup_month_check18.Text = "18";
            this.backup_month_check18.UseVisualStyleBackColor = true;
            // 
            // backup_month_check17
            // 
            this.backup_month_check17.AutoSize = true;
            this.backup_month_check17.Location = new System.Drawing.Point(45, 26);
            this.backup_month_check17.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.backup_month_check17.Name = "backup_month_check17";
            this.backup_month_check17.Size = new System.Drawing.Size(36, 16);
            this.backup_month_check17.TabIndex = 19;
            this.backup_month_check17.Text = "17";
            this.backup_month_check17.UseVisualStyleBackColor = true;
            // 
            // backup_month_check19
            // 
            this.backup_month_check19.AutoSize = true;
            this.backup_month_check19.Location = new System.Drawing.Point(113, 26);
            this.backup_month_check19.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.backup_month_check19.Name = "backup_month_check19";
            this.backup_month_check19.Size = new System.Drawing.Size(36, 16);
            this.backup_month_check19.TabIndex = 18;
            this.backup_month_check19.Text = "19";
            this.backup_month_check19.UseVisualStyleBackColor = true;
            // 
            // backup_month_check20
            // 
            this.backup_month_check20.AutoSize = true;
            this.backup_month_check20.Location = new System.Drawing.Point(148, 26);
            this.backup_month_check20.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.backup_month_check20.Name = "backup_month_check20";
            this.backup_month_check20.Size = new System.Drawing.Size(36, 16);
            this.backup_month_check20.TabIndex = 17;
            this.backup_month_check20.Text = "20";
            this.backup_month_check20.UseVisualStyleBackColor = true;
            // 
            // backup_month_check21
            // 
            this.backup_month_check21.AutoSize = true;
            this.backup_month_check21.Location = new System.Drawing.Point(182, 26);
            this.backup_month_check21.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.backup_month_check21.Name = "backup_month_check21";
            this.backup_month_check21.Size = new System.Drawing.Size(36, 16);
            this.backup_month_check21.TabIndex = 16;
            this.backup_month_check21.Text = "21";
            this.backup_month_check21.UseVisualStyleBackColor = true;
            // 
            // backup_month_check12
            // 
            this.backup_month_check12.AutoSize = true;
            this.backup_month_check12.Location = new System.Drawing.Point(386, 6);
            this.backup_month_check12.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.backup_month_check12.Name = "backup_month_check12";
            this.backup_month_check12.Size = new System.Drawing.Size(36, 16);
            this.backup_month_check12.TabIndex = 15;
            this.backup_month_check12.Text = "12";
            this.backup_month_check12.UseVisualStyleBackColor = true;
            // 
            // backup_month_check13
            // 
            this.backup_month_check13.AutoSize = true;
            this.backup_month_check13.Location = new System.Drawing.Point(423, 6);
            this.backup_month_check13.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.backup_month_check13.Name = "backup_month_check13";
            this.backup_month_check13.Size = new System.Drawing.Size(36, 16);
            this.backup_month_check13.TabIndex = 14;
            this.backup_month_check13.Text = "13";
            this.backup_month_check13.UseVisualStyleBackColor = true;
            // 
            // backup_month_check14
            // 
            this.backup_month_check14.AutoSize = true;
            this.backup_month_check14.Location = new System.Drawing.Point(462, 6);
            this.backup_month_check14.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.backup_month_check14.Name = "backup_month_check14";
            this.backup_month_check14.Size = new System.Drawing.Size(36, 16);
            this.backup_month_check14.TabIndex = 13;
            this.backup_month_check14.Text = "14";
            this.backup_month_check14.UseVisualStyleBackColor = true;
            // 
            // backup_month_check15
            // 
            this.backup_month_check15.AutoSize = true;
            this.backup_month_check15.Location = new System.Drawing.Point(503, 5);
            this.backup_month_check15.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.backup_month_check15.Name = "backup_month_check15";
            this.backup_month_check15.Size = new System.Drawing.Size(36, 16);
            this.backup_month_check15.TabIndex = 12;
            this.backup_month_check15.Text = "15";
            this.backup_month_check15.UseVisualStyleBackColor = true;
            // 
            // backup_month_check16
            // 
            this.backup_month_check16.AutoSize = true;
            this.backup_month_check16.Location = new System.Drawing.Point(10, 26);
            this.backup_month_check16.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.backup_month_check16.Name = "backup_month_check16";
            this.backup_month_check16.Size = new System.Drawing.Size(36, 16);
            this.backup_month_check16.TabIndex = 11;
            this.backup_month_check16.Text = "16";
            this.backup_month_check16.UseVisualStyleBackColor = true;
            // 
            // backup_month_check7
            // 
            this.backup_month_check7.AutoSize = true;
            this.backup_month_check7.Location = new System.Drawing.Point(215, 5);
            this.backup_month_check7.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.backup_month_check7.Name = "backup_month_check7";
            this.backup_month_check7.Size = new System.Drawing.Size(30, 16);
            this.backup_month_check7.TabIndex = 10;
            this.backup_month_check7.Text = "7";
            this.backup_month_check7.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.backup_month_check7.UseVisualStyleBackColor = true;
            // 
            // backup_month_check8
            // 
            this.backup_month_check8.AutoSize = true;
            this.backup_month_check8.Location = new System.Drawing.Point(249, 6);
            this.backup_month_check8.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.backup_month_check8.Name = "backup_month_check8";
            this.backup_month_check8.Size = new System.Drawing.Size(30, 16);
            this.backup_month_check8.TabIndex = 9;
            this.backup_month_check8.Text = "8";
            this.backup_month_check8.UseVisualStyleBackColor = true;
            // 
            // backup_month_check9
            // 
            this.backup_month_check9.AutoSize = true;
            this.backup_month_check9.Location = new System.Drawing.Point(284, 6);
            this.backup_month_check9.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.backup_month_check9.Name = "backup_month_check9";
            this.backup_month_check9.Size = new System.Drawing.Size(30, 16);
            this.backup_month_check9.TabIndex = 8;
            this.backup_month_check9.Text = "9";
            this.backup_month_check9.UseVisualStyleBackColor = true;
            // 
            // backup_month_check10
            // 
            this.backup_month_check10.AutoSize = true;
            this.backup_month_check10.Location = new System.Drawing.Point(318, 6);
            this.backup_month_check10.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.backup_month_check10.Name = "backup_month_check10";
            this.backup_month_check10.Size = new System.Drawing.Size(36, 16);
            this.backup_month_check10.TabIndex = 7;
            this.backup_month_check10.Text = "10";
            this.backup_month_check10.UseVisualStyleBackColor = true;
            // 
            // backup_month_check11
            // 
            this.backup_month_check11.AutoSize = true;
            this.backup_month_check11.Location = new System.Drawing.Point(352, 6);
            this.backup_month_check11.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.backup_month_check11.Name = "backup_month_check11";
            this.backup_month_check11.Size = new System.Drawing.Size(36, 16);
            this.backup_month_check11.TabIndex = 6;
            this.backup_month_check11.Text = "11";
            this.backup_month_check11.UseVisualStyleBackColor = true;
            // 
            // backup_month_check2
            // 
            this.backup_month_check2.AutoSize = true;
            this.backup_month_check2.Location = new System.Drawing.Point(46, 6);
            this.backup_month_check2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.backup_month_check2.Name = "backup_month_check2";
            this.backup_month_check2.Size = new System.Drawing.Size(30, 16);
            this.backup_month_check2.TabIndex = 5;
            this.backup_month_check2.Text = "2";
            this.backup_month_check2.UseVisualStyleBackColor = true;
            // 
            // backup_month_check3
            // 
            this.backup_month_check3.AutoSize = true;
            this.backup_month_check3.Location = new System.Drawing.Point(79, 6);
            this.backup_month_check3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.backup_month_check3.Name = "backup_month_check3";
            this.backup_month_check3.Size = new System.Drawing.Size(30, 16);
            this.backup_month_check3.TabIndex = 4;
            this.backup_month_check3.Text = "3";
            this.backup_month_check3.UseVisualStyleBackColor = true;
            // 
            // backup_month_check4
            // 
            this.backup_month_check4.AutoSize = true;
            this.backup_month_check4.Location = new System.Drawing.Point(112, 5);
            this.backup_month_check4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.backup_month_check4.Name = "backup_month_check4";
            this.backup_month_check4.Size = new System.Drawing.Size(30, 16);
            this.backup_month_check4.TabIndex = 3;
            this.backup_month_check4.Text = "4";
            this.backup_month_check4.UseVisualStyleBackColor = true;
            // 
            // backup_month_check5
            // 
            this.backup_month_check5.AutoSize = true;
            this.backup_month_check5.Location = new System.Drawing.Point(147, 6);
            this.backup_month_check5.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.backup_month_check5.Name = "backup_month_check5";
            this.backup_month_check5.Size = new System.Drawing.Size(30, 16);
            this.backup_month_check5.TabIndex = 2;
            this.backup_month_check5.Text = "5";
            this.backup_month_check5.UseVisualStyleBackColor = true;
            // 
            // backup_month_check6
            // 
            this.backup_month_check6.AutoSize = true;
            this.backup_month_check6.Location = new System.Drawing.Point(181, 6);
            this.backup_month_check6.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.backup_month_check6.Name = "backup_month_check6";
            this.backup_month_check6.Size = new System.Drawing.Size(30, 16);
            this.backup_month_check6.TabIndex = 1;
            this.backup_month_check6.Text = "6";
            this.backup_month_check6.UseVisualStyleBackColor = true;
            // 
            // backup_month_check1
            // 
            this.backup_month_check1.AutoSize = true;
            this.backup_month_check1.Location = new System.Drawing.Point(10, 6);
            this.backup_month_check1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.backup_month_check1.Name = "backup_month_check1";
            this.backup_month_check1.Size = new System.Drawing.Size(30, 16);
            this.backup_month_check1.TabIndex = 0;
            this.backup_month_check1.Text = "1";
            this.backup_month_check1.UseVisualStyleBackColor = true;
            // 
            // btn_backup_serviceUninstall
            // 
            this.btn_backup_serviceUninstall.BackColor = System.Drawing.Color.AliceBlue;
            this.btn_backup_serviceUninstall.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_backup_serviceUninstall.Location = new System.Drawing.Point(236, 140);
            this.btn_backup_serviceUninstall.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_backup_serviceUninstall.Name = "btn_backup_serviceUninstall";
            this.btn_backup_serviceUninstall.Size = new System.Drawing.Size(56, 21);
            this.btn_backup_serviceUninstall.TabIndex = 34;
            this.btn_backup_serviceUninstall.Text = "卸载";
            this.btn_backup_serviceUninstall.UseVisualStyleBackColor = false;
            this.btn_backup_serviceUninstall.Click += new System.EventHandler(this.btn_backup_serviceUninstall_Click);
            // 
            // btn_backup_serviceStop
            // 
            this.btn_backup_serviceStop.BackColor = System.Drawing.Color.AliceBlue;
            this.btn_backup_serviceStop.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_backup_serviceStop.Location = new System.Drawing.Point(159, 140);
            this.btn_backup_serviceStop.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_backup_serviceStop.Name = "btn_backup_serviceStop";
            this.btn_backup_serviceStop.Size = new System.Drawing.Size(56, 21);
            this.btn_backup_serviceStop.TabIndex = 33;
            this.btn_backup_serviceStop.Text = "停止";
            this.btn_backup_serviceStop.UseVisualStyleBackColor = false;
            this.btn_backup_serviceStop.Click += new System.EventHandler(this.btn_backup_serviceStop_Click);
            // 
            // btn_backup_serviceStart
            // 
            this.btn_backup_serviceStart.BackColor = System.Drawing.Color.AliceBlue;
            this.btn_backup_serviceStart.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_backup_serviceStart.Location = new System.Drawing.Point(87, 140);
            this.btn_backup_serviceStart.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_backup_serviceStart.Name = "btn_backup_serviceStart";
            this.btn_backup_serviceStart.Size = new System.Drawing.Size(56, 21);
            this.btn_backup_serviceStart.TabIndex = 32;
            this.btn_backup_serviceStart.Text = "启动";
            this.btn_backup_serviceStart.UseVisualStyleBackColor = false;
            this.btn_backup_serviceStart.Click += new System.EventHandler(this.btn_backup_serviceStart_Click);
            // 
            // btn_backup_serviceInstall
            // 
            this.btn_backup_serviceInstall.BackColor = System.Drawing.Color.AliceBlue;
            this.btn_backup_serviceInstall.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_backup_serviceInstall.Location = new System.Drawing.Point(8, 139);
            this.btn_backup_serviceInstall.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_backup_serviceInstall.Name = "btn_backup_serviceInstall";
            this.btn_backup_serviceInstall.Size = new System.Drawing.Size(56, 21);
            this.btn_backup_serviceInstall.TabIndex = 31;
            this.btn_backup_serviceInstall.Text = "安装";
            this.btn_backup_serviceInstall.UseVisualStyleBackColor = false;
            this.btn_backup_serviceInstall.Click += new System.EventHandler(this.btn_backup_serviceInstall_Click);
            // 
            // btn_backup
            // 
            this.btn_backup.BackColor = System.Drawing.Color.AliceBlue;
            this.btn_backup.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_backup.Location = new System.Drawing.Point(485, 138);
            this.btn_backup.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_backup.Name = "btn_backup";
            this.btn_backup.Size = new System.Drawing.Size(66, 21);
            this.btn_backup.TabIndex = 35;
            this.btn_backup.Text = "手动备份";
            this.btn_backup.UseVisualStyleBackColor = false;
            this.btn_backup.Click += new System.EventHandler(this.btn_backup_Click);
            // 
            // backupSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.btn_backup);
            this.Controls.Add(this.btn_backup_serviceUninstall);
            this.Controls.Add(this.btn_backup_serviceStop);
            this.Controls.Add(this.btn_backup_serviceStart);
            this.Controls.Add(this.btn_backup_serviceInstall);
            this.Controls.Add(this.lab_backupServicesState);
            this.Controls.Add(this.label48);
            this.Controls.Add(this.label47);
            this.Controls.Add(this.tab_backup);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "backupSet";
            this.Size = new System.Drawing.Size(570, 165);
            this.tab_backup.ResumeLayout(false);
            this.type_day.ResumeLayout(false);
            this.type_day.PerformLayout();
            this.type_week.ResumeLayout(false);
            this.type_week.PerformLayout();
            this.type_month.ResumeLayout(false);
            this.type_month.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lab_backupServicesState;
        private System.Windows.Forms.Label label48;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.TabControl tab_backup;
        private System.Windows.Forms.TabPage type_day;
        private System.Windows.Forms.DateTimePicker backup_day_starttime;
        private System.Windows.Forms.Label label50;
        private System.Windows.Forms.TabPage type_week;
        private System.Windows.Forms.DateTimePicker backup_week_starttime;
        private System.Windows.Forms.Label label51;
        private System.Windows.Forms.CheckBox backup_week_check7;
        private System.Windows.Forms.CheckBox backup_week_check6;
        private System.Windows.Forms.CheckBox backup_week_check5;
        private System.Windows.Forms.CheckBox backup_week_check4;
        private System.Windows.Forms.CheckBox backup_week_check3;
        private System.Windows.Forms.CheckBox backup_week_check2;
        private System.Windows.Forms.CheckBox backup_week_check1;
        private System.Windows.Forms.TabPage type_month;
        private System.Windows.Forms.DateTimePicker backup_month_starttime;
        private System.Windows.Forms.Label label52;
        private System.Windows.Forms.CheckBox backup_month_check31;
        private System.Windows.Forms.CheckBox backup_month_check30;
        private System.Windows.Forms.CheckBox backup_month_check29;
        private System.Windows.Forms.CheckBox backup_month_check28;
        private System.Windows.Forms.CheckBox backup_month_check27;
        private System.Windows.Forms.CheckBox backup_month_check26;
        private System.Windows.Forms.CheckBox backup_month_check25;
        private System.Windows.Forms.CheckBox backup_month_check24;
        private System.Windows.Forms.CheckBox backup_month_check23;
        private System.Windows.Forms.CheckBox backup_month_check22;
        private System.Windows.Forms.CheckBox backup_month_check18;
        private System.Windows.Forms.CheckBox backup_month_check17;
        private System.Windows.Forms.CheckBox backup_month_check19;
        private System.Windows.Forms.CheckBox backup_month_check20;
        private System.Windows.Forms.CheckBox backup_month_check21;
        private System.Windows.Forms.CheckBox backup_month_check12;
        private System.Windows.Forms.CheckBox backup_month_check13;
        private System.Windows.Forms.CheckBox backup_month_check14;
        private System.Windows.Forms.CheckBox backup_month_check15;
        private System.Windows.Forms.CheckBox backup_month_check16;
        private System.Windows.Forms.CheckBox backup_month_check7;
        private System.Windows.Forms.CheckBox backup_month_check8;
        private System.Windows.Forms.CheckBox backup_month_check9;
        private System.Windows.Forms.CheckBox backup_month_check10;
        private System.Windows.Forms.CheckBox backup_month_check11;
        private System.Windows.Forms.CheckBox backup_month_check2;
        private System.Windows.Forms.CheckBox backup_month_check3;
        private System.Windows.Forms.CheckBox backup_month_check4;
        private System.Windows.Forms.CheckBox backup_month_check5;
        private System.Windows.Forms.CheckBox backup_month_check6;
        private System.Windows.Forms.CheckBox backup_month_check1;
        private System.Windows.Forms.Button btn_backup_serviceUninstall;
        private System.Windows.Forms.Button btn_backup_serviceStop;
        private System.Windows.Forms.Button btn_backup_serviceStart;
        private System.Windows.Forms.Button btn_backup_serviceInstall;
        private System.Windows.Forms.Button btn_backup;
    }
}
