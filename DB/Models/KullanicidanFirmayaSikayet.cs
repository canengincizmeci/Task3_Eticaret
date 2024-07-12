using System;
using System.Collections.Generic;

namespace DB.Models;

public partial class KullanicidanFirmayaSikayet
{
    public int SikayetId { get; set; }

    public int? SikayetciId { get; set; }

    public string? SikayetBaslik { get; set; }

    public string? SikayetMetni { get; set; }

    public int? FirmaId { get; set; }

    public DateTime? Tarih { get; set; }

    public bool? Aktiflik { get; set; }

    public virtual Firma? Firma { get; set; }

    public virtual Kullanici? Sikayetci { get; set; }
}
