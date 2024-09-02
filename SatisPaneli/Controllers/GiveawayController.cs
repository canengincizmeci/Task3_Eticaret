using DB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SatisPaneli.Models;
using System.IO.Compression;

namespace SatisPaneli.Controllers
{
    public class GiveawayController : Controller
    {
        private readonly ILogger<CampaignController> _logger;
        private readonly Task3RealEcommerceContext _context;

        public GiveawayController(ILogger<CampaignController> logger, Task3RealEcommerceContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Giveaways()
        {
            int? id = HttpContext.Session.GetInt32("userId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "User");
            }

            var competitions = await _context.Cekilis.Where(p => p.Aktiflik == true).OrderByDescending(p => p.CekilisId).Select(p => new GiweawaysModel
            {
                Description = p.CekilisAciklama,
                End = p.BitisTarih,
                Id = p.CekilisId,
                Name = p.CekilisAd,
                Start = p.BaslangicTarih,
                JoinStatus = p.CekiliseKatılanlars.Any(l => l.KullaniciId == id)
            }).ToListAsync();
            return View(competitions);
        }
        [HttpPost]
        public async Task<ActionResult> JoinGiveaway(int giveawayId)
        {
            int? id = HttpContext.Session.GetInt32("userId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "User");
            }
            await _context.CekiliseKatılanlars.AddAsync(new CekiliseKatılanlar
            {
                KatilimTarihi = DateTime.Now,
                KullaniciId = id,
                CekilisId=giveawayId
            });
            await _context.SaveChangesAsync();


            return Json(new { success = true });
        }
    }
}
