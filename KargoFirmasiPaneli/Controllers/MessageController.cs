using DB.Models;
using KargoFirmasiPaneli.Models;
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
        public ActionResult MessagesFromSupport()
        {
            int? id = HttpContext.Session.GetInt32("shippingCompanyId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "ShippingCompany");
            }
            var model = _context.TeknikDenKargoyaMesajs.Where(p => p.KargoFirmaId == id).GroupBy(p => p.MesajlasmaId).ToList().Select(p => p.OrderByDescending(p => p.MesajId).FirstOrDefault()).ToList().Select(p => new TeknikDenKargoyaMesaj
            {
                Aktiflik = p.Aktiflik,
                MesajId = p.MesajId,
                KargoFirmaId = p.KargoFirmaId,
                Mesaj = p.Mesaj,
                MesajBaslik = p.MesajBaslik,
                MesajlasmaId = p.MesajlasmaId,
                TeknikElemanId = p.TeknikElemanId,
                OkunduBilgisi = p.OkunduBilgisi,
                Tarih = p.Tarih
            }).ToList();
            return View(model);
        }
        public ActionResult MessagingDetailsFromSupport(int messageId)
        {
            int? id = HttpContext.Session.GetInt32("shippingCompanyId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "ShippingCompany");
            }
            CompanyAndSupportMessagingModel model = new CompanyAndSupportMessagingModel()
            {
                supportId = _context.TeknikDenKargoyaMesajs.Find(messageId).TeknikElemanId,
                messageId = messageId,
                messagingId = _context.TeknikDenKargoyaMesajs.Find(messageId).MesajlasmaId,
                messagesList = (_context.KargodanTeknikElemanaMesajs.Where(p => (p.Aktiflik == true && p.KargoFirmaId == id && p.TeknikElemanId == _context.TeknikDenKargoyaMesajs.Find(messageId).TeknikElemanId && p.MesajlasmaId == _context.TeknikDenKargoyaMesajs.Find(messageId).MesajlasmaId)).OrderByDescending(p => p.MesajId).Select(p => new MessagingBetweenCompanyAndSupportListModel
                {
                    MesajId = p.MesajId,
                    TeknikElemanId = p.TeknikElemanId,
                    KargoFirmaId = p.KargoFirmaId,
                    Aktiflik = p.Aktiflik,
                    MesajBaslik = p.MesajBaslik,
                    Mesaj = p.Mesaj,
                    MesajlasmaId = p.MesajlasmaId,
                    OkunduBilgisi = p.OkunduBilgisi,
                    Tarih = p.Tarih,
                    TeknikElemanAd = p.TeknikEleman.ElemanAd,
                    Role = true
                }).ToList().Concat(_context.TeknikDenKargoyaMesajs.Where(p => (p.KargoFirmaId == id && p.Aktiflik == true && p.TeknikElemanId == (_context.TeknikDenKargoyaMesajs.Find(messageId).TeknikElemanId) && p.MesajlasmaId == _context.TeknikDenKargoyaMesajs.Find(messageId).MesajlasmaId)).OrderByDescending(p => p.MesajId).Select(p => new MessagingBetweenCompanyAndSupportListModel
                {
                    MesajId = p.MesajId,
                    TeknikElemanId = p.TeknikElemanId,
                    KargoFirmaId = p.KargoFirmaId,
                    Aktiflik = p.Aktiflik,
                    MesajBaslik = p.MesajBaslik,
                    Mesaj = p.Mesaj,
                    MesajlasmaId = p.MesajlasmaId,
                    OkunduBilgisi = p.OkunduBilgisi,
                    Tarih = p.Tarih,
                    TeknikElemanAd = p.TeknikEleman.ElemanAd,
                    Role = false
                }).ToList()).ToList())
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SendResponseToSupport(KargodanTeknikElemanaMesaj message)
        {
            int? id = HttpContext.Session.GetInt32("shippingCompanyId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "ShippingCompany");
            }
            _context.KargodanTeknikElemanaMesajs.Add(new KargodanTeknikElemanaMesaj
            {
                Aktiflik = true,
                KargoFirmaId = id,
                Mesaj = message.Mesaj,
                MesajBaslik = message.MesajBaslik,
                MesajlasmaId = message.MesajlasmaId,
                TeknikElemanId = message.TeknikElemanId,
                OkunduBilgisi = false,
                Tarih = DateTime.Now
            });
            _context.SaveChanges();
            return RedirectToAction("MessagingDetailsFromSupport", "Message", new { messageId = message.MesajId });
        }
        public ActionResult ReadLastMessageFromSupport(int messageId)
        {
            int? id = HttpContext.Session.GetInt32("shippingCompanyId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "ShippingCompany");
            }
            _context.TeknikDenKargoyaMesajs.Find(messageId).OkunduBilgisi = true;
            _context.SaveChanges();

            return RedirectToAction("MessagesFromSupport", "Message");
        }
        public ActionResult MessageDetailsFromSupport(int messageId, bool Role)
        {
            int? id = HttpContext.Session.GetInt32("shippingCompanyId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "ShippingCompany");
            }
            if (Role == true)
            {
                var model = _context.KargodanTeknikElemanaMesajs.Where(p => p.MesajId == messageId).Select(p => new MessagingBetweenCompanyAndSupportListModel
                {
                    Aktiflik = p.Aktiflik,
                    MesajId = p.MesajId,
                    KargoFirmaId = p.KargoFirmaId,
                    Mesaj = p.Mesaj,
                    MesajBaslik = p.MesajBaslik,
                    MesajlasmaId = p.MesajlasmaId,
                    OkunduBilgisi = p.OkunduBilgisi,
                    Role = true,
                    TeknikElemanAd = p.TeknikEleman.ElemanAd,
                    Tarih = p.Tarih,
                    TeknikElemanId = p.TeknikElemanId
                }).FirstOrDefault();
                return View(model);
            }
            else
            {
                var model = _context.TeknikDenKargoyaMesajs.Where(p => p.MesajId == messageId).Select(p => new MessagingBetweenCompanyAndSupportListModel
                {
                    Aktiflik = p.Aktiflik,
                    MesajId = p.MesajId,
                    KargoFirmaId = p.KargoFirmaId,
                    Mesaj = p.Mesaj,
                    MesajBaslik = p.MesajBaslik,
                    MesajlasmaId = p.MesajlasmaId,
                    OkunduBilgisi = p.OkunduBilgisi,
                    Role = false,
                    TeknikElemanAd = p.TeknikEleman.ElemanAd,
                    Tarih = p.Tarih,
                    TeknikElemanId = p.TeknikElemanId
                }).FirstOrDefault();
                return View(model);
            }
        }
        public ActionResult MarkAsReadMessageFromSupport(int messageId)
        {
            int? id = HttpContext.Session.GetInt32("shippingCompanyId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "ShippingCompany");
            }

            _context.TeknikDenKargoyaMesajs.Find(messageId).OkunduBilgisi = true;
            _context.SaveChanges();
            return RedirectToAction("MessageDetailsFromSupport", "Message", new { messageId = messageId, Role = false });
        }
        [HttpGet]
        public ActionResult ComplaintAboutSupport(int supportId)
        {
            int? id = HttpContext.Session.GetInt32("shippingCompanyId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "ShippingCompany");
            }
            ViewBag.SupportId = supportId;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ComplaintAboutSupport(KargoFirmadanTeknikElmanSikayeti complaint)
        {
            int? id = HttpContext.Session.GetInt32("shippingCompanyId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "ShippingCompany");
            }
            await _context.KargoFirmadanTeknikElmanSikayetis.AddAsync(new KargoFirmadanTeknikElmanSikayeti
            {
                Aktiflik = true,
                KargoFirmaId = id,
                SikayetBaslik = complaint.SikayetBaslik,
                SikayetMetni = complaint.SikayetMetni,
                TeknikElemanId = complaint.TeknikElemanId,
                Tarih = DateTime.Now
            });
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "ShippingCompany");
        }

    }
}
