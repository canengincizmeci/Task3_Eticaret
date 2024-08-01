using DB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace TeknikDestekElemanPaneli.Controllers
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
        public ActionResult Index()
        {
            int? id = HttpContext.Session.GetInt32("teknikElemanId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "TeknikEleman");
            }

            var liste = _context.KargoFirmas.Where(p => p.Aktiflik == true).OrderByDescending(p => p.KargoFirmaId).Select(p => new KargoFirma
            {
                Aktiflik = p.Aktiflik,
                KargoFirmaAd = p.KargoFirmaAd,
                Ulke = p.Ulke,
                KargoFirmaTel = p.KargoFirmaTel,
                KargoFirmaId = p.KargoFirmaId,
                KargoFirmaEmail = p.KargoFirmaEmail
            }).ToList();
            return View(liste);
        }
        public ActionResult KargoFirmaDetay(int kargoFirmaId)
        {
            int? id = HttpContext.Session.GetInt32("teknikElemanId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "TeknikEleman");
            }
            var model = _context.KargoFirmas.Where(p => p.KargoFirmaId == kargoFirmaId).OrderByDescending(p => p.KargoFirmaId).Select(p => new KargoFirma
            {
                Aktiflik = p.Aktiflik,
                KargoFirmaAd = p.KargoFirmaAd,
                Ulke = p.Ulke,
                KargoFirmaTel = p.KargoFirmaTel,
                KargoFirmaId = p.KargoFirmaId,
                KargoFirmaEmail = p.KargoFirmaEmail
            }).FirstOrDefault();

            return View(model);
        }
        public ActionResult KargoFirmaSil(int kargoFirmaId)
        {
            int? id = HttpContext.Session.GetInt32("teknikElemanId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "TeknikEleman");
            }
            _context.KargoFirmas.Find(kargoFirmaId).Aktiflik = false;
            _context.SaveChanges();
            return RedirectToAction("Index", "KargoFirma");
        }
    }
}
