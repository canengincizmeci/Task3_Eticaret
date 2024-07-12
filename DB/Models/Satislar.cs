using System;
using System.Collections.Generic;

namespace DB.Models;

public partial class Satislar
{
    public int SatisId { get; set; }

    public int? SiparisId { get; set; }

    public int? FirmaId { get; set; }

    public int? KullaniciId { get; set; }

    public DateTime? Tarih { get; set; }

    public string? GonderiAdresi { get; set; }

    public string? FaturaAdresi { get; set; }

    public virtual Firma? Firma { get; set; }

    public virtual ICollection<IstenenKargolar> IstenenKargolars { get; set; } = new List<IstenenKargolar>();

    public virtual Kullanici? Kullanici { get; set; }

    public virtual Siparisler? Siparis { get; set; }
}
