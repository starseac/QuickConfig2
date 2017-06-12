using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace QuickConfig.Model
{
   [XmlRoot("configset")]
   public class ConfigSet
    {
       private List<ConfigPar> _configParList;
       [XmlElement("configpar")]
       public List<ConfigPar> ConfigParList {
            set { _configParList = value; }
            get { return _configParList; }
        }
    }
}
