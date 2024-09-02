using DB.Models;
using Microsoft.AspNetCore.Mvc;

namespace SatisPaneli.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly Task3RealEcommerceContext _context;
        public UserController(ILogger<UserController> logger, Task3RealEcommerceContext context)
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
