using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuickConfig.Model.app;

namespace QuickConfig.Controls.SystemSet
{
    public partial class editServiceApp : UserControl
    {
        public editServiceApp()
        {
            InitializeComponent();
        }

        public void setValue(ServiceApp serviceapp)
        {
            this.txt_name.Text = serviceapp.Name;
            this.txt_label.Text = serviceapp.Label;
            this.txt_path.Text = serviceapp.Path;
            this.txt_relativepath.Text = serviceapp.Relativepath;
            this.txt_ip.Text = serviceapp.Ip;
            this.txt_port.Text = serviceapp.Port;
            this.txt_configfolder.Text = serviceapp.ConfigFolder;
            this.txt_servicename.Text = serviceapp.Servicename;
            this.txt_installbat.Text = serviceapp.Installbat;
            this.txt_removebat.Text = serviceapp.Removebat;

        }

        public bool isNew;


        public Object getValue()
        {
            ServiceApp serviceapp = new ServiceApp();
            serviceapp.Name = this.txt_name.Text;
            serviceapp.Label = this.txt_label.Text;
            serviceapp.Path = this.txt_path.Text;
            serviceapp.Relativepath = this.txt_relativepath.Text;
            serviceapp.Ip = this.txt_ip.Text;
            serviceapp.Port = this.txt_port.Text;
            serviceapp.ConfigFolder = this.txt_configfolder.Text;
            serviceapp.Servicename = this.txt_servicename.Text;
            serviceapp.Installbat = this.txt_installbat.Text;
            serviceapp.Removebat = this.txt_removebat.Text;
            return serviceapp;

        }
    }
}
