using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace QuickConfig.Model.backup
{
    public class Backup
    {
        private string _name;
        private string _label;
        private string _path;
        private string _content;
        private string _type;
        private string _type_daytime;
        private string _type_week;
        private string _type_weektime;
        private string _type_month;
        private string _type_monthtime;
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
        [XmlAttribute("content")]
        public string Content
        {
            get { return _content; }
            set { _content = value; }
        }
        [XmlAttribute("type")]
        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }
        [XmlAttribute("type_daytime")]
        public string Type_daytime
        {
            get { return _type_daytime; }
            set { _type_daytime = value; }
        }
        [XmlAttribute("type_week")]
        public string Type_week
        {
            get { return _type_week; }
            set { _type_week = value; }
        }
        [XmlAttribute("type_weektime")]
        public string Type_weektime
        {
            get { return _type_weektime; }
            set { _type_weektime = value; }
        }
        [XmlAttribute("type_month")]
        public string Type_month
        {
            get { return _type_month; }
            set { _type_month = value; }
        }
        [XmlAttribute("type_monthtime")]
        public string Type_monthtime
        {
            get { return _type_monthtime; }
            set { _type_monthtime = value; }
        }
    }
}
