namespace KargoFirmasiPaneli.Models
{
    public class ShippingNotificationsModel
    {
        public int KargoBildirimId { get; set; }

        public int? KargoFirmaId { get; set; }

        public int? KullaniciId { get; set; }
        public string? KullaniciAd { get; set; }
        public string? KargoBildirimBaslik { get; set; }


        public string? KargoBildirim { get; set; }

        public DateTime? Tarih { get; set; }

        public bool? OkunduBilgisi { get; set; }

        public bool? Aktiflik { get; set; }
    }
}
