
using System.IO;
using Newtonsoft.Json;


namespace QuickConfig.Utility
{
    public static class JsonClassHelper
    {
        public static T Json2Class<T>(string jsonStr) where T : class
        {
            return JsonConvert.DeserializeObject<T>(jsonStr);
        }
        public static string Class2Json<T>(T source)
        {
            return JsonConvert.SerializeObject(source);
        }

    }
}