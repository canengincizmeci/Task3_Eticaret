using DB.Models;
using Microsoft.AspNetCore.Mvc;

namespace AdminPaneli.Controllers
{
    public class TeknikElemanController : Controller
    {
        private readonly ILogger<TeknikElemanController> _logger;
        private readonly Task3RealEcommerceContext _context;

        public TeknikElemanController(ILogger<TeknikElemanController> logger, Task3RealEcommerceContext context)
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
            var basvurular = _context.TeknikElemanBasvurus.OrderByDescending(p => p.BasvuruId).Select(p => new TeknikElemanBasvuru
            {
                Ad = p.Ad,
                Adres = p.Adres,
                BasvuruId = p.BasvuruId,
                Cinsiyet = p.Cinsiyet,
                DogumTarihi = p.DogumTarihi,
                Mail = p.Mail,
                MezuniyetDurumu = p.MezuniyetDurumu,
                Ozgecmis = p.Ozgecmis,
                Soyad = p.Soyad,
                TcNo = p.TcNo,
                TelefonNumarasi = p.TelefonNumarasi
            }).ToList();
            return View(basvurular);
        }
        public ActionResult BasvuruDetay(int basvuruId)
        {
            int? id = HttpContext.Session.GetInt32("adminId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "Admin");

            }
            var basvuru = _context.TeknikElemanBasvurus.Where(p => p.BasvuruId == basvuruId).OrderByDescending(p => p.BasvuruId).Select(p => new TeknikElemanBasvuru
            {
                Ad = p.Ad,
                Adres = p.Adres,
                BasvuruId = p.BasvuruId,
                Cinsiyet = p.Cinsiyet,
                DogumTarihi = p.DogumTarihi,
                Mail = p.Mail,
                MezuniyetDurumu = p.MezuniyetDurumu,
                Ozgecmis = p.Ozgecmis,
                Soyad = p.Soyad,
                TcNo = p.TcNo,
                TelefonNumarasi = p.TelefonNumarasi
            }).FirstOrDefault();
            return View(basvuru);
        }
        public ActionResult BasvuruOnayla(int basvuruId)
        {
            int? id = HttpContext.Session.GetInt32("adminId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "Admin");

            }
            var basvuru = _context.TeknikElemanBasvurus.Find(basvuruId);
            _context.TeknikElemanlars.Add(new TeknikElemanlar
            {
                Aktiflik = true,
                ElemanAd = basvuru.Ad,
                GirisTarihi = DateTime.Now,
                Mail = basvuru.Mail,
                Puan = 0,
                Sifre = null,
                Unvan = "eleman"
            });
            _context.SaveChanges();
            return RedirectToAction("TeknikElemanlar", "TeknikEleman");
        }
        public ActionResult TeknikElemanlar()
        {
            int? id = HttpContext.Session.GetInt32("adminId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "Admin");

            }
            var elemanlar = _context.TeknikElemanlars.Where(p => p.Aktiflik == true).OrderByDescending(p => p.TeknikElemanId).Select(p => new TeknikElemanlar
            {
                Aktiflik = p.Aktiflik,
                Unvan = p.Unvan,
                TeknikElemanId = p.TeknikElemanId,
                ElemanAd = p.ElemanAd,
                GirisTarihi = p.GirisTarihi,
                Mail = p.Mail,
                Puan = p.Puan,
                Sifre = p.Sifre,
            }).ToList();
            return View(elemanlar);
        }
        [HttpGet]
        public ActionResult MesajGonder(int elemanId)
        {

            ViewBag.ElemanId = elemanId;

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MesajGonder(int elemanId, string mesajBaslik, string mesaj)
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
            _context.AdmindenTeknikDestegeMesajs.Add(new AdmindenTeknikDestegeMesaj
            {
                AdminId = id,
                ElemanId = elemanId,
                Mesaj = mesaj,
                MesajBaslik = mesajBaslik,
                MesajlasmaId = mesajlasmaId,
                OkunduBilgisi = false,
                Tarih = DateTime.Now
            });
            _context.SaveChanges();

            return RedirectToAction("TeknikElemanlar", "TeknikEleman");
        }
    }
}
