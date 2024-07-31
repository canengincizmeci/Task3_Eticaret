namespace TeknikDestekElemanPaneli.Models
{
    public class UrunSikayetModel

    {
        public int UrunsikayetId { get; set; }

        public int? UrunId { get; set; }
        public string? UrunAd { get; set; }
        public string? FirmaAd { get; set; }
        public int? FirmaId { get; set; }
        public string? SikayetBaslik { get; set; }

        public string? SikayetMetni { get; set; }

        public int? KullaniciId { get; set; }
        public string? KullaniciAd { get; set; }


        public DateTime? Tarih { get; set; }

        public bool? Aktiflik { get; set; }



    }
}
