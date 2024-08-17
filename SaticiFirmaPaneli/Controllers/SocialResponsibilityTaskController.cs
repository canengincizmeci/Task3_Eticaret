using DB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SaticiFirmaPaneli.Models;

namespace SaticiFirmaPaneli.Controllers
{
    public class SocialResponsibilityTaskController : Controller
    {
        private readonly ILogger<SocialResponsibilityTaskController> _logger;
        private readonly Task3RealEcommerceContext _context;

        public SocialResponsibilityTaskController(ILogger<SocialResponsibilityTaskController> logger, Task3RealEcommerceContext context)
        {
            _logger = logger;
            _context = context;
        }
        public async Task<ActionResult> SocialResponsibilityTasks()
        {
            int? id = HttpContext.Session.GetInt32("sellerCompanyId");
            if (!id.HasValue)
                return RedirectToAction("Login", "SellerCompany");

            var modal = await _context.SosyalSorumlulukGorevis.Where(p => (p.Aktiflik == true)).Select(p => new SocialResponsibilityTaskModel
            {
                ActivityStatus = p.Aktiflik,
                StartDate = p.BaslangicTarihi,
                EndDate = p.BitisTarihi,
                TaskDescription = p.GorevAciklama,
                TaskId = p.GorevId,
                TaskName = p.GorevAd,
                JoinStatus = p.SosyalSorumlulukKatilanFirmalars.Any(p => p.FirmaId == id)
            }).ToListAsync();

           
            return View(modal);
        }

        [HttpPost]
        public async Task<ActionResult> JoinSocialResponsibility(int taskId)
        {
            int? id = HttpContext.Session.GetInt32("sellerCompanyId");
            if (!id.HasValue)
                return RedirectToAction("Login", "SellerCompany");

            await _context.SosyalSorumlulukKatilanFirmalars.AddAsync(new SosyalSorumlulukKatilanFirmalar
            {
                Aktiflik = true,
                FirmaId = id,
                KatilimTarihi = DateTime.Now,
                GorevId = taskId,
                Puan = 10
            });
            await _context.SaveChangesAsync();
            return Json(new { success = true });
        }
    }
}
