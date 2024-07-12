using System;
using System.Collections.Generic;

namespace DB.Models;

public partial class Yorumlar
{
    public int YorumId { get; set; }

    public string? Yorum { get; set; }

    public int? KullaniciId { get; set; }

    public int? UrunId { get; set; }

    public DateTime? Tarih { get; set; }

    public bool? Aktiflik { get; set; }

    public virtual ICollection<FirmaYorumCevap> FirmaYorumCevaps { get; set; } = new List<FirmaYorumCevap>();

    public virtual ICollection<FirmadanYorumSikayet> FirmadanYorumSikayets { get; set; } = new List<FirmadanYorumSikayet>();

    public virtual Kullanici? Kullanici { get; set; }

    public virtual ICollection<KullaniciYorumCevap> KullaniciYorumCevaps { get; set; } = new List<KullaniciYorumCevap>();

    public virtual ICollection<KullanicidanYorumSikayet> KullanicidanYorumSikayets { get; set; } = new List<KullanicidanYorumSikayet>();

    public virtual Urun? Urun { get; set; }
}
