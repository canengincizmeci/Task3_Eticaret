using DB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SatisPaneli.Models;

namespace SatisPaneli.Components
{
    public class CampaignsViewComponent : ViewComponent
    {
        private readonly Task3RealEcommerceContext _context;

        public CampaignsViewComponent(Task3RealEcommerceContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {

            CampaignsViewComponentModel modal = new CampaignsViewComponentModel()
            {
                categoryCampaigns = await _context.KategoriKampanyalars.Where(p => p.Aktiflik == true).ToListAsync(),
                companyCampaigns = await _context.FirmaKampanyalars.Where(p => p.Aktiflik == true).ToListAsync(),
                generalCampaigns = await _context.GenelKampanyalars.Where(p => p.Aktiflik == true).ToListAsync(),
                productCampaigns = await _context.UrunKampanyalars.Where(p => p.Aktiflik == true).ToListAsync()
            };


            return View(modal);
        }
    }
}
