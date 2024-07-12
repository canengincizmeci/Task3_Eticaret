using System;
using System.Collections.Generic;

namespace DB.Models;

public partial class FirmadanYorumSikayet
{
    public int YorumSikayetId { get; set; }

    public int? YorumId { get; set; }

    public int? FirmaId { get; set; }

    public int? KullaniciId { get; set; }

    public string? SikayetBaslik { get; set; }

    public string? SikayetMetni { get; set; }

    public DateTime? Tarih { get; set; }

    public bool? Aktiflik { get; set; }

    public virtual Firma? Firma { get; set; }

    public virtual Kullanici? Kullanici { get; set; }

    public virtual Yorumlar? Yorum { get; set; }
}
