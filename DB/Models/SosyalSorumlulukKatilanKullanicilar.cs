using System;
using System.Collections.Generic;

namespace DB.Models;

public partial class SosyalSorumlulukKatilanKullanicilar
{
    public int KatilimId { get; set; }

    public int? KullaniciId { get; set; }

    public int? GorevId { get; set; }

    public DateTime? KatilimTarihi { get; set; }

    public float? Puan { get; set; }

    public bool? Aktiflik { get; set; }

    public virtual SosyalSorumlulukGorevi? Gorev { get; set; }

    public virtual Kullanici? Kullanici { get; set; }
}
