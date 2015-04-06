using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ShopRenterAPI.Models
{
    public class Base
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("href")]
        public string HRef { get; set; }
    }

    public class BaseObject<T> : Core, ICore
        where T : class
    {
        [JsonProperty("href")]
        public string HRef { get; set; }

        public T Data
        {
            get
            {
                if (HRef == null)
                    return null;
                return GenericGet<T>(HRef);
            }
        }
    }

    public class BaseList<T>
        where T : class
    {
        [JsonProperty("href")]
        public string HRef { get; set; }

        [JsonProperty("page")]
        public long? Page { get; set; }

        [JsonProperty("limit")]
        public long? Limit { get; set; }

        [JsonProperty("first")]
        public BaseList<T> First { get; set; }

        [JsonProperty("previous")]
        public BaseList<T> Previous { get; set; }

        [JsonProperty("next")]
        public BaseList<T> Next { get; set; }

        [JsonProperty("last")]
        public BaseList<T> Last { get; set; }

        [JsonProperty("items")]
        public BaseObject<T>[] _Items { get; set; }

        [JsonIgnore]
        public List<T> Items
        {
            get
            {
                return _Items.Select(x => x.Data).ToList();
            }                 
        }
    }
}
