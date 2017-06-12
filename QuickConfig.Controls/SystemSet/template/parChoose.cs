using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuickConfig.Model;

namespace QuickConfig.Controls.SystemSet.template
{
    public partial class parChoose : UserControl
    {
        public parChoose()
        {
            InitializeComponent();
        }

        public string Key {
            get { return this.par_key.Text; }
        
        }

        public string Value
        {
            get { return this.par_value.Text; }
        }

        public void setValue(parset parset) {
            this.par_key.Text ="$"+parset.id + "." + parset.key;
            this.par_value.Text = parset.value;
        
        }

        private void par_value_MouseEnter(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(par_value, Value);
        }

        private void par_key_MouseEnter(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(par_key, Key);
        }

        private void parChoose_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button==MouseButtons.Left){

                this.DoDragDrop(this,DragDropEffects.Move|DragDropEffects.Copy);
            }
        }
    }
}
