using System;
using System.Collections.Generic;

namespace DB.Models;

public partial class KargoFirmaSubeler
{
    public int KargoFirmaSubeId { get; set; }

    public int? KargoFirmaId { get; set; }

    public string? Adress { get; set; }

    public bool? Aktiflik { get; set; }

    public DateTime? EklenmeTarihi { get; set; }

    public virtual ICollection<GonderilenKargolar> GonderilenKargolars { get; set; } = new List<GonderilenKargolar>();

    public virtual KargoFirma? KargoFirma { get; set; }
}
