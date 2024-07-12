using System;
using System.Collections.Generic;

namespace DB.Models;

public partial class Kategori
{
    public int KategoriId { get; set; }

    public string? KategoriAd { get; set; }

    public string? KategoriAciklama { get; set; }

    public bool? Aktiflik { get; set; }

    public virtual ICollection<EnCokArananKategori> EnCokArananKategoris { get; set; } = new List<EnCokArananKategori>();

    public virtual ICollection<KategoriKampanyalar> KategoriKampanyalars { get; set; } = new List<KategoriKampanyalar>();

    public virtual ICollection<Urun> Uruns { get; set; } = new List<Urun>();
}
