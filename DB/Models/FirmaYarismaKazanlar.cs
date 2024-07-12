using System;
using System.Collections.Generic;

namespace DB.Models;

public partial class FirmaYarismaKazanlar
{
    public int KazanmaId { get; set; }

    public int? FirmaId { get; set; }

    public int? FirmayarismaId { get; set; }

    public DateTime? KazanmaTarih { get; set; }

    public bool? Aktiflik { get; set; }

    public virtual Firma? Firma { get; set; }

    public virtual FirmaYarismalar? Firmayarisma { get; set; }
}
