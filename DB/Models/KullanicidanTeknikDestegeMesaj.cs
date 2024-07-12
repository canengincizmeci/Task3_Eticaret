using System;
using System.Collections.Generic;

namespace DB.Models;

public partial class KullanicidanTeknikDestegeMesaj
{
    public int MesajId { get; set; }

    public int? KullaniciId { get; set; }

    public int? TeknikElemanId { get; set; }

    public string? MesajBaslik { get; set; }

    public string? Mesaj { get; set; }

    public DateTime? Tarih { get; set; }

    public bool? Aktiflik { get; set; }

    public int? MesajlasmaId { get; set; }

    public bool? OkunduBilgisi { get; set; }

    public virtual Kullanici? Kullanici { get; set; }

    public virtual Mesajlasma? Mesajlasma { get; set; }

    public virtual TeknikElemanlar? TeknikEleman { get; set; }
}
