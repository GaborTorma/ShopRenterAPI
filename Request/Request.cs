using System;
using System.Collections.Generic;
using System.Linq;
using ShopRenterAPI.Models;

namespace ShopRenterAPI.Requests
{
    public interface IRequest<T> : IReadRequest<T>
        where T : Base
    {
        T Add(T Data);
        T Modify(string Id, T Data);
        bool Delete(string Id);
    }

    public class Request<T> : ReadRequest<T>, IRequest<T>
        where T : Base
    {
        public Request(string Resource)
            : base(Resource)
        {
        }

        public T Add(T Data)
        {
            return GenericPost<T>(Resource, Data);
        }

        public T Modify(string Id, T Data)
        {
            return GenericPost<T>(string.Format("{0}/{1}", Resource, Id), Data);
        }

        public bool Delete(string Id)
        {
            return GenericDelete(string.Format("{0}/{1}", Resource, Id));
        }
    }
}
