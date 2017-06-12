using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Data;
using System.IO;
using QuickConfig.Model;
using QuickConfig.Utility;
using QuickConfig.Model.app;
using QuickConfig.Model.db;

namespace QuickConfig.Common
{
    public class setXml
    {

        public static Set getConfig(string configName)
        {
            string configPath = AppDomain.CurrentDomain.BaseDirectory + "config\\" + configName + ".xml";
            Set configset = XmlClassHelper.LoadXML2Class<Set>(configPath);
            return configset;

        }

        public static void saveConfig(string configName, Set configset)
        {
            string configPath2 = AppDomain.CurrentDomain.BaseDirectory + "config\\" + configName + ".xml";

            XmlClassHelper.SaveClass2Xml<Set>(configset, configPath2);
        }

        public static void deleteConfig(string configName)
        {
            string configPath = AppDomain.CurrentDomain.BaseDirectory + "config\\" + configName + ".xml";

            string configTemplatePath = AppDomain.CurrentDomain.BaseDirectory + "configTemplate\\" + configName;

            if (File.Exists(configPath))
            {
                File.Delete(configPath);
            }
            if (Directory.Exists(configTemplatePath))
            {
                Directory.Delete(configTemplatePath);
            }

        }


        public static ConfigSet getAppConfig()
        {
            string appconfigPath = AppDomain.CurrentDomain.BaseDirectory + "config\\app.set";
            ConfigSet config = XmlClassHelper.LoadXML2Class<ConfigSet>(appconfigPath);
            return config;

        }

        public static void saveAppConfig(ConfigSet configset) {
            string configPath2 = AppDomain.CurrentDomain.BaseDirectory + "config\\app.set";
            XmlClassHelper.SaveClass2Xml<ConfigSet>(configset, configPath2);
        
        }

        public static List<parset> getPars(string configName)
        {
            Set config = getConfig(configName);
            List<parset> parList = new List<parset>();

            Set2ParList sp = new Set2ParList();
            parList = sp.getList(config);
            return parList;
        }
        

        public static Set getConfigByFile(string fileName)
        {
            Set configset = XmlClassHelper.LoadXML2Class<Set>(fileName);
            return configset;

        }

        public DataTable readXMLCopyPath()
        {
            string fileurl = AppDomain.CurrentDomain.BaseDirectory + @"\config\copyPath.xml";
            DataSet ds = new DataSet();
            ds.ReadXml(fileurl);

            DataTable parSets = ds.Tables["copy"];
            return parSets;

        }

        public void scan(DirectoryInfo AppFolder, List<string> list)
        {

            foreach (DirectoryInfo folder in AppFolder.GetDirectories())
            {

                DirectoryInfo Folder = new DirectoryInfo(folder.FullName + @"\" + folder.Name);
                scan(folder, list);
            }

            //遍历文件
            foreach (FileInfo NextFile in AppFolder.GetFiles())
            {
                list.Add(NextFile.FullName);
            }
        }

        public List<string> scanfiles(string configTemplateFolder)
        {
            List<string> filepath = new List<string>();

            DirectoryInfo TheFolder = new DirectoryInfo(configTemplateFolder);
            //遍历文件夹
            foreach (DirectoryInfo NextFolder in TheFolder.GetDirectories())
            {
                DirectoryInfo AppFolder = new DirectoryInfo(TheFolder.FullName + @"\" + NextFolder.Name);
                scan(AppFolder, filepath);

                //foreach (FileInfo NextFile in AppFolder.GetFiles())
                //{
                //    filepath.Add(NextFile.FullName);
                //}

            }
            return filepath;

        }


        public void addCopyFileXML(string configFolder, string configTemplateFolder, string configxmlname, string copyfilename)
        {
            List<string> filepath = scanfiles(configTemplateFolder + "\\" + configxmlname);
            string url = configFolder + @"\\" + copyfilename + ".xml";

            XmlTextWriter xw = new XmlTextWriter(url, Encoding.UTF8);

            xw.Formatting = Formatting.Indented;

            xw.WriteStartDocument();
            xw.WriteStartElement("copyset");

            //---

            if (filepath != null && filepath.Count >= 1)
            {

                foreach (string pathString in filepath)
                {
                    string newpathString = pathString.Replace(configTemplateFolder + "\\", "");
                    string projectname = newpathString.Split('\\')[0];
                    string configFolderStr = newpathString.Split('\\')[1];
                    string file = newpathString.Substring(projectname.Length + configFolderStr.Length + 1);

                    //申请书页面
                    xw.WriteStartElement("copy");
                    xw.WriteAttributeString("projectname", projectname);
                    xw.WriteAttributeString("configFolder", configFolderStr);
                    xw.WriteAttributeString("filepath", file);
                    xw.WriteEndElement();
                }
            }

            xw.WriteEndElement();
            xw.WriteEndDocument();

            xw.Flush();
            xw.Close();

        }


        public void CreateInstallXML(Set set, string installConfigFolder)
        {
            string url = installConfigFolder + @"\\install.xml";

            XmlTextWriter xw = new XmlTextWriter(url, Encoding.UTF8);

            xw.Formatting = Formatting.Indented;

            xw.WriteStartDocument();
            xw.WriteStartElement("install");

            foreach (ServiceApp sa in set.Apps.ServiceAppList)
            {

                xw.WriteStartElement("package");
                xw.WriteAttributeString("type", "serviceapp");
                xw.WriteAttributeString("name", sa.Label);
                xw.WriteAttributeString("xmlname", sa.Name);
                xw.WriteEndElement();
            }

            foreach (WebApp sa in set.Apps.WebAppList)
            {

                xw.WriteStartElement("package");
                xw.WriteAttributeString("type", "webapp");
                xw.WriteAttributeString("name", sa.Label);
                xw.WriteAttributeString("xmlname", sa.Name);
                xw.WriteEndElement();
            }

            foreach (App sa in set.Apps.AppList)
            {

                xw.WriteStartElement("package");
                xw.WriteAttributeString("type", "app");
                xw.WriteAttributeString("name", sa.Label);
                xw.WriteAttributeString("xmlname", sa.Name);
                xw.WriteEndElement();
            }
            foreach (DbUser sa in set.Db.DbUserList)
            {

                xw.WriteStartElement("package");
                xw.WriteAttributeString("type", "dmp");
                xw.WriteAttributeString("name", "exp-" + sa.User);
                xw.WriteAttributeString("xmlname", sa.Name);
                xw.WriteEndElement();
            }
            foreach (DbSdeUser sa in set.Db.DbSdeUserList)
            {

                xw.WriteStartElement("package");
                xw.WriteAttributeString("type", "gdb");
                xw.WriteAttributeString("name", sa.User);
                xw.WriteAttributeString("xmlname", sa.Name);
                xw.WriteEndElement();
            }


            xw.WriteEndElement();
            xw.WriteEndDocument();

            xw.Flush();
            xw.Close();


        }

        public DataTable readInstallXML(string installConfigFolder)
        {
            string fileurl = installConfigFolder + @"\install.xml";
            DataSet ds = new DataSet();
            ds.ReadXml(fileurl);
            DataTable parSets = ds.Tables["package"];
            return parSets;

        }

    }
}
