using DB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;
using System.Net.Security;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Diagnostics;

namespace SaticiFirmaPaneli.Controllers
{
    public class SellerCompanyController : Controller
    {
        private readonly ILogger<SellerCompanyController> _logger;
        private readonly Task3RealEcommerceContext _context;

        public SellerCompanyController(ILogger<SellerCompanyController> logger, Task3RealEcommerceContext context)
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
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Login(string mail, string password)
        {
            if (await _context.Firmas.AnyAsync(p => p.Mail == mail))
            {
                var company = await _context.Firmas.FirstOrDefaultAsync(p => p.Mail == mail);
                if (company.Sifre == password)
                {
                    int number = SendCodeToEmail(company.Mail);
                    HttpContext.Session.SetInt32("sellerCompanyId", company.FirmaId);
                    HttpContext.Session.SetInt32("number", number);
                    return RedirectToAction("CodeVerification", "SellerCompany");
                }
                else
                {
                    return RedirectToAction("Login", "SellerCompany");
                }
            }
            else
            {
                return RedirectToAction("Login", "SellerCompany");
            }
        }
        [HttpGet]
        public ActionResult CodeVerification()
        {
            int? id = HttpContext.Session.GetInt32("sellerCompanyId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "SellerCompany");
            }


            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CodeVerification(string number)
        {
            int? id = HttpContext.Session.GetInt32("sellerCompanyId");
            if (!id.HasValue)
                return RedirectToAction("Login", "SellerCompany");
            if (number == HttpContext.Session.GetInt32("number").ToString())
                return RedirectToAction("Index", "SellerCompany");
            else
                return RedirectToAction("Login", "SellerCompany");
        }
        public async Task<ActionResult> Index()
        {

            HttpContext.Session.SetInt32("sellerCompanyId", 1);
            int? id = HttpContext.Session.GetInt32("sellerCompanyId");
            if (!id.HasValue)
                return RedirectToAction("Login", "SellerCompany");


            //var stopwatch = Stopwatch.StartNew();

            ViewBag.NewMessages = (await _context.AdmindenFirmayaMesajs.Where(p => p.OkunduBilgisi == false).CountAsync()) + (await _context.TeknikdenFirmayaMesajs.Where(p => (p.Aktiflik == true && p.OkunduBilgisi == false)).CountAsync());
            ViewBag.OrdersCount = (await _context.Siparislers.Where(p => (p.Onay == false && p.SiparisKalemlers.Any(l => l.Urun.FirmaId == id))).CountAsync());
            ViewBag.Comments = (await _context.Yorumlars.Where(p => (p.Urun.FirmaId == id && p.Aktiflik == true)).CountAsync()) + (await _context.KullaniciYorumCevaps.Where(p => (p.Aktiflik == true && p.Yorum.Urun.FirmaId == id)).CountAsync());
            ViewBag.Returns = (await _context.Iadelers.Where(p => (p.IadeTalep.Odeme.Siparis.SiparisKalemlers.Any(p => p.Urun.Firma.FirmaId == id))).CountAsync());
            ViewBag.Competition = await _context.FirmaYarismalars.Where(p => p.Aktiflik == true).CountAsync();
            ViewBag.SocialResponsibilityTask = await _context.SosyalSorumlulukGorevis.Where(p => p.Aktiflik == true).CountAsync();

            //stopwatch.Stop();
            //ViewBag.ExecutionTime = stopwatch.ElapsedMilliseconds;
            return View();
        }

    }
}
