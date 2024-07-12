using System;
using System.Collections.Generic;

namespace DB.Models;

public partial class EnCokArananKelimeler
{
    public int EncokArananKelimeId { get; set; }

    public int? AramaId { get; set; }

    public bool? Aktiflik { get; set; }

    public int? AranmaSayisi { get; set; }

    public string? Kelime { get; set; }

    public virtual ArananKelimeler? Arama { get; set; }
}
