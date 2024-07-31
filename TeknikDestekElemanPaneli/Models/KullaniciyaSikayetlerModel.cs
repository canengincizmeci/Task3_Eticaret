namespace TeknikDestekElemanPaneli.Models
{
    public class KullaniciyaSikayetlerModel
    {
        public List<FirmadanKullaniciyaSikayetModel> firmadanKullaniciyaSikayetler { get; set; }
        public List<FirmadanKullaniciyaYorumCevapSikayetModel> firmadanYorumCevapSikayetler { get; set; }
        public List<FirmadanYorumSikayetModel> firmadanYorumSikayetler { get; set; }
    }
}
