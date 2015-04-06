using ShopRenterAPI.Requests;

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
            Settings.APIURL = BaseAPIURL;
            Settings.UserName = UserName;
            Settings.Password = Password;
            Settings.LogFile = LogFile;

            Orders = new Orders();
            Coupons = new Coupons();
        }
    }

}
