using DB.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Net.Security;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Microsoft.VisualBasic;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;

namespace SatisPaneli.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly Task3RealEcommerceContext _context;
        private readonly IMemoryCache _memoryCache;
        public UserController(ILogger<UserController> logger, Task3RealEcommerceContext context, IMemoryCache memoryCache)
        {
            _logger = logger;
            _context = context;
            _memoryCache = memoryCache;
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
            msg.Body = $"Lütfen bu kodu girerek hesabınıza giriş yapınız <strong>{number}</strong>  eğer siz giriş yapmadıysanız hemen şifrenizi değiştirip destek personelimizle mail yoluyla iletişime geçiniz";
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
        public async Task<ActionResult> Login(string userName, string password)
        {
            if (await _context.Kullanicis.AnyAsync(p => p.KullaniciAd == userName))
            {
                var user = await _context.Kullanicis.FirstOrDefaultAsync(p => p.KullaniciAd == userName);
                if (user.Sifre == password)
                {
                    int number = SendCodeToEmail(user.Mail);
                    HttpContext.Session.SetInt32("userId", user.KullaniciId);
                    HttpContext.Session.SetInt32("number", number);
                    return RedirectToAction("CodeVerification", "User");
                }
                else
                {
                    return RedirectToAction("Login", "User");
                }
            }
            else
            {
                return RedirectToAction("Login", "User");
            }
        }
        [HttpGet]
        public ActionResult CodeVerification()
        {
            int? id = HttpContext.Session.GetInt32("userId");
            if (!id.HasValue)
                return RedirectToAction("Login", "User");



            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CodeVerification(string number)
        {
            int? id = HttpContext.Session.GetInt32("userId");
            if (!id.HasValue)
                return RedirectToAction("Login", "User");
            if (number == HttpContext.Session.GetInt32("number").ToString())
                return RedirectToAction("UserIndex", "User");
            else
                return RedirectToAction("Login", "User");
        }
        [HttpGet]
        public ActionResult SignUp()
        {



            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SignUp(Kullanici user)
        {

            if (await _context.Kullanicis.AnyAsync(p => p.KullaniciAd == user.KullaniciAd))
            {
                ViewBag.Mesaj = "Bu kullanici adı alınmış";
                return View();
            }
            else if (await _context.Kullanicis.AnyAsync(p => p.Mail == user.Mail))
            {
                ViewBag.Mesaj = "Bu kullanici adı alınmış";
                return View();
            }
            else
            {
                await _context.AddAsync(new Kullanici
                {
                    Aktiflik = true,
                    CoinMiktari = 0,
                    KayitTarihi = DateTime.Now,
                    ReferansOlmaSayisi = 0,
                    YorumCevapSayisi = 0,
                    YorumSayisi = 0,
                    SosyalSorumlulukKatilimSayisi = 0,
                    KullaniciResim = user.KullaniciResim,
                    Mail = user.Mail,
                    MailSifre = user.MailSifre,
                    KullaniciAd = user.KullaniciAd,
                    Adres = user.Adres,
                    ReferansKullaniciAd = user.ReferansKullaniciAd,
                    Sifre = user.Sifre,
                    ReferansMail = user.ReferansMail
                });
                await _context.SaveChangesAsync();
                var lastUser = await _context.Kullanicis.Where(p => p.Aktiflik == true).OrderByDescending(p => p.KullaniciId).FirstOrDefaultAsync();
                if (lastUser is not null)
                {
                    var reference = await _context.Kullanicis.FirstOrDefaultAsync(p => (p.Aktiflik == true && p.KullaniciAd == lastUser.KullaniciAd && p.Mail == lastUser.Mail));
                    if (reference is not null)
                    {
                        reference.CoinMiktari += 10;
                        reference.ReferansOlmaSayisi++;

                    }
                }
                await _context.SaveChangesAsync();
                return RedirectToAction("Login", "User");
            }
        }
        public async Task<ActionResult> UserIndex(string? filterBy, int? categoryId, string? word)
        {
            //HttpContext.Session.SetInt32("userId", 1);
            int? id = HttpContext.Session.GetInt32("userId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "User");
            }

            var visitorId = Request.Cookies["VisitorId"];
            if (visitorId is not null)
            {
                var cart = Request.Cookies["Cart_" + visitorId];
                if (cart is not null)
                {
                    var items = JsonConvert.DeserializeObject<Dictionary<int, int>>(cart);

                    var user = await _context.Kullanicis.FindAsync(id);
                    if (items is not null)
                    {
                        List<int> productIds = new List<int>();
                        List<Urun> _products = new();

                        productIds = items.Keys.ToList();
                        foreach (var item in productIds)
                        {
                            var _product = await _context.Uruns.FindAsync(item);
                            _products.Add(_product!);
                        }
                        var lastCard = await _context.Sepets.OrderByDescending(p => p.SepetId).FirstOrDefaultAsync(p => p.KullaniciId == id && p.Aktiflik == true);
                        if (lastCard is null)
                        {
                            await _context.Sepets.AddAsync(new Sepet
                            {
                                AcilmaTarih = DateTime.Now,
                                Aktiflik = true,
                                KullaniciId = id,
                                SonGuncelleme = DateTime.Now,
                                UrunSayisi = productIds.Count
                            });
                            await _context.SaveChangesAsync();
                            var _cart = await _context.Sepets.OrderByDescending(p => p.SepetId).FirstOrDefaultAsync(p => p.KullaniciId == id && p.Aktiflik == true);
                            foreach (var item in productIds)
                            {
                                await _context.SepeteEklenmes.AddAsync(new SepeteEklenme
                                {
                                    KullaniciId = id,
                                    SatisBasari = null,
                                    SepetId = _cart!.SepetId,
                                    Tarih = DateTime.Now
                                });
                            }

                            await _context.SaveChangesAsync();

                            await _context.Siparislers.AddAsync(new Siparisler
                            {
                                FaturaAdresi = null,
                                GonderiAdresi = null,
                                KargoDurumu = false,
                                KullaniciId = id,
                                KuponKod = null,
                                Onay = null,
                                SepetId = _cart!.SepetId,
                                Toplamfiyat = 0
                            });
                            var lastOrder = await _context.Siparislers.OrderByDescending(p => p.SiparisId).FirstOrDefaultAsync();
                            foreach (var item in _products)
                            {
                                await _context.SiparisKalemlers.AddAsync(new()
                                {
                                    UrunId = item.UrunId,
                                    BirimFiyat = item.Fiyat,
                                    Miktar = 1,
                                    SiparisId = lastOrder!.SiparisId
                                });
                            }
                            foreach (var item in Request.Cookies.Keys)
                            {
                                if (!item.Equals("User", StringComparison.OrdinalIgnoreCase))
                                {
                                    Response.Cookies.Delete(item);
                                }
                            }
                            await _context.SaveChangesAsync();

                        }
                        else
                        {
                            foreach (var item in productIds)
                            {
                                await _context.SepeteEklenmes.AddAsync(new SepeteEklenme
                                {
                                    Tarih = DateTime.Now,
                                    KullaniciId = id,
                                    SatisBasari = null,
                                    SepetId = lastCard.SepetId
                                });
                            }

                            await _context.Siparislers.AddAsync(new Siparisler
                            {
                                FaturaAdresi = null,
                                GonderiAdresi = null,
                                KargoDurumu = false,
                                KullaniciId = id,
                                KuponKod = null,
                                Onay = null,
                                SepetId = lastCard.SepetId,
                                Toplamfiyat = 0
                            });
                            await _context.SaveChangesAsync();
                            var lastOrder = await _context.Siparislers.OrderByDescending(p => p.SiparisId).FirstOrDefaultAsync();
                            foreach (var item in _products)
                            {
                                await _context.SiparisKalemlers.AddAsync(new()
                                {
                                    UrunId = item.UrunId,
                                    BirimFiyat = item.Fiyat,
                                    Miktar = 1,
                                    SiparisId = lastOrder!.SiparisId
                                });
                            }
                            await _context.SaveChangesAsync();

                            foreach (var item in Request.Cookies.Keys)
                            {
                                if (!item.Equals("User", StringComparison.OrdinalIgnoreCase))
                                {
                                    Response.Cookies.Delete(item);
                                }
                            }
                        }
                    }
                    else
                    {
                        foreach (var item in Request.Cookies.Keys)
                        {
                            if (!item.Equals("User", StringComparison.OrdinalIgnoreCase))
                            {
                                Response.Cookies.Delete(item);
                            }
                        }
                    }
                }

            }


            var products = new List<Urun>();
            if (!categoryId.HasValue && string.IsNullOrEmpty(filterBy) && string.IsNullOrEmpty(word))
            {
                var cachedProducts = await _memoryCache.GetOrCreateAsync("products", async entry =>
                {
                    entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10);

                    return await _context.Uruns.Where(p => p.Aktiflik == true).OrderBy(p => Guid.NewGuid()).ToListAsync();
                });
                return View(cachedProducts);

            }
            if (!string.IsNullOrEmpty(filterBy))
            {
                if (filterBy.Equals("decreasing"))
                {
                    products = await _context.Uruns.Where(p => p.Aktiflik == true).OrderByDescending(p => p.Fiyat).ToListAsync();
                    return View(products);
                }
                else if (filterBy.Equals("increasing"))
                {
                    products = await _context.Uruns.Where(p => p.Aktiflik == true).OrderBy(p => p.Fiyat).ToListAsync();
                    return View(products);
                }
                else if (filterBy.Equals("reverseOrder"))
                {
                    products = await _context.Uruns.Where(p => p.Aktiflik == true).OrderByDescending(p => p.EklenmeTarihi).ToListAsync();
                    return View(products);
                }
                else if (filterBy.Equals("ascendingOrder"))
                {
                    products = await _context.Uruns.Where(p => p.Aktiflik == true).OrderBy(p => p.EklenmeTarihi).ToListAsync();
                    return View(products);
                }
                else if (filterBy.Equals("bestSellers"))
                {

                    var bestSellers = await _context.Satislars.SelectMany(p => p.Siparis.SiparisKalemlers).GroupBy(p => p.UrunId).Select(p => new
                    {
                        ProductId = p.Key,
                        SalesCount = p.Count()
                    }).OrderByDescending(p => p.SalesCount).ToListAsync();
                    var modal = await _context.Uruns.Where(m => bestSellers.Select(l => l.ProductId).Contains(m.UrunId)).ToListAsync();
                    return View(modal);
                }
            }
            if (categoryId.HasValue)
            {
                products = await _context.Uruns.Where(p => (p.Aktiflik == true && p.KategoriId == categoryId)).OrderBy(p => Guid.NewGuid()).ToListAsync();
                return View(products);
            }
            if (!string.IsNullOrEmpty(word))
            {
                products = await _context.Uruns.Where(p => (p.Aktiflik == true && p.UrunAd == word)).ToListAsync();
                return View(products);
            }

            return RedirectToAction("LostedUser", "Home");
        }
        public async Task<ActionResult> UserProfile()
        {
            int? id = HttpContext.Session.GetInt32("userId");
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "User");
            }


            var userDetails = await _context.Kullanicis.FindAsync(id);




            return View(userDetails);
        }

    }
}
