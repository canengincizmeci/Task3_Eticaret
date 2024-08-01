namespace TeknikDestekElemanPaneli.Models
{
    public class KullanicidanKargoFirmasiSikayetlerModel
    {
        public int SikayetId { get; set; }

        public int? KargoFirmaId { get; set; }
        public string? KargoFirmaAd { get; set; }

        public int? KullaniciId { get; set; }
        public string? KullaniciAd { get; set; }

        public string? SikayetBaslik { get; set; }

        public string? SikayetMetni { get; set; }

        public DateTime? Tarih { get; set; }

        public bool? Aktiflik { get; set; }
    }
}
