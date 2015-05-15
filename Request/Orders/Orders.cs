using System;
using System.Collections.Generic;
using System.Linq;
using ShopRenterAPI.Models;

namespace ShopRenterAPI.Requests
{
    public interface IOrders : IRequest<Order>
    {
        Order ByInnerId(long InnerId);
    }

    public class Orders : Request<Order>, IOrders
    {
        public Orders()
            : base("orders")
        {
        }

        public Order ByInnerId(long InnerId)
        {
            BaseList<Order> Orders = GenericGet<BaseList<Order>>(string.Format("{0}?innerId={1}", Resource, InnerId));
            return Orders.Items.First();
        }
    }
}
