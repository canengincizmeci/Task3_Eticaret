using DB.Models;
using Microsoft.AspNetCore.Mvc;

namespace AdminPaneli.Controllers
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
        public IActionResult Index()
        {
            int? id = HttpContext.Session.GetInt32("adminId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "Admin");

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
                SosyalSorumlulukKatilimSayisi = 0,
                ReferansOlmaSayisi = p.ReferansOlmaSayisi,
                ReferansKullaniciAd = p.ReferansKullaniciAd
            }).ToList();
            ViewBag.KullaniciSayisi = kullanicilar.Count;
            return View(kullanicilar);
        }
        public ActionResult KullaniciDetay(int kullaniciId)
        {
            int? id = HttpContext.Session.GetInt32("adminId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "Admin");

            }
            var kullaniciDetay = _context.Kullanicis.Where(p => p.KullaniciId == kullaniciId).OrderByDescending(p => p.KullaniciId).Select(p => new Kullanici
            {
                KullaniciId = p.KullaniciId,
                Aktiflik = p.Aktiflik,
                Adres = p.Adres,
                CoinMiktari = p.CoinMiktari,
                KayitTarihi = p.KayitTarihi,
                KullaniciAd = p.KullaniciAd,
                KullaniciResim = p.KullaniciResim,
                Mail = p.Mail,
                MailSifre = p.MailSifre,
                ReferansKullaniciAd = p.ReferansKullaniciAd,
                ReferansMail = p.ReferansMail,
                Sifre = p.Sifre,
                YorumSayisi = p.YorumSayisi,
                YorumCevapSayisi = p.YorumCevapSayisi,
                SosyalSorumlulukKatilimSayisi = p.SosyalSorumlulukKatilimSayisi,
                ReferansOlmaSayisi = p.ReferansOlmaSayisi
            }).FirstOrDefault();
            return View(kullaniciDetay);
        }
        public ActionResult KullaniciSil(int kullaniciId)
        {
            int? id = HttpContext.Session.GetInt32("adminId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "Admin");

            }
            _context.Kullanicis.Find(kullaniciId).Aktiflik = false;
            _context.SaveChanges();
            return RedirectToAction("Index", "Kullanici");
        }
        [HttpGet]
        public ActionResult KullaniciyaMesajGonder(int kullaniciId)
        {
            int? id = HttpContext.Session.GetInt32("adminId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "Admin");

            }
            ViewBag.KullaniciId = kullaniciId;


            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult KullaniciyaMesajGonder(int kullaniciId, string mesaj, string mesajBaslik)
        {
            int? id = HttpContext.Session.GetInt32("adminId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "Admin");

            }
            _context.Mesajlasmas.Add(new Mesajlasma
            {
                Tarih = DateTime.Now
            });
            _context.SaveChanges();
            int mesajlasmaId = _context.Mesajlasmas.OrderByDescending(p => p.MesajlasmaId).First().MesajlasmaId;
            _context.AdmindenKullaniciyaMesajs.Add(new AdmindenKullaniciyaMesaj
            {
                MesajlasmaId = mesajlasmaId,
                AdminId = id,
                KullaniciId = kullaniciId,
                Mesaj = mesaj,
                MesajBaslik = mesajBaslik,
                OkunduBilgisi = false,
                Tarih = DateTime.Now
            });
            _context.SaveChanges();
            return RedirectToAction("Index", "Kullanici");
        }
    }
}
