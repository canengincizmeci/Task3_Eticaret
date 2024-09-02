using DB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using SatisPaneli.Models;
using System.Diagnostics;

namespace SatisPaneli.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Task3RealEcommerceContext _context;
        private readonly IMemoryCache _memoryCache;
        public HomeController(ILogger<HomeController> logger, Task3RealEcommerceContext context, IMemoryCache memoryCache)
        {
            _logger = logger;
            _context = context;
            _memoryCache = memoryCache;
        }

        

        public async Task<ActionResult> VisitorIndex(string? filterBy, int? categoryId, string? word)
        {
            var products = new List<Urun>();
            if (!categoryId.HasValue && string.IsNullOrEmpty(filterBy) && string.IsNullOrEmpty(word))
            {
                var cachedProducts = await _memoryCache.GetOrCreateAsync("products", async entry =>
                {
                    entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10);

                    return await _context.Uruns.Where(p => p.Aktiflik == true).OrderBy(p => Guid.NewGuid()).ToListAsync();
                });


                return View(cachedProducts);

            }
            if (!string.IsNullOrEmpty(filterBy))
            {
                if (filterBy.Equals("decreasing"))
                {
                    products = await _context.Uruns.Where(p => p.Aktiflik == true).OrderByDescending(p => p.Fiyat).ToListAsync();
                    return View(products);
                }
                else if (filterBy.Equals("increasing"))
                {
                    products = await _context.Uruns.Where(p => p.Aktiflik == true).OrderBy(p => p.Fiyat).ToListAsync();
                    return View(products);
                }
                else if (filterBy.Equals("reverseOrder"))
                {
                    products = await _context.Uruns.Where(p => p.Aktiflik == true).OrderByDescending(p => p.EklenmeTarihi).ToListAsync();
                    return View(products);
                }
                else if (filterBy.Equals("ascendingOrder"))
                {
                    products = await _context.Uruns.Where(p => p.Aktiflik == true).OrderBy(p => p.EklenmeTarihi).ToListAsync();
                    return View(products);
                }
                else if (filterBy.Equals("bestSellers"))
                {
                    //products = await _context.Satislars.SelectMany(p => p.Siparis.SiparisKalemlers).GroupBy(p => p.UrunId).Select(p => new
                    //{
                    //    productId = p.Key,
                    //    salesCount = p.Count()
                    //}).OrderByDescending(p => p.salesCount).ToListAsync();
                    var bestSellers = await _context.Satislars.SelectMany(p => p.Siparis.SiparisKalemlers).GroupBy(p => p.UrunId).Select(p => new
                    {
                        ProductId = p.Key,
                        SalesCount = p.Count()
                    }).OrderByDescending(p => p.SalesCount).ToListAsync();
                    var modal = await _context.Uruns.Where(m => bestSellers.Select(l => l.ProductId).Contains(m.UrunId)).ToListAsync();
                    return View(modal);
                }
            }
            if (categoryId.HasValue)
            {
                products = await _context.Uruns.Where(p => (p.Aktiflik == true && p.KategoriId == categoryId)).OrderBy(p => Guid.NewGuid()).ToListAsync();
                return View(products);
            }
            if (!string.IsNullOrEmpty(word))
            {
                products = await _context.Uruns.Where(p => (p.Aktiflik == true && p.UrunAd == word)).ToListAsync();
                return View(products);
            }
            return RedirectToAction("LostedUser", "Home");
        }



        
        public async Task<ActionResult> FrequentlyAskedQuestions()
        {

            var cachedQuestions = await _memoryCache.GetOrCreateAsync("questions", async entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5);

                return await _context.SikcaSorulanlars.Where(p => p.Aktiflik == true).ToListAsync();
            });

            return View(cachedQuestions);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Search(string _word)
        {

            var bannedWords = await _memoryCache.GetOrCreateAsync("bannedWords", async entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(1);
                return await _context.ArananKelimelers.Where(p => p.Aktiflik == false).Distinct().ToListAsync();
            });


            if (bannedWords.Any(p => p.Kelime == _word))
            {
                return RedirectToAction("VisitorIndex", "Home");
            }

            await _context.ArananKelimelers.AddAsync(new ArananKelimeler
            {
                Aktiflik = true,
                Kelime = _word,
                Tarih = DateTime.Now
            });
            await _context.SaveChangesAsync();
            return RedirectToAction("VisitorIndex", "Home", new { word = _word });
        }

    }
}
