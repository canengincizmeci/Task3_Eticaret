using DB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;
using System.Net.Security;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System;

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

        //Hesaba 3 defa yanlış şifreyle girildiğinde admine gönderilen mail
        public void HataliGirisMail(string adminMail)
        {
            var admin = _context.Admins.Where(p => p.Mail == adminMail).FirstOrDefault();
            var basAdmin = _context.Admins.Find(1);
            string basAdminMail = basAdmin.Mail;
            string basAdminMailSifre = basAdmin.MailSifre;
            var cred = new NetworkCredential(basAdminMail, basAdminMailSifre);
            var client = new SmtpClient("smtp.gmail.com", 587);
            var msg = new System.Net.Mail.MailMessage();
            msg.To.Add(adminMail);
            msg.Subject = "Hatalı giriş bildirimi";
            msg.Body = $"Hesabınıza 3 defa üst üste hatalı  şifre girişi yapılmıştır eğer siz değilseniz <strong>Lütfen Baş adminle mail yoluyla iletişime geçiniz</strong>";
            msg.IsBodyHtml = true;
            msg.From = new MailAddress(basAdminMail, "Doğrulama kodu", Encoding.UTF8);
            client.Credentials = cred;
            client.EnableSsl = true;
            ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
            client.Send(msg);

        }

        //Admin Login Bilgilerini doğru girerse mailine 6 haneli kod gönderen bir metot
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

        public bool SonUcGirisKontolu(int adminId)
        {
            List<AdminLoginGirisler> sonUcGiris = _context.AdminLoginGirislers.OrderByDescending(p => p.GirisId).Where(p => p.AdminId == adminId).Take(3).ToList();
            int sayac = 0;
            bool izin = true;
            // giriş başarısı false ise sayacaımı artırıyorum
            foreach (var giris in sonUcGiris)
            {
                if (giris.Basari == false)
                {
                    sayac++;
                }
            }

            //Son giriş tarihini alıyorum
            DateTime? sonGiris = _context.AdminLoginGirislers.OrderByDescending(p => p.GirisId).Where(p => p.AdminId == adminId).First().Tarih;
            if (sonGiris.HasValue)
            {
                //son girişin üzerinden bir saat geçmeden tekrar girişe izin vermemek için geri dönüş değerini false vericem
                DateTime simdikiZaman = DateTime.Now;
                TimeSpan gecenSure = simdikiZaman - sonGiris.Value;
                if (gecenSure.TotalHours < 1)
                {
                    izin = false;
                }

            }

            //Eğer son 3 giriş başarısız ve son giriş denemesi üzerinden 1 saat geçmediyse login e gerekli parametreleri gönderiyorum
            if (sayac == 3 && izin == false)
            {
                return false;
            }
            else
            {
                return true;

            }
        }



        //Mevcut bir admin mailiyle 3 defa başarısız giriş yapılmışsa mesaj ve aktiflik parametreleriyle ViewBag aracılığyla butonu unenabled yapıp uyarı mesajı gönderen Parametre almadığında normal bir şekilde çalışan Login metodu
        [HttpGet]
        public ActionResult Login(string mesaj = "Admin", bool aktiflik = true)
        {

            if (aktiflik == false)
            {
                ViewBag.Aktiflik = false;
                ViewBag.Mesaj = mesaj;
            }
            else
            {
                ViewBag.Aktiflik = true;
                ViewBag.Mesaj = mesaj;
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string adminMail, string adminSifre)
        {

            //Mail kontrolü yapılıyor
            if (_context.Admins.Any(x => x.Mail == adminMail))
            {
                //Maili girilen admin verisi alınıyor
                var admin = _context.Admins.Where(p => p.Mail == adminMail).FirstOrDefault();
                if (admin.Aktiflik == false)
                {
                    return RedirectToAction("Login", new { mesaj = "Güvenliğiniz için hesabınız dondurulmuştur.Eğer hatalı bir durumla karşı karşıyasanız lütfen baş Adminle mail yoluyla iletişime geçiniz" });
                }

                //şifre kontrolu yapılıyor
                if (admin.AdminSifre != adminSifre)
                {
                    bool kontrol = SonUcGirisKontolu(admin.AdminId);
                    if (!kontrol)
                    {
                        admin.Aktiflik = false;
                        _context.SaveChanges();
                        HataliGirisMail(adminMail);
                        return RedirectToAction("Login", new { mesaj = "Güvenliğiniz için hesabınız dondurulmuştur.Eğer hatalı bir durumla karşı karşıyasanız lütfen baş Adminle mail yoluyla iletişime geçiniz", aktiflik = false });
                    }
                    ////Aynı maille 3 defa üst üste yanlış şifre girildi mi diye kontrol edicez bunun için son 3 giriş verisini alıyorum
                    //int adminId = admin.AdminId;
                    //List<AdminLoginGirisler> sonUcGiris = _context.AdminLoginGirislers.OrderByDescending(p => p.GirisId).Where(p => p.AdminId == adminId).Take(3).ToList();
                    //int sayac = 0;
                    //bool izin = true;
                    //// giriş başarısı false ise sayacaımı artırıyorum
                    //foreach (var giris in sonUcGiris)
                    //{
                    //    if (giris.Basari == false)
                    //    {
                    //        sayac++;
                    //    }
                    //}

                    ////Son giriş tarihini alıyorum
                    //DateTime? sonGiris = _context.AdminLoginGirislers.OrderByDescending(p => p.GirisId).First().Tarih;
                    //if (sonGiris.HasValue)
                    //{
                    //    //son girişin üzerinden bir saat geçmeden tekrar girişe izin vermemek için logine gönderceğim parametreleri oluşturup değer atıyorum
                    //    DateTime simdikiZaman = DateTime.Now;
                    //    TimeSpan gecenSure = simdikiZaman - sonGiris.Value;
                    //    if (gecenSure.TotalHours < 1)
                    //    {
                    //        izin = false;
                    //    }

                    //}


                    ////Eğer son 3 giriş başarısız ve son giriş denemesi üzerinden 1 saat geçmediyse login e gerekli parametreleri gönderiyorum
                    //if (sayac == 3 && izin == false)
                    //{
                    //    return RedirectToAction("Login", new { mesaj = "Güvenliğiniz için hesabınıza 1 saat giriş yapamazsınız.Eğer hatalı bir durumla karşı karşıyasanız lütfen baş Adminle mail yoluyla iletişime geçiniz", aktiflik = false });
                    //}
                    ////Eğer daha 3 başarısız yoksa ve 1 saatten fazla süre geçmişse AdminGirişler tablosuna bir başarısız giriş daha yapılıyor
                    //else
                    //{
                    _context.AdminLoginGirislers.Add(new AdminLoginGirisler
                    {
                        AdminId = admin.AdminId,
                        Tarih = DateTime.Now,
                        Basari = false
                    });
                    _context.SaveChanges();
                    //Ve sonrasında Login sayfasına redirect işlemi yapılıyor
                    return RedirectToAction("Login");
                    //}





                }
                else
                {
                    //Admin girişler tablosuna başarılı bir giriş verisi yapılıyor
                    _context.AdminLoginGirislers.Add(new AdminLoginGirisler
                    {
                        AdminId = admin.AdminId,
                        Tarih = DateTime.Now,
                        Basari = true
                    });
                    //Adminin ıd değeri session ile saklanıyor
                    HttpContext.Session.SetInt32("adminId", admin.AdminId);

                    //Giriş yapan adminin mail adresine giriş kodu gönderiiliyor
                    int kod = GirisKodDogrulama(adminMail);
                    //Giriş kodu da session ile tutuluyor
                    HttpContext.Session.SetInt32("girisKod", kod);
                    //Kod doğrulama ekranına redirect işlemi yapılıyor
                    return RedirectToAction("KodDogrulama");


                }
            }
            //Admin mail doğru değilse Login sayfasına hiçbir kontrol olmadan geri dön
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
            //Eğer session değeri yoksa oturum süresi yok yada birisi url yazarak ulaşmaya çalışıyorsa login sayfasına yönlendirme yapıyorum
            int? id = HttpContext.Session.GetInt32("adminId");
            if (id.HasValue)
            {
                var admin = _context.Admins.Find(id);

            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
            //Session ile tuttuğum girişkod değerini alıyorum ve kullanıcının girdiği değer ile eşit mi diye kontrol ediyorum
            int? _kod = HttpContext.Session.GetInt32("girisKod");
            if (_kod.HasValue)
            {
                if (kod == _kod.ToString())
                {
                    //Eğer sonuç true ise AdminMailGirişler tablosuna bir başarılı giriş verisi ekliyorum
                    _context.AdminMailGirislers.Add(new AdminMailGirisler
                    {
                        AdminId = id,
                        Basari = true,
                        Tarih = DateTime.Now
                    });
                    //Sonrasında admin için olan index sayfasına redirect ediyorum
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    //Eğer sonuc false ise yani kullanicinin girdiği kod yanlış ise AdminMailGirisler tablosuna başarısız bir giriş ekliyorum
                    _context.AdminMailGirislers.Add(new AdminMailGirisler
                    {
                        AdminId = id,
                        Basari = false,
                        Tarih = DateTime.Now
                    });
                    //Sonrasında son 3 giriş yanlış ve son giriş üzerinden 1 saat geçmemiş ise login sayfasına uyarı mesajlarımızla göndericez
                    List<AdminMailGirisler> sonUcGiris = _context.AdminMailGirislers.OrderByDescending(x => x.GirisId).Take(3).ToList();
                    int sayac = 0;
                    bool izin = true;
                    foreach (var giris in sonUcGiris)
                    {
                        if (giris.Basari == false)
                        {
                            sayac++;
                        }
                    }
                    //Son girişten sonra 1 saat geçip geçmediği kontrol ediliyor
                    DateTime? sonGiris = _context.AdminLoginGirislers.OrderByDescending(p => p.GirisId).First().Tarih;
                    if (sonGiris.HasValue)
                    {
                        DateTime simdikiZaman = DateTime.Now;
                        TimeSpan gecenSure = simdikiZaman - sonGiris.Value;
                        if (gecenSure.TotalHours < 1)
                        {
                            izin = false;
                        }

                    }
                    //Eğer son 3 kod girişi başarısız ve son giriş üzerinden 1 saat geçmediyse login sayfasına uyarı mesajı ile redirect yapılır
                    if (sayac == 3 && izin == false)
                    {
                        return RedirectToAction("Login", new { mesaj = "Güvenliğiniz için hesabınıza 1 saat giriş yapamazsınız.Eğer hatalı bir durumla karşı karşıyasanız lütfen baş Adminle mail yoluyla iletişime geçiniz", aktiflik = false });
                    }

                    return RedirectToAction("Login", "Home");
                }
            }
            //Session ile alınan kod değeri null ise bir hata olacağı için login sayfasına yönlendirme yapılır
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
