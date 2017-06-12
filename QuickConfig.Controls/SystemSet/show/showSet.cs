using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuickConfig.Model;
using QuickConfig.Common;

namespace QuickConfig.Controls.SystemSet.show
{
    public partial class showSet : UserControl
    {
        public showSet()
        {
            InitializeComponent();
        }

        private string _name;

        public string Name {
            get { return _name; }
            set { this._name = value; }
        
        }

        public void setValue(ConfigPar configpar) {
            this._name = configpar.Name;
            this.txt_desc.Text= configpar.Desc;
            this.txt_value.Checked = Convert.ToBoolean(configpar.Value);        
        }

        private void txt_value_CheckedChanged(object sender, EventArgs e)
        {
            ConfigSet appconfig = setXml.getAppConfig();
            appconfig.ConfigParList.Find((ConfigPar par) => par.Name == this._name).Value = this.txt_value.Checked.ToString();
            setXml.saveAppConfig(appconfig);
        }
    }
}
