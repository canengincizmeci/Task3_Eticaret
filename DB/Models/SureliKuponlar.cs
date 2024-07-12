using System;
using System.Collections.Generic;

namespace DB.Models;

public partial class SureliKuponlar
{
    public int KuponId { get; set; }

    public string? KuponBaslik { get; set; }

    public string? KuponAciklama { get; set; }

    public DateTime? BaslangicTarihi { get; set; }

    public DateTime? BitisTarihi { get; set; }

    public bool? Aktiflik { get; set; }

    public float? IndirimMiktari { get; set; }
}
