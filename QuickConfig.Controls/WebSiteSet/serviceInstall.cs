using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ServiceProcess;
using QuickConfig.Model.app;
using QuickConfig.Common;

namespace QuickConfig.Controls.WebSiteSet
{
    public partial class serviceInstall : UserControl
    {
        public serviceInstall()
        {
            InitializeComponent();
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Label
        {
            get { return this.service_label.Text; }
            set { this.service_label.Text = value; }
        }

        public string ConfigName;

        public void SetValue(ServiceApp serviceapp)
        {
            this._name = serviceapp.Name;
            this.service_label.Text =serviceapp.Label;
            this.service_state.Text = Common.getServiceState(serviceapp.Servicename);
        }

        private void btn_install_Click(object sender, EventArgs e)
        {
            Apps apps = QuickConfig.Common.setXml.getConfig(ConfigName).Apps;
            ServiceApp serviceapp = apps.ServiceAppList.Find((ServiceApp gx) => gx.Name == this.Name);
            setBAT.AppServiceInstall(serviceapp.Path, serviceapp.Installbat, true);
            this.service_state.Text = Common.getServiceState(serviceapp.Servicename);
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            Apps apps = QuickConfig.Common.setXml.getConfig(ConfigName).Apps;
            ServiceApp serviceapp = apps.ServiceAppList.Find((ServiceApp gx) => gx.Name == this.Name);
            setBAT.ServiceRun(Common.getToolsFolder(), Common.getToolsTempFolder(), serviceapp.Label, serviceapp.Servicename, true);
            this.service_state.Text = Common.getServiceState(serviceapp.Servicename);
        }

        private void btn_stop_Click(object sender, EventArgs e)
        {
            Apps apps = QuickConfig.Common.setXml.getConfig(ConfigName).Apps;
            ServiceApp serviceapp = apps.ServiceAppList.Find((ServiceApp gx) => gx.Name == this.Name);
            setBAT.ServiceStop(Common.getToolsFolder(), Common.getToolsTempFolder(), serviceapp.Label, serviceapp.Servicename, true);
            this.service_state.Text = Common.getServiceState(serviceapp.Servicename);
        }

        private void btn_remove_Click(object sender, EventArgs e)
        {
            Apps apps = QuickConfig.Common.setXml.getConfig(ConfigName).Apps;
            ServiceApp serviceapp = apps.ServiceAppList.Find((ServiceApp gx) => gx.Name == this.Name);
            setBAT.AppServiceRemove(serviceapp.Path, serviceapp.Removebat, true);
            this.service_state.Text = Common.getServiceState(serviceapp.Servicename);
        }
    }
}
