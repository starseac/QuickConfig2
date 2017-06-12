using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace QuickConfig.Model.db
{
  public  class Db
    {
        private string _name;
        private string _label;
        private string _ip;
        private string _datasource;
        private bool _datafolder_type;
        private string _datafolder;
        private string _cs_type;
        private string _wkid;
        private string _prjpath;
        private string _impfolder;
        private string _relativepath;

        private DbSystemUser _dbSystemUser;
        private List<DbUser> _dbUserList;
        private List<DbSdeUser> _dbSdeUserList;
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
      [XmlAttribute("ip")]
      public string Ip
      {
          get { return _ip; }
          set { _ip = value; }
      }

      [XmlAttribute("datasource")]
        public string Datasource
        {
            get { return _datasource; }
            set { _datasource = value; }
        }
      [XmlAttribute("datafolder_type")]
        public bool Datafolder_type
        {
            get { return _datafolder_type; }
            set { _datafolder_type = value; }
        }
      [XmlAttribute("datafolder")]
        public string Datafolder
        {
            get { return _datafolder; }
            set { _datafolder = value; }
        }
      [XmlAttribute("cs_type")]
      public string CS_TYPE
      {
          get { return _cs_type; }
          set { _cs_type = value; }
      }
      [XmlAttribute("wkid")]
      public string WKID
      {
          get { return _wkid; }
          set { _wkid = value; }
      }
      [XmlAttribute("prjpath")]
      public string Prjpath
      {
          get { return _prjpath; }
          set { _prjpath = value; }
      }
      [XmlAttribute("impfolder")]
        public string Impfolder
        {
            get { return _impfolder; }
            set { _impfolder = value; }
        }
      [XmlAttribute("relativepath")]
      public string Relativepath
      {
          get { return _relativepath; }
          set { _relativepath = value; }
      }
      [XmlElement("systemuser")]
        public DbSystemUser DbSystemUser
        {
            get { return _dbSystemUser; }
            set { _dbSystemUser = value; }
        }
      [XmlElement("user")]
        public List<DbUser> DbUserList
        {
            get { return _dbUserList; }
            set { _dbUserList = value; }
        }
      [XmlElement("sdeuser")]
        public List<DbSdeUser> DbSdeUserList
        {
            get { return _dbSdeUserList; }
            set { _dbSdeUserList = value; }
        }
      
    }
}
