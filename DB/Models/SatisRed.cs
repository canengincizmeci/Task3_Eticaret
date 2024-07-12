using System;
using System.Collections.Generic;

namespace DB.Models;

public partial class SatisRed
{
    public int RedId { get; set; }

    public int? OdemeId { get; set; }

    public int? SiparisId { get; set; }

    public int? KullaniciId { get; set; }

    public int? FirmaId { get; set; }

    public float? Fiyat { get; set; }

    public DateTime? Tarih { get; set; }

    public virtual Firma? Firma { get; set; }

    public virtual Kullanici? Kullanici { get; set; }

    public virtual Odemeler? Odeme { get; set; }

    public virtual Siparisler? Siparis { get; set; }
}
