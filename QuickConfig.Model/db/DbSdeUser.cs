using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace QuickConfig.Model.db
{
  public  class DbSdeUser
    {
        private string _name;
        private string _label;
        private string _tablespace;
        private string _user;
        private string _password;
        private string _gdbfile;
        private string _relativepath;
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
      [XmlAttribute("tablespace")]
        public string Tablespace
        {
            get { return _tablespace; }
            set { _tablespace = value; }
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
      [XmlAttribute("gdbfile")]
        public string Gdbfile
        {
            get { return _gdbfile; }
            set { _gdbfile = value; }
        }
      [XmlAttribute("relativepath")]
      public string Relativepath
      {
          get { return _relativepath; }
          set { _relativepath = value; }
      }
    }
}
