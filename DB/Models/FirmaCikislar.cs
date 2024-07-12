using System;
using System.Collections.Generic;

namespace DB.Models;

public partial class FirmaCikislar
{
    public int FirmaCikisId { get; set; }

    public int? FirmaId { get; set; }

    public int? FirmaGirisId { get; set; }

    public DateTime? Tarih { get; set; }

    public bool? BasariDurumu { get; set; }

    public virtual Firma? Firma { get; set; }

    public virtual FirmaGirisler? FirmaGiris { get; set; }
}
