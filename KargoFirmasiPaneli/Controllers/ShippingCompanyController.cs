using DB.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Net.Security;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System;
using KargoFirmasiPaneli.Models;
using Microsoft.EntityFrameworkCore;

namespace KargoFirmasiPaneli.Controllers
{
    public class ShippingCompanyController : Controller
    {
        private readonly ILogger<ShippingCompanyController> _logger;
        private readonly Task3RealEcommerceContext _context;
        public ShippingCompanyController(ILogger<ShippingCompanyController> logger, Task3RealEcommerceContext context)
        {
            _logger = logger;
            _context = context;
        }
        public int SendCodeToEmail(string companyMail)
        {
            Random rnd = new Random();
            int number = rnd.Next(100000, 999999 + 1);
            var superAdmin = _context.Admins.Find(1);
            string superAdminMail = superAdmin.Mail;
            string superAdminPassword = superAdmin.MailSifre;
            var cred = new NetworkCredential(superAdminMail, superAdminPassword);
            var client = new SmtpClient("smtp.gmail.com", 587);
            var msg = new System.Net.Mail.MailMessage();
            msg.To.Add(companyMail);
            msg.Subject = "Giriş Kodu";
            msg.Body = $"Lütfen bu kodu girerek hesabınıza giriş yapınız <strong>{number}</strong>  eğer siz giriş yapmadıysanız hemen şifrenizi değiştirip başadminle mail yoluyla iletişime geçiniz";
            msg.IsBodyHtml = true;
            msg.From = new MailAddress(superAdminMail, "Doğrulama kodu", Encoding.UTF8);
            client.Credentials = cred;
            client.EnableSsl = true;
            ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
            client.Send(msg);
            return number;
        }

        [HttpGet]
        public ActionResult Login()
        {



            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string companyName, string mail)
        {
            if (_context.KargoFirmas.Any(p => p.KargoFirmaAd == companyName))
            {
                var company = _context.KargoFirmas.Where(p => p.KargoFirmaAd == companyName).FirstOrDefault();
                if (company.KargoFirmaEmail == mail)
                {
                    int number = SendCodeToEmail(mail);
                    HttpContext.Session.SetInt32("shippingCompanyId", company.KargoFirmaId);
                    HttpContext.Session.SetInt32("number", number);
                    return RedirectToAction("CodeVerification", "ShippingCompany");
                }
            }
            else
            {
                return RedirectToAction("Login", "ShippingCompany");
            }

            return RedirectToAction("Login", "ShippingCompany");
        }
        [HttpGet]
        public ActionResult CodeVerification()
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
        public ActionResult CodeVerification(int _number)
        {
            int? id = HttpContext.Session.GetInt32("shippingCompanyId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "ShippingCompany");
            }

            if (_number == HttpContext.Session.GetInt32("number"))
            {
                return RedirectToAction("Index", "ShippingCompany");

            }
            return RedirectToAction("Login", "ShippingCompany");

        }
        public ActionResult Index()
        {
            int? id = HttpContext.Session.GetInt32("shippingCompanyId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "ShippingCompany");
            }
            ShippingCompanyIndexModel model = new ShippingCompanyIndexModel()
            {
                receivedMessagesCount = _context.TeknikDenKargoyaMesajs.Where(p => (p.OkunduBilgisi == false && p.Aktiflik == true)).Count() + _context.AdmindenKargoFirmasinaBilgilendirmes.Where(p => (p.OkunduBilgisi == false && p.Aktiflik == true)).Count(),
                requestedShipmentsCount = _context.IstenenKargolars.Where(p => p.Akitflik == false).Count(),
                returnRequestsInTransitCount = _context.YoldaIadeTalebis.Where(p => p.Onay == false).Count()
            };
            return View(model);
        }
        public async Task<ActionResult> ShippingCompanyInfo()
        {
            int? id = HttpContext.Session.GetInt32("shippingCompanyId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "ShippingCompany");
            }

            var company = await _context.KargoFirmas.Where(p => p.KargoFirmaId == id).Select(p => new KargoFirma
            {
                KargoFirmaId = p.KargoFirmaId,
                Aktiflik = p.Aktiflik,
                FirmaMerkezAdres = p.FirmaMerkezAdres,
                KargoFirmaAd = p.KargoFirmaAd,
                KargoFirmaEmail = p.KargoFirmaEmail,
                KargoFirmaTel = p.KargoFirmaTel,
                Ulke = p.Ulke
            }).FirstOrDefaultAsync();
            return View(company);
        }
        [HttpGet]
        public async Task<ActionResult> UpdateCompanyProfile(int companyId)
        {
            int? id = HttpContext.Session.GetInt32("shippingCompanyId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "ShippingCompany");
            }
            var profile = await _context.KargoFirmas.FirstOrDefaultAsync(p => p.KargoFirmaId == companyId);
            return View(profile);
        }
        [HttpPost]
        public async Task<ActionResult> UpdateCompanyProfile(KargoFirma company)
        {
            int? id = HttpContext.Session.GetInt32("shippingCompanyId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "ShippingCompany");
            }
            var _company = await _context.KargoFirmas.FirstOrDefaultAsync(p => p.KargoFirmaId == id);
            _company.KargoFirmaAd = company.KargoFirmaAd;
            _company.FirmaMerkezAdres = company.FirmaMerkezAdres;
            _company.KargoFirmaEmail = company.KargoFirmaEmail;
            _company.KargoFirmaTel = company.KargoFirmaTel;
            _company.Ulke = company.Ulke;
            await _context.SaveChangesAsync();
            return RedirectToAction("ShippingCompanyInfo", "ShippingCompany");
        }
        public ActionResult LogOut()
        {
            int? id = HttpContext.Session.GetInt32("shippingCompanyId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "ShippingCompany");
            }
            HttpContext.Session.Clear();

            return RedirectToAction("Login", "ShippingCompany");
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
