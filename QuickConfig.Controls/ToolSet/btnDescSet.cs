using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuickConfig.Model.definebtns;
using QuickConfig.Common;
using QuickConfig.Model.db;
using QuickConfig.Model;

namespace QuickConfig.Controls.ToolSet
{
    public partial class btnDescSet : UserControl
    {
        public btnDescSet()
        {
            InitializeComponent();
        }
        private string _name;
        private string _desc;
        private string _type;
        private string _filename;
        private bool _install;

        public string Name
        {
            get { return _name; }
            set { this._name = value; }
        }


        public string Desc
        {
            get { return btn_desc.Text; }
            set { this.btn_desc.Text = value; }
        }


        public string Type
        {
            get { return this._type; }
            set { this._type = value; }
        }

        public string Filename
        {
            get { return _filename; }
            set { this._filename = value; }
        }

        public bool Install
        {
            get { return _install; }
            set { this._install = value; }
        }

        public void setValue(Btn btn)
        {
            this._name = btn.Name;
            this.btn_desc.Text = btn.Desc;
            this._type = btn.Type;
            this._filename = btn.Filename;

            this._install = btn.Install;

        }

        public string ConfigName;

        private void btn_exec_Click(object sender, EventArgs e)
        {

            Set set = QuickConfig.Common.setXml.getConfig(ConfigName);

            setConfig setconfig = new setConfig();

            List<Btn> btnList = set.Definebtns.BtnList;

            if (this.Type == "bat")
            {
                string filePath = Common.getToolsFolder() + "\\" + this.Filename + "." + this.Type;

                Btn btn = btnList.Find((Btn s) => s.Name == this.Name);
                List<string[]> inputList = new List<string[]>();
                foreach (Input input in btn.InputList)
                {
                    string[] str = new string[2];
                    str[0] = input.Key;
                    str[1] = input.Value;
                    inputList.Add(str);

                }

                setBAT.RunBatByDefine(Common.getToolsFolder(), Common.getToolsTempFolder(), this.Filename, inputList, true);

            }
            else if (this.Type == "sql")
            {

                Btn btn = btnList.Find((Btn s) => s.Name == this.Name);
                List<string[]> inputList = new List<string[]>();
                foreach (Input input in btn.InputList)
                {
                    string[] str = new string[2];
                    str[0] = input.Key;
                    str[1] = input.Value;
                    inputList.Add(str);
                }

                string user = btn.Execuser;
                string password = "";
                string datasource = set.Db.Datasource;
                if (user == set.Db.DbSystemUser.User)
                {
                    password = set.Db.DbSystemUser.Password;
                }
                else if (set.Db.DbUserList.Find((DbUser dbuser) => dbuser.User == user) != null)
                {
                    password = set.Db.DbUserList.Find((DbUser dbuser) => dbuser.User == user).Password;

                }
                else if (set.Db.DbSdeUserList.Find((DbSdeUser dbsdeuser) => dbsdeuser.User == user) != null)
                {
                    password = set.Db.DbSdeUserList.Find((DbSdeUser dbsdeuser) => dbsdeuser.User == user).Password;
                }

                setBAT.SqlExec(Common.getToolsFolder(), Common.getToolsTempFolder(), user, password, datasource, this.Filename, inputList, true);

            }
        }
    }
}
