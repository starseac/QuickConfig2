using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using QuickConfig.Model;

namespace QuickConfig.Common
{
    public class setConfig
    {

        public void scanAndCopy(DirectoryInfo AppFolder, DirectoryInfo NewAppFolder)
        {

            foreach (DirectoryInfo folder in AppFolder.GetDirectories())
            {

                DirectoryInfo Folder = new DirectoryInfo(AppFolder.FullName + @"\" + folder.Name);

                DirectoryInfo NewFolder = new DirectoryInfo(NewAppFolder.FullName + @"\" + folder.Name);
                Directory.CreateDirectory(NewFolder.FullName);
                scanAndCopy(Folder, NewFolder);
            }

            //遍历文件
            foreach (FileInfo NextFile in AppFolder.GetFiles())
            {
                System.IO.File.Copy(NextFile.FullName, NewAppFolder.FullName + @"\" + NextFile.Name);
            }
        }

        public void copyConfig(string oriFolder,string targetFolder,string configName)
        {

            DirectoryInfo TheFolder = new DirectoryInfo(oriFolder+"\\"+configName);

            DirectoryInfo TempFolder = new DirectoryInfo(targetFolder + "\\" + configName);
            if (Directory.Exists(TempFolder.FullName) == true)
            {
                TempFolder.Delete(true);
            }

            Directory.CreateDirectory(TempFolder.FullName);
            //遍历文件夹
            foreach (DirectoryInfo NextFolder in TheFolder.GetDirectories())
            {
                DirectoryInfo AppFolder = new DirectoryInfo(TheFolder.FullName + @"\" + NextFolder.Name);
                DirectoryInfo NewAppFolder = new DirectoryInfo(TempFolder.FullName + @"\" + NextFolder.Name);
                Directory.CreateDirectory(NewAppFolder.FullName);
                scanAndCopy(AppFolder, NewAppFolder);

            }

        }


        public System.Text.Encoding GetFileEncodeType(string filename)
        {
            System.IO.FileStream fs = new System.IO.FileStream(filename, System.IO.FileMode.Open, System.IO.FileAccess.Read);
            System.IO.BinaryReader br = new System.IO.BinaryReader(fs);
            Byte[] buffer = br.ReadBytes(2);

            fs.Close();
            br.Close();
            if (buffer[0] >= 0xEF)
            {
                if (buffer[0] == 0xEF && buffer[1] == 0xBB)
                {
                    return System.Text.Encoding.UTF8;
                }
                else if (buffer[0] == 0xFE && buffer[1] == 0xFF)
                {
                    return System.Text.Encoding.BigEndianUnicode;
                }
                else if (buffer[0] == 0xFF && buffer[1] == 0xFE)
                {
                    return System.Text.Encoding.Unicode;
                }
                else
                {
                    return System.Text.Encoding.Default;
                }
            }
            else
            {
                return System.Text.Encoding.Default;
            }
        }


        public void repalcePar(string configName,string targetFolder)
        {
            setXml xml = new setXml();
            List<parset> pars = setXml.getPars(configName);
            DataTable dtFile = xml.readXMLCopyPath();
            DirectoryInfo TempFolder = new DirectoryInfo(targetFolder);

            for (int i = 0; i < dtFile.Rows.Count; i++)
            {
                string path = TempFolder.FullName +"\\"+dtFile.Rows[i]["projectname"].ToString()  +"\\"+ dtFile.Rows[i]["configFolder"].ToString() + "" + dtFile.Rows[i]["filepath"].ToString();
                FileInfo file = new FileInfo(path);

                Encoding encoding;
                encoding = GetFileEncodeType(file.FullName);

                FileStream fs = new FileStream(path, FileMode.Open, FileAccess.ReadWrite);
                StreamReader sr;
              
              
                sr = new StreamReader(fs, encoding);
                string con = sr.ReadToEnd();
                foreach (parset par in pars)
                {
                    con = con.Replace("{$" + par.id + "."+par.key+"}", par.value);
                }
                sr.Close();
                fs.Close();
                File.WriteAllText(path, con, encoding);

            }

        }

      
        public void repalceParByDefine(string oriFileFolderPath, string filename, string targetFileFolderPath, DataTable dtPar)
        {
            if (File.Exists(targetFileFolderPath + "\\" + filename) == true)
            {
                File.Delete(targetFileFolderPath + "\\" + filename);
            }
            System.IO.File.Copy(oriFileFolderPath + "\\" + filename, targetFileFolderPath + "\\" + filename);
           

            string path = targetFileFolderPath + "\\" + filename;
            FileInfo file = new FileInfo(path);

            Encoding encoding;
            encoding = GetFileEncodeType(file.FullName);

            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.ReadWrite);
            StreamReader sr;


            sr = new StreamReader(fs, encoding);
            string con = sr.ReadToEnd();
            for (int j = 0; j < dtPar.Rows.Count; j++)
            {
                con = con.Replace("{" + dtPar.Rows[j]["name"].ToString() + "}", dtPar.Rows[j]["value"].ToString());
            }
            sr.Close();
            fs.Close();
            File.WriteAllText(path, con, encoding);

        }


        public void config(string oriFolder,string targetFolder,string configName,List<string[]> configFolder)
        {
            // 复制文件到  临时文件夹
            copyConfig(oriFolder,targetFolder,configName);
            // 替换参数 为真实值      
            repalcePar(configName,targetFolder);
            //应用配置到 程序
            applyConfig(targetFolder,configFolder);
        }

        private void applyConfig(string targetFolder,List<string[]> checkapp)
        {
            setXml xml = new setXml();
            DataTable dtFile = xml.readXMLCopyPath();

            foreach (string [] configFolder in checkapp)
            {
                DataTable selectDT = new DataTable();
                selectDT = dtFile.Clone();
                System.Data.DataRow[] selectDT_row = dtFile.Select("configFolder='" + configFolder[0] + "'");
                for (int j = 0; j < selectDT_row.Length; j++)
                {
                    selectDT.ImportRow((System.Data.DataRow)selectDT_row[j]);
                }

                for (int i = 0; i < selectDT.Rows.Count; i++)
                {
                    string oriFilePath = targetFolder + "\\" + selectDT.Rows[i]["projectname"].ToString()+"\\" + selectDT.Rows[i]["configFolder"].ToString() + selectDT.Rows[i]["filepath"].ToString();
                    string targetFilePath = configFolder[1] + selectDT.Rows[i]["filepath"].ToString();
                    if (File.Exists(targetFilePath))
                    {
                        File.Delete(targetFilePath);
                    }
                    File.Copy(oriFilePath, targetFilePath);

                }

            }
        }

     

    }
}
