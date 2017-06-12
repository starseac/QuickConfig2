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
    public partial class editFtp : UserControl
    {
        public editFtp()
        {
            InitializeComponent();
        }

        public void setValue(Ftp ftp)
        {
            this.txt_name.Text = ftp.Name;
            this.txt_label.Text = ftp.Label;
            this.txt_path.Text = ftp.Path;
            this.txt_relativepath.Text = ftp.Relativepath;
            this.txt_ip.Text = ftp.Ip;
            this.txt_user.Text = ftp.User;
            this.txt_password.Text = ftp.Password;

        }

        public bool isNew;

        public Object getValue()
        {
            Ftp ftp = new Ftp();
            ftp.Name = this.txt_name.Text;
            ftp.Label = this.txt_label.Text;
            ftp.Path = this.txt_path.Text;
            ftp.Relativepath = this.txt_relativepath.Text;
            ftp.Ip = this.txt_ip.Text;
            ftp.User = this.txt_user.Text;
            ftp.Password = this.txt_password.Text;

            return ftp;


        }
    }
}
