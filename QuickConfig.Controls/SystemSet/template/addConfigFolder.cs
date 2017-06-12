using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuickConfig.Common;
using QuickConfig.Model;
using System.IO;

namespace QuickConfig.Controls.SystemSet.template
{
    public partial class addConfigFolder : UserControl
    {
        public addConfigFolder()
        {
            InitializeComponent();
        }

        public string ConfigName;

        public void loadAppList() {
            if(ConfigName!=""){
            Set configset = setXml.getConfig(ConfigName); 
            this.cb_applist.DataSource = configset.getConfigFolderList();
              
            }       
        
        }

        private void btn_createConfigFolder_Click(object sender, EventArgs e)
        {
            if (this.txt_configfolder.Text.Trim() == "")
            {
                MessageBox.Show("配置文件目录不能为空!");

            }
            else {
                string path = Common.getConfigTemplateFolder() + "\\" + ConfigName + "\\" + this.txt_configfolder.Text;

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                    MessageBox.Show("创建成功!");

                }
                else {
                    MessageBox.Show("文件夹已存在!");
                }
            
            }
           
        }

        private void cb_applist_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(this.cb_applist.SelectedItem.ToString()!=null){
                this.txt_configfolder.Text = this.cb_applist.SelectedItem.ToString();            
            }
        }
    }
}
