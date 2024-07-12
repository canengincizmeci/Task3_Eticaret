using System;
using System.Collections.Generic;

namespace DB.Models;

public partial class KargoPuanlama
{
    public int KargoPuanlamaId { get; set; }

    public int? KullaniciId { get; set; }

    public int? KargoFirmaId { get; set; }

    public int? Puan { get; set; }

    public DateTime? Tarih { get; set; }

    public bool? Aktiflik { get; set; }

    public virtual KargoFirma? KargoFirma { get; set; }

    public virtual Kullanici? Kullanici { get; set; }
}
