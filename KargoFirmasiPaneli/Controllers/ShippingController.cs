using DB.Models;
using KargoFirmasiPaneli.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KargoFirmasiPaneli.Controllers
{
    public class ShippingController : Controller
    {
        private readonly ILogger<ShippingController> _logger;
        private readonly Task3RealEcommerceContext _context;
        public ShippingController(ILogger<ShippingController> logger, Task3RealEcommerceContext context)
        {
            _logger = logger;
            _context = context;
        }
        public ActionResult RequestedShipments()
        {
            int? id = HttpContext.Session.GetInt32("shippingCompanyId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "ShippingCompany");
            }
            var model = _context.IstenenKargolars.Include(p => p.Satis.Siparis).ThenInclude(p => p.Odemelers).Where(p => (p.Akitflik == true && p.KargoFirmaId == id)).OrderByDescending(p => p.IstekKargoId).Select(p => new RequestedShipmentsModel
            {
                ActivityStatus = p.Akitflik,
                Date = p.Tarih,
                RequestedShipmentId = p.IstekKargoId,
                SalesId = p.SatisId,
                SellerCompanyId = p.SatisiciFirmaId,
                SellerCompanyName = p.SatisiciFirma.FirmaAd,
                ShippingCompanyId = p.KargoFirmaId,
                ShippingCompanyName = p.KargoFirma.KargoFirmaAd,
                ProductsId = p.Satis.Siparis.SiparisKalemlers.Select(m => m.Urun.UrunId).Distinct().ToList(),
                ProductsName = p.Satis.Siparis.SiparisKalemlers.Select(l => l.Urun.UrunAd).Distinct().ToList(),
                ShippingAdress = p.Satis.GonderiAdresi,
                SellerCompanyAdres = p.SatisiciFirma.FirmaAdres
            }).ToList();
            return View(model);
        }
        [HttpPost]
        public ActionResult DispatchShipment(int shipmentId)
        {
            int? id = HttpContext.Session.GetInt32("shippingCompanyId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "ShippingCompany");
            }
            var shipment = _context.IstenenKargolars.Find(shipmentId);
            shipment.Akitflik = false;
            var sales = _context.Satislars.Find(shipment.SatisiciFirmaId);
            string adress = sales.GonderiAdresi;
            _context.SaveChanges();
            _context.KargoBildirimlers.Add(new KargoBildirimler
            {
                Aktiflik = true,
                KargoBildirim = $"{adress} ine ulaştırılmak üzere yola çıktı",
                KargoBildirimBaslik = "Yolda",
                KargoFirmaId = id,
                KullaniciId = sales.FirmaId,
                OkunduBilgisi = false,
                Tarih = DateTime.Now
            });
            _context.SaveChanges();
            return Json(new { success = true });
        }
        public ActionResult ShipmentsInTransit()
        {
            int? id = HttpContext.Session.GetInt32("shippingCompanyId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "ShippingCompany");
            }
            var shipments = _context.KargoBildirimlers.Where(p => (p.KargoBildirimBaslik == "Yolda" && p.Aktiflik == true)).OrderByDescending(p => p.KargoBildirimId).Select(p => new ShippingNotificationsModel
            {
                Aktiflik = p.Aktiflik,
                KargoBildirimBaslik = p.KargoBildirimBaslik,
                KargoBildirim = p.KargoBildirim,
                KargoBildirimId = p.KargoBildirimId,
                KargoFirmaId = p.KargoFirmaId,
                KullaniciAd = p.Kullanici.KullaniciAd,
                KullaniciId = p.KullaniciId,
                OkunduBilgisi = p.OkunduBilgisi,
                Tarih = p.Tarih
            }).ToList();
            return View(shipments);
        }
        [HttpPost]
        public ActionResult CompleteShipmentDispatch(int notificationId)
        {
            int? id = HttpContext.Session.GetInt32("shippingCompanyId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "ShippingCompany");
            }
            var notification = _context.KargoBildirimlers.Find(notificationId);

            notification.Aktiflik = false;
            _context.SaveChanges();
            _context.GonderilenKargolars.Add(new GonderilenKargolar
            {
                AliciId = notification.KullaniciId,
                KargoFirmaId = id,
                Tarih = DateTime.Now,
                TahminiTeslimTarihi = DateTime.Now,
                IadeTalebi = false,
                GonderimTarihi = DateTime.Now
            });
            _context.SaveChanges();
            return Json(new { success = true });
        }
        [HttpPost]
        public ActionResult UpdateCurrentShipmentLocation(int notificationId, string adress)
        {
            int? id = HttpContext.Session.GetInt32("shippingCompanyId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "ShippingCompany");
            }

            _context.KargoBildirimlers.Find(notificationId).KargoBildirim = $"{adress} adresinde yola devam ediyor";
            _context.SaveChanges();

            return Json(new { success = true });
        }
        public async Task<ActionResult> DispatchedShipment()
        {
            int? id = HttpContext.Session.GetInt32("shippingCompanyId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "ShippingCompany");
            }

            var dispatchedShipments = await _context.GonderilenKargolars.OrderByDescending(p => p.IstenenKargoId).Select(p => new DispatchedShipmentsModel
            {
                RecipientId = p.AliciId,
                RequestedShipmentId = p.IstenenKargoId,
                SalerCompanyId = p.FirmaId,
                DestinationAdressId = p.GidisAdresiId,
                DispatchedShipmentId = p.GonderilenKargoId,
                DeliveryDate = p.GonderimTarihi,
                ReturnRequest = p.IadeTalebi,
                ShipmentCompanyId = p.KargoFirmaId,
                ShipmentCompanyBrachId = p.KargoFirmaSubeId,
                DestinationAdressName = p.GidisAdresi.Adres,
                Date = p.TahminiTeslimTarihi,
                RecipientName = p.Alici.KullaniciAd,
                SalerCompanyName = p.Firma.FirmaAd,
                ShipmentDate = p.Tarih
            }).ToListAsync();

            return View(dispatchedShipments);
        }

        public async Task<ActionResult> ReturnsRequests()
        {
            int? id = HttpContext.Session.GetInt32("shippingCompanyId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "ShippingCompany");
            }
            var requests = await _context.IadeTaleps.Where(p => p.Onay == false).Select(p => new ReturnRequestsModel
            {
                ActivityStatus = p.Aktiflik,
                Approval = p.Onay,
                Date = p.Tarih,
                PaymnetId = p.OdemeId,
                Reason = p.Sebep,
                UserId = p.KullaniciId,
                RequestId = p.TalepId,
                CompanyIds = p.Odeme.Siparis.SiparisKalemlers.Select(l => l.Urun.Firma.FirmaId).Distinct().ToList(),
                CompanyNames = p.Odeme.Siparis.SiparisKalemlers.Select(k => k.Urun.Firma.FirmaAd).Distinct().ToList(),
                Adress = p.Odeme.Siparis.GonderiAdresi,
                ProductsId = p.Odeme.Siparis.SiparisKalemlers.Select(n => n.Urun.UrunId).Distinct().ToList(),
                ProductsName = p.Odeme.Siparis.SiparisKalemlers.Select(b => b.Urun.UrunAd).Distinct().ToList()
            }).ToListAsync();
            return View(requests);
        }
        [HttpPost]
        public async Task<ActionResult> ShipAndCompleteReturn(int requestsId)
        {
            int? id = HttpContext.Session.GetInt32("shippingCompanyId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "ShippingCompany");
            }
            var request = await _context.IadeTaleps.FindAsync(requestsId);
            if (request == null)
            {
                return Json(new { success = false });
            }
            request.Onay = true;
            await _context.SaveChangesAsync();
            await _context.KargoBildirimlers.AddAsync(new KargoBildirimler
            {
                Aktiflik = true,
                KargoBildirim = "İade yola çıktı",
                KargoBildirimBaslik = "İade Tamamlandı",
                KargoFirmaId = id,
                KullaniciId = request.KullaniciId,
                OkunduBilgisi = false,
                Tarih = DateTime.Now
            });
            await _context.SaveChangesAsync();
            return Json(new { success = true });
        }
        public async Task<ActionResult> ReturnRequestsInTransit()
        {
            int? id = HttpContext.Session.GetInt32("shippingCompanyId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "ShippingCompany");
            }
            var modal = await _context.YoldaIadeTalebis.Where(p => p.Onay == false).OrderByDescending(p => p.YoldaIadeTalebiId).Select(p => new ReturnRequestsModel
            {
                Approval = p.Onay,
                RequestId = p.YoldaIadeTalebiId,
                CompanyIds = p.GonderilenKargo.IstenenKargo.Satis.Siparis.SiparisKalemlers.Select(l => l.Urun.Firma.FirmaId).ToList(),
                CompanyNames = p.GonderilenKargo.IstenenKargo.Satis.Siparis.SiparisKalemlers.Select(k => k.Urun.Firma.FirmaAd).ToList(),
                ProductsId = p.GonderilenKargo.IstenenKargo.Satis.Siparis.SiparisKalemlers.Select(n => n.Urun.UrunId).ToList(),
                ProductsName = p.GonderilenKargo.IstenenKargo.Satis.Siparis.SiparisKalemlers.Select(i => i.Urun.UrunAd).ToList(),
                Reason = p.IadeAciklama,
                UserId = p.KullaniciId,
                Date = p.Tarih,
                Adress = p.Firma.FirmaAdres,
                CompanyAdress = p.GonderilenKargo.IstenenKargo.Satis.Siparis.SiparisKalemlers.Select(h => h.Urun.Firma.FirmaAdres).ToList()
            }).ToListAsync();
            return View(modal);
        }
        [HttpPost]
        public async Task<ActionResult> StartReturnRequestInTransit(int requestId, int userId)
        {
            int? id = HttpContext.Session.GetInt32("shippingCompanyId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "ShippingCompany");
            }
            var request = await _context.YoldaIadeTalebis.FindAsync(requestId);
            if (request != null)
            {

                await _context.KargoBildirimlers.AddAsync(new KargoBildirimler
                {
                    Aktiflik = true,
                    KargoBildirimBaslik = "Yolda iade başladı",
                    KargoBildirim = "Yolda iade talebiyle işlem başlatılmıştır",
                    KargoFirmaId = id,
                    Tarih = DateTime.Now,
                    OkunduBilgisi = false,
                    KullaniciId = userId
                });

                request.Onay = true;


                await _context.SaveChangesAsync();

                return Json(new { success = true });
            }
            else
            {
                return Json(new { success = false });
            }
        }
    }
}
