using System;
using System.Collections.Generic;

namespace DB.Models;

public partial class Sepet
{
    public int SepetId { get; set; }

    public int? KullaniciId { get; set; }

    public DateTime? AcilmaTarih { get; set; }

    public int? UrunSayisi { get; set; }

    public DateTime? SonGuncelleme { get; set; }

    public bool? Aktiflik { get; set; }

    public virtual Kullanici? Kullanici { get; set; }

    public virtual ICollection<SepeteEklenme> SepeteEklenmes { get; set; } = new List<SepeteEklenme>();

    public virtual ICollection<SepettenCikarma> SepettenCikarmas { get; set; } = new List<SepettenCikarma>();

    public virtual ICollection<Siparisler> Siparislers { get; set; } = new List<Siparisler>();
}
