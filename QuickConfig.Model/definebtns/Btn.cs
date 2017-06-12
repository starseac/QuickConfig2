using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace QuickConfig.Model.definebtns
{
   public class Btn
    {
       private string _name;
       private string _desc;
       private string _type;
       private string _execuser;
       private string _filename;
       private bool _install;

       private List<Input> _inputList;
       
       [XmlAttribute("name")]
       public string Name {
           get { return _name; }
           set { this._name = value; }
       }

       [XmlAttribute("desc")]
       public string Desc
       {
           get { return _desc; }
           set { this._desc = value; }
       }

       [XmlAttribute("type")]
       public string Type
       {
           get { return  _type; }
           set { this._type = value; }
       }

       [XmlAttribute("execuser")]
       public string Execuser
       {
           get { return _execuser; }
           set { this._execuser = value; }
       }

       [XmlAttribute("filename")]
       public string Filename
       {
           get { return _filename; }
           set { this._filename = value; }
       }

       [XmlAttribute("install")]
       public bool Install
       {
           get { return _install; }
           set { this._install = value; }
       }


       [XmlElement("input")]
       public List<Input> InputList
       {
           get { return _inputList; }
           set { this._inputList = value; }
       }

    }
}
