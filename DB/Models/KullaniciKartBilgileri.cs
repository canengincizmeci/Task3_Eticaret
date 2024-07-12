using System;
using System.Collections.Generic;

namespace DB.Models;

public partial class KullaniciKartBilgileri
{
    public int KartId { get; set; }

    public string? KartNumarasi { get; set; }

    public string? Aciklama { get; set; }

    public string? Cvv { get; set; }

    public string? GecerlilikTarihi { get; set; }

    public int? KullaniciId { get; set; }

    public DateTime? EklenmeTarihi { get; set; }

    public bool? Aktiflik { get; set; }

    public virtual Kullanici? Kullanici { get; set; }
}
