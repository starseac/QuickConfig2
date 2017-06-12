using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuickConfig.Model.app;

namespace QuickConfig.Controls.SystemSet
{
    public partial class editApps : UserControl
    {
        public editApps()
        {
            InitializeComponent();
        }

        public void setValue(Apps apps){
            this.txt_name.Text=apps.Name;
            this.txt_label.Text=apps.Label;
            this.txt_path.Text=apps.Path;
        
        }

        public bool isNew;

        public Object getValue() {
            Apps apps = new Apps();
            apps.Name = this.txt_name.Text;
            apps.Label = this.txt_label.Text;
            apps.Path = this.txt_path.Text;
            return apps;
        
        }
    }
}
