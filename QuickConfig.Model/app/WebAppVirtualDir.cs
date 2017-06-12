using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace QuickConfig.Model.app
{
    public class WebAppVirtualDir
    {
        private string _name;
        private string _virtualName;
        private string _path;
      
        [XmlAttribute("name")]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        [XmlAttribute("virtualname")]
        public string VirtualName
        {
            get { return _virtualName; }
            set { _virtualName = value; }
        }
        [XmlAttribute("path")]
        public string Path
        {
            get { return _path; }
            set { _path = value; }
        }
       
    }
}
