namespace SatisPaneli.Models
{
    public class CargoViewModel
    {
        public int CargoID { get; set; }
        public int? SellingId { get; set; }

        public int? OrderId { get; set; }

        public int? CompanyId { get; set; }

        public bool? CargoStatus { get; set; }
        public string? DeliveryAddress { get; set; }

        public string? BillingAddress { get; set; }
    }
}
