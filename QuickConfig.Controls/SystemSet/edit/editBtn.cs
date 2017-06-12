using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuickConfig.Model.app;
using QuickConfig.Model.definebtns;

namespace QuickConfig.Controls.SystemSet
{
    public partial class editBtn : UserControl
    {
        public editBtn()
        {
            InitializeComponent();
        }

        public void setValue(Btn btn)
        {
            this.txt_name.Text = btn.Name;
            this.txt_desc.Text = btn.Desc;
            this.txt_type.Text = btn.Type;
            this.txt_execuser.Text = btn.Execuser;
            this.txt_filename.Text = btn.Filename;
            this.txt_install.Checked = btn.Install;

        }

        public bool isNew;

        public Object getValue()
        {
            Btn btn = new Btn();
            btn.Name = this.txt_name.Text;
            btn.Desc = this.txt_desc.Text;
            btn.Type = this.txt_type.Text;
            btn.Execuser = this.txt_execuser.Text;
            btn.Filename = this.txt_filename.Text;
            btn.Install = this.txt_install.Checked;

            return btn;
        }
    }
}
