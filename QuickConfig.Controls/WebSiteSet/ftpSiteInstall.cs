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
    public partial class ftpSiteInstall : UserControl
    {
        public ftpSiteInstall()
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

        public void SetValue(Ftp ftp) {
            this._name = ftp.Name;
            this.label.Text = ftp.Label;        
        }

        public string ConfigName;

        private void btn_createftp_Click(object sender, EventArgs e)
        {
            Apps apps = QuickConfig.Common.setXml.getConfig(ConfigName).Apps;

            Ftp ftp = apps.FtpList.Find((Ftp f)=>f.Name==this.Name);

          
            if (!setOSUser.isUserExist(ftp.User))
            {
                setOSUser.addUser(ftp.User, ftp.Password);
            }
            else {
                setOSUser.UpdateUserPassword(ftp.User, ftp.Password);
            }

            setFTP setftp = new setFTP();
            setftp.delFtpSite(ftp.Label);
            setftp.createFTP(ftp.Label, ftp.Path, ftp.User, ftp.Ip);
           setMessage.MessageShow("", "ftp创建成功!", this.btn_createftp);
        }
    }
}
