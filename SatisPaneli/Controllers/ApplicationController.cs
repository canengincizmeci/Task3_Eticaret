using DB.Models;
using Microsoft.AspNetCore.Mvc;

namespace SatisPaneli.Controllers
{
    public class ApplicationController : Controller
    {
        private readonly ILogger<ApplicationController> _logger;
        private readonly Task3RealEcommerceContext _context;
        public ApplicationController(ILogger<ApplicationController> logger, Task3RealEcommerceContext context)
        {
            _logger = logger;
            _context = context;
        }
        [HttpGet]
        public IActionResult CompanyApplication()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CompanyApplication(FirmaBasvuru apply)
        {

            await _context.FirmaBasvurus.AddAsync(new FirmaBasvuru
            {
                Aktiflik = true,
                BasvuruTarih = DateTime.Now,
                FirmaAciklama = apply.FirmaAciklama,
                FirmaAd = apply.FirmaAd,
                FirmaAdres = apply.FirmaAdres,
                FirmaSektor = apply.FirmaSektor,
                FirmaTel = apply.FirmaTel,
                KurulusTarihi = apply.KurulusTarihi,
                Mail = apply.Mail
            });
            await _context.SaveChangesAsync();
            return RedirectToAction("VisitorIndex", "Home");
        }
        [HttpGet]
        public ActionResult SupportApplication()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SupportApplication(TeknikElemanBasvuru apply)
        {
            await _context.AddAsync(new TeknikElemanBasvuru
            {
                Ad = apply.Ad,
                Adres = apply.Adres,
                Cinsiyet = apply.Cinsiyet,
                DogumTarihi = apply.DogumTarihi,
                Mail = apply.Mail,
                MezuniyetDurumu = apply.MezuniyetDurumu,
                Ozgecmis = apply.Ozgecmis,
                Soyad = apply.Soyad,
                TcNo = apply.TcNo,
                TelefonNumarasi = apply.TelefonNumarasi
            });
            await _context.SaveChangesAsync();

            return RedirectToAction("VisitorIndex", "Home");
        }
    }
}
