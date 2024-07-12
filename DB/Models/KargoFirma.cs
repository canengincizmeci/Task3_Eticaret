using System;
using System.Collections.Generic;

namespace DB.Models;

public partial class KargoFirma
{
    public int KargoFirmaId { get; set; }

    public string? KargoFirmaAd { get; set; }

    public string? KargoFirmaEmail { get; set; }

    public string? KargoFirmaTel { get; set; }

    public string? FirmaMerkezAdres { get; set; }

    public string? Ulke { get; set; }

    public bool? Aktiflik { get; set; }

    public virtual ICollection<AdmindenKargoFirmasinaBilgilendirme> AdmindenKargoFirmasinaBilgilendirmes { get; set; } = new List<AdmindenKargoFirmasinaBilgilendirme>();

    public virtual ICollection<GonderilenKargolar> GonderilenKargolars { get; set; } = new List<GonderilenKargolar>();

    public virtual ICollection<IstenenKargolar> IstenenKargolars { get; set; } = new List<IstenenKargolar>();

    public virtual ICollection<KargoBildirimler> KargoBildirimlers { get; set; } = new List<KargoBildirimler>();

    public virtual ICollection<KargoFirmaSubeler> KargoFirmaSubelers { get; set; } = new List<KargoFirmaSubeler>();

    public virtual ICollection<KargoFirmadanTeknikElmanSikayeti> KargoFirmadanTeknikElmanSikayetis { get; set; } = new List<KargoFirmadanTeknikElmanSikayeti>();

    public virtual ICollection<KargoPuanlama> KargoPuanlamas { get; set; } = new List<KargoPuanlama>();

    public virtual ICollection<KargodanTeknikElemanaMesaj> KargodanTeknikElemanaMesajs { get; set; } = new List<KargodanTeknikElemanaMesaj>();

    public virtual ICollection<KullanicidanKargoFirmasiSikayeti> KullanicidanKargoFirmasiSikayetis { get; set; } = new List<KullanicidanKargoFirmasiSikayeti>();

    public virtual ICollection<TeknikDenKargoyaMesaj> TeknikDenKargoyaMesajs { get; set; } = new List<TeknikDenKargoyaMesaj>();

    public virtual ICollection<TeknikElemandanKargoSikayeti> TeknikElemandanKargoSikayetis { get; set; } = new List<TeknikElemandanKargoSikayeti>();
}
