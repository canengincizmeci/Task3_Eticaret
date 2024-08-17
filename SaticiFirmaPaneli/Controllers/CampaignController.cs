using DB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SaticiFirmaPaneli.Models;

namespace SaticiFirmaPaneli.Controllers
{
    public class CampaignController : Controller
    {
        private readonly ILogger<CampaignController> _logger;
        private readonly Task3RealEcommerceContext _context;

        public CampaignController(ILogger<CampaignController> logger, Task3RealEcommerceContext context)
        {
            _logger = logger;
            _context = context;
        }
        public async Task<ActionResult> Campaigns()
        {

            int? id = HttpContext.Session.GetInt32("sellerCompanyId");
            if (!id.HasValue)
                return RedirectToAction("Login", "SellerCompany");

            ViewBag.CompanyCampaignCount = await _context.FirmaKampanyalars.Where(p => p.Aktiflik == true).CountAsync();
            ViewBag.GeneralCampaignCount = await _context.GenelKampanyalars.Where(p => p.Aktiflik == true).CountAsync();
            ViewBag.CategoryCampaignCount = await _context.KategoriKampanyalars.Where(p => p.Aktiflik == true).CountAsync();
            ViewBag.ProductCampaignCount = await _context.UrunKampanyalars.Where(p => p.Aktiflik == true).CountAsync();


            return View();
        }
        public async Task<ActionResult> CompanyCampaigns()
        {
            int? id = HttpContext.Session.GetInt32("sellerCompanyId");
            if (!id.HasValue)
                return RedirectToAction("Login", "SellerCompany");

            var categoryCampaigns = await _context.FirmaKampanyalars.Where(p => (p.Aktiflik == true && p.FirmaId == id && p.BaslangicTarihi < DateTime.Now && p.BitisTarihi > DateTime.Now)).ToListAsync();


            return View(categoryCampaigns);
        }
        public async Task<ActionResult> GeneralCampaigns()
        {
            int? id = HttpContext.Session.GetInt32("sellerCompanyId");
            if (!id.HasValue)
                return RedirectToAction("Login", "SellerCompany");

            var modal = await _context.GenelKampanyalars.Where(p => (p.Aktiflik == true && p.BaslangicTarihi < DateTime.Now && p.BitisTarihi > DateTime.Now)).ToListAsync();

            return View(modal);
        }
        public async Task<ActionResult> CategoryCampaigns()
        {
            int? id = HttpContext.Session.GetInt32("sellerCompanyId");
            if (!id.HasValue)
                return RedirectToAction("Login", "SellerCompany");

            var modal = await _context.KategoriKampanyalars.Where(p => (p.Aktiflik == true && p.BaslangicTarihi < DateTime.Now && p.BitisTarihi > DateTime.Now)).Select(p => new CategoryCampaignsModel
            {
                ActivityStatus = p.Aktiflik,
                CampaignDescription = p.KampanyaAciklama,
                CampaignId = p.KampanyaId,
                CampaignTitle = p.KampanyaBaslik,
                CategoryId = p.KategoriId,
                CategoryName = p.Kategori.KategoriAd,
                DiscountAmount = p.IndirimMiktari,
                EndDate = p.BitisTarihi,
                StartDate = p.BaslangicTarihi
            }).ToListAsync();

            return View(modal);
        }
        public async Task<ActionResult> ProductCampaigns()
        {
            int? id = HttpContext.Session.GetInt32("sellerCompanyId");
            if (!id.HasValue)
                return RedirectToAction("Login", "SellerCompany");

            var campaigns = await _context.UrunKampanyalars.Where(p => (p.Aktiflik == true && p.BaslangicTarihi < DateTime.Now && p.BitisTarihi > DateTime.Now)).Select(p => new ProductCampaignsModel
            {
                ActivityStatus = p.Aktiflik,
                CampaignDescription = p.KampanyaAciklama,
                CampaignId = p.KapmanyaId,
                CampaignTitle = p.KampanyaBaslik,
                DiscountAmount = p.IndirimMiktari,
                EndDate = p.BitisTarihi,
                ProductId = p.UrunId,
                ProductName = p.Urun.UrunAd,
                StartDate = p.BaslangicTarihi
            }).ToListAsync();

            return View(campaigns);
        }
    }
}
