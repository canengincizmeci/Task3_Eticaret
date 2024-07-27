using Microsoft.EntityFrameworkCore;

namespace TeknikDestekElemanPaneli.Models
{
    public class KullaniciGelenMesajModel
    {
        public int _kullanicidanGelenMesajSayisi { get; set; }
        public int _admindenGelenMesajSayisi { get; set; }

        public int _firmadanGelenMesajSayisi { get; set; }
        public int _kargodanGelenMesajSayisi { get; set; }
        public int _teknikElemandanGelenMesajSayisi { get; set; }
    }
}
