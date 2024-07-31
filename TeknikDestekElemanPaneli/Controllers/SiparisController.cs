using DB.Models;
using Microsoft.AspNetCore.Mvc;

namespace TeknikDestekElemanPaneli.Controllers
{
    public class SiparisController : Controller
    {
        private readonly ILogger<SiparisController> _logger;
        private readonly Task3RealEcommerceContext _context;
        public SiparisController(ILogger<SiparisController> logger, Task3RealEcommerceContext context)
        {
            _logger = logger;
            _context = context;
        }
        public ActionResult KullaniciGecmisSiparisler(int kullaniciId)
        {
            int? id = HttpContext.Session.GetInt32("teknikElemanId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "TeknikEleman");
            }
            var siparisler = _context.Siparislers.Where(p => p.KullaniciId == kullaniciId).OrderByDescending(p => p.SiparisId).Select(p => new Siparisler
            {
                FaturaAdresi = p.FaturaAdresi,
                SiparisId = p.SiparisId,
                Onay = p.Onay,
                Toplamfiyat = p.Toplamfiyat,
                KullaniciId = p.KullaniciId,
                GonderiAdresi = p.GonderiAdresi,
                KargoDurumu = p.KargoDurumu,
                KuponKod = p.KuponKod,
                SepetId = p.SepetId
            }).ToList();

            return View(siparisler);
        }
    }
}
