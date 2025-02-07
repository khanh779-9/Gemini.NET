using Newtonsoft.Json;

namespace Commons
{
    public static class JsonHelper
    {
        public static string AsString<T>(T obj)
        {
            return JsonConvert.SerializeObject(obj, Formatting.Indented);
        }

        public static T? AsObject<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
