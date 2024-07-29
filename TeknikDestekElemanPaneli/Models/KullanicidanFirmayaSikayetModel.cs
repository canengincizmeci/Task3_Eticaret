namespace TeknikDestekElemanPaneli.Models
{
    public class KullanicidanFirmayaSikayetModel
    {
        public int SikayetId { get; set; }

        public int? SikayetciId { get; set; }
        public string? KullaniciAd { get; set; }

        public string? SikayetBaslik { get; set; }

        public string? SikayetMetni { get; set; }

        public int? FirmaId { get; set; }
        public string? FirmaAd { get; set; }

        public DateTime? Tarih { get; set; }

        public bool? Aktiflik { get; set; }
    }
}
