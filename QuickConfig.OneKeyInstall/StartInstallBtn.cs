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
    public partial class StartInstallBtn : UserControl
    {
        public StartInstallBtn()
        {
            InitializeComponent();
        }

        public StartAgree startAgree;

        public delegate void SaveConfigDelegate();
        public event SaveConfigDelegate save;

        public delegate void ShowDelegate();
        public event ShowDelegate show;     

        private void txButton1_Click(object sender, EventArgs e)
        {
            if (startAgree.isRead)
            {

                save();
                show();
            }
            else {

                MessageBox.Show("请阅读完许可协议,并点击同意!");
            }
        }
    }
}
