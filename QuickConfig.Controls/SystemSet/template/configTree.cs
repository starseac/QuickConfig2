using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace QuickConfig.Controls.SystemSet.template
{
    public partial class configTree : UserControl
    {
        public configTree()
        {
            InitializeComponent();
        }

        public string ConfigName;

        public void setValue()
        {
            string folderPath = Common.getConfigTemplateFolder() + "\\" + ConfigName;
           
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            foreach (string dirString in Directory.GetDirectories(folderPath))
            {
                DirectoryInfo dirinfo = new DirectoryInfo(dirString);
                TreeNode tn = new TreeNode("程序配置文件夹("+dirinfo.Name+")");
                tn.ForeColor = Color.Blue;              
                tn.Tag = dirinfo;
                treeView1.Nodes.Add(tn);

                scanFile(tn,dirString);
            }
            treeView1.ExpandAll();
        
        }

        private void scanFile(TreeNode tn, string folderPath)
        {
            foreach (string dirString in Directory.GetDirectories(folderPath))
            {
                DirectoryInfo dirinfo = new DirectoryInfo(dirString);
                TreeNode node = new TreeNode(dirinfo.Name);
                node.ForeColor = Color.YellowGreen;               
                node.Tag = dirinfo;
                scanFile(node, dirString);
                tn.Nodes.Add(node);
                
            }

            foreach(string fileString in Directory.GetFiles(folderPath)){
                FileInfo fileinfo = new FileInfo(fileString);
                TreeNode node = new TreeNode(fileinfo.Name);
                node.Tag = fileinfo;               
                tn.Nodes.Add(node);
            
            }
        }


        private void setContextMenuStripShow(string type)
        {
            foreach (ToolStripItem tsi in this.contextMenuStrip1.Items)
            {
                tsi.Visible = true;
            }
            if (type == "folder")
            {
                foreach (ToolStripItem tsi in this.contextMenuStrip1.Items)
                {
                    tsi.Visible = false;
                }
                this.contextMenuStrip1.Items[0].Visible = true;
                this.contextMenuStrip1.Items[1].Visible = true;
                this.contextMenuStrip1.Items[4].Visible = true;
            }
            else if (type == "childFolder")
            {
                foreach (ToolStripItem tsi in this.contextMenuStrip1.Items)
                {
                    tsi.Visible = false;
                }
                this.contextMenuStrip1.Items[1].Visible = true;
                this.contextMenuStrip1.Items[2].Visible = true;
                this.contextMenuStrip1.Items[3].Visible = true;
                this.contextMenuStrip1.Items[4].Visible = true;
               

            }
            else if (type == "file")
            {
                foreach (ToolStripItem tsi in this.contextMenuStrip1.Items)
                {
                    tsi.Visible = false;
                }
                this.contextMenuStrip1.Items[3].Visible = true;
                this.contextMenuStrip1.Items[4].Visible = true;
               

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
                   
                        if (CurrentNode.Tag is DirectoryInfo &&CurrentNode.Parent==null)
                        {
                            setContextMenuStripShow("folder");
                        }

                        else if (CurrentNode.Tag is DirectoryInfo && CurrentNode.Parent!=null)
                        {
                            setContextMenuStripShow("childFolder");
                        }

                        else if (CurrentNode.Tag is FileInfo)
                        {
                            setContextMenuStripShow("file");
                        }                      

                        else
                        {
                            setContextMenuStripShow("none");
                        }
                        CurrentNode.ContextMenuStrip = this.contextMenuStrip1;

                    
                    treeView1.SelectedNode = CurrentNode;//重新选
                }
            }
        }


        private void init_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new Form();            
            fileChoose filechoose = new fileChoose();
            form.Controls.Add(filechoose);
            form.SetBounds(100, 100, 380, 530);
            form.ShowDialog();
            
        }

        private void addFolder_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new Form();
            addConfigFolder addconfigfolder = new addConfigFolder();
            addconfigfolder.ConfigName = ConfigName;
            addconfigfolder.loadAppList();
            form.Controls.Add(addconfigfolder);
            form.SetBounds(100, 100, 300, 140);
            form.ShowDialog();
        }

        private void addFile_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new Form();
            fileChoose filechoose = new fileChoose();
            form.Controls.Add(filechoose);
            form.SetBounds(100, 100, 380, 530);
            form.ShowDialog();
        }

        private void reImport_ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void delet_ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
