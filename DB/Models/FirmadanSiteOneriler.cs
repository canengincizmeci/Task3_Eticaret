using System;
using System.Collections.Generic;

namespace DB.Models;

public partial class FirmadanSiteOneriler
{
    public int OneriId { get; set; }

    public string? OneriBaslik { get; set; }

    public string? OneriMetin { get; set; }

    public int? FirmaId { get; set; }

    public DateTime? Tarih { get; set; }

    public bool? Aktiflik { get; set; }

    public virtual Firma? Firma { get; set; }
}
