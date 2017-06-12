using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuickConfig.Model.db;

namespace QuickConfig.Controls.DbSet
{
    public partial class dbSdeUserSet : UserControl
    {
        public dbSdeUserSet()
        {
            InitializeComponent();
        }
        private string _name;

        public string Name {
            get { return _name; }

            set { _name = value; }
        }

        public string Label
        {
            get { return this.label.Text; }

            set { this.label.Text = value; }
        }

        public string Tablespace
        {
            get { return this.tablespace.Text; }

            set { this.tablespace.Text = value; }
        }

        public string User
        {
            get { return this.user.Text; }

            set { this.user.Text = value; }
        }

        public string Password
        {
            get { return this.password.Text; }

            set { this.password.Text = value; }
        }

        public void SetValue(DbSdeUser dbsdeuser) {
            this._name = dbsdeuser.Name;
            this.label.Text = dbsdeuser.Label;
            this.tablespace.Text = dbsdeuser.Tablespace;
            this.user.Text = dbsdeuser.User;
            this.password.Text = dbsdeuser.Password;
        }

    }
}
