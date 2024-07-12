using System;
using System.Collections.Generic;

namespace DB.Models;

public partial class SosyalSorumlulukTalepKullanici
{
    public int TalepId { get; set; }

    public string? TalepBaslik { get; set; }

    public string? TalepMetin { get; set; }

    public int? KullaniciId { get; set; }

    public DateTime? Tarih { get; set; }

    public bool? Aktiflik { get; set; }

    public virtual Kullanici? Kullanici { get; set; }
}
