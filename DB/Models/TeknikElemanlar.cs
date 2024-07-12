using System;
using System.Collections.Generic;

namespace DB.Models;

public partial class TeknikElemanlar
{
    public int TeknikElemanId { get; set; }

    public string? ElemanAd { get; set; }

    public string? Unvan { get; set; }

    public DateTime? GirisTarihi { get; set; }

    public string? Mail { get; set; }

    public int? Puan { get; set; }

    public string? Sifre { get; set; }

    public bool? Aktiflik { get; set; }

    public virtual ICollection<AdmindenTeknikDestegeMesaj> AdmindenTeknikDestegeMesajs { get; set; } = new List<AdmindenTeknikDestegeMesaj>();

    public virtual ICollection<FirmadanTeknikElemanaMesaj> FirmadanTeknikElemanaMesajs { get; set; } = new List<FirmadanTeknikElemanaMesaj>();

    public virtual ICollection<FirmadanTeknikElemanaSikayet> FirmadanTeknikElemanaSikayets { get; set; } = new List<FirmadanTeknikElemanaSikayet>();

    public virtual ICollection<KargoFirmadanTeknikElmanSikayeti> KargoFirmadanTeknikElmanSikayetis { get; set; } = new List<KargoFirmadanTeknikElmanSikayeti>();

    public virtual ICollection<KargodanTeknikElemanaMesaj> KargodanTeknikElemanaMesajs { get; set; } = new List<KargodanTeknikElemanaMesaj>();

    public virtual ICollection<KullanicidanTeknikDestegeMesaj> KullanicidanTeknikDestegeMesajs { get; set; } = new List<KullanicidanTeknikDestegeMesaj>();

    public virtual ICollection<KullanicidanTeknikElemanaSikayet> KullanicidanTeknikElemanaSikayets { get; set; } = new List<KullanicidanTeknikElemanaSikayet>();

    public virtual ICollection<TeknikDenKargoyaMesaj> TeknikDenKargoyaMesajs { get; set; } = new List<TeknikDenKargoyaMesaj>();

    public virtual ICollection<TeknikElemanCikislar> TeknikElemanCikislars { get; set; } = new List<TeknikElemanCikislar>();

    public virtual ICollection<TeknikElemanGirisler> TeknikElemanGirislers { get; set; } = new List<TeknikElemanGirisler>();

    public virtual ICollection<TeknikElemandanKargoSikayeti> TeknikElemandanKargoSikayetis { get; set; } = new List<TeknikElemandanKargoSikayeti>();

    public virtual ICollection<TeknikElemanlarArasıMesaj> TeknikElemanlarArasıMesajAlıcıElemanNavigations { get; set; } = new List<TeknikElemanlarArasıMesaj>();

    public virtual ICollection<TeknikElemanlarArasıMesaj> TeknikElemanlarArasıMesajGonderenElemanNavigations { get; set; } = new List<TeknikElemanlarArasıMesaj>();

    public virtual ICollection<TeknikdenAdmineMesaj> TeknikdenAdmineMesajs { get; set; } = new List<TeknikdenAdmineMesaj>();

    public virtual ICollection<TeknikdenFirmayaMesaj> TeknikdenFirmayaMesajs { get; set; } = new List<TeknikdenFirmayaMesaj>();

    public virtual ICollection<TeknikdenKullaniciyaMesaj> TeknikdenKullaniciyaMesajs { get; set; } = new List<TeknikdenKullaniciyaMesaj>();
}
