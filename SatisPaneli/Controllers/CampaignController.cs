using DB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SatisPaneli.Models;

namespace SatisPaneli.Controllers
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
        public async Task<IActionResult> Campaigns()
        {
            int? id = HttpContext.Session.GetInt32("userId");
            if (id.HasValue)
            {
                ViewBag.Role = "User";
            }
            else
            {
                ViewBag.Role = "Visitor";
            }
            CampaignsModel modal = new CampaignsModel()
            {
                categoryCampaigns = await _context.KategoriKampanyalars.Where(p => p.Aktiflik == true).Select(p => new CategoryCampaingsModel
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
                }).ToListAsync(),
                companyCampaigns = await _context.FirmaKampanyalars.Where(p => p.Aktiflik == true).Select(p => new CompanyCampaignModel
                {
                    StartDate = p.BaslangicTarihi,
                    ActivityStatus = p.Aktiflik,
                    CampaignDescription = p.KampanyaAciklama,
                    CampaignId = p.KampanyaId,
                    CampaignTitle = p.KampanyaBaslik,
                    CompanyId = p.FirmaId,
                    CompanyName = p.Firma.FirmaAd,
                    DiscountAmount = p.IndirimMiktari,
                    EndDate = p.BitisTarihi
                }).ToListAsync(),
                generalCampaigns = await _context.GenelKampanyalars.Where(p => p.Aktiflik == true).ToListAsync(),
                productCampaigns = await _context.UrunKampanyalars.Where(p => p.Aktiflik == true).Select(p => new ProductCampaignModel
                {
                    EndDate = p.BitisTarihi,
                    DiscountAmount = p.IndirimMiktari,
                    ActivityStatus = p.Aktiflik,
                    CampaignDescription = p.KampanyaAciklama,
                    CampaignId = p.KapmanyaId,
                    CampaignTitle = p.KampanyaBaslik,
                    ProductId = p.UrunId,
                    ProductName = p.Urun.UrunAd,
                    StartDate = p.BaslangicTarihi
                }).ToListAsync()
            };

            return View(modal);
        }
    }
}
