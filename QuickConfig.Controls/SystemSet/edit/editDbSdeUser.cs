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
    public partial class editDbSdeUser : UserControl
    {
        public editDbSdeUser()
        {
            InitializeComponent();
        }

        public void setValue(DbSdeUser dbsdeuser)
        {
            this.txt_name.Text = dbsdeuser.Name;
            this.txt_label.Text = dbsdeuser.Label;
            this.txt_tablespace.Text = dbsdeuser.Tablespace;
            this.txt_user.Text = dbsdeuser.User;
            this.txt_password.Text = dbsdeuser.Password;
            this.txt_gdbpath.Text = dbsdeuser.Gdbfile;
            this.txt_relativepath.Text = dbsdeuser.Relativepath;

        }

        public bool isNew;

        public Object getValue()
        {
            DbSdeUser dbsdeuser = new DbSdeUser();
            dbsdeuser.Name = this.txt_name.Text;
            dbsdeuser.Label = this.txt_label.Text;
            dbsdeuser.Tablespace = this.txt_tablespace.Text;
            dbsdeuser.User = this.txt_user.Text;
            dbsdeuser.Password = this.txt_password.Text;
            dbsdeuser.Gdbfile = this.txt_gdbpath.Text;
            dbsdeuser.Relativepath = this.txt_relativepath.Text;

            return dbsdeuser;


        }
    }
}
