using AdminPaneli.Models;
using DB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Operations;
using Microsoft.EntityFrameworkCore;

namespace AdminPaneli.Controllers
{
    public class CekilisController : Controller
    {
        private readonly ILogger<CekilisController> _logger;
        private readonly Task3RealEcommerceContext _context;

        public CekilisController(ILogger<CekilisController> logger, Task3RealEcommerceContext context)
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
            var cekilisListe = _context.Cekilis.Where(p => p.Aktiflik == true).OrderByDescending(p => p.CekilisId).Select(p => new Cekili
            {
                Aktiflik = p.Aktiflik,
                CekilisId = p.CekilisId,
                BaslangicTarih = p.BaslangicTarih,
                BitisTarih = p.BitisTarih,
                CekilisAciklama = p.CekilisAciklama,
                CekilisAd = p.CekilisAd
            }).ToList();
            return View(cekilisListe);
        }
        public ActionResult CekilisDetay(int cekilisId)
        {
            int? id = HttpContext.Session.GetInt32("adminId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "Admin");

            }
            var detay = _context.Cekilis.Where(p => p.CekilisId == cekilisId).OrderByDescending(p => p.CekilisId).Select(p => new Cekili
            {
                Aktiflik = p.Aktiflik,
                CekilisId = p.CekilisId,
                BaslangicTarih = p.BaslangicTarih,
                BitisTarih = p.BitisTarih,
                CekilisAciklama = p.CekilisAciklama,
                CekilisAd = p.CekilisAd
            }).FirstOrDefault();


            return View(detay);
        }
        public ActionResult CekilisBitir(int cekilisId)
        {
            int? id = HttpContext.Session.GetInt32("adminId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "Admin");

            }
            _context.Cekilis.Find(cekilisId).Aktiflik = false;
            _context.SaveChanges();

            return RedirectToAction("Index", "Cekilis");
        }
        [HttpGet]
        public ActionResult CekilisEkle()
        {


            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CekilisEkle(Cekili cekilis)
        {
            int? id = HttpContext.Session.GetInt32("adminId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "Admin");

            }
            _context.Cekilis.Add(new Cekili
            {
                Aktiflik = true,
                BaslangicTarih = cekilis.BaslangicTarih,
                BitisTarih = cekilis.BitisTarih,
                CekilisAciklama = cekilis.CekilisAciklama,
                CekilisAd = cekilis.CekilisAd
            });
            _context.SaveChanges();

            return RedirectToAction("Index", "Cekilis");
        }
        [HttpGet]
        public ActionResult CekilisUzat(int cekilisId)
        {
            int? id = HttpContext.Session.GetInt32("adminId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "Admin");

            }
            var cekilis = _context.Cekilis.Find(cekilisId);
            ViewBag.Ad = cekilis.CekilisAd;
            ViewBag.Baslangic = cekilis.BaslangicTarih;
            ViewBag.EskiBitis = cekilis.BitisTarih;
            ViewBag.Id = cekilisId;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CekilisUzat(int cekilisId, DateTime tarih)
        {
            int? id = HttpContext.Session.GetInt32("adminId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "Admin");
            }
            var cekilis = _context.Cekilis.Find(cekilisId);
            cekilis.BitisTarih = tarih;
            _context.SaveChanges();
            return RedirectToAction("Index", "Cekilis");
        }
        public ActionResult CekiliseKatilanlar(int cekilisId)
        {
            int? id = HttpContext.Session.GetInt32("adminId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "Admin");
            }
            var cekiliseKatilanlar = _context.CekiliseKatılanlars.Select(p => new CekilisKatilimModel
            {
                _CekilisAd = p.Cekilis.CekilisAd,
                _CekilisId = p.CekilisId,
                _KatilimId = p.KatilimId,
                _KatilimTarihi = p.KatilimTarihi,
                _KullaniciAd = p.Kullanici.KullaniciAd,
                _KullaniciId = p.KatilimId
            }).ToList();
            ViewBag.CekilisId = cekilisId;
            return View(cekiliseKatilanlar);
        }
        public ActionResult CekilisKazananlar(int cekilisId)
        {
            int? id = HttpContext.Session.GetInt32("adminId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "Admin");
            }
            var katilimciIdler = _context.CekiliseKatılanlars.Where(p => p.CekilisId == cekilisId).Select(p => p.KatilimId).ToList();

            int katilimciSayisi = katilimciIdler.Count();
            int enBuyukId = katilimciIdler.Max();
            int enKucukId = katilimciIdler.Min();
            List<int> kazananlar = new List<int>();
            Random random1 = new Random();

            while (kazananlar.Count < 5 && katilimciIdler.Count > 0)
            {
                int deger = random1.Next(enKucukId, enBuyukId + 1);
                if (katilimciIdler.Contains(deger) && !kazananlar.Contains(deger))
                {
                    kazananlar.Add(deger);
                }
            }

            List<CekilisKatilimModel> sonModel = new List<CekilisKatilimModel>();
            foreach (int item in kazananlar)
            {
                var katilimci = _context.CekiliseKatılanlars.Include(k => k.Kullanici).Include(k => k.Cekilis).FirstOrDefault(p => p.KatilimId == item);
                if (katilimci != null)
                {
                    string ad = katilimci.Kullanici.KullaniciAd;
                    string cekilisAd = katilimci.Cekilis.CekilisAd;

                    _context.CekilisKazananlars.Add(new DB.Models.CekilisKazananlar
                    {
                        CekilisId = cekilisId,
                        KazanmaTarihi = DateTime.Now,
                        KullaniciId = katilimci.KullaniciId
                    });
                    _context.SaveChanges();

                    sonModel.Add(new CekilisKatilimModel
                    {
                        _CekilisAd = cekilisAd,
                        _CekilisId = cekilisId,
                        _KatilimTarihi = DateTime.Now,
                        _KullaniciId = item,
                        _KullaniciAd = ad
                    });
                }
            }
            //var katilimciIdler = _context.CekiliseKatılanlars.Where(p => p.CekilisId == cekilisId).Select(p => new { katilimciId = p.KatilimId }).ToList();
            //int katilimciSayisi = katilimciIdler.Count();
            //int enBuyukId = katilimciIdler.Max(p => p.katilimciId);
            //int enKucukId = katilimciIdler.Min(p => p.katilimciId);
            //List<int> kazananlar = new List<int>();
            //Random random1 = new Random();
            //int sayac = 0;
            //while (sayac < 5)
            //{
            //    int deger = random1.Next(enKucukId, enBuyukId + 1);
            //    foreach (var _id in katilimciIdler)
            //    {
            //        if (_id.katilimciId == deger)
            //        {
            //            kazananlar.Add(deger);
            //            sayac++;
            //        }
            //    }
            //}
            //List<CekilisKatilimModel> sonModel = new List<CekilisKatilimModel>();
            //foreach (int item in kazananlar)
            //{
            //    foreach (var _id in katilimciIdler)
            //    {
            //        if (item == _id.katilimciId)
            //        {
            //            var katilimci = _context.CekiliseKatılanlars.Find(cekilisId);
            //            string ad = katilimci.Kullanici.KullaniciAd
            //            string cekilisAd = katilimci.Cekilis.CekilisAd;
            //            _context.CekilisKazananlars.Add(new DB.Models.CekilisKazananlar
            //            {
            //                CekilisId = cekilisId,
            //                KazanmaTarihi = DateTime.Now,
            //                KullaniciId = _id.katilimciId
            //            });
            //            _context.SaveChanges();
            //            sonModel.Add(new CekilisKatilimModel
            //            {
            //                _CekilisAd = cekilisAd,
            //                _CekilisId = cekilisId,
            //                _KatilimTarihi = DateTime.Now,
            //                _KullaniciId = _id.katilimciId,
            //                _KullaniciAd = ad
            //            });
            //        }
            //    }
            //}

            return View(sonModel);
        }
    }
}
