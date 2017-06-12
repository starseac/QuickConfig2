using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace QuickConfig.Model.app
{
   public class ServiceApp
    {
        private string _name;
        private string _label;
        private string _path;
        private string _relativepath;
        private string _configFolder;
        private string _ip;
        private string _port;
        private string _servicename;
        private string _installbat;
        private string _removebat;
      [XmlAttribute("name")]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
       [XmlAttribute("label")]
        public string Label
        {
            get { return _label; }
            set { _label = value; }
        }
       [XmlAttribute("path")]
        public string Path
        {
            get { return _path; }
            set { _path = value; }
        }
       [XmlAttribute("relativepath")]
       public string Relativepath
       {
           get { return _relativepath; }
           set { _relativepath = value; }
       }
       [XmlAttribute("configfolder")]
        public string ConfigFolder
        {
            get { return _configFolder; }
            set { _configFolder = value; }
        }
       [XmlAttribute("ip")]
        public string Ip
        {
            get { return _ip; }
            set { _ip = value; }
        }
       [XmlAttribute("port")]
        public string Port
        {
            get { return _port; }
            set { _port = value; }
        }
       [XmlAttribute("servicename")]
       public string Servicename
       {
           get { return _servicename; }
           set { _servicename = value; }
       }
       [XmlAttribute("installbat")]
       public string Installbat
       {
           get { return _installbat; }
           set { _installbat = value; }
       }


       [XmlAttribute("removebat")]
       public string Removebat
       {
           get { return _removebat; }
           set { _removebat = value; }
       }
       
    }
}
