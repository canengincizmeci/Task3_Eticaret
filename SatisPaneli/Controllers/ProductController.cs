using DB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SatisPaneli.Models;

namespace SatisPaneli.Controllers
{
    public class ProductController : Controller
    {

        private readonly ILogger<ProductController> _logger;
        private readonly Task3RealEcommerceContext _context;

        public ProductController(ILogger<ProductController> logger, Task3RealEcommerceContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> ProductDetails(int productId)
        {
            await _context.UrunGoruntulenmes.AddAsync(new()
            {
                Aktiflik = true,
                GoruntulenmeSayisi = 1,
                UrunId = productId
            });
            await _context.SaveChangesAsync();
            var product = await _context.Uruns.Where(p => (p.Aktiflik == true && p.UrunId == productId)).Select(p => new ProductDetailsModel
            {
                AddingDate = p.EklenmeTarihi,
                CompanyId = p.FirmaId,
                CompanyName = p.Firma!.FirmaAd,
                Description = p.Aciklama,
                Price = p.Fiyat,
                ProductId = p.UrunId,
                ProductImage = p.UrunResim,
                ProductName = p.UrunAd,
                Stock = p.Stok,
                CategoryName = p.Kategori!.KategoriAd
            }).FirstOrDefaultAsync();

            return View(product);
        }
        public async Task<IActionResult> ProductDetailsForUser(int productId)
        {
            await _context.UrunGoruntulenmes.AddAsync(new()
            {
                Aktiflik = true,
                GoruntulenmeSayisi = 1,
                UrunId = productId
            });
            int? id = HttpContext.Session.GetInt32("userId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "User");
            }
            var product = await _context.Uruns.Where(p => (p.Aktiflik == true && p.UrunId == productId)).Select(p => new ProductDetailsModel
            {
                AddingDate = p.EklenmeTarihi,
                CompanyId = p.FirmaId,
                CompanyName = p.Firma!.FirmaAd,
                Description = p.Aciklama,
                Price = p.Fiyat,
                ProductId = p.UrunId,
                ProductImage = p.UrunResim,
                ProductName = p.UrunAd,
                Stock = p.Stok,
                CategoryName = p.Kategori!.KategoriAd
            }).FirstOrDefaultAsync();

            return View(product);
        }

    }
}
