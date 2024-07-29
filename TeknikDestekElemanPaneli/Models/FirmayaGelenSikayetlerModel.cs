using DB.Models;

namespace TeknikDestekElemanPaneli.Models
{
    public class FirmayaGelenSikayetlerModel
    {
        public List<KullanicidanFirmayaSikayetModel> kullanicidanFirmayaSikayetler { get; set; }
        public List<KullanicidanFirmayaYorumCevapSikayetModel> kullanicidanFirmayaYorumSikayetler { get; set; }
    }
}
