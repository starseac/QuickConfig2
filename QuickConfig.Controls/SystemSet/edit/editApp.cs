using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuickConfig.Model.app;
using QuickConfig.Controls.SystemSet.edit;

namespace QuickConfig.Controls.SystemSet
{
    public partial class editApp : UserControl
    {
        public editApp()
        {
            InitializeComponent();
        }

        public void setValue(App app)
        {
            this.txt_name.Text = app.Name;
            this.txt_label.Text = app.Label;
            this.txt_path.Text = app.Path;
            this.txt_relativepath.Text = app.Relativepath;
            this.txt_configfolder.Text = app.ConfigFolder;

        }

         public bool isNew;

         public Object getValue()
        {
            App app = new App();
            app.Name = this.txt_name.Text;
            app.Label = this.txt_label.Text;
            app.Path = this.txt_path.Text;
            app.Relativepath = this.txt_relativepath.Text;
            app.ConfigFolder = this.txt_configfolder.Text;

            return app;

        }
    }
}
