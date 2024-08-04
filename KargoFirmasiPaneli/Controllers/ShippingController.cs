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
    }
}
