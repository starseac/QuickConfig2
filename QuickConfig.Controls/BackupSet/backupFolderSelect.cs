using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace QuickConfig.Controls.BackupSet
{
    public partial class backupFolderSelect : UserControl
    {
        public backupFolderSelect()
        {
            InitializeComponent();
        }

        public string folderPath;

        public List<string> chooseFolder
        {
            get { return getList("folder"); }
            set { bindList(value,"folder"); }

        }

        public List<string> chooseFile
        {
            get { return getList("file"); }
            set { bindList(value,"file"); }
        }

        private void showFileList(DirectoryInfo dirinfo, TreeNode tn)
        {
            foreach (DirectoryInfo folder in dirinfo.GetDirectories())
            {
                TreeNode node = new TreeNode(folder.Name);
                node.Tag = folder;
                tn.Nodes.Add(node);
                showFileList(folder, node);

            }

            foreach (FileInfo file in dirinfo.GetFiles())
            {
                TreeNode node = new TreeNode(file.Name);
                node.Tag = file;
                tn.Nodes.Add(node);
            }

        }


        public void setFileList()
        {
            if (Directory.Exists(folderPath))
            {
                TreeNode toptn = new TreeNode("程序文件");
                this.treeView1.Nodes.Clear();
                this.treeView1.Nodes.Add(toptn);
                DirectoryInfo dirinfo = new DirectoryInfo(folderPath);
                showFileList(dirinfo, toptn);
                this.treeView1.ExpandAll();
            }
            else
            {
                MessageBox.Show("没找到文件夹:" + folderPath);

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void findChecked(List<string> checkList, TreeNode tn, string type)
        {
            if (tn.Nodes != null)
            {
                foreach (TreeNode node in tn.Nodes)
                {
                    if (type == "folder")
                    {
                        if (node.Tag is DirectoryInfo && node.Checked)
                        {
                            checkList.Add((node.Tag as DirectoryInfo).FullName.Replace(folderPath, ""));

                        }
                    }
                    else if (type == "file")
                    {

                        if (node.Tag is FileInfo && node.Checked)
                        {
                            checkList.Add((node.Tag as FileInfo).FullName.Replace(folderPath, ""));

                        }

                    }

                    if (node.Nodes != null)
                    {
                        findChecked(checkList, node, type);
                    }

                }
            }
        }

        private List<string> getList(string type)
        {
            List<string> checkList = new List<string>();
            findChecked(checkList, treeView1.Nodes[0], type);
            return checkList;
        }


        private void bindSet(string xdPath, TreeNode tn, string type)
        {
            foreach (TreeNode node in tn.Nodes)
            {

                if (type == "folder")
                {
                    if (node.Tag is FileInfo)
                    {
                        continue;
                    }
                    else
                    {
                        if (folderPath + xdPath == (node.Tag as DirectoryInfo).FullName)
                        {
                            node.Checked = true;
                            break;
                        }
                        else
                        {
                            if (node.Nodes != null)
                            {
                                bindSet(xdPath, node, type);

                            }
                        }

                    }
                }
                else if (type == "file")
                {

                    if ((node.Tag is FileInfo) && (folderPath + xdPath == (node.Tag as FileInfo).FullName))
                    {
                        node.Checked = true;
                        break;
                    }
                    else
                    {
                        if (node.Nodes != null)
                        {
                            bindSet(xdPath, node, type);
                        }
                    }
                }
            }
        }

        private void bindList(List<string> checkList, string type)
        {
            foreach (string path in checkList)
            {
                bindSet(path, treeView1.Nodes[0], type);

            }

        }

    }
}
