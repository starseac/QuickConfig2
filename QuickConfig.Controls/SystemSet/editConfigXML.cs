using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuickConfig.Common;
using System.IO;
using QuickConfig.Model;
using QuickConfig.Model.db;
using QuickConfig.Model.pars;
using QuickConfig.Model.definebtns;
using QuickConfig.Model.app;
using QuickConfig.Model.backup;
using QuickConfig.Controls.SystemSet.show;
using QuickConfig.Controls.SystemSet.template;
using QuickConfig.Controls.SystemSet.edit;

namespace QuickConfig.Controls.SystemSet
{
    public partial class editConfigXML : Form
    {
        public editConfigXML()
        {
            InitializeComponent();
            setAppShow();
            SetItems();
        }

        private void SetItems()
        {
            this.configList.Items.Clear();
            this.cb_configlist.Items.Clear();
            DirectoryInfo TheFolder = new DirectoryInfo(Common.getConfigFolder());
            //遍历文件夹
            foreach (FileInfo NextFile in TheFolder.GetFiles("*.xml"))
            {
                if (NextFile.Name != "copyPath.xml")
                {

                    configList.Items.Add(NextFile.Name.Split('.')[0]);
                    cb_configlist.Items.Add(NextFile.Name.Split('.')[0]);
                }
            }

        }

        private void loadXMLTree(Set set)
        {
            this.treeView1.Nodes.Clear();
            if (set.Apps != null)
            {
                TreeNode tn = new TreeNode("程序");
                tn.Tag = set.Apps;
                foreach (ServiceApp serviceapp in set.Apps.ServiceAppList)
                {
                    TreeNode tn1 = new TreeNode("服务程序(" + serviceapp.Label + ")");
                    tn1.Tag = serviceapp;
                    tn.Nodes.Add(tn1);

                }
                foreach (WebApp webapp in set.Apps.WebAppList)
                {
                    TreeNode tn1 = new TreeNode("网站程序(" + webapp.Label + ")");
                    tn1.Tag = webapp;
                    tn.Nodes.Add(tn1);

                    if(webapp.VirtualDirList!=null&&webapp.VirtualDirList.Count>0){
                        foreach(WebAppVirtualDir virtualdir in webapp.VirtualDirList){
                            TreeNode tn2 = new TreeNode("虚拟目录(" + virtualdir.VirtualName+")");
                            tn2.Tag = virtualdir;
                            tn1.Nodes.Add(tn2);
                        }
                    }

                }
                foreach (App app in set.Apps.AppList)
                {
                    TreeNode tn1 = new TreeNode("桌面程序(" + app.Label + ")");
                    tn1.Tag = app;
                    tn.Nodes.Add(tn1);

                }
                foreach (Ftp ftp in set.Apps.FtpList)
                {
                    TreeNode tn1 = new TreeNode("FTP站点(" + ftp.Label + ")");
                    tn1.Tag = ftp;
                    tn.Nodes.Add(tn1);

                }
                foreach (Gxml gxml in set.Apps.GxmlList)
                {
                    TreeNode tn1 = new TreeNode("共享目录(" + gxml.Label + ")");
                    tn1.Tag = gxml;
                    tn.Nodes.Add(tn1);

                }


                treeView1.Nodes.Add(tn);
            }


            if (set.Db != null)
            {
                TreeNode tn = new TreeNode("数据库");
                tn.Tag = set.Db;
                DbSystemUser dsu = set.Db.DbSystemUser;
                if (dsu != null)
                {
                    TreeNode tn1 = new TreeNode("管理员(" + dsu.Label + ")");
                    tn1.Tag = dsu;
                    tn.Nodes.Add(tn1);

                }
                foreach (DbUser du in set.Db.DbUserList)
                {
                    TreeNode tn1 = new TreeNode("普通用户(" + du.Label + ")");
                    tn1.Tag = du;
                    tn.Nodes.Add(tn1);

                }
                foreach (DbSdeUser sdeuser in set.Db.DbSdeUserList)
                {
                    TreeNode tn1 = new TreeNode("SDE用户(" + sdeuser.Label + ")");
                    tn1.Tag = sdeuser;
                    tn.Nodes.Add(tn1);

                }


                treeView1.Nodes.Add(tn);
            }

            if (set.Pars != null)
            {
                TreeNode tn = new TreeNode("其他参数");
                tn.Tag = set.Pars;
                foreach (Par par in set.Pars.ParList)
                {
                    TreeNode tn1 = new TreeNode("参数(" + par.Label + ")");
                    tn1.Tag = par;
                    tn.Nodes.Add(tn1);

                }


                treeView1.Nodes.Add(tn);
            }

            if (set.Definebtns != null)
            {
                TreeNode tn = new TreeNode("其他工具");
                tn.Tag = set.Definebtns;
                foreach (Btn btn in set.Definebtns.BtnList)
                {
                    TreeNode tn1 = new TreeNode("工具(" + btn.Desc + ")");
                    tn1.Tag = btn;
                    tn.Nodes.Add(tn1);
                    foreach (Input input in btn.InputList)
                    {
                        TreeNode tn2 = new TreeNode("参数(" + input.Label + ")");
                        tn2.Tag = input;
                        tn1.Nodes.Add(tn2);

                    }

                }

                treeView1.Nodes.Add(tn);
            }

            if (set.Backup != null)
            {
                TreeNode tn = new TreeNode("备份");
                tn.Tag = set.Backup;

                treeView1.Nodes.Add(tn);
            }

            treeView1.ExpandAll();

        }

        private void configList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string appname = this.configList.SelectedItem.ToString();
            Set configset = setXml.getConfig(appname);
            loadXMLTree(configset);
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            this.btnNodeSave.Visible = true;
            TreeNode tn = e.Node as TreeNode;
            if (tn.Tag is Apps)
            {
                editApps editapps = new editApps();
                editapps.setValue(tn.Tag as Apps);
                this.panel1.Controls.Clear();
                this.panel1.Controls.Add(editapps);
            }
            else if (tn.Tag is ServiceApp)
            {
                editServiceApp editapps = new editServiceApp();
                editapps.setValue(tn.Tag as ServiceApp);
                this.panel1.Controls.Clear();
                this.panel1.Controls.Add(editapps);

            }
            else if (tn.Tag is WebApp)
            {
                editWebApp editapps = new editWebApp();
                editapps.setValue(tn.Tag as WebApp);
                this.panel1.Controls.Clear();
                this.panel1.Controls.Add(editapps);

            }
            else if (tn.Tag is WebAppVirtualDir)
            {
                editWebAppVirtualDirctory editapps = new editWebAppVirtualDirctory();
                editapps.setValue(tn.Tag as WebAppVirtualDir);
                this.panel1.Controls.Clear();
                this.panel1.Controls.Add(editapps);

            }
            else if (tn.Tag is App)
            {
                editApp editapps = new editApp();
                editapps.setValue(tn.Tag as App);
                this.panel1.Controls.Clear();
                this.panel1.Controls.Add(editapps);

            }
            else if (tn.Tag is Ftp)
            {
                editFtp editapps = new editFtp();
                editapps.setValue(tn.Tag as Ftp);
                this.panel1.Controls.Clear();
                this.panel1.Controls.Add(editapps);

            }
            else if (tn.Tag is Gxml)
            {
                editGxml editapps = new editGxml();
                editapps.setValue(tn.Tag as Gxml);
                this.panel1.Controls.Clear();
                this.panel1.Controls.Add(editapps);

            }
            // 数据库
            else if (tn.Tag is Db)
            {
                editDb editapps = new editDb();
                editapps.setValue(tn.Tag as Db);
                this.panel1.Controls.Clear();
                this.panel1.Controls.Add(editapps);

            }
            else if (tn.Tag is DbSystemUser)
            {
                editDbSystemUser editapps = new editDbSystemUser();
                editapps.setValue(tn.Tag as DbSystemUser);
                this.panel1.Controls.Clear();
                this.panel1.Controls.Add(editapps);

            }
            else if (tn.Tag is DbUser)
            {
                editDbUser editapps = new editDbUser();
                editapps.setValue(tn.Tag as DbUser);
                this.panel1.Controls.Clear();
                this.panel1.Controls.Add(editapps);

            }
            else if (tn.Tag is DbSdeUser)
            {
                editDbSdeUser editapps = new editDbSdeUser();
                editapps.setValue(tn.Tag as DbSdeUser);
                this.panel1.Controls.Clear();
                this.panel1.Controls.Add(editapps);

            }
            //参数
            else if (tn.Tag is Par)
            {
                editPar editapps = new editPar();
                editapps.setValue(tn.Tag as Par);
                this.panel1.Controls.Clear();
                this.panel1.Controls.Add(editapps);

            }

          // 自定义工具
            else if (tn.Tag is Btn)
            {
                editBtn editapps = new editBtn();
                editapps.setValue(tn.Tag as Btn);
                this.panel1.Controls.Clear();
                this.panel1.Controls.Add(editapps);

            }
            else if (tn.Tag is Input)
            {
                editBtnInput editapps = new editBtnInput();
                editapps.setValue(tn.Tag as Input);
                this.panel1.Controls.Clear();
                this.panel1.Controls.Add(editapps);

            }
            //备份
            else if (tn.Tag is Backup)
            {
                editBackup editapps = new editBackup();
                editapps.setValue(tn.Tag as Backup);
                this.panel1.Controls.Clear();
                this.panel1.Controls.Add(editapps);

            }
            else
            {
                this.panel1.Controls.Clear();
                this.btnNodeSave.Visible = false;

            }


        }




        private void btnNodeSave_Click(object sender, EventArgs e)
        {
            string appname = this.configList.SelectedItem.ToString();
            Set configset = setXml.getConfig(appname);

            Control ctl = this.panel1.Controls[0];

            TreeNode tn = this.treeView1.SelectedNode;
            Object oldObj = tn.Tag;

            TreeNode pretn = tn.Parent;
            Object preObj = null;
            if (pretn != null)
            {
                preObj = pretn.Tag;
            }

            Object obj = null;
            bool isNew = false;

            if (ctl is editApps)
            {
                obj = (ctl as editApps).getValue();
                isNew = (ctl as editApps).isNew;

            }
            else if (ctl is editServiceApp)
            {
                obj = (ctl as editServiceApp).getValue();
                isNew = (ctl as editServiceApp).isNew;

            }
            else if (ctl is editWebApp)
            {
                obj = (ctl as editWebApp).getValue();
                isNew = (ctl as editWebApp).isNew;

            }
            else if (ctl is editWebAppVirtualDirctory)
            {
                obj = (ctl as editWebAppVirtualDirctory).getValue();
                isNew = (ctl as editWebAppVirtualDirctory).isNew;

            }
            else if (ctl is editApp)
            {
                obj = (ctl as editApp).getValue();
                isNew = (ctl as editApp).isNew;

            }
            else if (ctl is editFtp)
            {
                obj = (ctl as editFtp).getValue();
                isNew = (ctl as editFtp).isNew;

            }
            else if (ctl is editGxml)
            {
                obj = (ctl as editGxml).getValue();
                isNew = (ctl as editGxml).isNew;

            }
            else if (ctl is editDb)
            {
                obj = (ctl as editDb).getValue();
                isNew = (ctl as editDb).isNew;

            }
            else if (ctl is editDbSystemUser)
            {
                obj = (ctl as editDbSystemUser).getValue();
                isNew = (ctl as editDbSystemUser).isNew;

            }
            else if (ctl is editDbUser)
            {
                obj = (ctl as editDbUser).getValue();
                isNew = (ctl as editDbUser).isNew;

            }
            else if (ctl is editDbSdeUser)
            {
                obj = (ctl as editDbSdeUser).getValue();
                isNew = (ctl as editDbSdeUser).isNew;

            }
            else if (ctl is editPar)
            {
                obj = (ctl as editPar).getValue();
                isNew = (ctl as editPar).isNew;

            }
            else if (ctl is editBtn)
            {
                obj = (ctl as editBtn).getValue();
                isNew = (ctl as editBtn).isNew;

            }
            else if (ctl is editBtnInput)
            {
                obj = (ctl as editBtnInput).getValue();
                isNew = (ctl as editBtnInput).isNew;

            }
            else if (ctl is editBackup)
            {
                obj = (ctl as editBackup).getValue();
                isNew = (ctl as editBackup).isNew;

            }



            if (isNew)
            {
                if (obj is ServiceApp || obj is WebApp || obj is App || obj is Ftp || obj is Gxml || obj is DbSystemUser || obj is DbUser || obj is DbSdeUser || obj is Par || obj is Btn)
                {
                    configset.addObject(obj);
                }
                else if (obj is Input)
                {
                    configset.addBtnInput(oldObj as Btn, obj as Input);
                }
                else if (obj is WebAppVirtualDir)
                {
                    configset.addVirtualDir(oldObj as WebApp, obj as WebAppVirtualDir);
                }
            }
            else
            {
                if (obj is Apps)
                {
                    configset.setApps(obj as Apps);

                }
                else if (obj is Db)
                {
                    configset.setDb(obj as Db);

                }
                else if (obj is Backup)
                {
                    configset.setBackup(obj as Backup);

                }
                else if (obj is ServiceApp || obj is WebApp || obj is App || obj is Ftp || obj is Gxml || obj is DbSystemUser || obj is DbUser || obj is DbSdeUser || obj is Par || obj is Btn)
                {
                    configset.editObject(oldObj, obj);
                }
                else if (obj is Input)
                {
                    configset.editBtnInput(preObj as Btn, oldObj as Input, obj as Input);
                }
                else if (obj is WebAppVirtualDir)
                {
                    configset.editVirtualDir(preObj as WebApp, oldObj as WebAppVirtualDir, obj as WebAppVirtualDir);
                }

            }

            MessageBox.Show("保存成功!");



            setXml.saveConfig(appname, configset);
            configset = setXml.getConfig(appname);
            loadXMLTree(configset);

            this.btnNodeSave.Visible = false;
            this.panel1.Controls.Clear();
        }

        private void setContextMenuStripShow(string type)
        {
            foreach (ToolStripItem tsi in this.contextMenuStrip1.Items)
            {
                tsi.Visible = true;
            }
            if (type == "node")
            {
                foreach (ToolStripItem tsi in this.contextMenuStrip1.Items)
                {
                    tsi.Visible = false;
                }
                this.contextMenuStrip1.Items[0].Visible = true;
            }
            else if (type == "apps")
            {
                foreach (ToolStripItem tsi in this.contextMenuStrip1.Items)
                {
                    tsi.Visible = false;
                }
                this.contextMenuStrip1.Items[1].Visible = true;
                this.contextMenuStrip1.Items[2].Visible = true;
                this.contextMenuStrip1.Items[3].Visible = true;
                this.contextMenuStrip1.Items[4].Visible = true;
                this.contextMenuStrip1.Items[5].Visible = true;

            }
            else if (type == "db")
            {
                foreach (ToolStripItem tsi in this.contextMenuStrip1.Items)
                {
                    tsi.Visible = false;
                }
                this.contextMenuStrip1.Items[6].Visible = true;
                this.contextMenuStrip1.Items[7].Visible = true;
                this.contextMenuStrip1.Items[8].Visible = true;

            }
            else if (type == "pars")
            {
                foreach (ToolStripItem tsi in this.contextMenuStrip1.Items)
                {
                    tsi.Visible = false;
                }
                this.contextMenuStrip1.Items[9].Visible = true;
            }
            else if (type == "definebtns")
            {
                foreach (ToolStripItem tsi in this.contextMenuStrip1.Items)
                {
                    tsi.Visible = false;
                }
                this.contextMenuStrip1.Items[10].Visible = true;
            }
            else if (type == "btn")
            {
                foreach (ToolStripItem tsi in this.contextMenuStrip1.Items)
                {
                    tsi.Visible = false;
                }
                this.contextMenuStrip1.Items[0].Visible = true;
                this.contextMenuStrip1.Items[11].Visible = true;
            }
            else if (type == "webapp")
            {
                foreach (ToolStripItem tsi in this.contextMenuStrip1.Items)
                {
                    tsi.Visible = false;
                }
                this.contextMenuStrip1.Items[0].Visible = true;
                this.contextMenuStrip1.Items[12].Visible = true;
            }
            else if (type == "none")
            {

                foreach (ToolStripItem tsi in this.contextMenuStrip1.Items)
                {
                    tsi.Visible = false;
                }
            }
        }

        private void treeView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)//获取鼠标右键点击
            {
                Point ClickPoint = new Point(e.X, e.Y);
                TreeNode CurrentNode = treeView1.GetNodeAt(ClickPoint);
                if (CurrentNode != null)//当前节点不为空
                {
                    if (CurrentNode.Parent == null)
                    {

                        if (CurrentNode.Tag is Apps)
                        {
                            setContextMenuStripShow("apps");
                        }
                       

                        else if (CurrentNode.Tag is Db)
                        {
                            setContextMenuStripShow("db");
                        }

                        else if (CurrentNode.Tag is Pars)
                        {
                            setContextMenuStripShow("pars");
                        }
                        else if (CurrentNode.Tag is Definebtns)
                        {
                            setContextMenuStripShow("definebtns");
                        }

                        else
                        {
                            setContextMenuStripShow("none");
                        }
                        CurrentNode.ContextMenuStrip = this.contextMenuStrip1;

                    }
                    else if (CurrentNode.Parent != null)
                    {
                        if (CurrentNode.Tag is WebApp)
                        {
                            setContextMenuStripShow("webapp");
                        }
                          else if (CurrentNode.Tag is Btn)
                        {
                            setContextMenuStripShow("btn");
                        }
                        else if (!(CurrentNode.Tag is Btn))
                        {
                            setContextMenuStripShow("node");
                        }
                       
                        else
                        {
                            setContextMenuStripShow("none");
                        }
                        CurrentNode.ContextMenuStrip = this.contextMenuStrip1;

                    }
                    treeView1.SelectedNode = CurrentNode;//重新选
                }
            }
        }

        private void Delete_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode tn = treeView1.SelectedNode;
            object obj = tn.Tag;
            TreeNode pretn = new TreeNode();
            if (tn.Parent != null)
            {
                pretn = tn.Parent;
            }
            Object preObj = pretn.Tag;

            string appname = this.configList.SelectedItem.ToString();
            Set configset = setXml.getConfig(appname);


            if (obj is ServiceApp || obj is WebApp || obj is App || obj is Ftp || obj is Gxml || obj is DbSystemUser || obj is DbUser || obj is DbSdeUser || obj is Par || obj is Btn)
            {
                configset.deleteObject(obj);
            }
            else if (obj is Input)
            {
                configset.deleteBtnInput(preObj as Btn, obj as Input);
            }
            else if (obj is WebAppVirtualDir)
            {
                configset.deleteVirtualDir(preObj as WebApp, obj as WebAppVirtualDir);
            }

            MessageBox.Show("删除成功");

            setXml.saveConfig(appname, configset);
            configset = setXml.getConfig(appname);
            loadXMLTree(configset);
        }

        private void makeConfigTemplate_Click(object sender, EventArgs e)
        {

        }

        private void Add_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode tn = this.treeView1.SelectedNode;
            string btnstr = (sender as ToolStripItem).Text;


            if (btnstr == "添加服务程序")
            {
                editServiceApp editapps = new editServiceApp();
                editapps.isNew = true;
                this.panel1.Controls.Clear();
                this.panel1.Controls.Add(editapps);

            }
            else if (btnstr == "添加网站程序")
            {
                editWebApp editapps = new editWebApp();
                editapps.isNew = true;
                this.panel1.Controls.Clear();
                this.panel1.Controls.Add(editapps);

            }
            else if (btnstr == "添加虚拟目录")
            {
                editWebAppVirtualDirctory editapps = new editWebAppVirtualDirctory();
                editapps.isNew = true;
                this.panel1.Controls.Clear();
                this.panel1.Controls.Add(editapps);

            }

            else if (btnstr == "添加桌面程序")
            {
                editApp editapps = new editApp();
                editapps.isNew = true;
                this.panel1.Controls.Clear();
                this.panel1.Controls.Add(editapps);

            }
            else if (btnstr == "添加FTP站点")
            {
                editFtp editapps = new editFtp();
                editapps.isNew = true;
                this.panel1.Controls.Clear();
                this.panel1.Controls.Add(editapps);

            }
            else if (btnstr == "添加共享目录")
            {
                editGxml editapps = new editGxml();
                editapps.isNew = true;
                this.panel1.Controls.Clear();
                this.panel1.Controls.Add(editapps);

            }
            // 数据库

            else if (btnstr == "设置管理员")
            {
                editDbSystemUser editapps = new editDbSystemUser();
                editapps.isNew = true;
                this.panel1.Controls.Clear();
                this.panel1.Controls.Add(editapps);

            }
            else if (btnstr == "添加普通用户")
            {
                editDbUser editapps = new editDbUser();
                editapps.isNew = true;
                this.panel1.Controls.Clear();
                this.panel1.Controls.Add(editapps);

            }
            else if (btnstr == "添加SDE用户")
            {
                editDbSdeUser editapps = new editDbSdeUser();
                editapps.isNew = true;
                this.panel1.Controls.Clear();
                this.panel1.Controls.Add(editapps);

            }
            //鍙傛暟
            else if (btnstr == "添加参数")
            {
                editPar editapps = new editPar();
                editapps.isNew = true;
                this.panel1.Controls.Clear();
                this.panel1.Controls.Add(editapps);

            }

          // 鑷畾涔夋寜閽?
            else if (btnstr == "添加工具")
            {
                editBtn editapps = new editBtn();
                editapps.isNew = true;
                this.panel1.Controls.Clear();
                this.panel1.Controls.Add(editapps);

            }
            else if (btnstr == "添加工具参数")
            {
                editBtnInput editapps = new editBtnInput();
                editapps.isNew = true;
                this.panel1.Controls.Clear();
                this.panel1.Controls.Add(editapps);

            }

            else
            {
                this.panel1.Controls.Clear();

            }

            this.btnNodeSave.Visible = true;
        }

        private void btnXmlAdd_Click(object sender, EventArgs e)
        {
            Set newSet = new Set();
            newSet.Apps = new Apps();
            newSet.Db = new Db();
            newSet.Pars = new Pars();
            newSet.Definebtns = new Definebtns();
            newSet.Backup = new Backup();

            setXml.saveConfig("test", newSet);

            SetItems();
            MessageBox.Show("新配置文件添加成功!");
        }

        private void btnXmlDelete_Click(object sender, EventArgs e)
        {
            string appname = this.configList.SelectedItem.ToString();
            if (appname != "")
            {
                setXml.deleteConfig(appname);
                SetItems();
                MessageBox.Show("配置文件" + appname + "删除成功!");
            }
            else
            {
                MessageBox.Show("配置文件" + appname + "删除失败!");
            }
        }


        private void setAppShow() {
           ConfigSet config= setXml.getAppConfig();

           foreach (ConfigPar par in config.ConfigParList)
           {
               showSet show = new showSet();
               show.setValue(par);
               this.flowLayoutPanel1.Controls.Add(show);           
            
            }
        
        }

        private void cb_configlist_SelectedIndexChanged(object sender, EventArgs e)
        {
            string appname = this.cb_configlist.SelectedItem.ToString();

            loadConfigTemplateFolder(appname);
            loadParsetList(appname);
        }

        private void loadConfigTemplateFolder(string configName){          

            configTree configtree = new configTree();
            configtree.ConfigName = configName;
            configtree.setValue();
            panel_tree.Controls.Clear();
            panel_tree.Controls.Add(configtree);
            configtree.Dock = DockStyle.Fill;
            
        
        }

        private void loadParsetList(string configName) {
            try
            {
                List<parset> pars = setXml.getPars(configName);               
                flowLayoutPanel_parset.Controls.Clear();
                foreach (parset parset in pars)
                {
                    parChoose parchoose = new parChoose();
                    parchoose.setValue(parset);
                    flowLayoutPanel_parset.Controls.Add(parchoose);                   
                }              
            }
            catch (Exception eg) {
                MessageBox.Show("请检查配置设置"+eg.Message);
            
            }
        }

        private void textBox2_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void textBox2_DragDrop(object sender, DragEventArgs e)
        {
            parChoose par = e.Data.GetData(e.Data.GetFormats()[0]) as parChoose;

            if (mousestop - mousestart >= 0)
            {

                textBox2.Text = textBox2.Text.Remove(selectionStartIndex, selectionLength).Insert(selectionStartIndex, par.Key);

            }
            else {
                textBox2.Text = textBox2.Text.Remove(selectionStartIndex + selectionLength, selectionLength*-1).Insert(selectionStartIndex + selectionLength, par.Key);
            
            }
        }

        private int selectionStartIndex = 0;
        private int selectionLength = 0;

        private int mousestart = 0;
        private int mousestop = 0;

        private void textBox2_MouseDown(object sender, MouseEventArgs e)
        {
            selectionStartIndex = textBox2.SelectionStart;
            this.label_startindex.Text = selectionStartIndex.ToString();

            mousestart = e.X;
        }

        private void textBox2_MouseUp(object sender, MouseEventArgs e)
        {
          //  selectionLength = textBox2.SelectionStart - this.textBox2.SelectedText>0?textBox2.SelectionStart - selectionStartIndex:0;
           // this.label_length.Text = selectionLength.ToString();

           

            mousestop = e.X;

            if (mousestop - mousestart >= 0)
            {
                selectionLength = this.textBox2.SelectedText.Length;
                this.label_length.Text = selectionLength.ToString();
            }
            else {
                selectionLength = this.textBox2.SelectedText.Length * -1;
                this.label_length.Text = selectionLength.ToString();
            }

            textBox2.Focus();
        }

        private void btn_addfolder_Click(object sender, EventArgs e)
        {
            Form form = new Form();

            addConfigFolder addconfigfolder = new addConfigFolder();
            addconfigfolder.ConfigName = this.cb_configlist.SelectedItem.ToString();
            addconfigfolder.loadAppList();
            form.SetBounds(100, 100, 300, 140);
            form.Controls.Add(addconfigfolder);
            
            form.ShowDialog();
           
        
        }

       
      
      
    }
}
