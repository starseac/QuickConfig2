using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuickConfig.Model.db;
using QuickConfig.Common;
using System.Runtime.InteropServices;

namespace QuickConfig.Controls.DbInit
{
    public partial class dbInit : UserControl
    {
        public dbInit()
        {
            InitializeComponent();
        }

        public List<Control> dbControlList;

        public string ConfigName;

        public void SetButtons(Db db) { 
            if(db.DbSdeUserList.Count<=0){
                this.btnCreateSde.Visible = false;
                this.btnInitSde.Visible = false;            
            }
        
        }

     
        private void btnCreateTablespace_Click(object sender, EventArgs e)
        {
            Db db = QuickConfig.Common.setXml.getConfig(ConfigName).Db;
            try
            {
                setDB setdb = new setDB(db.DbSystemUser.User, db.DbSystemUser.Password, db.Datasource);
                string ansStr = "开始创建表空间\r\n";
                foreach (Control ctl in dbControlList)
                {
                    if (ctl is dmpChoose && ((dmpChoose)ctl).Check == true)
                    {
                        string Name = ((dmpChoose)ctl).Name;
                        DbUser dbuser = db.DbUserList.Find((DbUser ds) => ds.Name == Name);
                        bool ans = setdb.createTabelspace(dbuser.Tablespace, db.Datafolder + "\\" + dbuser.Tablespace + ".DBF", "50m");
                        if (ans == true)
                        {
                            ansStr += "表空间 " + dbuser.Tablespace + "创建成功\r\n";
                        }
                        else
                        {
                            ansStr += "表空间" + dbuser.Tablespace + "创建失败\r\n";
                        }
                    }

                    else if (ctl is gdbChoose && ((gdbChoose)ctl).Check == true)
                    {

                        string Name = ((gdbChoose)ctl).Name;
                        DbSdeUser dbsdeuser = db.DbSdeUserList.Find((DbSdeUser ds) => ds.Name == Name);
                        bool ans = setdb.createTabelspace(dbsdeuser.Tablespace, db.Datafolder + "\\" + dbsdeuser.Tablespace + ".DBF", "50m");
                        if (ans == true)
                        {
                            ansStr += "表空间" + dbsdeuser.Tablespace + "创建成功\r\n";
                        }
                        else
                        {
                            ansStr += "表空间" + dbsdeuser.Tablespace + "创建失败\r\n";
                        }
                    }
                   
                }
                ansStr += "结束创建\r\n";
                MessageBox.Show(ansStr);
            }
            catch (Exception eg)
            {
                MessageBox.Show(eg.Message.ToString());
            }


        }

        private void btnCreateUser_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("创建用户会先drop掉原有用户和用户对象\r\n,请先备份数据库!\r\n继续请点击确定，放弃请点击取消。", "创建用户", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Cancel)
            {
                return;
            }
            Db db = QuickConfig.Common.setXml.getConfig(ConfigName).Db;
            try
            {
                setDB setdb = new setDB(db.DbSystemUser.User, db.DbSystemUser.Password, db.Datasource);
                string ansStr = "开始创建用户\r\n";
                foreach (Control ctl in dbControlList)
                {
                    if (ctl is dmpChoose && ((dmpChoose)ctl).Check == true)
                    {
                        string Name = ((dmpChoose)ctl).Name;
                        DbUser dbuser = db.DbUserList.Find((DbUser ds) => ds.Name == Name);

                        if (setdb.isUserExist(dbuser.User))
                        {
                            setdb.deleteUser(dbuser.User);
                            ansStr += "用户 " + dbuser.User + "drop成功\r\n";
                        }

                        bool ans = setdb.createUser(dbuser.User, dbuser.Password, dbuser.Tablespace);
                        if (ans == true)
                        {
                            ansStr += "用户 " + dbuser.User + "创建成功\r\n";
                        }
                        else
                        {
                            ansStr += "用户 " + dbuser.User + "创建失败\r\n";
                        }

                    }
                }

                ansStr += "结束创建\r\n";
                MessageBox.Show(ansStr);

            }
            catch (Exception eg)
            {
                MessageBox.Show(eg.Message.ToString());
            }
        }

        private void btnCreateSde_Click(object sender, EventArgs e)
        {
            setArcgis.init();
            EngineDatabase engine = new EngineDatabase();

            Db db = QuickConfig.Common.setXml.getConfig(ConfigName).Db;
            try
            {
                setDB setdb = new setDB(db.DbSystemUser.User, db.DbSystemUser.Password, db.Datasource);
                foreach (Control ctl in dbControlList)
                {
                    if (ctl is gdbChoose && ((gdbChoose)ctl).Check == true)
                    {
                        string Name = ((gdbChoose)ctl).Name;
                        DbSdeUser dbsdeuser = db.DbSdeUserList.Find((DbSdeUser ds) => ds.Name == Name);

                        if (setdb.isUserExist(dbsdeuser.User))
                        {
                            // MessageBox.Show("现势库已存在");       

                            if (MessageBox.Show("现势库已存在,是否删除已有的现势库", "确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                            {
                                bool res = setdb.deleteUser(dbsdeuser.User);
                                if (res == true)
                                {
                                    MessageBox.Show("现势库删除成功!");
                                }
                                else
                                {
                                    MessageBox.Show("现势库删除失败!");
                                }

                            }
                        }
                        else
                        {
                            string ans1 = engine.createSDE("Oracle", db.Datasource, db.DbSystemUser.User, db.DbSystemUser.Password, dbsdeuser.User, dbsdeuser.Password, dbsdeuser.Tablespace, Common.getSdeEcpFile());
                            setdb.grantUser(dbsdeuser.User);
                            MessageBox.Show("现势库创建结果如下:\r\n" + ans1);
                        }
                    }
                }

            }
            catch (Exception eg)
            {
                MessageBox.Show(eg.Message.ToString());
            }

            MessageBox.Show("企业空间库操作结束");

        }

        private bool checkSDEimportSet()
        {
            string errStr = "";
            //导入数据文件检查
            Db db = QuickConfig.Common.setXml.getConfig(ConfigName).Db;


            if (!Common.checkFolder(db.Impfolder))
            {
                errStr += "数据文件存放地址必须填写,请重新设置\r\n";
            }
            foreach (Control ctl in dbControlList)
            {
                if (ctl is gdbChoose && ((gdbChoose)ctl).Check == true)
                {
                    string Name = ((gdbChoose)ctl).Name;
                    DbSdeUser dbsdeuser = db.DbSdeUserList.Find((DbSdeUser ds) => ds.Name == Name);
                    if (!Common.checkGDBFolder(dbsdeuser.Gdbfile))
                    {
                        errStr += dbsdeuser.Label + "的GDB文件夹不存在,请重新设置\r\n";
                    }

                }
            }


            if (errStr != "")
            {
                MessageBox.Show(errStr, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;

        }


        private void btnInitSde_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("初始化空间库，会删除空间库原有内容，\r\n,请先备空间库库!\r\n继续请点击确定，放弃请点击取消。", "初始化空间库", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Cancel)
            {
                return;
            }

            if (!checkSDEimportSet())
            {
                return;
            }
            //初始化 esri授权
            setArcgis.init();
            setArcgis.grant();

            EngineDatabase engine = new EngineDatabase();

            Db db = QuickConfig.Common.setXml.getConfig(ConfigName).Db;
            try
            {
                setDB setdb = new setDB(db.DbSystemUser.User, db.DbSystemUser.Password, db.Datasource);
                foreach (Control ctl in dbControlList)
                {
                    if (ctl is gdbChoose && ((gdbChoose)ctl).Check == true)
                    {
                        string Name = ((gdbChoose)ctl).Name;
                        DbSdeUser dbsdeuser = db.DbSdeUserList.Find((DbSdeUser ds) => ds.Name == Name);


                        string ans1 = "";
                        if (setdb.isUserExist(dbsdeuser.User))
                        {
                            setdb.grantUser(dbsdeuser.User);
                            ans1 += "用户 " + dbsdeuser.User + "授权成功\r\n";
                        }
                        ans1+=engine.importGDB2SDEWithWorkspace(db.Ip,"sde:oracle10g:" + db.Datasource,dbsdeuser.User,dbsdeuser.Password,dbsdeuser.Gdbfile,db.CS_TYPE,db.WKID,db.Prjpath);
                        MessageBox.Show(dbsdeuser.Label+"创建结果如下:\r\n" + ans1);
                    }
                }
            }
            catch (Exception eg)
            {
                MessageBox.Show(eg.Message.ToString());
            }

            MessageBox.Show("企业空间库初始化完成");


        }

        private bool checkDataImportSet()
        {
            string errStr = "";
            //导入数据文件检查
            Db db = QuickConfig.Common.setXml.getConfig(ConfigName).Db;


            if (!Common.checkFolder(db.Impfolder))
            {
                errStr += "数据文件存放地址必须填写,请重新设置\r\n";
            }
            foreach (Control ctl in dbControlList)
            {
                if (ctl is dmpChoose && ((dmpChoose)ctl).Check == true)
                {
                    string Name = ((dmpChoose)ctl).Name;
                    DbUser dbuser = db.DbUserList.Find((DbUser ds) => ds.Name == Name);
                    if (!Common.checkFile(dbuser.Dmpfile))
                    {
                        errStr += dbuser.Label + "的dmp文件不存在,请重新设置\r\n";
                    }

                }
            }


            if (errStr != "")
            {
                MessageBox.Show(errStr, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }


        private void btnDmpImport_Click(object sender, EventArgs e)
        {
            if (!checkDataImportSet())
            {
                return;
            }

           setConfig setconfig = new setConfig();

           Db db = QuickConfig.Common.setXml.getConfig(ConfigName).Db;
            try
            {
                string ansStr = "开始导入数据\r\n";
                foreach (Control ctl in dbControlList)
                {
                    if (ctl is dmpChoose && ((dmpChoose)ctl).Check == true)
                    {
                        string Name = ((dmpChoose)ctl).Name;
                        DbUser dbuser = db.DbUserList.Find((DbUser ds) => ds.Name == Name);                     
                        setBAT.OracleImp(Common.getToolsFolder(), Common.getToolsTempFolder(), dbuser.User, dbuser.Password, db.Datasource, dbuser.Dmpfile, db.Impfolder, true);

                        ansStr += dbuser.Label+"数据导出完成\r\n";

                    }

                    
                }
                ansStr += "导入结束\r\n";
                MessageBox.Show(ansStr);
            }
            catch (Exception eg)
            {
                MessageBox.Show(eg.Message.ToString());
            }

        }

        private void checkAll_CheckedChanged(object sender, EventArgs e)
        {
            foreach (Control ctl in dbControlList)
            {
                if (ctl is dmpChoose )
                {
                    ((dmpChoose)ctl).Check = this.checkAll.Checked;
                }
                else if (ctl is gdbChoose)
                {
                    ((gdbChoose)ctl).Check = this.checkAll.Checked;
                }
            
            }
        }
    }
}
