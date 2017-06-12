using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuickConfig.Model.db;
using QuickConfig.Model.backup;

namespace QuickConfig.Controls.BackupSet
{
    public partial class backupFolder : UserControl
    {
        public backupFolder()
        {
            InitializeComponent();
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            string Path = Common.folderPath();
            this.backupFolderPath.Text = Path == "" ? this.backupFolderPath.Text : Path;
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

        public string BackupFolderPath {
            get { return this.backupFolderPath.Text; }
            set { this.backupFolderPath.Text = value; }
        
        }

        public void SetValue(Backup backup) {
            this._name = backup.Name;
            this.label.Text = backup.Label;
            this.backupFolderPath.Text = backup.Path;
        
        }
    }
}
