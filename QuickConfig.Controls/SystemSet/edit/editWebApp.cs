using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuickConfig.Model.app;
using QuickConfig.Controls.SystemSet.edit;

namespace QuickConfig.Controls.SystemSet
{
    public partial class editWebApp : UserControl
    {
        public editWebApp()
        {
            InitializeComponent();
        }

        public void setValue(WebApp webapp)
        {
            this.txt_name.Text = webapp.Name;
            this.txt_label.Text = webapp.Label;
            this.txt_path.Text = webapp.Path;
            this.txt_relativepath.Text = webapp.Relativepath;
            this.txt_ip.Text = webapp.Ip;
            this.txt_port.Text = webapp.Port;
            this.txt_configfolder.Text = webapp.ConfigFolder;
            this.txt_sitename.Text = webapp.SiteName;
            this.txt_x86bit.Checked = webapp.X86bit;

        }

        public bool isNew;

        public Object getValue()
        {
            WebApp webapp = new WebApp();

            webapp.Name = this.txt_name.Text;
            webapp.Label = this.txt_label.Text;
            webapp.Path = this.txt_path.Text;
            webapp.Relativepath = this.txt_relativepath.Text;
            webapp.Ip = this.txt_ip.Text;
            webapp.Port = this.txt_port.Text;
            webapp.ConfigFolder = this.txt_configfolder.Text;
            webapp.SiteName = this.txt_sitename.Text;
            webapp.X86bit = this.txt_x86bit.Checked;

            return webapp;

        }
    }
}
