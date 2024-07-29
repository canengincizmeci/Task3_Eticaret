using DB.Models;
using Microsoft.AspNetCore.Mvc;
using TeknikDestekElemanPaneli.Models;

namespace TeknikDestekElemanPaneli.Controllers
{
    public class FirmaController : Controller
    {
        private readonly ILogger<FirmaController> _logger;
        private readonly Task3RealEcommerceContext _context;
        public FirmaController(ILogger<FirmaController> logger, Task3RealEcommerceContext context)
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
            var model = _context.Firmas.Where(p => p.Aktiflik == true).OrderByDescending(p => p.FirmaId).Select(p => new Firma
            {
                FirmaId = p.FirmaId,
                FirmaAd = p.FirmaAd,
                FirmaAdres = p.FirmaAdres,
                Mail = p.Mail,
                TelefonNumarasi = p.TelefonNumarasi
            }).ToList();
            return View(model);
        }

        public ActionResult FirmaDetay(int firmaId)
        {
            int? id = HttpContext.Session.GetInt32("teknikElemanId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "TeknikEleman");
            }

            int satisRedSayisi = _context.SatisReds.Where(p => p.FirmaId == firmaId).Count();
            int urunSayisi = _context.Uruns.Where(p => (p.FirmaId == firmaId && p.Aktiflik == true)).Count();
            int sikayetEtmeSayisi = _context.FirmadanKullaniciyaSikayets.Where(p => (p.FirmaId == firmaId && p.Aktiflik == true)).Count() + _context.FirmadanYorumSikayets.Where(p => (p.FirmaId == firmaId && p.Aktiflik == true)).Count() + _context.FirmadanTeknikElemanaSikayets.Where(p => (p.FirmaId == firmaId && p.Aktiflik == true)).Count() + _context.FirmadanKullaniciyaYorumCevapSikayets.Where(p => (p.FirmaId == firmaId && p.Aktiflik == true)).Count();
            int sikayetEdilmeSayisi = _context.KullanicidanFirmayaYorumCevapSikayets.Where(p => (p.FirmaId == firmaId && p.Aktiflik == true)).Count() + _context.KullanicidanFirmayaYorumCevapSikayets.Where(p => (p.FirmaId == firmaId && p.Aktiflik == true)).Count();
            float? toplamCiro = _context.Satislars.Where(p => p.FirmaId == firmaId).Sum(p => p.Siparis.Toplamfiyat);
            var model = _context.Firmas.Where(p => (p.FirmaId == firmaId && p.Aktiflik == true)).Select(p => new FirmaDetayModel
            {
                Aktiflik = p.Aktiflik,
                FirmaId = p.FirmaId,
                CoinMiktari = p.CoinMiktari,
                FirmaAd = p.FirmaAd,
                FirmaAdres = p.FirmaAdres,
                Mail = p.Mail,
                MailSifre = p.MailSifre,
                Puan = p.Puan,
                SatisSayisi = p.SatisSayisi,
                SosyalSorumlulukKatılımSayisi = p.SosyalSorumlulukKatılımSayisi,
                Sifre = p.Sifre,
                TelefonNumarasi = p.TelefonNumarasi,
                SatisReddetmeSayisi = satisRedSayisi,
                UrunSayisi = urunSayisi,
                SikayetEtmeSayisi = sikayetEtmeSayisi,
                SikayetEdilmeSayisi = sikayetEdilmeSayisi,
                ToplamCiro = toplamCiro
            }).FirstOrDefault();
            return View(model);
        }
        public ActionResult FirmaSil(int firmaId)
        {
            int? id = HttpContext.Session.GetInt32("teknikElemanId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "TeknikEleman");
            }

            _context.Firmas.Find(firmaId).Aktiflik = false;
            _context.SaveChanges();


            return RedirectToAction("Index", "Firma");
        }
        [HttpGet]
        public ActionResult FirmaEkle()
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
        public ActionResult FirmaEkle(Firma _firma)
        {
            int? id = HttpContext.Session.GetInt32("teknikElemanId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "TeknikEleman");
            }
            _context.Firmas.Add(new Firma
            {
                Aktiflik = true,
                CoinMiktari = 0,
                FirmaAd = _firma.FirmaAd,
                FirmaAdres = _firma.FirmaAdres,
                Mail = _firma.Mail,
                TelefonNumarasi = _firma.TelefonNumarasi,
                SosyalSorumlulukKatılımSayisi = 0,
                Sifre = _firma.Sifre,
                SatisSayisi = 0,
                Puan = 0
            });
            _context.SaveChanges();
            return RedirectToAction("Index", "Firma");
        }

    }
}
