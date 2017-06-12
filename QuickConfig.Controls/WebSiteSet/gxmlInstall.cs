using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuickConfig.Model.app;
using QuickConfig.Common;

namespace QuickConfig.Controls.WebSiteSet
{
    public partial class gxmlInstall : UserControl
    {
        public gxmlInstall()
        {
            InitializeComponent();
        }
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Label {
            get { return this.label.Text; }
            set { this.label.Text = value; }
        }

        public string ConfigName;

        public void SetValue(Gxml gxml) {
            this._name = gxml.Name;
            this.label.Text = gxml.Label;
        }

       
        private void btn_creategxml_Click(object sender, EventArgs e)
        {
            Apps apps = QuickConfig.Common.setXml.getConfig(ConfigName).Apps;
            Gxml gxml = apps.GxmlList.Find((Gxml gx)=>gx.Name==this.Name);
         
            setGXML setgxml = new setGXML();
            setgxml.SetFileRole(gxml.Path,gxml.User);
            setgxml.shareFolder(gxml.Path, gxml.Label, "");
            setMessage.MessageShow("", "共享目录创建成功!", this.btn_creategxml);

        }
    }
}
