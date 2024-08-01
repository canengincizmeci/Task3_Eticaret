namespace TeknikDestekElemanPaneli.Models
{
    public class TeknikElemandanKargoFirmasinaSikayetlerModel
    {
        public int SikayetId { get; set; }

        public string? SikayetBaslik { get; set; }

        public string? SikayetMetni { get; set; }

        public int? KargoFirmaId { get; set; }
        public string? KargoFirmasiAd { get; set; }

        public int? TeknikElemanId { get; set; }

        public string? TeknikElemanAd { get; set; }

        public DateTime? Tarih { get; set; }

        public bool? Aktiflik { get; set; }
    }
}
