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
    public partial class editDb : UserControl
    {
        public editDb()
        {
            InitializeComponent();
        }

        public void setValue(Db db)
        {
            this.txt_name.Text = db.Name;
            this.txt_label.Text = db.Label;
            this.txt_ip.Text = db.Ip;
            this.txt_datasource.Text = db.Datasource;
            this.txt_datafolder_type.Checked = db.Datafolder_type;
            this.txt_datafolder.Text = db.Datafolder;
            this.txt_cs_type.Text = db.CS_TYPE;
            this.txt_wkid.Text = db.WKID;
            this.txt_prjpath.Text = db.Prjpath;
            this.txt_impfolder.Text = db.Impfolder;
            this.txt_relativepath.Text = db.Relativepath;

        }

        public bool isNew;

        public Object getValue()
        {
            Db db = new Db();
            db.Name = this.txt_name.Text;
            db.Label = this.txt_label.Text;
            db.Ip = this.txt_ip.Text;
            db.Datasource = this.txt_datasource.Text;
            db.Datafolder_type = this.txt_datafolder_type.Checked;
            db.Datafolder = this.txt_datafolder.Text;
            db.CS_TYPE = this.txt_cs_type.Text;
            db.WKID = this.txt_wkid.Text;
            db.Prjpath = this.txt_prjpath.Text;
            db.Impfolder = this.txt_impfolder.Text;
            db.Relativepath = this.txt_relativepath.Text;
            return db;
        }
    }
}
