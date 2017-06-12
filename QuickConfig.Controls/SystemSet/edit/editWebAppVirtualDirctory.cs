using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuickConfig.Model.app;

namespace QuickConfig.Controls.SystemSet.edit
{
    public partial class editWebAppVirtualDirctory : UserControl
    {
        public editWebAppVirtualDirctory()
        {
            InitializeComponent();
        }

        public void setValue(WebAppVirtualDir virtualDir)
        {
            this.txt_name.Text = virtualDir.Name;
            this.txt_virtualname.Text = virtualDir.VirtualName;
            this.txt_path.Text = virtualDir.Path;
           

        }

        public bool isNew;

        public Object getValue()
        {
            WebAppVirtualDir virtualDir = new WebAppVirtualDir();

            virtualDir.Name = this.txt_name.Text;
            virtualDir.VirtualName = this.txt_virtualname.Text;
            virtualDir.Path = this.txt_path.Text;
            return virtualDir;

        }
    }
}
