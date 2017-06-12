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
    public partial class appsConfig : UserControl
    {
        public appsConfig()
        {
            InitializeComponent();
        }

        List<configCheck> configcheckList;

        public string ConfigName;

        public void SetConfigApps(Apps apps) {
            configcheckList = new List<configCheck>();

            List<ServiceApp> serviceapps = new List<ServiceApp>();
            serviceapps = apps.ServiceAppList;

            int height = 0;

            foreach (ServiceApp serviceapp in serviceapps)
            {
                configCheck appcheck = new configCheck();
                appcheck.Name = serviceapp.Name;
                appcheck.Label = serviceapp.Label;
                appcheck.AppType = "ServiceApp";
                this.flowLayoutPanel1.Controls.Add(appcheck);
                height=appcheck.Bounds.Y + appcheck.Bounds.Height;
                configcheckList.Add(appcheck);
            }

            List<WebApp> webapps = new List<WebApp>();
            webapps = apps.WebAppList;
            foreach (WebApp webapp in webapps)
            {
                configCheck appcheck = new configCheck();
                appcheck.Name = webapp.Name;
                appcheck.Label = webapp.Label;
                appcheck.AppType = "WebApp";
                this.flowLayoutPanel1.Controls.Add(appcheck);
                height = appcheck.Bounds.Y + appcheck.Bounds.Height;
                configcheckList.Add(appcheck);
            }

            List<App> appList = new List<App>();
            appList = apps.AppList;
            foreach (App app in appList)
            {
                configCheck appcheck = new configCheck();
                appcheck.Name = app.Name;
                appcheck.Label = app.Label;
                appcheck.AppType = "App";
                this.flowLayoutPanel1.Controls.Add(appcheck);
                height = appcheck.Bounds.Y + appcheck.Bounds.Height;
                configcheckList.Add(appcheck);
            }

            int addHeight=height-this.flowLayoutPanel1.Size.Height>0?height-this.flowLayoutPanel1.Size.Height+20:0;

            this.Height += addHeight;
            this.groupBox1.Height += addHeight;
            this.flowLayoutPanel1.Height += addHeight;
            this.label2.SetBounds(label2.Bounds.X, label2.Bounds.Y + addHeight, label2.Bounds.Width, label2.Bounds.Height);
            this.checkAll.SetBounds(checkAll.Bounds.X, checkAll.Bounds.Y + addHeight, checkAll.Bounds.Width, checkAll.Bounds.Height);
            this.btnConfig.SetBounds(btnConfig.Bounds.X, btnConfig.Bounds.Y + addHeight, btnConfig.Bounds.Width, btnConfig.Bounds.Height);
        
        }

       

        private bool checkAppFolder(Apps apps)
        {
            string errStr = "";
            foreach (configCheck cc in configcheckList)
            {
                string folderPath = "";
                if (cc.Check)
                {
                    if (cc.AppType == "ServiceApp")
                    {
                        ServiceApp serviceapp = apps.ServiceAppList.Find((ServiceApp sa) => sa.Name == cc.Name);
                        folderPath = serviceapp.Path;                  

                    }

                    else if (cc.AppType == "WebApp")
                    {
                        WebApp serviceapp = apps.WebAppList.Find((WebApp sa) => sa.Name == cc.Name);
                        folderPath = serviceapp.Path;
                    }

                    else if (cc.AppType == "App")
                    {
                        App serviceapp = apps.AppList.Find((App sa) => sa.Name == cc.Name);
                        folderPath = serviceapp.Path;
                    }

                    if (!Common.checkFolder(folderPath))
                    {
                        errStr += cc.Label + "的文件夹不存在,请重新设置\r\n";
                    }

                }
               
            }       
          

            if (errStr != "")
            {
                MessageBox.Show(errStr, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            setXml xml = new setXml();           
            xml.addCopyFileXML(Common.getConfigFolder(),Common.getConfigTemplateFolder(),ConfigName,"copyPath");

            Apps apps = QuickConfig.Common.setXml.getConfig(ConfigName).Apps;

            if (!checkAppFolder(apps))
            {
                return;
            }

            setConfig setconfig = new setConfig();
            List<string[]> checkApp = new List<string[]>();
            foreach (configCheck cc in configcheckList)
            {
                if (cc.Check)
                {
                    string []configFolder =new string[2];
                    if (cc.AppType == "ServiceApp")
                    {
                        ServiceApp serviceapp = apps.ServiceAppList.Find((ServiceApp sa) => sa.Name == cc.Name);
                        configFolder[0] = serviceapp.ConfigFolder;
                        configFolder[1] = serviceapp.Path;
                    }
                    else if (cc.AppType == "WebApp")
                    {
                        WebApp serviceapp = apps.WebAppList.Find((WebApp sa) => sa.Name == cc.Name);
                        configFolder[0] = serviceapp.ConfigFolder;
                        configFolder[1] = serviceapp.Path;
                    }
                    else if (cc.AppType == "App")
                    {
                        App serviceapp = apps.AppList.Find((App sa) => sa.Name == cc.Name);
                        configFolder[0] = serviceapp.ConfigFolder;
                        configFolder[1] = serviceapp.Path;
                    }
                    checkApp.Add(configFolder);
                }

            }

            setconfig.config(Common.getConfigTemplateFolder(),Common.getConfigTemplateTempFolder(),ConfigName,checkApp);

            setMessage.MessageShow("", "设置完成!", this.btnConfig);

        }

        private void checkAll_CheckedChanged(object sender, EventArgs e)
        {
            List<string[]> checkApp = new List<string[]>();
            foreach (configCheck cc in configcheckList)
            {
                if (this.checkAll.Checked == true)
                {
                    cc.Check = true;
                }else{
                    cc.Check = false;
                }
            }
        }



    }
}
