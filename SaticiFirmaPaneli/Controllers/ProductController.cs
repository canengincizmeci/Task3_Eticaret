using DB.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SaticiFirmaPaneli.Models;

namespace SaticiFirmaPaneli.Controllers
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
        public async Task<ActionResult> FavoritedProducts()
        {
            int? id = HttpContext.Session.GetInt32("sellerCompanyId");
            if (!id.HasValue)
                return RedirectToAction("Login", "SellerCompany");
            var favories = await _context.Favorilers.Where(p => (p.Aktiflik == true && p.Urun.FirmaId == id)).Select(p => new FavoritedProductsModel
            {
                ActivityStatus = p.Aktiflik,
                FavoritedId = p.FavoriId,
                ProductId = p.UrunId,
                ProductName = p.Urun.UrunAd,
                UserAd = p.Kullanici.KullaniciAd,
                UserId = p.KullaniciId
            }).ToListAsync();
            return View(favories);
        }
        public async Task<ActionResult> Products(int? categoryId)
        {
            int? id = HttpContext.Session.GetInt32("sellerCompanyId");
            if (!id.HasValue)
                return RedirectToAction("Login", "SellerCompany");

            var categories = await _context.Kategoris.Where(p => p.Aktiflik == true).ToListAsync();

            List<SelectListItem> ktg = categories.Select(i => new SelectListItem
            {
                Text = i.KategoriAd,
                Value = i.KategoriId.ToString()
            }).ToList();

            ViewBag.Ktg = ktg;

            if (categoryId.HasValue && categoryId.Value > 0)
            {
                var products = await _context.Uruns.Where(p => (p.Aktiflik == true && p.FirmaId == id && p.KategoriId == categoryId)).Select(p => new ProductModel
                {
                    ActivityStatus = p.Aktiflik,
                    AddedDate = p.EklenmeTarihi,
                    CategoryId = p.KategoriId,
                    CategoryName = p.Kategori.KategoriAd,
                    CompanyId = p.FirmaId,
                    Description = p.Aciklama,
                    Price = p.Fiyat,
                    ProductId = p.UrunId,
                    ProductImage = p.UrunResim,
                    ProductName = p.UrunAd,
                    SalesCount = p.SatisSayisi,
                    Stock = p.Stok,
                    timesAddedToCart = p.SepeteEklemeSayisi
                }).ToListAsync();
                return View(products);
            }
            else
            {
                var products = await _context.Uruns.Where(p => (p.Aktiflik == true && p.FirmaId == id)).Select(p => new ProductModel
                {
                    ActivityStatus = p.Aktiflik,
                    AddedDate = p.EklenmeTarihi,
                    CategoryId = p.KategoriId,
                    CategoryName = p.Kategori.KategoriAd,
                    CompanyId = p.FirmaId,
                    Description = p.Aciklama,
                    Price = p.Fiyat,
                    ProductId = p.UrunId,
                    ProductImage = p.UrunResim,
                    ProductName = p.UrunAd,
                    SalesCount = p.SatisSayisi,
                    Stock = p.Stok,
                    timesAddedToCart = p.SepeteEklemeSayisi
                }).ToListAsync();
                return View(products);
            }
        }
        public async Task<ActionResult> ProductDetails(int productId)
        {
            int? id = HttpContext.Session.GetInt32("sellerCompanyId");
            if (!id.HasValue)
                return RedirectToAction("Login", "SellerCompany");




            var details = await _context.Uruns.Where(p => (p.UrunId == productId && p.FirmaId == id)).Select(p => new ProductModel
            {
                ActivityStatus = p.Aktiflik,
                AddedDate = p.EklenmeTarihi,
                CategoryId = p.KategoriId,
                CategoryName = p.Kategori.KategoriAd,
                CompanyId = p.FirmaId,
                Description = p.Aciklama,
                Price = p.Fiyat,
                ProductId = p.UrunId,
                ProductImage = p.UrunResim,
                ProductName = p.UrunAd,
                SalesCount = p.SatisSayisi,
                Stock = p.Stok,
                timesAddedToCart = p.SepeteEklemeSayisi,
                comments = p.Yorumlars.Where(l => l.UrunId == productId).Select(m => new ProductCommentModel
                {
                    ActivityStatus = m.Aktiflik,
                    Comment = m.Yorum,
                    CommentId = m.YorumId,
                    Date = m.Tarih,
                    ProductId = m.UrunId,
                    UserId = m.KullaniciId,
                    UserName = m.Kullanici.KullaniciAd
                }).ToList(),

            }).FirstOrDefaultAsync();

            return View(details);
        }
        [HttpPost]
        public async Task<ActionResult> UpdateProduct(Urun _product)
        {
            int? id = HttpContext.Session.GetInt32("sellerCompanyId");
            if (!id.HasValue)
                return RedirectToAction("Login", "SellerCompany");

            var product = await _context.Uruns.FindAsync(_product.UrunId);
            if (product == null)
            {
                return Json(new { success = false });
            }
            else
            {
                product.Aciklama = _product.Aciklama;
                product.Fiyat = _product.Fiyat;
                product.Stok = _product.Stok;
                product.UrunAd = _product.UrunAd;
                if (_product.UrunResim != null)
                {
                    product.UrunResim = _product.UrunResim;

                }
                await _context.SaveChangesAsync();
                return Json(new { success = true });
            }
        }
        [HttpGet]
        public async Task<ActionResult> AddProduct()
        {
            int? id = HttpContext.Session.GetInt32("sellerCompanyId");
            if (!id.HasValue)
                return RedirectToAction("Login", "SellerCompany");


            var categories = await _context.Kategoris.Where(p => p.Aktiflik == true).ToListAsync();

            List<SelectListItem> ktg = categories.Select(i => new SelectListItem
            {
                Text = i.KategoriAd,
                Value = i.KategoriId.ToString()
            }).ToList();

            ViewBag.Ktg = ktg;

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddProduct(Urun product)
        {
            int? id = HttpContext.Session.GetInt32("sellerCompanyId");
            if (!id.HasValue)
                return RedirectToAction("Login", "SellerCompany");
            await _context.AddAsync(new Urun
            {
                Aciklama = product.Aciklama,
                Fiyat = product.Fiyat,
                KategoriId = product.KategoriId,
                Stok = product.Stok,
                UrunAd = product.UrunAd,
                UrunResim = product.UrunResim,
                SepeteEklemeSayisi = 0,
                SatisSayisi = 0,
                FirmaId = id,
                EklenmeTarihi = DateTime.Now,
                Aktiflik = true
            });
            await _context.SaveChangesAsync();
            return RedirectToAction("Products", "Product");
        }
        [HttpPost]
        public async Task<ActionResult> DeleteProduct(int productId)
        {
            int? id = HttpContext.Session.GetInt32("sellerCompanyId");
            if (!id.HasValue)
                return RedirectToAction("Login", "SellerCompany");

            var product = await _context.Uruns.FindAsync(productId);
            if (product == null)
            {
                return Json(new { success = false });
            }
            else
            {
                product.Aktiflik = false;
                await _context.SaveChangesAsync();
                return Json(new { success = true });
            }
        }
        [HttpGet]
        public async Task<ActionResult> GetReplies(int commentId)
        {
            int? id = HttpContext.Session.GetInt32("sellerCompanyId");
            if (!id.HasValue)
                return RedirectToAction("Login", "SellerCompany");


            var userReplies = await _context.KullaniciYorumCevaps.Where(p => (p.Aktiflik == true && p.YorumId == commentId)).Select(p => new ProductCommentReplyModel
            {
                ActivityStatus = p.Aktiflik,
                CommentId = p.YorumId,
                Date = p.Tarih,
                Reply = p.Cevap,
                ReplyId = p.CevapId,
                UserId = p.KullaniciId,
                UserName = p.Kullanici.KullaniciAd
            }).ToListAsync();
            var companyReplies = await _context.FirmaYorumCevaps.Where(p => (p.Aktiflik == true && p.YorumId == commentId)).Select(p => new ProductCommentReplyModel
            {
                ActivityStatus = p.Aktiflik,
                CommentId = p.YorumId,
                CompanyId = p.FirmaId,
                CompanyName = p.Firma.FirmaAd,
                Date = p.Tarih,
                Reply = p.Cevap,
                ReplyId = p.CevapId,
            }).ToListAsync();
            var modal = userReplies.Concat(companyReplies).OrderBy(p => p.Date).ToList();
            return PartialView("~/Views/Shared/RepliesPartialView.cshtml", modal);
        }
        [HttpPost]
        public async Task<ActionResult> AddReply(FirmaYorumCevap reply)
        {
            int? id = HttpContext.Session.GetInt32("sellerCompanyId");
            if (!id.HasValue)
                return RedirectToAction("Login", "SellerCompany");

            await _context.AddAsync(new FirmaYorumCevap
            {
                Aktiflik = true,
                Cevap = reply.Cevap,
                YorumId = reply.YorumId,
                FirmaId = id,
                Tarih = DateTime.Now
            });
            await _context.SaveChangesAsync();
            return Json(new { success = true });
        }

        [HttpPost]
        public async Task<ActionResult> AddReplyForReply(FirmaYorumCevap reply, string recevierName)
        {
            int? id = HttpContext.Session.GetInt32("sellerCompanyId");
            if (!id.HasValue)
                return RedirectToAction("Login", "SellerCompany");

            await _context.FirmaYorumCevaps.AddAsync(new FirmaYorumCevap
            {
                Aktiflik = true,
                Cevap = $"@{recevierName}'a: {reply.Cevap}",
                YorumId = reply.YorumId,
                FirmaId = id,
                Tarih = DateTime.Now
            });
            await _context.SaveChangesAsync();
            return Json(new { success = true });
        }
    }
}
