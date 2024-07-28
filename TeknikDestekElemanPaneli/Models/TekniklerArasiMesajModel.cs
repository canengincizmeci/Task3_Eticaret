namespace TeknikDestekElemanPaneli.Models
{
    public class TekniklerArasiMesajModel
    {
        public int MesajId { get; set; }

        public string? Mesaj { get; set; }

        public string? MesajBaslik { get; set; }

        public int? MesajlasmaId { get; set; }

        public int? GonderenEleman { get; set; }
        public string? GonderenElemanAd { get; set; }

        public int? AlıcıEleman { get; set; }

        public bool? Role { get; set; }

        public DateTime? Tarih { get; set; }

        public bool? Aktiflik { get; set; }

        public bool? OkunduBilgisi { get; set; }
    }
}
