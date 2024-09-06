using DB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SatisPaneli.Models;

namespace SatisPaneli.Controllers
{
    public class OrderController : Controller
    {
        private readonly ILogger<CartController> _logger;
        private readonly Task3RealEcommerceContext _context;

        public OrderController(ILogger<CartController> logger, Task3RealEcommerceContext context)
        {
            _logger = logger;
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Buy(int cartId)
        {
            int? id = HttpContext.Session.GetInt32("userId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "User");
            }
            var user = await _context.Kullanicis.FindAsync(id);
            var lastCard = await _context.Sepets.FindAsync(cartId);
            var order = await _context.Siparislers.OrderByDescending(p => p.SiparisId).FirstOrDefaultAsync(p => p.SepetId == lastCard!.SepetId);
            var items = await _context.SiparisKalemlers.Where(p => p.SiparisId == order!.SiparisId).ToListAsync();
            float? totalPrice = 0;
            foreach (var item in items)
            {
                totalPrice += item.BirimFiyat;
            }

            ViewBag.CartId = cartId;
            ViewBag.UserName = user!.KullaniciAd;
            ViewBag.TotalPrice = totalPrice;
            ViewBag.OrderId = order!.SiparisId;
            var creditCard = await _context.KullaniciKartBilgileris.Where(p => p.Aktiflik == true && p.KullaniciId == id).ToListAsync();

            List<SelectListItem> crd = creditCard.Select(i => new SelectListItem
            {
                Text = i.KartNumarasi,
                Value = i.KartId.ToString()
            }).ToList();

            ViewBag.Crd = crd;


            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Buy(PaymentModel modal)
        {
            int? id = HttpContext.Session.GetInt32("userId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "User");
            }

            await _context.Odemelers.AddAsync(new()
            {
                KullaniciId = id,
                Onay = null,
                Tarih = DateTime.Now,
                KuponKod = modal.CouponCode,
                SiparisId = modal.OrderId,
                Toplamfiyat = modal.TotalPrice

            });
            var cart = await _context.Sepets.FindAsync(modal.CartId);
            var order = await _context.Siparislers.FindAsync(modal.OrderId);
            cart!.Aktiflik = false;
            order!.Onay = false;
            await _context.SaveChangesAsync();

            return RedirectToAction("Orders", "Order");
        }
        public async Task<ActionResult> Orders()
        {
            int? id = HttpContext.Session.GetInt32("userId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "User");
            }
            var lastCard = await _context.Sepets.OrderByDescending(p => p.SepetId).FirstOrDefaultAsync(p => p.KullaniciId == id && p.Aktiflik == true);
            var order = await _context.Siparislers.OrderByDescending(p => p.SiparisId).FirstOrDefaultAsync(p => p.SepetId == lastCard!.SepetId);
            var items = new List<OrderViewModel>();
            bool orderNullability = true;
            bool allowCancel = false;
            if (order is not null)
            {
                orderNullability = false;
                allowCancel = await _context.Satislars.AnyAsync(p => p.SiparisId == order!.SiparisId);
                items = await _context.SiparisKalemlers.Where(p => p.SiparisId == order!.SiparisId).GroupBy(p => p.UrunId).Select(p => new OrderViewModel
                {
                    CategoryName = p.Select(l => l.Urun!.Kategori!.KategoriAd).FirstOrDefault(),
                    CompanyId = p.Select(l => l.Urun!.FirmaId).FirstOrDefault(),
                    CompanyName = p.Select(l => l.Urun!.Firma!.FirmaAd).FirstOrDefault(),
                    Count = p.Count(),
                    Description = p.Select(l => l.Urun!.Aciklama).FirstOrDefault(),
                    Price = p.Select(l => l.Urun!.Fiyat).FirstOrDefault(),
                    ProductId = p.Select(l => l.UrunId).FirstOrDefault(),
                    ProductImage = p.Select(l => l.Urun!.UrunResim).FirstOrDefault(),
                    ProductName = p.Select(l => l.Urun!.UrunAd).FirstOrDefault(),
                    UserId = id,
                    TotalPrice = 0

                }).ToListAsync();
            }
            ViewBag.OrderNull = orderNullability;
            ViewBag.CartId = lastCard!.SepetId;
            ViewBag.Allow = allowCancel;

            return View(items);
        }
        [HttpPost]
        public async Task<ActionResult> CancelOrder(int cartId)
        {
            int? id = HttpContext.Session.GetInt32("userId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "User");
            }

            var lastCard = await _context.Sepets.FindAsync(cartId);
            var order = await _context.Siparislers.FirstOrDefaultAsync(p => p.SepetId == lastCard!.SepetId);
            lastCard!.Aktiflik = false;
            await _context.OnaysızSiparisIptals.AddAsync(new()
            {
                Fiyat = order!.Toplamfiyat,
                KullaniciId = id,
                SiparisId = order.SiparisId,
                Tarih = DateTime.Now
            });

            await _context.SaveChangesAsync();
            return Json(new { success = true, redirectUrl = Url.Action("UserIndex", "User") });
        }
    }
}
