namespace AdminPaneli.Models
{
    public class Talep
    {
        public int TalepId { get; set; }

        public string? TalepBaslik { get; set; }

        public string? TalepMetni { get; set; }

        public int? KullaniciId { get; set; }
        public string? KullaniciAd { get; set; }
        public DateTime? Tarih { get; set; }

        public bool? Aktiflik { get; set; }
    }
}
