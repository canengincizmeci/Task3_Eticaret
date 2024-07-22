namespace AdminPaneli.Models
{
    public class CekilisKatilimModel
    {
        public int _KatilimId { get; set; }

        public int? _CekilisId { get; set; }

        public int? _KullaniciId { get; set; }

        public DateTime? _KatilimTarihi { get; set; }
        public string? _CekilisAd { get; set; }
        public string? _KullaniciAd { get; set; }
    }
}
