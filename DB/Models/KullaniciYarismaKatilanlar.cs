using System;
using System.Collections.Generic;

namespace DB.Models;

public partial class KullaniciYarismaKatilanlar
{
    public int KatilimId { get; set; }

    public int? KullaniciId { get; set; }

    public int? KullaniciYarismaId { get; set; }

    public DateTime? KatilmaTarih { get; set; }

    public bool? Aktiflik { get; set; }

    public virtual Kullanici? Kullanici { get; set; }

    public virtual KullaniciYarismalar? KullaniciYarisma { get; set; }
}
