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
    public partial class impdataFolder : UserControl
    {
        public impdataFolder()
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

        public string FolderPath
        {
            get { return this.folderPath.Text; }
            set { this.folderPath.Text = value; }
        }

        public void SetValue(Db db)
        {
            this._name = db.Name;
            this.label.Text = db.Label;
            this.folderPath.Text = db.Impfolder;
        }
        
        private void btnChoose_Click(object sender, EventArgs e)
        {
            string Path = Common.folderPath();
            this.folderPath.Text = Path == "" ? this.folderPath.Text : Path;
        }
    }
}
