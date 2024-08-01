using DB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Xml.Schema;
using TeknikDestekElemanPaneli.Models;

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
        public ActionResult IadeTalepler()
        {
            int? id = HttpContext.Session.GetInt32("teknikElemanId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "TeknikEleman");
            }

            var talepler = _context.IadeTaleps.Include(p => p.Odeme).ThenInclude(p => p.Siparis).ThenInclude(p => p.SiparisKalemlers).ThenInclude(p => p.Urun).Where(p => (p.Aktiflik == true && p.Onay == false)).OrderByDescending(p => p.TalepId).Select(p => new IadeTalepModel
            {
                TalepId = p.TalepId,
                Aktiflik = p.Aktiflik,
                KullaniciId = p.KullaniciId,
                KullaniciAd = p.Kullanici.KullaniciAd,
                OdemeId = p.OdemeId,
                Onay = p.Onay,
                Sebep = p.Sebep,
                Tarih = p.Tarih,
                FirmaAd = p.Odeme.Siparis.SiparisKalemlers.Select(l => l.Urun.Firma.FirmaAd).Distinct().ToList(),
                FirmaId = p.Odeme.Siparis.SiparisKalemlers.Select(k => k.Urun.Firma.FirmaId).Distinct().ToList()
            }).ToList();


            return View(talepler);
        }

        public ActionResult IadeTalepSil(int iadeTalepId)
        {
            int? id = HttpContext.Session.GetInt32("teknikElemanId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "TeknikEleman");
            }

            _context.IadeTaleps.Find(iadeTalepId).Aktiflik = false;
            _context.SaveChanges();

            return RedirectToAction("IadeTalepler", "Iade");
        }
        public ActionResult IadeTalepOnayla()
        {
            int? id = HttpContext.Session.GetInt32("teknikElemanId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "TeknikEleman");
            }
            _context.IadeTaleps.Find().Onay = true;
            _context.SaveChanges();


            return RedirectToAction("IadeTalepler", "Iade");
        }
        public ActionResult YoldaIadeTalepler()
        {
            int? id = HttpContext.Session.GetInt32("teknikElemanId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "TeknikEleman");
            }
            var model = _context.YoldaIadeTalebis.Where(p => p.Onay == false).OrderByDescending(p => p.YoldaIadeTalebiId).Select(p => new YoldaIadeTalebiModel
            {
                YoldaIadeTalebiId = p.YoldaIadeTalebiId,
                Onay = p.Onay,
                FirmaAd = p.Firma.FirmaAd,
                FirmaId = p.FirmaId,
                GonderilenKargoId = p.GonderilenKargoId,
                IadeAciklama = p.IadeAciklama,
                KullaniciAd = p.Kullanici.KullaniciAd,
                KullaniciId = p.KullaniciId,
                Tarih = p.Tarih,
                KargoFirmaAd = p.GonderilenKargo.KargoFirma.KargoFirmaAd,
                KargoFirmaId = p.GonderilenKargo.KargoFirmaId
            }).ToList();


            return View(model);
        }

        public ActionResult YoldaIadeTalepOnayla(int yoldaIadeTalepId)
        {
            int? id = HttpContext.Session.GetInt32("teknikElemanId");
            if (!id.HasValue)
            {
                return RedirectToAction();
            }
            _context.YoldaIadeTalebis.Find(yoldaIadeTalepId).Onay = true;
            _context.SaveChanges();

            return RedirectToAction("YoldaIadeTalepler", "Iade");
        }
    }
}
