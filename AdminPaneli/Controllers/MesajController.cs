using AdminPaneli.Models;
using DB.Models;
using Microsoft.AspNetCore.Mvc;

namespace AdminPaneli.Controllers
{
    public class MesajController : Controller
    {
        private readonly ILogger<MesajController> _logger;
        private readonly Task3RealEcommerceContext _context;

        public MesajController(ILogger<MesajController> logger, Task3RealEcommerceContext context)
        {
            _logger = logger;
            _context = context;
        }
        public IActionResult Index()
        {


            int? id = HttpContext.Session.GetInt32("adminId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "Admin");

            }

            var sonMesajlar = _context.TeknikdenAdmineMesajs.GroupBy(p => p.MesajlasmaId).Select(p => p.OrderByDescending(p => p.Tarih).FirstOrDefault()).ToList();






            var gonderiicler = from mesaj in sonMesajlar
                               join teknik in _context.TeknikElemanlars on mesaj.TeknikId equals teknik.TeknikElemanId
                               select new AdminMesajModel
                               {
                                   _mesajId = mesaj.MesajId,
                                   _elemanAd = teknik.ElemanAd,
                                   _mesaj = mesaj.Mesaj,
                                   _okunduBilgisi = mesaj.OkunduBilgisi,
                                   _tarih = mesaj.Tarih
                               };


            var veriler = gonderiicler.ToList();
            return View(veriler);
        }
        public ActionResult MesajOku(int mesajId)
        {

            int? id = HttpContext.Session.GetInt32("adminId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "Admin");

            }
            int? mesajim = _context.TeknikdenAdmineMesajs.Find(mesajId).MesajlasmaId;
            int? teknikEleman = _context.TeknikdenAdmineMesajs.Find(mesajId).TeknikId;
            ViewBag.ElemanId = teknikEleman;
            var mesajlar = from mesaj in _context.TeknikdenAdmineMesajs
                           join mesajlarim in _context.Mesajlasmas on mesaj.MesajlasmaId equals mesajim
                           join eleman in _context.TeknikElemanlars on mesaj.TeknikId equals eleman.TeknikElemanId

                           select new AdminMesajModel
                           {
                               _elemanAd = eleman.ElemanAd,
                               _mesaj = mesaj.Mesaj,
                               _mesajId = mesaj.MesajId,
                               _okunduBilgisi = mesaj.OkunduBilgisi,
                               _tarih = mesaj.Tarih,
                               _mesajlasmaId = mesaj.MesajlasmaId,
                               _elemanId = mesaj.TeknikId
                           };
            var adminGidenMesajlar = from mesaj in _context.AdmindenTeknikDestegeMesajs
                                     join mesajlarim in _context.Mesajlasmas on mesaj.MesajlasmaId equals mesajim
                                     where mesaj.AdminId == id
                                     select new AdminMesajModel
                                     {
                                         _mesaj = mesaj.Mesaj,
                                         _tarih = mesaj.Tarih,
                                         _okunduBilgisi = mesaj.OkunduBilgisi,
                                         _mesajId = mesaj.MesajId,
                                         _mesajlasmaId = mesaj.MesajlasmaId,
                                         _adminId = mesaj.AdminId
                                     };


            var siraliMesajlar = mesajlar.Distinct().OrderByDescending(p => p._tarih).ToList();
            var adminMesajlar = adminGidenMesajlar.Distinct().OrderByDescending(p => p._tarih).ToList();
            List<AdminMesajModel> tamListe = siraliMesajlar.Concat(adminMesajlar).ToList().OrderBy(p => p._tarih).ToList();
            return View(tamListe);
        }
        public ActionResult MesajGoruntule(int mesajId)
        {
            int? id = HttpContext.Session.GetInt32("adminId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "Admin");

            }
            var mesaj = _context.TeknikdenAdmineMesajs.Find(mesajId);
            var mesajData = from i in _context.TeknikElemanlars
                            join m in _context.TeknikdenAdmineMesajs on i.TeknikElemanId equals m.TeknikId
                            where m.MesajId == mesajId
                            select new AdminMesajModel
                            {
                                _elemanAd = i.ElemanAd,
                                _mesaj = m.Mesaj,
                                _mesajId = m.MesajId,
                                _okunduBilgisi = m.OkunduBilgisi,
                                _tarih = m.Tarih,
                                _adminId = m.AdminId,
                                _mesajlasmaId = m.MesajlasmaId
                            };

            var _mesajData = mesajData.FirstOrDefault();
            return View(_mesajData);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AdmindenTeknikeCevap(int mesajlasmaId, string mesaj, int teknikElemanId, string mesajBaslik, int mesajId)
        {
            int? id = HttpContext.Session.GetInt32("adminId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "Admin");

            }
            _context.AdmindenTeknikDestegeMesajs.Add(new AdmindenTeknikDestegeMesaj
            {
                AdminId = id,
                ElemanId = teknikElemanId,
                Tarih = DateTime.Now,
                MesajlasmaId = mesajlasmaId,
                OkunduBilgisi = false,
                MesajBaslik = mesajBaslik,
                Mesaj = mesaj,

            });
            _context.SaveChanges();

            return RedirectToAction("Index", "Mesaj");
            //return RedirectToAction("MesajOku", "Mesaj", new { mesajId = mesajId });
        }
       
    }
}
