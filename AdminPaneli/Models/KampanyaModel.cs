namespace AdminPaneli.Models
{
    public class KampanyaModel
    {
        public int _KampanyaId { get; set; }

        public string? _KampanyaBaslik { get; set; }

        public string? _KampanyaAciklama { get; set; }

        public int? _KategoriId { get; set; }
        public int? _UrunId { get; set; }
        public int? _FirmaId { get; set; }
        public DateTime? _BaslangicTarihi { get; set; }

        public DateTime? _BitisTarihi { get; set; }

        public bool? _Aktiflik { get; set; }

        public float? _IndirimMiktari { get; set; }
        public string? _KategoriAd { get; set; }
        public string? _UrunAd { get; set; }
        public string? _FirmaAd { get; set; }


    }
}
