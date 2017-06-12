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
    public partial class ReadLicense :Form
    {
        public ReadLicense()
        {
            InitializeComponent();
        }

        public void setContent(string rtfPath) {
            this.richTextBox1.LoadFile(rtfPath);
        }
    }
}
