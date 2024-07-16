using AdminPaneli.Models;
using DB.Models;
using Microsoft.AspNetCore.Mvc;

namespace AdminPaneli.Controllers
{
    public class SikayetController : Controller
    {
        private readonly ILogger<SikayetController> _logger;
        private readonly Task3RealEcommerceContext _context;

        public SikayetController(ILogger<SikayetController> logger, Task3RealEcommerceContext context)
        {
            _logger = logger;
            _context = context;
        }
        public IActionResult Index()
        {
            var firmadanTeknikElemanaSikayet = _context.FirmadanTeknikElemanaSikayets.Count();
            var kullanicidanTeknikElemanSikayet = _context.KullanicidanTeknikElemanaSikayets.Count();
            var kargodanTeknikElemanSikayet = _context.KargoFirmadanTeknikElmanSikayetis.Count();
            ViewBag.FirmadanTeknike = firmadanTeknikElemanaSikayet;
            ViewBag.KullanicidanTeknike = kullanicidanTeknikElemanSikayet;
            ViewBag.KargodanTeknike = kargodanTeknikElemanSikayet;

            return View();
        }
        public ActionResult FirmadanTeknikeSikayet()
        {
            var veriler = _context.FirmadanTeknikElemanaSikayets.Where(p => p.Aktiflik == true).OrderByDescending(p => p.SikayetId).Select(p => new SikayetModel
            {
                elemanAd = p.TeknikEleman.ElemanAd,
                Aktiflik = p.Aktiflik,
                SikayetMetni = p.SikayetMetni,
                firmaAd = p.Firma.FirmaAd,
                Tarih = p.Tarih,
                FirmaId = p.FirmaId,
                SikayetBaslik = p.SikayetBaslik,
                SikayetId = p.SikayetId,
                TeknikElemanId = p.TeknikElemanId
            }).ToList();


            return View(veriler);
        }
        public ActionResult FirmaSikayetSil(int sikayetId)
        {
            int? id = HttpContext.Session.GetInt32("adminId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "Admin");

            }
            _context.FirmadanTeknikElemanaSikayets.Find(sikayetId).Aktiflik = false;
            _context.SaveChanges();
            return RedirectToAction("Index", "Sikayet");
        }
    }
}
