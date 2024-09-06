using DB.Models;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using SatisPaneli.Models;

namespace SatisPaneli.Controllers
{
    public class CartController : Controller
    {
        private readonly ILogger<CartController> _logger;
        private readonly Task3RealEcommerceContext _context;

        public CartController(ILogger<CartController> logger, Task3RealEcommerceContext context)
        {
            _logger = logger;
            _context = context;
        }
        public void CreateVisitorId()
        {
            var visitorId = Request.Cookies["VisitorId"];
            if (string.IsNullOrEmpty(visitorId))
            {
                visitorId = Guid.NewGuid().ToString();

                CookieOptions options = new CookieOptions()
                {
                    Expires = DateTime.UtcNow.AddYears(1),
                    HttpOnly = true,
                    IsEssential = true
                };
                Response.Cookies.Append("VisitorId", visitorId, options);
            }
        }
        [HttpPost]
        public ActionResult AddProductToCart(int productId)
        {
            CreateVisitorId();
            var visitorId = Request.Cookies["VisitorId"];

            var cart = Request.Cookies["Cart_" + visitorId];
            Dictionary<int, int> cartItems;

            if (string.IsNullOrEmpty(cart))
            {
                cartItems = new Dictionary<int, int>();
            }
            else
            {
                cartItems = JsonConvert.DeserializeObject<Dictionary<int, int>>(cart)!;
            }

            if (cartItems.ContainsKey(productId))
            {
                cartItems[productId]++;
            }
            else
            {
                cartItems.Add(productId, 1);
            }

            CookieOptions options = new CookieOptions()
            {
                Expires = DateTime.UtcNow.AddYears(1)
            };

            Response.Cookies.Append("Cart_" + visitorId, JsonConvert.SerializeObject(cartItems), options);

            return Json(new { success = true });
        }

        public JsonResult TotalCartItems()
        {

            int productCount = 0;
            CreateVisitorId();
            var visitorId = Request.Cookies["VisitorId"];
            var cart = Request.Cookies["Cart_" + visitorId];

            Dictionary<int, int> cartItems;
            if (string.IsNullOrEmpty(cart))
            {
                productCount = 0;
            }
            else
            {
                cartItems = JsonConvert.DeserializeObject<Dictionary<int, int>>(cart)!;
                if (cartItems is not null)
                {
                    productCount = cartItems.Values.Sum();
                }
                else
                {
                    productCount = 0;
                }
            }
            var result = new { productCount = productCount };

            return Json(result);


        }
        public async Task<JsonResult> UserTotalCardItem()
        {
            int? id = HttpContext.Session.GetInt32("userId");
            var lastCard = await _context.Sepets.OrderByDescending(p => p.SepetId).FirstOrDefaultAsync(p => p.KullaniciId == id && p.Aktiflik == true);
            var order = await _context.Siparislers.OrderByDescending(p => p.SiparisId).FirstOrDefaultAsync(p => p.SepetId == lastCard!.SepetId);
            var items = await _context.SiparisKalemlers.Where(p => p.SiparisId == order!.SiparisId).ToListAsync();
            var result = new { productCount = items.Count() };
            return Json(result);
        }

        public ActionResult ViewCart()
        {
            List<VisitorCartModel> emptyCart = new List<VisitorCartModel>();
            CreateVisitorId();
            var visitorId = Request.Cookies["VisitorId"];
            var cart = Request.Cookies["Cart_" + visitorId];
            Dictionary<int, int> products;
            if (!string.IsNullOrEmpty(cart))
            {
                products = JsonConvert.DeserializeObject<Dictionary<int, int>>(cart)!;
                if (products is not null)
                {
                    var productsList = _context.Uruns.Where(p => products.Keys.Contains(p.UrunId)).Select(p => new VisitorCartModel
                    {
                        CategoryName = p.Kategori!.KategoriAd,
                        CompanyId = p.FirmaId,
                        CompanyName = p.Firma!.FirmaAd,
                        Price = p.Fiyat,
                        ProductImage = p.UrunResim,
                        ProductName = p.UrunAd,
                        ProductId = p.UrunId,
                        Count = products[p.UrunId]
                    }).ToList();

                    return View(productsList);
                }
                else
                {
                    return View(emptyCart);
                }
            }
            else
            {
                return View(emptyCart);
            }
        }
        [HttpPost]
        public ActionResult DeleteProductFromCart(int productId)
        {
            CreateVisitorId();
            var visitorId = Request.Cookies["visitorId"];
            var cart = Request.Cookies["Cart_" + visitorId];
            Dictionary<int, int> products;
            products = JsonConvert.DeserializeObject<Dictionary<int, int>>(cart!)!;
            if (products[productId] == 1)
            {
                products.Remove(productId);
            }
            else
            {
                products[productId]--;
            }
            CookieOptions options = new CookieOptions()
            {
                Expires = DateTime.UtcNow.AddYears(1)
            };
            Response.Cookies.Append("Cart_" + visitorId, JsonConvert.SerializeObject(products), options);

            return Json(new { success = true });
        }

        public ActionResult DeleteCart()
        {
            CreateVisitorId();
            var visitorId = Request.Cookies["visitorId"];

            Response.Cookies.Delete("Cart_" + visitorId, new CookieOptions { Path = "/" });

            return RedirectToAction("VisitorIndex", "Home");
        }
        public async Task<ActionResult> ViewUserCart()
        {
            int? id = HttpContext.Session.GetInt32("userId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "User");
            }
            var user = await _context.Kullanicis.FindAsync(id);
            var lastCard = await _context.Sepets.OrderByDescending(p => p.SepetId).FirstOrDefaultAsync(p => p.KullaniciId == id && p.Aktiflik == true);
            var order = await _context.Siparislers.OrderByDescending(p => p.SiparisId).FirstOrDefaultAsync(p => p.SepetId == lastCard!.SepetId);
            var items = await _context.SiparisKalemlers.Where(p => p.SiparisId == order!.SiparisId).GroupBy(p => p.UrunId).Select(p => new ViewUserCartModel
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
                UserName = user!.KullaniciAd,
                TotalPrice = 0

            }).ToListAsync();
            ViewBag.CartId = lastCard!.SepetId;

            return View(items);
        }
        [HttpPost]
        public async Task<ActionResult> AddProductUserCard(int productId)
        {
            int? id = HttpContext.Session.GetInt32("userId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "User");
            }
            var lastCard = await _context.Sepets.OrderByDescending(p => p.SepetId).FirstOrDefaultAsync(p => p.KullaniciId == id && p.Aktiflik == null);
            var order = await _context.Siparislers.OrderByDescending(p => p.SiparisId).FirstOrDefaultAsync(p => p.SepetId == lastCard!.SepetId);
            var product = await _context.Uruns.FindAsync(productId);
            await _context.SiparisKalemlers.AddAsync(new()
            {
                Miktar = 1,
                BirimFiyat = product!.Fiyat,
                SiparisId = order!.SiparisId,
                UrunId = productId
            });
            await _context.SaveChangesAsync();

            return Json(new { success = true });
        }
        [HttpPost]
        public async Task<ActionResult> DeleteProductFromUserCart(int productId)
        {
            int? id = HttpContext.Session.GetInt32("userId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "User");
            }
            var lastCard = await _context.Sepets.OrderByDescending(p => p.SepetId).FirstOrDefaultAsync(p => p.KullaniciId == id && p.Aktiflik == true);
            var order = await _context.Siparislers.OrderByDescending(p => p.SiparisId).FirstOrDefaultAsync(p => p.SepetId == lastCard!.SepetId);
            var orderItem = await _context.SiparisKalemlers.OrderByDescending(p => p.SiparisId).FirstOrDefaultAsync(p => p.UrunId == productId);

            _context.SiparisKalemlers.Remove(orderItem!);
            await _context.SaveChangesAsync();
            return Json(new { success = true });
        }
        [HttpPost]
        public async Task<ActionResult> DeleteUserCard(int cartId)
        {
            int? id = HttpContext.Session.GetInt32("userId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "User");
            }

            var card = await _context.Sepets.FindAsync(cartId);

            var items = await _context.SiparisKalemlers.Where(p => p.Siparis!.SepetId == card!.SepetId).ToListAsync();
            foreach (var item in items)
            {
                _context.SiparisKalemlers.Remove(item);
            }
            card!.Aktiflik = false;

            await _context.SaveChangesAsync();

            return Json(new { success = true });
        }

    }
}
