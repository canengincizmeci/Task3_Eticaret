namespace TeknikDestekElemanPaneli.Models
{
    public class SaticidanTeknikeMesajModel
    {
        public int MesajId { get; set; }

        public string? MesajBaslik { get; set; }

        public string? Mesaj { get; set; }

        public int? MesajlasmaId { get; set; }

        public int? FirmaId { get; set; }
        public string? FirmaAd { get; set; }


        public int? TeknikElemanId { get; set; }

        public DateTime? Tarih { get; set; }

        public bool? Aktiflik { get; set; }

        public bool? OkunduBilgisi { get; set; }
        public bool? Role { get; set; }
    }
}
