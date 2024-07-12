using System;
using System.Collections.Generic;

namespace DB.Models;

public partial class EnCokArananKategori
{
    public int EnCokAranmaId { get; set; }

    public int? KategoriId { get; set; }

    public int? AranmaSayisi { get; set; }

    public string? KategoriAd { get; set; }

    public bool? Aktiflik { get; set; }

    public virtual Kategori? Kategori { get; set; }
}
