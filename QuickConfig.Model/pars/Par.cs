using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace QuickConfig.Model.pars
{
   public class Par
    {
       private string _label;
        private string _key;       
        private string _value;

        [XmlAttribute("label")]
        public string Label
        {
            get { return _label; }
            set { _label = value; }
        }

       [XmlAttribute("key")]
        public string Key
        {
            get { return _key; }
            set { _key = value; }
        }
       [XmlAttribute("value")]
        public string Value
        {
            get { return _value; }
            set { _value = value; }
        }
     
    }
}
