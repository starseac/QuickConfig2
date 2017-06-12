using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuickConfig.Model.app;
using QuickConfig.Model;
using QuickConfig.Model.db;
using QuickConfig.Utility;
using System.IO;

namespace QuickConfig.Controls.BackupSet
{
    public partial class backupContentSet : UserControl
    {
        public backupContentSet()
        {
            InitializeComponent();

        }

        public void SetBackup(Set set)
        {

            setBackupDmpCheckNode(set.Db.DbUserList, set.Db);
            setBackupAppCheckNode(set.Apps);

            if (set.Db.DbSdeUserList.Count <= 0)
            {
                this.treeView3.Visible = false;
            }

            setBackupSdeCheckNode(set.Db.DbSdeUserList);

            this.BackupContent = set.Backup.Content;

        }

        void setBackupDmpCheckNode(List<DbUser> dbuserList, Db db)
        {
            TreeNode Root = treeView1.Nodes.Add("数据库备份");
            Root.ExpandAll();
            foreach (DbUser dbuser in dbuserList)
            {
                TreeNode Node = Root.Nodes.Add(dbuser.Label);
                Node.Tag = dbuser;
                Node.ToolTipText = db.Datasource;
            }
        }

        void setBackupAppCheckNode(Apps apps)
        {
            TreeNode Root = treeView2.Nodes.Add("程序备份");
            Root.ExpandAll();
            foreach (ServiceApp serviceapp in apps.ServiceAppList)
            {
                TreeNode Node = Root.Nodes.Add(serviceapp.Label);
                Node.Tag = serviceapp;
            }

            foreach (WebApp webapp in apps.WebAppList)
            {
                TreeNode Node = Root.Nodes.Add(webapp.Label);
                Node.Tag = webapp;
            }
            foreach (App app in apps.AppList)
            {
                TreeNode Node = Root.Nodes.Add(app.Label);
                Node.Tag = app;
            }

            foreach (Ftp ftp in apps.FtpList)
            {
                TreeNode Node = Root.Nodes.Add(ftp.Label);
                Node.Tag = ftp;
            }

            foreach (Gxml gxml in apps.GxmlList)
            {
                TreeNode Node = Root.Nodes.Add(gxml.Label);
                Node.Tag = gxml;
            }

        }

        void setBackupSdeCheckNode(List<DbSdeUser> dbsdeuserList)
        {
            TreeNode Root = treeView3.Nodes.Add("空间库备份");
            Root.ExpandAll();
            foreach (DbSdeUser dbsdeuser in dbsdeuserList)
            {
                TreeNode Node = Root.Nodes.Add(dbsdeuser.Label);
                Node.Tag = dbsdeuser;
            }

        }

        public string BackupContent
        {
            get { return getBackupContent(); }
            set { setBackupContent(value); }
        }


        private string getBackupContent()
        {
            BackupContents bcs = new BackupContents();
            bcs.content = new List<BackupContent>();

            string contentStr = "";
            //数据备份
            BackupContent bc_dmp = new BackupContent();
            bc_dmp.Name = "dmp";
            bc_dmp.Type = new List<BackupContentType>();

            if (this.treeView1.Nodes[0].Nodes.Count > 0)
            {

                foreach (TreeNode tn in treeView1.Nodes[0].Nodes)
                {
                    if (tn.Checked == true)
                    {
                        BackupContentType type_dmp = new BackupContentType();
                        type_dmp.Name = (tn.Tag as DbUser).Name;
                        type_dmp.Type = (tn.Tag as DbUser).GetType().ToString();
                        type_dmp.Set = new List<BackupContentSet>();
                        if (tn.Nodes != null)
                        {
                            foreach (TreeNode tablenode in tn.Nodes)
                            {
                                if(tablenode.Tag.ToString()=="remoteInfo"){
                                    BackupContentSet bcs_table = new BackupContentSet();
                                    bcs_table.SetKey = "remoteInfo";
                                    bcs_table.SetValue = tablenode.Text;
                                    type_dmp.Set.Add(bcs_table);
                                }
                                else if (tablenode.Tag.ToString() == "excludeTable")
                                {
                                    BackupContentSet bcs_table = new BackupContentSet();
                                    bcs_table.SetKey = "excludeTable";
                                    bcs_table.SetValue = tablenode.Text;
                                    type_dmp.Set.Add(bcs_table);                                
                                }                               
                            }
                        }
                        bc_dmp.Type.Add(type_dmp);
                    }
                }

            }
            bcs.content.Add(bc_dmp);

            //程序备份
            BackupContent bc_app = new BackupContent();
            bc_app.Name = "app";
            bc_app.Type = new List<BackupContentType>();
            if (this.treeView2.Nodes[0].Nodes.Count > 0)
            {
                foreach (TreeNode tn in treeView2.Nodes[0].Nodes)
                {
                    if (tn.Checked == true)
                    {
                        BackupContentType type_app = new BackupContentType();
                        if(tn.Tag is ServiceApp){
                            type_app.Name = (tn.Tag as ServiceApp).Name;
                            type_app.Type = (tn.Tag as ServiceApp).GetType().ToString();
                        }else if(tn.Tag is WebApp){
                            type_app.Name = (tn.Tag as WebApp).Name;
                            type_app.Type = (tn.Tag as WebApp).GetType().ToString();
                        }
                        else if (tn.Tag is App)
                        {
                            type_app.Name = (tn.Tag as App).Name;
                            type_app.Type = (tn.Tag as App).GetType().ToString();
                        }
                        else if (tn.Tag is Ftp)
                        {
                            type_app.Name = (tn.Tag as Ftp).Name;
                            type_app.Type = (tn.Tag as Ftp).GetType().ToString();
                        }
                        else if (tn.Tag is Gxml)
                        {
                            type_app.Name = (tn.Tag as Gxml).Name;
                            type_app.Type = (tn.Tag as Gxml).GetType().ToString();
                        }
                       
                        type_app.Set = new List<BackupContentSet>();
                        if (tn.Nodes != null)
                        {
                            foreach (TreeNode tablenode in tn.Nodes)
                            {
                                if (tablenode.Tag.ToString()=="folder")
                                {
                                    BackupContentSet bcs_table = new BackupContentSet();
                                    bcs_table.SetKey = "excludeFolder";
                                    bcs_table.SetValue = tablenode.Text;
                                    type_app.Set.Add(bcs_table);
                                }
                                else if (tablenode.Tag.ToString()=="file")
                                {
                                    BackupContentSet bcs_table = new BackupContentSet();
                                    bcs_table.SetKey = "excludeFile";
                                    bcs_table.SetValue = tablenode.Text;
                                    type_app.Set.Add(bcs_table);
                                }
                            }
                        }
                        bc_app.Type.Add(type_app);
                    }
                }

            }
            bcs.content.Add(bc_app);

            //sde备份
            BackupContent bc_sde = new BackupContent();
            bc_sde.Name = "sde";
            bc_sde.Type = new List<BackupContentType>();
            if (this.treeView3.Nodes[0].Nodes.Count > 0)
            {
                foreach (TreeNode tn in treeView3.Nodes[0].Nodes)
                {
                    if (tn.Checked == true)
                    {
                        BackupContentType type_sde = new BackupContentType();
                        type_sde.Name = (tn.Tag as DbSdeUser).Name;
                        type_sde.Type = (tn.Tag as DbSdeUser).GetType().ToString();
                        type_sde.Set = new List<BackupContentSet>();

                        bc_sde.Type.Add(type_sde);
                    }
                }
            }
            bcs.content.Add(bc_sde);

            return contentStr = JsonClassHelper.Class2Json<BackupContents>(bcs);
        }

        private void setBackupContent(string backupContent)
        {

            BackupContents bcs = new BackupContents();
            try
            {
                bcs = JsonClassHelper.Json2Class<BackupContents>(backupContent);
            }catch(Exception eg){
                return;
            }

            if(bcs==null||bcs.content==null){
                return;
            }

            foreach(BackupContent bc in bcs.content){
                TreeView tv = new TreeView();
                if (bc.Name == "dmp")
                {
                    tv = treeView1;                   

                }
                else if (bc.Name == "app")
                {
                    tv = treeView2;
                }
                else if (bc.Name == "sde")
                {
                    tv = treeView3;
                }

                foreach (BackupContentType bct in bc.Type)
                {
                    foreach (TreeNode tn in tv.Nodes[0].Nodes)
                    {
                        string name="";
                        if (tn.Tag is ServiceApp) {
                            name = (tn.Tag as ServiceApp).Name;
                        }
                        else if (tn.Tag is WebApp)
                        {
                            name = (tn.Tag as WebApp).Name;
                        
                        }
                        else if (tn.Tag is App)
                        {
                            name = (tn.Tag as App).Name;

                        }
                        else if (tn.Tag is Ftp)
                        {
                            name = (tn.Tag as Ftp).Name;

                        }
                        else if (tn.Tag is Gxml)
                        {
                            name = (tn.Tag as Gxml).Name;

                        }
                        else if (tn.Tag is DbUser)
                        {
                            name = (tn.Tag as DbUser).Name;

                        }
                        else if (tn.Tag is DbSdeUser)
                        {
                            name = (tn.Tag as DbSdeUser).Name;

                        }

                        if (name == bct.Name)
                        {
                            tn.Checked = true;

                            if (bct.Set != null && bct.Set.Count > 0)
                            {
                                tn.Nodes.Clear();
                                foreach (BackupContentSet set in bct.Set)
                                {
                                   
                                        TreeNode node = new TreeNode(set.SetValue);
                                        node.Tag = set.SetKey;
                                        node.ForeColor = Color.Red;
                                        node.Checked = true;
                                        tn.Nodes.Add(node);
                                        tn.Expand();                                  

                                }
                            }

                        }
                    }

                }               
            
            }        

        }

        private void chooseNode(TreeNode tnode)
        {
            var selectedNode = tnode;

            if (selectedNode != null)
            {

                bool choose = selectedNode.Checked;

                if (selectedNode.Nodes.Count > 0)
                {
                    foreach (TreeNode tn in selectedNode.Nodes)
                    {
                        tn.Checked = choose;

                    }
                }
                if (selectedNode.Parent != null)
                {
                    int selectCount = 0;
                    foreach (TreeNode tn in selectedNode.Parent.Nodes)
                    {
                        if (tn.Checked)
                        {
                            selectCount += 1;
                        }
                    }
                    if (selectCount != selectedNode.Parent.Nodes.Count)
                    {
                        selectedNode.Parent.Checked = false;
                    }
                    else
                    {
                        selectedNode.Parent.Checked = true;
                    }
                }
            }

        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            chooseNode(e.Node);
        }

        private void treeView2_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            chooseNode(e.Node);
        }

        private void treeView3_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            chooseNode(e.Node);
        }


        private void setContextMenuStripShow(string type)
        {
            foreach (ToolStripItem tsi in this.contextMenuStrip1.Items)
            {
                tsi.Visible = true;
            }
            if (type == "dmp")
            {
                foreach (ToolStripItem tsi in this.contextMenuStrip1.Items)
                {
                    tsi.Visible = false;
                }
                this.contextMenuStrip1.Items[1].Visible = true;

            }
            else if (type == "file")
            {
                foreach (ToolStripItem tsi in this.contextMenuStrip1.Items)
                {
                    tsi.Visible = false;
                }
                this.contextMenuStrip1.Items[0].Visible = true;

            }
            else if (type == "delete")
            {
                foreach (ToolStripItem tsi in this.contextMenuStrip1.Items)
                {
                    tsi.Visible = false;
                }
                this.contextMenuStrip1.Items[2].Visible = true;
            }

            else if (type == "none")
            {

                foreach (ToolStripItem tsi in this.contextMenuStrip1.Items)
                {
                    tsi.Visible = false;
                }
            }
        }


        private void BackupSet_ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string btnstr = (sender as ToolStripItem).Text;

            if (btnstr == "排除文件/文件夹")
            {
                TreeNode selectedtn = selectTreeview.SelectedNode;

                List<string> hasSetFolderList = new List<string>();
                foreach (TreeNode tn in selectedtn.Nodes)
                {
                    if (tn.Tag.ToString() == "excludeFolder")
                    {
                        hasSetFolderList.Add(tn.Text);
                    }
                }

                List<string> hasSetFileList = new List<string>();
                foreach (TreeNode tn in selectedtn.Nodes)
                {
                    if (tn.Tag.ToString() == "excludeFile")
                    {
                        hasSetFileList.Add(tn.Text);
                    }
                }

                Form form = new Form();
                backupFolderSelect bfs = new backupFolderSelect();
                if(selectedtn.Tag is ServiceApp){
                    bfs.folderPath = (selectedtn.Tag as ServiceApp).Path;
                }
                else if (selectedtn.Tag is WebApp)
                {
                    bfs.folderPath = (selectedtn.Tag as WebApp).Path;
                }
                else if (selectedtn.Tag is App)
                {
                    bfs.folderPath = (selectedtn.Tag as App).Path;
                }
                else if (selectedtn.Tag is Ftp)
                {
                    bfs.folderPath = (selectedtn.Tag as Ftp).Path;
                }
                else if (selectedtn.Tag is Gxml)
                {
                    bfs.folderPath = (selectedtn.Tag as Gxml).Path;
                }
               
                bfs.setFileList();
                bfs.chooseFolder = hasSetFolderList;
                bfs.chooseFile = hasSetFileList;
                form.Controls.Add(bfs);
                form.SetBounds(120, 10, 520, 550);
                form.Text = "选择要排除的文件/文件夹";

                if (form.ShowDialog() == DialogResult.OK)
                {
                    List<string> listfile = bfs.chooseFile;
                    List<string> listfolder = bfs.chooseFolder;

                    selectedtn.Nodes.Clear();

                    foreach (string folder in listfolder)
                    {
                        TreeNode addtn = new TreeNode(folder);
                        addtn.ForeColor = Color.Red;
                        addtn.Tag = "excludeFolder";
                        addtn.Checked = true;
                        selectedtn.Nodes.Add(addtn);

                    }
                    foreach (string file in listfile)
                    {
                        TreeNode addtn = new TreeNode(file);
                        addtn.ForeColor = Color.Red;
                        addtn.Tag = "excludeFile";
                        addtn.Checked = true;
                        selectedtn.Nodes.Add(addtn);
                    }

                    selectedtn.Expand();
                }

            }

            else if (btnstr == "排除表")
            {
                TreeNode selectedtn = selectTreeview.SelectedNode;

                List<string> hasSetTableList = new List<string>();
                string hasRemoteInfo = "";
                foreach (TreeNode tn in selectedtn.Nodes)
                {
                    if(tn.Tag.ToString()=="excludeTable"){
                        hasSetTableList.Add(tn.Text);
                    }
                    else if (tn.Tag.ToString() == "remoteInfo")
                    {
                        hasRemoteInfo = tn.Text;
                    }
                }

                Form form = new Form();
                backupTableSelect bts = new backupTableSelect();
                bts.dbuser = selectedtn.Tag as DbUser;
                bts.datasource = selectedtn.ToolTipText;
                bts.setTables();
                bts.chooseTables = hasSetTableList;
                bts.remoteInfo = hasRemoteInfo;
                form.Controls.Add(bts);
                form.SetBounds(120, 40, 320, 560);
                form.Text = "选择要排除表";
                List<string> tableList = new List<string>();
                if (form.ShowDialog() == DialogResult.OK)
                {
                    selectedtn.Nodes.Clear();
                    string remoteInfo = bts.remoteInfo;
                    TreeNode infonode = new TreeNode(remoteInfo);
                    infonode.Tag = "remoteInfo";
                    infonode.ForeColor = Color.Red;
                    infonode.Checked = true;
                    selectedtn.Nodes.Add(infonode);
                    selectedtn.Expand();

                    tableList = bts.chooseTables;
                    
                    foreach (string tnname in tableList)
                    {
                        TreeNode addtn = new TreeNode(tnname);
                        addtn.Tag = "excludeTable";
                        addtn.ForeColor = Color.Red;
                        addtn.Checked = true;
                        selectedtn.Nodes.Add(addtn);
                        selectedtn.Expand();
                    }
                }
            }
        }

        private TreeView selectTreeview;

        private void treeView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)//获取鼠标右键点击
            {
                Point ClickPoint = new Point(e.X, e.Y);
                TreeNode CurrentNode = (sender as TreeView).GetNodeAt(ClickPoint);
                if (CurrentNode != null && CurrentNode.Parent != null)//当前节点不为空
                {
                    if (CurrentNode.Parent.Text == "数据库备份")
                    {
                        setContextMenuStripShow("dmp");
                    }

                    else if (CurrentNode.Parent.Text == "程序备份")
                    {
                        setContextMenuStripShow("file");
                    }
                    else if (CurrentNode.Parent.Text != "程序备份" && CurrentNode.Parent.Text != "数据库备份" && CurrentNode.Parent.Text != "空间库备份")
                    {
                        setContextMenuStripShow("delete");
                    }
                    else
                    {
                        setContextMenuStripShow("none");
                    }
                    CurrentNode.ContextMenuStrip = this.contextMenuStrip1;
                    (sender as TreeView).SelectedNode = CurrentNode;//重新选
                    selectTreeview = sender as TreeView;
                }
            }
        }



        private void BackupSet_delete_ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string btnstr = (sender as ToolStripItem).Text;
            TreeNode tn = selectTreeview.SelectedNode;
            TreeNode pretn = tn.Parent;
            pretn.Nodes.Remove(tn);

        }

    }
}
