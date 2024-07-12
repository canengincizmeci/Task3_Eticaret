using System;
using System.Collections.Generic;

namespace DB.Models;

public partial class FirmaYarismasiKatilanlar
{
    public int KatilimId { get; set; }

    public int? FirmaId { get; set; }

    public int? FirmayarismaId { get; set; }

    public DateTime? KatilmaTarih { get; set; }

    public bool? Aktiflik { get; set; }

    public virtual Firma? Firma { get; set; }

    public virtual FirmaYarismalar? Firmayarisma { get; set; }
}
