using DB.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Net.Security;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System;
using KargoFirmasiPaneli.Models;

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
                returnRequestsInTransitCount = _context.YoldaIadeTalebis.Where(p => p.Onay == true).Count()
            };
            return View(model);
        }

    }
}
