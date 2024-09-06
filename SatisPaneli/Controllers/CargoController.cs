using DB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SatisPaneli.Models;

namespace SatisPaneli.Controllers
{
    public class CargoController : Controller
    {
        private readonly ILogger<CartController> _logger;
        private readonly Task3RealEcommerceContext _context;

        public CargoController(ILogger<CartController> logger, Task3RealEcommerceContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> ProductsToBeShipped()
        {
            int? id = HttpContext.Session.GetInt32("userId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "User");
            }

            var cargos = await _context.Satislars.Where(p => (p.Siparis!.KargoDurumu == false && p.KullaniciId == id)).Select(p => new CargoViewModel
            {
                BillingAddress = p.FaturaAdresi,
                CompanyId = p.FirmaId,
                DeliveryAddress = p.GonderiAdresi,
                OrderId = p.SiparisId,
                SellingId = p.SatisId,
                CargoStatus = p.IstenenKargolars.Any(l => l.SatisId == p.SatisId)
            }).ToListAsync();

            return View(cargos);
        }
        public async Task<ActionResult> InShipment(int sellingId)
        {
            int? id = HttpContext.Session.GetInt32("userId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "User");
            }

            var cargos = await _context.KargoBildirimlers.Where(p => p.KargoBildirimBaslik == "Yolda").ToListAsync();

            return View(cargos);
        }
        public async Task<ActionResult> DispatchedOrders()
        {
            int? id = HttpContext.Session.GetInt32("userId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "User");
            }

            var orders = await _context.GonderilenKargolars.Where(p => p.AliciId == id).ToListAsync();


            return View(orders);
        }
    }
}
