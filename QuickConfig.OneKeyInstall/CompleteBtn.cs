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
    public partial class CompleteBtn : UserControl
    {
        public CompleteBtn()
        {
            InitializeComponent();
        }

        public delegate void closeHander();
        public event closeHander close;

        private void btnComplete_Click(object sender, EventArgs e)
        {
            close();
        }
    }
}
