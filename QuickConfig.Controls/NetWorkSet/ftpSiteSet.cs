using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using QuickConfig.Common;
using QuickConfig.Model.app;

namespace QuickConfig.Controls.NetWorkSet
{
    public partial class ftpSiteSet : UserControl
    {
        public ftpSiteSet()
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
            get { return this.label.Text; }
            set { this.label.Text = value; }
        }

        public string FolderPath
        {
            get { return this.ftp_folderPath.Text; }
            set { this.ftp_folderPath.Text = value; }
        }

        public string Ip
        {
            get { return this.ftp_ip.Text; }
            set { this.ftp_ip.Text = value; }
        }

        public string User
        {
            get { return this.ftp_user.Text; }
            set { this.ftp_user.Text = value; }
        }

        public string Password
        {
            get { return this.ftp_password.Text; }
            set { this.ftp_password.Text = value; }
        }

        public void SetValue(Ftp ftp) {
            this._name = ftp.Name;
            this.label.Text = ftp.Label;
            this.ftp_folderPath.Text = ftp.Path;
            this.ftp_ip.Text = ftp.Ip;
            this.ftp_user.Text = ftp.User;
            this.ftp_password.Text = ftp.Password;        
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            string Path = Common.folderPath(_mainFolder);
            this.ftp_folderPath.Text = Path == "" ? this.ftp_folderPath.Text : Path;
        }

        private void btnCreateFolder_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(this.ftp_folderPath.Text) == false)
            {
                Directory.CreateDirectory(this.ftp_folderPath.Text);
                // MessageBox.Show("ftp文件夹创建成功！");
                setMessage.MessageShow("", "ftp文件夹创建成功！", this.btnCreateFolder);
                if (Directory.Exists(this.ftp_folderPath.Text + @"\SJCL") == false)
                {
                    Directory.CreateDirectory(this.ftp_folderPath.Text + @"\SJCL");
                    // MessageBox.Show("ftp中SJCL文件夹创建成功！");
                    setMessage.MessageShow("", "ftp中SJCL文件夹创建成功！", this.btnCreateFolder);
                }
                else
                {
                    MessageBox.Show("ftp中SJCL文件夹已经存在！");

                }

            }
            else
            {
                MessageBox.Show("ftp文件夹已经存在！");

            }
        }
    }
}
