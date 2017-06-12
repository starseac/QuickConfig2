using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuickConfig.Model.app;

namespace QuickConfig.Controls.AppSet
{
    public partial class appFolder : UserControl
    {
        public appFolder()
        {
            InitializeComponent();
        }
        
        private string _mainFolder;

        public string MainFolder {
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
            get { return this.label.Text; }
            set { this.label.Text = value; }

        }

        public string FolderPath
        {
            get { return this.folderPath.Text; }
            set { this.folderPath.Text = value; }

        }

        private string _configFolder;

        public string ConfigFolder
        {
            get { return _configFolder; }
            set { _configFolder = value; }

        }

        public void SetValue(App app) {
            this._name = app.Name;
            this.label.Text = app.Label;
            this.folderPath.Text = app.Path;
            this._configFolder = app.ConfigFolder;
        
        }


        private void btnChoose_Click(object sender, EventArgs e)
        {
            string Path = Common.folderPath(_mainFolder);
            this.folderPath.Text = Path == "" ? this.folderPath.Text : Path;
        }

        
    }
}
