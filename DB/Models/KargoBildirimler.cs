using System;
using System.Collections.Generic;

namespace DB.Models;

public partial class KargoBildirimler
{
    public int KargoBildirimId { get; set; }

    public int? KargoFirmaId { get; set; }

    public int? KullaniciId { get; set; }

    public string? KargoBildirimBaslik { get; set; }

    public string? KargoBildirim { get; set; }

    public DateTime? Tarih { get; set; }

    public bool? OkunduBilgisi { get; set; }

    public bool? Aktiflik { get; set; }

    public virtual KargoFirma? KargoFirma { get; set; }

    public virtual Kullanici? Kullanici { get; set; }
}
