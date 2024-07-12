using System;
using System.Collections.Generic;

namespace DB.Models;

public partial class KullaniciCikislar
{
    public int KullaniciCikisId { get; set; }

    public int? KullaniciId { get; set; }

    public int? KullaniciGirisId { get; set; }

    public DateTime? Tarih { get; set; }

    public bool? BasariDurumu { get; set; }

    public virtual Kullanici? Kullanici { get; set; }

    public virtual KullaniciGirisler? KullaniciGiris { get; set; }
}
