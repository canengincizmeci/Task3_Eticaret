using DB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using SatisPaneli.Models;
using Microsoft.EntityFrameworkCore;

namespace SatisPaneli.Components
{
    public class CategoriesViewComponent : ViewComponent
    {
        private readonly Task3RealEcommerceContext _context;

        public CategoriesViewComponent(Task3RealEcommerceContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = await _context.Kategoris.Where(p => p.Aktiflik == true).OrderByDescending(p => p.Uruns.Count).Select(p => new CategoriesViewComponentModel
            {
                Count = p.Uruns.Count,
                CategoryName = p.KategoriAd,
                CategoryId = p.KategoriId
            }).ToListAsync();



            return View(categories);
        }
    }
}
