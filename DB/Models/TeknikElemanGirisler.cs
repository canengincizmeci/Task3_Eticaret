using System;
using System.Collections.Generic;

namespace DB.Models;

public partial class TeknikElemanGirisler
{
    public int GirisId { get; set; }

    public int? ElemanId { get; set; }

    public bool? GirisBasariDurumu { get; set; }

    public DateTime? Tarih { get; set; }

    public virtual TeknikElemanlar? Eleman { get; set; }

    public virtual ICollection<TeknikElemanCikislar> TeknikElemanCikislars { get; set; } = new List<TeknikElemanCikislar>();
}
