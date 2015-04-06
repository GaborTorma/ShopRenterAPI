using System;
using System.Collections.Generic;
using System.ComponentModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ShopRenterAPI.Models
{
    public class CouponDescription
    {
        [JsonProperty("id"  )]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("coupon")]
        public string CouponURL { get; set; }

        [JsonProperty("language")]
        public string LanguageURL { get; set; }
    }
}