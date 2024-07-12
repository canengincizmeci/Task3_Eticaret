using System;
using System.Collections.Generic;

namespace DB.Models;

public partial class Odemeler
{
    public int OdemeId { get; set; }

    public int? SiparisId { get; set; }

    public int? KullaniciId { get; set; }

    public string? KuponKod { get; set; }

    public float? Toplamfiyat { get; set; }

    public bool? Onay { get; set; }

    public DateTime? Tarih { get; set; }

    public virtual ICollection<IadeTalep> IadeTaleps { get; set; } = new List<IadeTalep>();

    public virtual Kullanici? Kullanici { get; set; }

    public virtual ICollection<SatisRed> SatisReds { get; set; } = new List<SatisRed>();

    public virtual Siparisler? Siparis { get; set; }
}
