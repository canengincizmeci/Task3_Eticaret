using Microsoft.AspNetCore.Mvc;

namespace AdminPaneli.Controllers
{
    public class MesajController1 : Controller
    {
        public IActionResult Index()
        {
            try
            {
                int? id = HttpContext.Session.GetInt32("adminId");

            }
            catch (Exception)
            {
                return RedirectToAction("Login", "Admin");
            }
            





            return View();
        }
    }
}
