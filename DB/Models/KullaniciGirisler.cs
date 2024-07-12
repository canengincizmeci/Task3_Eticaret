using System;
using System.Collections.Generic;

namespace DB.Models;

public partial class KullaniciGirisler
{
    public int GirisId { get; set; }

    public int? KullaniciId { get; set; }

    public bool? BasariDurumu { get; set; }

    public DateTime? Tarih { get; set; }

    public virtual ICollection<KullaniciCikislar> KullaniciCikislars { get; set; } = new List<KullaniciCikislar>();
}
