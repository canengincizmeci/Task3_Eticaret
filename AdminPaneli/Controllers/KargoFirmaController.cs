using DB.Models;
using Microsoft.AspNetCore.Mvc;

namespace AdminPaneli.Controllers
{
    public class KargoFirmaController : Controller
    {
        private readonly ILogger<KargoFirmaController> _logger;
        private readonly Task3RealEcommerceContext _context;

        public KargoFirmaController(ILogger<KargoFirmaController> logger, Task3RealEcommerceContext context)
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
            var liste = _context.KargoFirmas.Where(p => p.Aktiflik == true).OrderByDescending(p => p.KargoFirmaId).Select(p => new KargoFirma
            {
                FirmaMerkezAdres = p.FirmaMerkezAdres,
                KargoFirmaId = p.KargoFirmaId,
                KargoFirmaAd = p.KargoFirmaAd,
                KargoFirmaEmail = p.KargoFirmaEmail,
                KargoFirmaTel = p.KargoFirmaTel,
                Ulke = p.Ulke
            }).ToList();
            return View(liste);
        }
        [HttpGet]
        public ActionResult KargoFirmaEkle()
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
        public ActionResult KargoFirmaEkle(KargoFirma kargoFirma)
        {
            int? id = HttpContext.Session.GetInt32("adminId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "Admin");
            }
            _context.KargoFirmas.Add(new KargoFirma
            {
                Aktiflik = true,
                FirmaMerkezAdres = kargoFirma.FirmaMerkezAdres,
                KargoFirmaAd = kargoFirma.KargoFirmaAd,
                KargoFirmaEmail = kargoFirma.KargoFirmaEmail,
                KargoFirmaTel = kargoFirma.KargoFirmaTel,
                Ulke = kargoFirma.Ulke
            });
            _context.SaveChanges();
            return RedirectToAction("Index", "KargoFirma");
        }
        public ActionResult KargoFirmaDetay(int kargoFirmaId)
        {
            int? id = HttpContext.Session.GetInt32("adminId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "Admin");
            }
            var kargoFirma = _context.KargoFirmas.Find(kargoFirmaId);
            return View(kargoFirma);
        }
        public ActionResult KargoFirmaSil(int kargoFirmaId)
        {
            int? id = HttpContext.Session.GetInt32("adminId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "Admin");
            }
            _context.KargoFirmas.Find(kargoFirmaId).Aktiflik = false;
            _context.SaveChanges();
            return RedirectToAction("Index", "KargoFirma");
        }
        [HttpGet]
        public ActionResult IletisimeGec(int kargoFirmaId)
        {
            int? id = HttpContext.Session.GetInt32("adminId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "Admin");
            }
            ViewBag.KargoFirmaId = kargoFirmaId;


            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult IletisimeGec(int kargoFirmaId, string bilgilendirmeBaslik, string bilgilendirmeMetin)
        {
            int? id = HttpContext.Session.GetInt32("adminId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "Admin");
            }
            _context.AdmindenKargoFirmasinaBilgilendirmes.Add(new AdmindenKargoFirmasinaBilgilendirme
            {
                AdminId = id,
                Aktiflik = true,
                BilgilendirmeBaslik = bilgilendirmeBaslik,
                BilgilendirmeMetin = bilgilendirmeMetin,
                KargoFirmaId = kargoFirmaId,
                OkunduBilgisi = false,
                Tarih = DateTime.Now
            });
            _context.SaveChanges();
            return RedirectToAction("Index", "KargoFirma");
        }
    }
}
