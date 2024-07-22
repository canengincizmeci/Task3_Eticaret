using AdminPaneli.Models;
using DB.Models;
using Microsoft.AspNetCore.Mvc;

namespace AdminPaneli.Controllers
{
    public class IstatistikController : Controller
    {
        private readonly ILogger<IstatistikController> _logger;
        private readonly Task3RealEcommerceContext _context;

        public IstatistikController(ILogger<IstatistikController> logger, Task3RealEcommerceContext context)
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





            return View();
        }
        public ActionResult ArananTumKelimeler()
        {
            int? id = HttpContext.Session.GetInt32("adminId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "Admin");
            }
            var liste = _context.ArananKelimelers.Where(p => p.Aktiflik == true).OrderByDescending(p => p.AramaId).Select(p => new ArananKelimeler
            {
                AramaId = p.AramaId,
                Aktiflik = p.Aktiflik,
                Kelime = p.Kelime,
                Tarih = p.Tarih
            }).ToList();

            var aramaSayilari = _context.ArananKelimelers.Where(p => p.Aktiflik == true).GroupBy(p => p.Kelime).Select(g => new { Kelime = g.Key, AramaSayisi = g.Count() }).ToDictionary(g => g.Kelime, g => g.AramaSayisi);

            ViewBag.AranmaSayilari = aramaSayilari;


            return View(liste);
        }
        public ActionResult ArananTumKelimeSilVeYasakla(int aramaId)
        {
            int? id = HttpContext.Session.GetInt32("adminId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "Admin");
            }
            var silinecekKelime = _context.ArananKelimelers.FirstOrDefault(p => p.AramaId == aramaId);
            if (silinecekKelime.Kelime != null)
            {
                var ayniKelimeler = _context.ArananKelimelers.Where(p => p.Kelime == silinecekKelime.Kelime).ToList();

                foreach (var kayit in ayniKelimeler)
                {
                    kayit.Aktiflik = false;
                }
                _context.SaveChanges();

            }

            return RedirectToAction("ArananTumKelimeler", "Istatistik");
        }
        public ActionResult EnCokArananKelimeler()
        {
            int? id = HttpContext.Session.GetInt32("adminId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "Admin");
            }
            var enCokArananKelimeler = _context.EnCokArananKelimelers.Where(p => p.Aktiflik == true).OrderByDescending(p => p.AranmaSayisi).Select(p => new EnCokArananKelimeler
            {
                AranmaSayisi = p.AranmaSayisi,
                Aktiflik = p.Aktiflik,
                EncokArananKelimeId = p.EncokArananKelimeId,
                Kelime = p.Kelime
            }).ToList();
            return View(enCokArananKelimeler);
        }
        public ActionResult EnCokArananKelimelerSilVeYasakla(int aramaId)
        {
            int? id = HttpContext.Session.GetInt32("adminId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "Admin");
            }

            var silenecekKelime = _context.EnCokArananKelimelers.FirstOrDefault(p => p.EncokArananKelimeId == aramaId);
            if (silenecekKelime != null)
            {

                var ayniKelimeler = _context.EnCokArananKelimelers.Where(p => p.Kelime == silenecekKelime.Kelime).ToList();
                foreach (var kelime in ayniKelimeler)
                {
                    kelime.Aktiflik = false;
                }
                _context.SaveChanges();
            }

            return RedirectToAction("EnCokArananKelimeler", "Istatistik");
        }
        public ActionResult EnCokArananUrunler()
        {
            int? id = HttpContext.Session.GetInt32("adminId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "Admin");
            }
            var liste = _context.EnCokArananUruns.Where(p => p.Aktiflik == true).OrderByDescending(p => p.AranmaSayisi).Select(p => new EnCokArananUrun
            {
                UrunId = p.UrunId,
                AranmaSayisi = p.AranmaSayisi,
                EnCokArananUrunId = p.EnCokArananUrunId,
                Aktiflik = p.Aktiflik,
                UrunAd = p.Urun.UrunAd
            }).ToList();
            if (liste.Count > 1000)
            {
                liste = liste.Take(1000).ToList();
            }

            return View(liste);
        }
        public ActionResult EnCokArananKategoriler()
        {
            int? id = HttpContext.Session.GetInt32("adminId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "Admin");
            }
            var liste = _context.EnCokArananKategoris.Where(p => p.Aktiflik == true).OrderByDescending(p => p.AranmaSayisi).Select(p => new EnCokArananKategori
            {
                AranmaSayisi = p.AranmaSayisi,
                Aktiflik = p.Aktiflik,
                EnCokAranmaId = p.EnCokAranmaId,
                KategoriAd = p.KategoriAd,
                KategoriId = p.KategoriId
            }).ToList();


            return View(liste);
        }
        public ActionResult SatisGrafigi()
        {
            int? id = HttpContext.Session.GetInt32("adminId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "Admin");
            }
            var satislar = _context.Satislars.GroupBy(p => p.Tarih).Select(p => new GrafikModel
            {
                tarih = p.Key,
                miktar = p.Count()
            }).ToList();


            return View(satislar);
        }
        
    }
}

