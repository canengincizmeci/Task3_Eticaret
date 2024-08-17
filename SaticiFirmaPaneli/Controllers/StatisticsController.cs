using DB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SaticiFirmaPaneli.Models;

namespace SaticiFirmaPaneli.Controllers
{
    public class StatisticsController : Controller
    {
        private readonly ILogger<StatisticsController> _logger;
        private readonly Task3RealEcommerceContext _context;

        public StatisticsController(ILogger<StatisticsController> logger, Task3RealEcommerceContext context)
        {
            _logger = logger;
            _context = context;
        }
        public ActionResult Statistics()
        {
            int? id = HttpContext.Session.GetInt32("sellerCompanyId");
            if (!id.HasValue)
                return RedirectToAction("Login", "SellerCompany");

            return View();
        }

        public async Task<ActionResult> BestSellingProducts()
        {
            int? id = HttpContext.Session.GetInt32("sellerCompanyId");
            if (!id.HasValue)
                return RedirectToAction("Login", "SellerCompany");

            var products = await _context.Satislars.Where(p => p.FirmaId == id).OrderByDescending(p => p.Siparis.SiparisKalemlers.Sum(p => p.Urun.SatisSayisi)).Take(10).Select(p => new BestSellingProductsModel
            {
                SalesCount = p.Siparis.SiparisKalemlers.Sum(l => l.Urun.SatisSayisi),
                ProductName = p.Siparis.SiparisKalemlers.Select(l => l.Urun.UrunAd).FirstOrDefault()
            }).ToListAsync();


            return View(products);
        }

        public async Task<ActionResult> SalesByDateChart()
        {
            int? id = HttpContext.Session.GetInt32("sellerCompanyId");
            if (!id.HasValue)
                return RedirectToAction("Login", "SellerCompany");

            var satislar = await _context.Satislars.Where(p => p.FirmaId == id).GroupBy(p => p.Tarih).Select(p => new SalesByDateChartModel
            {
                Date = p.Key,
                Amount = p.Count()
            }).ToListAsync();
            return View(satislar);
        }
        public async Task<ActionResult> TopSellingCategories()
        {
            int? id = HttpContext.Session.GetInt32("sellerCompanyId");
            if (!id.HasValue)
                return RedirectToAction("Login", "SellerCompany");

            var categories = await _context.Satislars.Where(p => p.FirmaId == id).SelectMany(p => p.Siparis.SiparisKalemlers).GroupBy(l => l.Urun.KategoriId).Select(p => new TopSellingCategoriesModel
            {
                CategoryName = p.Select(l => l.Urun.Kategori.KategoriAd).FirstOrDefault(),
                Amount = p.Sum(l => l.Urun.SatisSayisi)
            }).ToListAsync();


            return View(categories);
        }
        public async Task<ActionResult> MostViewedProducts()
        {
            int? id = HttpContext.Session.GetInt32("sellerCompanyId");
            if (!id.HasValue)
                return RedirectToAction("Login", "SellerCompany");


            var products = await _context.UrunGoruntulenmes.Where(p => p.Urun.FirmaId == id).GroupBy(p => new { p.UrunId, p.Urun.UrunAd }).Select(p => new MostViewedProductsModel
            {
                ProductName = p.Key.UrunAd,
                Count = p.Count()
            }).OrderByDescending(p => p.Count).Take(10).ToListAsync();
            
            return View(products);
        }

    }
}
