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
    public partial class editGxml : UserControl
    {
        public editGxml()
        {
            InitializeComponent();
        }

        public void setValue(Gxml gxml)
        {
            this.txt_name.Text = gxml.Name;
            this.txt_label.Text = gxml.Label;
            this.txt_path.Text = gxml.Path;
            this.txt_relativepath.Text = gxml.Relativepath;
            this.txt_ip.Text = gxml.Ip;
            this.txt_user.Text = gxml.User;
            this.txt_password.Text = gxml.Password;

        }

        public bool isNew;

        public Object getValue()
        {
            Gxml gxml = new Gxml();

            gxml.Name = this.txt_name.Text;
            gxml.Label = this.txt_label.Text;
            gxml.Path = this.txt_path.Text;
            gxml.Relativepath = this.txt_relativepath.Text;
            gxml.Ip = this.txt_ip.Text;
            gxml.User = this.txt_user.Text;
            gxml.Password = this.txt_password.Text;
            return gxml;

        }
    }
}
