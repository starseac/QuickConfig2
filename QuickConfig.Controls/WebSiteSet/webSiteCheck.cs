using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuickConfig.Controls.WebSiteSet
{
    public partial class webSiteCheck : UserControl
    {
        public webSiteCheck()
        {
            InitializeComponent();
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { this._name = value; }
        }


        public string Label
        {
            get { return this.checkBox1.Text; }
            set { this.checkBox1.Text = value; }
        }

        public bool Check
        {
            get { return this.checkBox1.Checked; }
            set { this.checkBox1.Checked = value; }
        }

    }
}
