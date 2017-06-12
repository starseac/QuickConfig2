using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuickConfig.Model.app;
using QuickConfig.Controls.NetWorkSet;
using QuickConfig.Model;
using QuickConfig.Controls.DbInit;
using QuickConfig.Model.db;

namespace QuickConfig.Controls.AppSet
{
    public partial class mainFolder : UserControl
    {
        public mainFolder()
        {
            InitializeComponent();
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

        public List<Control> allControl;
        public Set set;

        public void SetValue(Apps apps) {
            this._name = apps.Name;
            this.label.Text = apps.Label;
            this.folderPath.Text = apps.Path;        
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            string Path = Common.folderPath();
            this.folderPath.Text = Path == "" ? this.folderPath.Text : Path;
            changeDefaultPath(this.folderPath.Text);
        }

        private void changeDefaultPath(string mainFolder) { 
             List<Control> servicectl = allControl.FindAll((Control ctl) => (ctl is serviceSet));
             if (servicectl != null && servicectl.Count > 0)
             {
                 foreach (Control ctl in servicectl)
                 {
                     ServiceApp serviceapp = set.Apps.ServiceAppList.Find((ServiceApp sa) => sa.Name == ((serviceSet)ctl).Name);

                     ((serviceSet)ctl).FolderPath = mainFolder + "\\" + serviceapp.Relativepath;
                 }
             }

             List<Control> websitectl = allControl.FindAll((Control ctl) => (ctl is webSiteSet));
             if (websitectl != null && websitectl.Count > 0)
             {
                 foreach (Control ctl in websitectl)
                 {
                     WebApp webapp = set.Apps.WebAppList.Find((WebApp sa) => sa.Name == ((webSiteSet)ctl).Name);

                     ((webSiteSet)ctl).FolderPath = mainFolder + "\\" + webapp.Relativepath;
                 }
             }

             List<Control> appctl = allControl.FindAll((Control ctl) => (ctl is appFolder));
             if (appctl != null && appctl.Count > 0)
             {
                 foreach (Control ctl in appctl)
                 {
                     App app = set.Apps.AppList.Find((App sa) => sa.Name == ((appFolder)ctl).Name);

                     ((appFolder)ctl).FolderPath = mainFolder + "\\" + app.Relativepath;
                 }
             }

             List<Control> ftpctl = allControl.FindAll((Control ctl) => (ctl is ftpSiteSet));
             if (ftpctl != null && ftpctl.Count > 0)
             {
                 foreach (Control ctl in ftpctl)
                 {
                     Ftp ftp = set.Apps.FtpList.Find((Ftp sa) => sa.Name == ((ftpSiteSet)ctl).Name);

                     ((ftpSiteSet)ctl).FolderPath = mainFolder + "\\" + ftp.Relativepath;
                 }
             }

             List<Control> gxmlctl = allControl.FindAll((Control ctl) => (ctl is gxmlSet));
             if (gxmlctl != null && gxmlctl.Count > 0)
             {
                 foreach (Control ctl in gxmlctl)
                 {
                     Gxml gxml = set.Apps.GxmlList.Find((Gxml sa) => sa.Name == ((gxmlSet)ctl).Name);

                     ((gxmlSet)ctl).FolderPath = mainFolder + "\\" + gxml.Relativepath;
                 }
             }

             List<Control> impdatafolderctl = allControl.FindAll((Control ctl) => (ctl is impdataFolder));
             if (impdatafolderctl != null && impdatafolderctl.Count > 0)
             {
                 foreach (Control ctl in impdatafolderctl)
                 {
                     
                     ((impdataFolder)ctl).FolderPath = mainFolder + "\\" + set.Db.Relativepath;
                 }
             }

             List<Control> dmpctl = allControl.FindAll((Control ctl) => (ctl is dmpChoose));
             if (dmpctl != null && dmpctl.Count > 0)
             {
                 foreach (Control ctl in dmpctl)
                 {
                     DbUser dbuser = set.Db.DbUserList.Find((DbUser sa) => sa.Name == ((dmpChoose)ctl).Name);

                     ((dmpChoose)ctl).FilePath = mainFolder + "\\" + dbuser.Relativepath;
                 }
             }

             List<Control> gdbctl = allControl.FindAll((Control ctl) => (ctl is gdbChoose));
             if (gdbctl != null && gdbctl.Count > 0)
             {
                 foreach (Control ctl in gdbctl)
                 {
                     DbSdeUser dbsdeuser = set.Db.DbSdeUserList.Find((DbSdeUser sa) => sa.Name == ((gdbChoose)ctl).Name);

                     ((gdbChoose)ctl).FolderPath = mainFolder + "\\" + dbsdeuser.Relativepath;
                 }
             }
                       
        
        }
    }
}
