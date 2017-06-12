using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuickConfig.Model.definebtns;

namespace QuickConfig.Controls.ToolSet
{
    public partial class InputSet : UserControl
    {
        public InputSet()
        {
            InitializeComponent();
        }

        private string _key;

        public string Key {
            get { return _key; }
            set { this._key = value; }
        
        }
        public string Label
        {
            get { return this.input_label.Text; }
            set { this.input_label.Text = value; }

        }
        public string Value
        {
            get { return this.input_value.Text; }
            set { this.input_value.Text = value; }

        }

        public void setValue(Input input) {
            this._key = input.Key;
            this.input_label.Text = input.Label;
            this.input_value.Text = input.Value;
        }
    }
}
