namespace TeknikDestekElemanPaneli.Models
{
    public class KargoFirmasinaSikayetlerModel
    {
        public List<KullanicidanKargoFirmasiSikayetlerModel> kullanicidanKargoyaSikayetler { get; set; }
        public List<TeknikElemandanKargoFirmasinaSikayetlerModel> teknikElemandanKargoyaSikayetler { get; set; }
    }
}
