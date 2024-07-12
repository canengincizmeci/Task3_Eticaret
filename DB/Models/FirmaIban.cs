using System;
using System.Collections.Generic;

namespace DB.Models;

public partial class FirmaIban
{
    public int FirmaIbanId { get; set; }

    public string? Iban { get; set; }

    public string? AliciIsim { get; set; }

    public int? FirmaId { get; set; }

    public DateTime? EklenmeTarihi { get; set; }

    public bool? Aktiflik { get; set; }

    public virtual Firma? Firma { get; set; }
}
