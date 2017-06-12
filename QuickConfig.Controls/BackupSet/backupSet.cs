using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuickConfig.Model.backup;
using QuickConfig.Common;
using System.ServiceProcess;
using QuickConfig.Model;

namespace QuickConfig.Controls.BackupSet
{
    public partial class backupSet : UserControl
    {
        public backupSet()
        {
            InitializeComponent();
        }


        public string Type
        {
            get { return this.tab_backup.SelectedTab.Text; }
            set { setBackupType(value); }
        }

        public string Type_daytime
        {
            get { return this.backup_day_starttime.Value.ToString("HH:mm:ss"); }
            set { this.backup_day_starttime.Text = value; }
        }

        public string Type_week
        {
            get { return getWeekStr(); }
            set { setWeekStr(value); }
        }


        public string Type_weektime
        {
            get { return this.backup_week_starttime.Value.ToString("HH:mm:ss"); }
            set { this.backup_week_starttime.Text = value; }
        }

        public string Type_month
        {
            get { return getMonthStr(); }
            set { setMonthStr(value); }
        }

        public string Type_monthtime
        {
            get { return this.backup_month_starttime.Value.ToString("HH:mm:ss"); }
            set { this.backup_month_starttime.Text = value; }
        }

        public string ConfigName;


        private string getWeekStr()
        {

            string chooseWeekStr = "";
            foreach (Control cb in tab_backup.TabPages[1].Controls)
            {
                if (cb is CheckBox)
                {
                    if ((cb as CheckBox).Checked == true)
                    {
                        if (chooseWeekStr == "")
                        {
                            chooseWeekStr = cb.Text;
                        }
                        else
                        {
                            chooseWeekStr += "," + cb.Text;
                        }
                    }
                }
            }

            return chooseWeekStr;
        }

        private string getMonthStr()
        {
            string chooseMonthStr = "";
            foreach (Control cb in tab_backup.TabPages[2].Controls)
            {
                if (cb is CheckBox)
                {
                    if ((cb as CheckBox).Checked == true)
                    {
                        if (chooseMonthStr == "")
                        {
                            chooseMonthStr = cb.Text;
                        }
                        else
                        {
                            chooseMonthStr += "," + cb.Text;
                        }
                    }
                }
            }
            return chooseMonthStr;
        }



        private void setBackupType(string backupType)
        {

            if (backupType != "")
            {
                if (backupType == "每天")
                {
                    this.tab_backup.SelectedIndex = 0;
                }
                else if (backupType == "每周")
                {
                    this.tab_backup.SelectedIndex = 1;
                }
                else
                {
                    this.tab_backup.SelectedIndex = 2;
                }

            }
            else
            {
                this.tab_backup.SelectedIndex = 0;
            }
        }


        private void setWeekStr(string chooseWeekStr)
        {
            foreach (Control cb in tab_backup.TabPages[1].Controls)
            {
                if (cb is CheckBox && chooseWeekStr.Contains(cb.Text))
                {
                    (cb as CheckBox).Checked = true;
                }
            }

        }

        private void setMonthStr(string chooseMonthStr)
        {
            foreach (Control cb in tab_backup.TabPages[2].Controls)
            {
                if (cb is CheckBox)
                {
                    if ((chooseMonthStr.Contains(cb.Text) && chooseMonthStr == cb.Text) || (chooseMonthStr.Contains(cb.Text + ",")) || (chooseMonthStr.Contains("," + cb.Text + ",")) || (chooseMonthStr.Contains("," + cb.Text)))
                    {
                        (cb as CheckBox).Checked = true;
                    }
                }
            }

        }

        public void SetValue(Backup backup)
        {
            this.Type = backup.Type;
            this.Type_daytime = backup.Type_daytime;
            this.Type_week = backup.Type_week;
            this.Type_weektime = backup.Type_weektime;
            this.Type_month = backup.Type_month;
            this.Type_monthtime = backup.Type_monthtime;

        }


        private void btn_backup_serviceInstall_Click(object sender, EventArgs e)
        {

            setBAT.ServiceInstall(Common.getToolsFolder(), Common.getToolsTempFolder(), "自动备份", "QuickConfig_AutoBackup", Common.getServicesFolder() + "\\AutoBackup.exe", true);

            this.lab_backupServicesState.Text = Common.getServiceState("QuickConfig_AutoBackup");
        }

        private void btn_backup_serviceStart_Click(object sender, EventArgs e)
        {
            setBAT.ServiceRun(Common.getToolsFolder(), Common.getToolsTempFolder(), "自动备份", "QuickConfig_AutoBackup", true);

            this.lab_backupServicesState.Text = Common.getServiceState("QuickConfig_AutoBackup");
        }

        private void btn_backup_serviceStop_Click(object sender, EventArgs e)
        {
            setBAT.ServiceStop(Common.getToolsFolder(), Common.getToolsTempFolder(), "自动备份", "QuickConfig_AutoBackup", true);

            this.lab_backupServicesState.Text = Common.getServiceState("QuickConfig_AutoBackup");
        }

        private void btn_backup_serviceUninstall_Click(object sender, EventArgs e)
        {
            setBAT.ServiceRemove(Common.getToolsFolder(), Common.getToolsTempFolder(), "自动备份", Common.getServicesFolder() + "\\AutoBackup.exe", true);
            this.lab_backupServicesState.Text = Common.getServiceState("QuickConfig_AutoBackup");
        }

        private void btn_backup_Click(object sender, EventArgs e)
        {

            //先保存备份内容设置
            // saveBackupContent();

            Set set = QuickConfig.Common.setXml.getConfig(ConfigName);

            setBackup setbackup = new setBackup();

            setbackup.backup(set, Common.getToolsFolder(), Common.getToolsTempFolder());
            //打开备份目录
            setbackup.openFolderAndLog();

        }

    }



}
