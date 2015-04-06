using System;
using System.Collections.Generic;
using System.Linq;
using ShopRenterAPI.Models;

namespace ShopRenterAPI.Requests
{
    public interface ICoupons : ICore
    {
        Coupon ById(string Id);
        Coupon Modify(string Id, Coupon Coupon);
    }

    public class Coupons : Core, ICoupons
    {
        public Coupon ById(string Id)
        {
            return GenericGet<Coupon>(string.Format("coupons/{0}", Id));
        }

        public Coupon Modify(string Id, Coupon Coupon)
        {
            return GenericPost<Coupon>(string.Format("coupons/{0}", Id), Coupon);
        }
    }
}
