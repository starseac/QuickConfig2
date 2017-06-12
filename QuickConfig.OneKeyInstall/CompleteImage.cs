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
    public partial class CompleteImage : UserControl
    {
        public CompleteImage()
        {
            InitializeComponent();
            loadImage();
        }

        private void loadImage()
        {
           this.BackgroundImage = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "Images\\complete.jpg");
        }
    }
}
