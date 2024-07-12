using System;
using System.Collections.Generic;

namespace DB.Models;

public partial class ReferansOlmusKullanicilar
{
    public int ReferansOlmaId { get; set; }

    public int? ReferansKullaniciId { get; set; }

    public int? KayıtOlanKullaniciId { get; set; }

    public DateTime? Tarih { get; set; }

    public bool? Aktiflik { get; set; }

    public virtual Kullanici? KayıtOlanKullanici { get; set; }

    public virtual Kullanici? ReferansKullanici { get; set; }
}
