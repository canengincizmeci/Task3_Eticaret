using System;
using System.Collections.Generic;

namespace DB.Models;

public partial class Urun
{
    public int UrunId { get; set; }

    public string? UrunAd { get; set; }

    public string? Aciklama { get; set; }

    public string? UrunResim { get; set; }

    public DateTime? EklenmeTarihi { get; set; }

    public int? FirmaId { get; set; }

    public int? SatisSayisi { get; set; }

    public int? Fiyat { get; set; }

    public int? SepeteEklemeSayisi { get; set; }

    public int? Stok { get; set; }

    public int? KategoriId { get; set; }

    public bool? Aktiflik { get; set; }

    public virtual ICollection<EnCokArananUrun> EnCokArananUruns { get; set; } = new List<EnCokArananUrun>();

    public virtual ICollection<Favoriler> Favorilers { get; set; } = new List<Favoriler>();

    public virtual Firma? Firma { get; set; }

    public virtual Kategori? Kategori { get; set; }

    public virtual ICollection<KullanicidanYorumSikayet> KullanicidanYorumSikayets { get; set; } = new List<KullanicidanYorumSikayet>();

    public virtual ICollection<OnaysızSiparisIptal> OnaysızSiparisIptals { get; set; } = new List<OnaysızSiparisIptal>();

    public virtual ICollection<SiparisKalemler> SiparisKalemlers { get; set; } = new List<SiparisKalemler>();

    public virtual ICollection<UrunGoruntulenme> UrunGoruntulenmes { get; set; } = new List<UrunGoruntulenme>();

    public virtual ICollection<UrunKampanyalar> UrunKampanyalars { get; set; } = new List<UrunKampanyalar>();

    public virtual ICollection<UrunPuanlama> UrunPuanlamas { get; set; } = new List<UrunPuanlama>();

    public virtual ICollection<UrunSikayet> UrunSikayets { get; set; } = new List<UrunSikayet>();

    public virtual ICollection<Yorumlar> Yorumlars { get; set; } = new List<Yorumlar>();
}
