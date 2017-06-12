using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuickConfig.Model.db;

namespace QuickConfig.Controls.DbInit
{
    public partial class gdbChoose : UserControl
    {
        public gdbChoose()
        {
            InitializeComponent();
        }

        private string _mainFolder;

        public string MainFolder
        {
            get { return _mainFolder; }
            set { _mainFolder = value; }
        }

        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Label
        {
            get { return this.gdb_label.Text; }
            set { this.gdb_label.Text = value; }
        }


        private string _user;

        public string User
        {
            get { return _user; }
            set { _user = value; }
        }

        private string _password;

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public string FolderPath
        {
            get { return this.gdb_folderPath.Text; }
            set { this.gdb_folderPath.Text = value; }
        }

        public bool Check
        {
            get { return this.gdb_label.Checked; }
            set { this.gdb_label.Checked = value; }
        }

        public void SetValue(DbSdeUser dbSdeUser)
        {
            this._name = dbSdeUser.Name;
            this.gdb_label.Text = dbSdeUser.Label;
            this._user = dbSdeUser.User;
            this._password = dbSdeUser.Password;
            this.gdb_folderPath.Text = dbSdeUser.Gdbfile;
        }


        private void btnChoose_Click(object sender, EventArgs e)
        {
            string Path = Common.folderPath(_mainFolder);
            this.gdb_folderPath.Text = Path == "" ? this.gdb_folderPath.Text : Path;
        }
    }
}
