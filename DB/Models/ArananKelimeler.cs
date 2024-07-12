using System;
using System.Collections.Generic;

namespace DB.Models;

public partial class ArananKelimeler
{
    public int AramaId { get; set; }

    public string? Kelime { get; set; }

    public DateTime? Tarih { get; set; }

    public bool? Aktiflik { get; set; }

    public virtual ICollection<EnCokArananKelimeler> EnCokArananKelimelers { get; set; } = new List<EnCokArananKelimeler>();
}
