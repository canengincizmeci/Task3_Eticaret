using DB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SaticiFirmaPaneli.Models;

namespace SaticiFirmaPaneli.Controllers
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
            int? id = HttpContext.Session.GetInt32("sellerCompanyId");
            if (!id.HasValue)
                return RedirectToAction("Login", "SellerCompany");





            var modal = await _context.FirmaYarismalars.Where(p => (p.BaslangicTarih < DateTime.Now && p.BitisTarih > DateTime.Now && p.Aktiflik == true)).OrderByDescending(p => p.FirmayarismaId).Select(p => new CompanyCompetitionModel
            {
                ActivityStatus = p.Aktiflik,
                CompanyCompetitionId = p.FirmayarismaId,
                BeginDate = p.BaslangicTarih,
                CompetitionDescription = p.YarismaAciklama,
                CompetitionId = p.FirmayarismaId,
                CompetitionTitle = p.YarismaBaslik,
                EndDate = p.BitisTarih,
                JoinStatus = p.FirmaYarismasiKatilanlars.Any(p => p.FirmaId == id),
            }).ToListAsync();


            return View(modal);
        }
        public async Task<ActionResult> ParticipateCompetition(int competitionId)
        {
            int? id = HttpContext.Session.GetInt32("sellerCompanyId");
            if (!id.HasValue)
                return RedirectToAction("Login", "SellerCompany");

            await _context.FirmaYarismasiKatilanlars.AddAsync(new FirmaYarismasiKatilanlar
            {
                Aktiflik = true,
                FirmaId = id,
                FirmayarismaId = competitionId,
                KatilmaTarih = DateTime.Now
            });
            await _context.SaveChangesAsync();

            return Json(new { success = true });
        }
    }
}
