using System;
using System.Collections.Generic;

namespace DB.Models;

public partial class KullanicidanTeknikElemanaSikayet
{
    public int SikayetId { get; set; }

    public int? KullaniciId { get; set; }

    public int? TeknikElemanId { get; set; }

    public string? SikayetBaslik { get; set; }

    public string? SikayetMetni { get; set; }

    public DateTime? Tarih { get; set; }

    public bool? Aktiflik { get; set; }

    public virtual Kullanici? Kullanici { get; set; }

    public virtual TeknikElemanlar? TeknikEleman { get; set; }
}
