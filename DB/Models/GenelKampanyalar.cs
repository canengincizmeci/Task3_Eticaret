using System;
using System.Collections.Generic;

namespace DB.Models;

public partial class GenelKampanyalar
{
    public int KampanyaId { get; set; }

    public string? KampanyaBaslik { get; set; }

    public string? KampanyaAciklama { get; set; }

    public DateTime? BaslangicTarihi { get; set; }

    public DateTime? BitisTarihi { get; set; }

    public bool? Aktiflik { get; set; }

    public float? IndirimMiktari { get; set; }
}
