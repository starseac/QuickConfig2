using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuickConfig.Model;
using System.Net;

namespace QuickConfig.OneKeyInstall
{
    public partial class StartConfig : UserControl
    {
        public StartConfig()
        {
            InitializeComponent();
            getLoaclIP();
        }
       
        public string MainFolder {
            get { return this.mainPath.Text; }
            set { this.mainPath.Text = value; }            
        }
        public string APP_IP
        {
            get { return this.app_ip.Text; }
            set { this.app_ip.Text = value; }
        }


        public string DB_IP
        {
            get { return this.db_ip.Text; }
            set { this.db_ip.Text = value; }
        }

        public string DB_Datasource
        {
            get { return this.db_datasource.Text; }
            set { this.db_datasource.Text = value; }
        }

        public string DB_Password
        {
            get { return this.db_password.Text; }
            set { this.db_password.Text = value; }
        }


        public static string folderPath()
        {
            string folderPath = "";
            FolderBrowserDialog folderfDialog = new FolderBrowserDialog();
            folderfDialog.Description = "请选着文件夹";
            if (folderfDialog.ShowDialog() == DialogResult.OK)
            {
                folderPath = folderfDialog.SelectedPath;

            }
            return folderPath;
        }

        private void getLoaclIP() {
            string strHostName = Dns.GetHostName();  //得到本机的主机名
            IPHostEntry ipEntry = Dns.GetHostByName(strHostName); //取得本机IP
            this.APP_IP = ipEntry.AddressList[0].ToString(); //假设本地主机为单网卡
        }

        

        private void ChooseInstallFolder_Click(object sender, EventArgs e)
        {
            string Path = folderPath();
            this.mainPath.Text = Path == "" ? this.mainPath.Text : Path;
        }

        public void SetValue(Set set) {
            this.mainPath.Text = set.Apps.Path;
            this.db_ip.Text = set.Db.Ip;
            this.db_datasource.Text = set.Db.Datasource;
            this.db_password.Text = set.Db.DbSystemUser.Password;
            
        }

        private void btnTestConnect_Click(object sender, EventArgs e)
        {
            try
            {
                Common.setDB setdb = new Common.setDB("system", this.db_password.Text, this.db_datasource.Text);
                
               MessageBox.Show("链接成功!");
            }catch(Exception eg){
                MessageBox.Show("链接失败!");
            
            }
            
        }

        private void getOracleServerIP()
        {
            Common.setDB setdb = new Common.setDB("system", this.db_password.Text, this.db_datasource.Text);
            string strHostName = setdb.getServerHostName();
            IPHostEntry ipEntry = Dns.GetHostByName(strHostName); //取得本机IP
            this.DB_IP = ipEntry.AddressList[0].ToString(); //假设本地主机为单网卡

        }

        private void db_password_TextChanged(object sender, EventArgs e)
        {
            try
            {
                getOracleServerIP();
            }catch(Exception eg){
                this.DB_IP = "127.0.0.1";
            }
        }
    }
}
