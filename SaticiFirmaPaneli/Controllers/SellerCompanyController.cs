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
using SaticiFirmaPaneli.Models;
using Microsoft.VisualBasic;

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

          
            int? id = HttpContext.Session.GetInt32("sellerCompanyId");
            if (!id.HasValue)
                return RedirectToAction("Login", "SellerCompany");


            //var stopwatch = Stopwatch.StartNew();






            SellerCompanyIndexModel modal = new SellerCompanyIndexModel()
            {
                newMessagesCount = (await _context.AdmindenFirmayaMesajs.Where(p => p.OkunduBilgisi == false).CountAsync()) + (await _context.TeknikdenFirmayaMesajs.Where(p => (p.Aktiflik == true && p.OkunduBilgisi == false)).CountAsync()),

                currentCompetitionCount = await _context.FirmaYarismalars.Where(p => (p.Aktiflik == true && p.BaslangicTarih < DateTime.Now && p.BitisTarih > DateTime.Now)).CountAsync(),
                newOrdersCount = (await _context.Siparislers.Where(p => (p.Onay == null && p.SiparisKalemlers.Any(l => l.Urun.FirmaId == id))).CountAsync()),
                socialResponsibiltyTasksCount = await _context.SosyalSorumlulukGorevis.Where(p => p.Aktiflik == true).CountAsync(),
                newReturnsCount = (await _context.Iadelers.Where(p => (p.IadeTalep.Odeme.Siparis.SiparisKalemlers.Any(p => p.Urun.Firma.FirmaId == id))).CountAsync()),
                productsCount = await _context.Uruns.Where(p => (p.Aktiflik == true && p.FirmaId == id)).CountAsync(),
                requestedCampaignsCount = (await _context.KategoriKampanyalars.Where(p => p.Aktiflik == true).CountAsync()) + (await _context.UrunKampanyalars.Where(p => p.Aktiflik == true).CountAsync()) + (await _context.FirmaKampanyalars.Where(p => (p.Aktiflik == true && p.FirmaId == id)).CountAsync()) + (await _context.GenelKampanyalars.Where(p => p.Aktiflik == true).CountAsync()),
                favoritedProductsCount = await _context.Favorilers.Where(p => (p.Aktiflik == true && p.Urun.FirmaId == id)).CountAsync()
            };


            //stopwatch.Stop();
            //ViewBag.ExecutionTime = stopwatch.ElapsedMilliseconds;
            return View(modal);
        }
        public async Task<ActionResult> CompanySocialMediaAccounts()
        {
            int? id = HttpContext.Session.GetInt32("sellerCompanyId");
            if (!id.HasValue)
                return RedirectToAction("Login", "SellerCompany");
            var modal = await _context.FirmaSosyalMedyalars.Where(p => (p.FirmaId == id && p.Aktiflik == true)).ToListAsync();
            return View(modal);
        }
        [HttpPost]
        public async Task<ActionResult> AddCompanySocialMediaAccount(FirmaSosyalMedyalar accountInfo)
        {
            int? id = HttpContext.Session.GetInt32("sellerCompanyId");
            if (!id.HasValue)
                return RedirectToAction("Login", "SellerCompany");


            await _context.FirmaSosyalMedyalars.AddAsync(new FirmaSosyalMedyalar
            {
                Aktiflik = true,
                EklenmeTarihi = DateTime.Now,
                FirmaId = id,
                SosyalMedyaIsmi = accountInfo.SosyalMedyaIsmi,
                UrlAdresi = accountInfo.UrlAdresi
            });
            await _context.SaveChangesAsync();
            return Json(new { success = true });
        }
        [HttpPost]
        public async Task<ActionResult> DeleteCompanySocialMediaAccount(int accountId)
        {
            int? id = HttpContext.Session.GetInt32("sellerCompanyId");
            if (!id.HasValue)
                return RedirectToAction("Login", "SellerCompany");

            var account = await _context.FirmaSosyalMedyalars.FindAsync(accountId);
            if (account == null)
            {
                return Json(new { success = false });

            }
            else
            {
                account.Aktiflik = false;
                await _context.SaveChangesAsync();
                return Json(new { success = true });
            }
        }
        [HttpGet]
        public ActionResult ChangePassword()
        {
            int? id = HttpContext.Session.GetInt32("sellerCompanyId");
            if (!id.HasValue)
                return RedirectToAction("Login", "SellerCompany");

            return View();
        }
        [HttpPost]
        public async Task<ActionResult> ChangePassword(string newPassword, string currentPassword)
        {
            int? id = HttpContext.Session.GetInt32("sellerCompanyId");
            if (!id.HasValue)
                return RedirectToAction("Login", "SellerCompany");

            var company = await _context.Firmas.FindAsync(id);
            if (company == null)
            {
                return Json(new { success = false, message = "Bir hata oluştu" });
            }
            else
            {
                if (currentPassword != company.Sifre)
                {
                    return Json(new { success = false, message = "Mevcut şifrenizi yanlış girdiniz" });

                }
                else
                {
                    company.Sifre = newPassword;
                    await _context.SaveChangesAsync();
                    return Json(new { success = true, message = "Şifre Başarıyla değiştirildi" });
                }
            }
        }
        public async Task<ActionResult> CompanyProfile()
        {
            int? id = HttpContext.Session.GetInt32("sellerCompanyId");
            if (!id.HasValue)
                return RedirectToAction("Login", "SellerCompany");

            var modal = await _context.Firmas.FindAsync(id);



            return View(modal);
        }
        [HttpPost]
        public async Task<ActionResult> UpdateCompany(Firma _company)
        {
            int? id = HttpContext.Session.GetInt32("sellerCompanyId");
            if (!id.HasValue)
                return RedirectToAction("Login", "SellerCompany");

            var company = await _context.Firmas.FindAsync(_company.FirmaId);
            if (company == null)
            {
                return Json(new { success = false });
            }
            else
            {
                company.FirmaAd = _company.FirmaAd;
                company.FirmaAdres = _company.FirmaAdres;
                company.Mail = _company.Mail;
                company.TelefonNumarasi = _company.TelefonNumarasi;
                await _context.SaveChangesAsync();
                return Json(new { success = true });
            }
        }
        public ActionResult Logout()
        {
            int? id = HttpContext.Session.GetInt32("sellerCompanyId");
            if (!id.HasValue)
                return RedirectToAction("Login", "SellerCompany");

            HttpContext.Session.Clear();

            return RedirectToAction("Login", "SellerCompany");
        }
    }
}
