using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace QuickConfig.Model
{
 
   public class ConfigPar
    {

        private string _name;
        private string _desc;
        private string _value;

        [XmlAttribute("name")]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        [XmlAttribute("desc")]
        public string Desc
        {
            get { return _desc; }
            set { _desc = value; }
        }
        [XmlAttribute("value")]
        public string Value
        {
            get { return _value; }
            set { _value = value; }
        }
    }
}
