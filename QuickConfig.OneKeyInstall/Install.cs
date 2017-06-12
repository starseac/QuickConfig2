using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuickConfig.Model;
using QuickConfig.Utility;
using QuickConfig.Model.app;
using QuickConfig.Model.db;
using QuickConfig.Common;
using System.IO;
using System.Threading;

namespace QuickConfig.OneKeyInstall
{
    public partial class Install : Form
    {
        public Install()
        {
            InitializeComponent();
            laodConfigXML();
            loadControls();
            showStart();
        }

        StartImage startimage;
        StartInstallBtn startinstallbtn;
        StartConfig startconfig;
        StartAgree startagree;

        InstallImages installimages;
        InstallProgress installprogress;

        CompleteImage completeimage;
        CompleteBtn completebtn;

        Set set;

        string configName;

        private void laodConfigXML()
        {
            string path = Tools.getInstallConfigFolder() + "\\install.txt";
            FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamReader sr = new StreamReader(fs);
            string con = sr.ReadToEnd();
            sr.Close();
            fs.Close();
            if (con != "")
            {
                configName = con;
                set = Common.setXml.getConfig(configName);
            }
            else
            {
                MessageBox.Show("未设置好安装程序配置!");
                Application.Exit();

            }


        }

        private void AddControl(Control ctl)
        {
            this.flowLayoutPanel1.Controls.Add(ctl);

        }

        private void loadControls()
        {
            startimage = new StartImage();
            AddControl(startimage);
            startinstallbtn = new StartInstallBtn();
            startinstallbtn.save += saveInstallConfigToConfigXML;
            startinstallbtn.show += showInstall;

            AddControl(startinstallbtn);
            startconfig = new StartConfig();
            startconfig.SetValue(set);

            AddControl(startconfig);
            startagree = new StartAgree();
            startagree.show += showConfig;
            startagree.hide += showStart;
            AddControl(startagree);

            startinstallbtn.startAgree = startagree;

            installimages = new InstallImages();
            installimages.change += changeImage;
            AddControl(installimages);
            installprogress = new InstallProgress();
            installprogress.install += installApp;

            AddControl(installprogress);

            completeimage = new CompleteImage();
            AddControl(completeimage);
            completebtn = new CompleteBtn();
            completebtn.close += this.Close;
            AddControl(completebtn);


        }
        #region 界面显示控制
        private void showStart()
        {
            startimage.Visible = true;
            startinstallbtn.Visible = true;
            startconfig.Visible = false;
            startagree.Visible = true;

            installimages.Visible = false;
            installprogress.Visible = false;

            completeimage.Visible = false;
            completebtn.Visible = false;
            this.Height = 430;
        }

        private void showConfig()
        {
            startimage.Visible = true;
            startinstallbtn.Visible = true;
            startconfig.Visible = true;
            startagree.Visible = true;

            installimages.Visible = false;
            installprogress.Visible = false;

            completeimage.Visible = false;
            completebtn.Visible = false;

            this.Height = 560;
        }


        private void showInstall()
        {
            startimage.Visible = false;
            startinstallbtn.Visible = false;
            startconfig.Visible = false;
            startagree.Visible = false;

            installimages.Visible = true;
            installprogress.Visible = true;

            completeimage.Visible = false;
            completebtn.Visible = false;

            this.Height = 430;
        }

        public delegate void ShowCompleteDelegate();
        private void showComplete()
        {
            startimage.Visible = false;
            startinstallbtn.Visible = false;
            startconfig.Visible = false;
            startagree.Visible = false;

            installimages.Visible = false;
            installprogress.Visible = false;

            completeimage.Visible = true;
            completebtn.Visible = true;

            this.Height = 430;


        }
        #endregion

        //private void saveConfig()
        //{

        //    //Thread th = new Thread(new ThreadStart(this.saveInstallConfigToConfigXML));
        //    //th.IsBackground = true;
        //    //th.Start();

        //    saveConfigXML();
        //}


        private void saveConfigXML()
        {
            string configPath2 = AppDomain.CurrentDomain.BaseDirectory + "config\\" + configName + ".xml";

            XmlClassHelper.SaveClass2Xml<Set>(set, configPath2);
        }


        private void saveInstallConfigToConfigXML()
        {
            // 设置修改 绝对路径的保存设置。
            string dataFolder = "";
            try
            {
                setDB db = new setDB("system", startconfig.DB_Password, startconfig.DB_Datasource);
                dataFolder = db.getDataFolder();
            }
            catch (Exception eg)
            {
                MessageBox.Show("链接不上数据库，请检查参数和配置!", "错误");

            }

            set.setInstallSet(startconfig.APP_IP, startconfig.MainFolder, startconfig.DB_IP, startconfig.DB_Datasource, startconfig.DB_Password, dataFolder);
            saveConfigXML();
            laodConfigXML();
        }


        private void changeImage()
        {

            Thread th = new Thread(new ThreadStart(this.changeNextImage));
            th.IsBackground = true;
            th.Start();

        }

        private void changeNextImage()
        {
            string imagelistPath = Tools.getInstallShowFolder();
            List<string> imageList = new List<string>();
            DirectoryInfo Folder = new DirectoryInfo(imagelistPath);
            foreach (FileInfo NextFile in Folder.GetFiles("*.jpg"))
            {
                imageList.Add(NextFile.Name.Replace(".jpg", ""));
            }
            int i = 0;
            int count = imageList.Count;
            while (true)
            {
                installimages.imageName = imageList[i];
                if (i + 1 == count)
                {
                    i = 0;
                }
                else
                {
                    i++;
                }
                Thread.Sleep(8000);

            }
        }


        private void installApp()
        {
            Thread th = new Thread(new ThreadStart(this.installByConfig));
            th.IsBackground = true;
            th.Start();

            thhander = th;
        }

        private Thread thhander;

        string installLog;
        StreamWriter sw;

        private void writeLog(string content)
        {
            try
            {
                sw = new StreamWriter(installLog, true);
                sw.Write(DateTime.Now.ToString() + content + "\r\n");
            }
            catch { }
            finally
            {
                sw.Close();
                sw.Dispose();
            }
        }


        private void installByConfig()
        {
            InstallProgress.SetShow setShow = new InstallProgress.SetShow(installprogress.setVlaue);
            this.Invoke(setShow, new object[] { "开始安装..", 1 });
            installLog = set.Apps.Path + "\\install.log";

            if(!Directory.Exists(set.Apps.Path)){
                try
                {
                    Directory.CreateDirectory(set.Apps.Path);
                }catch(Exception eg){
                    MessageBox.Show("无法创建路径:"+set.Apps.Path);
                    writeLog(eg.Message.ToString() + "\r\n" + "无法创建路径:" + set.Apps.Path +"\r\n");
                }
            }

            writeLog("开始安装");
            try
            {
                CopyFile(setShow);
                AppSet(setShow);
                if (set.Db.DbUserList.Count > 0 || set.Db.DbSdeUserList.Count > 0)
                {
                    CreateDB(setShow);
                }
                if (set.Db.DbSdeUserList.Count > 0)
                {
                    CreateSDE(setShow);
                    InitSDE(setShow);
                }
                if (set.Db.DbUserList.Count > 0)
                {
                    InitDB(setShow);
                }
                if (set.Apps.ServiceAppList.Count > 0)
                {
                    InstallAndStartServer(setShow);
                }
                if (set.Apps.FtpList.Count > 0)
                {
                    InstallFtp(setShow);
                }
                if (set.Apps.GxmlList.Count > 0)
                {
                    InstallGXML(setShow);
                }
                if (set.Apps.WebAppList.Count > 0)
                {
                    InstallWebApps(setShow);
                }
            }catch(Exception eg){
                writeLog(eg.Message.ToString());
            }
            // StartAutoBackupService(setShow);  
            ShowCompleteDelegate scd = new ShowCompleteDelegate(this.showComplete);
            this.Invoke(scd, new object[] { });
            thhander.Abort();
        }

        private void CopyFile(InstallProgress.SetShow setShow)
        {
            this.Invoke(setShow, new object[] { "复制文件", 1 });
            writeLog("复制文件");
            int numStart = 1;
            int numMax = 15;
            Common.setConfig setconfig = new Common.setConfig();

            Common.setXml setxml = new Common.setXml();

            DataTable dt = setxml.readInstallXML(Tools.getInstallConfigFolder());
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string type = dt.Rows[i]["type"].ToString();
                    string name = dt.Rows[i]["name"].ToString();
                    string xmlname = dt.Rows[i]["xmlname"].ToString();

                    string packagefilepath = Tools.getInstallPackagesFolder() + "\\" + name + ".7z";
                    string targetFolder = "";
                    string label = "";
                    if (type == "serviceapp")
                    {
                        ServiceApp sa = set.Apps.ServiceAppList.Find((ServiceApp du) => du.Name == xmlname);
                        targetFolder = set.Apps.Path + "\\" + sa.Relativepath;
                        label = sa.Label;
                    }
                    else if (type == "webapp")
                    {

                        WebApp sa = set.Apps.WebAppList.Find((WebApp du) => du.Name == xmlname);
                        targetFolder = set.Apps.Path + "\\" + sa.Relativepath;
                        label = sa.Label;
                    }
                    else if (type == "app")
                    {
                        App sa = set.Apps.AppList.Find((App du) => du.Name == xmlname);
                        targetFolder = set.Apps.Path + "\\" + sa.Relativepath;
                        label = sa.Label;
                    }
                    else if (type == "dmp")
                    {
                        DbUser sa = set.Db.DbUserList.Find((DbUser du) => du.Name == xmlname);
                        targetFolder = set.Apps.Path + "\\" + set.Db.Relativepath;
                        label = sa.Label;

                    }
                    else if (type == "gdb")
                    {
                        DbSdeUser sa = set.Db.DbSdeUserList.Find((DbSdeUser du) => du.Name == xmlname);
                        targetFolder = set.Apps.Path + "\\" + sa.Relativepath;
                        label = sa.Label;
                    }

                    if (!Directory.Exists(targetFolder))
                    {

                        Directory.CreateDirectory(targetFolder);
                    }

                    Common.setBAT.FileExtract(Tools.getToolsFolder(), Tools.getToolsTempFolder(), label, packagefilepath, targetFolder, false);

                    if (numStart != numMax)
                    {
                        this.Invoke(setShow, new object[] { type+"文件:" + label + "复制完成", numStart });
                        writeLog( type+"文件:" + label + "复制完成");
                        numStart++;
                    }
                }
            }
        }

        private void AppSet(InstallProgress.SetShow setShow)
        {
            this.Invoke(setShow, new object[] { "生成配置", 6 });
            writeLog("生成配置");
            int numStart = 6;
            int numMax = 7;

            Common.setXml xml = new Common.setXml();
            xml.addCopyFileXML(Tools.getConfigFolder(), Tools.getConfigTemplateFolder(), configName, "copyPath");

            Apps apps = QuickConfig.Common.setXml.getConfig(configName).Apps;


            Common.setConfig setconfig = new Common.setConfig();
            List<string[]> checkApp = new List<string[]>();

            foreach (ServiceApp sa in set.Apps.ServiceAppList)
            {
                string[] configFolder = new string[2];
                configFolder[0] = sa.ConfigFolder;
                configFolder[1] = sa.Path;
                checkApp.Add(configFolder);
            }
            foreach (WebApp sa in set.Apps.WebAppList)
            {
                string[] configFolder = new string[2];
                configFolder[0] = sa.ConfigFolder;
                configFolder[1] = sa.Path;
                checkApp.Add(configFolder);
            }
            foreach (App sa in set.Apps.AppList)
            {
                string[] configFolder = new string[2];
                configFolder[0] = sa.ConfigFolder;
                configFolder[1] = sa.Path;
                checkApp.Add(configFolder);
            }

            setconfig.config(Tools.getConfigTemplateFolder(), Tools.getConfigTemplateTempFolder(), configName, checkApp);

            if (numStart != numMax)
            {
                this.Invoke(setShow, new object[] { "配置程序完成", numStart });
                writeLog("配置程序完成");
                numStart++;
            }
        }

        private void CreateDB(InstallProgress.SetShow setShow)
        {
            this.Invoke(setShow, new object[] { "开始创建数据库", 15 });
            writeLog("开始创建数据库");
            int numStart = 15;
            int numMax = 25;

            Db db = QuickConfig.Common.setXml.getConfig(configName).Db;
            try
            {
                Common.setDB setdb = new Common.setDB(db.DbSystemUser.User, db.DbSystemUser.Password, db.Datasource);
                string ansStr = "开始创建表空间\r\n";
                writeLog(ansStr);
                this.Invoke(setShow, new object[] { "开始创建表空间", 15 });
                foreach (DbUser dbuser in set.Db.DbUserList)
                {
                    bool ans = setdb.createTabelspace(dbuser.Tablespace, db.Datafolder + "\\" + dbuser.Tablespace + ".DBF", "50m");
                    if (ans == true)
                    {
                        ansStr = "表空间 " + dbuser.Tablespace + "创建成功\r\n";
                        writeLog(ansStr);
                        if (numStart != numMax)
                        {
                            this.Invoke(setShow, new object[] { "表空间 " + dbuser.Tablespace + "创建成功", numStart });
                            numStart++;
                        }
                    }
                    else
                    {
                        ansStr = "表空间" + dbuser.Tablespace + "创建失败\r\n";
                        writeLog(ansStr);
                        if (numStart != numMax)
                        {
                            this.Invoke(setShow, new object[] { "表空间 " + dbuser.Tablespace + "创建失败", numStart });
                            numStart++;
                        }
                    }
                }

                foreach (DbSdeUser dbsdeuser in set.Db.DbSdeUserList)
                {

                    bool ans = setdb.createTabelspace(dbsdeuser.Tablespace, db.Datafolder + "\\" + dbsdeuser.Tablespace + ".DBF", "50m");
                    if (ans == true)
                    {
                        ansStr = "表空间" + dbsdeuser.Tablespace + "创建成功\r\n";
                        writeLog(ansStr);
                        if (numStart != numMax)
                        {
                            this.Invoke(setShow, new object[] { "表空间 " + dbsdeuser.Tablespace + "创建成功", numStart });
                            numStart++;
                        }
                    }
                    else
                    {
                        ansStr = "表空间" + dbsdeuser.Tablespace + "创建失败\r\n";
                        writeLog(ansStr);
                        if (numStart != numMax)
                        {
                            this.Invoke(setShow, new object[] { "表空间 " + dbsdeuser.Tablespace + "创建失败", numStart });
                            numStart++;
                        }
                    }


                }
                ansStr = "数据库结束创建\r\n";
                writeLog(ansStr);

            }
            catch (Exception eg)
            {
                MessageBox.Show(eg.Message.ToString());
                return;
            }
            this.Invoke(setShow, new object[] { "开始创建数据用户", 15 });

            if (MessageBox.Show("创建用户会先删除掉原有数据\r\n,请先备份数据库!\r\n继续请点击确定，放弃请点击取消。", "创建用户", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Cancel)
            {
                return;
            }

            try
            {
                Common.setDB setdb = new Common.setDB(db.DbSystemUser.User, db.DbSystemUser.Password, db.Datasource);
                string ansStr = "开始创建用户\r\n";
                writeLog(ansStr);
                foreach (DbUser dbuser in db.DbUserList)
                {

                    if (setdb.isUserExist(dbuser.User))
                    {
                        setdb.deleteUser(dbuser.User);
                        ansStr = "用户 " + dbuser.User + "drop成功\r\n";
                        writeLog(ansStr);
                        if (numStart != numMax)
                        {
                            this.Invoke(setShow, new object[] { "用户 " + dbuser.User + "drop成功", numStart });
                            numStart++;
                        }
                    }

                    bool ans = setdb.createUser(dbuser.User, dbuser.Password, dbuser.Tablespace);
                    if (ans == true)
                    {
                        ansStr = "用户 " + dbuser.User + "创建成功\r\n";
                        writeLog(ansStr);
                        if (numStart != numMax)
                        {
                            this.Invoke(setShow, new object[] { "用户 " + dbuser.User + "创建成功", numStart });
                            numStart++;
                        }
                    }
                    else
                    {
                        ansStr = "用户 " + dbuser.User + "创建失败\r\n";
                        writeLog(ansStr);
                        if (numStart != numMax)
                        {
                            this.Invoke(setShow, new object[] { "用户 " + dbuser.User + "创建失败", numStart });
                            numStart++;
                        }
                    }

                }

                ansStr = "用户创建结束\r\n";
                writeLog(ansStr);
                this.Invoke(setShow, new object[] { "用户创建结束", 25 });

            }
            catch (Exception eg)
            {
                MessageBox.Show(eg.Message.ToString());
            }

        }

        private void CreateSDE(InstallProgress.SetShow setShow)
        {
            this.Invoke(setShow, new object[] { "创建地理空间库", 26 });
            writeLog("创建地理空间库");
            int numStart = 26;
            int numMax = 30;
            Common.setArcgis.init();
            Common.EngineDatabase engine = new Common.EngineDatabase();
            try
            {
                Common.setDB setdb = new Common.setDB(set.Db.DbSystemUser.User, set.Db.DbSystemUser.Password, set.Db.Datasource);
                foreach (DbSdeUser dbsdeuser in set.Db.DbSdeUserList)
                {

                    if (setdb.isUserExist(dbsdeuser.User))
                    {

                        if (MessageBox.Show(dbsdeuser.Label + "已存在,是否删除已有的" + dbsdeuser.Label, "确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            bool res = setdb.deleteUser(dbsdeuser.User);
                            if (res == true)
                            {
                                //MessageBox.Show(dbsdeuser.Label + "删除成功!");
                                writeLog(dbsdeuser.Label + "删除成功!");
                            }
                            else
                            {
                                //MessageBox.Show(dbsdeuser.Label + "删除失败!");
                                writeLog(dbsdeuser.Label + "删除失败!");
                            }

                        }
                    }
                    else
                    {
                        string ans1 = engine.createSDE("Oracle", set.Db.Datasource, set.Db.DbSystemUser.User, set.Db.DbSystemUser.Password, dbsdeuser.User, dbsdeuser.Password, dbsdeuser.Tablespace, Tools.getSdeEcpFile());
                        setdb.grantUser(dbsdeuser.User);
                        writeLog(ans1);
                        if (numStart != numMax)
                        {
                            this.Invoke(setShow, new object[] { dbsdeuser.Label + "空间库创建结束", numStart });
                            writeLog(dbsdeuser.Label + "空间库创建结果："+ans1+"\r\n");
                            writeLog(dbsdeuser.Label + "空间库创建结束");
                        }
                    }
                }

            }
            catch (Exception eg)
            {
                MessageBox.Show(eg.Message.ToString());
            }
            this.Invoke(setShow, new object[] { "企业空间库操作结束", 30 });
            writeLog("企业空间库操作结束");

        }

        private void InitSDE(InstallProgress.SetShow setShow)
        {
            this.Invoke(setShow, new object[] { "初始化空间库", 31 });
            writeLog("初始化空间库");
            if (MessageBox.Show("初始化空间库，会删除空间库原有内容，\r\n,请先备空间库库!\r\n继续请点击确定，放弃请点击取消。", "初始化空间库", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Cancel)
            {
                return;
            }

            //初始化 esri授权
            Common.setArcgis.init();
            Common.setArcgis.grant();

            Common.EngineDatabase engine = new Common.EngineDatabase();

            try
            {
                Common.setDB setdb = new Common.setDB(set.Db.DbSystemUser.User, set.Db.DbSystemUser.Password, set.Db.Datasource);
                foreach (DbSdeUser dbsdeuser in set.Db.DbSdeUserList)
                {

                    string ans1 = "";
                    if (setdb.isUserExist(dbsdeuser.User))
                    {
                        setdb.grantUser(dbsdeuser.User);
                        ans1 = "用户 " + dbsdeuser.User + "授权成功\r\n";
                        writeLog(ans1);
                    }                    
                    ans1 = engine.importGDB2SDEWithWorkspace(set.Db.Ip, "sde:oracle10g:" + set.Db.Datasource, dbsdeuser.User, dbsdeuser.Password, dbsdeuser.Gdbfile, set.Db.CS_TYPE,set.Db.WKID,set.Db.Prjpath);
                    //MessageBox.Show(dbsdeuser.Label + "创建结果如下:\r\n" + ans1);
                    writeLog(dbsdeuser.Label + "创建结果如下:\r\n" + ans1);
                }

            }
            catch (Exception eg)
            {
                // MessageBox.Show(eg.Message.ToString());
                writeLog(eg.Message.ToString());
            }

            // MessageBox.Show("企业空间库初始化完成");
            this.Invoke(setShow, new object[] { "企业空间库初始化完成", 40 });
            writeLog("企业空间库初始化完成");
        }

        private void InitDB(InstallProgress.SetShow setShow)
        {
            this.Invoke(setShow, new object[] { "初始化数据库", 25 });
            writeLog("初始化数据库");
            int numStart = 41;
            int numMax = 50;

            Common.setConfig setconfig = new Common.setConfig();

            try
            {
                string ansStr = "开始导入数据\r\n";
                writeLog(ansStr);
                this.Invoke(setShow, new object[] { "开始导入数据", 25 });
                writeLog("开始导入数据");
                foreach (DbUser dbuser in set.Db.DbUserList)
                {
                    Common.setBAT.OracleImp(Tools.getToolsFolder(), Tools.getToolsTempFolder(), dbuser.User, dbuser.Password, set.Db.Datasource, dbuser.Dmpfile, set.Db.Impfolder, false);
                    ansStr = dbuser.Label + "数据导入完成\r\n";
                    writeLog(ansStr);
                    if (numStart != numMax)
                    {
                        this.Invoke(setShow, new object[] { dbuser.Label + "数据导入完成", numStart });
                        numStart++;
                    }

                }
                ansStr = "导入结束\r\n";
                writeLog(ansStr);
                this.Invoke(setShow, new object[] { "数据导入结束", 50 });
            }
            catch (Exception eg)
            {
                MessageBox.Show(eg.Message.ToString());
            }

        }

        private void InstallAndStartServer(InstallProgress.SetShow setShow)
        {
            this.Invoke(setShow, new object[] { "安装启动服务", 51 });
            writeLog("安装启动服务");
            int numStart = 51;
            int numMax = 60;
            foreach (ServiceApp serviceapp in set.Apps.ServiceAppList)
            {
                if (Tools.getServiceState(serviceapp.Servicename) == "服务未安装")
                {
                    Common.setBAT.AppServiceInstall(serviceapp.Path, serviceapp.Installbat, false);
                }
                if (Tools.getServiceState(serviceapp.Servicename) == "已经停止")
                {
                    Common.setBAT.ServiceRun(Tools.getToolsFolder(), Tools.getToolsTempFolder(), serviceapp.Label, serviceapp.Servicename, false);
                }

                if (numStart != numMax)
                {
                    this.Invoke(setShow, new object[] { "服务" + serviceapp.Servicename + "安装启动完成", numStart });
                    writeLog("服务" + serviceapp.Servicename + "安装启动完成");
                    numStart++;
                }
            }

        }

        private void InstallFtp(InstallProgress.SetShow setShow)
        {
            this.Invoke(setShow, new object[] { "搭建Ftp站点", 61 });
            writeLog("搭建Ftp站点");
            int numStart = 61;
            int numMax = 70;
            foreach (Ftp ftp in set.Apps.FtpList)
            {
                if (!Common.setOSUser.isUserExist(ftp.User))
                {
                    Common.setOSUser.addUser(ftp.User, ftp.Password);
                }
                else
                {
                    Common.setOSUser.UpdateUserPassword(ftp.User, ftp.Password);
                }

                Common.setFTP setftp = new Common.setFTP();
                setftp.delFtpSite(ftp.Label);
                if (!Directory.Exists(ftp.Path))
                {
                    Directory.CreateDirectory(ftp.Path);
                }
                setftp.createFTP(ftp.Label, ftp.Path, ftp.User, ftp.Ip);

                if (numStart != numMax)
                {
                    this.Invoke(setShow, new object[] { ftp.Label + "创建成功", numStart });
                    writeLog(ftp.Label + "创建成功");
                    numStart++;
                }
            }
        }

        private void InstallGXML(InstallProgress.SetShow setShow)
        {
            this.Invoke(setShow, new object[] { "设置共享目录", 80 });
            writeLog("设置共享目录");
            int numStart = 80;
            int numMax = 90;
            foreach (Gxml gxml in set.Apps.GxmlList)
            {
                Common.setGXML setgxml = new Common.setGXML();
                if (!Directory.Exists(gxml.Path))
                {
                    Directory.CreateDirectory(gxml.Path);
                }
                setgxml.SetFileRole(gxml.Path, gxml.User);
                setgxml.shareFolder(gxml.Path, gxml.Label, "");

                if (numStart != numMax)
                {
                    this.Invoke(setShow, new object[] { gxml.Label + "创建成功", numStart });
                    writeLog(gxml.Label + "创建成功");
                    numStart++;
                }
            }
        }

        private void InstallWebApps(InstallProgress.SetShow setShow)
        {
            this.Invoke(setShow, new object[] { "创建网站", 90 });
            writeLog("创建网站");
            int numStart = 90;
            int numMax = 99;

            Common.setIIS iis = new Common.setIIS();
            foreach (WebApp webapp in set.Apps.WebAppList)
            {
                iis.DelSite(webapp.SiteName);
                NewWebSiteInfo info_framework = new NewWebSiteInfo(webapp.Ip, webapp.Port, "", webapp.SiteName, webapp.Path);
                iis.CreateNewWebSite(info_framework, webapp.SiteName);
                writeLog(webapp.Label + "创建完成");
            }
            if (numStart != numMax)
            {
                this.Invoke(setShow, new object[] { "网站创建完成", numStart });
                numStart++;
            }
        }

        private void StartAutoBackupService(InstallProgress.SetShow setShow)
        {
            this.Invoke(setShow, new object[] { "开启备份服务", 99 });
            setBAT.ServiceInstall(Tools.getToolsFolder(), Tools.getToolsTempFolder(), "自动备份", "QuickConfig_AutoBackup", Tools.getServicesFolder() + "\\AutoBackup.exe", false);
            setBAT.ServiceRun(Tools.getToolsFolder(), Tools.getToolsTempFolder(), "自动备份", "QuickConfig_AutoBackup", false);
            this.Invoke(setShow, new object[] { "自动备份服务启动", 100 });
        }
    }
}
