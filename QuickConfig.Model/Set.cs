using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuickConfig.Model.app;
using QuickConfig.Model.db;
using QuickConfig.Model.pars;
using QuickConfig.Model.backup;
using System.Xml.Serialization;
using QuickConfig.Model.definebtns;
using QuickConfig.Model.doc;

namespace QuickConfig.Model
{

    [XmlRoot("set")]
    public class Set
    {
        private Apps _apps;
        private Db _db;
        private Pars _pars;
        private Definebtns _definebtns;
        private Backup _backup;
        private Doc _doc;

        [XmlElement("apps")]
        public Apps Apps
        {
            get { return _apps; }
            set { _apps = value; }
        }

        [XmlElement("db")]
        public Db Db
        {
            get { return _db; }
            set { _db = value; }
        }

        [XmlElement("pars")]
        public Pars Pars
        {
            get { return _pars; }
            set { _pars = value; }
        }

        [XmlElement("definebtns")]
        public Definebtns Definebtns
        {
            get { return _definebtns; }
            set { _definebtns = value; }
        }

        [XmlElement("backup")]
        public Backup Backup
        {
            get { return _backup; }
            set { _backup = value; }
        }

        [XmlElement("doc")]
        public Doc Doc
        {
            get { return _doc; }
            set { _doc = value; }
        }


        public void setInstallSet(string installServerIp, string mainFolder, string dataServerIp, string datasource, string systemUserPassword, string dataFolder)
        {
            this.Apps.Path = mainFolder;
            foreach (ServiceApp sa in this.Apps.ServiceAppList)
            {
                sa.Ip = installServerIp;
                sa.Path = mainFolder + "\\" + sa.Relativepath;
            }
            foreach (WebApp sa in this.Apps.WebAppList)
            {
                sa.Ip = installServerIp;
                sa.Path = mainFolder + "\\" + sa.Relativepath;
            }
            foreach (App sa in this.Apps.AppList)
            {

                sa.Path = mainFolder + "\\" + sa.Relativepath;
            }
            foreach (Ftp sa in this.Apps.FtpList)
            {
                sa.Ip = installServerIp;
                sa.Path = mainFolder + "\\" + sa.Relativepath;
            }
            foreach (Gxml sa in this.Apps.GxmlList)
            {
                sa.Ip = installServerIp;
                sa.Path = mainFolder + "\\" + sa.Relativepath;
            }

            this.Db.Ip = dataServerIp;
            this.Db.Datafolder = dataFolder;
            this.Db.Datafolder_type = true;
            this.Db.Impfolder = mainFolder + "\\" + this.Db.Relativepath;

            foreach (DbUser du in this.Db.DbUserList)
            {
                du.Dmpfile = mainFolder + "\\" + du.Relativepath;
            }

            foreach (DbSdeUser du in this.Db.DbSdeUserList)
            {
                du.Gdbfile = mainFolder + "\\" + du.Relativepath;
            }
        }


        public void addObject(Object app)
        {
            if (app is ServiceApp)
            {
                this.Apps.ServiceAppList.Add(app as ServiceApp);
            }
            else if (app is WebApp)
            {
                this.Apps.WebAppList.Add(app as WebApp);
            }
            else if (app is App)
            {
                this.Apps.AppList.Add(app as App);
            }
            else if (app is Ftp)
            {
                this.Apps.FtpList.Add(app as Ftp);
            }
            else if (app is Gxml)
            {
                this.Apps.GxmlList.Add(app as Gxml);
            }
            else if (app is DbSystemUser)
            {
                this.Db.DbSystemUser = app as DbSystemUser;
            }
            else if (app is DbUser)
            {
                this.Db.DbUserList.Add(app as DbUser);
            }
            else if (app is DbSdeUser)
            {
                this.Db.DbSdeUserList.Add(app as DbSdeUser);
            }
            else if (app is Par)
            {
                this.Pars.ParList.Add(app as Par);
            }
            else if (app is Btn)
            {
                this.Definebtns.BtnList.Add(app as Btn);
            }

        }

        public void setApps(Apps apps) {
            this.Apps.Name = apps.Name;
            this.Apps.Label = apps.Label;
            this.Apps.Path = apps.Path;         
        
        }

        public void addVirtualDir(WebApp webapp, WebAppVirtualDir newvirtualdir)
        {
            this.Apps.WebAppList.Find((WebApp sa) => sa.Name == (webapp as WebApp).Name).VirtualDirList.Add(newvirtualdir);
        }


        public void setDb(Db db) {
            this.Db.Name = db.Name;
            this.Db.Label = db.Label;
            this.Db.Datasource = db.Datasource;
            this.Db.Ip = db.Ip;
            this.Db.Datafolder_type = db.Datafolder_type;
            this.Db.Datafolder = db.Datafolder;
            this.Db.CS_TYPE = db.CS_TYPE;
            this.Db.WKID = db.WKID;
            this.Db.Prjpath = db.Prjpath;
            this.Db.Impfolder = db.Impfolder;
            this.Db.Relativepath = db.Relativepath;           
        
        }

        public void addBtnInput(Btn btn,Input newinput) {
            this.Definebtns.BtnList.Find((Btn sa) => sa.Name == (btn as Btn).Name).InputList.Add(newinput);      
        
        }

        public void setBackup(Backup backup) {
            this.Backup.Name = backup.Name;
            this.Backup.Label = backup.Label;
            this.Backup.Path = backup.Path;
            this.Backup.Content = backup.Content;
            this.Backup.Type = backup.Type;
            this.Backup.Type_daytime = backup.Type_daytime;
            this.Backup.Type_week = backup.Type_week;
            this.Backup.Type_weektime = backup.Type_weektime;
            this.Backup.Type_month = backup.Type_month;
            this.Backup.Type_monthtime = backup.Type_monthtime;           
        
        }


        public void deleteObject(Object app)
        {
            if (app is ServiceApp)
            {
                this.Apps.ServiceAppList.Remove(this.Apps.ServiceAppList.Find((ServiceApp sa) => sa.Name == (app as ServiceApp).Name));
            }
            else if (app is WebApp)
            {
                this.Apps.WebAppList.Remove(this.Apps.WebAppList.Find((WebApp sa) => sa.Name == (app as WebApp).Name));

            }
            else if (app is App)
            {
                this.Apps.AppList.Remove(this.Apps.AppList.Find((App sa) => sa.Name == (app as App).Name));
            }
            else if (app is Ftp)
            {
                this.Apps.FtpList.Remove(this.Apps.FtpList.Find((Ftp sa) => sa.Name == (app as Ftp).Name));

            }
            else if (app is Gxml)
            {
                this.Apps.GxmlList.Remove(this.Apps.GxmlList.Find((Gxml sa) => sa.Name == (app as Gxml).Name));
            }

            else if (app is DbSystemUser)
            {
                this.Db.DbSystemUser = null;
            }

            else if (app is DbUser)
            {
                this.Db.DbUserList.Remove(this.Db.DbUserList.Find((DbUser sa) => sa.Name == (app as DbUser).Name));
            }

            else if (app is DbSdeUser)
            {
                this.Db.DbSdeUserList.Remove(this.Db.DbSdeUserList.Find((DbSdeUser sa) => sa.Name == (app as DbSdeUser).Name));
            }

            else if (app is Par)
            {
                this.Pars.ParList.Remove(this.Pars.ParList.Find((Par sa) => sa.Key == (app as Par).Key));
            }

            else if (app is Btn)
            {
                this.Definebtns.BtnList.Remove(this.Definebtns.BtnList.Find((Btn sa) => sa.Name == (app as Btn).Name));
            }
        }

        public void deleteBtnInput(Btn btn ,Input input) {                
         this.Definebtns.BtnList.Find((Btn sa) => sa.Name == btn.Name).InputList.Remove( this.Definebtns.BtnList.Find((Btn sa) => sa.Name == btn.Name).InputList.Find((Input sa) => sa.Key == input.Key));
        }

        public void deleteVirtualDir(WebApp webApp, WebAppVirtualDir webAppVirtualDir)
        {
            this.Apps.WebAppList.Find((WebApp sa) => sa.Name == webApp.Name).VirtualDirList.Remove(this.Apps.WebAppList.Find((WebApp sa) => sa.Name == webApp.Name).VirtualDirList.Find((WebAppVirtualDir sa) => sa.Name == webAppVirtualDir.Name));
        }


        public void editObject(Object app, Object newapp)
        {
            if (app is ServiceApp && newapp is ServiceApp)
            {
                int index = this.Apps.ServiceAppList.FindIndex((ServiceApp sa) => sa.Name == (app as ServiceApp).Name);
                deleteObject(app);
                this.Apps.ServiceAppList.Insert(index, newapp as ServiceApp);
            }
            else if (app is WebApp && newapp is WebApp)
            {

                int index = this.Apps.WebAppList.FindIndex((WebApp sa) => sa.Name == (app as WebApp).Name);
                deleteObject(app);
                this.Apps.WebAppList.Insert(index, newapp as WebApp);
            }
            else if (app is App && newapp is App)
            {
                int index = this.Apps.AppList.FindIndex((App sa) => sa.Name == (app as App).Name);
                deleteObject(app);
                this.Apps.AppList.Insert(index, newapp as App);
            }
            else if (app is Ftp && newapp is Ftp)
            {

                int index = this.Apps.FtpList.FindIndex((Ftp sa) => sa.Name == (app as Ftp).Name);
                deleteObject(app);
                this.Apps.FtpList.Insert(index, newapp as Ftp);
            }
            else if (app is Gxml && newapp is Gxml)
            {
                int index = this.Apps.GxmlList.FindIndex((Gxml sa) => sa.Name == (app as Gxml).Name);
                deleteObject(app);
                this.Apps.GxmlList.Insert(index, newapp as Gxml);

            }

            else if (app is DbSystemUser && newapp is DbSystemUser)
            {
                this.Db.DbSystemUser=newapp as DbSystemUser;
            }

            else if (app is DbUser && newapp is DbUser)
            {
                int index = this.Db.DbUserList.FindIndex((DbUser sa) => sa.Name == (app as DbUser).Name);
                deleteObject(app);
                this.Db.DbUserList.Insert(index, newapp as DbUser);

            }
            else if (app is DbSdeUser && newapp is DbSdeUser)
            {
                int index = this.Db.DbSdeUserList.FindIndex((DbSdeUser sa) => sa.Name == (app as DbSdeUser).Name);
                deleteObject(app);
                this.Db.DbSdeUserList.Insert(index, newapp as DbSdeUser);

            }

            else if (app is Par && newapp is Par)
            {
                int index = this.Pars.ParList.FindIndex((Par sa) => sa.Key == (app as Par).Key);
                deleteObject(app);
                this.Pars.ParList.Insert(index, newapp as Par);

            }

            else if (app is Btn && newapp is Btn)
            {
                int index = this.Definebtns.BtnList.FindIndex((Btn sa) => sa.Name == (app as Btn).Name);
                deleteObject(app);
                (newapp as Btn).InputList = (app as Btn).InputList;
                this.Definebtns.BtnList.Insert(index, newapp as Btn);
            }
        }

        public void editBtnInput(Btn btn, Input input,Input newinput)
        {
            int index = this.Definebtns.BtnList.Find((Btn sa) => sa.Name == btn.Name).InputList.FindIndex((Input sa) => sa.Key == input.Key);
            deleteBtnInput(btn,input);
            this.Definebtns.BtnList.Find((Btn sa) => sa.Name == (btn as Btn).Name).InputList.Insert(index, newinput);
        
        }


        public void editVirtualDir(WebApp webApp, WebAppVirtualDir webAppVirtualDir, WebAppVirtualDir newwebAppVirtualDir)
        {
            int index = this.Apps.WebAppList.Find((WebApp sa) => sa.Name == webApp.Name).VirtualDirList.FindIndex((WebAppVirtualDir sa) => sa.Name == webAppVirtualDir.Name);
            deleteVirtualDir(webApp, webAppVirtualDir);
            this.Apps.WebAppList.Find((WebApp sa) => sa.Name == (webApp as WebApp).Name).VirtualDirList.Insert(index, newwebAppVirtualDir);
        }


        public List<string> getConfigFolderList() {
            List<string> folderList = new List<string>();
            foreach (ServiceApp app in this.Apps.ServiceAppList) { 
                if(app.ConfigFolder.Trim()!=""){
                    folderList.Add(app.ConfigFolder);                
                }
            
            }
            foreach (WebApp app in this.Apps.WebAppList)
            {
                if (app.ConfigFolder.Trim() != "")
                {
                    folderList.Add(app.ConfigFolder);
                }

            }
            foreach (App app in this.Apps.AppList)
            {
                if (app.ConfigFolder.Trim() != "")
                {
                    folderList.Add(app.ConfigFolder);
                }

            }

            return folderList;
        }
      
    }
}
