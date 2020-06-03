using System.Collections.Generic;
using Newtonsoft.Json;

namespace ShopRenterAPI.Models
{
    public class Order : Base
    {
        [JsonProperty("innerId")]
        public long? InnerId { get; set; }

        [JsonProperty("invoiceId")]
        public string InvoiceId { get; set; }

        [JsonProperty("invoicePrefix")]
        public string InvoicePrefix { get; set; }

        [JsonProperty("firstname")]
        public string FirstName { get; set; }

        [JsonProperty("lastname")]
        public string LastName { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("fax")]
        public string? Fax { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("shippingFirstname")]
        public string ShippingFirstname { get; set; }

        [JsonProperty("shippingLastname")]
        public string ShippingLastname { get; set; }

        [JsonProperty("shippingCompany")]
        public string ShippingCompany { get; set; }

        [JsonProperty("shippingAddress1")]
        public string ShippingAddress1 { get; set; }

        [JsonProperty("shippingAddress2")]
        public string ShippingAddress2 { get; set; }

        [JsonProperty("shippingCity")]
        public string ShippingCity { get; set; }

        [JsonProperty("shippingPostcode")]
        public string ShippingPostcode { get; set; }

        [JsonProperty("shippingZoneName")]
        public string ShippingZoneName { get; set; }

        [JsonProperty("shippingCountryName")]
        public string ShippingCountryName { get; set; }

        [JsonProperty("shippingAddressFormat")]
        public string ShippingAddressFormat { get; set; }

        [JsonProperty("shippingMethodName")]
        public string ShippingMethodName { get; set; }

        [JsonProperty("shippingMethodTaxRate")]
        public string ShippingMethodTaxRate { get; set; }

        [JsonProperty("ShippingMethodTaxName")]
        public string ShippingMethodTaxName { get; set; }

        [JsonProperty("shippingMethodExtension")]
        public string ShippingMethodExtension { get; set; }

        [JsonProperty("shippingReceivingPointId")]
        public string ShippingReceivingPointId { get; set; }

        [JsonProperty("paymentFirstname")]
        public string PaymentFirstname { get; set; }

        [JsonProperty("paymentLastname")]
        public string PaymentLastname { get; set; }

        [JsonProperty("paymentCompany")]
        public string PaymentCompany { get; set; }

        [JsonProperty("paymentAddress1")]
        public string PaymentAddress1 { get; set; }

        [JsonProperty("paymentAddress2")]
        public string PaymentAddress2 { get; set; }

        [JsonProperty("paymentCity")]
        public string PaymentCity { get; set; }

        [JsonProperty("paymentPostcode")]
        public string PaymentPostcode { get; set; }

        [JsonProperty("paymentZoneName")]
        public string PaymentZoneName { get; set; }

        [JsonProperty("paymentCountryName")]
        public string PaymentCountryName { get; set; }

        [JsonProperty("paymentAddressFormat")]
        public string PaymentAddressFormat { get; set; }

        [JsonProperty("paymentMethodName")]
        public string PaymentMethodName { get; set; }

        [JsonProperty("paymentMethodCode")]
        public string PaymentMethodCode { get; set; }

        [JsonProperty("paymentMethodTaxRate")]
        public string PaymentMethodTaxRate { get; set; }

        [JsonProperty("paymentMethodTaxName")]
        public string PaymentMethodTaxName { get; set; }

        [JsonProperty("paymentMethodAfter")]
        public string PaymentMethodAfter { get; set; }

        [JsonProperty("comment")]
        public string Comment { get; set; }

        [JsonProperty("total")]
        public string Total { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("couponTaxRate")]
        public string CouponTaxRate { get; set; }

        [JsonProperty("dateCreated")]
        public string DateCreated { get; set; }

        [JsonProperty("dateUpdated")]
        public string DateUpdated { get; set; }

        [JsonProperty("ip")]
        public string Ip { get; set; }

        [JsonProperty("pickPackPontShopCode")]
        public string PickPackPontShopCode { get; set; }

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
