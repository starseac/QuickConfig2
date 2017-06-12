using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuickConfig.OneKeyInstall
{
    public partial class InstallImages : UserControl
    {
        public InstallImages()
        {
            InitializeComponent();

        }

        public string imageName {
            get { return this.pictureBox1.ImageLocation.Replace(AppDomain.CurrentDomain.BaseDirectory + "installShow\\","").Replace(".jpg", ""); }
            set { this.pictureBox1.ImageLocation = AppDomain.CurrentDomain.BaseDirectory+"installShow\\"+ value+".jpg"; }        
        }

        public delegate void changeImage();
        public event changeImage change;

        private void InstallImages_Load(object sender, EventArgs e)
        {
            change();
        }


    }
}
