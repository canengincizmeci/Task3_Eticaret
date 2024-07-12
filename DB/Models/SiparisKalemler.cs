using System;
using System.Collections.Generic;

namespace DB.Models;

public partial class SiparisKalemler
{
    public int SipariskalemId { get; set; }

    public int? SiparisId { get; set; }

    public int? UrunId { get; set; }

    public float? BirimFiyat { get; set; }

    public int? Miktar { get; set; }

    public virtual Siparisler? Siparis { get; set; }

    public virtual Urun? Urun { get; set; }
}
