using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace QuickConfig.OneKeyInstall
{
    public partial class StartAgree : UserControl
    {
        public StartAgree()
        {
            InitializeComponent();
        }

        public int hideCode = 0;

        public bool isRead {
            get { return this.txCheckBox1.Checked; }        
        }

        public delegate void ShowDelegate();
        public event ShowDelegate show;

        public delegate void hideDelegate();
        public event hideDelegate hide;

        private void txButton1_Click(object sender, EventArgs e)
        {
            if (hideCode == 0)
            {
                show();
                hideCode = 1;
            }
            else {
                hide();
                hideCode = 0;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string filepath=AppDomain.CurrentDomain.BaseDirectory+"installConfig\\使用协议.rtf";
            ReadLicense rl = new ReadLicense();
            rl.setContent(filepath);
            rl.ShowDialog();
           
        }

       
    }
}
