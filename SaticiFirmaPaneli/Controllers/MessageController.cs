using DB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using Newtonsoft.Json.Linq;
using SaticiFirmaPaneli.Models;

namespace SaticiFirmaPaneli.Controllers
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
        public async Task<ActionResult> Inbox()
        {
            int? id = HttpContext.Session.GetInt32("sellerCompanyId");
            if (!id.HasValue)
                return RedirectToAction("Login", "SellerCompany");

            ViewBag.messagesFromSupport = await _context.TeknikdenFirmayaMesajs.Where(p => (p.Aktiflik == true && p.OkunduBilgisi == false)).CountAsync();
            ViewBag.messagesFromAdmin = await _context.AdmindenFirmayaMesajs.Where(p => p.OkunduBilgisi == false).CountAsync();

            return View();
        }
        public async Task<ActionResult> MessagingsWithSupport()
        {
            int? id = HttpContext.Session.GetInt32("sellerCompanyId");
            if (!id.HasValue)
                return RedirectToAction("Login", "SellerCompany");


            var messages = await _context.TeknikdenFirmayaMesajs.Where(p => p.FirmaId == id).ToListAsync();
            var modal = messages.GroupBy(p => p.MesajlasmaId).Select(p => p.OrderByDescending(p => p.MesajlasmaId).FirstOrDefault()).Select(p => new TeknikdenFirmayaMesaj
            {
                Tarih = p.Tarih,
                MesajlasmaId = p.MesajlasmaId,
                TeknikId = p.TeknikId,
                Aktiflik = p.Aktiflik,
                FirmaId = p.FirmaId,
                Mesaj = p.Mesaj,
                MesajBaslik = p.MesajBaslik,
                MesajId = p.MesajId,
                OkunduBilgisi = p.OkunduBilgisi
            }).ToList();
            return View(modal);
        }
        public async Task<ActionResult> ReadLastMessageFromSupport(int messageId)
        {
            int? id = HttpContext.Session.GetInt32("sellerCompanyId");
            if (!id.HasValue)
                return RedirectToAction("Login", "SellerCompany");

            var message = await _context.TeknikdenFirmayaMesajs.FindAsync(messageId);
            if (message == null)
            {
                return Json(new { success = false });
            }
            else
            {
                message.OkunduBilgisi = true;
                await _context.SaveChangesAsync();
                return Json(new { success = true });
            }
        }
        public async Task<ActionResult> MessagingDetailsFromSupport(int messageId)
        {
            int? id = HttpContext.Session.GetInt32("sellerCompanyId");
            if (!id.HasValue)
                return RedirectToAction("Login", "SellerCompany");

            var messaging = await _context.TeknikdenFirmayaMesajs.FindAsync(messageId);
            int? messagingId = messaging.MesajlasmaId;
            var list1 = await _context.TeknikdenFirmayaMesajs.Where(p => (p.Aktiflik == true && p.MesajlasmaId == messagingId)).OrderByDescending(p => p.MesajId).Select(p => new MessagesWithSupportModel
            {
                ActivityStatus = p.Aktiflik,
                MessageId = p.MesajId,
                MessagingId = p.MesajlasmaId,
                CompanyId = p.FirmaId,
                Message = p.Mesaj,
                MessageTitle = p.MesajBaslik,
                ReadStatus = p.OkunduBilgisi,
                Date = p.Tarih,
                SupportId = p.TeknikId,
                SupportName = p.Teknik.ElemanAd,
                Role = false
            }).ToListAsync();
            var list2 = await _context.FirmadanTeknikElemanaMesajs.Where(p => (p.Aktiflik == true && p.MesajlasmaId == messagingId && p.FirmaId == id && p.TeknikElemanId == messaging.TeknikId)).OrderByDescending(p => p.MesajId).Select(p => new MessagesWithSupportModel
            {
                ActivityStatus = p.Aktiflik,
                MessageId = p.MesajId,
                MessagingId = p.MesajlasmaId,
                CompanyId = p.FirmaId,
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
        public async Task<ActionResult> SendResponseToSupport(FirmadanTeknikElemanaMesaj message)
        {
            int? id = HttpContext.Session.GetInt32("sellerCompanyId");
            if (!id.HasValue)
                return RedirectToAction("Login", "SellerCompany");

            await _context.FirmadanTeknikElemanaMesajs.AddAsync(new FirmadanTeknikElemanaMesaj
            {
                Aktiflik = true,
                FirmaId = id,
                Mesaj = message.Mesaj,
                MesajBaslik = message.MesajBaslik,
                MesajlasmaId = message.MesajlasmaId,
                OkunduBilgisi = false,
                Tarih = DateTime.Now,
                TeknikElemanId = message.TeknikElemanId
            });
            await _context.SaveChangesAsync();


            return Json(new { success = true });
        }
        public async Task<ActionResult> MessageDetailsFromSupport(int messageId, bool Role)
        {
            int? id = HttpContext.Session.GetInt32("sellerCompanyId");
            if (!id.HasValue)
                return RedirectToAction("Login", "SellerCompany");
            if (Role == true)
            {
                var messaging = await _context.FirmadanTeknikElemanaMesajs.FindAsync(messageId);
                if (messaging == null)
                {
                    return View("Mesaj bulunamadı");
                }
                else
                {

                    var modal = await _context.FirmadanTeknikElemanaMesajs.Where(p => (p.Aktiflik == true && p.MesajlasmaId == messaging.MesajlasmaId && p.TeknikElemanId == messaging.TeknikElemanId && p.FirmaId == id)).Select(p => new MessagesWithSupportModel
                    {
                        ActivityStatus = p.Aktiflik,
                        CompanyId = p.FirmaId,
                        Date = p.Tarih,
                        Message = p.Mesaj,
                        MessageId = p.MesajId,
                        MessageTitle = p.MesajBaslik,
                        MessagingId = p.MesajlasmaId,
                        ReadStatus = p.OkunduBilgisi,
                        Role = true,
                        SupportId = p.TeknikElemanId,
                        SupportName = p.TeknikEleman.ElemanAd
                    }).FirstOrDefaultAsync();
                    return View(modal);
                }
            }
            else if (Role == false)
            {
                var messaging = await _context.TeknikdenFirmayaMesajs.FindAsync(messageId);
                if (messaging == null)
                {
                    return View("Mesaj bulunamadı");
                }
                else
                {

                    var modal = await _context.TeknikdenFirmayaMesajs.Where(p => (p.Aktiflik == true && p.MesajlasmaId == messaging.MesajlasmaId && p.TeknikId == messaging.TeknikId && p.FirmaId == id)).Select(p => new MessagesWithSupportModel
                    {
                        ActivityStatus = p.Aktiflik,
                        CompanyId = p.FirmaId,
                        Date = p.Tarih,
                        Message = p.Mesaj,
                        MessageId = p.MesajId,
                        MessageTitle = p.MesajBaslik,
                        MessagingId = p.MesajlasmaId,
                        ReadStatus = p.OkunduBilgisi,
                        Role = false,
                        SupportId = p.Teknik.TeknikElemanId,
                        SupportName = p.Teknik.ElemanAd
                    }).FirstOrDefaultAsync();
                    return View(modal);
                }
            }
            return View("Sayfa Bulunamadı");
        }
        public async Task<ActionResult> MarkAsReadMessageFromSupport(int messageId)
        {
            int? id = HttpContext.Session.GetInt32("sellerCompanyId");
            if (!id.HasValue)
                return RedirectToAction("Login", "SellerCompany");

            var mesaj = await _context.TeknikdenFirmayaMesajs.FindAsync(messageId);
            if (mesaj == null)
            {
                return Json(new { success = false });
            }
            else
            {
                mesaj.OkunduBilgisi = true;
                await _context.SaveChangesAsync();
                return Json(new { success = true });
            }
        }
        public async Task<ActionResult> MessagesFromAdmin()
        {
            int? id = HttpContext.Session.GetInt32("sellerCompanyId");
            if (!id.HasValue)
                return RedirectToAction("Login", "SellerCompany");

            var messages = await _context.AdmindenFirmayaMesajs.Where(p => p.FirmaId == id).OrderByDescending(p => p.MesajId).ToListAsync();

            return View(messages);
        }
        [HttpGet]
        public ActionResult MessageToSupport()
        {
            int? id = HttpContext.Session.GetInt32("sellerCompanyId");
            if (!id.HasValue)
                return RedirectToAction("Login", "SellerCompany");




            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> MessageToSupport(FirmadanTeknikElemanaMesaj message)
        {
            int? id = HttpContext.Session.GetInt32("sellerCompanyId");
            if (!id.HasValue)
                return RedirectToAction("Login", "SellerCompany");

            var support = await _context.TeknikElemanlars.Where(p => p.Aktiflik == true).OrderBy(p => Guid.NewGuid()).FirstOrDefaultAsync();

            await _context.Mesajlasmas.AddAsync(new Mesajlasma
            {
                Tarih = DateTime.Now
            });
            await _context.SaveChangesAsync();
            var messaging = await _context.Mesajlasmas.OrderByDescending(p => p.MesajlasmaId).FirstOrDefaultAsync();
            await _context.FirmadanTeknikElemanaMesajs.AddAsync(new FirmadanTeknikElemanaMesaj
            {
                Aktiflik = true,
                Tarih = DateTime.Now,
                FirmaId = id,
                Mesaj = message.Mesaj,
                MesajBaslik = message.MesajBaslik,
                MesajlasmaId = messaging.MesajlasmaId,
                OkunduBilgisi = false,
                TeknikElemanId = support.TeknikElemanId
            });
            await _context.SaveChangesAsync();


            return RedirectToAction("Index", "SellerCompany");
        }
    }
}
