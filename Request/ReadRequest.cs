using System;
using System.Collections.Generic;
using System.Linq;
using ShopRenterAPI.Models;

namespace ShopRenterAPI.Requests
{
    public interface IReadRequest<T> : ICore
        where T : Base
    {
        BaseList<T> All(long Page = 0, long Limit = 25);
        T ById(string Id);
    }

    public class ReadRequest<T> : Core, IReadRequest<T>
        where T : Base
    {
        protected string _Resource;
        public string Resource
        {
            get
            {
                return _Resource;
            }
        }
        public ReadRequest(string Resource)
        {
            _Resource = Resource;
        }

        public BaseList<T> All(long Page = 0, long Limit = 25)
        {
            return GenericGet<BaseList<T>>(string.Format("{0}?page={1}&limit={2}", Resource, Page, Limit));
        }

        public T ById(string Id)
        {
            return GenericGet<T>(string.Format("{0}/{1}", Resource, Id));
        }
    }
}
