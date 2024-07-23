using DB.Models;
using Microsoft.AspNetCore.Mvc;
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
    }
}
