namespace KargoFirmasiPaneli.Models
{
    public class DispatchedShipmentsModel
    {
        public int DispatchedShipmentId { get; set; }

        public int? RequestedShipmentId { get; set; }

        public int? ShipmentCompanyId { get; set; }

        public int? SalerCompanyId { get; set; }
        public string? SalerCompanyName { get; set; }

        public int? ShipmentCompanyBrachId { get; set; }

        public int? RecipientId { get; set; }
        public string? RecipientName { get; set; }

        public DateTime? ShipmentDate { get; set; }

        public DateTime? DeliveryDate { get; set; }

        public int? DestinationAdressId { get; set; }
        public string? DestinationAdressName { get; set; }

        public DateTime? Date { get; set; }

        public bool? ReturnRequest { get; set; }

    }
}
