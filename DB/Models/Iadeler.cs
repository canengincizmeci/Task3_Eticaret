using System;
using System.Collections.Generic;

namespace DB.Models;

public partial class Iadeler
{
    public int IadeId { get; set; }

    public int? IadeTalepId { get; set; }

    public int? KullaniciId { get; set; }

    public float? IadeTutarı { get; set; }

    public DateTime? Tarih { get; set; }

    public virtual IadeTalep? IadeTalep { get; set; }

    public virtual Kullanici? Kullanici { get; set; }
}
