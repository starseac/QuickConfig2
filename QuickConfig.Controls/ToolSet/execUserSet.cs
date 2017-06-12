using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuickConfig.Common;
using QuickConfig.Model.db;

namespace QuickConfig.Controls.ToolSet
{
    public partial class execUserSet : UserControl
    {
        public execUserSet()
        {
            InitializeComponent();
           
        }

        public string ConfigName;

        public string Execuser {
            get { return this.userList.SelectedItem.ToString(); }
            
        }

        public void setUserList()
        {
         
            List<string> userList=new List<string>();
            Db db=QuickConfig.Common.setXml.getConfig(ConfigName).Db;

            if(db.DbSystemUser!=null){
                userList.Add(db.DbSystemUser.User);
            }
            if(db.DbUserList.Count>0){
                foreach (DbUser dbuser in db.DbUserList) {
                    userList.Add(dbuser.User);
                }
            }
            if (db.DbSdeUserList.Count > 0)
            {
                foreach (DbSdeUser dbsdeuser in db.DbSdeUserList)
                {
                    userList.Add(dbsdeuser.User);
                }
            }

            this.userList.DataSource = userList;
        }

        public void setValue(string user) { 
               if(this.userList.Items.Count>0&&user!=""){
                   this.userList.SelectedItem = user;
               }
        }
    }
}
