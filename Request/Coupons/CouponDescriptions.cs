using System;
using System.Collections.Generic;
using System.Linq;
using ShopRenterAPI.Models;

namespace ShopRenterAPI.Requests
{
    public interface ICouponDescriptions : IRequest<CouponDescription>
    {
        CouponDescription ByCouponId(string CouponId);
        BaseList<CouponDescription> ByLanguageId(string LanguageId, long Page = 0, long Limit = 25);
    }

    public class CouponDescriptions : Request<CouponDescription>, ICouponDescriptions
    {
        public CouponDescriptions()
            : base("couponDescriptions")
        {
        }

        public CouponDescription ByCouponId(string CouponId)
        {
            BaseList<CouponDescription> CouponDescriptions = GenericGet<BaseList<CouponDescription>>(string.Format("{0}?couponId={1}", Resource, CouponId));
            return CouponDescriptions.Items.First();
        }

        public BaseList<CouponDescription> ByLanguageId(string LanguageId, long Page = 0, long Limit = 25)
        {
            return GenericGet<BaseList<CouponDescription>>(string.Format("{0}?languageId={1}&page={2}&limit={3}", Resource, LanguageId, Page, Limit));
        }
    }
}
