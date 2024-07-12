using System;
using System.Collections.Generic;

namespace DB.Models;

public partial class ReddedilenSiparisler
{
    public int ReddedilenSiparisId { get; set; }

    public int? SiparisId { get; set; }

    public string? Sebep { get; set; }

    public DateTime? Tarih { get; set; }

    public float? Fiyat { get; set; }

    public virtual Siparisler? Siparis { get; set; }
}
