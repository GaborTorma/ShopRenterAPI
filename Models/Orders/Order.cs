using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ShopRenterAPI.Models
{
	public class Order : Base
	{
        [JsonProperty("innerId")]
        public long? InnerId { get; set; }

        [JsonProperty("orderTotals")]
        public BaseList<OrderTotal> _OrderTotals { get; set; }

        [JsonIgnore]
        public List<OrderTotal> OrderTotals
        {
            get
            {
                return _OrderTotals.Items;
            }
        }
    }
}