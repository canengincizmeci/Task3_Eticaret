using DB.Models;
using Microsoft.AspNetCore.Mvc;

namespace KargoFirmasiPaneli.Controllers
{
    public class MessageController : Controller
    {
        private readonly ILogger<MessageController> _logger;
        private readonly Task3RealEcommerceContext _context;
        public MessageController(ILogger<MessageController> logger, Task3RealEcommerceContext context)
        {
            _logger = logger;
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult InboxMessage()
        {
            int? id = HttpContext.Session.GetInt32("shippingCompanyId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "ShippingCompany");
            }
            ViewBag.NotificationFromAdmin = _context.AdmindenKargoFirmasinaBilgilendirmes.Where(p => (p.OkunduBilgisi == false && p.Aktiflik == true)).Count().ToString();
            ViewBag.MessageFromSupport = _context.TeknikDenKargoyaMesajs.Where(p => (p.OkunduBilgisi == false && p.Aktiflik == true)).Count().ToString();
            return View();
        }
        public ActionResult NotificationFromAdmin()
        {
            int? id = HttpContext.Session.GetInt32("shippingCompanyId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "ShippingCompany");
            }
            var model = _context.AdmindenKargoFirmasinaBilgilendirmes.Where(p => (p.OkunduBilgisi == false && p.Aktiflik == true)).OrderByDescending(p => p.BilgilendirmeId).Select(p => new AdmindenKargoFirmasinaBilgilendirme
            {
                AdminId = p.AdminId,
                Aktiflik = p.Aktiflik,
                BilgilendirmeBaslik = p.BilgilendirmeBaslik,
                BilgilendirmeId = p.BilgilendirmeId,
                BilgilendirmeMetin = p.BilgilendirmeMetin,
                KargoFirmaId = p.KargoFirmaId,
                OkunduBilgisi = p.OkunduBilgisi,
                Tarih = p.Tarih
            }).ToList();
            return View(model);
        }
        [HttpGet]
        public ActionResult MessageToSupport()
        {
            int? id = HttpContext.Session.GetInt32("shippingCompanyId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "ShippingCompany");
            }

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MessageToSupport(KargodanTeknikElemanaMesaj _message)
        {
            int? id = HttpContext.Session.GetInt32("shippingCompanyId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "ShippingCompany");
            }
            _context.Mesajlasmas.Add(new Mesajlasma
            {
                Tarih = DateTime.Now
            });
            _context.SaveChanges();

            int? supportId = _context.TeknikElemanlars.Where(p => p.Aktiflik == true).OrderBy(p => Guid.NewGuid()).FirstOrDefault().TeknikElemanId;

            int? messagingId = _context.Mesajlasmas.OrderByDescending(p => p.MesajlasmaId).FirstOrDefault().MesajlasmaId;
            _context.KargodanTeknikElemanaMesajs.Add(new KargodanTeknikElemanaMesaj
            {
                Aktiflik = true,
                KargoFirmaId = id,
                Mesaj = _message.Mesaj,
                MesajBaslik = _message.MesajBaslik,
                MesajlasmaId = messagingId,
                OkunduBilgisi = false,
                Tarih = DateTime.Now,
                TeknikElemanId = supportId
            });
            _context.SaveChanges();
            return RedirectToAction("NotificationFromAdmin", "Message");
        }
    }
}
