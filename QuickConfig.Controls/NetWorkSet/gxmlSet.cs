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
    public partial class gxmlSet : UserControl
    {
        public gxmlSet()
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
            get { return this.gxml_folderPath.Text; }
            set { this.gxml_folderPath.Text = value; }
        }

        public string Ip
        {
            get { return this.gxml_ip.Text; }
            set { this.gxml_ip.Text = value; }
        }

        public string User
        {
            get { return this.gxml_user.Text; }
            set { this.gxml_user.Text = value; }
        }

        public string Password
        {
            get { return this.gxml_password.Text; }
            set { this.gxml_password.Text = value; }
        }

        public void SetValue(Gxml gxml)
        {
            this._name = gxml.Name;
            this.label.Text = gxml.Label;
            this.gxml_folderPath.Text = gxml.Path;
            this.gxml_ip.Text = gxml.Ip;
            this.gxml_user.Text = gxml.User;
            this.gxml_password.Text = gxml.Password;
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            string Path = Common.folderPath(_mainFolder);
            this.gxml_folderPath.Text = Path == "" ? this.gxml_folderPath.Text : Path;
        }

        private void btnCreateFolder_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(this.gxml_folderPath.Text) == false)
            {
                Directory.CreateDirectory(this.gxml_folderPath.Text);
                // MessageBox.Show("共享目录文件夹创建成功！");
                setMessage.MessageShow("", "共享目录文件夹创建成功！", this.btnCreateFolder);
            }
            else
            {
                MessageBox.Show("共享目录文件夹已经存在！");

            }
        }

    }
}
