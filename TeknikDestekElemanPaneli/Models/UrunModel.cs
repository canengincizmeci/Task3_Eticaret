namespace TeknikDestekElemanPaneli.Models
{
    public class UrunModel
    {
        public int UrunId { get; set; }

        public string? UrunAd { get; set; }

        public string? Aciklama { get; set; }

        public string? UrunResim { get; set; }

        public DateTime? EklenmeTarihi { get; set; }

        public int? FirmaId { get; set; }
        public string? FirmaAd { get; set; }

        public int? SatisSayisi { get; set; }

        public int? Fiyat { get; set; }

        public int? SepeteEklemeSayisi { get; set; }

        public int? Stok { get; set; }

        public int? KategoriId { get; set; }
        public string? KategoriAd { get; set; }
        public bool? Aktiflik { get; set; }
    }
}
