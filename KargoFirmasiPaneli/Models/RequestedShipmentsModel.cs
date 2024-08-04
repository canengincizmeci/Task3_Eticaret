namespace KargoFirmasiPaneli.Models
{
    public class RequestedShipmentsModel
    {
        public int RequestedShipmentId { get; set; }

        public int? SalesId { get; set; }

        public int? ShippingCompanyId { get; set; }
        public string? ShippingCompanyName { get; set; }
        public int? SellerCompanyId { get; set; }
        public string? SellerCompanyName { get; set; }

        public DateTime? Date { get; set; }

        public bool? ActivityStatus { get; set; }
        public List<int>? ProductsId { get; set; }
        public List<string>? ProductsName { get; set; }


    }
}
