using DB.Models;
using Microsoft.AspNetCore.Mvc;
using TeknikDestekElemanPaneli.Models;

namespace TeknikDestekElemanPaneli.Controllers
{
    public class SikayetController : Controller
    {
        private readonly ILogger<SikayetController> _logger;
        private readonly Task3RealEcommerceContext _context;
        public SikayetController(ILogger<SikayetController> logger, Task3RealEcommerceContext context)
        {
            _logger = logger;
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public ActionResult FirmayaGelenSikayetler(int firmaId)
        {
            int? id = HttpContext.Session.GetInt32("teknikElemanId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "TeknikEleman");
            }

            FirmayaGelenSikayetlerModel model = new FirmayaGelenSikayetlerModel()
            {
                kullanicidanFirmayaSikayetler = _context.KullanicidanFirmayaSikayets.Where(p => (p.Aktiflik == true && p.FirmaId == firmaId)).OrderByDescending(p => p.SikayetId).Select(p => new KullanicidanFirmayaSikayetModel
                {
                    Tarih = p.Tarih,
                    SikayetciId = p.SikayetciId,
                    Aktiflik = p.Aktiflik,
                    FirmaAd = p.Firma.FirmaAd,
                    FirmaId = p.FirmaId,
                    KullaniciAd = p.Sikayetci.KullaniciAd,
                    SikayetBaslik = p.SikayetBaslik,
                    SikayetId = p.SikayetId,
                    SikayetMetni = p.SikayetMetni
                }).ToList(),
                kullanicidanFirmayaYorumSikayetler = _context.KullanicidanFirmayaYorumCevapSikayets.Where(p => (p.FirmaId == firmaId && p.Aktiflik == true)).OrderByDescending(p => p.KullaniciYorumCevapSikayetId).Select(p => new KullanicidanFirmayaYorumCevapSikayetModel
                {
                    Aktiflik = p.Aktiflik,
                    FirmaAd = p.Firma.FirmaAd,
                    FirmaId = p.FirmaId,
                    KullaniciAd = p.Kullanici.KullaniciAd,
                    KullaniciId = p.KullaniciId,
                    KullaniciYorumCevapSikayetId = p.KullaniciYorumCevapSikayetId,
                    SikayetBaslik = p.SikayetBaslik,
                    SikayetMetni = p.SikayetMetni,
                    Tarih = p.Tarih,
                    Yorum = p.YorumCevap.Yorum.Yorum,
                    YorumCevapId = p.YorumCevapId
                }).ToList()
            };

            return View(model);
        }
    }
}
