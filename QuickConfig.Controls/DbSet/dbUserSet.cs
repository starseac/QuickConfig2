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
    public partial class dbUserSet : UserControl
    {
        public dbUserSet()
        {
            InitializeComponent();
        }

        private string _name;

        public string Name
        {
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

        public void SetValue(DbUser dbuser)
        {
            this._name = dbuser.Name;
            this.label.Text = dbuser.Label;
            this.tablespace.Text = dbuser.Tablespace;
            this.user.Text = dbuser.User;
            this.password.Text = dbuser.Password;
        }
    }
}
