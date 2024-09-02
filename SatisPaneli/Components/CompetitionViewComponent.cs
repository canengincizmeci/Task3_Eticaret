using DB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SatisPaneli.Components
{
    public class CompetitionViewComponent : ViewComponent
    {
        private readonly Task3RealEcommerceContext _context;

        public CompetitionViewComponent(Task3RealEcommerceContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var competitions = await _context.KullaniciYarismalars.Where(p => p.Aktiflik == true).OrderByDescending(p => p.KullaniciYarismaId).ToListAsync();
            return View(competitions);
        }
    }
}

