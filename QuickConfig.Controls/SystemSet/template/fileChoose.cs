using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuickConfig.Controls.SystemSet.template
{
    public partial class fileChoose : UserControl
    {
        public fileChoose()
        {
            InitializeComponent();
        }


        public string Path {
            get { return this.txt_path.Text; }
            set { this.txt_path.Text = value;}        
        
        }

        public string ImportPath;

        public List<string> checkFileList;

        private void laodFolderFile(string folderPath) { 
        
        
        
        
        }


        private void getCheckFileList() { 
                
        
        
        }

        private void btn_brower_Click(object sender, EventArgs e)
        {

        }

        private void btn_load_Click(object sender, EventArgs e)
        {

        }

        private void btn_confim_Click(object sender, EventArgs e)
        {

        }






    }
}
