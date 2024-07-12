using System;
using System.Collections.Generic;

namespace DB.Models;

public partial class KullanicidanKargoFirmasiSikayeti
{
    public int SikayetId { get; set; }

    public int? KargoFirmaId { get; set; }

    public int? KullaniciId { get; set; }

    public string? SikayetBaslik { get; set; }

    public string? SikayetMetni { get; set; }

    public DateTime? Tarih { get; set; }

    public bool? Aktiflik { get; set; }

    public virtual KargoFirma? KargoFirma { get; set; }

    public virtual Kullanici? Kullanici { get; set; }
}
