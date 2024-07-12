using System;
using System.Collections.Generic;

namespace DB.Models;

public partial class IstenenKargolar
{
    public int IstekKargoId { get; set; }

    public int? SatisId { get; set; }

    public int? KargoFirmaId { get; set; }

    public int? SatisiciFirmaId { get; set; }

    public DateTime? Tarih { get; set; }

    public bool? Akitflik { get; set; }

    public virtual ICollection<GonderilenKargolar> GonderilenKargolars { get; set; } = new List<GonderilenKargolar>();

    public virtual KargoFirma? KargoFirma { get; set; }

    public virtual Satislar? Satis { get; set; }

    public virtual Firma? SatisiciFirma { get; set; }
}
