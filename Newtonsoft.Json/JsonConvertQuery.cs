using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace Newtonsoft.Json
{
    public static class JsonConvertQuery
    {
        public static string ValueToQuery(string Prefix, string Key, string Value)
        {
            if (Regex.IsMatch(Value, "^[\\[\\{]"))
                if (string.IsNullOrEmpty(Prefix))
                    return JsonConvertQuery.DeserializeQuery(Value, Key);
                else
                    return JsonConvertQuery.DeserializeQuery(Value, string.Format("{0}[{1}]", Prefix, Key));
            else
                if (string.IsNullOrEmpty(Prefix))
                    return string.Format("{0}={1}&", Key, Value);
                else
                    return string.Format("{0}[{1}]={2}&", Prefix, Key, Value);
        }

        public static string DeserializeQuery(string Json, string Prefix = null)
        {
            string Result = string.Empty;
            if (Json.IndexOf('[') == 0)
            {
                List<object> Values = Newtonsoft.Json.JsonConvert.DeserializeObject<List<object>>(Json);
                foreach (object ValueObj in Values)
                    Result += JsonConvertQuery.ValueToQuery(Prefix, Values.IndexOf(ValueObj).ToString(), ValueObj.ToString());
            }
            else
            {
                Dictionary<string, object> Values = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, object>>(Json);
                foreach (KeyValuePair<string, object> Pair in Values)
                    Result += JsonConvertQuery.ValueToQuery(Prefix, Pair.Key, Pair.Value.ToString());
            }
            return Result;
        }

        public static string SerializeObject(object Value, JsonSerializerSettings Settings, string Prefix = null)
        {
            string Json = JsonConvert.SerializeObject(Value, Settings);
            return DeserializeQuery(Json, Prefix);
        }

    }
}
