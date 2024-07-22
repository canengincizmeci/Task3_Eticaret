using AdminPaneli.Models;
using DB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AdminPaneli.Controllers
{
    public class KampanyaController : Controller
    {
        private readonly ILogger<KampanyaController> _logger;
        private readonly Task3RealEcommerceContext _context;

        public KampanyaController(ILogger<KampanyaController> logger, Task3RealEcommerceContext context)
        {
            _logger = logger;
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public ActionResult KategoriKampanyalar()
        {
            int? id = HttpContext.Session.GetInt32("adminId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "Admin");
            }
            var kategoriler = _context.KategoriKampanyalars.Where(p => p.Aktiflik == true).OrderByDescending(p => p.KampanyaId).Select(p => new KampanyaModel
            {
                _BaslangicTarihi = p.BaslangicTarihi,
                _BitisTarihi = p.BitisTarihi,
                _IndirimMiktari = p.IndirimMiktari,
                _KampanyaAciklama = p.KampanyaAciklama,
                _KampanyaBaslik = p.KampanyaBaslik,
                _KampanyaId = p.KampanyaId,
                _KategoriId = p.KategoriId,
                _KategoriAd = p.Kategori.KategoriAd
            }).ToList();


            return View(kategoriler);
        }
        public ActionResult KategoriKampanyaDetay(int kampanyaId)
        {
            int? id = HttpContext.Session.GetInt32("adminId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "Admin");
            }
            var kampanya = _context.KategoriKampanyalars.Where(p => p.KampanyaId == kampanyaId).OrderByDescending(p => p.KampanyaId).Select(p => new KampanyaModel
            {
                _BaslangicTarihi = p.BaslangicTarihi,
                _BitisTarihi = p.BitisTarihi,
                _IndirimMiktari = p.IndirimMiktari,
                _KampanyaAciklama = p.KampanyaAciklama,
                _KampanyaBaslik = p.KampanyaBaslik,
                _KampanyaId = p.KampanyaId,
                _KategoriId = p.KategoriId,
                _KategoriAd = p.Kategori.KategoriAd
            }).FirstOrDefault();
            return View(kampanya);
        }
        public ActionResult KategoriKampanyaBitir(int kampanyaId)
        {
            int? id = HttpContext.Session.GetInt32("adminId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "Admin");
            }
            _context.KategoriKampanyalars.Find(kampanyaId).Aktiflik = false;
            _context.SaveChanges();


            return RedirectToAction("KategoriKampanyalar", "Kampanya");
        }
        [HttpGet]
        public ActionResult KategoriKampanyaUzat(int kampanyaId)
        {
            int? id = HttpContext.Session.GetInt32("adminId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "Admin");
            }
            var kampanya = _context.KategoriKampanyalars.Find(kampanyaId);
            ViewBag.BaslangicTarih = kampanya.BaslangicTarihi;
            ViewBag.Id = kampanya.KampanyaId;
            ViewBag.Ad = kampanya.KampanyaBaslik;
            ViewBag.EskiBitis = kampanya.BitisTarihi;


            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult KategoriKampanyaUzat(int kampanyaId, DateTime tarih)
        {
            int? id = HttpContext.Session.GetInt32("adminId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "Admin");
            }
            var kampanya = _context.KategoriKampanyalars.Find(kampanyaId);
            kampanya.BitisTarihi = tarih;
            _context.SaveChanges();
            return RedirectToAction("KategoriKampanyalar", "Kampanya");
        }
        [HttpGet]
        public ActionResult KategoriKampanyaEkle()
        {

            List<SelectListItem> ktg = (from i in _context.Kategoris.Where(p => p.Aktiflik == true).ToList()
                                        select new SelectListItem
                                        {
                                            Text = i.KategoriAd,
                                            Value = i.KategoriId.ToString()
                                        }).ToList();
            ViewBag.Ktg = ktg;



            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult KategoriKampanyaEkle(KategoriKampanyalar _kampanya)
        {
            int? id = HttpContext.Session.GetInt32("adminId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "Admin");
            }
            _context.KategoriKampanyalars.Add(new DB.Models.KategoriKampanyalar
            {
                Aktiflik = true,
                BaslangicTarihi = _kampanya.BaslangicTarihi,
                BitisTarihi = _kampanya.BitisTarihi,
                IndirimMiktari = _kampanya.IndirimMiktari,
                KampanyaAciklama = _kampanya.KampanyaAciklama,
                KampanyaBaslik = _kampanya.KampanyaBaslik,
                KategoriId = _kampanya.KategoriId
            });
            _context.SaveChanges();

            return RedirectToAction("KategoriKampanyalar", "Kampanya");
        }

        public ActionResult UrunKampanyalar()
        {
            int? id = HttpContext.Session.GetInt32("adminId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "Admin");
            }
            var kampanyalar = _context.UrunKampanyalars.Where(p => p.Aktiflik == true).OrderByDescending(p => p.KapmanyaId).Select(p => new KampanyaModel
            {
                _KampanyaId = p.KapmanyaId,
                _Aktiflik = p.Aktiflik,
                _BaslangicTarihi = p.BaslangicTarihi,
                _BitisTarihi = p.BitisTarihi,
                _IndirimMiktari = p.IndirimMiktari,
                _KampanyaAciklama = p.KampanyaAciklama,
                _KampanyaBaslik = p.KampanyaBaslik,
                _UrunId = p.UrunId,
                _UrunAd = p.Urun.UrunAd
            }).ToList();



            return View(kampanyalar);
        }
        [HttpGet]
        public ActionResult UrunKampanyaEkle()
        {

            List<SelectListItem> urn = (from urun in _context.Uruns.Where(p => p.Aktiflik == true).ToList()
                                        select new SelectListItem
                                        {
                                            Text = urun.UrunAd,
                                            Value = urun.UrunId.ToString()
                                        }).ToList();
            ViewBag.Urn = urn;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UrunKampanyaEkle(UrunKampanyalar _kampanya)
        {
            int? id = HttpContext.Session.GetInt32("adminId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "Admin");
            }
            _context.UrunKampanyalars.Add(new DB.Models.UrunKampanyalar
            {
                Aktiflik = true,
                BaslangicTarihi = _kampanya.BaslangicTarihi,
                BitisTarihi = _kampanya.BitisTarihi,
                IndirimMiktari = _kampanya.IndirimMiktari,
                KampanyaAciklama = _kampanya.KampanyaAciklama,
                KampanyaBaslik = _kampanya.KampanyaBaslik,
                KapmanyaId = _kampanya.KapmanyaId,
                UrunId = _kampanya.UrunId
            });
            _context.SaveChanges();
            return RedirectToAction("UrunKampanyalar", "Kampanya");
        }
        public ActionResult UrunKampanyaDetay(int kampanyaId)
        {
            int? id = HttpContext.Session.GetInt32("adminId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "Admin");
            }
            var kampanya = _context.UrunKampanyalars.Where(p => p.Aktiflik == true).OrderByDescending(p => p.KapmanyaId).Select(p => new KampanyaModel
            {
                _KampanyaId = p.KapmanyaId,
                _Aktiflik = p.Aktiflik,
                _BaslangicTarihi = p.BaslangicTarihi,
                _BitisTarihi = p.BitisTarihi,
                _IndirimMiktari = p.IndirimMiktari,
                _KampanyaAciklama = p.KampanyaAciklama,
                _KampanyaBaslik = p.KampanyaBaslik,
                _UrunId = p.UrunId,
                _UrunAd = p.Urun.UrunAd
            }).FirstOrDefault();
            return View(kampanya);
        }
        public ActionResult UrunKampanyaBitir(int kampanyaId)
        {
            int? id = HttpContext.Session.GetInt32("adminId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "Admin");
            }
            _context.UrunKampanyalars.Find(kampanyaId).Aktiflik = false;
            _context.SaveChanges();
            return RedirectToAction("UrunKampanyalar", "Kampanya");
        }
        [HttpGet]
        public ActionResult UrunKampanyaUzat(int kampanyaId)
        {
            int? id = HttpContext.Session.GetInt32("adminId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "Admin");
            }
            var kampanya = _context.UrunKampanyalars.Find(kampanyaId);
            ViewBag.BaslangicTarih = kampanya.BaslangicTarihi;
            ViewBag.Id = kampanya.KapmanyaId;
            ViewBag.Ad = kampanya.KampanyaBaslik;
            ViewBag.EskiBitis = kampanya.BitisTarihi;



            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UrunKampanyaUzat(int kampanyaId, DateTime tarih)
        {
            int? id = HttpContext.Session.GetInt32("adminId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "Admin");
            }
            _context.UrunKampanyalars.Find(kampanyaId).Aktiflik = false;
            _context.SaveChanges();

            return RedirectToAction("UrunKampanyalar", "Kampanya");
        }

        public ActionResult FirmaKampanyalar()
        {
            int? id = HttpContext.Session.GetInt32("adminId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "Admin");
            }
            var kampanyalar = _context.FirmaKampanyalars.Where(p => p.Aktiflik == true).OrderByDescending(p => p.KampanyaId).Select(p => new KampanyaModel
            {
                _KampanyaId = p.KampanyaId,
                _Aktiflik = p.Aktiflik,
                _BaslangicTarihi = p.BaslangicTarihi,
                _BitisTarihi = p.BitisTarihi,
                _IndirimMiktari = p.IndirimMiktari,
                _KampanyaAciklama = p.KampanyaAciklama,
                _KampanyaBaslik = p.KampanyaBaslik,
                _FirmaId = p.FirmaId,
                _FirmaAd = p.Firma.FirmaAd
            }).ToList();
            return View(kampanyalar);
        }
        [HttpGet]
        public ActionResult FirmaKampanyaEkle()
        {
            int? id = HttpContext.Session.GetInt32("adminId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "Admin");
            }
            List<SelectListItem> frm = (from firma in _context.Firmas.Where(p => p.Aktiflik == true).ToList()
                                        select new SelectListItem
                                        {
                                            Text = firma.FirmaAd,
                                            Value = firma.FirmaId.ToString()
                                        }).ToList();
            ViewBag.Frm = frm;



            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FirmaKampanyaEkle(FirmaKampanyalar _kampanya)
        {
            int? id = HttpContext.Session.GetInt32("adminId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "Admin");
            }
            _context.FirmaKampanyalars.Add(new DB.Models.FirmaKampanyalar
            {
                Aktiflik = true,
                BaslangicTarihi = _kampanya.BaslangicTarihi,
                BitisTarihi = _kampanya.BitisTarihi,
                IndirimMiktari = _kampanya.IndirimMiktari,
                KampanyaAciklama = _kampanya.KampanyaAciklama,
                KampanyaBaslik = _kampanya.KampanyaBaslik,
                KampanyaId = _kampanya.KampanyaId
            });
            _context.SaveChanges();

            return RedirectToAction("FirmaKampanyalar", "Kampanya");
        }
        public ActionResult FirmaKampanyaDetay(int kampanyaId)
        {
            int? id = HttpContext.Session.GetInt32("adminId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "Admin");
            }
            var kampanya = _context.FirmaKampanyalars.Where(p => p.KampanyaId == kampanyaId).Select(p => new KampanyaModel
            {
                _KampanyaId = p.KampanyaId,
                _Aktiflik = p.Aktiflik,
                _BaslangicTarihi = p.BaslangicTarihi,
                _BitisTarihi = p.BitisTarihi,
                _IndirimMiktari = p.IndirimMiktari,
                _KampanyaAciklama = p.KampanyaAciklama,
                _KampanyaBaslik = p.KampanyaBaslik,
                _FirmaId = p.FirmaId,
                _FirmaAd = p.Firma.FirmaAd
            }).FirstOrDefault();




            return View(kampanya);
        }
        public ActionResult FirmaKampanyaBitir(int kampanyaId)
        {
            int? id = HttpContext.Session.GetInt32("adminId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "Admin");
            }
            _context.FirmaKampanyalars.Find(kampanyaId).Aktiflik = false;
            _context.SaveChanges();
            return RedirectToAction("FirmaKampanyalar", "Kampanya");
        }
        [HttpGet]
        public ActionResult FirmaKampanyaUzat(int kampanyaId)
        {
            int? id = HttpContext.Session.GetInt32("adminId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "Admin");
            }
            var kampanya = _context.FirmaKampanyalars.Find(kampanyaId);
            ViewBag.BaslangicTarih = kampanya.BaslangicTarihi;
            ViewBag.Id = kampanya.KampanyaId;
            ViewBag.Ad = kampanya.KampanyaBaslik;
            ViewBag.EskiBitis = kampanya.BitisTarihi;

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FirmaKampanyaUzat(int kampanyaId, DateTime tarih)
        {
            int? id = HttpContext.Session.GetInt32("adminId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "Admin");
            }
            _context.FirmaKampanyalars.Find(kampanyaId).BitisTarihi = tarih;
            _context.SaveChanges();
            return RedirectToAction("FirmaKampanyalar", "Kampanya");
        }
        public ActionResult GenelKampanyalar()
        {
            int? id = HttpContext.Session.GetInt32("adminId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "Admin");
            }
            var kampanya = _context.GenelKampanyalars.Where(p => p.Aktiflik == true).OrderByDescending(p => p.KampanyaId).Select(p => new GenelKampanyalar
            {
                KampanyaAciklama = p.KampanyaAciklama,
                IndirimMiktari = p.IndirimMiktari,
                BitisTarihi = p.BitisTarihi,
                BaslangicTarihi = p.BitisTarihi,
                Aktiflik = p.Aktiflik,
                KampanyaBaslik = p.KampanyaBaslik,
                KampanyaId = p.KampanyaId
            }).ToList();

            return View(kampanya);
        }
        public ActionResult GenelKampanyaDetay(int kampanyaId)
        {
            int? id = HttpContext.Session.GetInt32("adminId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "Admin");
            }
            var kampanya = _context.GenelKampanyalars.Find(kampanyaId);

            return View(kampanya);
        }
        public ActionResult GenelKampanyaBitir(int kampanyaId)
        {
            int? id = HttpContext.Session.GetInt32("adminId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "Admin");
            }
            _context.GenelKampanyalars.Find(kampanyaId).Aktiflik = false;
            _context.SaveChanges();
            return RedirectToAction("GenelKampanyalar", "Kampanya");
        }
        [HttpGet]
        public ActionResult GenelKampanyaEkle(int kampanyaId)
        {
            int? id = HttpContext.Session.GetInt32("adminId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "Admin");
            }
            ViewBag.Id = kampanyaId;



            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GenelKampanyaEkle(GenelKampanyalar _kampanya)
        {
            int? id = HttpContext.Session.GetInt32("adminId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "Admin");
            }
            _context.GenelKampanyalars.Add(new DB.Models.GenelKampanyalar
            {
                Aktiflik = true,
                BaslangicTarihi = _kampanya.BaslangicTarihi,
                BitisTarihi = _kampanya.BitisTarihi,
                IndirimMiktari = _kampanya.IndirimMiktari,
                KampanyaAciklama = _kampanya.KampanyaAciklama,
                KampanyaBaslik = _kampanya.KampanyaBaslik
            });
            _context.SaveChanges();
            return RedirectToAction("GenelKampanyalar", "Kampanya");
        }
        [HttpGet]
        public ActionResult GenelKampanyaUzat(int kampanyaId)
        {
            int? id = HttpContext.Session.GetInt32("adminId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "Admin");
            }
            var kampanya = _context.GenelKampanyalars.Find(kampanyaId);
            ViewBag.BaslangicTarih = kampanya.BaslangicTarihi;
            ViewBag.Id = kampanya.KampanyaId;
            ViewBag.Ad = kampanya.KampanyaBaslik;
            ViewBag.EskiBitis = kampanya.BitisTarihi;
            return View();
        }
        [HttpPost]
        public ActionResult GenelKampanyaUzat(int kampanyaId, DateTime tarih)
        {
            int? id = HttpContext.Session.GetInt32("adminId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "Admin");
            }
            _context.GenelKampanyalars.Find(kampanyaId).BitisTarihi = tarih;
            _context.SaveChanges();

            return RedirectToAction("GenelKampanyalar", "Kampanya");
        }
    }
}
