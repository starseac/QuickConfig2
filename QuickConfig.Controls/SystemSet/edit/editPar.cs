using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuickConfig.Model.app;
using QuickConfig.Model.pars;

namespace QuickConfig.Controls.SystemSet
{
    public partial class editPar : UserControl
    {
        public editPar()
        {
            InitializeComponent();
        }

        public void setValue(Par par)
        {
            this.txt_key.Text = par.Key;
            this.txt_label.Text = par.Label;
            this.txt_value.Text = par.Value;
        }

        public bool isNew;

        public Object getValue()
        {
            Par par = new Par();
            par.Key = this.txt_key.Text;
            par.Label = this.txt_label.Text;
            par.Value = this.txt_value.Text;
            return par;

        }
    }
}
