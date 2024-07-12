using System;
using System.Collections.Generic;

namespace DB.Models;

public partial class CekiliseKatılanlar
{
    public int KatilimId { get; set; }

    public int? CekilisId { get; set; }

    public int? KullaniciId { get; set; }

    public DateTime? KatilimTarihi { get; set; }

    public virtual Cekili? Cekilis { get; set; }

    public virtual Kullanici? Kullanici { get; set; }
}
