using System;
using System.Collections.Generic;

namespace DB.Models;

public partial class FirmadanTeknikElemanaSikayet
{
    public int SikayetId { get; set; }

    public int? FirmaId { get; set; }

    public int? TeknikElemanId { get; set; }

    public string? SikayetBaslik { get; set; }

    public string? SikayetMetni { get; set; }

    public DateTime? Tarih { get; set; }

    public bool? Aktiflik { get; set; }

    public virtual Firma? Firma { get; set; }

    public virtual TeknikElemanlar? TeknikEleman { get; set; }
}
