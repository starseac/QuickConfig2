using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Runtime.Serialization;
namespace QuickConfig.Model
{
    
    public class BackupContent
    {
       
        public string Name { set; get; }

       
        public List<BackupContentType> Type{ set; get; }
    }
}
