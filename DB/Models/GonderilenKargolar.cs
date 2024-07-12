using System;
using System.Collections.Generic;

namespace DB.Models;

public partial class GonderilenKargolar
{
    public int GonderilenKargoId { get; set; }

    public int? IstenenKargoId { get; set; }

    public int? KargoFirmaId { get; set; }

    public int? FirmaId { get; set; }

    public int? KargoFirmaSubeId { get; set; }

    public int? AliciId { get; set; }

    public DateTime? GonderimTarihi { get; set; }

    public DateTime? TahminiTeslimTarihi { get; set; }

    public int? GidisAdresiId { get; set; }

    public DateTime? Tarih { get; set; }

    public bool? IadeTalebi { get; set; }

    public virtual Kullanici? Alici { get; set; }

    public virtual Firma? Firma { get; set; }

    public virtual KullaniciAdresler? GidisAdresi { get; set; }

    public virtual IstenenKargolar? IstenenKargo { get; set; }

    public virtual KargoFirma? KargoFirma { get; set; }

    public virtual KargoFirmaSubeler? KargoFirmaSube { get; set; }

    public virtual ICollection<YoldaIadeTalebi> YoldaIadeTalebis { get; set; } = new List<YoldaIadeTalebi>();
}
