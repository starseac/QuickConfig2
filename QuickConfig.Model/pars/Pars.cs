using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace QuickConfig.Model.pars
{
  public class Pars
    {
      private List<Par> _parList;
       [XmlElement("par")]
      public List<Par> ParList
      {
          get { return _parList; }
          set { _parList = value; }
      }
    }
}
