using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace QuickConfig.Model.app
{
    public class WebApp
    {
        private string _name;
        private string _label;
        private string _path;
        private string _relativepath;
        private string _configFolder;
        private string _siteName;
        private string _ip;
        private string _port;
        private bool _x86bit;

        private List<WebAppVirtualDir> _virtualDirList;

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
        [XmlAttribute("sitename")]
        public string SiteName
        {
            get { return _siteName; }
            set { _siteName = value; }
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
        [XmlAttribute("x86bit")]
        public bool X86bit
        {
            get { return _x86bit; }
            set { _x86bit = value; }
        }

        [XmlElement("virtualdir")]
        public List<WebAppVirtualDir> VirtualDirList
        {
            get { return _virtualDirList; }
            set { _virtualDirList = value; }
        }
    }
}
