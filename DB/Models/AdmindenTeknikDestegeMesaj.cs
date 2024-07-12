using System;
using System.Collections.Generic;

namespace DB.Models;

public partial class AdmindenTeknikDestegeMesaj
{
    public int MesajId { get; set; }

    public string? MesajBaslik { get; set; }

    public string? Mesaj { get; set; }

    public int? AdminId { get; set; }

    public int? ElemanId { get; set; }

    public int? MesajlasmaId { get; set; }

    public DateTime? Tarih { get; set; }

    public bool? OkunduBilgisi { get; set; }

    public virtual Admin? Admin { get; set; }

    public virtual TeknikElemanlar? Eleman { get; set; }

    public virtual Mesajlasma? Mesajlasma { get; set; }
}
