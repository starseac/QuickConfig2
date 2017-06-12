using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;
using System.Data;

namespace QuickConfig.Common
{
    public class setBAT
    {

        public static void RunBat(string batPath, bool isshow)
        {

            Process pro = new Process();

            FileInfo file = new FileInfo(batPath);

            pro.StartInfo.WorkingDirectory = file.Directory.FullName;

            pro.StartInfo.FileName = batPath;

            pro.StartInfo.CreateNoWindow = true;
            if (!isshow)
            {
                pro.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            }

            pro.Start();

            pro.WaitForExit();

        }

        public static void RunBatByDefine(string toolsFolder, string toolsTempFolder, string filename, List<string[]> inputList,bool isshow)
        {
            DataTable dtPar = new DataTable();
            dtPar.Columns.Add("name", typeof(string));
            dtPar.Columns.Add("value", typeof(string));
            //然后把你想要加的数据加进DataTable 里
            foreach (string[] str in inputList)
            {
                dtPar.Rows.Add(new object[] { str[0], str[1] });
            }
            setConfig setconfig = new Common.setConfig();
            setconfig.repalceParByDefine(toolsFolder, filename+".bat", toolsTempFolder, dtPar);
            setBAT.RunBat(toolsTempFolder + @"\"+filename+".bat", isshow);

        }

        public static void OpenFolder(string toolsFolder, string toolsTempFolder, string folderPath)
        {
            DataTable dtPar = new DataTable();
            dtPar.Columns.Add("name", typeof(string));
            dtPar.Columns.Add("value", typeof(string));
            //然后把你想要加的数据加进DataTable 里
            dtPar.Rows.Add(new object[] { "folder", folderPath });
            setConfig setconfig = new Common.setConfig();
            setconfig.repalceParByDefine(toolsFolder, "explorerFolder.bat", toolsTempFolder, dtPar);
            setBAT.RunBat(toolsTempFolder + @"\explorerFolder.bat", true);
        }

        public static void OpenFileWithNotepad(string toolsFolder, string toolsTempFolder, string filePath)
        {
            DataTable dtPar = new DataTable();
            dtPar.Columns.Add("name", typeof(string));
            dtPar.Columns.Add("value", typeof(string));
            //然后把你想要加的数据加进DataTable 里          
            dtPar.Rows.Add(new object[] { "file", filePath });
            setConfig setconfig = new Common.setConfig();
            setconfig.repalceParByDefine(toolsFolder, "explorerFile.bat", toolsTempFolder, dtPar);
            setBAT.RunBat(toolsTempFolder + @"\explorerFile.bat", true);
        }

        public static void FilePackage(string toolsFolder, string toolsTempFolder, string filedesc, string filepath, string packagefilepath, bool isFolder, List<string> excludeFolderList, List<string> excludeFileList, bool isshow)
        {
            DataTable dtPar = new DataTable();
            dtPar.Columns.Add("name", typeof(string));
            dtPar.Columns.Add("value", typeof(string));
            //然后把你想要加的数据加进DataTable 里
            dtPar.Rows.Add(new object[] { "7zfolder", toolsFolder });
            dtPar.Rows.Add(new object[] { "filename", filedesc });
            dtPar.Rows.Add(new object[] { "target", packagefilepath + ".7z" });
            dtPar.Rows.Add(new object[] { "orifolder", filepath });
            string packageType = isFolder ? "\\*" : "";
            dtPar.Rows.Add(new object[] { "FolderOrFile", packageType });
            setConfig setconfig = new Common.setConfig();
            if (excludeFolderList != null && excludeFolderList.Count > 0)
            {
                FilePackage_setExcludeFolder(toolsFolder, toolsTempFolder, filepath, excludeFolderList);
                dtPar.Rows.Add(new object[] { "excludeFolder", "-xr@" + toolsTempFolder + @"\7z_package_excludeFolder.txt" });
            }
            else {
                dtPar.Rows.Add(new object[] { "excludeFolder", "" });
            }
            if (excludeFileList != null && excludeFileList.Count > 0)
            {
                FilePackage_setExcludeFile(toolsFolder, toolsTempFolder, filepath, excludeFileList);
                dtPar.Rows.Add(new object[] { "excludeFile", "-x@" + toolsTempFolder + @"\7z_package_excludeFile.txt" });
            }
            else {
                dtPar.Rows.Add(new object[] { "excludeFile", "" });
            
            }
            setconfig.repalceParByDefine(toolsFolder, "7z_package.bat", toolsTempFolder, dtPar);
            setBAT.RunBat(toolsTempFolder + @"\7z_package.bat", true);

        }

        private static void write(string filepath,string content)
        {
            StreamWriter sw = null;
            try
            {
                sw = new StreamWriter(filepath, true);
                sw.Write(content + "\r\n");
            }
            catch { }
            finally
            {
                sw.Close();
                sw.Dispose();
            }

        }

        private static void FilePackage_setExcludeFolder(string toolsFolder, string toolsTempFolder,string parenteFolderPath,List<string>excludeFolderList) {
            string excludeFolderFilePath = toolsFolder + "\\7z_package_excludeFolder.txt";
            string excludeFolderFileTempPath = toolsTempFolder + "\\7z_package_excludeFolder.txt";
            File.Copy(excludeFolderFilePath, excludeFolderFileTempPath,true);
            foreach(string xzpath in excludeFolderList){
                write(excludeFolderFileTempPath, parenteFolderPath  + xzpath);            
            }
        
        }

        private static void FilePackage_setExcludeFile(string toolsFolder, string toolsTempFolder, string parenteFolderPath, List<string> excludeFileList)
        {
            string excludeFolderFilePath = toolsFolder + "\\7z_package_excludeFile.txt";
            string excludeFolderFileTempPath = toolsTempFolder + "\\7z_package_excludeFile.txt";
            File.Copy(excludeFolderFilePath, excludeFolderFileTempPath, true);
            foreach (string xzpath in excludeFileList)
            {
                write(excludeFolderFileTempPath, parenteFolderPath  + xzpath);
            }
        }


        public static void FileExtract(string toolsFolder, string toolsTempFolder, string filedesc, string packagePath, string extractFolder, bool isshow)
        {
            DataTable dtPar = new DataTable();
            dtPar.Columns.Add("name", typeof(string));
            dtPar.Columns.Add("value", typeof(string));
            //然后把你想要加的数据加进DataTable 里
            dtPar.Rows.Add(new object[] { "7zfolder", toolsFolder });
            dtPar.Rows.Add(new object[] { "filename", filedesc });
            dtPar.Rows.Add(new object[] { "targetfile", packagePath });
            dtPar.Rows.Add(new object[] { "targetfolder", extractFolder });
            setConfig setconfig = new Common.setConfig();
            setconfig.repalceParByDefine(toolsFolder, "7z_extract.bat", toolsTempFolder, dtPar);
            Common.setBAT.RunBat(toolsTempFolder + @"\7z_extract.bat", isshow);


        }

        public static void OracleExp(string toolsFolder, string toolsTempFolder, string user, string password, string datasource, string dmpdesc, string exportpath, bool isshow)
        {
            //设置空表导出参数
            setDB setdb = new setDB(user, password, datasource);
            setdb.setEXP();
            DataTable dtPar = new DataTable();
            dtPar.Columns.Add("name", typeof(string));
            dtPar.Columns.Add("value", typeof(string));
            //然后把你想要加的数据加进DataTable 里
            dtPar.Rows.Add(new object[] { "dmpdesc", dmpdesc });
            dtPar.Rows.Add(new object[] { "backupday", exportpath });
            dtPar.Rows.Add(new object[] { "user", user });
            dtPar.Rows.Add(new object[] { "password", password });
            dtPar.Rows.Add(new object[] { "datasource", datasource });
            setConfig setconfig = new Common.setConfig();
            setconfig.repalceParByDefine(toolsFolder, "Oracle_exp.bat", toolsTempFolder, dtPar);
            setBAT.RunBat(toolsTempFolder + @"\Oracle_exp.bat", isshow);

        }

        public static void OracleExpdp(string toolsFolder, string toolsTempFolder, string user, string password, string datasource, string dmpdesc, string exportpath,string remoteIP,string remoteAccount,string remotePassword,List<string> excludeTableList, bool isshow)
        {
            //设置空表导出参数
            setDB setdb = new setDB(user, password, datasource);
            setdb.setEXP();
            DataTable dtPar = new DataTable();
            dtPar.Columns.Add("name", typeof(string));
            dtPar.Columns.Add("value", typeof(string));
            //然后把你想要加的数据加进DataTable 里
            dtPar.Rows.Add(new object[] { "dmpdesc", dmpdesc });
            dtPar.Rows.Add(new object[] { "backupday", exportpath });
            dtPar.Rows.Add(new object[] { "user", user });
            dtPar.Rows.Add(new object[] { "password", password });
            dtPar.Rows.Add(new object[] { "datasource", datasource });

            dtPar.Rows.Add(new object[] { "remoteIP", remoteIP });
            dtPar.Rows.Add(new object[] { "remoteAccount", remoteAccount });
            dtPar.Rows.Add(new object[] { "remotePassword", remotePassword });
            SqlExec(toolsFolder, toolsTempFolder, user, password, datasource, "sys_createdumpdir", new List<string[]>(), isshow);

            if (excludeTableList != null && excludeTableList.Count > 0)
            {
                string tablesString = "";
                foreach (string tablename in excludeTableList)
                {
                    if (tablesString == "")
                    {
                        tablesString += "'" + tablename + "'";
                    }
                    else
                    {
                        tablesString += ",'" + tablename + "'";
                    }

                }
                dtPar.Rows.Add(new object[] { "excludeTable", "EXCLUDE=TABLE:\\\"IN (" + tablesString + ")\\\"" });

            }
            else {
                dtPar.Rows.Add(new object[] { "excludeTable", "" });            
            }
            setConfig setconfig = new Common.setConfig();
            setconfig.repalceParByDefine(toolsFolder, "Oracle_expdp.bat", toolsTempFolder, dtPar);
            setBAT.RunBat(toolsTempFolder + @"\Oracle_expdp.bat", isshow);

        }



        public static void SqlExec(string toolsFolder, string toolsTempFolder, string user, string password, string datasource,string sqlfilename, List<string[]> inputList,bool isShow) {
            string batfilePath = toolsFolder + "\\sql_exec.bat";
            string sqlfilePath = toolsFolder + "\\sqls\\" + sqlfilename + ".sql";

            DataTable dtPar = new DataTable();
            dtPar.Columns.Add("name", typeof(string));
            dtPar.Columns.Add("value", typeof(string));
            //然后把你想要加的数据加进DataTable 里
            foreach (string[] str in inputList)
            {
                dtPar.Rows.Add(new object[] { str[0], str[1] });
            }
            setConfig setconfig = new setConfig();
            setconfig.repalceParByDefine(toolsFolder + "\\sqls", sqlfilename + ".sql", toolsTempFolder, dtPar);


            string sqlpath = toolsTempFolder + "\\" + sqlfilename + ".sql";
            string logpath = toolsTempFolder + "\\" + sqlfilename + System.Guid.NewGuid().ToString() + ".log";
            
            List<string[]> BatinputList = new List<string[]>();

            string[] str1 = new string[2];
            str1[0] = "user";
            str1[1] = user;
            BatinputList.Add(str1);
            string[] str2 = new string[2];
            str2[0] = "password";
            str2[1] = password;
            BatinputList.Add(str2);
            string[] str3 = new string[2];
            str3[0] = "datasource";
            str3[1] = datasource;
            BatinputList.Add(str3);
            string[] str4 = new string[2];
            str4[0] = "sqlpath";
            str4[1] = sqlpath;
            BatinputList.Add(str4);
            string[] str5 = new string[2];
            str5[0] = "logpath";
            str5[1] = logpath;
            BatinputList.Add(str5);

            RunBatByDefine(toolsFolder, toolsTempFolder, "sql_exec", BatinputList, isShow);
        
        
        }

        public static void OracleImp(string toolsFolder, string toolsTempFolder, string user, string password, string datasource, string filepath, string impfolder, bool isshow)
        {
            DataTable dtPar = new DataTable();
            dtPar.Columns.Add("name", typeof(string));
            dtPar.Columns.Add("value", typeof(string));
            //然后把你想要加的数据加进DataTable 里
            dtPar.Rows.Add(new object[] { "user", user });
            dtPar.Rows.Add(new object[] { "password", password });
            dtPar.Rows.Add(new object[] { "datasource", datasource });
            dtPar.Rows.Add(new object[] { "dmpfile", filepath });
            dtPar.Rows.Add(new object[] { "impfolder", impfolder });
            setConfig setconfig = new Common.setConfig();
            setconfig.repalceParByDefine(toolsFolder, "oracle_imp.bat", toolsTempFolder, dtPar);
            Common.setBAT.RunBat(toolsTempFolder + @"\oracle_imp.bat", isshow);

        }


        public static void AppServiceInstall(string appPath, string installbatPath, bool isshow)
        {
            setBAT.RunBat(appPath + @"\" + installbatPath, isshow);

        }

        public static void ServiceInstall(string toolsFolder, string toolsTempFolder, string servicedesc, string servicename, string exepath, bool isshow)
        {
            DataTable dtPar = new DataTable();
            dtPar.Columns.Add("name", typeof(string));
            dtPar.Columns.Add("value", typeof(string));
            //然后把你想要加的数据加进DataTable 里
            dtPar.Rows.Add(new object[] { "servicedesc", servicedesc });
            dtPar.Rows.Add(new object[] { "servicename", servicename });
            dtPar.Rows.Add(new object[] { "exepath", exepath });
            setConfig setconfig = new setConfig();
            setconfig.repalceParByDefine(toolsFolder, "Service_Install.bat", toolsTempFolder, dtPar);
            setBAT.RunBat(toolsTempFolder + @"\Service_Install.bat", isshow);

        }

        public static void ServiceRun(string toolsFolder, string toolsTempFolder, string servicedesc, string servicename, bool isshow)
        {
            DataTable dtPar = new DataTable();
            dtPar.Columns.Add("name", typeof(string));
            dtPar.Columns.Add("value", typeof(string));
            //然后把你想要加的数据加进DataTable 里
            dtPar.Rows.Add(new object[] { "servicedesc", servicedesc });
            dtPar.Rows.Add(new object[] { "servicename", servicename });
            setConfig setconfig = new Common.setConfig();
            setconfig.repalceParByDefine(toolsFolder, "Service_Start.bat", toolsTempFolder, dtPar);
            setBAT.RunBat(toolsTempFolder + @"\Service_Start.bat", isshow);

        }
        public static void ServiceStop(string toolsFolder, string toolsTempFolder, string servicedesc, string servicename, bool isshow)
        {
            DataTable dtPar = new DataTable();
            dtPar.Columns.Add("name", typeof(string));
            dtPar.Columns.Add("value", typeof(string));
            //然后把你想要加的数据加进DataTable 里
            dtPar.Rows.Add(new object[] { "servicedesc", servicedesc });
            dtPar.Rows.Add(new object[] { "servicename", servicename });
            setConfig setconfig = new setConfig();
            setconfig.repalceParByDefine(toolsFolder, "Service_Stop.bat", toolsTempFolder, dtPar);
            setBAT.RunBat(toolsTempFolder + @"\Service_Stop.bat", true);

        }

        public static void AppServiceRemove(string appPath, string removebatPath, bool isshow)
        {
            setBAT.RunBat(appPath + @"\" + removebatPath, isshow);
        }

        public static void ServiceRemove(string toolsFolder, string toolsTempFolder, string servicedesc, string exepath, bool isshow)
        {
            DataTable dtPar = new DataTable();
            dtPar.Columns.Add("name", typeof(string));
            dtPar.Columns.Add("value", typeof(string));
            //然后把你想要加的数据加进DataTable 里
            dtPar.Rows.Add(new object[] { "servicedesc", servicedesc });
            dtPar.Rows.Add(new object[] { "exepath", exepath });
            setConfig setconfig = new setConfig();
            setconfig.repalceParByDefine(toolsFolder, "Service_Unistall.bat", toolsTempFolder, dtPar);
            setBAT.RunBat(toolsTempFolder + @"\Service_Unistall.bat", isshow);

        }


    }
}
