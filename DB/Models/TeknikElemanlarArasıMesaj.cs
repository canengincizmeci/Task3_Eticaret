using System;
using System.Collections.Generic;

namespace DB.Models;

public partial class TeknikElemanlarArasıMesaj
{
    public int MesajId { get; set; }

    public string? Mesaj { get; set; }

    public string? MesajBaslik { get; set; }

    public int? MesajlasmaId { get; set; }

    public int? GonderenEleman { get; set; }

    public int? AlıcıEleman { get; set; }

    public DateTime? Tarih { get; set; }

    public bool? Aktiflik { get; set; }

    public bool? OkunduBilgisi { get; set; }

    public virtual TeknikElemanlar? AlıcıElemanNavigation { get; set; }

    public virtual TeknikElemanlar? GonderenElemanNavigation { get; set; }

    public virtual Mesajlasma? Mesajlasma { get; set; }
}
