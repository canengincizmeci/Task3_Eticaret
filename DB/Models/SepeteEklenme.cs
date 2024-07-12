using System;
using System.Collections.Generic;

namespace DB.Models;

public partial class SepeteEklenme
{
    public int EklenmeId { get; set; }

    public int? SepetId { get; set; }

    public int? KullaniciId { get; set; }

    public DateTime? Tarih { get; set; }

    public bool? SatisBasari { get; set; }

    public virtual Kullanici? Kullanici { get; set; }

    public virtual Sepet? Sepet { get; set; }
}
