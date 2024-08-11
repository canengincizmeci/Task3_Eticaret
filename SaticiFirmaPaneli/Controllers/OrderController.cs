using DB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using SaticiFirmaPaneli.Models;

namespace SaticiFirmaPaneli.Controllers
{
    public class OrderController : Controller
    {
        private readonly ILogger<OrderController> _logger;
        private readonly Task3RealEcommerceContext _context;

        public OrderController(ILogger<OrderController> logger, Task3RealEcommerceContext context)
        {
            _logger = logger;
            _context = context;
        }
        public async Task<ActionResult> Orders()
        {
            int? id = HttpContext.Session.GetInt32("sellerCompanyId");
            if (!id.HasValue)
                return RedirectToAction("Login", "SellerCompany");

            var modal = await _context.Siparislers.Where(p => (p.Onay == null && p.SiparisKalemlers.Any(p => p.Urun.FirmaId == id))).Select(p => new NewOrdersModel
            {
                BillingAddress = p.FaturaAdresi,
                Confirmation = p.Onay,
                CouponCode = p.KuponKod,
                OrderId = p.SiparisId,
                ShippingAddress = p.GonderiAdresi,
                ShippingStatus = p.KargoDurumu,
                TotalPrice = p.Toplamfiyat,
                UserId = p.KullaniciId,
                ShoppingCartId = p.SepetId,
                ProductNames = p.SiparisKalemlers.Select(l => l.Urun.UrunAd).ToList(),
                UserName = p.Kullanici.KullaniciAd
            }).ToListAsync();

            return View(modal);
        }
        public async Task<ActionResult> ApproveSale(int orderId)
        {
            int? id = HttpContext.Session.GetInt32("sellerCompanyId");
            if (!id.HasValue)
                return RedirectToAction("Login", "SellerCompany");
            var order = await _context.Siparislers.FindAsync(orderId);
            if (order == null)
            {
                return Json(new { success = false });
            }
            else
            {
                order.Onay = true;
                await _context.Satislars.AddAsync(new Satislar
                {
                    FaturaAdresi = order.FaturaAdresi,
                    FirmaId = id,
                    GonderiAdresi = order.GonderiAdresi,
                    KullaniciId = order.KullaniciId,
                    SiparisId = orderId,
                    Tarih = DateTime.Now
                });
                var firma = await _context.Firmas.FindAsync(id);
                firma.SatisSayisi++;
                decimal totalPrice = Convert.ToDecimal(order.Toplamfiyat * 0.1);
                int earnedPoint = (int)Math.Floor(totalPrice);
                firma.Puan += earnedPoint;
                firma.CoinMiktari++;
                List<int> products = order.SiparisKalemlers.Select(p => p.Urun.UrunId).ToList<int>();
                foreach (var productId in products)
                {
                    var product = await _context.Uruns.FindAsync(productId);
                    if (product.Aktiflik == true)
                    {
                        product.SatisSayisi++;
                        product.Stok--;
                    }
                }
                await _context.SaveChangesAsync();
                return Json(new { success = true });
            }

        }
        public ActionResult RejectSale(int orderId)
        {
            int? id = HttpContext.Session.GetInt32("sellerCompanyId");
            if (!id.HasValue)
                return RedirectToAction("Login", "SellerCompany");

            ViewBag.OrderId = orderId;


            return View();
        }
        [HttpPost]
        public async Task<ActionResult> RejectSale(int orderId, string reason)
        {
            int? id = HttpContext.Session.GetInt32("sellerCompanyId");
            if (!id.HasValue)
                return RedirectToAction("Login", "SellerCompany");


            var order = await _context.Siparislers.FindAsync(orderId);
            var company = await _context.Firmas.FindAsync(id);
            company.Puan -= 10;
            order.Onay = false;
            company.CoinMiktari--;
            await _context.ReddedilenSiparislers.AddAsync(new ReddedilenSiparisler
            {
                Fiyat = order.Toplamfiyat,
                Sebep = reason,
                SiparisId = orderId,
                Tarih = DateTime.Now
            });

            await _context.SaveChangesAsync();
            return RedirectToAction("Orders", "Order");

        }
    }
}
