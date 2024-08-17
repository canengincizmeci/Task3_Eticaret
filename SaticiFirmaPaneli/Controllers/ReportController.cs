using DB.Models;
using Microsoft.AspNetCore.Mvc;

namespace SaticiFirmaPaneli.Controllers
{
    public class ReportController : Controller
    {
        private readonly ILogger<ReportController> _logger;
        private readonly Task3RealEcommerceContext _context;

        public ReportController(ILogger<ReportController> logger, Task3RealEcommerceContext context)
        {
            _logger = logger;
            _context = context;
        }


        [HttpPost]
        public async Task<ActionResult> ReportUserComment(FirmadanYorumSikayet report)
        {
            int? id = HttpContext.Session.GetInt32("sellerCompanyId");
            if (!id.HasValue)
                return RedirectToAction("Login", "SellerCompany");

            await _context.AddAsync(new FirmadanYorumSikayet
            {
                Aktiflik = true,
                FirmaId = id,
                KullaniciId = report.KullaniciId,
                YorumId = report.YorumId,
                SikayetBaslik = report.SikayetBaslik,
                SikayetMetni = report.SikayetMetni,
                Tarih = DateTime.Now
            });
            await _context.SaveChangesAsync();
            return Json(new { success = true });

        }
        [HttpPost]
        public async Task<ActionResult> ReportUserReply(FirmadanKullaniciyaYorumCevapSikayet report)
        {
            int? id = HttpContext.Session.GetInt32("sellerCompanyId");
            if (!id.HasValue)
                return RedirectToAction("Login", "SellerCompany");

            await _context.FirmadanKullaniciyaYorumCevapSikayets.AddAsync(new FirmadanKullaniciyaYorumCevapSikayet
            {
                Aktiflik = true,
                FirmaId = id,
                KullaniciId = report.KullaniciId,
                SikayetBaslik = report.SikayetBaslik,
                SikayetMetni = report.SikayetMetni,
                YorumCevapId = report.YorumCevapId,
                Tarih = DateTime.Now
            });
                await _context.SaveChangesAsync();
            return Json(new { success = true });
        }
    }
}
