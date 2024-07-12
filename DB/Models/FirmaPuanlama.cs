using System;
using System.Collections.Generic;

namespace DB.Models;

public partial class FirmaPuanlama
{
    public int FirmaPuanlamaId { get; set; }

    public int? KullaniciId { get; set; }

    public int? FirmaId { get; set; }

    public int? Puan { get; set; }

    public DateTime? Tarih { get; set; }

    public bool? Aktiflik { get; set; }

    public virtual Firma? Firma { get; set; }

    public virtual Kullanici? Kullanici { get; set; }
}
