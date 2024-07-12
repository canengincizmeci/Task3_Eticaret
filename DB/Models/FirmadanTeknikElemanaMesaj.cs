using System;
using System.Collections.Generic;

namespace DB.Models;

public partial class FirmadanTeknikElemanaMesaj
{
    public int MesajId { get; set; }

    public string? MesajBaslik { get; set; }

    public string? Mesaj { get; set; }

    public int? MesajlasmaId { get; set; }

    public int? FirmaId { get; set; }

    public int? TeknikElemanId { get; set; }

    public DateTime? Tarih { get; set; }

    public bool? Aktiflik { get; set; }

    public bool? OkunduBilgisi { get; set; }

    public virtual Firma? Firma { get; set; }

    public virtual Mesajlasma? Mesajlasma { get; set; }

    public virtual TeknikElemanlar? TeknikEleman { get; set; }
}
