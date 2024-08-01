namespace TeknikDestekElemanPaneli.Models
{
    public class YoldaIadeTalebiModel
    {
        public int YoldaIadeTalebiId { get; set; }

        public int? GonderilenKargoId { get; set; }

        public string? IadeAciklama { get; set; }
        public int? KargoFirmaId { get; set; }

        public int? KullaniciId { get; set; }
        public string? KullaniciAd { get; set; }
        public int? FirmaId { get; set; }
        public string? FirmaAd { get; set; }
        public DateTime? Tarih { get; set; }
        public string? KargoFirmaAd { get; set; }
        public bool? Onay { get; set; }
    }
}
