using System;
using System.Collections.Generic;

namespace DB.Models;

public partial class AdmindenKargoFirmasinaBilgilendirme
{
    public int BilgilendirmeId { get; set; }

    public int? AdminId { get; set; }

    public int? KargoFirmaId { get; set; }

    public string? BilgilendirmeBaslik { get; set; }

    public string? BilgilendirmeMetin { get; set; }

    public DateTime? Tarih { get; set; }

    public bool? Aktiflik { get; set; }

    public bool? OkunduBilgisi { get; set; }

    public virtual Admin? Admin { get; set; }

    public virtual KargoFirma? KargoFirma { get; set; }
}
