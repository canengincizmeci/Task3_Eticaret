using DB.Models;
using Microsoft.AspNetCore.Mvc;

namespace AdminPaneli.Controllers
{
    public class KategoriController : Controller
    {
        private readonly ILogger<KategoriController> _logger;
        private readonly Task3RealEcommerceContext _context;

        public KategoriController(ILogger<KategoriController> logger, Task3RealEcommerceContext context)
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
            var veriler = _context.Kategoris.Where(p => p.Aktiflik == true).OrderByDescending(p => p.KategoriId).Select(p => new Kategori
            {
                KategoriId = p.KategoriId,
                KategoriAd = p.KategoriAd,
                Aktiflik = p.Aktiflik,
                KategoriAciklama = p.KategoriAciklama
            }).ToList();

            return View(veriler);
        }
        public ActionResult KategoriSil(int kategoriId)
        {
            int? id = HttpContext.Session.GetInt32("adminId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "Admin");

            }
            _context.Kategoris.Find(kategoriId).Aktiflik = false;
            _context.SaveChanges();
            return RedirectToAction("Index", "Kategori");
        }
        [HttpGet]
        public ActionResult KategoriEkle()
        {
            int? id = HttpContext.Session.GetInt32("adminId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "Admin");

            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult KategoriEkle(string kategoriAd, string kategoriAciklama)
        {
            int? id = HttpContext.Session.GetInt32("adminId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "Admin");

            }
            _context.Add(new Kategori
            {
                Aktiflik = true,
                KategoriAciklama = kategoriAciklama,
                KategoriAd = kategoriAd,
            });
            _context.SaveChanges();
            return RedirectToAction("Index", "Kategori");
        }
    }
}
