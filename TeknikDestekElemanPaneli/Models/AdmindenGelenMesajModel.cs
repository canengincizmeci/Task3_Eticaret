namespace TeknikDestekElemanPaneli.Models
{
    public class AdmindenGelenMesajModel
    {
        public int _MesajId { get; set; }

        public string? _MesajBaslik { get; set; }

        public string? _Mesaj { get; set; }

        public int? _AdminId { get; set; }
        public string? _AdminAd { get; set; }

        public int? _ElemanId { get; set; }
        public string? _ElemanAd { get; set; }

        public int? _MesajlasmaId { get; set; }

        public DateTime? _Tarih { get; set; }

        public bool? _OkunduBilgisi { get; set; }
        public bool? _Role { get; set; }

    }
}
