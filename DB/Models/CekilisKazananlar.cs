using System;
using System.Collections.Generic;

namespace DB.Models;

public partial class CekilisKazananlar
{
    public int KazanmaId { get; set; }

    public int? KullaniciId { get; set; }

    public int? CekilisId { get; set; }

    public DateTime? KazanmaTarihi { get; set; }

    public virtual Cekili? Cekilis { get; set; }

    public virtual Kullanici? Kullanici { get; set; }
}
