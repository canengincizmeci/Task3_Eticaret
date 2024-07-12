using System;
using System.Collections.Generic;

namespace DB.Models;

public partial class UrunPuanlama
{
    public int UrunPuanlamaId { get; set; }

    public int? KullaniciId { get; set; }

    public int? UrunId { get; set; }

    public int? Puan { get; set; }

    public DateTime? Tarih { get; set; }

    public bool? Aktiflik { get; set; }

    public virtual Kullanici? Kullanici { get; set; }

    public virtual Urun? Urun { get; set; }
}
