using System;
using System.Collections.Generic;

namespace DB.Models;

public partial class UrunGoruntulenme
{
    public int GoruntulenmeId { get; set; }

    public int? UrunId { get; set; }

    public int? GoruntulenmeSayisi { get; set; }

    public DateTime? IlkGoruntulenmeTarih { get; set; }

    public DateTime? SonGoruntulenmeTarih { get; set; }

    public bool? Aktiflik { get; set; }

    public virtual Urun? Urun { get; set; }
}
