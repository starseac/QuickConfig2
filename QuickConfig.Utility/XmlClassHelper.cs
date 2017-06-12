
using System.IO;
using System.Xml.Serialization;


namespace QuickConfig.Utility
{
    public static class XmlClassHelper
    {
        public static T LoadXML2Class<T>(string path) where T : class
        {
            T config = null;
            var xmlser = new XmlSerializer(typeof(T));

            using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                config = xmlser.Deserialize(fs) as T;
            }
            return config;
        }
        public static void SaveClass2Xml<T>(T source, string savePath)
        {
            var xmlser = new XmlSerializer(typeof(T));
            using (var fs = new FileStream(savePath, FileMode.Create, FileAccess.Write))
            {
                xmlser.Serialize(fs, source);
            }
        }
        //public static T Copy<T>(T source) where T:class 
        //{
        //    var xmlser = new XmlSerializer(typeof(T));
        //    T config = null;
        //    using (var fs = new MemoryStream())
        //    {
        //        xmlser.Serialize(fs, source);
        //        config = xmlser.Deserialize(fs) as T;
        //    }
        //    return config;
        //}
    }
}
