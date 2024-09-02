using DB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SatisPaneli.Models;

namespace SatisPaneli.Controllers
{
    public class MessageController : Controller
    {
        private readonly ILogger<CartController> _logger;
        private readonly Task3RealEcommerceContext _context;

        public MessageController(ILogger<CartController> logger, Task3RealEcommerceContext context)
        {
            _logger = logger;
            _context = context;
        }
        public async Task<ActionResult> Inbox()
        {
            int? id = HttpContext.Session.GetInt32("userId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "User");
            }
            var messages = await _context.TeknikdenKullaniciyaMesajs.Where(p => (p.Aktiflik == true && p.KullaniciId == id)).ToListAsync();
            var modal = messages.GroupBy(p => p.MesajlasmaId).Select(p => p.OrderByDescending(p => p.MesajlasmaId).FirstOrDefault()).Select(p => new TeknikdenKullaniciyaMesaj
            {
                OkunduBilgisi = p.OkunduBilgisi,
                Tarih = p.Tarih,
                MesajlasmaId = p.MesajlasmaId,
                Aktiflik = p.Aktiflik,
                KullaniciId = p.KullaniciId,
                Mesaj = p.Mesaj,
                MesajBaslik = p.MesajBaslik,
                MesajId = p.MesajId,
                TeknikId = p.TeknikId
            }).ToList();


            return View(modal);
        }
        public async Task<ActionResult> MessagingDetailsFromSupport(int messageId)
        {
            int? id = HttpContext.Session.GetInt32("userId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "User");
            }
            var messaging = await _context.TeknikdenKullaniciyaMesajs.FindAsync(messageId);
            int? messagingId = messaging.MesajlasmaId;
            var list1 = await _context.TeknikdenKullaniciyaMesajs.Where(p => (p.Aktiflik == true && p.MesajlasmaId == messagingId)).OrderByDescending(p => p.MesajId).Select(p => new MessagesWithSupportModel
            {
                ActivityStatus = p.Aktiflik,
                MessageId = p.MesajId,
                MessagingId = p.MesajlasmaId,
                UserId = p.KullaniciId,
                UserName = p.Kullanici.KullaniciAd,
                Message = p.Mesaj,
                MessageTitle = p.MesajBaslik,
                ReadStatus = p.OkunduBilgisi,
                Date = p.Tarih,
                SupportId = p.TeknikId,
                SupportName = p.Teknik.ElemanAd,
                Role = false
            }).ToListAsync();
            var list2 = await _context.KullanicidanTeknikDestegeMesajs.Where(p => (p.Aktiflik == true && p.MesajlasmaId == messagingId && p.KullaniciId == id && p.TeknikElemanId == messaging.TeknikId)).OrderByDescending(p => p.MesajId).Select(p => new MessagesWithSupportModel
            {
                ActivityStatus = p.Aktiflik,
                MessageId = p.MesajId,
                MessagingId = p.MesajlasmaId,
                UserId = p.KullaniciId,
                UserName = p.Kullanici.KullaniciAd,
                Message = p.Mesaj,
                MessageTitle = p.MesajBaslik,
                ReadStatus = p.OkunduBilgisi,
                Date = p.Tarih,
                SupportId = p.TeknikElemanId,
                SupportName = p.TeknikEleman.ElemanAd,
                Role = true
            }).ToListAsync();
            var modal = list1.Concat(list2).ToList();
            ViewBag.SupportId = messaging.TeknikId;
            ViewBag.MessageId = messageId;
            ViewBag.MessaginId = messagingId;
            return View(modal);
        }
      
    }
}
