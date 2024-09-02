using DB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SatisPaneli.Components
{
    public class CouponsViewComponent : ViewComponent
    {
        private readonly Task3RealEcommerceContext _context;

        public CouponsViewComponent(Task3RealEcommerceContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {

            var coupons = await _context.SureliKuponlars.Where(p => p.Aktiflik == true).OrderByDescending(p => p.KuponId).ToListAsync();



            return View(coupons);
        }




    }
}
