using System;
using System.Collections.Generic;
using System.Linq;
using ShopRenterAPI.Models;

namespace ShopRenterAPI.Requests
{
    public interface ICoupons : IRequest<Coupon>
    {
        Coupon ByCode(string Code);
    }

    public class Coupons : Request<Coupon>, ICoupons
    {
        public Coupons()
            : base("coupons")
        {
        }

        public Coupon ByCode(string Code)
        {
            BaseList<Coupon> Coupons = GenericGet<BaseList<Coupon>>(string.Format("{0}?code={1}", Resource, Code));
            return Coupons.Items.First();
        }
    }
}
