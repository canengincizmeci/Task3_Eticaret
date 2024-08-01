using DB.Models;
using Microsoft.AspNetCore.Mvc;

namespace TeknikDestekElemanPaneli.Controllers
{
    public class SatisRedController : Controller
    {
        private readonly ILogger<SatisRedController> _logger;
        private readonly Task3RealEcommerceContext _context;
        public SatisRedController(ILogger<SatisRedController> logger, Task3RealEcommerceContext context)
        {
            _logger = logger;
            _context = context;
        }
        public ActionResult Index()
        {
            int? id = HttpContext.Session.GetInt32("teknikElemanId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "TeknikEleman");
            }
            var model = _context.SatisReds.OrderByDescending(p => p.RedId).Select(p => new SatisRed
            {
                Tarih = p.Tarih,
                FirmaId = p.FirmaId

            }).ToList();


            return View(model);
        }
    }
}
