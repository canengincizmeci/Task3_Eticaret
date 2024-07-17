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
    }
}
