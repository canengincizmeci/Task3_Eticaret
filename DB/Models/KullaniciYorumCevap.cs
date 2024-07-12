using System;
using System.Collections.Generic;

namespace DB.Models;

public partial class KullaniciYorumCevap
{
    public int CevapId { get; set; }

    public string? Cevap { get; set; }

    public int? KullaniciId { get; set; }

    public int? YorumId { get; set; }

    public bool? Aktiflik { get; set; }

    public DateTime? Tarih { get; set; }

    public virtual ICollection<FirmadanKullaniciyaYorumCevapSikayet> FirmadanKullaniciyaYorumCevapSikayets { get; set; } = new List<FirmadanKullaniciyaYorumCevapSikayet>();

    public virtual Kullanici? Kullanici { get; set; }

    public virtual ICollection<KullanicidanFirmayaYorumCevapSikayet> KullanicidanFirmayaYorumCevapSikayets { get; set; } = new List<KullanicidanFirmayaYorumCevapSikayet>();

    public virtual Yorumlar? Yorum { get; set; }
}
