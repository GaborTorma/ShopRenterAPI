using System;
using System.Collections.Generic;
using System.Linq;
using ShopRenterAPI.Models;

namespace ShopRenterAPI.Requests
{
    public interface IOrders : ICore
    {
        Order ById(string Id);
        Order ByInnerId(long InnerId);
        BaseList<Order> All(long Page = 0, long Limit = 25);
    }
    
    public class Orders : Core, IOrders
    {
        public BaseList<Order> All(long Page = 0, long Limit = 25)
        {
            return GenericGet<BaseList<Order>>(string.Format("orders?page={0}&limit={1}", Page, Limit));
        }

        public Order ById(string Id)
        {
            return GenericGet<Order>(string.Format("orders/{0}", Id));
        }

        public Order ByInnerId(long InnerId)
        {
            BaseList<Order> Orders = GenericGet<BaseList<Order>>(string.Format("orders?innerId={0}", InnerId));
            return Orders.Items.Count > 0 ? Orders.Items[0] : null;
        }
    }
}
