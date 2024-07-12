using System;
using System.Collections.Generic;

namespace DB.Models;

public partial class AdminLoginGirisler
{
    public int GirisId { get; set; }

    public int? AdminId { get; set; }

    public DateTime? Tarih { get; set; }

    public bool? Basari { get; set; }

    public virtual Admin? Admin { get; set; }
}
