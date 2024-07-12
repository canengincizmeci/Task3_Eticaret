using System;
using System.Collections.Generic;

namespace DB.Models;

public partial class KullanicidanYorumSikayet
{
    public int YorumSikayetId { get; set; }

    public int? YorumId { get; set; }

    public int? SikayetciKullaniciId { get; set; }

    public int? BildirilenKullaniciId { get; set; }

    public int? UrunId { get; set; }

    public string? SikayetBaslik { get; set; }

    public string? SikayetMetni { get; set; }

    public DateTime? Tarih { get; set; }

    public bool? Aktiflik { get; set; }

    public virtual Kullanici? BildirilenKullanici { get; set; }

    public virtual Kullanici? SikayetciKullanici { get; set; }

    public virtual Urun? Urun { get; set; }

    public virtual Yorumlar? Yorum { get; set; }
}
