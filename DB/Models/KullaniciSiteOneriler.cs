using System;
using System.Collections.Generic;

namespace DB.Models;

public partial class KullaniciSiteOneriler
{
    public int OneriId { get; set; }

    public string? OneriBaslik { get; set; }

    public string? OneriMetin { get; set; }

    public int? KullaniciId { get; set; }

    public DateTime? Tarih { get; set; }

    public bool? Aktiflik { get; set; }

    public virtual Kullanici? Kullanici { get; set; }
}
