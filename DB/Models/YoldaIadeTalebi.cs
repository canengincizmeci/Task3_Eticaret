using System;
using System.Collections.Generic;

namespace DB.Models;

public partial class YoldaIadeTalebi
{
    public int YoldaIadeTalebiId { get; set; }

    public int? GonderilenKargoId { get; set; }

    public string? IadeAciklama { get; set; }

    public int? KullaniciId { get; set; }

    public int? FirmaId { get; set; }

    public DateTime? Tarih { get; set; }

    public bool? Onay { get; set; }

    public virtual Firma? Firma { get; set; }

    public virtual GonderilenKargolar? GonderilenKargo { get; set; }

    public virtual Kullanici? Kullanici { get; set; }
}
