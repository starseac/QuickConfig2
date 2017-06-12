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
    public partial class dbSystemuserSet : UserControl
    {
        public dbSystemuserSet()
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

        public void SetValue(DbSystemUser dbsystemuser)
        {
            this._name = dbsystemuser.Name;
            this.label.Text = dbsystemuser.Label;
            this.user.Text = dbsystemuser.User;
            this.password.Text = dbsystemuser.Password;
        }
    }
}
