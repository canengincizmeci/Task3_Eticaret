namespace AdminPaneli.Models
{
    public class UrunModel
    {
        public int _UrunId { get; set; }
        public string? _UrunAd { get; set; }
        public string? _Aciklama { get; set; }
        public string? _UrunResim { get; set; }
        public string? _FirmaAd { get; set; }
        public int? _Fiyat { get; set; }
        public string? _KategoriAd { get; set; }




        public DateTime? _EklenmeTarihi { get; set; }
        public int? _FirmaId { get; set; }
        public int? _SatisSayisi { get; set; }
        public int? _SepeteEklemeSayisi { get; set; }
        public int? _Stok { get; set; }
        public int? _KategoriId { get; set; }
        public bool? _Aktiflik { get; set; }
    }
}
