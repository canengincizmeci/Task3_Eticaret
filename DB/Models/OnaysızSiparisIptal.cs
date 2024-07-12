﻿using System;
using System.Collections.Generic;

namespace DB.Models;

public partial class OnaysızSiparisIptal
{
    public int IptalId { get; set; }

    public int? SiparisId { get; set; }

    public int? KullaniciId { get; set; }

    public int? UrunId { get; set; }

    public float? Fiyat { get; set; }

    public DateTime? Tarih { get; set; }

    public virtual Kullanici? Kullanici { get; set; }

    public virtual Siparisler? Siparis { get; set; }

    public virtual Urun? Urun { get; set; }
}
