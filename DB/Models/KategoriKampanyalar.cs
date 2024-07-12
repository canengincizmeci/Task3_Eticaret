using System;
using System.Collections.Generic;

namespace DB.Models;

public partial class KategoriKampanyalar
{
    public int KampanyaId { get; set; }

    public string? KampanyaBaslik { get; set; }

    public string? KampanyaAciklama { get; set; }

    public int? KategoriId { get; set; }

    public DateTime? BaslangicTarihi { get; set; }

    public DateTime? BitisTarihi { get; set; }

    public bool? Aktiflik { get; set; }

    public float? IndirimMiktari { get; set; }

    public virtual Kategori? Kategori { get; set; }
}
