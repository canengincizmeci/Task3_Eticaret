namespace TeknikDestekElemanPaneli.Models
{
    public class AdminTeknikMesajModel
    {
        public int _MesajId { get; set; }

        public string? _MesajBaslik { get; set; }

        public string? _Mesaj { get; set; }

        public int? _GondericiId { get; set; }
        public string? _GondericiAd { get; set; }

        public int? _AliciId { get; set; }
        public string? _AliciAd { get; set; }
        public int? _MesajlasmaId { get; set; }

        public DateTime? _Tarih { get; set; }

        public bool? _OkunduBilgisi { get; set; }
        public bool? _Rol { get; set; }

    }
}
