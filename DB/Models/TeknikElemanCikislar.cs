using System;
using System.Collections.Generic;

namespace DB.Models;

public partial class TeknikElemanCikislar
{
    public int TeknikElemanCikisId { get; set; }

    public int? TeknikElemanId { get; set; }

    public int? TeknikElemanGirisId { get; set; }

    public DateTime? Tarih { get; set; }

    public bool? BasariDurumu { get; set; }

    public virtual TeknikElemanlar? TeknikEleman { get; set; }

    public virtual TeknikElemanGirisler? TeknikElemanGiris { get; set; }
}
