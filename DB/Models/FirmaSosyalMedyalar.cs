using System;
using System.Collections.Generic;

namespace DB.Models;

public partial class FirmaSosyalMedyalar
{
    public int FirmaSosyalMedyaId { get; set; }

    public int? FirmaId { get; set; }

    public string? UrlAdresi { get; set; }

    public string? SosyalMedyaIsmi { get; set; }

    public DateTime? EklenmeTarihi { get; set; }

    public bool? Aktiflik { get; set; }

    public virtual Firma? Firma { get; set; }
}
