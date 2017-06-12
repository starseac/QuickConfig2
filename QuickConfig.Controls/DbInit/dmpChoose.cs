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
    public partial class dmpChoose : UserControl
    {
        public dmpChoose()
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

        public string FilePath
        {
            get { return this.dmp_filePath.Text; }
            set { this.dmp_filePath.Text = value; }
        }

        public bool Check {
            get { return this.dmp_label.Checked; }
            set { this.dmp_label.Checked = value; }
        }

        public void SetValue(DbUser dbUser) {
            this._name = dbUser.Name;
            this.dmp_label.Text = dbUser.Label;
            this._user = dbUser.User;
            this._password = dbUser.Password;
            this.dmp_filePath.Text = dbUser.Dmpfile;
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            string Path = Common.filePath("dmp", _mainFolder);
            this.dmp_filePath.Text = Path == "" ? this.dmp_filePath.Text : Path;
        }
    }
}
