using System;
using System.Collections.Generic;

namespace DB.Models;

public partial class FirmaKampanyalar
{
    public int KampanyaId { get; set; }

    public string? KampanyaBaslik { get; set; }

    public string? KampanyaAciklama { get; set; }

    public int? FirmaId { get; set; }

    public DateTime? BaslangicTarihi { get; set; }

    public DateTime? BitisTarihi { get; set; }

    public bool? Aktiflik { get; set; }

    public float? IndirimMiktari { get; set; }

    public virtual Firma? Firma { get; set; }
}
