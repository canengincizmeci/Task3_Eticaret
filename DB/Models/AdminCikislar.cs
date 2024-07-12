using System;
using System.Collections.Generic;

namespace DB.Models;

public partial class AdminCikislar
{
    public int AdminCikisId { get; set; }

    public int? AdminId { get; set; }

    public int? AdminGirisId { get; set; }

    public DateTime? Tarih { get; set; }

    public bool? BasariDurumu { get; set; }

    public virtual Admin? Admin { get; set; }

    public virtual AdminMailGirisler? AdminGiris { get; set; }
}
