using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace QuickConfig.Model
{
   public class BackupContentType
    {
       
        public string Name { set; get; }

        public string Type { set; get; }
       
        public List<BackupContentSet> Set { set; get; }


        public List<string> getValueList(string keyString) {

            List<string> valueList = new List<string>();

            if(Set!=null&&Set.Count>0){
                List<BackupContentSet> bcslist = Set.FindAll((BackupContentSet bcs)=>bcs.SetKey==keyString);
                
                 if(bcslist!=null&&bcslist.Count>0){
                     foreach (BackupContentSet bcsset in bcslist) {
                         valueList.Add(bcsset.SetValue);                     
                     }                 
                 }                
            }

            return valueList;
        }
    }
}
