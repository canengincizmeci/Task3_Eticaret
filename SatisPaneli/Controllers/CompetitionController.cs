using DB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SatisPaneli.Models;

namespace SatisPaneli.Controllers
{
    public class CompetitionController : Controller
    {
        private readonly ILogger<CompetitionController> _logger;
        private readonly Task3RealEcommerceContext _context;

        public CompetitionController(ILogger<CompetitionController> logger, Task3RealEcommerceContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<ActionResult> Competitions()
        {
            int? id = HttpContext.Session.GetInt32("userId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "User");
            }
            var competitons = await _context.KullaniciYarismalars.Where(p => p.Aktiflik == true).Select(p => new CompetitionModel
            {
                Description = p.YarismaAciklama,
                End = p.BitisTarih,
                Start = p.BaslangicTarih,
                Title = p.YarismaBaslik,
                JoinStatus = p.KullaniciYarismaKatilanlars.Any(p => p.KullaniciYarismaId == id),
                Id = p.KullaniciYarismaId
            }).ToListAsync();

            return View(competitons);
        }
        public async Task<ActionResult> JoinCompetition(int competitionId)
        {
            int? id = HttpContext.Session.GetInt32("userId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "User");
            }
            var competition = await _context.KullaniciYarismalars.FindAsync(competitionId);
            if (competition is not null)
            {
                await _context.KullaniciYarismaKatilanlars.AddAsync(new KullaniciYarismaKatilanlar
                {
                    Aktiflik = true,
                    KatilmaTarih = DateTime.Now,
                    KullaniciId = id,
                    KullaniciYarismaId = competitionId
                });
                await _context.SaveChangesAsync();
                return Json(new { success = true });
            }
            else
            {
                return Json(new { success = false });
            }
        }
    }
}
