using System;
using System.Collections.Generic;

namespace DB.Models;

public partial class Siparisler
{
    public int SiparisId { get; set; }

    public int? KullaniciId { get; set; }

    public int? SepetId { get; set; }

    public string? KuponKod { get; set; }

    public float? Toplamfiyat { get; set; }

    public bool? Onay { get; set; }

    public bool? KargoDurumu { get; set; }

    public string? GonderiAdresi { get; set; }

    public string? FaturaAdresi { get; set; }

    public virtual Kullanici? Kullanici { get; set; }

    public virtual ICollection<Odemeler> Odemelers { get; set; } = new List<Odemeler>();

    public virtual ICollection<OnaysızSiparisIptal> OnaysızSiparisIptals { get; set; } = new List<OnaysızSiparisIptal>();

    public virtual ICollection<ReddedilenSiparisler> ReddedilenSiparislers { get; set; } = new List<ReddedilenSiparisler>();

    public virtual ICollection<SatisRed> SatisReds { get; set; } = new List<SatisRed>();

    public virtual ICollection<Satislar> Satislars { get; set; } = new List<Satislar>();

    public virtual Sepet? Sepet { get; set; }

    public virtual ICollection<SiparisKalemler> SiparisKalemlers { get; set; } = new List<SiparisKalemler>();
}
