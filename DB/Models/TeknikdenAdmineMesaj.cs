using System;
using System.Collections.Generic;

namespace DB.Models;

public partial class TeknikdenAdmineMesaj
{
    public int MesajId { get; set; }

    public string? Mesaj { get; set; }

    public string? MesajBaslik { get; set; }

    public int? TeknikId { get; set; }

    public int? AdminId { get; set; }

    public int? MesajlasmaId { get; set; }

    public DateTime? Tarih { get; set; }

    public bool? Aktiflik { get; set; }

    public bool? OkunduBilgisi { get; set; }

    public virtual Admin? Admin { get; set; }

    public virtual Mesajlasma? Mesajlasma { get; set; }

    public virtual TeknikElemanlar? Teknik { get; set; }
}
