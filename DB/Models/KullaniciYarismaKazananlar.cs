using System;
using System.Collections.Generic;

namespace DB.Models;

public partial class KullaniciYarismaKazananlar
{
    public int KazanmaId { get; set; }

    public int? KullaniciId { get; set; }

    public int? KullaniciYarismaId { get; set; }

    public DateTime? KazanmaTarih { get; set; }

    public virtual Kullanici? Kullanici { get; set; }

    public virtual KullaniciYarismalar? KullaniciYarisma { get; set; }
}
