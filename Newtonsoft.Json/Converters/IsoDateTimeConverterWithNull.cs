using System;
using System.Globalization;
using Newtonsoft.Json.Utilities;

namespace Newtonsoft.Json.Converters
{
    public class IsoDateTimeConverterWithNull : IsoDateTimeConverter
    {
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.Value.ToString() == "0000-00-00 00:00:00" || reader.Value.ToString() == "0000-00-00")
                return null;
            else
                return base.ReadJson(reader, objectType, existingValue, serializer);
        }
    }
}