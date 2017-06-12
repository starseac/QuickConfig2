using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace QuickConfig.Model.definebtns
{
   public class Definebtns
    {
       private List<Btn> _btnList;

       [XmlElement("btn")]
       public List<Btn> BtnList {
           get { return _btnList; }
           set { this._btnList = value; }
       }
    }
}
