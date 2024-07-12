using System;
using System.Collections.Generic;

namespace DB.Models;

public partial class UrunSikayet
{
    public int UrunsikayetId { get; set; }

    public int? UrunId { get; set; }

    public string? SikayetBaslik { get; set; }

    public string? SikayetMetni { get; set; }

    public int? KullaniciId { get; set; }

    public DateTime? Tarih { get; set; }

    public bool? Aktiflik { get; set; }

    public virtual Kullanici? Kullanici { get; set; }

    public virtual Urun? Urun { get; set; }
}
