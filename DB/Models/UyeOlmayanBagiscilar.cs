using System;
using System.Collections.Generic;

namespace DB.Models;

public partial class UyeOlmayanBagiscilar
{
    public int BagisId { get; set; }

    public string? BagisciAd { get; set; }

    public float? Miktar { get; set; }

    public DateTime? Tarih { get; set; }

    public string? KartNumarasi { get; set; }

    public string? SonGecerlilikTarihi { get; set; }

    public string? Cvv { get; set; }

    public bool? Onay { get; set; }

    public bool? Aktiflik { get; set; }
}
