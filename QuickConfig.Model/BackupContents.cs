using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Runtime.Serialization;
namespace QuickConfig.Model
{
    
    public class BackupContents
    {  
        public List<BackupContent> content{ set; get; }
    }
}
