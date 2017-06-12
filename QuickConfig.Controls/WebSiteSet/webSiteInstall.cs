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
    public partial class webSiteInstall : UserControl
    {
        public webSiteInstall()
        {
            InitializeComponent();
        }

        List<webSiteCheck> websitecheckList;

        public string ConfigName;

        public void SetInstallWebapps(Apps apps){
            websitecheckList = new List<webSiteCheck>();
            List<WebApp> webapps = new List<WebApp>();
            webapps = apps.WebAppList;

            int height = 0;
            foreach (WebApp webapp in webapps)
            {
                webSiteCheck websitecheck = new webSiteCheck();
                websitecheck.Name = webapp.Name;
                websitecheck.Label = webapp.Label;             
                this.flowLayoutPanel1.Controls.Add(websitecheck);
                height = websitecheck.Bounds.Y + websitecheck.Bounds.Height;
                websitecheckList.Add(websitecheck);
            }

            int addHeight = height - this.flowLayoutPanel1.Size.Height > 0 ? height - this.flowLayoutPanel1.Size.Height + 20 : 0;

            this.Height += addHeight;
            this.groupBox6.Height += addHeight;
            this.flowLayoutPanel1.Height += addHeight;
            this.label40.SetBounds(label40.Bounds.X, label40.Bounds.Y + addHeight, label40.Bounds.Width, label40.Bounds.Height);
            this.checkAll.SetBounds(checkAll.Bounds.X, checkAll.Bounds.Y + addHeight, checkAll.Bounds.Width, checkAll.Bounds.Height);
            this.btn_createweb.SetBounds(btn_createweb.Bounds.X, btn_createweb.Bounds.Y + addHeight, btn_createweb.Bounds.Width, btn_createweb.Bounds.Height);
        

        }

        

        private void btn_createweb_Click(object sender, EventArgs e)
        {
            Apps apps = QuickConfig.Common.setXml.getConfig(ConfigName).Apps;

            setIIS iis = new setIIS();

            foreach (webSiteCheck wsc in websitecheckList) { 
                if(wsc.Check){
                    WebApp webapp = apps.WebAppList.Find((WebApp wa)=>wa.Name==wsc.Name);
                    iis.DelSite(webapp.SiteName);
                    NewWebSiteInfo info_framework = new NewWebSiteInfo(webapp.Ip, webapp.Port, "", webapp.SiteName, webapp.Path);
                    iis.CreateNewWebSite(info_framework, webapp.SiteName);    
                    //创建网站的 虚拟目录
                    if(webapp.VirtualDirList!=null&&webapp.VirtualDirList.Count>0){
                        foreach (WebAppVirtualDir virtualdir in webapp.VirtualDirList) {
                            iis.CreateVirtualDirectory(webapp.SiteName,@"/", virtualdir.VirtualName, virtualdir.Path);
                        }
                    }
                }
            
            }          
          
            setMessage.MessageShow("", "网站创建完成!", this.btn_createweb);
        }

        private void checkAll_CheckedChanged(object sender, EventArgs e)
        {
            List<string[]> checkApp = new List<string[]>();
            foreach (webSiteCheck cc in websitecheckList)
            {
                if (this.checkAll.Checked == true)
                {
                    cc.Check = true;
                }
                else
                {
                    cc.Check = false;
                }
            }
        }
    }
}
