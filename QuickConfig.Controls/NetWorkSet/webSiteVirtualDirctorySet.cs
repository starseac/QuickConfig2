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
    public partial class webSiteVirtualDirctorySet : UserControl
    {
        public webSiteVirtualDirctorySet()
        {
            InitializeComponent();
        }

        public string WebSiteName;

        public string WebSitePath;

        public string Name;

        public string VirtualName {
            get { return this.txt_virtualName.Text; }
            set { this.txt_virtualName.Text = value; }
        }

        public string Path
        {
            get { return this.txt_path.Text; }
            set { this.txt_path.Text = value; }
        }


        public void setValue(WebAppVirtualDir virtualDir){
            this.Name = virtualDir.Name;
            this.txt_virtualName.Text = virtualDir.VirtualName;
            this.txt_path.Text = virtualDir.Path;
        
        }

        private void btn_choose_Click(object sender, EventArgs e)
        {
            string Path = Common.folderPath(WebSitePath);
            this.txt_path.Text = Path == "" ? this.txt_path.Text : Path;
        }


    }
}
