using ShopRenterAPI.Requests;
using ShopRenterAPI.Models;

namespace ShopRenterAPI
{
    public interface IShopRenter
    {
        IOrders Orders { get; }
        ICoupons Coupons { get; }
    }

    public class ShopRenter : IShopRenter
    {
        public IOrders Orders { get; set; }
        public ICoupons Coupons { get; set; }

        public ShopRenter(string BaseAPIURL, string UserName, string Password, string LogFile = null)
        {
            ShopRenterAPISettings.APIURL = BaseAPIURL;
            ShopRenterAPISettings.UserName = UserName;
            ShopRenterAPISettings.Password = Password;
            ShopRenterAPISettings.LogFile = LogFile;

            Orders = new Orders();
            Coupons = new Coupons();
        }
    }

}
