using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuickConfig.Model.pars;

namespace QuickConfig.Controls.ParsSet
{
    public partial class parSet : UserControl
    {
        public parSet()
        {
            InitializeComponent();
        }  
    
      

        public string Label
        {
            get { return this.par_label.Text; }
            set { this.par_label.Text = value; }
        }

        private string _key;

        public string Key
        {
            get { return _key; }
            set { _key = value; }
        }

        public string Value
        {
            get { return this.par_value.Text; }
            set { this.par_value.Text = value; }
        }

        public void SetValue(Par par) {            
            this.par_label.Text = par.Label;
            this._key = par.Key;
            this.par_value.Text = par.Value;
        
        }

    }
}
