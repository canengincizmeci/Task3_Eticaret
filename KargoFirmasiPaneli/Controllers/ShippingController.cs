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
                ProductsName = p.Satis.Siparis.SiparisKalemlers.Select(l => l.Urun.UrunAd).Distinct().ToList()
            }).ToList();
            return View(model);
        }
    }
}
