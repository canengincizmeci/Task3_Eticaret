namespace AdminPaneli.Models
{
    public class SikayetModel
    {
        public int SikayetId { get; set; }

        public int? FirmaId { get; set; }

        public int? TeknikElemanId { get; set; }

        public string? SikayetBaslik { get; set; }

        public string? SikayetMetni { get; set; }

        public DateTime? Tarih { get; set; }

        public bool? Aktiflik { get; set; }
        public string? firmaAd { get; set; }
        public string? elemanAd { get; set; }
        public string? kullaniciAd { get; set; }
    }
}
