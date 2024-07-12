using System;
using System.Collections.Generic;

namespace DB.Models;

public partial class KullaniciYarismalar
{
    public int KullaniciYarismaId { get; set; }

    public string? YarismaBaslik { get; set; }

    public string? YarismaAciklama { get; set; }

    public DateTime? BaslangicTarih { get; set; }

    public DateTime? BitisTarih { get; set; }

    public bool? Aktiflik { get; set; }

    public virtual ICollection<KullaniciYarismaKatilanlar> KullaniciYarismaKatilanlars { get; set; } = new List<KullaniciYarismaKatilanlar>();

    public virtual ICollection<KullaniciYarismaKazananlar> KullaniciYarismaKazananlars { get; set; } = new List<KullaniciYarismaKazananlar>();
}
