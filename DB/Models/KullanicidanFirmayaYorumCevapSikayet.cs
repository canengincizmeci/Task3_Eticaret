using System;
using System.Collections.Generic;

namespace DB.Models;

public partial class KullanicidanFirmayaYorumCevapSikayet
{
    public int KullaniciYorumCevapSikayetId { get; set; }

    public int? YorumCevapId { get; set; }

    public int? KullaniciId { get; set; }

    public int? FirmaId { get; set; }

    public string? SikayetBaslik { get; set; }

    public string? SikayetMetni { get; set; }

    public DateTime? Tarih { get; set; }

    public bool? Aktiflik { get; set; }

    public virtual Firma? Firma { get; set; }

    public virtual Kullanici? Kullanici { get; set; }

    public virtual KullaniciYorumCevap? YorumCevap { get; set; }
}
