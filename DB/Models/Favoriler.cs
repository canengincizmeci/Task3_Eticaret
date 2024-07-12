using System;
using System.Collections.Generic;

namespace DB.Models;

public partial class Favoriler
{
    public int FavoriId { get; set; }

    public int? UrunId { get; set; }

    public int? KullaniciId { get; set; }

    public bool? Aktiflik { get; set; }

    public virtual ICollection<FavoriCikarma> FavoriCikarmas { get; set; } = new List<FavoriCikarma>();

    public virtual ICollection<FavoriEklenme> FavoriEklenmes { get; set; } = new List<FavoriEklenme>();

    public virtual Kullanici? Kullanici { get; set; }

    public virtual Urun? Urun { get; set; }
}
