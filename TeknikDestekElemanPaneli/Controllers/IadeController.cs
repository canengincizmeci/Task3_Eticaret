using DB.Models;
using Microsoft.AspNetCore.Mvc;

namespace TeknikDestekElemanPaneli.Controllers
{
    public class IadeController : Controller
    {
        private readonly ILogger<IadeController> _logger;
        private readonly Task3RealEcommerceContext _context;
        public IadeController(ILogger<IadeController> logger, Task3RealEcommerceContext context)
        {
            _logger = logger;
            _context = context;
        }
        public ActionResult Index()
        {


            return View();
        }
    }
}
