using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ServiceProcess;

namespace QuickConfig.Controls
{
   public class Common
    {
        public static string folderPath()
        {
            string folderPath = "";
            FolderBrowserDialog folderfDialog = new FolderBrowserDialog();
            folderfDialog.Description = "请选着文件夹";
            if (folderfDialog.ShowDialog() == DialogResult.OK)
            {
                folderPath = folderfDialog.SelectedPath;

            }
            return folderPath;
        }

        public static string folderPath(string DefinefolderPath)
        {
            string folderPath = "";
            FolderBrowserDialog folderfDialog = new FolderBrowserDialog();
            folderfDialog.SelectedPath = DefinefolderPath;
            folderfDialog.Description = "请选着文件夹";
            if (folderfDialog.ShowDialog() == DialogResult.OK)
            {
                folderPath = folderfDialog.SelectedPath;

            }
            return folderPath;
        }


        public static string filePath(string format)
        {
            string filePath = "";
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = true;
            fileDialog.Title = "请选择文件";
            fileDialog.Filter = "所有文件(*." + format + ")|*." + format + "";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = fileDialog.FileName;
            }
            return filePath;
        }

        public static string filePath(string format, string defineOpenFolder)
        {
            string filePath = "";
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.InitialDirectory = defineOpenFolder;
            fileDialog.Multiselect = true;
            fileDialog.Title = "请选择文件";
            fileDialog.Filter = "所有文件(*." + format + ")|*." + format + "";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = fileDialog.FileName;
            }
            return filePath;
        }

        public static bool checkFolder(string folderPath)
        {
            return System.IO.Directory.Exists(folderPath);

        }

        public static bool checkGDBFolder(string folderPath)
        {
            if (System.IO.Directory.Exists(folderPath))
            {
                string[] args = folderPath.Split('.');
                string lastStr = args[args.Length - 1];
                if (lastStr.ToUpper() == "GDB")
                {
                    return true;

                }
                else
                {
                    return false;
                }

            }
            else
            {
                return false;
            }

        }

        public static bool checkFile(string filePath)
        {
            return System.IO.File.Exists(filePath);
        }

        public static string getSdeEcpFile() {
            return AppDomain.CurrentDomain.BaseDirectory + @"tools\Server101.ecp";
        
        }

        public static string getToolsFolder() {
            return AppDomain.CurrentDomain.BaseDirectory + @"tools";        
        }
        public static string getToolsTempFolder()
        {
            return AppDomain.CurrentDomain.BaseDirectory + @"toolsTemp";
        }

        public static string getConfigFolder()
        {
            return AppDomain.CurrentDomain.BaseDirectory + @"config";
        }

        public static string getConfigTemplateFolder()
        {
            return AppDomain.CurrentDomain.BaseDirectory + @"configTemplate";
        }
        public static string getConfigTemplateTempFolder()
        {
            return AppDomain.CurrentDomain.BaseDirectory + @"configTemplateTemp";
        }
        public static string getServicesFolder()
        {
            return AppDomain.CurrentDomain.BaseDirectory + @"Services";
        }

        public static string getInstallConfigFolder()
        {
            return AppDomain.CurrentDomain.BaseDirectory + @"installConfig";
        }

        public static string getInstallPackagesFolder()
        {
            return AppDomain.CurrentDomain.BaseDirectory + @"installPackages";
        }

        public static string getInstallShowFolder()
        {
            return AppDomain.CurrentDomain.BaseDirectory + @"installShow";
        }

        public static string getServiceState(string servicename)
        {
            //看打印服务状态
            try
            {
                ServiceController sc = new ServiceController(servicename);
                string status = "";
                if (sc.Status.ToString() == "Running")
                {
                    status = "正在运行";
                }
                else if (sc.Status.ToString() == "Stopped")
                {

                    status = "已经停止";
                }

                return status;
            }
            catch (Exception eg)
            {
                return "服务未安装";
            }
        }
       
    }
}
