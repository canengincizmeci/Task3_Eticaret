using DB.Models;
using Microsoft.AspNetCore.Mvc;

namespace TeknikDestekElemanPaneli.Controllers
{
    public class SikcaSorulanlarController : Controller
    {
        private readonly ILogger<SikcaSorulanlarController> _logger;
        private readonly Task3RealEcommerceContext _context;
        public SikcaSorulanlarController(ILogger<SikcaSorulanlarController> logger, Task3RealEcommerceContext context)
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

            var sorular = _context.SikcaSorulanlars.Where(p => p.Aktiflik == true).OrderByDescending(p => p.SorulmaId).Select(p => new SikcaSorulanlar
            {
                SorulmaId = p.SorulmaId,
                Aktiflik = p.Aktiflik,
                Cevap = p.Cevap,
                Soru = p.Soru
            }).ToList();
            return View(sorular);
        }
        public ActionResult SoruSil(int sorulmaId)
        {
            int? id = HttpContext.Session.GetInt32("teknikElemanId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "TeknikEleman");
            }
            _context.SikcaSorulanlars.Find(sorulmaId).Aktiflik = false;
            _context.SaveChanges();

            return RedirectToAction("Index", "SikcaSorulanlar");
        }
        [HttpGet]
        public ActionResult SoruEkle()
        {
            int? id = HttpContext.Session.GetInt32("teknikElemanId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "TeknikEleman");
            }


            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SoruEkle(SikcaSorulanlar _soru)
        {
            int? id = HttpContext.Session.GetInt32("teknikElemanId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "TeknikEleman");
            }
            _context.SikcaSorulanlars.Add(new SikcaSorulanlar
            {
                Aktiflik = true,
                Cevap = _soru.Cevap,
                Soru = _soru.Soru
            });
            _context.SaveChanges();
            return RedirectToAction("Index", "SikcaSorulanlar");
        }
        [HttpGet]
        public ActionResult SoruGuncelle(int sorulmaId)
        {
            int? id = HttpContext.Session.GetInt32("teknikElemanId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "TeknikEleman");
            }
            var soru = _context.SikcaSorulanlars.Find(sorulmaId);
            ViewBag.SoruId = sorulmaId;
            ViewBag.Soru = soru.Soru;
            ViewBag.Cevap = soru.Cevap;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SoruGuncelle(SikcaSorulanlar _soru)
        {
            int? id = HttpContext.Session.GetInt32("teknikElemanId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "TeknikEleman");
            }
            var soru = _context.SikcaSorulanlars.Find(_soru.SorulmaId);
            soru.Soru = _soru.Soru;
            soru.Cevap = _soru.Cevap;
            _context.SaveChanges();
            return RedirectToAction("Index", "SikcaSorulanlar");
        }
    }
}
