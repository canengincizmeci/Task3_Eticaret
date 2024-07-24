using DB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using TeknikDestekElemanPaneli.Models;

namespace TeknikDestekElemanPaneli.Controllers
{
    public class YarismaController : Controller
    {
        private readonly ILogger<YarismaController> _logger;
        private readonly Task3RealEcommerceContext _context;
        public YarismaController(ILogger<YarismaController> logger, Task3RealEcommerceContext context)
        {
            _logger = logger;
            _context = context;
        }
        public ActionResult FirmaYarismaIndex()
        {
            int? id = HttpContext.Session.GetInt32("teknikElemanId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "TeknikEleman");
            }
            var firmaYarismalar = _context.FirmaYarismalars.Where(p => p.Aktiflik == true).OrderByDescending(p => p.FirmayarismaId).Select(p => new FirmaYarismalar
            {
                Aktiflik = p.Aktiflik,
                FirmayarismaId = p.FirmayarismaId,
                BaslangicTarih = p.BaslangicTarih,
                BitisTarih = p.BitisTarih,
                YarismaAciklama = p.YarismaAciklama,
                YarismaBaslik = p.YarismaBaslik
            }).ToList();

            return View(firmaYarismalar);
        }
        public ActionResult FirmaYarismaDetay(int yarismaId)
        {
            int? id = HttpContext.Session.GetInt32("teknikElemanId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "TeknikEleman");
            }
            var detay = _context.FirmaYarismalars.Where(p => p.FirmayarismaId == yarismaId).Select(p => new FirmaYarismalar
            {
                BitisTarih = p.BitisTarih,
                YarismaBaslik = p.YarismaBaslik,
                BaslangicTarih = p.BaslangicTarih,
                Aktiflik = p.Aktiflik,
                FirmayarismaId = p.FirmayarismaId,
                YarismaAciklama = p.YarismaAciklama
            }).FirstOrDefault();

            return View(detay);
        }
        public ActionResult FirmaYarismaKazananlar(int yarismaId)
        {
            int? id = HttpContext.Session.GetInt32("teknikElemanId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "TeknikEleman");
            }

            var kazananIdler = _context.Satislars.GroupBy(p => p.FirmaId).Select(p => new { FirmaId = p.Key, ToplamSatis = p.Sum(l => l.Siparis.Toplamfiyat) }).Join(_context.FirmaYarismasiKatilanlars, satis => satis.FirmaId, katilan => katilan.FirmaId, (satis, katilan) => new
            {
                satis.FirmaId,
                satis.ToplamSatis,
                katilan.FirmayarismaId
            }).Where(m => m.FirmayarismaId == yarismaId).OrderByDescending(k => k.ToplamSatis).Take(3).Select(k => k.FirmaId).ToList();


            var model = _context.Firmas.Where(p => (p.Aktiflik == true && kazananIdler.Contains(p.FirmaId))).Select(p => new Firma
            {
                FirmaId = p.FirmaId,
                FirmaAdres = p.FirmaAdres,
                Aktiflik = p.Aktiflik,
                Mail = p.Mail,

            }).ToList();

            foreach (var item in model)
            {
                _context.FirmaYarismaKazanlars.Add(new FirmaYarismaKazanlar
                {
                    Aktiflik = true,
                    FirmaId = item.FirmaId,
                    FirmayarismaId = yarismaId,
                    KazanmaTarih = DateTime.Now
                });
                _context.SaveChanges();
            }



            return View(model);
        }
        public ActionResult FirmaYarismaKatilanlar(int yarismaId)
        {
            int? id = HttpContext.Session.GetInt32("teknikElemanId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "TeknikEleman");
            }
            var katilanlar = _context.FirmaYarismasiKatilanlars.Where(p => p.FirmayarismaId == yarismaId).Select(p => new FirmaYarismaKatilanlarModel
            {
                _firmaAdres = p.Firma.FirmaAdres,
                _firmaAd = p.Firma.FirmaAd,
                _firmaId = p.Firma.FirmaId
            }).ToList();


            return View(katilanlar);
        }
        [HttpGet]
        public ActionResult FirmaYarismaEkle()
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
        public ActionResult FirmaYarismaEkle(FirmaYarismalar _yarisma)
        {
            int? id = HttpContext.Session.GetInt32("teknikElemanId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "TeknikEleman");
            }
            _context.FirmaYarismalars.Add(new FirmaYarismalar
            {
                Aktiflik = true,
                BaslangicTarih = _yarisma.BaslangicTarih,
                BitisTarih = _yarisma.BitisTarih,
                YarismaAciklama = _yarisma.YarismaAciklama,
                YarismaBaslik = _yarisma.YarismaBaslik
            });
            _context.SaveChanges();



            return RedirectToAction("FirmaYarismaIndex", "Yarisma");
        }
        [HttpGet]
        public ActionResult FirmaYarismaTarihUzat(int yarismaId)
        {
            int? id = HttpContext.Session.GetInt32("teknikElemanId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "TeknikEleman");
            }
            var yarisma = _context.FirmaYarismalars.Find(yarismaId);
            ViewBag.Ad = yarisma.YarismaBaslik;
            ViewBag.Baslangic = yarisma.BaslangicTarih;
            ViewBag.Bitis = yarisma.BitisTarih;
            ViewBag.Id = yarisma.FirmayarismaId;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FirmaYarismaTarihUzat(int yarismaId, DateTime tarih)
        {
            int? id = HttpContext.Session.GetInt32("teknikElemanId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "TeknikEleman");
            }
            var yarisma = _context.FirmaYarismalars.Find(yarismaId);
            yarisma.BitisTarih = tarih;
            _context.SaveChanges();
            return RedirectToAction("FirmaYarismaIndex", "Yarisma");
        }
        public ActionResult KullaniciYarismaIndex()
        {
            int? id = HttpContext.Session.GetInt32("teknikElemanId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "TeknikEleman");
            }
            var yarismalar = _context.KullaniciYarismalars.Where(p => p.Aktiflik == true).OrderByDescending(p => p.KullaniciYarismaId).Select(p => new KullaniciYarismalar
            {
                Aktiflik = p.Aktiflik,
                KullaniciYarismaId = p.KullaniciYarismaId,
                BaslangicTarih = p.BaslangicTarih,
                BitisTarih = p.BitisTarih,
                YarismaAciklama = p.YarismaAciklama,
                YarismaBaslik = p.YarismaBaslik
            }).ToList();
            return View(yarismalar);
        }
        public ActionResult KullaniciYarismaDetay(int yarismaId)
        {
            int? id = HttpContext.Session.GetInt32("teknikElemanId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "TeknikEleman");
            }
            var yarisma = _context.KullaniciYarismalars.Where(p => p.KullaniciYarismaId == yarismaId).Select(p => new KullaniciYarismalar
            {
                Aktiflik = p.Aktiflik,
                KullaniciYarismaId = p.KullaniciYarismaId,
                BaslangicTarih = p.BaslangicTarih,
                BitisTarih = p.BitisTarih,
                YarismaAciklama = p.YarismaAciklama,
                YarismaBaslik = p.YarismaBaslik
            }).FirstOrDefault();


            return View(yarisma);
        }
        [HttpGet]
        public ActionResult KullaniciYarismaTarihUzat(int yarismaId)
        {
            int? id = HttpContext.Session.GetInt32("teknikElemanId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "TeknikEleman");
            }
            var yarisma = _context.KullaniciYarismalars.Find(yarismaId);
            ViewBag.Ad = yarisma.YarismaBaslik;
            ViewBag.Baslangic = yarisma.BaslangicTarih;
            ViewBag.Bitis = yarisma.BitisTarih;
            ViewBag.Id = yarisma.KullaniciYarismaId;

            return View();
        }
        [HttpPost]
        public ActionResult KullaniciYarismaTarihUzat(int yarismaId, DateTime tarih)
        {
            int? id = HttpContext.Session.GetInt32("teknikElemanId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "TeknikEleman");
            }
            var yarisma = _context.KullaniciYarismalars.Find(yarismaId);
            yarisma.BitisTarih = tarih;
            _context.SaveChanges();
            return RedirectToAction("KullaniciYarismaIndex", "Yarisma");
        }
        public ActionResult KullaniciYarismaKatilanlar(int yarismaId)
        {
            int? id = HttpContext.Session.GetInt32("teknikElemanId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "TeknikEleman");
            }
            var kullanicilar = _context.KullaniciYarismaKatilanlars.Where(p => p.KullaniciYarismaId == yarismaId).OrderByDescending(p => p.KatilimId).Select(p => new KullaniciYarismaKatilanlarModel
            {
                _kullaniciAd = p.Kullanici.KullaniciAd,
                _kullaniciId = p.Kullanici.KullaniciId,
                _kullaniciMail = p.Kullanici.Mail
            }).ToList();


            return View(kullanicilar);
        }
        public ActionResult KullaniciYarismaKazananlar(int yarismaId)
        {
            int? id = HttpContext.Session.GetInt32("teknikElemanId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "TeknikEleman");
            }

            var kazananIdler = _context.Satislars.GroupBy(p => p.Kullanici.KullaniciId).Select(p => new { KullaniciId = p.Key, ToplamSatis = p.Sum(l => l.Siparis.Toplamfiyat) }).Join(_context.KullaniciYarismaKatilanlars, satis => satis.KullaniciId, katilan => katilan.Kullanici.KullaniciId, (satis, katilan) => new
            {
                satis.KullaniciId,
                satis.ToplamSatis,
                katilan.KullaniciYarismaId
            }).Where(m => m.KullaniciYarismaId == yarismaId).OrderByDescending(k => k.ToplamSatis).Take(3).Select(k => k.KullaniciId).ToList();


            var model = _context.Kullanicis.Where(p => (p.Aktiflik == true && kazananIdler.Contains(p.KullaniciId))).Select(p => new Kullanici
            {
                KullaniciId = p.KullaniciId,
                KullaniciAd = p.KullaniciAd,
                Aktiflik = p.Aktiflik,
                Mail = p.Mail

            }).ToList();

            foreach (var item in model)
            {
                _context.KullaniciYarismaKazananlars.Add(new KullaniciYarismaKazananlar
                {
                    KullaniciId = item.KullaniciId,
                    KazanmaTarih = DateTime.Now,
                    KullaniciYarismaId = yarismaId
                });
                _context.SaveChanges();
            }



            return View(model);
        }
        [HttpGet]
        public ActionResult KullaniciYarismaEkle()
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
        public ActionResult KullaniciYarismaEkle(KullaniciYarismalar _yarisma)
        {
            int? id = HttpContext.Session.GetInt32("teknikElemanId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "TeknikEleman");
            }

            _context.KullaniciYarismalars.Add(new KullaniciYarismalar
            {
                Aktiflik = true,
                BaslangicTarih = _yarisma.BaslangicTarih,
                BitisTarih = _yarisma.BitisTarih,
                YarismaAciklama = _yarisma.YarismaAciklama,
                YarismaBaslik = _yarisma.YarismaBaslik
            });
            _context.SaveChanges();
            return RedirectToAction("KullaniciYarismaIndex", "Yarisma");
        }
    }
}
