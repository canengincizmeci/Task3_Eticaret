using AdminPaneli.Models;
using DB.Models;
using Microsoft.AspNetCore.Mvc;

namespace AdminPaneli.Controllers
{
    public class UrunController : Controller
    {
        private readonly ILogger<UrunController> _logger;
        private readonly Task3RealEcommerceContext _context;

        public UrunController(ILogger<UrunController> logger, Task3RealEcommerceContext context)
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
            var liste = _context.Uruns.Where(p => p.Aktiflik == true).OrderByDescending(p => p.UrunId).Select(p => new UrunModel
            {
                _UrunId = p.UrunId,
                _UrunAd = p.UrunAd,
                _UrunResim = p.UrunResim,
                _Aciklama = p.Aciklama,
                _FirmaAd = p.Firma.FirmaAd,
                _EklenmeTarihi = p.EklenmeTarihi,
                _Fiyat = p.Fiyat
            }).ToList();
            return View(liste);
        }
        public ActionResult UrunDetay(int urunId)
        {
            int? id = HttpContext.Session.GetInt32("adminId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "Admin");

            }
            var resim = _context.Uruns.Where(p => p.UrunId == urunId).Select(p => new UrunModel
            {
                _UrunId = p.UrunId,
                _UrunAd = p.UrunAd,
                _UrunResim = p.UrunResim,
                _Aciklama = p.Aciklama,
                _FirmaAd = p.Firma.FirmaAd,
                _EklenmeTarihi = p.EklenmeTarihi,
                _Fiyat = p.Fiyat,
                _Aktiflik = p.Aktiflik,
                _FirmaId = p.FirmaId,
                _KategoriAd = p.Kategori.KategoriAd,
                _KategoriId = p.KategoriId,
                _SatisSayisi = p.SatisSayisi,
                _SepeteEklemeSayisi = p.SepeteEklemeSayisi,
                _Stok = p.Stok
            }).FirstOrDefault();
            return View(resim);
        }
        [HttpGet]
        public ActionResult UrunBildir(int urunId, int firmaId)
        {
            ViewBag.UrunId = urunId;
            ViewBag.FirmaId = firmaId;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UrunBildir(int urunId, int firmaId, string mesaj)
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

            int _mesajlasmaId = _context.Mesajlasmas.OrderByDescending(p => p.MesajlasmaId).First().MesajlasmaId;
            string mesajBaslik = urunId.ToString() + " id 'li ürün";
            _context.AdmindenFirmayaMesajs.Add(new AdmindenFirmayaMesaj
            {
                AdminId = id,
                FirmaId = firmaId,
                Mesaj = mesaj,
                MesajBaslik = mesajBaslik,
                Tarih = DateTime.Now,
                OkunduBilgisi = false,
                MesajlasmaId = _mesajlasmaId
            });
            _context.SaveChanges();

            return RedirectToAction("Index", "Urun");

        }
        public ActionResult UrunSil(int urunId)
        {
            int? id = HttpContext.Session.GetInt32("adminId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "Admin");

            }
            _context.Uruns.Find(urunId).Aktiflik = false;
            _context.SaveChanges();
            return RedirectToAction("Index", "Urun");
        }
    }
}
