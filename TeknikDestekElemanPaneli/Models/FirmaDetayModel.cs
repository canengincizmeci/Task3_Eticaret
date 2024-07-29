namespace TeknikDestekElemanPaneli.Models
{
    public class FirmaDetayModel
    {
        public int FirmaId { get; set; }

        public string? FirmaAd { get; set; }

        public string? FirmaAdres { get; set; }

        public int? SatisSayisi { get; set; }

        public int? CoinMiktari { get; set; }

        public string? Mail { get; set; }

        public string? MailSifre { get; set; }

        public int? Puan { get; set; }

        public int? SosyalSorumlulukKatılımSayisi { get; set; }

        public string? Sifre { get; set; }

        public string? TelefonNumarasi { get; set; }

        public bool? Aktiflik { get; set; }
        public float? ToplamCiro { get; set; }
        public int? SikayetEdilmeSayisi { get; set; }
        public int? SatisReddetmeSayisi { get; set; }
        public int? SikayetEtmeSayisi { get; set; }
        public int? UrunSayisi { get; set; }

    }
}
