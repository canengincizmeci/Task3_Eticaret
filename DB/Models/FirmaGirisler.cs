using System;
using System.Collections.Generic;

namespace DB.Models;

public partial class FirmaGirisler
{
    public int GirisId { get; set; }

    public int? FirmaId { get; set; }

    public DateTime? Tarih { get; set; }

    public bool? Basari { get; set; }

    public virtual Firma? Firma { get; set; }

    public virtual ICollection<FirmaCikislar> FirmaCikislars { get; set; } = new List<FirmaCikislar>();
}
