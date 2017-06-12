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
    public partial class webSiteSet : UserControl
    {
        public webSiteSet()
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
            get { return this.web_label.Text; }
            set { this.web_label.Text = value; }
        }

        public string FolderPath
        {
            get { return this.web_folderPath.Text; }
            set { this.web_folderPath.Text = value; }

        }

        private string _configFolder;

        public string ConfigFolder
        {
            get { return _configFolder; }
            set { _configFolder = value; }

        }

        public string SiteName
        {
            get { return this.web_siteName.Text; }
            set { this.web_siteName.Text = value; }

        }
        public string Port
        {
            get { return this.web_port.Text; }
            set { this.web_port.Text = value; }

        }
        public string Ip
        {
            get { return this.web_ip.Text; }
            set { this.web_ip.Text = value; }

        }
        public bool X86bit
        {
            get { return this.web_32bit.Checked; }
            set { this.web_32bit.Checked = value; }
        }

        public List<WebAppVirtualDir> VirtualDirList {
            get {return  getVirtualDirList(); }
            set { setVirtualDirCtlList(value); }
        
        }

        private List<webSiteVirtualDirctorySet> virtualDirCtlList;

        private List<WebAppVirtualDir> getVirtualDirList() {
            List<WebAppVirtualDir> virtualDirList = new List<WebAppVirtualDir>();
            if(virtualDirCtlList!=null&&virtualDirCtlList.Count>0){
                foreach(webSiteVirtualDirctorySet virtualDirSet in virtualDirCtlList){
                    WebAppVirtualDir virtualdir = new WebAppVirtualDir();
                    virtualdir.Name = virtualDirSet.Name;
                    virtualdir.VirtualName = virtualDirSet.VirtualName;
                    virtualdir.Path = virtualDirSet.Path;
                    virtualDirList.Add(virtualdir);
                }
            }
            return virtualDirList;
        
        }

        public void SetValue(WebApp webApp) {
            this._name = webApp.Name;
            this.web_label.Text = webApp.Label;
            this.web_folderPath.Text = webApp.Path;
            this._configFolder = webApp.ConfigFolder;
            this.web_siteName.Text = webApp.SiteName;
            this.web_port.Text = webApp.Port;
            this.web_ip.Text = webApp.Ip;
            this.web_32bit.Checked = webApp.X86bit;
            this.VirtualDirList = webApp.VirtualDirList;
            
        
        }

        private void setVirtualDirCtlList( List<WebAppVirtualDir> virtualDirList) {
            virtualDirCtlList = new List<webSiteVirtualDirctorySet>();

            if (virtualDirList!=null&&virtualDirList.Count>0)
            {
                foreach(WebAppVirtualDir virtualDir in virtualDirList){
                    webSiteVirtualDirctorySet virtualDirSet = new webSiteVirtualDirctorySet();
                    virtualDirSet.WebSiteName = this.SiteName;
                    virtualDirSet.WebSitePath = this.FolderPath;
                    virtualDirSet.setValue(virtualDir);

                    virtualDirCtlList.Add(virtualDirSet);

                    this.Controls.Add(virtualDirSet);
                    virtualDirSet.SetBounds(0, this.Height, virtualDirSet.Width, virtualDirSet.Height);
                    this.Height += virtualDirSet.Height;

                }
                
            }
        
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            string Path = Common.folderPath(_mainFolder);
            this.web_folderPath.Text = Path == "" ? this.web_folderPath.Text : Path;
        } 
    }
}
