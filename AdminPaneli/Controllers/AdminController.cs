using DB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;
using System.Net.Security;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace AdminPaneli.Controllers
{
    public class AdminController : Controller
    {
        private readonly ILogger<AdminController> _logger;
        private readonly Task3RealEcommerceContext _context;

        public AdminController(ILogger<AdminController> logger, Task3RealEcommerceContext context)
        {
            _logger = logger;
            _context = context;
        }

        public int GirisKodDogrulama(string kullaniciMail)
        {
            Random rnd = new Random();
            int random = rnd.Next(100000, 999999 + 1);
            var admin = _context.Admins.Find(1);
            string basAdminMail = admin.Mail;
            string basAdminMailSifre = admin.MailSifre;
            var cred = new NetworkCredential(basAdminMail, basAdminMailSifre);
            var client = new SmtpClient("smtp.gmail.com", 587);
            var msg = new System.Net.Mail.MailMessage();
            msg.To.Add(kullaniciMail);
            msg.Subject = "Kayıt onay kodu";
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
        public ActionResult Login(string mesaj = "Admin", bool aktiflik = true)
        {
            if (aktiflik == false)
            {
                ViewBag.Aktiflik = "AktifDegil";
                ViewBag.Mesaj = mesaj;
            }
            else
            {
                ViewBag.Aktiflik = "Aktif";
                ViewBag.Mesaj = mesaj;
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string adminMail, string adminSifre)
        {
            if (_context.Admins.Any(x => x.Mail == adminMail))
            {
                List<AdminLoginGirisler> sonUcGiris = _context.AdminLoginGirislers.OrderByDescending(p => p.GirisId).Take(3).ToList();
                int sayac = 0;
                bool izin = true;
                foreach (var giris in sonUcGiris)
                {
                    if (giris.Basari == true)
                    {
                        sayac++;
                    }
                }
                if (_context.AdminLoginGirislers.OrderBy(p => p.GirisId).First().Tarih.HasValue)
                {
                    DateTime? sonGiris = _context.AdminLoginGirislers.OrderBy(p => p.GirisId).First().Tarih;
                    if (sonGiris.HasValue)
                    {
                        DateTime simdikiZaman = DateTime.Now;
                        TimeSpan gecenSure = simdikiZaman - sonGiris.Value;
                        if (gecenSure.TotalHours < 1)
                        {
                            izin = false;
                        }

                    }

                }

                if (sayac == 3 && izin == false)
                {
                    return RedirectToAction("Login", new { mesaj = "Güvenliğiniz için hesabınıza 1 saat giriş yapamazsınız.Eğer hatalı bir durumla karşı karşıyasanız lütfen baş Adminle mail yoluyla iletişime geçiniz", aktiflik = false });
                }

                var admin = _context.Admins.Where(x => x.Mail == adminMail).FirstOrDefault();

                if (admin.AdminSifre == adminSifre)
                {
                    _context.AdminLoginGirislers.Add(new AdminLoginGirisler
                    {
                        AdminId = admin.AdminId,
                        Tarih = DateTime.Now,
                        Basari = true
                    });
                    HttpContext.Session.SetInt32("adminId", admin.AdminId);

                    int? id = HttpContext.Session.GetInt32("adminId");
                    int kod = GirisKodDogrulama(adminMail);

                    HttpContext.Session.SetInt32("girisKod", kod);
                    return RedirectToAction("KodDogrulama");
                }
                else
                {
                    _context.AdminLoginGirislers.Add(new AdminLoginGirisler
                    {
                        AdminId = admin.AdminId,
                        Tarih = DateTime.Now,
                        Basari = false
                    });
                    return RedirectToAction("Login");
                }

            }
            else
            {
                return RedirectToAction("Login");
            }

        }
        [HttpGet]
        public ActionResult KodDogrulama()
        {


            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult KodDogrulama(string kod)
        {
            int? id = HttpContext.Session.GetInt32("adminId");
            if (id.HasValue)
            {
                var admin = _context.Admins.Find(id);

            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
            int? _kod = HttpContext.Session.GetInt32("girisKod");
            if (_kod.HasValue)
            {
                if (kod == _kod.ToString())
                {
                    _context.AdminMailGirislers.Add(new AdminMailGirisler
                    {
                        AdminId = id,
                        Basari = true,
                        Tarih = DateTime.Now
                    });
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    _context.AdminMailGirislers.Add(new AdminMailGirisler
                    {
                        AdminId = id,
                        Basari = true,
                        Tarih = DateTime.Now
                    });
                    return RedirectToAction("Login", "Home");
                }
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }
        public IActionResult Index()
        {
            int? id = HttpContext.Session.GetInt32("adminId");
            var admin = _context.Admins.Find(id);
            return View();
        }
    }
}
