using System;
using System.Collections.Generic;

namespace DB.Models;

public partial class SikcaSorulanlar
{
    public int SorulmaId { get; set; }

    public string? Soru { get; set; }

    public string? Cevap { get; set; }

    public bool? Aktiflik { get; set; }
}
