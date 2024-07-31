namespace TeknikDestekElemanPaneli.Models
{
    public class FirmadanKullaniciyaYorumCevapSikayetModel
    {

        public int? YorumCevapId { get; set; }
        public string? YorumCevap { get; set; }
        public string? Yorum { get; set; }

        public int? KullaniciId { get; set; }

        public string? KullaniciAd { get; set; }


        public int? FirmaId { get; set; }
        public string? FirmaAd { get; set; }

        public string? SikayetBaslik { get; set; }

        public string? SikayetMetni { get; set; }

        public DateTime? Tarih { get; set; }

        public bool? Aktiflik { get; set; }
    }
}
