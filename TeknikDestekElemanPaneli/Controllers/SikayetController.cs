using DB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TeknikDestekElemanPaneli.Models;

namespace TeknikDestekElemanPaneli.Controllers
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
            return View();
        }
        public ActionResult FirmayaGelenSikayetler(int firmaId)
        {
            int? id = HttpContext.Session.GetInt32("teknikElemanId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "TeknikEleman");
            }

            FirmayaGelenSikayetlerModel model = new FirmayaGelenSikayetlerModel()
            {
                kullanicidanFirmayaSikayetler = _context.KullanicidanFirmayaSikayets.Where(p => (p.Aktiflik == true && p.FirmaId == firmaId)).OrderByDescending(p => p.SikayetId).Select(p => new KullanicidanFirmayaSikayetModel
                {
                    Tarih = p.Tarih,
                    SikayetciId = p.SikayetciId,
                    Aktiflik = p.Aktiflik,
                    FirmaAd = p.Firma.FirmaAd,
                    FirmaId = p.FirmaId,
                    KullaniciAd = p.Sikayetci.KullaniciAd,
                    SikayetBaslik = p.SikayetBaslik,
                    SikayetId = p.SikayetId,
                    SikayetMetni = p.SikayetMetni
                }).ToList(),
                kullanicidanFirmayaYorumSikayetler = _context.KullanicidanFirmayaYorumCevapSikayets.Where(p => (p.FirmaId == firmaId && p.Aktiflik == true)).OrderByDescending(p => p.KullaniciYorumCevapSikayetId).Select(p => new KullanicidanFirmayaYorumCevapSikayetModel
                {
                    Aktiflik = p.Aktiflik,
                    FirmaAd = p.Firma.FirmaAd,
                    FirmaId = p.FirmaId,
                    KullaniciAd = p.Kullanici.KullaniciAd,
                    KullaniciId = p.KullaniciId,
                    KullaniciYorumCevapSikayetId = p.KullaniciYorumCevapSikayetId,
                    SikayetBaslik = p.SikayetBaslik,
                    SikayetMetni = p.SikayetMetni,
                    Tarih = p.Tarih,
                    Yorum = p.YorumCevap.Yorum.Yorum,
                    YorumCevapId = p.YorumCevapId
                }).ToList()
            };

            return View(model);
        }
        public ActionResult UrunGelenSikayetler(int urunId)
        {
            int? id = HttpContext.Session.GetInt32("teknikElemanId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "TeknikEleman");
            }
            var sikayetler = _context.UrunSikayets.Where(p => p.UrunId == urunId).OrderByDescending(p => p.UrunsikayetId).Select(p => new UrunSikayetModel
            {
                UrunsikayetId = p.UrunsikayetId,
                Aktiflik = p.Aktiflik,
                KullaniciAd = p.Kullanici.KullaniciAd,
                KullaniciId = p.KullaniciId,
                SikayetBaslik = p.SikayetBaslik,
                SikayetMetni = p.SikayetMetni,
                Tarih = p.Tarih,
                UrunAd = p.Urun.UrunAd,
                UrunId = p.UrunId,
                FirmaAd = p.Urun.Firma.FirmaAd,
                FirmaId = p.Urun.FirmaId
            }).ToList();
            return View(sikayetler);
        }
        public ActionResult KullaniciGelenSikayetler(int kullaniciId)
        {
            int? id = HttpContext.Session.GetInt32("teknikElemanId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "TeknikEleman");
            }

            KullaniciyaSikayetlerModel model = new KullaniciyaSikayetlerModel()
            {
                firmadanYorumSikayetler = _context.FirmadanYorumSikayets.Where(p => (p.Aktiflik == true && p.KullaniciId == kullaniciId)).OrderByDescending(p => p.YorumSikayetId).Select(p => new FirmadanYorumSikayetModel
                {
                    FirmaId = p.FirmaId,
                    Aktiflik = p.Aktiflik,
                    KullaniciId = p.KullaniciId,
                    SikayetBaslik = p.SikayetBaslik,
                    SikayetMetni = p.SikayetMetni,
                    Tarih = p.Tarih,
                    YorumId = p.YorumId,
                    FirmaAd = p.Firma.FirmaAd,
                    KullaniciAd = p.Kullanici.KullaniciAd,
                    Yorum = p.Yorum.Yorum
                }).ToList(),
                firmadanKullaniciyaSikayetler = _context.FirmadanKullaniciyaSikayets.Where(p => (p.Aktiflik == true && p.KullaniciId == kullaniciId)).OrderByDescending(p => p.SikayetId).Select(p => new FirmadanKullaniciyaSikayetModel
                {
                    Tarih = p.Tarih,
                    SikayetMetni = p.SikayetMetni,
                    SikayetBaslik = p.SikayetBaslik,
                    KullaniciId = p.KullaniciId,
                    KullaniciAd = p.Kullanici.KullaniciAd,
                    Aktiflik = p.Aktiflik,
                    FirmaAd = p.Firma.FirmaAd,
                    FirmaId = p.FirmaId,
                    SikayetId = p.SikayetId
                }).ToList(),
                firmadanYorumCevapSikayetler = _context.FirmadanKullaniciyaYorumCevapSikayets.Where(p => (p.Aktiflik == true && p.KullaniciId == kullaniciId)).OrderByDescending(p => p.FirmaYorumCevapSikayetId).Select(p => new FirmadanKullaniciyaYorumCevapSikayetModel
                {
                    Aktiflik = p.Aktiflik,
                    FirmaAd = p.Firma.FirmaAd,
                    FirmaId = p.FirmaId,
                    KullaniciAd = p.Kullanici.KullaniciAd,
                    KullaniciId = p.KullaniciId,
                    SikayetBaslik = p.SikayetBaslik,
                    SikayetMetni = p.SikayetMetni,
                    Tarih = p.Tarih,
                    Yorum = p.YorumCevap.Yorum.Yorum,
                    YorumCevap = p.YorumCevap.Cevap,
                    YorumCevapId = p.YorumCevapId
                }).ToList()
            };
            return View(model);
        }
    }
}
