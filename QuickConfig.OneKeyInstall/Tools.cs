using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceProcess;

namespace QuickConfig.OneKeyInstall
{
   public class Tools
    {
       public static string getInstallConfigFolder() {

           return AppDomain.CurrentDomain.BaseDirectory + "installConfig";
       }

       public static string getInstallPackagesFolder() {
           return AppDomain.CurrentDomain.BaseDirectory + "installPackages";
       }

       public static string getInstallShowFolder() {
           return AppDomain.CurrentDomain.BaseDirectory + "installShow";
       }
       
       public static string getSdeEcpFile()
       {
           return AppDomain.CurrentDomain.BaseDirectory + @"tools\Server101.ecp";

       }

       public static string getToolsFolder()
       {
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
