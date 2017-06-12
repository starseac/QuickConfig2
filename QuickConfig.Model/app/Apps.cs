using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace QuickConfig.Model.app
{
  public  class Apps
    {
        private string _name;
        private string _label;
        private string _path;
        private List<ServiceApp> _serviceAppList;
        private List<WebApp> _webAppList;
        private List<App> _appList;
        private List<Ftp> _ftpList;
        private List<Gxml> _gxmlList;
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
       [XmlElement("serviceapp")]
        public List<ServiceApp> ServiceAppList
        {
            get { return _serviceAppList; }
            set { _serviceAppList = value; }
        }
       [XmlElement("webapp")]
        public List<WebApp> WebAppList
        {
            get { return _webAppList; }
            set { _webAppList = value; }
        }
       [XmlElement("app")]
        public List<App> AppList
        {
            get { return _appList; }
            set { _appList = value; }
        }
       [XmlElement("ftp")]
        public List<Ftp> FtpList
        {
            get { return _ftpList; }
            set { _ftpList = value; }
        }
       [XmlElement("gxml")]
        public  List<Gxml> GxmlList
        {
            get { return _gxmlList; }
            set { _gxmlList = value; }
        }

      

       
    }
}
