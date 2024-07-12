using System;
using System.Collections.Generic;

namespace DB.Models;

public partial class FavoriEklenme
{
    public int EklenmeId { get; set; }

    public int? FavoriId { get; set; }

    public DateTime? Tarih { get; set; }

    public virtual Favoriler? Favori { get; set; }
}
