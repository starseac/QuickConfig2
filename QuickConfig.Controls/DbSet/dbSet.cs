using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuickConfig.Model.db;
using QuickConfig.Common;

namespace QuickConfig.Controls.DbSet
{
    public partial class dbSet : UserControl
    {
        public dbSet()
        {
            InitializeComponent();
        }

        private string _name;
        public string Name {
            get { return _name; }
            set { _name = value; }
        
        }

        public string Datasource
        {
            get { return this.datasource.Text; }
            set { this.datasource.Text = value; }
        }      

        public bool DataFolder_type {
            get { return this.checkDefault.Checked; }
            set { this.checkDefault.Checked = value; }
        
        }

        public string DataFolder {

            get { return this.datafolder.Text; }
            set { this.datafolder.Text = value; }
        }

        public string Ip
        {

            get { return this.serverip.Text; }
            set { this.serverip.Text = value; }
        }

        public void SetValue(Db db) {
            this._name = db.Name;
            this.serverip.Text = db.Ip;
            this.datasource.Text = db.Datasource;
            this.checkDefault.Checked = db.Datafolder_type;
            this.datafolder.Text = db.Datafolder;        
        }

        private dbSystemuserSet dbsystemuserset;

        public void SetSystemUserSet(dbSystemuserSet dbsystemuserset ) {
            this.dbsystemuserset = dbsystemuserset;        
        }

        private void checkDefault_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkDefault.Checked == true)
            {

                try
                {
                    setDB db = new setDB(dbsystemuserset.User, dbsystemuserset.Password, this.datasource.Text);
                    this.datafolder.Text = db.getDataFolder();
                }
                catch (Exception eg)
                {
                    setMessage.MessageShow("", "链接不上数据库，请检查参数和配置!", this.checkDefault);
                   this.checkDefault.Checked = false;
                    return;
                }

            }
            else
            {
                this.datafolder.Text = "";
            }
        }
    }
}
