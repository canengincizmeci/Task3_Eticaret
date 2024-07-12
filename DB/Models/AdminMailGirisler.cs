using System;
using System.Collections.Generic;

namespace DB.Models;

public partial class AdminMailGirisler
{
    public int GirisId { get; set; }

    public int? AdminId { get; set; }

    public DateTime? Tarih { get; set; }

    public bool? Basari { get; set; }

    public virtual Admin? Admin { get; set; }

    public virtual ICollection<AdminCikislar> AdminCikislars { get; set; } = new List<AdminCikislar>();
}
