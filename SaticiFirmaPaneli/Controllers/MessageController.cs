using Microsoft.AspNetCore.Mvc;

namespace SaticiFirmaPaneli.Controllers
{
    public class MessageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
