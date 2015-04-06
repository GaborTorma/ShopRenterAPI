using System;
using System.Collections.Generic;
using System.ComponentModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ShopRenterAPI.Models
{
    public class OrderTotal : Base
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("valueText")]
        public string Text { get; set; }
        
        [JsonProperty("value")]
        public double? Value { get; set; }

        [JsonProperty("sortOrder")]
        public long? SortOrder { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("order")]
        public BaseList<Order> _Order { get; set; }

/*        [JsonIgnore]
        public Order Order
        {
            get
            {
                return _Order.Select(x => x.Data);
            }
        }*/
    }
}