using DB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Newtonsoft.Json.Linq;
using TeknikDestekElemanPaneli.Models;

namespace TeknikDestekElemanPaneli.Controllers
{
    public class MesajController : Controller
    {
        private readonly ILogger<MesajController> _logger;
        private readonly Task3RealEcommerceContext _context;
        public MesajController(ILogger<MesajController> logger, Task3RealEcommerceContext context)
        {
            _logger = logger;
            _context = context;
        }
        public IActionResult MesajIndex()
        {
            int? id = HttpContext.Session.GetInt32("teknikElemanId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "TeknikEleman");
            }
            int admindenGelenMesajSayisi = _context.AdmindenTeknikDestegeMesajs.Where(p => p.OkunduBilgisi == false).Count();



            int kullanicidanGelenMesajSayisi = _context.KullanicidanTeknikDestegeMesajs.Where(p => p.OkunduBilgisi == false).Count();
            int firmadanGelenMesajSayisi = _context.FirmadanTeknikElemanaMesajs.Where(p => p.OkunduBilgisi == false).Count();
            int kargodanGelenMesajSayisi = _context.KargodanTeknikElemanaMesajs.Where(p => p.OkunduBilgisi == false).Count();
            int teknikElemandanGelenMesajSayisi = _context.TeknikElemanlarArasıMesajs.Where(p => (p.AlıcıEleman == id && p.OkunduBilgisi == false)).Count();

            KullaniciGelenMesajModel model = new KullaniciGelenMesajModel
            {
                _kullanicidanGelenMesajSayisi = kargodanGelenMesajSayisi,
                _admindenGelenMesajSayisi = admindenGelenMesajSayisi,
                _firmadanGelenMesajSayisi = firmadanGelenMesajSayisi,
                _kargodanGelenMesajSayisi = kargodanGelenMesajSayisi,
                _teknikElemandanGelenMesajSayisi = teknikElemandanGelenMesajSayisi
            };
            return View(model);
        }
        public ActionResult AdminGelenMesajlar()
        {
            int? id = HttpContext.Session.GetInt32("teknikElemanId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "TeknikEleman");
            }
            var sonMesajlar = _context.AdmindenTeknikDestegeMesajs.GroupBy(p => p.MesajlasmaId).Select(p => p.OrderByDescending(p => p.MesajId).FirstOrDefault()).ToList();


            //var model = sonMesajlar.Select(p => new AdmindenGelenMesajModel
            //{
            //    _AdminAd = p.Admin.AdminAd,
            //    _AdminId = p.AdminId,
            //    _ElemanAd = p.Eleman.ElemanAd,
            //    _ElemanId = p.Eleman.TeknikElemanId,
            //    _Mesaj = p.Mesaj,
            //    _MesajBaslik = p.MesajBaslik,
            //    _MesajId = p.MesajId,
            //    _MesajlasmaId = p.MesajlasmaId,
            //    _OkunduBilgisi = p.OkunduBilgisi,
            //    _Tarih = p.Tarih
            //}).ToList();


            var model = sonMesajlar.Select(p => new AdmindenGelenMesajModel
            {
                _AdminAd = p.Admin != null ? p.Admin.AdminAd : "Admin",
                _AdminId = p.AdminId,
                _ElemanAd = p.Eleman != null ? p.Eleman.ElemanAd : "Sen",
                _ElemanId = id,
                _Mesaj = p.Mesaj,
                _MesajBaslik = p.MesajBaslik,
                _MesajId = p.MesajId,
                _MesajlasmaId = p.MesajlasmaId,
                _OkunduBilgisi = p.OkunduBilgisi,
                _Tarih = p.Tarih
            }).ToList();

            //var model = from p in sonMesajlar
            //            join l in _context.Admins on p.Admin.AdminId equals l.AdminId
            //            select new AdmindenGelenMesajModel
            //            {
            //                _AdminAd = p.Admin.AdminAd,
            //                _AdminId = p.Admin.AdminId,
            //                _ElemanAd = p.Eleman.ElemanAd,
            //                _ElemanId = p.Eleman.TeknikElemanId,
            //                _Mesaj = p.Mesaj,
            //                _MesajBaslik = p.MesajBaslik,
            //                _MesajId = p.MesajId,
            //                _MesajlasmaId = p.MesajlasmaId,
            //                _OkunduBilgisi = p.OkunduBilgisi,
            //                _Tarih = p.Tarih
            //            };
            //var gidenModel = model.ToList();
            return View(model);
        }
        public ActionResult AdmindenGelenMesajlasmaDetay(int mesajId)
        {
            int? id = HttpContext.Session.GetInt32("teknikElemanId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "TeknikEleman");
            }
            int? mesajlasmaId = _context.AdmindenTeknikDestegeMesajs.Find(mesajId).MesajlasmaId;

            var admindenGelenler = from m in _context.AdmindenTeknikDestegeMesajs.Where(p => p.MesajlasmaId == mesajlasmaId)
                                   join l in _context.TeknikElemanlars.Where(p => p.TeknikElemanId == id) on m.ElemanId equals l.TeknikElemanId
                                   where m.MesajlasmaId == mesajlasmaId
                                   select new AdminTeknikMesajModel
                                   {
                                       _AliciAd = l.ElemanAd,
                                       _AliciId = l.TeknikElemanId,
                                       _GondericiAd = m.Admin.AdminAd,
                                       _Mesaj = m.Mesaj,
                                       _GondericiId = m.AdminId,
                                       _MesajBaslik = m.MesajBaslik,
                                       _MesajId = m.MesajId,
                                       _MesajlasmaId = m.MesajlasmaId,
                                       _OkunduBilgisi = m.OkunduBilgisi,
                                       _Tarih = m.Tarih,
                                       _Rol = false
                                   };

            var admineGonderilenler = from k in _context.TeknikdenAdmineMesajs.Where(p => p.MesajlasmaId == mesajlasmaId)
                                      join s in _context.TeknikElemanlars.Where(p => p.TeknikElemanId == id) on k.TeknikId equals s.TeknikElemanId
                                      where k.MesajlasmaId == mesajlasmaId
                                      select new AdminTeknikMesajModel
                                      {
                                          _AliciAd = k.Admin.AdminAd,
                                          _AliciId = k.AdminId,
                                          _GondericiAd = s.ElemanAd,
                                          _GondericiId = s.TeknikElemanId,
                                          _Mesaj = k.Mesaj,
                                          _MesajBaslik = k.MesajBaslik,
                                          _MesajId = k.MesajId,
                                          _MesajlasmaId = k.MesajlasmaId,
                                          _OkunduBilgisi = k.OkunduBilgisi,
                                          _Tarih = k.Tarih,
                                          _Rol = true
                                      };
            List<AdminTeknikMesajModel> model = new List<AdminTeknikMesajModel>();
            model.AddRange(admindenGelenler.Distinct().OrderByDescending(p => p._MesajId).ToList());
            model.AddRange(admineGonderilenler.Distinct().OrderByDescending(p => p._MesajId).ToList());
            model = model.OrderByDescending(p => p._Tarih).ToList();

            //var model = _context.AdmindenTeknikDestegeMesajs.Where(p => p.MesajlasmaId == mesajlasmaId).OrderByDescending(p => p.MesajId).Select(p => new AdmindenGelenMesajModel
            //{
            //    _AdminAd = p.Admin.AdminAd,
            //    _AdminId = p.Admin.AdminId,
            //    _ElemanAd = p.Eleman.ElemanAd,
            //    _Mesaj = p.Mesaj,
            //    _MesajBaslik = p.MesajBaslik,
            //    _ElemanId = p.Eleman.TeknikElemanId,
            //    _MesajId = p.MesajId,
            //    _MesajlasmaId = p.MesajlasmaId,
            //    _OkunduBilgisi = p.OkunduBilgisi,
            //    _Tarih = p.Tarih
            //}).ToList();
            var mesajim = _context.AdmindenTeknikDestegeMesajs.Find(mesajId);

            @ViewBag.ElemanId = mesajim.ElemanId;
            @ViewBag._mesajId = mesajId;
            @ViewBag._mesajlasmaId = mesajim.MesajlasmaId;
            return View(model);
        }
        public ActionResult AdmindenGelenMesajDetay(int mesajId)
        {
            int? id = HttpContext.Session.GetInt32("teknikElemanId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "TeknikEleman");
            }
            var mesaj = _context.AdmindenTeknikDestegeMesajs.Where(p => p.MesajId == mesajId).OrderByDescending(p => p.MesajId).Select(p => new AdmindenGelenMesajModel
            {
                _AdminAd = p.Admin.AdminAd,
                _AdminId = p.Admin.AdminId,
                _ElemanAd = p.Eleman.ElemanAd,
                _ElemanId = p.Eleman.TeknikElemanId,
                _Mesaj = p.Mesaj,
                _MesajBaslik = p.MesajBaslik,
                _MesajId = p.MesajId,
                _MesajlasmaId = p.MesajlasmaId,
                _OkunduBilgisi = p.OkunduBilgisi,
                _Tarih = p.Tarih
            }).FirstOrDefault();

            return View(mesaj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TeknikdenAdmineCevap(TeknikdenAdmineMesaj _mesaj)
        {
            int? id = HttpContext.Session.GetInt32("teknikElemanId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "TeknikEleman");
            }

            _context.TeknikdenAdmineMesajs.Add(new TeknikdenAdmineMesaj
            {
                AdminId = _mesaj.AdminId,
                Aktiflik = true,
                Mesaj = _mesaj.Mesaj,
                MesajBaslik = _mesaj.MesajBaslik,
                MesajlasmaId = _mesaj.MesajlasmaId,
                OkunduBilgisi = false,
                Tarih = DateTime.Now,
                TeknikId = id
            });
            _context.SaveChanges();
            return RedirectToAction("AdmindenGelenMesajlasmaDetay", "Mesaj", new { mesajId = _mesaj.MesajId });
        }
        public ActionResult AdmindenGelenMesajOkunduIsaretle(int mesajId)
        {
            int? id = HttpContext.Session.GetInt32("teknikElemanId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "TeknikEleman");
            }
            var mesaj = _context.AdmindenTeknikDestegeMesajs.Find(mesajId);
            mesaj.OkunduBilgisi = true;
            _context.SaveChanges();
            return RedirectToAction("AdmindenGelenMesajDetay", "Mesaj", new { mesajId = mesajId });
        }
        public ActionResult AdminGelenSonMesajOku(int mesajId)
        {
            int? id = HttpContext.Session.GetInt32("teknikElemanId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "TeknikEleman");
            }
            _context.AdmindenTeknikDestegeMesajs.Find(mesajId).OkunduBilgisi = true;
            _context.SaveChanges();
            return RedirectToAction("AdmindenGelenMesajlasmaDetay", "Mesaj", new { mesajId = mesajId });
        }
        public ActionResult KullaniciGelenMesajlar()
        {
            int? id = HttpContext.Session.GetInt32("teknikElemanId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "TeknikEleman");
            }

            var sonMesajlar = _context.KullanicidanTeknikDestegeMesajs.Include(p => p.Kullanici).GroupBy(p => p.MesajlasmaId).Select(p => p.OrderByDescending(p => p.MesajId).FirstOrDefault()).ToList();

            var gidenModel = sonMesajlar.Select(p => new AdmindenGelenMesajModel
            {
                _AdminAd = p.Kullanici.KullaniciAd,
                _AdminId = p.Kullanici.KullaniciId,

                _Mesaj = p.Mesaj,
                _MesajBaslik = p.MesajBaslik,
                _MesajId = p.MesajId,
                _MesajlasmaId = p.MesajlasmaId,
                _OkunduBilgisi = p.OkunduBilgisi,
                _Tarih = p.Tarih


            }).ToList();

            return View(gidenModel);
        }
        public ActionResult KullanicidanGelenMesajlasmaDetay(int mesajId)
        {
            int? id = HttpContext.Session.GetInt32("teknikElemanId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "TeknikEleman");
            }
            var mesajlama = _context.KullanicidanTeknikDestegeMesajs.Find(mesajId);

            var kullanicdanGelenler = _context.KullanicidanTeknikDestegeMesajs.Where(p => (p.KullaniciId == mesajlama.KullaniciId && p.TeknikElemanId == id && p.MesajlasmaId == mesajlama.MesajlasmaId)).OrderByDescending(p => p.MesajId).Select(p => new AdminTeknikMesajModel
            {
                _AliciAd = p.TeknikEleman.ElemanAd,
                _AliciId = p.TeknikElemanId,
                _GondericiAd = p.Kullanici.KullaniciAd,
                _GondericiId = p.KullaniciId,
                _Rol = false,
                _Mesaj = p.Mesaj,
                _MesajBaslik = p.MesajBaslik,
                _MesajId = p.MesajId,
                _MesajlasmaId = p.MesajlasmaId,
                _OkunduBilgisi = p.OkunduBilgisi,
                _Tarih = p.Tarih
            }).ToList();

            var teknikdenGidenler = _context.TeknikdenKullaniciyaMesajs.Where(p => (p.KullaniciId == mesajlama.KullaniciId && p.TeknikId == id && p.MesajlasmaId == mesajlama.MesajlasmaId)).OrderByDescending(p => p.MesajId).Select(p => new AdminTeknikMesajModel
            {
                _AliciAd = p.Kullanici.KullaniciAd,
                _AliciId = p.KullaniciId,
                _Rol = true,
                _GondericiAd = p.Teknik.ElemanAd,
                _GondericiId = p.TeknikId,
                _Mesaj = p.Mesaj,
                _MesajBaslik = p.MesajBaslik,
                _MesajId = p.MesajId,
                _MesajlasmaId = p.MesajlasmaId,
                _OkunduBilgisi = p.OkunduBilgisi,
                _Tarih = p.Tarih
            }).ToList();
            kullanicdanGelenler.AddRange(teknikdenGidenler);
            List<AdminTeknikMesajModel> model = new List<AdminTeknikMesajModel>();
            model = kullanicdanGelenler.OrderByDescending(p => p._Tarih).ToList();
            @ViewBag.KullaniciId = mesajlama.KullaniciId;
            @ViewBag._mesajId = mesajId;
            @ViewBag._mesajlasmaId = mesajlama.MesajlasmaId;
            return View(model);
        }
        public ActionResult KullanicidanGelenSonMesajOku(int mesajId)
        {
            int? id = HttpContext.Session.GetInt32("teknikElemanId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "TeknikEleman");
            }
            _context.KullanicidanTeknikDestegeMesajs.Find(mesajId).Aktiflik = false;
            _context.SaveChanges();


            return RedirectToAction("KullaniciGelenMesajlar", "Mesaj");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TeknikdenKullaniciyaCevap(TeknikdenKullaniciyaMesaj _mesaj)
        {
            int? id = HttpContext.Session.GetInt32("teknikElemanId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "TeknikEleman");
            }
            _context.TeknikdenKullaniciyaMesajs.Add(new TeknikdenKullaniciyaMesaj
            {
                Aktiflik = true,
                OkunduBilgisi = false,
                Mesaj = _mesaj.Mesaj,
                MesajBaslik = _mesaj.MesajBaslik,
                KullaniciId = _mesaj.KullaniciId,
                MesajlasmaId = _mesaj.MesajlasmaId,
                Tarih = DateTime.Now,
                TeknikId = id
            });
            _context.SaveChanges();

            return RedirectToAction("KullanicidanGelenMesajlasmaDetay", "Mesaj", new { mesajId = _mesaj.MesajId });
        }
        public ActionResult KullanicidanGelenMesajDetay(int mesajId)
        {
            int? id = HttpContext.Session.GetInt32("teknikElemanId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "TeknikEleman");
            }
            var mesajDetay = _context.KullanicidanTeknikDestegeMesajs.Where(p => p.MesajId == mesajId).Select(p => new AdmindenGelenMesajModel
            {
                _AdminAd = p.Kullanici.KullaniciAd,
                _AdminId = p.KullaniciId,
                _ElemanAd = p.TeknikEleman.ElemanAd,
                _MesajBaslik = p.MesajBaslik,
                _ElemanId = p.TeknikElemanId,
                _Mesaj = p.Mesaj,
                _MesajId = p.MesajId,
                _MesajlasmaId = p.MesajlasmaId,
                _OkunduBilgisi = p.OkunduBilgisi,
                _Tarih = p.Tarih,

            }).FirstOrDefault();
            return View(mesajDetay);
        }
        public ActionResult KullanicidanGelenMesajOkunduIsaretle(int mesajId)
        {
            int? id = HttpContext.Session.GetInt32("teknikElemanId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "TeknikEleman");
            }
            _context.KullanicidanTeknikDestegeMesajs.Find(mesajId).OkunduBilgisi = true;
            _context.SaveChanges();
            return RedirectToAction("KullanicidanGelenMesajlasmaDetay", "Mesaj", new { mesajId = mesajId });
        }
        public ActionResult SaticiFirmaGelenMesajlar()
        {
            int? id = HttpContext.Session.GetInt32("teknikElemanId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "TeknikEleman");
            }
            var sonmesajlar = _context.FirmadanTeknikElemanaMesajs.Include(p => p.Firma).GroupBy(p => p.MesajlasmaId).Select(p => p.OrderByDescending(p => p.MesajId).FirstOrDefault()).ToList().Select(p => new SaticidanTeknikeMesajModel
            {
                MesajId = p.MesajId,
                Aktiflik = p.Aktiflik,
                FirmaAd = p.Firma.FirmaAd,
                FirmaId = p.FirmaId,
                Mesaj = p.Mesaj,
                MesajBaslik = p.MesajBaslik,
                MesajlasmaId = p.MesajlasmaId,
                OkunduBilgisi = p.OkunduBilgisi,
                Tarih = p.Tarih,
                TeknikElemanId = p.TeknikElemanId
            }).ToList();
            return View(sonmesajlar);
        }
        public ActionResult SaticidanGelenMesajlasmaDetay(int mesajId)
        {
            int? id = HttpContext.Session.GetInt32("teknikElemanId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "TeknikEleman");
            }
            var mesaj = _context.FirmadanTeknikElemanaMesajs.Find(mesajId);

            var gelenler = _context.FirmadanTeknikElemanaMesajs.Include(p => p.Firma).Include(p => p.TeknikEleman).Where(p => (p.TeknikElemanId == id && p.MesajlasmaId == mesaj.MesajlasmaId && p.FirmaId == mesaj.FirmaId)).OrderByDescending(p => p.MesajlasmaId).Select(p => new SaticidanTeknikeMesajModel
            {
                Aktiflik = p.Aktiflik,
                FirmaAd = p.Firma.FirmaAd,
                FirmaId = p.FirmaId,
                Mesaj = p.Mesaj,
                MesajBaslik = p.MesajBaslik,
                MesajId = p.MesajId,
                MesajlasmaId = p.MesajlasmaId,
                OkunduBilgisi = p.OkunduBilgisi,
                Tarih = p.Tarih,
                TeknikElemanId = p.TeknikElemanId,
                Role = false
            }).ToList();


            var gidenler = _context.TeknikdenFirmayaMesajs.Include(p => p.Teknik).Include(p => p.Firma).Where(p => (p.TeknikId == id && p.MesajlasmaId == mesaj.MesajlasmaId && p.FirmaId == mesaj.FirmaId)).OrderByDescending(p => p.MesajId).Select(p => new SaticidanTeknikeMesajModel
            {
                Aktiflik = p.Aktiflik,
                MesajId = p.MesajId,
                FirmaId = p.FirmaId,
                FirmaAd = p.Firma.FirmaAd,
                Mesaj = p.Mesaj,
                MesajBaslik = p.MesajBaslik,
                MesajlasmaId = p.MesajlasmaId,
                OkunduBilgisi = p.OkunduBilgisi,
                Tarih = p.Tarih,
                TeknikElemanId = p.TeknikId,
                Role = true
            }).ToList();



            gelenler.AddRange(gidenler);
            List<SaticidanTeknikeMesajModel> model = new List<SaticidanTeknikeMesajModel>();
            model = gelenler.OrderByDescending(p => p.Tarih).ToList();

            ViewBag.FirmaId = mesaj.FirmaId;
            ViewBag.MesajId = mesajId;
            ViewBag.MesajlamaId = mesaj.MesajlasmaId;
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TeknikdenSaticiyaCevap(TeknikdenFirmayaMesaj _mesaj)
        {
            int? id = HttpContext.Session.GetInt32("teknikElemanId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "TeknikEleman");
            }
            _context.TeknikdenFirmayaMesajs.Add(new TeknikdenFirmayaMesaj
            {

                Aktiflik = true,
                FirmaId = _mesaj.FirmaId,
                Mesaj = _mesaj.Mesaj,
                MesajBaslik = _mesaj.MesajBaslik,
                MesajlasmaId = _mesaj.MesajlasmaId,
                OkunduBilgisi = false,
                Tarih = DateTime.Now,
                TeknikId = id
            });
            _context.SaveChanges();

            return RedirectToAction("SaticidanGelenMesajlasmaDetay", "Mesaj", new { mesajId = _mesaj.MesajId });
        }
        public ActionResult SaticidanGelenMesajDetay(int mesajId)
        {
            int? id = HttpContext.Session.GetInt32("teknikElemanId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "TeknikEleman");
            }

            var model = _context.FirmadanTeknikElemanaMesajs.Include(p => p.Firma).Where(p => (p.MesajId == mesajId)).Select(p => new SaticidanTeknikeMesajModel
            {
                FirmaId = p.FirmaId,
                Mesaj = p.Mesaj,
                MesajBaslik = p.MesajBaslik,
                Tarih = p.Tarih,
                FirmaAd = p.Firma.FirmaAd,
                OkunduBilgisi = p.OkunduBilgisi,
                MesajId = p.MesajId
            }).FirstOrDefault();


            return View(model);
        }
        public ActionResult SaticidanGelenMesajOkunduIsaretle(int mesajId)
        {
            int? id = HttpContext.Session.GetInt32("teknikElemanId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "TeknikEleman");
            }
            _context.FirmadanTeknikElemanaMesajs.Find(mesajId).OkunduBilgisi = true;
            _context.SaveChanges();
            return RedirectToAction("SaticidanGelenMesajlasmaDetay", "Mesaj", new { mesajId = mesajId });
        }
        public ActionResult SaticidanGelenSonMesajOku(int mesajId)
        {
            int? id = HttpContext.Session.GetInt32("teknikElemanId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "TeknikEleman");
            }
            _context.FirmadanTeknikElemanaMesajs.Find(mesajId).OkunduBilgisi = true;
            _context.SaveChanges();
            return RedirectToAction("SaticidanGelenMesajlasmaDetay", "Mesaj", new { mesajId = mesajId });

        }

    }
}
