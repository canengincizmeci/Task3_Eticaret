namespace AdminPaneli.Models
{
    public class FirmaOneriModel
    {
        public int _OneriId { get; set; }

        public string? _OneriBaslik { get; set; }

        public string? _OneriMetin { get; set; }

        public int? _FirmaId { get; set; }
        public string? _FirmaAd { get; set; }
        public DateTime? _Tarih { get; set; }

        public bool? _Aktiflik { get; set; }
    }
}
