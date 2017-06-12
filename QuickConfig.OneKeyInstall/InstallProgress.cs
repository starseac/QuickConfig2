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
    public partial class InstallProgress : UserControl
    {
        public InstallProgress()
        {
            InitializeComponent();
        }

        public string MessageStr {
            get { return this.label1.Text; }
            set { this.label1.Text = value; }
        }

        public int ProgressValue {
            get { return this.progressBar1.Value; }
            set { this.progressBar1.Value = value;
                    this.label2.Text = value + "%";
            }
        
        }

       

        public delegate void InstallProgressDelegate();
        public event InstallProgressDelegate install;

        public delegate void SetShow(string message, int value);
        public void setVlaue(string message, int value)
        {
            this.MessageStr = message;
            this.ProgressValue = value;           

        }
       
        private void InstallProgress_Load(object sender, EventArgs e)
        {
            install();           
        }       

    }

    
}
