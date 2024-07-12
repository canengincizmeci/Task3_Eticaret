using System;
using System.Collections.Generic;

namespace DB.Models;

public partial class FirmaBasvuru
{
    public int BasvuruId { get; set; }

    public string? FirmaAd { get; set; }

    public string? FirmaAdres { get; set; }

    public string? FirmaAciklama { get; set; }

    public DateTime? KurulusTarihi { get; set; }

    public string? FirmaSektor { get; set; }

    public string? FirmaTel { get; set; }

    public string? Mail { get; set; }

    public DateTime? BasvuruTarih { get; set; }

    public bool? Aktiflik { get; set; }
}
