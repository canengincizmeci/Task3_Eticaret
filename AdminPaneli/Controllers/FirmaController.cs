using AdminPaneli.Models;
using DB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace AdminPaneli.Controllers
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
        public IActionResult Index()
        {
            int? id = HttpContext.Session.GetInt32("adminId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "Admin");

            }
            var basvurular = _context.FirmaBasvurus.Where(p => p.Aktiflik == true).OrderByDescending(p => p.BasvuruId).Select(p => new FirmaBasvuru
            {
                BasvuruId = p.BasvuruId,
                BasvuruTarih = p.BasvuruTarih,
                FirmaAciklama = p.FirmaAciklama,
                FirmaAd = p.FirmaAd,
                FirmaAdres = p.FirmaAdres,
                FirmaSektor = p.FirmaSektor
            }).ToList();
            return View(basvurular);
        }

        public ActionResult FirmaDetay(int basvuruId)
        {
            int? id = HttpContext.Session.GetInt32("adminId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "Admin");

            }
            var basvuru = _context.FirmaBasvurus.Where(p => p.BasvuruId == basvuruId).FirstOrDefault();
            return View(basvuru);
        }
        public ActionResult FirmaBasvuruOnayla(int basvuruId)
        {
            int? id = HttpContext.Session.GetInt32("adminId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "Admin");

            }
            var basvuru = _context.FirmaBasvurus.Find(basvuruId);
            _context.Firmas.Add(new Firma
            {
                Aktiflik = true,
                CoinMiktari = 0,
                FirmaAd = basvuru.FirmaAd,
                FirmaAdres = basvuru.FirmaAdres,
                Mail = basvuru.Mail,
                MailSifre = null,
                Puan = 0,
                TelefonNumarasi = basvuru.FirmaTel,
                SosyalSorumlulukKatılımSayisi = 0,
                Sifre = null,
                SatisSayisi = 0
            });
            basvuru.Aktiflik = false;
            _context.SaveChanges();

            return RedirectToAction("Index", "Firma");
        }
        public ActionResult FirmaBasvuruSil(int basvuruId)
        {
            int? id = HttpContext.Session.GetInt32("adminId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "Admin");
            }
            _context.FirmaBasvurus.Find(basvuruId).Aktiflik = false;
            _context.SaveChanges();
            return RedirectToAction("Index", "Firma");
        }
        public ActionResult FirmaListesi()
        {
            int? id = HttpContext.Session.GetInt32("adminId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "Admin");
            }
            var firmalar = _context.Firmas.Where(p => p.Aktiflik == true).Select(p => new Firma
            {
                Aktiflik = p.Aktiflik,
                CoinMiktari = p.CoinMiktari,
                FirmaAd = p.FirmaAd,
                FirmaAdres = p.FirmaAdres,
                FirmaId = p.FirmaId,
                Mail = p.Mail,
                Puan = p.Puan,
                TelefonNumarasi = p.TelefonNumarasi
            }).ToList();
            return View(firmalar);
        }
        public ActionResult FirmaSil(int firmaId)
        {
            int? id = HttpContext.Session.GetInt32("adminId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "Admin");
            }
            _context.Firmas.Find(firmaId).Aktiflik = false;
            _context.SaveChanges();
            return RedirectToAction("FirmaListesi", "Firma");
        }
        [HttpGet]
        public ActionResult FirmayaMesaj(int firmaId)
        {
            int? id = HttpContext.Session.GetInt32("adminId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "Admin");
            }
            ViewBag.FirmaId = firmaId;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FirmayaMesaj(string mesajBaslik, string mesaj, int firmaId)
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
            _context.AdmindenFirmayaMesajs.Add(new AdmindenFirmayaMesaj
            {
                AdminId = id,
                Tarih = DateTime.Now,
                OkunduBilgisi = false,
                MesajlasmaId = mesajlasmaId,
                FirmaId = firmaId,
                MesajBaslik = mesajBaslik,
                Mesaj = mesaj
            });
            _context.SaveChanges();

            return RedirectToAction("FirmaListesi", "Firma");
        }
        [HttpGet]
        public ActionResult FirmaEkle()
        {
            int? id = HttpContext.Session.GetInt32("adminId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "Admin");
            }



            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FirmaEkle(string firmaAd, string firmaAdres, string mail, string tel)
        {
            int? id = HttpContext.Session.GetInt32("adminId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "Admin");
            }


            _context.Firmas.Add(new Firma
            {
                Aktiflik = true,
                CoinMiktari = 0,
                FirmaAd = firmaAd,
                FirmaAdres = firmaAdres,
                Mail = mail,
                Puan = 0,
                SatisSayisi = 0,
                TelefonNumarasi = tel,
                Sifre = null,
                SosyalSorumlulukKatılımSayisi = 0,
                MailSifre = null
            });
            _context.SaveChanges();
            return RedirectToAction("FirmaListesi", "Firma");
        }
        public ActionResult FirmaOneriler()
        {
            int? id = HttpContext.Session.GetInt32("adminId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "Admin");
            }
            var oneriler = _context.FirmadanSiteOnerilers.Where(p => p.Aktiflik == true).OrderByDescending(p => p.OneriId).Select(p => new FirmaOneriModel
            {
                _Aktiflik = p.Aktiflik,
                _FirmaAd = p.Firma.FirmaAd,
                _FirmaId = p.FirmaId,
                _OneriBaslik = p.OneriBaslik,
                _OneriId = p.OneriId,
                _OneriMetin = p.OneriMetin,
                _Tarih = p.Tarih
            }).ToList();
            return View(oneriler);
        }
        [HttpGet]
        public ActionResult FirmaOneriyeCevapVer(int oneriId)
        {
            ViewBag.OneriId = oneriId;


            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FirmaOneriyeCevapVer(int oneriId, string mesaj, string mesajBaslik)
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
            var firma = (from o in _context.FirmadanSiteOnerilers
                         join f in _context.Firmas on o.FirmaId equals f.FirmaId
                         where o.OneriId == oneriId
                         select new FirmaOneriModel
                         {
                             _Aktiflik = f.Aktiflik,
                             _FirmaAd = f.FirmaAd,
                             _FirmaId = f.FirmaId,
                             _OneriBaslik = o.OneriBaslik,
                             _OneriId = o.OneriId,
                             _OneriMetin = o.OneriMetin,
                             _Tarih = o.Tarih
                         }).FirstOrDefault();
            _context.AdmindenFirmayaMesajs.Add(new AdmindenFirmayaMesaj
            {
                AdminId = id,
                FirmaId = firma._FirmaId,
                Mesaj = mesaj,
                Tarih = DateTime.Now,
                MesajlasmaId = mesajlasmaId,
                OkunduBilgisi = false,
                MesajBaslik = mesajBaslik
            });
            _context.SaveChanges();
            return RedirectToAction("FirmaOneriler", "Firma");
        }
        public ActionResult FirmaOneriSil(int oneriId)
        {
            int? id = HttpContext.Session.GetInt32("adminId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "Admin");
            }
            _context.FirmadanSiteOnerilers.Find(oneriId).Aktiflik = false;
            _context.SaveChanges();
            return RedirectToAction("FirmaOneriler", "Firma");
        }
    }
}

