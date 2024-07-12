using System;
using System.Collections.Generic;

namespace DB.Models;

public partial class SosyalSorumlulukTalepFirma
{
    public int TalepId { get; set; }

    public string? TalepBaslik { get; set; }

    public string? TalepMetin { get; set; }

    public int? FirmaId { get; set; }

    public DateTime? Tarih { get; set; }

    public bool? Aktiflik { get; set; }

    public virtual Firma? Firma { get; set; }
}
