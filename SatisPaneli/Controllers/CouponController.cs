using DB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SatisPaneli.Models;

namespace SatisPaneli.Controllers
{
    public class CouponController : Controller
    {
        private readonly ILogger<CampaignController> _logger;
        private readonly Task3RealEcommerceContext _context;

        public CouponController(ILogger<CampaignController> logger, Task3RealEcommerceContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Coupons()
        {
            int? id = HttpContext.Session.GetInt32("userId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "User");
            }

            var coupons = await _context.SureliKuponlars.Where(p => p.Aktiflik == true).OrderByDescending(p => p.KuponId).Select(p => new CouponModel
            {
                Description = p.KuponAciklama,
                DiscountAmount = p.IndirimMiktari,
                End = p.BitisTarihi,
                Start = p.BaslangicTarihi,
                Id = p.KuponId,
                Title = p.KuponBaslik
            }).ToListAsync();

            return View(coupons);
        }
    }
}
