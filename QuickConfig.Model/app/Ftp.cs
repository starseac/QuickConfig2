using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace QuickConfig.Model.app
{
   public class Ftp
    {
        private string _name;
        private string _label;
        private string _path;
        private string _relativepath;
        private string _ip;
        private string _user;
        private string _password;

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
       [XmlAttribute("ip")]
        public string Ip
        {
            get { return _ip; }
            set { _ip = value; }
        }
       [XmlAttribute("user")]
        public string User
        {
            get { return _user; }
            set { _user = value; }
        }
       [XmlAttribute("password")]
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        } 
    }
}
