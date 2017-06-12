using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Data;
using System.IO;
using QuickConfig.Model;
using QuickConfig.Model.db;
using QuickConfig.Model.app;
using QuickConfig.Utility;
using System.Reflection;

namespace QuickConfig.Common
{
    public class setBackup
    {
        string exp_tem_path = "";
        string exp_path = "";
        string dayString = "";

        string backup_path = "";


        public void backup(Set set, string toolsFolder, string toolsTempFolder)
        {
            BackupContents bcs = new BackupContents();
            bcs = JsonClassHelper.Json2Class<BackupContents>(set.Backup.Content);

            if (bcs==null||bcs.content==null)
            {
                return;

            }
            else
            {
                exp_tem_path = toolsFolder;
                exp_path = toolsTempFolder;
                dayString = DateTime.Now.Year + "-" + (DateTime.Now.Month < 10 ? "0" + DateTime.Now.Month : DateTime.Now.Month + "") + "-" + (DateTime.Now.Day < 10 ? "0" + DateTime.Now.Day : DateTime.Now.Day + "");  //DateTime.Now.ToShortDateString();
                string timeString = DateTime.Now.Hour.ToString() + "-" + DateTime.Now.Minute.ToString() + "--" + DateTime.Now.Second.ToString();

                backup_path = set.Backup.Path + "\\backup-" + dayString + "\\" + timeString;
                if (!System.IO.Directory.Exists(backup_path))
                {
                    System.IO.Directory.CreateDirectory(backup_path);
                }


                setConfig setconfig = new setConfig();
                string ansStr = "开始备份数据\r\n";


                if (bcs.content.Find((BackupContent bc) => bc.Name == "sde") != null&&bcs.content.Find((BackupContent bc) => bc.Name == "sde").Type.Count>0)
                {
                    //备份 sde库
                    //初始化 esri授权
                    setArcgis.init();
                    setArcgis.grant();
                }


                foreach (BackupContent bc in bcs.content)
                {
                    if (bc.Type==null)
                    {
                        continue;
                    }
                  

                    foreach (BackupContentType bctype in bc.Type)
                    {
                       
                        if (bc.Name == "dmp")
                        {
                            string name = bctype.Name;
                            DbUser dbuser = set.Db.DbUserList.Find((DbUser du) => du.Name == name);
                           
                            if(bctype.Set!=null&&bctype.Set.Count>0){
                                string remoteInfo = bctype.Set.Find((BackupContentSet bcsset) => bcsset.SetKey == "remoteInfo").SetValue;
                                string [] remoteInfos=remoteInfo.Split(',');                             

                                setBAT.OracleExpdp(exp_tem_path, exp_path, dbuser.User, dbuser.Password, set.Db.Datasource, dbuser.Label, backup_path, remoteInfos[0],remoteInfos[1],remoteInfos[2],bctype.getValueList("excludeTable"), true);                            
                                setBAT.FilePackage(exp_tem_path, exp_path, "正在压缩" + dbuser.Label + "dmpdp文件", backup_path + "\\EXP-" + dbuser.User.ToUpper() + ".DMPDP", backup_path + "\\exp-" + dbuser.User, false, null, null, true);
                                File.Delete(backup_path + "\\exp-" + dbuser.User + ".dmpdp");
                                ansStr += dbuser.Label + "数据expdp导出完成\r\n";

                            }else{
                                setBAT.OracleExp(exp_tem_path, exp_path, dbuser.User, dbuser.Password, set.Db.Datasource, dbuser.Label, backup_path, true);                            
                                setBAT.FilePackage(exp_tem_path, exp_path, "正在压缩" + dbuser.Label + "dmp文件", backup_path + "\\exp-" + dbuser.User + ".dmp", backup_path + "\\exp-" + dbuser.User,false,null,null, true);
                                File.Delete(backup_path + "\\exp-" + dbuser.User + ".dmp");
                                ansStr += dbuser.Label + "数据导出完成\r\n";
                            }
                            

                        }
                        else if (bc.Name == "app")
                        {
                            string type = bctype.Type;
                            string name = bctype.Name;

                            string labelStr = "";
                            string appfolder = "";
                            string appfilename = "";

                            dynamic typeObject = System.Reflection.Assembly.Load("QuickConfig.Model").CreateInstance(type, false); ;

                            if (typeObject is ServiceApp)
                            {
                                ServiceApp dbuser = set.Apps.ServiceAppList.Find((ServiceApp du) => du.Name == name);
                                labelStr = dbuser.Label;
                                appfolder = dbuser.Path;
                                appfilename = dbuser.Label;

                            }
                            else if (typeObject is WebApp)
                            {
                                WebApp dbuser = set.Apps.WebAppList.Find((WebApp du) => du.Name == name);
                                labelStr = dbuser.Label;
                                appfolder = dbuser.Path;
                                appfilename = dbuser.Label;
                            }
                            else if (typeObject is App)
                            {
                                App dbuser = set.Apps.AppList.Find((App du) => du.Name == name);
                                labelStr = dbuser.Label;
                                appfolder = dbuser.Path;
                                appfilename = dbuser.Label;

                            }
                            else if (typeObject is Ftp)
                            {
                                Ftp dbuser = set.Apps.FtpList.Find((Ftp du) => du.Name == name);
                                labelStr = dbuser.Label;
                                appfolder = dbuser.Path;
                                appfilename = dbuser.Label;

                            }
                            else if (typeObject is Gxml)
                            {
                                Gxml dbuser = set.Apps.GxmlList.Find((Gxml du) => du.Name == name);
                                labelStr = dbuser.Label;
                                appfolder = dbuser.Path;
                                appfilename = dbuser.Label;
                            }

                            setBAT.FilePackage(exp_tem_path, exp_path, labelStr, appfolder, backup_path + "\\" + appfilename, true, bctype.getValueList("excludeFolder"), bctype.getValueList("excludeFile"), true);

                            ansStr += appfilename + "程序备份完成\r\n";

                        }
                        else if (bc.Name == "sde")
                        {
                            string name =bctype.Name;
                            DbSdeUser dbuser = set.Db.DbSdeUserList.Find((DbSdeUser du) => du.Name == name);
                            EngineDatabase engine = new EngineDatabase();
                            engine.createGDBFile(backup_path, dbuser.Tablespace + ".gdb");
                            string ans1 = engine.exportSDE2GDBWithWorkspace(set.Db.Ip, "sde:oracle10g:" + set.Db.Datasource, dbuser.User, dbuser.Password, backup_path + "\\" + dbuser.Tablespace + ".gdb");
                           // setBAT.FilePackage(exp_tem_path, exp_path, "正在压缩" + dbuser.Label + "gdb文件", backup_path + "\\" + dbuser.Tablespace + ".gdb", backup_path + "\\" + dbuser.User,true,null,null, true);
                            ansStr += dbuser.Label + "导出结果如下:\r\n" + ans1 + "\r\n";

                            ansStr += dbuser.Label + "导出导出完成\r\n";
                        }


                    }

                }
                ansStr += "备份结束\r\n";
                StreamWriter sw = null;
                if (!File.Exists(backup_path + "\\" + dayString + ".log"))
                {
                    //不存在就新建一个文本文件,并写入一些内容 
                    sw = File.CreateText(backup_path + "\\" + dayString + ".log");
                }
                else
                {
                    sw = new StreamWriter(backup_path + "\\" + dayString + ".log");
                }

                sw.Write(ansStr);
                sw.Close();

            }

        }

        public void openFolderAndLog()
        {           
            setBAT.OpenFolder(exp_tem_path, exp_path, backup_path);
            setBAT.OpenFileWithNotepad(exp_tem_path, exp_path, backup_path + "\\" + dayString+".log");
        }

    }
}
