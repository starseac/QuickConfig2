using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuickConfig.Model;
using QuickConfig.Controls;
using QuickConfig.Model.app;
using QuickConfig.Controls.AppSet;
using QuickConfig.Controls.NetWorkSet;
using QuickConfig.Model.db;
using QuickConfig.Controls.DbSet;
using QuickConfig.Model.pars;
using QuickConfig.Controls.ParsSet;
using QuickConfig.Controls.DbInit;
using QuickConfig.Controls.WebSiteSet;
using QuickConfig.Model.backup;
using QuickConfig.Controls.BackupSet;
using QuickConfig.Utility;
using QuickConfig.Common;
using QuickConfig.Controls.SystemSet;
using System.IO;
using QuickConfig.Model.definebtns;
using QuickConfig.Model;
using QuickConfig.Controls.ToolSet;

namespace QuickConfig
{
    public partial class QuickConfig : Form
    {
        public QuickConfig()
        {
            InitializeComponent();



            loadStart();
            //this.flowLayoutPanel4.Visible = false;
            //this.flowLayoutPanel7.Visible = false;
            //this.linkChangeXML.Visible = false;
            //this.btnEditConfigXml.Visible = false;
            //this.link_doc.Visible = false;


            setTabPagesShow();

        }

        private void setTabPagesShow()
        {
            this.tabControl1.TabPages.Remove(this.tabPage1);
            this.tabControl1.TabPages.Remove(this.tabPage2);
            this.tabControl1.TabPages.Remove(this.tabPage3);
            this.tabControl1.TabPages.Remove(this.tabPage4);
            this.tabControl1.TabPages.Remove(this.tabPage5);
            this.tabControl1.TabPages.Remove(this.tabPage6);
            this.tabControl1.TabPages.Remove(this.tabPage7);

            //控制 tab页显示
            ConfigSet config = setXml.getAppConfig();
            List<ConfigPar> configParList = config.ConfigParList;
            if (configParList.Find((ConfigPar par) => par.Name == "tab_appset").Value == "True")
            {
                this.tabControl1.Controls.Add(this.tabPage1);
            }
            if (configParList.Find((ConfigPar par) => par.Name == "tab_dbset").Value == "True")
            {
                this.tabControl1.Controls.Add(this.tabPage2);
            }
            if (configParList.Find((ConfigPar par) => par.Name == "tab_pars").Value == "True")
            {
                this.tabControl1.Controls.Add(this.tabPage7);
            }
            if (configParList.Find((ConfigPar par) => par.Name == "tab_dbinit").Value == "True")
            {
                this.tabControl1.Controls.Add(this.tabPage3);
            }
            if (configParList.Find((ConfigPar par) => par.Name == "tab_appinit").Value == "True")
            {
                this.tabControl1.Controls.Add(this.tabPage4);
            }
            if (configParList.Find((ConfigPar par) => par.Name == "tab_tools").Value == "True")
            {
                this.tabControl1.Controls.Add(this.tabPage6);
            }
            if (configParList.Find((ConfigPar par) => par.Name == "tab_backup").Value == "True")
            {
                this.tabControl1.Controls.Add(this.tabPage5);
            }

            //设置按钮显示
            if (configParList.Find((ConfigPar par) => par.Name == "btn_set").Value == "True")
            {
                this.link_appset.Visible = true;
            }

            if (configParList.Find((ConfigPar par) => par.Name == "btn_chanagexml").Value == "True")
            {
                this.link_ChangeXML.Visible = true;
            }           

            if (configParList.Find((ConfigPar par) => par.Name == "btn_helpdoc").Value == "True")
            {
               // this.link_doc.Visible = true;
            }

            if (configParList.Find((ConfigPar par) => par.Name == "btn_save").Value == "True")
            {
                this.btnSaveConfig.Visible = true;
            }



        }

        string configName;

        Set configset;

        List<Control> allControl;

        private void loadStart()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "config\\start.txt";
            FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamReader sr = new StreamReader(fs);
            string con = sr.ReadToEnd();
            sr.Close();
            fs.Close();
            if (con != "")
            {
                loadConfig(con);
            }
            else
            {
                loadChange();
            }
        }
        private void saveStart(string xmlname)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "config\\start.txt";
            File.WriteAllText(path, xmlname);
        }



        private void loadConfig(string xmlname)
        {
            configName = xmlname;

            string configPath = AppDomain.CurrentDomain.BaseDirectory + "config\\" + configName + ".xml";

            if (File.Exists(configPath))
            {
                try
                {
                    configset = XmlClassHelper.LoadXML2Class<Set>(configPath);
                    allControl = new List<Control>();
                    this.flowLayoutPanel1.Controls.Clear();
                    this.flowLayoutPanel2.Controls.Clear();
                    this.flowLayoutPanel3.Controls.Clear();
                    this.flowLayoutPanel4.Controls.Clear();
                    this.flowLayoutPanel5.Controls.Clear();
                    this.flowLayoutPanel6.Controls.Clear();
                    this.flowLayoutPanel7.Controls.Clear();
                    loadSetControls();
                    loadDbSetControls();
                    loadParsControls();
                    loadDbInit();
                    loadAppsInit();
                    loadBtnInit();
                    loadBackup();
                }
                catch (Exception eg)
                {
                    loadChange();
                }

            }
            else
            {
                loadChange();

            }
        }

        private void saveConfig()
        {
            string configPath2 = AppDomain.CurrentDomain.BaseDirectory + "config\\" + configName + ".xml";

            XmlClassHelper.SaveClass2Xml<Set>(configset, configPath2);
        }

        private void SetControlAdd(Control ctl)
        {
            this.flowLayoutPanel1.Controls.Add(ctl);
            allControl.Add(ctl);


        }

        private void loadSetControls()
        {
            Apps apps = configset.Apps;

            //设置主目录
            mainFolder mainfolder = new mainFolder();
            mainfolder.SetValue(apps);
            mainfolder.allControl = allControl;
            mainfolder.set = configset;
            SetControlAdd(mainfolder);

            //服务设置
            if (apps.ServiceAppList.Count > 0)
            {
                for (int i = 0; i < apps.ServiceAppList.Count; i++)
                {
                    ServiceApp serviceapp = apps.ServiceAppList[i];
                    serviceSet serviceset = new serviceSet();
                    serviceset.SetValue(serviceapp);
                    SetControlAdd(serviceset);
                }

            }

            //网站设置
            if (apps.WebAppList.Count > 0)
            {
                for (int i = 0; i < apps.WebAppList.Count; i++)
                {
                    WebApp webapp = apps.WebAppList[i];
                    webSiteSet websiteset = new webSiteSet();
                    websiteset.SetValue(webapp);
                    SetControlAdd(websiteset);
                }

            }

            //客户端程序
            if (apps.AppList.Count > 0)
            {
                for (int i = 0; i < apps.AppList.Count; i++)
                {
                    App app = apps.AppList[i];
                    appFolder appfolder = new appFolder();
                    appfolder.SetValue(app);
                    SetControlAdd(appfolder);
                }

            }

            //ftp
            if (apps.FtpList.Count > 0)
            {
                for (int i = 0; i < apps.FtpList.Count; i++)
                {
                    Ftp ftp = apps.FtpList[i];
                    ftpSiteSet ftpsiteset = new ftpSiteSet();
                    ftpsiteset.SetValue(ftp);
                    SetControlAdd(ftpsiteset);
                }

            }

            //gxml
            if (apps.GxmlList.Count > 0)
            {
                for (int i = 0; i < apps.GxmlList.Count; i++)
                {
                    Gxml gxml = apps.GxmlList[i];
                    gxmlSet gxmlset = new gxmlSet();
                    gxmlset.SetValue(gxml);
                    SetControlAdd(gxmlset);
                }

            }

        }


        private void DbSetControlAdd(Control ctl)
        {
            this.flowLayoutPanel2.Controls.Add(ctl);
            allControl.Add(ctl);
        }

        private void loadDbSetControls()
        {
            Db db = configset.Db;
            //设置表头
            dbTableTitleSet dbtabletitleset = new dbTableTitleSet();
            DbSetControlAdd(dbtabletitleset);

            //设置普通用户            
            if (db.DbUserList.Count > 0)
            {
                for (int i = 0; i < db.DbUserList.Count; i++)
                {

                    DbUser dbuser = db.DbUserList[i];
                    dbUserSet dbuserset = new dbUserSet();
                    dbuserset.SetValue(dbuser);
                    DbSetControlAdd(dbuserset);

                }
            }




            //设置sde用户
            if (db.DbSdeUserList.Count > 0)
            {
                for (int i = 0; i < db.DbSdeUserList.Count; i++)
                {

                    DbSdeUser dbsdeuser = db.DbSdeUserList[i];
                    dbSdeUserSet dbsdeuserset = new dbSdeUserSet();
                    dbsdeuserset.SetValue(dbsdeuser);
                    DbSetControlAdd(dbsdeuserset);

                }
            }



            //设置system用户
            if (db.DbSystemUser != null)
            {
                dbSystemuserSet dbsystemuserset = new dbSystemuserSet();
                dbsystemuserset.SetValue(db.DbSystemUser);
                DbSetControlAdd(dbsystemuserset);

                //设置数据源
                dbSet dbset = new dbSet();
                dbset.SetValue(db);
                dbset.SetSystemUserSet(dbsystemuserset);
                DbSetControlAdd(dbset);
            }




        }


        private void ParsSetControlAdd(Control ctl)
        {
            this.flowLayoutPanel3.Controls.Add(ctl);
            allControl.Add(ctl);
        }

        private void loadParsControls()
        {
            Pars pars = configset.Pars;
            if (pars.ParList.Count > 0)
            {
                for (int i = 0; i < pars.ParList.Count; i++)
                {
                    Par par = pars.ParList[i];
                    parSet parset = new parSet();
                    parset.SetValue(par);
                    ParsSetControlAdd(parset);
                }

            }

        }

        private void DbInitControlAdd(Control ctl)
        {
            this.flowLayoutPanel4.Controls.Add(ctl);
            allControl.Add(ctl);
        }

        private void loadDbInit()
        {

            Db db = configset.Db;

            List<Control> dbCtlsList = new List<Control>();

            //设置数据主目录
            impdataFolder impdatafolder = new impdataFolder();
            impdatafolder.SetValue(db);
            DbInitControlAdd(impdatafolder);

            //设置普通用户初始化

            if (db.DbUserList.Count > 0)
            {
                for (int i = 0; i < db.DbUserList.Count; i++)
                {
                    DbUser dbuser = db.DbUserList[i];
                    dmpChoose dmpchoose = new dmpChoose();
                    dmpchoose.SetValue(dbuser);
                    DbInitControlAdd(dmpchoose);
                    dbCtlsList.Add(dmpchoose);
                }


            }


            //设置sde用户初始化
            if (db.DbSdeUserList.Count > 0)
            {
                for (int i = 0; i < db.DbSdeUserList.Count; i++)
                {
                    DbSdeUser dbsdeuser = db.DbSdeUserList[i];
                    gdbChoose gdbchoose = new gdbChoose();
                    gdbchoose.SetValue(dbsdeuser);
                    DbInitControlAdd(gdbchoose);
                    dbCtlsList.Add(gdbchoose);
                }

                sdeCoordinateSystemSet sdecss = new sdeCoordinateSystemSet();
                sdecss.CS_TYPE = db.CS_TYPE;
                sdecss.WKID = db.WKID;
                sdecss.Prjpath = db.Prjpath;
                DbInitControlAdd(sdecss);
                dbCtlsList.Add(sdecss);
            }

            dbInit dbinit = new dbInit();
            dbinit.dbControlList = dbCtlsList;
            dbinit.SetButtons(db);
            dbinit.ConfigName = configName;
            DbInitControlAdd(dbinit);
        }

        private void AppInitControlAdd(Control ctl)
        {
            this.flowLayoutPanel5.Controls.Add(ctl);
            allControl.Add(ctl);
        }

        private void loadAppsInit()
        {
            Apps apps = configset.Apps;

            appsConfig appconfig = new appsConfig();
            appconfig.SetConfigApps(apps);
            appconfig.ConfigName = configName;
            AppInitControlAdd(appconfig);
            // 设置网站安装

            if (apps.WebAppList.Count > 0)
            {
                webSiteInstall websiteinstall = new webSiteInstall();
                websiteinstall.SetInstallWebapps(apps);
                websiteinstall.ConfigName = configName;
                AppInitControlAdd(websiteinstall);
            }

            //设置服务安装
            if (apps.ServiceAppList.Count > 0)
            {
                foreach (ServiceApp serviceapp in apps.ServiceAppList)
                {
                    serviceInstall serviceinstall = new serviceInstall();
                    serviceinstall.SetValue(serviceapp);
                    serviceinstall.ConfigName = configName;
                    AppInitControlAdd(serviceinstall);
                }
            }

            //设置ftp安装
            if (apps.FtpList.Count > 0)
            {
                for (int i = 0; i < apps.FtpList.Count; i++)
                {
                    Ftp ftp = apps.FtpList[i];
                    ftpSiteInstall ftpsiteinstall = new ftpSiteInstall();
                    ftpsiteinstall.SetValue(ftp);
                    ftpsiteinstall.ConfigName = configName;
                    AppInitControlAdd(ftpsiteinstall);

                }
            }

            //设置共享目录安装
            if (apps.GxmlList.Count > 0)
            {
                for (int i = 0; i < apps.GxmlList.Count; i++)
                {
                    Gxml gxml = apps.GxmlList[i];
                    gxmlInstall gxmlinstall = new gxmlInstall();
                    gxmlinstall.SetValue(gxml);
                    gxmlinstall.ConfigName = configName;
                    AppInitControlAdd(gxmlinstall);

                }
            }

        }

        private void BtnInitControlAdd(Control ctl)
        {
            this.flowLayoutPanel6.Controls.Add(ctl);
            allControl.Add(ctl);
        }

        private void loadBtnInit()
        {
            List<Btn> btnlist = new List<Btn>();
            btnlist = configset.Definebtns.BtnList;
            foreach (Btn btn in btnlist)
            {
                btnSet bs = new btnSet();
                bs.ConfigName = configName;
                bs.btn = btn;
                bs.setValue();
                BtnInitControlAdd(bs);

            }

        }


        private void BackupControlAdd(Control ctl)
        {
            this.flowLayoutPanel7.Controls.Add(ctl);
            allControl.Add(ctl);
        }

        private void loadBackup()
        {
            Backup backup = configset.Backup;
            backupFolder backupfolder = new backupFolder();
            backupfolder.SetValue(backup);
            BackupControlAdd(backupfolder);

            backupContentSet backupcontentset = new backupContentSet();
            backupcontentset.SetBackup(configset);
            BackupControlAdd(backupcontentset);

            backupSet backupset = new backupSet();
            backupset.SetValue(backup);
            backupset.ConfigName = configName;
            BackupControlAdd(backupset);

        }

        private void btnSaveConfig_Click(object sender, EventArgs e)
        {
            if (allControl.Count > 0)
            {

                #region 程序
                Control mfctl = allControl.Find((Control ctl) => (ctl is mainFolder));
                Apps apps = new Apps();
                mainFolder mf = mfctl as mainFolder;
                apps.Name = mf.Name;
                apps.Label = mf.Label;
                apps.Path = mf.FolderPath;


                //-- 服务
                List<ServiceApp> serviceapps = new List<ServiceApp>();
                List<Control> servicesctl = allControl.FindAll((Control ctl) => (ctl is serviceSet));
                if (servicesctl != null && servicesctl.Count > 0)
                {
                    foreach (Control ctl in servicesctl)
                    {
                        serviceSet serviceset = ctl as serviceSet;
                        ServiceApp serviceapp = new ServiceApp();
                        serviceapp.Name = serviceset.Name;
                        serviceapp.Label = serviceset.Label;
                        serviceapp.Path = serviceset.FolderPath;
                        serviceapp.ConfigFolder = serviceset.ConfigFolder;
                        serviceapp.Ip = serviceset.Ip;
                        serviceapp.Port = serviceset.Port;

                        ServiceApp oldServiceapp = configset.Apps.ServiceAppList.Find((ServiceApp sa) => sa.Name == serviceset.Name);
                        serviceapp.Relativepath = oldServiceapp.Relativepath;
                        serviceapp.Servicename = oldServiceapp.Servicename;
                        serviceapp.Installbat = oldServiceapp.Installbat;
                        serviceapp.Removebat = oldServiceapp.Removebat;
                        serviceapps.Add(serviceapp);

                    }
                }
                apps.ServiceAppList = serviceapps;
                //-- 网站
                List<WebApp> webapps = new List<WebApp>();
                List<Control> webappsctl = allControl.FindAll((Control ctl) => (ctl is webSiteSet));
                if (webappsctl != null && webappsctl.Count > 0)
                {
                    foreach (Control ctl in webappsctl)
                    {
                        webSiteSet websiteset = ctl as webSiteSet;
                        WebApp webapp = new WebApp();
                        webapp.Name = websiteset.Name;
                        webapp.Label = websiteset.Label;
                        webapp.Path = websiteset.FolderPath;
                        webapp.ConfigFolder = websiteset.ConfigFolder;
                        webapp.SiteName = websiteset.SiteName;
                        webapp.Ip = websiteset.Ip;
                        webapp.Port = websiteset.Port;
                        webapp.X86bit = websiteset.X86bit;

                        WebApp oldWebapp = configset.Apps.WebAppList.Find((WebApp sa) => sa.Name == websiteset.Name);
                        webapp.Relativepath = oldWebapp.Relativepath;

                        webapp.VirtualDirList = websiteset.VirtualDirList;

                        webapps.Add(webapp);

                    }
                }
                apps.WebAppList = webapps;

                //--程序
                List<App> appList = new List<App>();
                List<Control> appsctl = allControl.FindAll((Control ctl) => (ctl is appFolder));
                if (appsctl != null && appsctl.Count > 0)
                {
                    foreach (Control ctl in appsctl)
                    {
                        appFolder appfolder = ctl as appFolder;
                        App app = new App();
                        app.Name = appfolder.Name;
                        app.Label = appfolder.Label;
                        app.Path = appfolder.FolderPath;
                        app.ConfigFolder = appfolder.ConfigFolder;

                        App oldApp = configset.Apps.AppList.Find((App sa) => sa.Name == appfolder.Name);
                        app.Relativepath = oldApp.Relativepath;

                        appList.Add(app);

                    }
                }
                apps.AppList = appList;

                //--ftp站点
                List<Ftp> ftpList = new List<Ftp>();
                List<Control> ftpsctl = allControl.FindAll((Control ctl) => (ctl is ftpSiteSet));
                if (ftpsctl != null && ftpsctl.Count > 0)
                {
                    foreach (Control ctl in ftpsctl)
                    {
                        ftpSiteSet ftpsiteset = ctl as ftpSiteSet;
                        Ftp ftp = new Ftp();
                        ftp.Name = ftpsiteset.Name;
                        ftp.Label = ftpsiteset.Label;
                        ftp.Path = ftpsiteset.FolderPath;
                        ftp.Ip = ftpsiteset.Ip;
                        ftp.User = ftpsiteset.User;
                        ftp.Password = ftpsiteset.Password;

                        Ftp oldFtp = configset.Apps.FtpList.Find((Ftp sa) => sa.Name == ftpsiteset.Name);
                        ftp.Relativepath = oldFtp.Relativepath;

                        ftpList.Add(ftp);

                    }
                }
                apps.FtpList = ftpList;

                //--共享目录
                List<Gxml> gxmlList = new List<Gxml>();
                List<Control> gxmlsctl = allControl.FindAll((Control ctl) => (ctl is gxmlSet));
                if (gxmlsctl != null && gxmlsctl.Count > 0)
                {
                    foreach (Control ctl in gxmlsctl)
                    {
                        gxmlSet gxmlset = ctl as gxmlSet;
                        Gxml gxml = new Gxml();
                        gxml.Name = gxmlset.Name;
                        gxml.Label = gxmlset.Label;
                        gxml.Path = gxmlset.FolderPath;
                        gxml.Ip = gxmlset.Ip;
                        gxml.User = gxmlset.User;
                        gxml.Password = gxmlset.Password;

                        Gxml oldGxml = configset.Apps.GxmlList.Find((Gxml sa) => sa.Name == gxmlset.Name);
                        gxml.Relativepath = oldGxml.Relativepath;

                        gxmlList.Add(gxml);

                    }
                }
                apps.GxmlList = gxmlList;
                #endregion


                #region 数据
                Control datasourcectl = allControl.Find((Control ctl) => (ctl is dbSet));
                Control dataimpctl = allControl.Find((Control ctl) => (ctl is impdataFolder));
                dbSet dbset = datasourcectl as dbSet;
                impdataFolder impdatafolder = dataimpctl as impdataFolder;
                Db db = new Db();
                db.Name = dbset.Name;
                db.Label = impdatafolder.Label;
                db.Ip = dbset.Ip;
                db.Datasource = dbset.Datasource;
                db.Datafolder_type = dbset.DataFolder_type;
                db.Datafolder = dbset.DataFolder;
                db.Relativepath = configset.Db.Relativepath;

                Control scs = allControl.Find((Control ctl) => (ctl is sdeCoordinateSystemSet));
                if (scs != null)
                {
                    db.CS_TYPE = ((sdeCoordinateSystemSet)scs).CS_TYPE;
                    db.WKID = ((sdeCoordinateSystemSet)scs).WKID;
                    db.Prjpath = ((sdeCoordinateSystemSet)scs).Prjpath;
                }
                else
                {
                    db.CS_TYPE = "";
                    db.WKID = "";
                    db.Prjpath = "";
                }

                db.Impfolder = impdatafolder.FolderPath;

                //-- system用户
                Control systemuserctl = allControl.Find((Control ctl) => (ctl is dbSystemuserSet));
                dbSystemuserSet dbsystemuserset = systemuserctl as dbSystemuserSet;
                DbSystemUser dbsystemuser = new DbSystemUser();
                dbsystemuser.Name = dbsystemuserset.Name;
                dbsystemuser.Label = dbsystemuserset.Label;
                dbsystemuser.User = dbsystemuserset.User;
                dbsystemuser.Password = dbsystemuserset.Password;

                db.DbSystemUser = dbsystemuser;
                //-- 普通用户
                List<DbUser> dbuserList = new List<DbUser>();
                List<Control> dbusersctl = allControl.FindAll((Control ctl) => (ctl is dbUserSet));
                if (dbusersctl != null && dbusersctl.Count > 0)
                {
                    foreach (Control ctl in dbusersctl)
                    {
                        dbUserSet dbuserset = ctl as dbUserSet;
                        DbUser dbuser = new DbUser();
                        dbuser.Name = dbuserset.Name;
                        dbuser.Label = dbuserset.Label;
                        dbuser.Tablespace = dbuserset.Tablespace;
                        dbuser.User = dbuserset.User;
                        dbuser.Password = dbuserset.Password;

                        Control dmpchoosectl = allControl.Find((Control cc) => (cc is dmpChoose) && ((cc as dmpChoose).Name == dbuserset.Name));
                        dmpChoose dmpchoose = dmpchoosectl as dmpChoose;
                        dbuser.Dmpfile = dmpchoose.FilePath;

                        DbUser oldDbuser = configset.Db.DbUserList.Find((DbUser sa) => sa.Name == dbuserset.Name);
                        dbuser.Relativepath = oldDbuser.Relativepath;

                        dbuserList.Add(dbuser);

                    }
                }
                db.DbUserList = dbuserList;
                //-- sde 用户
                List<DbSdeUser> dbsdeuserList = new List<DbSdeUser>();
                List<Control> dbsdeusersctl = allControl.FindAll((Control ctl) => (ctl is dbSdeUserSet));
                if (dbsdeusersctl != null && dbsdeusersctl.Count > 0)
                {
                    foreach (Control ctl in dbsdeusersctl)
                    {
                        dbSdeUserSet dbsdeuserset = ctl as dbSdeUserSet;
                        DbSdeUser dbsdeuser = new DbSdeUser();
                        dbsdeuser.Name = dbsdeuserset.Name;
                        dbsdeuser.Label = dbsdeuserset.Label;
                        dbsdeuser.Tablespace = dbsdeuserset.Tablespace;
                        dbsdeuser.User = dbsdeuserset.User;
                        dbsdeuser.Password = dbsdeuserset.Password;
                        Control gdbchoosectl = allControl.Find((Control cc) => (cc is gdbChoose) && ((cc as gdbChoose).Name == dbsdeuserset.Name));
                        gdbChoose gdbchoose = gdbchoosectl as gdbChoose;
                        dbsdeuser.Gdbfile = gdbchoose.FolderPath;

                        DbSdeUser oldDbsdeuser = configset.Db.DbSdeUserList.Find((DbSdeUser sa) => sa.Name == dbsdeuserset.Name);
                        dbsdeuser.Relativepath = oldDbsdeuser.Relativepath;

                        dbsdeuserList.Add(dbsdeuser);

                    }
                }
                db.DbSdeUserList = dbsdeuserList;
                #endregion
                #region 参数
                Pars pars = new Pars();
                List<Par> parList = new List<Par>();
                List<Control> parsctl = allControl.FindAll((Control ctl) => (ctl is parSet));
                if (parsctl != null && parsctl.Count > 0)
                {
                    foreach (Control ctl in parsctl)
                    {
                        parSet parset = ctl as parSet;
                        Par par = new Par();
                        par.Key = parset.Key;
                        par.Label = parset.Label;
                        par.Value = parset.Value;

                        parList.Add(par);

                    }
                }
                pars.ParList = parList;
                #endregion

                #region 工具
                Definebtns definebtns = new Definebtns();


                List<Btn> btnList = new List<Btn>();
                List<Control> btnsctl = allControl.FindAll((Control ctl) => (ctl is btnSet));
                if (btnsctl != null && btnsctl.Count > 0)
                {
                    foreach (Control ctl in btnsctl)
                    {
                        btnSet btnset = ctl as btnSet;
                        Btn btn = new Btn();
                        btn = btnset.btn;
                        btnList.Add(btn);
                    }

                }

                definebtns.BtnList = btnList;



                #endregion


                #region 备份
                Backup backup = new Backup();
                Control backupfolderctl = allControl.Find((Control ctl) => (ctl is backupFolder));
                backupFolder backupfolder = backupfolderctl as backupFolder;
                Control backupcontentsetctl = allControl.Find((Control ctl) => (ctl is backupContentSet));
                backupContentSet backupcontentset = backupcontentsetctl as backupContentSet;
                Control backupsetctl = allControl.Find((Control ctl) => (ctl is backupSet));
                backupSet backupset = backupsetctl as backupSet;

                backup.Name = backupfolder.Name;
                backup.Label = backupfolder.Label;
                backup.Content = backupcontentset.BackupContent;
                backup.Path = backupfolder.BackupFolderPath;
                backup.Type = backupset.Type;
                backup.Type_daytime = backupset.Type_daytime;
                backup.Type_week = backupset.Type_week;
                backup.Type_weektime = backupset.Type_weektime;
                backup.Type_month = backupset.Type_month;
                backup.Type_monthtime = backupset.Type_monthtime;


                #endregion


                //保存成Set
                configset.Apps = apps;
                configset.Db = db;
                configset.Pars = pars;
                configset.Definebtns = definebtns;
                configset.Backup = backup;
                saveConfig();

                setMessage.MessageShow("", "保存成功!", this.btnSaveConfig);

            }
        }

        private void link_doc_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "doc/配置工具手册.pdf";
            System.Diagnostics.Process.Start(path);
        }

        private void loadChange()
        {
            changeXML change = new changeXML();
            if (change.ItemCount == 0)
            {
                MessageBox.Show("请设置好配置模板!");
                change.Close();
                return;
            }
            else
            {
                change.ShowDialog();
            }

            if (change.DialogResult == DialogResult.OK)
            {
                string xmlname = change.selectName;
                loadConfig(xmlname);
                saveStart(xmlname);
            }


        }

        private void linkChangeXML_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            loadChange();

        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            // setDB setdb = new setDB(configset.Db.DbSystemUser.User,configset.Db.DbSystemUser.Password,configset.Db.Datasource);
            // setdb.setAppInfo(this.def_xzqmc.Text,this.def_serverip.Text);
            // setMessage.MessageShow("", "修改成功!", button1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //  setBAT.RunBat(AppDomain.CurrentDomain.BaseDirectory + "Tools\\regaspnet4iis.bat", true);
        }

        private void link_appset_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            editConfigXML editxml = new editConfigXML();
            editxml.ShowDialog();
        }

      

    }
}
