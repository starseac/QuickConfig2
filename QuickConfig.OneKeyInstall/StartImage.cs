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
    public partial class StartImage : UserControl
    {
        public StartImage()
        {
            InitializeComponent();
            loadImage();
        }

        private void loadImage() {
            this.pictureBox1.ImageLocation = AppDomain.CurrentDomain.BaseDirectory + "Images\\start.jpg";        
        }
    }
}
