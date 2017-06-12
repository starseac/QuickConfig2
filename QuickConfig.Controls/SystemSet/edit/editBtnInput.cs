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
    public partial class editBtnInput : UserControl
    {
        public editBtnInput()
        {
            InitializeComponent();
        }

        public void setValue(Input input)
        {
            this.txt_key.Text = input.Key;
            this.txt_label.Text = input.Label;
            this.txt_value.Text = input.Value;

        }

        public bool isNew;

        public Object getValue()
        {
            Input input = new Input();
            input.Key = this.txt_key.Text;
            input.Label = this.txt_label.Text;
            input.Value = this.txt_value.Text;
            return input;
        }
    }
}
