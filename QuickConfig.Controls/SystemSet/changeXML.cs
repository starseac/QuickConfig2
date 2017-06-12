using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace QuickConfig.Controls.SystemSet
{
    public partial class changeXML : Form
    {
        public changeXML()
        {
            InitializeComponent();
            SetItems();
           
        }

        private void SetItems() {
            listBox1.Items.Clear();
            DirectoryInfo TheFolder = new DirectoryInfo(Common.getConfigFolder());
            //遍历文件夹
            foreach (FileInfo NextFile in TheFolder.GetFiles("*.xml"))
            {
                 if(NextFile.Name!="copyPath.xml"){

                     listBox1.Items.Add( NextFile.Name.Split('.')[0]);
                 }  
            }
            
        }

        public int ItemCount {
            get { return this.listBox1.Items.Count; }
        }

        public string selectName="";

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
             selectName=this.listBox1.SelectedItem.ToString();
             this.DialogResult = DialogResult.OK;
             this.Close();

        }
    }
}
