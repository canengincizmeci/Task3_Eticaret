using System;
using System.Collections.Generic;

namespace DB.Models;

public partial class FirmaYorumCevap
{
    public int CevapId { get; set; }

    public string? Cevap { get; set; }

    public int? YorumId { get; set; }

    public int? FirmaId { get; set; }

    public DateTime? Tarih { get; set; }

    public bool? Aktiflik { get; set; }

    public virtual Firma? Firma { get; set; }

    public virtual Yorumlar? Yorum { get; set; }
}
