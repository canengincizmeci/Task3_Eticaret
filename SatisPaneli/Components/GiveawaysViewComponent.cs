using DB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SatisPaneli.Components
{
    public class GiveawaysViewComponent : ViewComponent
    {
        private readonly Task3RealEcommerceContext _context;

        public GiveawaysViewComponent(Task3RealEcommerceContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {

            var giveAways = await _context.Cekilis.Where(p => p.Aktiflik == true).OrderByDescending(p => p.CekilisId).ToListAsync();


            return View(giveAways);
        }
    }
}
