using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuickConfig.Model.db;
using QuickConfig.Common;

namespace QuickConfig.Controls.BackupSet
{
    public partial class backupTableSelect : UserControl
    {
        public backupTableSelect()
        {
            InitializeComponent();
        }

        public DbUser dbuser { get; set; }
        public string datasource { get; set; }

        public List<string> chooseTables
        {
            set{
                bindChooseTableList(value);
            }
            get {

                return getChooseTableList();
            }
        }

        public string remoteInfo {
            set { setRemoteInfo(value); }
            get { return this.txt_ip.Text+","+this.txt_account.Text+","+this.txt_password.Text; }        
        
        }

        private void setRemoteInfo(string info){
            if(info!=""){
                string [] infos=info.Split(',');
                this.txt_ip.Text = infos[0];
                this.txt_account.Text = infos[1];
                this.txt_password.Text = infos[2];
            }
        
        }

        public void setTables() {
            setDB setdb = new setDB(dbuser.User, dbuser.Password, datasource);
            List<string> tableList = setdb.getTableListByUser(dbuser.User);

            this.treeView1.Nodes.Clear();
            TreeNode toptn = new TreeNode("数据表");
            treeView1.Nodes.Add(toptn);

            if(tableList!=null){
                foreach (string tablename in tableList) {
                    TreeNode tn = new TreeNode(tablename);
                    toptn.Nodes.Add(tn);
                
                }
            
            }

            treeView1.ExpandAll();        
        
        }


        public List<string> getChooseTableList() {
            List<string> tableList = new List<string>();
            if(treeView1.Nodes!=null){
                if(treeView1.Nodes[0].Nodes!=null){
                    foreach (TreeNode tn in treeView1.Nodes[0].Nodes) { 
                            if(tn.Checked){
                                tableList.Add(tn.Text);
                            }
                    
                    }
                }
            }

            return tableList;
        }

        private void bindChooseTableList(List<string> tableList) { 
            if(tableList!=null&&tableList.Count>0){
                foreach (string tablename in tableList) {
                    for (int i = 0; i < treeView1.Nodes[0].Nodes.Count; i++) {
                        if (treeView1.Nodes[0].Nodes[i].Text==tablename)
                        {

                            treeView1.Nodes[0].Nodes[i].Checked = true;
                        }
                    
                    }        
                }
            
            }
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }


       
    }
}
