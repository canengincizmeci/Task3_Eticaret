namespace KargoFirmasiPaneli.Models
{
    public class MessagingBetweenCompanyAndSupportListModel
    {
        public int MesajId { get; set; }

        public string? MesajBaslik { get; set; }

        public string? Mesaj { get; set; }

        public int? TeknikElemanId { get; set; }
        public string? TeknikElemanAd { get; set; }

        public int? KargoFirmaId { get; set; }

        public DateTime? Tarih { get; set; }

        public bool? Aktiflik { get; set; }

        public bool? OkunduBilgisi { get; set; }

        public int? MesajlasmaId { get; set; }
        public bool Role { get; set; }
    }
}
