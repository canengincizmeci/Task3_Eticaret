namespace SaticiFirmaPaneli.Models
{
    public class NewOrdersModel
    {
        public int OrderId { get; set; }
        public int? UserId { get; set; }
        public int? ShoppingCartId { get; set; }
        public string? CouponCode { get; set; }
        public float? TotalPrice { get; set; }
        public bool? Confirmation { get; set; }
        public List<string>? ProductNames { get; set; }
        public bool? ShippingStatus { get; set; }
        public string? ShippingAddress { get; set; }
        public string? BillingAddress { get; set; }
        public string UserName { get; set; }

    }
}
