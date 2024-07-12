using System;
using System.Collections.Generic;

namespace DB.Models;

public partial class Firma
{
    public int FirmaId { get; set; }

    public string? FirmaAd { get; set; }

    public string? FirmaAdres { get; set; }

    public int? SatisSayisi { get; set; }

    public int? CoinMiktari { get; set; }

    public string? Mail { get; set; }

    public string? MailSifre { get; set; }

    public int? Puan { get; set; }

    public int? SosyalSorumlulukKatılımSayisi { get; set; }

    public string? Sifre { get; set; }

    public string? TelefonNumarasi { get; set; }

    public bool? Aktiflik { get; set; }

    public virtual ICollection<AdmindenFirmayaMesaj> AdmindenFirmayaMesajs { get; set; } = new List<AdmindenFirmayaMesaj>();

    public virtual ICollection<FirmaCikislar> FirmaCikislars { get; set; } = new List<FirmaCikislar>();

    public virtual ICollection<FirmaGirisler> FirmaGirislers { get; set; } = new List<FirmaGirisler>();

    public virtual ICollection<FirmaIban> FirmaIbans { get; set; } = new List<FirmaIban>();

    public virtual ICollection<FirmaKampanyalar> FirmaKampanyalars { get; set; } = new List<FirmaKampanyalar>();

    public virtual ICollection<FirmaPuanlama> FirmaPuanlamas { get; set; } = new List<FirmaPuanlama>();

    public virtual ICollection<FirmaSosyalMedyalar> FirmaSosyalMedyalars { get; set; } = new List<FirmaSosyalMedyalar>();

    public virtual ICollection<FirmaYarismaKazanlar> FirmaYarismaKazanlars { get; set; } = new List<FirmaYarismaKazanlar>();

    public virtual ICollection<FirmaYarismasiKatilanlar> FirmaYarismasiKatilanlars { get; set; } = new List<FirmaYarismasiKatilanlar>();

    public virtual ICollection<FirmaYorumCevap> FirmaYorumCevaps { get; set; } = new List<FirmaYorumCevap>();

    public virtual ICollection<FirmadanKullaniciyaMesaj> FirmadanKullaniciyaMesajs { get; set; } = new List<FirmadanKullaniciyaMesaj>();

    public virtual ICollection<FirmadanKullaniciyaSikayet> FirmadanKullaniciyaSikayets { get; set; } = new List<FirmadanKullaniciyaSikayet>();

    public virtual ICollection<FirmadanKullaniciyaYorumCevapSikayet> FirmadanKullaniciyaYorumCevapSikayets { get; set; } = new List<FirmadanKullaniciyaYorumCevapSikayet>();

    public virtual ICollection<FirmadanSiteOneriler> FirmadanSiteOnerilers { get; set; } = new List<FirmadanSiteOneriler>();

    public virtual ICollection<FirmadanTeknikElemanaMesaj> FirmadanTeknikElemanaMesajs { get; set; } = new List<FirmadanTeknikElemanaMesaj>();

    public virtual ICollection<FirmadanTeknikElemanaSikayet> FirmadanTeknikElemanaSikayets { get; set; } = new List<FirmadanTeknikElemanaSikayet>();

    public virtual ICollection<FirmadanYorumSikayet> FirmadanYorumSikayets { get; set; } = new List<FirmadanYorumSikayet>();

    public virtual ICollection<GonderilenKargolar> GonderilenKargolars { get; set; } = new List<GonderilenKargolar>();

    public virtual ICollection<IstenenKargolar> IstenenKargolars { get; set; } = new List<IstenenKargolar>();

    public virtual ICollection<KullanicidanFirmayaSikayet> KullanicidanFirmayaSikayets { get; set; } = new List<KullanicidanFirmayaSikayet>();

    public virtual ICollection<KullanicidanFirmayaYorumCevapSikayet> KullanicidanFirmayaYorumCevapSikayets { get; set; } = new List<KullanicidanFirmayaYorumCevapSikayet>();

    public virtual ICollection<SatisRed> SatisReds { get; set; } = new List<SatisRed>();

    public virtual ICollection<Satislar> Satislars { get; set; } = new List<Satislar>();

    public virtual ICollection<SosyalSorumlulukKatilanFirmalar> SosyalSorumlulukKatilanFirmalars { get; set; } = new List<SosyalSorumlulukKatilanFirmalar>();

    public virtual ICollection<SosyalSorumlulukTalepFirma> SosyalSorumlulukTalepFirmas { get; set; } = new List<SosyalSorumlulukTalepFirma>();

    public virtual ICollection<TeknikdenFirmayaMesaj> TeknikdenFirmayaMesajs { get; set; } = new List<TeknikdenFirmayaMesaj>();

    public virtual ICollection<Urun> Uruns { get; set; } = new List<Urun>();

    public virtual ICollection<YoldaIadeTalebi> YoldaIadeTalebis { get; set; } = new List<YoldaIadeTalebi>();
}
