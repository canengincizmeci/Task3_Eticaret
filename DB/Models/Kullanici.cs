using System;
using System.Collections.Generic;

namespace DB.Models;

public partial class Kullanici
{
    public int KullaniciId { get; set; }

    public string? KullaniciAd { get; set; }

    public string? Sifre { get; set; }

    public string? Mail { get; set; }

    public string? MailSifre { get; set; }

    public int? SosyalSorumlulukKatilimSayisi { get; set; }

    public int? YorumSayisi { get; set; }

    public int? YorumCevapSayisi { get; set; }

    public int? CoinMiktari { get; set; }

    public string? Adres { get; set; }

    public string? KullaniciResim { get; set; }

    public DateTime? KayitTarihi { get; set; }

    public bool? Aktiflik { get; set; }

    public string? ReferansKullaniciAd { get; set; }

    public string? ReferansMail { get; set; }

    public int? ReferansOlmaSayisi { get; set; }

    public virtual ICollection<AdmindenKullaniciyaMesaj> AdmindenKullaniciyaMesajs { get; set; } = new List<AdmindenKullaniciyaMesaj>();

    public virtual ICollection<CekilisKazananlar> CekilisKazananlars { get; set; } = new List<CekilisKazananlar>();

    public virtual ICollection<CekiliseKatılanlar> CekiliseKatılanlars { get; set; } = new List<CekiliseKatılanlar>();

    public virtual ICollection<Favoriler> Favorilers { get; set; } = new List<Favoriler>();

    public virtual ICollection<FirmaPuanlama> FirmaPuanlamas { get; set; } = new List<FirmaPuanlama>();

    public virtual ICollection<FirmadanKullaniciyaMesaj> FirmadanKullaniciyaMesajs { get; set; } = new List<FirmadanKullaniciyaMesaj>();

    public virtual ICollection<FirmadanKullaniciyaSikayet> FirmadanKullaniciyaSikayets { get; set; } = new List<FirmadanKullaniciyaSikayet>();

    public virtual ICollection<FirmadanKullaniciyaYorumCevapSikayet> FirmadanKullaniciyaYorumCevapSikayets { get; set; } = new List<FirmadanKullaniciyaYorumCevapSikayet>();

    public virtual ICollection<FirmadanYorumSikayet> FirmadanYorumSikayets { get; set; } = new List<FirmadanYorumSikayet>();

    public virtual ICollection<GonderilenKargolar> GonderilenKargolars { get; set; } = new List<GonderilenKargolar>();

    public virtual ICollection<IadeTalep> IadeTaleps { get; set; } = new List<IadeTalep>();

    public virtual ICollection<Iadeler> Iadelers { get; set; } = new List<Iadeler>();

    public virtual ICollection<KargoBildirimler> KargoBildirimlers { get; set; } = new List<KargoBildirimler>();

    public virtual ICollection<KargoPuanlama> KargoPuanlamas { get; set; } = new List<KargoPuanlama>();

    public virtual ICollection<KullaniciAdresler> KullaniciAdreslers { get; set; } = new List<KullaniciAdresler>();

    public virtual ICollection<KullaniciCikislar> KullaniciCikislars { get; set; } = new List<KullaniciCikislar>();

    public virtual ICollection<KullaniciKartBilgileri> KullaniciKartBilgileris { get; set; } = new List<KullaniciKartBilgileri>();

    public virtual ICollection<KullaniciSiteOneriler> KullaniciSiteOnerilers { get; set; } = new List<KullaniciSiteOneriler>();

    public virtual ICollection<KullaniciYarismaKatilanlar> KullaniciYarismaKatilanlars { get; set; } = new List<KullaniciYarismaKatilanlar>();

    public virtual ICollection<KullaniciYarismaKazananlar> KullaniciYarismaKazananlars { get; set; } = new List<KullaniciYarismaKazananlar>();

    public virtual ICollection<KullaniciYorumCevap> KullaniciYorumCevaps { get; set; } = new List<KullaniciYorumCevap>();

    public virtual ICollection<KullanicidanFirmayaSikayet> KullanicidanFirmayaSikayets { get; set; } = new List<KullanicidanFirmayaSikayet>();

    public virtual ICollection<KullanicidanFirmayaYorumCevapSikayet> KullanicidanFirmayaYorumCevapSikayets { get; set; } = new List<KullanicidanFirmayaYorumCevapSikayet>();

    public virtual ICollection<KullanicidanKargoFirmasiSikayeti> KullanicidanKargoFirmasiSikayetis { get; set; } = new List<KullanicidanKargoFirmasiSikayeti>();

    public virtual ICollection<KullanicidanTeknikDestegeMesaj> KullanicidanTeknikDestegeMesajs { get; set; } = new List<KullanicidanTeknikDestegeMesaj>();

    public virtual ICollection<KullanicidanTeknikElemanaSikayet> KullanicidanTeknikElemanaSikayets { get; set; } = new List<KullanicidanTeknikElemanaSikayet>();

    public virtual ICollection<KullanicidanYorumSikayet> KullanicidanYorumSikayetBildirilenKullanicis { get; set; } = new List<KullanicidanYorumSikayet>();

    public virtual ICollection<KullanicidanYorumSikayet> KullanicidanYorumSikayetSikayetciKullanicis { get; set; } = new List<KullanicidanYorumSikayet>();

    public virtual ICollection<KullanicilarArasiMesaj> KullanicilarArasiMesajAliciKullanicis { get; set; } = new List<KullanicilarArasiMesaj>();

    public virtual ICollection<KullanicilarArasiMesaj> KullanicilarArasiMesajGonderenKullanicis { get; set; } = new List<KullanicilarArasiMesaj>();

    public virtual ICollection<Odemeler> Odemelers { get; set; } = new List<Odemeler>();

    public virtual ICollection<OnaysızSiparisIptal> OnaysızSiparisIptals { get; set; } = new List<OnaysızSiparisIptal>();

    public virtual ICollection<ReferansOlmusKullanicilar> ReferansOlmusKullanicilarKayıtOlanKullanicis { get; set; } = new List<ReferansOlmusKullanicilar>();

    public virtual ICollection<ReferansOlmusKullanicilar> ReferansOlmusKullanicilarReferansKullanicis { get; set; } = new List<ReferansOlmusKullanicilar>();

    public virtual ICollection<SatisRed> SatisReds { get; set; } = new List<SatisRed>();

    public virtual ICollection<Satislar> Satislars { get; set; } = new List<Satislar>();

    public virtual ICollection<SepeteEklenme> SepeteEklenmes { get; set; } = new List<SepeteEklenme>();

    public virtual ICollection<Sepet> Sepets { get; set; } = new List<Sepet>();

    public virtual ICollection<SepettenCikarma> SepettenCikarmas { get; set; } = new List<SepettenCikarma>();

    public virtual ICollection<Siparisler> Siparislers { get; set; } = new List<Siparisler>();

    public virtual ICollection<SosyalSorumlulukKatilanKullanicilar> SosyalSorumlulukKatilanKullanicilars { get; set; } = new List<SosyalSorumlulukKatilanKullanicilar>();

    public virtual ICollection<SosyalSorumlulukTalepKullanici> SosyalSorumlulukTalepKullanicis { get; set; } = new List<SosyalSorumlulukTalepKullanici>();

    public virtual ICollection<Talepler> Taleplers { get; set; } = new List<Talepler>();

    public virtual ICollection<TeknikdenKullaniciyaMesaj> TeknikdenKullaniciyaMesajs { get; set; } = new List<TeknikdenKullaniciyaMesaj>();

    public virtual ICollection<UrunPuanlama> UrunPuanlamas { get; set; } = new List<UrunPuanlama>();

    public virtual ICollection<UrunSikayet> UrunSikayets { get; set; } = new List<UrunSikayet>();

    public virtual ICollection<YoldaIadeTalebi> YoldaIadeTalebis { get; set; } = new List<YoldaIadeTalebi>();

    public virtual ICollection<Yorumlar> Yorumlars { get; set; } = new List<Yorumlar>();
}
