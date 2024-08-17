using DB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SaticiFirmaPaneli.Models;

namespace SaticiFirmaPaneli.Controllers
{
    public class ReturnController : Controller
    {
        private readonly ILogger<ReturnController> _logger;
        private readonly Task3RealEcommerceContext _context;

        public ReturnController(ILogger<ReturnController> logger, Task3RealEcommerceContext context)
        {
            _logger = logger;
            _context = context;
        }
        public async Task<ActionResult> ReturnsIndex()
        {
            int? id = HttpContext.Session.GetInt32("sellerCompanyId");
            if (!id.HasValue)
                return RedirectToAction("Login", "SellerCompany");

            var returns = await _context.Iadelers.Where(p => p.IadeTalep.Odeme.Siparis.SiparisKalemlers.Any(l => l.Urun.FirmaId == id)).Select(p => new ReturnsModel
            {
                Date = p.Tarih,
                ReturnId = p.IadeId,
                UserName = p.Kullanici.KullaniciAd,
                ReturnAmount = p.IadeTutarı,
                UserId = p.KullaniciId,
                ReturnRequestId = p.IadeTalepId,
                CompanyIds = p.IadeTalep.Odeme.Siparis.SiparisKalemlers.Select(l => l.Urun.Firma.FirmaId).ToList(),
                CompanyNames = p.IadeTalep.Odeme.Siparis.SiparisKalemlers.Select(l => l.Urun.Firma.FirmaAd).ToList(),
                ProductIds = p.IadeTalep.Odeme.Siparis.SiparisKalemlers.Select(l => l.Urun.UrunId).ToList(),
                ProductNames = p.IadeTalep.Odeme.Siparis.SiparisKalemlers.Select(l => l.Urun.UrunAd).ToList(),
                CompanyAdresses = p.IadeTalep.Odeme.Siparis.SiparisKalemlers.Select(l => l.Urun.Firma.FirmaAdres).ToList()
            }).ToListAsync();

            return View(returns);
        }
        [HttpPost]
        public async Task<ActionResult> ShipTheReturn(int returnId)
        {
            int? id = HttpContext.Session.GetInt32("sellerCompanyId");
            if (!id.HasValue)
                return RedirectToAction("Login", "SellerCompany");

            var _return = await _context.Iadelers.FindAsync(returnId);
            if (_return == null)
            {
                return Json(new { success = false });
            }
            else
            {
                _context.Iadelers.Remove(_return);
                await _context.SaveChangesAsync();
                return Json(new { success = true });
            }
        }
    }
}
