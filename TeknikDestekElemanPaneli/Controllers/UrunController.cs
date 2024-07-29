using DB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
using Newtonsoft.Json;
using TeknikDestekElemanPaneli.Models;

namespace TeknikDestekElemanPaneli.Controllers
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
        public ActionResult Index(bool type = false)
        {
            int? id = HttpContext.Session.GetInt32("teknikElemanId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "TeknikEleman");
            }

            List<SelectListItem> ktg = (from k in _context.Kategoris.Where(p => p.Aktiflik == true).ToList()
                                        select new SelectListItem
                                        {
                                            Text = k.KategoriAd,
                                            Value = k.KategoriId.ToString()
                                        }).ToList();
            ViewBag.Ktg = ktg;

            List<SelectListItem> frm = (from f in _context.Firmas.Where(p => p.Aktiflik == true).ToList()
                                        select new SelectListItem
                                        {
                                            Text = f.FirmaAd,
                                            Value = f.FirmaId.ToString()
                                        }).ToList();
            ViewBag.Frm = frm;


            if (type == false)
            {
                var model = _context.Uruns.Where(p => p.Aktiflik == true).OrderByDescending(p => p.UrunId).Select(p => new UrunModel
                {
                    Aciklama = p.Aciklama,
                    UrunId = p.UrunId,
                    Aktiflik = p.Aktiflik,
                    EklenmeTarihi = p.EklenmeTarihi,
                    FirmaId = p.FirmaId,
                    Fiyat = p.Fiyat,
                    KategoriId = p.KategoriId,
                    SatisSayisi = p.SatisSayisi,
                    Stok = p.Stok,
                    UrunAd = p.UrunAd,
                    UrunResim = p.UrunResim,
                    SepeteEklemeSayisi = p.SepeteEklemeSayisi,
                    FirmaAd = p.Firma.FirmaAd,
                    KategoriAd = p.Kategori.KategoriAd
                }).ToList();
                return View(model);
            }
            else
            {
                var modelJson = HttpContext.Session.GetString("Filtre");
                var model = JsonConvert.DeserializeObject<List<UrunModel>>(modelJson);
                return View(model);
            }
        }
        public ActionResult KategoriFiltreIndex(int kategoriId)
        {
            int? id = HttpContext.Session.GetInt32("teknikElemanId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "TeknikEleman");
            }
            List<UrunModel>? _model = _context.Uruns.Where(p => p.KategoriId == kategoriId).OrderByDescending(p => p.UrunId).Select(p => new UrunModel
            {
                Aciklama = p.Aciklama,
                UrunId = p.UrunId,
                Aktiflik = p.Aktiflik,
                EklenmeTarihi = p.EklenmeTarihi,
                FirmaId = p.FirmaId,
                Fiyat = p.Fiyat,
                KategoriId = p.KategoriId,
                SatisSayisi = p.SatisSayisi,
                Stok = p.Stok,
                UrunAd = p.UrunAd,
                UrunResim = p.UrunResim,
                SepeteEklemeSayisi = p.SepeteEklemeSayisi,
                FirmaAd = p.Firma.FirmaAd,
                KategoriAd = p.Kategori.KategoriAd
            }).ToList();
            
            HttpContext.Session.SetString("Filtre", JsonConvert.SerializeObject(_model));

            return RedirectToAction("Index", "Urun", new { type = true });
        }
        public ActionResult FirmaFiltreIndex(int firmaId)
        {
            int? id = HttpContext.Session.GetInt32("teknikElemanId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "TeknikEleman");
            }
            List<UrunModel>? _model = _context.Uruns.Where(p => p.FirmaId == firmaId).OrderByDescending(p => p.UrunId).Select(p => new UrunModel
            {
                Aciklama = p.Aciklama,
                UrunId = p.UrunId,
                Aktiflik = p.Aktiflik,
                EklenmeTarihi = p.EklenmeTarihi,
                FirmaId = p.FirmaId,
                Fiyat = p.Fiyat,
                KategoriId = p.KategoriId,
                SatisSayisi = p.SatisSayisi,
                Stok = p.Stok,
                UrunAd = p.UrunAd,
                UrunResim = p.UrunResim,
                SepeteEklemeSayisi = p.SepeteEklemeSayisi,
                FirmaAd = p.Firma.FirmaAd,
                KategoriAd = p.Kategori.KategoriAd
            }).ToList();
            HttpContext.Session.SetString("Filtre", JsonConvert.SerializeObject(_model));
            return RedirectToAction("Index", "Urun", new { type = true });
        }
    }
}
