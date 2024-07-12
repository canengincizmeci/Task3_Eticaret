using System;
using System.Collections.Generic;

namespace DB.Models;

public partial class KullaniciAdresler
{
    public int KullaniciAdresId { get; set; }

    public int? KullaniciId { get; set; }

    public string? AdresBaslik { get; set; }

    public string? Adres { get; set; }

    public string? Sehir { get; set; }

    public string? Ulke { get; set; }

    public DateTime? EklenmeTarihi { get; set; }

    public bool? Aktiflik { get; set; }

    public virtual ICollection<GonderilenKargolar> GonderilenKargolars { get; set; } = new List<GonderilenKargolar>();

    public virtual Kullanici? Kullanici { get; set; }
}
