using DB.Models;

namespace AdminPaneli.Models
{
    public class AdminMesajModel
    {
        public int? _mesajId { get; set; }
        public string _mesaj { get; set; }
        public DateTime? _tarih { get; set; }
        public string _elemanAd { get; set; }
        public bool? _okunduBilgisi { get; set; }
        public int? _mesajlasmaId { get; set; }
        public int? _elemanId { get; set; }
        public int? _adminId { get; set; }
    }
}
