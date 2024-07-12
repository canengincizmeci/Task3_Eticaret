using DB.Models;
using Microsoft.AspNetCore.Mvc;
using SatisPaneli.Models;
using System.Diagnostics;

namespace SatisPaneli.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Task3RealEcommerceContext _context;
        public HomeController(ILogger<HomeController> logger, Task3RealEcommerceContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
