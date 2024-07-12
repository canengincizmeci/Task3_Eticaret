using System;
using System.Collections.Generic;

namespace DB.Models;

public partial class KullanicilarArasiMesaj
{
    public int MesajId { get; set; }

    public int? AliciKullaniciId { get; set; }

    public int? GonderenKullaniciId { get; set; }

    public string? Mesaj { get; set; }

    public string? MesajBaslik { get; set; }

    public DateTime? Tarih { get; set; }

    public bool? Aktiflik { get; set; }

    public int? MesajlasmaId { get; set; }

    public bool? OkunduBilgisi { get; set; }

    public virtual Kullanici? AliciKullanici { get; set; }

    public virtual Kullanici? GonderenKullanici { get; set; }

    public virtual Mesajlasma? Mesajlasma { get; set; }
}
