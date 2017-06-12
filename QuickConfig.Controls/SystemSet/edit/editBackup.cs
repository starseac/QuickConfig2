using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuickConfig.Model.app;
using QuickConfig.Model.backup;

namespace QuickConfig.Controls.SystemSet
{
    public partial class editBackup : UserControl
    {
        public editBackup()
        {
            InitializeComponent();
        }

        public void setValue(Backup Backup) {
            this.txt_name.Text = Backup.Name;
            this.txt_label.Text = Backup.Label;
            this.txt_path.Text = Backup.Path;
            this.txt_content.Text = Backup.Content;
            this.txt_type.Text = Backup.Type;
            this.txt_type_daytime.Text = Backup.Type_daytime;
            this.txt_type_week.Text = Backup.Type_week;
            this.txt_type_weektime.Text = Backup.Type_weektime;
            this.txt_type_month.Text = Backup.Type_month;
            this.txt_type_monthtime.Text = Backup.Type_monthtime;        
        
        }

        public bool isNew;

        public Object getValue(){
            Backup backup = new Backup();
            backup.Name = this.txt_name.Text;
            backup.Label = this.txt_label.Text;
            backup.Path = this.txt_path.Text;
            backup.Content = this.txt_content.Text;
            backup.Type = this.txt_type.Text;
            backup.Type_daytime = this.txt_type_daytime.Text;
            backup.Type_week = this.txt_type_week.Text;
            backup.Type_weektime = this.txt_type_weektime.Text;
            backup.Type_month = this.txt_type_month.Text;
            backup.Type_monthtime = this.txt_type_monthtime.Text;

            return backup;
        }
    }
}
