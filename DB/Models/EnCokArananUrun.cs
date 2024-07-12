using System;
using System.Collections.Generic;

namespace DB.Models;

public partial class EnCokArananUrun
{
    public int EnCokArananUrunId { get; set; }

    public int? UrunId { get; set; }

    public string? UrunAd { get; set; }

    public int? AranmaSayisi { get; set; }

    public bool? Aktiflik { get; set; }

    public virtual Urun? Urun { get; set; }
}
