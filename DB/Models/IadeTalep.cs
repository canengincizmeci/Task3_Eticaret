using System;
using System.Collections.Generic;

namespace DB.Models;

public partial class IadeTalep
{
    public int TalepId { get; set; }

    public int? OdemeId { get; set; }

    public int? KullaniciId { get; set; }

    public string? Sebep { get; set; }

    public DateTime? Tarih { get; set; }

    public bool? Onay { get; set; }

    public bool? Aktiflik { get; set; }

    public virtual ICollection<Iadeler> Iadelers { get; set; } = new List<Iadeler>();

    public virtual Kullanici? Kullanici { get; set; }

    public virtual Odemeler? Odeme { get; set; }
}
