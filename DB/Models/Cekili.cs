using System;
using System.Collections.Generic;

namespace DB.Models;

public partial class Cekili
{
    public int CekilisId { get; set; }

    public string? CekilisAd { get; set; }

    public string? CekilisAciklama { get; set; }

    public DateTime? BaslangicTarih { get; set; }

    public DateTime? BitisTarih { get; set; }

    public bool? Aktiflik { get; set; }

    public virtual ICollection<CekilisKazananlar> CekilisKazananlars { get; set; } = new List<CekilisKazananlar>();

    public virtual ICollection<CekiliseKatılanlar> CekiliseKatılanlars { get; set; } = new List<CekiliseKatılanlar>();
}
