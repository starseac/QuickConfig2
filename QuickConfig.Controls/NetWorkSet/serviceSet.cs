using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuickConfig.Model.app;

namespace QuickConfig.Controls.NetWorkSet
{
    public partial class serviceSet : UserControl
    {
        public serviceSet()
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
            get { return this.service_label.Text; }
            set { this.service_label.Text = value; }
        }

        public string FolderPath
        {
            get { return this.service_folderPath.Text; }
            set { this.service_folderPath.Text = value; }
        }

        private string _configFolder;

        public string ConfigFolder
        {
            get { return _configFolder; }
            set { _configFolder = value; }
        }

       
        public string Ip {
            get { return this.service_ip.Text; }
            set { this.service_ip.Text = value; }        
        }

        public string Port
        {
            get { return this.service_port.Text; }
            set { this.service_port.Text = value; }
        }

        public void SetValue(ServiceApp serviceApp) {
            this._name = serviceApp.Name;
            this.service_label.Text = serviceApp.Label;
            this.service_folderPath.Text = serviceApp.Path;
            this._configFolder = serviceApp.ConfigFolder;
            this.service_ip.Text = serviceApp.Ip;
            this.service_port.Text = serviceApp.Port;
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            string Path = Common.folderPath(_mainFolder);
            this.service_folderPath.Text = Path == "" ? this.service_folderPath.Text : Path;
        }
    }
}
