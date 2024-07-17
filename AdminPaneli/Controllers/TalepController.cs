using AdminPaneli.Models;
using DB.Models;
using Microsoft.AspNetCore.Mvc;

namespace AdminPaneli.Controllers
{
    public class TalepController : Controller
    {
        private readonly ILogger<TalepController> _logger;
        private readonly Task3RealEcommerceContext _context;

        public TalepController(ILogger<TalepController> logger, Task3RealEcommerceContext context)
        {
            _logger = logger;
            _context = context;
        }
        public IActionResult Index()
        {
            int? id = HttpContext.Session.GetInt32("adminId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "Admin");

            }
            var veriler = _context.Taleplers.Where(p => p.Aktiflik == true).OrderByDescending(p => p.TalepId).Select(p => new Talep
            {
                TalepId = p.TalepId,
                Aktiflik = p.Aktiflik,
                KullaniciAd = p.Kullanici.KullaniciAd,
                KullaniciId = p.KullaniciId,
                TalepMetni = p.Talep,
                Tarih = p.Tarih,
                TalepBaslik = p.TalepBaslik
            }).ToList();

            return View(veriler);
        }
        public ActionResult KullaniciTalepDetay(int talepId)
        {
            int? id = HttpContext.Session.GetInt32("adminId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "Admin");

            }
            var veri = _context.Taleplers.Where(p => p.TalepId == talepId).OrderByDescending(p => p.TalepId).Select(p => new Talep
            {
                TalepId = p.TalepId,
                Aktiflik = p.Aktiflik,
                KullaniciAd = p.Kullanici.KullaniciAd,
                KullaniciId = p.KullaniciId,
                TalepMetni = p.Talep,
                Tarih = p.Tarih,
                TalepBaslik = p.TalepBaslik
            }).FirstOrDefault();
            return View(veri);
        }
        public ActionResult KullaniciTalepSil(int talepId)
        {
            int? id = HttpContext.Session.GetInt32("adminId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "Admin");

            }
            _context.Taleplers.Find(talepId).Aktiflik = false;
            _context.SaveChanges();
            return RedirectToAction("Index", "Talep");
        }
    }
}
