using System;
using System.Collections.Generic;

namespace DB.Models;

public partial class SosyalSorumlulukKatilanFirmalar
{
    public int KatilimId { get; set; }

    public int? FirmaId { get; set; }

    public int? GorevId { get; set; }

    public DateTime? KatilimTarihi { get; set; }

    public float? Puan { get; set; }

    public bool? Aktiflik { get; set; }

    public virtual Firma? Firma { get; set; }

    public virtual SosyalSorumlulukGorevi? Gorev { get; set; }
}
