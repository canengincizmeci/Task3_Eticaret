using System;
using System.Collections.Generic;

namespace DB.Models;

public partial class FirmaYarismalar
{
    public int FirmayarismaId { get; set; }

    public string? YarismaBaslik { get; set; }

    public string? YarismaAciklama { get; set; }

    public DateTime? BaslangicTarih { get; set; }

    public DateTime? BitisTarih { get; set; }

    public bool? Aktiflik { get; set; }

    public virtual ICollection<FirmaYarismaKazanlar> FirmaYarismaKazanlars { get; set; } = new List<FirmaYarismaKazanlar>();

    public virtual ICollection<FirmaYarismasiKatilanlar> FirmaYarismasiKatilanlars { get; set; } = new List<FirmaYarismasiKatilanlar>();
}
