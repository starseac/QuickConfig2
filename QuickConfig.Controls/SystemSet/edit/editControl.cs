using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuickConfig.Controls.SystemSet.edit
{
    public partial class editControl : UserControl
    {
        public editControl()
        {
            InitializeComponent();
        }

       // public void setValue(Object obj) { }

        public bool isNew;

        public Object getValue() {
            Object obj = new object();

            return obj;
        }
    }
}
