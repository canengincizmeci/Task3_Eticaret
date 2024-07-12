using System;
using System.Collections.Generic;

namespace DB.Models;

public partial class SosyalSorumlulukGorevi
{
    public int GorevId { get; set; }

    public string? GorevAd { get; set; }

    public string? GorevAciklama { get; set; }

    public DateTime? BaslangicTarihi { get; set; }

    public DateTime? BitisTarihi { get; set; }

    public bool? Aktiflik { get; set; }

    public virtual ICollection<SosyalSorumlulukKatilanFirmalar> SosyalSorumlulukKatilanFirmalars { get; set; } = new List<SosyalSorumlulukKatilanFirmalar>();

    public virtual ICollection<SosyalSorumlulukKatilanKullanicilar> SosyalSorumlulukKatilanKullanicilars { get; set; } = new List<SosyalSorumlulukKatilanKullanicilar>();
}
