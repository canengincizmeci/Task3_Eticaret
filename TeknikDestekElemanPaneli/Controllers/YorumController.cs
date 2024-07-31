using DB.Models;
using Microsoft.AspNetCore.Mvc;

namespace TeknikDestekElemanPaneli.Controllers
{
    public class YorumController : Controller
    {
        private readonly ILogger<YorumController> _logger;
        private readonly Task3RealEcommerceContext _context;
        public YorumController(ILogger<YorumController> logger, Task3RealEcommerceContext context)
        {
            _logger = logger;
            _context = context;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult KullaniciYorumlar(int kullaniciId)
        {
            int? id = HttpContext.Session.GetInt32("teknikElemanId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "TeknikEleman");
            }
            var yorumlar = _context.Yorumlars.Where(p => (p.KullaniciId == kullaniciId && p.Aktiflik == true)).OrderByDescending(p => p.YorumId).Select(p => new Yorumlar
            {
                UrunId = p.UrunId,
                YorumId = p.YorumId,
                Aktiflik = p.Aktiflik,
                KullaniciId = p.KullaniciId,
                Tarih = p.Tarih,
                Yorum = p.Yorum
            }).ToList();

            return View(yorumlar);
        }
        public ActionResult KullaniciYorumSil(int yorumId)
        {
            int? id = HttpContext.Session.GetInt32("teknikElemanId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "TeknikEleman");
            }
            _context.Yorumlars.Find(yorumId).Aktiflik = false;
            _context.SaveChanges();
            return RedirectToAction("KullaniciYorumlar", "Yorum");
        }
        public ActionResult KullaniciYorumCevaplar(int kullaniciId)
        {
            int? id = HttpContext.Session.GetInt32("teknikElemanId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "TeknikEleman");
            }
            var model = _context.KullaniciYorumCevaps.Where(p => (p.Aktiflik == true && p.KullaniciId == kullaniciId)).OrderByDescending(p => p.CevapId).Select(p => new KullaniciYorumCevap
            {
                Aktiflik = p.Aktiflik,
                CevapId = p.CevapId,
                KullaniciId = p.KullaniciId,
                Cevap = p.Cevap,
                Tarih = p.Tarih,
                YorumId = p.YorumId
            }).ToList();


            return View(model);
        }
     
    }
}
