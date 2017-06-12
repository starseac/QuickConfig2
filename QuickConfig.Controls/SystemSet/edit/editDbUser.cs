using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuickConfig.Model.app;
using QuickConfig.Model.db;

namespace QuickConfig.Controls.SystemSet
{
    public partial class editDbUser : UserControl
    {
        public editDbUser()
        {
            InitializeComponent();
        }

        public void setValue(DbUser dbuser)
        {
            this.txt_name.Text = dbuser.Name;
            this.txt_label.Text = dbuser.Label;
            this.txt_tablespace.Text = dbuser.Tablespace;
            this.txt_user.Text = dbuser.User;
            this.txt_password.Text = dbuser.Password;
            this.txt_dmpfile.Text = dbuser.Dmpfile;
            this.txt_relativepath.Text = dbuser.Relativepath;

        }


        public bool isNew;

        public Object getValue()
        {
            DbUser dbuser = new DbUser();
            dbuser.Name = this.txt_name.Text;
            dbuser.Label = this.txt_label.Text;
            dbuser.Tablespace = this.txt_tablespace.Text;
            dbuser.User = this.txt_user.Text;
            dbuser.Password = this.txt_password.Text;
            dbuser.Dmpfile = this.txt_dmpfile.Text;
            dbuser.Relativepath = this.txt_relativepath.Text;
            return dbuser;

        }
    }
}
