using DB.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Net.Security;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace TeknikDestekElemanPaneli.Controllers
{
    public class TeknikElemanController : Controller
    {
        private readonly ILogger<TeknikElemanController> _logger;
        private readonly Task3RealEcommerceContext _context;
        public TeknikElemanController(ILogger<TeknikElemanController> logger, Task3RealEcommerceContext context)
        {
            _logger = logger;
            _context = context;
        }

        public int GirisKodDogrula(string teknikElemanMail)
        {
            Random rnd = new Random();
            int random = rnd.Next(100000, 999999 + 1);
            var admin = _context.Admins.Find(1);
            string basAdminMail = admin.Mail;
            string basAdminMailSifre = admin.MailSifre;
            var cred = new NetworkCredential(basAdminMail, basAdminMailSifre);
            var client = new SmtpClient("smtp.gmail.com", 587);
            var msg = new System.Net.Mail.MailMessage();
            msg.To.Add(teknikElemanMail);
            msg.Subject = "Giriş Kodu";
            msg.Body = $"Lütfen bu kodu girerek hesabınıza giriş yapınız <strong>{random}</strong>  eğer siz giriş yapmadıysanız hemen şifrenizi değiştirip başadminle mail yoluyla iletişime geçiniz";
            msg.IsBodyHtml = true;
            msg.From = new MailAddress(basAdminMail, "Doğrulama kodu", Encoding.UTF8);
            client.Credentials = cred;
            client.EnableSsl = true;
            ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
            client.Send(msg);
            return random;
        }


        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string teknikElemanMail, string sifre)
        {
            if (_context.TeknikElemanlars.Any(p => p.Mail == teknikElemanMail))
            {
                var eleman = _context.TeknikElemanlars.FirstOrDefault(p => p.Mail == teknikElemanMail);
                if (eleman.Sifre == sifre)
                {
                    int kod = GirisKodDogrula(teknikElemanMail);
                    HttpContext.Session.SetInt32("teknikElemanId", eleman.TeknikElemanId);
                    HttpContext.Session.SetInt32("kod", kod);
                    return RedirectToAction("GirisKodDogrulama", "TeknikEleman");
                }
                else
                {
                    return RedirectToAction("Login", "TeknikEleman");
                }
            }
            else
            {
                return RedirectToAction("Login", "TeknikEleman");
            }
        }
        [HttpGet]
        public ActionResult GirisKodDogrulama()
        {
            int? id = HttpContext.Session.GetInt32("teknikElemanId");
            int? kod = HttpContext.Session.GetInt32("kod");
            if (!id.HasValue || !kod.HasValue)
            {
                return RedirectToAction("Login", "TeknikEleman");
            }


            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GirisKodDogrulama(int kod)
        {
            int? id = HttpContext.Session.GetInt32("teknikElemanId");
            int? _kod = HttpContext.Session.GetInt32("kod");
            if (!id.HasValue || !_kod.HasValue)
            {
                return RedirectToAction("Login", "Admin");
            }
            if (kod == _kod)
            {
                _context.TeknikElemanGirislers.Add(new TeknikElemanGirisler
                {
                    ElemanId = id,
                    GirisBasariDurumu = true,
                    Tarih = DateTime.Now
                });
                _context.SaveChanges();
                return RedirectToAction("Index", "TeknikEleman");
            }
            else
            {
                return RedirectToAction("Login", "TeknikEleman");
            }

        }
        public ActionResult Index()
        {
            int? id = HttpContext.Session.GetInt32("TeknikElemanId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "Admin");
            }





            return View();
        }
    }
}
