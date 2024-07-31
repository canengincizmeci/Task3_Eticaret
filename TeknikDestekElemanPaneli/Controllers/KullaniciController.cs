using DB.Models;
using Microsoft.AspNetCore.Mvc;

namespace TeknikDestekElemanPaneli.Controllers
{
    public class KullaniciController : Controller
    {
        private readonly ILogger<KullaniciController> _logger;
        private readonly Task3RealEcommerceContext _context;
        public KullaniciController(ILogger<KullaniciController> logger, Task3RealEcommerceContext context)
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
            var kullanicilar = _context.Kullanicis.Where(p => p.Aktiflik == true).OrderByDescending(p => p.KullaniciId).Select(p => new Kullanici
            {
                KullaniciId = p.KullaniciId,
                Adres = p.Adres,
                Aktiflik = p.Aktiflik,
                CoinMiktari = p.CoinMiktari,
                KayitTarihi = p.KayitTarihi,
                KullaniciAd = p.KullaniciAd,
                KullaniciResim = p.KullaniciResim,
                Mail = p.Mail,
                YorumSayisi = p.YorumSayisi,
                YorumCevapSayisi = p.YorumCevapSayisi,
                SosyalSorumlulukKatilimSayisi = p.SosyalSorumlulukKatilimSayisi,
                Sifre = p.Sifre,
                ReferansOlmaSayisi = p.ReferansOlmaSayisi,
                ReferansMail = p.ReferansMail,
                ReferansKullaniciAd = p.ReferansKullaniciAd,
                MailSifre = p.MailSifre
            }).ToList();
            return View(kullanicilar);
        }
        public ActionResult KullaniciDetay(int kullaniciId)
        {
            int? id = HttpContext.Session.GetInt32("teknikElemanId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "TeknikEleman");
            }
            var kullanici = _context.Kullanicis.Where(p => p.KullaniciId == kullaniciId).OrderByDescending(p => p.KullaniciId).Select(p => new Kullanici
            {
                KullaniciId = p.KullaniciId,
                Adres = p.Adres,
                Aktiflik = p.Aktiflik,
                CoinMiktari = p.CoinMiktari,
                KayitTarihi = p.KayitTarihi,
                KullaniciAd = p.KullaniciAd,
                KullaniciResim = p.KullaniciResim,
                Mail = p.Mail,
                YorumSayisi = p.YorumSayisi,
                YorumCevapSayisi = p.YorumCevapSayisi,
                SosyalSorumlulukKatilimSayisi = p.SosyalSorumlulukKatilimSayisi,
                Sifre = p.Sifre,
                ReferansOlmaSayisi = p.ReferansOlmaSayisi,
                ReferansMail = p.ReferansMail,
                ReferansKullaniciAd = p.ReferansKullaniciAd,
                MailSifre = p.MailSifre
            }).FirstOrDefault();
            return View(kullanici);
        }
        public ActionResult KullaniciSil(int kullaniciId)
        {
            int? id = HttpContext.Session.GetInt32("teknikElemanId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "TeknikEleman");
            }
            _context.Kullanicis.Find(kullaniciId).Aktiflik = false;
            _context.SaveChanges();
            return RedirectToAction("Index", "Kullanici");
        }




    }
}
