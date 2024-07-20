using DB.Models;
using Microsoft.AspNetCore.Mvc;

namespace AdminPaneli.Controllers
{
    public class CekilisController : Controller
    {
        private readonly ILogger<CekilisController> _logger;
        private readonly Task3RealEcommerceContext _context;

        public CekilisController(ILogger<CekilisController> logger, Task3RealEcommerceContext context)
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
            var cekilisListe = _context.Cekilis.Where(p => p.Aktiflik == true).OrderByDescending(p => p.CekilisId).Select(p => new Cekili
            {
                Aktiflik = p.Aktiflik,
                CekilisId = p.CekilisId,
                BaslangicTarih = p.BaslangicTarih,
                BitisTarih = p.BitisTarih,
                CekilisAciklama = p.CekilisAciklama,
                CekilisAd = p.CekilisAd
            }).ToList();
            return View(cekilisListe);
        }
        public ActionResult CekilisDetay(int cekilisId)
        {
            int? id = HttpContext.Session.GetInt32("adminId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "Admin");

            }
            var detay = _context.Cekilis.Where(p => p.CekilisId == cekilisId).OrderByDescending(p => p.CekilisId).Select(p => new Cekili
            {
                Aktiflik = p.Aktiflik,
                CekilisId = p.CekilisId,
                BaslangicTarih = p.BaslangicTarih,
                BitisTarih = p.BitisTarih,
                CekilisAciklama = p.CekilisAciklama,
                CekilisAd = p.CekilisAd
            }).FirstOrDefault();


            return View(detay);
        }
        public ActionResult CekilisBitir(int cekilisId)
        {
            int? id = HttpContext.Session.GetInt32("adminId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "Admin");

            }
            _context.Cekilis.Find(cekilisId).Aktiflik = false;
            _context.SaveChanges();

            return RedirectToAction("Index", "Cekilis");
        }
        [HttpGet]
        public ActionResult CekilisEkle()
        {


            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CekilisEkle(Cekili cekilis)
        {
            int? id = HttpContext.Session.GetInt32("adminId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "Admin");

            }
            _context.Cekilis.Add(new Cekili
            {
                Aktiflik = true,
                BaslangicTarih = cekilis.BaslangicTarih,
                BitisTarih = cekilis.BitisTarih,
                CekilisAciklama = cekilis.CekilisAciklama,
                CekilisAd = cekilis.CekilisAd
            });
            _context.SaveChanges();

            return RedirectToAction("Index", "Cekilis");
        }
        [HttpGet]
        public ActionResult CekilisUzat(int cekilisId)
        {
            int? id = HttpContext.Session.GetInt32("adminId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "Admin");

            }
            var cekilis = _context.Cekilis.Find(cekilisId);
            ViewBag.Ad = cekilis.CekilisAd;
            ViewBag.Baslangic = cekilis.BaslangicTarih;
            ViewBag.EskiBitis = cekilis.BitisTarih;
            ViewBag.Id = cekilisId;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CekilisUzat(int cekilisId, DateTime tarih)
        {
            int? id = HttpContext.Session.GetInt32("adminId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "Admin");
            }
            var cekilis = _context.Cekilis.Find(cekilisId);
            cekilis.BitisTarih = tarih;
            _context.SaveChanges();
            return RedirectToAction("Index", "Cekilis");
        }
    }
}
