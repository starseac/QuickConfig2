using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuickConfig.Model.app;
using QuickConfig.Model.db;

namespace QuickConfig.Controls.SystemSet
{
    public partial class editDbSystemUser : UserControl
    {
        public editDbSystemUser()
        {
            InitializeComponent();
        }

        public void setValue(DbSystemUser dbsystemuser)
        {
            this.txt_name.Text = dbsystemuser.Name;
            this.txt_label.Text = dbsystemuser.Label;
            this.txt_user.Text = dbsystemuser.User;
            this.txt_password.Text = dbsystemuser.Password;

        }

        public bool isNew;
        
        public Object getValue()
        {
            DbSystemUser dbsystemuser = new DbSystemUser();
            dbsystemuser.Name = this.txt_name.Text;
            dbsystemuser.Label = this.txt_label.Text;
            dbsystemuser.User = this.txt_user.Text;
            dbsystemuser.Password = this.txt_password.Text;

            return dbsystemuser;

        }
    }
}
