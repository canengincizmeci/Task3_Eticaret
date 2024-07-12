using System;
using System.Collections.Generic;

namespace DB.Models;

public partial class TeknikElemanBasvuru
{
    public int BasvuruId { get; set; }

    public string? Ad { get; set; }

    public string? Soyad { get; set; }

    public string? Adres { get; set; }

    public DateOnly? DogumTarihi { get; set; }

    public string? Ozgecmis { get; set; }

    public string? Cinsiyet { get; set; }

    public string? TcNo { get; set; }

    public string? Mail { get; set; }

    public string? MezuniyetDurumu { get; set; }

    public string? TelefonNumarasi { get; set; }
}
