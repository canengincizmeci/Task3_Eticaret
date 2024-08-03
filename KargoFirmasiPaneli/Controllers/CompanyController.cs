using DB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json.Linq;

namespace KargoFirmasiPaneli.Controllers
{
    public class CompanyController : Controller
    {
        private readonly ILogger<CompanyController> _logger;
        private readonly Task3RealEcommerceContext _context;
        public CompanyController(ILogger<CompanyController> logger, Task3RealEcommerceContext context)
        {
            _logger = logger;
            _context = context;
        }

        public ActionResult BranchList()
        {
            int? id = HttpContext.Session.GetInt32("shippingCompanyId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "ShippingCompany");
            }
            var model = _context.KargoFirmaSubelers.Where(p => (p.Aktiflik == true && p.KargoFirmaId == id)).OrderByDescending(p => p.KargoFirmaSubeId).Select(p => new KargoFirmaSubeler
            {
                Adress = p.Adress,
                KargoFirmaSubeId = p.KargoFirmaSubeId,
                KargoFirmaId = p.KargoFirmaId,
                Aktiflik = p.Aktiflik,
                EklenmeTarihi = p.EklenmeTarihi
            }).ToList();
            return View(model);
        }
        [HttpPost]
        public ActionResult DeleteBranch(int branchId)
        {
            int? id = HttpContext.Session.GetInt32("shippingCompanyId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "ShippingCompany");
            }
            _context.KargoFirmaSubelers.Find(branchId).Aktiflik = false;
            _context.SaveChanges();
            return Json(new { success = true });
        }
      
        [HttpPost]    
        public ActionResult AddBranch(string adress)
        {
            int? id = HttpContext.Session.GetInt32("shippingCompanyId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "ShippingCompany");
            }
            _context.KargoFirmaSubelers.Add(new KargoFirmaSubeler
            {
                Adress = adress,
                Aktiflik = true,
                EklenmeTarihi = DateTime.Now,
                KargoFirmaId = id
            });
            _context.SaveChanges();

            return Json(new { success = true });
        }
    }
}
