namespace TeknikDestekElemanPaneli.Models
{
    public class IadeTalepModel
    {
        public int TalepId { get; set; }

        public int? OdemeId { get; set; }
        public List<string>? FirmaAd { get; set; }
        public List<int>? FirmaId { get; set; }
        public int? KullaniciId { get; set; }
        public string? KullaniciAd { get; set; }

        public string? Sebep { get; set; }

        public DateTime? Tarih { get; set; }

        public bool? Onay { get; set; }

        public bool? Aktiflik { get; set; }
    }
}
