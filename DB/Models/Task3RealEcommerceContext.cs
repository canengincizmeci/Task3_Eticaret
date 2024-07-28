using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DB.Models;

public partial class Task3RealEcommerceContext : DbContext
{
    public Task3RealEcommerceContext()
    {
    }

    public Task3RealEcommerceContext(DbContextOptions<Task3RealEcommerceContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<AdminCikislar> AdminCikislars { get; set; }

    public virtual DbSet<AdminLoginGirisler> AdminLoginGirislers { get; set; }

    public virtual DbSet<AdminMailGirisler> AdminMailGirislers { get; set; }

    public virtual DbSet<AdmindenFirmayaMesaj> AdmindenFirmayaMesajs { get; set; }

    public virtual DbSet<AdmindenKargoFirmasinaBilgilendirme> AdmindenKargoFirmasinaBilgilendirmes { get; set; }

    public virtual DbSet<AdmindenKullaniciyaMesaj> AdmindenKullaniciyaMesajs { get; set; }

    public virtual DbSet<AdmindenTeknikDestegeMesaj> AdmindenTeknikDestegeMesajs { get; set; }

    public virtual DbSet<ArananKelimeler> ArananKelimelers { get; set; }

    public virtual DbSet<Cekili> Cekilis { get; set; }

    public virtual DbSet<CekilisKazananlar> CekilisKazananlars { get; set; }

    public virtual DbSet<CekiliseKatılanlar> CekiliseKatılanlars { get; set; }

    public virtual DbSet<EnCokArananKategori> EnCokArananKategoris { get; set; }

    public virtual DbSet<EnCokArananKelimeler> EnCokArananKelimelers { get; set; }

    public virtual DbSet<EnCokArananUrun> EnCokArananUruns { get; set; }

    public virtual DbSet<FavoriCikarma> FavoriCikarmas { get; set; }

    public virtual DbSet<FavoriEklenme> FavoriEklenmes { get; set; }

    public virtual DbSet<Favoriler> Favorilers { get; set; }

    public virtual DbSet<Firma> Firmas { get; set; }

    public virtual DbSet<FirmaBasvuru> FirmaBasvurus { get; set; }

    public virtual DbSet<FirmaCikislar> FirmaCikislars { get; set; }

    public virtual DbSet<FirmaGirisler> FirmaGirislers { get; set; }

    public virtual DbSet<FirmaIban> FirmaIbans { get; set; }

    public virtual DbSet<FirmaKampanyalar> FirmaKampanyalars { get; set; }

    public virtual DbSet<FirmaPuanlama> FirmaPuanlamas { get; set; }

    public virtual DbSet<FirmaSosyalMedyalar> FirmaSosyalMedyalars { get; set; }

    public virtual DbSet<FirmaYarismaKazanlar> FirmaYarismaKazanlars { get; set; }

    public virtual DbSet<FirmaYarismalar> FirmaYarismalars { get; set; }

    public virtual DbSet<FirmaYarismasiKatilanlar> FirmaYarismasiKatilanlars { get; set; }

    public virtual DbSet<FirmaYorumCevap> FirmaYorumCevaps { get; set; }

    public virtual DbSet<FirmadanKullaniciyaMesaj> FirmadanKullaniciyaMesajs { get; set; }

    public virtual DbSet<FirmadanKullaniciyaSikayet> FirmadanKullaniciyaSikayets { get; set; }

    public virtual DbSet<FirmadanKullaniciyaYorumCevapSikayet> FirmadanKullaniciyaYorumCevapSikayets { get; set; }

    public virtual DbSet<FirmadanSiteOneriler> FirmadanSiteOnerilers { get; set; }

    public virtual DbSet<FirmadanTeknikElemanaMesaj> FirmadanTeknikElemanaMesajs { get; set; }

    public virtual DbSet<FirmadanTeknikElemanaSikayet> FirmadanTeknikElemanaSikayets { get; set; }

    public virtual DbSet<FirmadanYorumSikayet> FirmadanYorumSikayets { get; set; }

    public virtual DbSet<GenelKampanyalar> GenelKampanyalars { get; set; }

    public virtual DbSet<GonderilenKargolar> GonderilenKargolars { get; set; }

    public virtual DbSet<IadeTalep> IadeTaleps { get; set; }

    public virtual DbSet<Iadeler> Iadelers { get; set; }

    public virtual DbSet<IstenenKargolar> IstenenKargolars { get; set; }

    public virtual DbSet<KargoBildirimler> KargoBildirimlers { get; set; }

    public virtual DbSet<KargoFirma> KargoFirmas { get; set; }

    public virtual DbSet<KargoFirmaSubeler> KargoFirmaSubelers { get; set; }

    public virtual DbSet<KargoFirmadanTeknikElmanSikayeti> KargoFirmadanTeknikElmanSikayetis { get; set; }

    public virtual DbSet<KargoPuanlama> KargoPuanlamas { get; set; }

    public virtual DbSet<KargodanTeknikElemanaMesaj> KargodanTeknikElemanaMesajs { get; set; }

    public virtual DbSet<Kategori> Kategoris { get; set; }

    public virtual DbSet<KategoriKampanyalar> KategoriKampanyalars { get; set; }

    public virtual DbSet<Kullanici> Kullanicis { get; set; }

    public virtual DbSet<KullaniciAdresler> KullaniciAdreslers { get; set; }

    public virtual DbSet<KullaniciCikislar> KullaniciCikislars { get; set; }

    public virtual DbSet<KullaniciGirisler> KullaniciGirislers { get; set; }

    public virtual DbSet<KullaniciKartBilgileri> KullaniciKartBilgileris { get; set; }

    public virtual DbSet<KullaniciSiteOneriler> KullaniciSiteOnerilers { get; set; }

    public virtual DbSet<KullaniciYarismaKatilanlar> KullaniciYarismaKatilanlars { get; set; }

    public virtual DbSet<KullaniciYarismaKazananlar> KullaniciYarismaKazananlars { get; set; }

    public virtual DbSet<KullaniciYarismalar> KullaniciYarismalars { get; set; }

    public virtual DbSet<KullaniciYorumCevap> KullaniciYorumCevaps { get; set; }

    public virtual DbSet<KullanicidanFirmayaSikayet> KullanicidanFirmayaSikayets { get; set; }

    public virtual DbSet<KullanicidanFirmayaYorumCevapSikayet> KullanicidanFirmayaYorumCevapSikayets { get; set; }

    public virtual DbSet<KullanicidanKargoFirmasiSikayeti> KullanicidanKargoFirmasiSikayetis { get; set; }

    public virtual DbSet<KullanicidanTeknikDestegeMesaj> KullanicidanTeknikDestegeMesajs { get; set; }

    public virtual DbSet<KullanicidanTeknikElemanaSikayet> KullanicidanTeknikElemanaSikayets { get; set; }

    public virtual DbSet<KullanicidanYorumSikayet> KullanicidanYorumSikayets { get; set; }

    public virtual DbSet<KullanicilarArasiMesaj> KullanicilarArasiMesajs { get; set; }

    public virtual DbSet<Mesajlasma> Mesajlasmas { get; set; }

    public virtual DbSet<Odemeler> Odemelers { get; set; }

    public virtual DbSet<OnaysızSiparisIptal> OnaysızSiparisIptals { get; set; }

    public virtual DbSet<ReddedilenSiparisler> ReddedilenSiparislers { get; set; }

    public virtual DbSet<ReferansOlmusKullanicilar> ReferansOlmusKullanicilars { get; set; }

    public virtual DbSet<SatisRed> SatisReds { get; set; }

    public virtual DbSet<Satislar> Satislars { get; set; }

    public virtual DbSet<Sepet> Sepets { get; set; }

    public virtual DbSet<SepeteEklenme> SepeteEklenmes { get; set; }

    public virtual DbSet<SepettenCikarma> SepettenCikarmas { get; set; }

    public virtual DbSet<SikcaSorulanlar> SikcaSorulanlars { get; set; }

    public virtual DbSet<SiparisKalemler> SiparisKalemlers { get; set; }

    public virtual DbSet<Siparisler> Siparislers { get; set; }

    public virtual DbSet<SosyalSorumlulukGorevi> SosyalSorumlulukGorevis { get; set; }

    public virtual DbSet<SosyalSorumlulukKatilanFirmalar> SosyalSorumlulukKatilanFirmalars { get; set; }

    public virtual DbSet<SosyalSorumlulukKatilanKullanicilar> SosyalSorumlulukKatilanKullanicilars { get; set; }

    public virtual DbSet<SosyalSorumlulukTalepFirma> SosyalSorumlulukTalepFirmas { get; set; }

    public virtual DbSet<SosyalSorumlulukTalepKullanici> SosyalSorumlulukTalepKullanicis { get; set; }

    public virtual DbSet<SureliKuponlar> SureliKuponlars { get; set; }

    public virtual DbSet<Talepler> Taleplers { get; set; }

    public virtual DbSet<TeknikDenKargoyaMesaj> TeknikDenKargoyaMesajs { get; set; }

    public virtual DbSet<TeknikElemanBasvuru> TeknikElemanBasvurus { get; set; }

    public virtual DbSet<TeknikElemanCikislar> TeknikElemanCikislars { get; set; }

    public virtual DbSet<TeknikElemanGirisler> TeknikElemanGirislers { get; set; }

    public virtual DbSet<TeknikElemandanKargoSikayeti> TeknikElemandanKargoSikayetis { get; set; }

    public virtual DbSet<TeknikElemanlar> TeknikElemanlars { get; set; }

    public virtual DbSet<TeknikElemanlarArasıMesaj> TeknikElemanlarArasıMesajs { get; set; }

    public virtual DbSet<TeknikdenAdmineMesaj> TeknikdenAdmineMesajs { get; set; }

    public virtual DbSet<TeknikdenFirmayaMesaj> TeknikdenFirmayaMesajs { get; set; }

    public virtual DbSet<TeknikdenKullaniciyaMesaj> TeknikdenKullaniciyaMesajs { get; set; }

    public virtual DbSet<Urun> Uruns { get; set; }

    public virtual DbSet<UrunGoruntulenme> UrunGoruntulenmes { get; set; }

    public virtual DbSet<UrunKampanyalar> UrunKampanyalars { get; set; }

    public virtual DbSet<UrunPuanlama> UrunPuanlamas { get; set; }

    public virtual DbSet<UrunSikayet> UrunSikayets { get; set; }

    public virtual DbSet<UyeOlmayanBagiscilar> UyeOlmayanBagiscilars { get; set; }

    public virtual DbSet<YoldaIadeTalebi> YoldaIadeTalebis { get; set; }

    public virtual DbSet<Yorumlar> Yorumlars { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-CGDTBSJ\\MSSQLSERVER5;Database=Task3_RealEcommerce;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.AdminId).HasName("PK__Admin__AD0500A66AEB6F6C");

            entity.ToTable("Admin");

            entity.Property(e => e.AdminId).HasColumnName("adminId");
            entity.Property(e => e.AdminAd)
                .HasMaxLength(30)
                .HasColumnName("adminAd");
            entity.Property(e => e.AdminSifre)
                .HasMaxLength(20)
                .HasColumnName("adminSifre");
            entity.Property(e => e.Aktiflik).HasColumnName("aktiflik");
            entity.Property(e => e.Mail)
                .HasMaxLength(40)
                .HasColumnName("mail");
            entity.Property(e => e.MailSifre)
                .HasMaxLength(30)
                .HasColumnName("mailSifre");
        });

        modelBuilder.Entity<AdminCikislar>(entity =>
        {
            entity.HasKey(e => e.AdminCikisId).HasName("PK__AdminCik__9B7B0A3E599BBEB9");

            entity.ToTable("AdminCikislar");

            entity.Property(e => e.AdminCikisId).HasColumnName("adminCikisId");
            entity.Property(e => e.AdminGirisId).HasColumnName("adminGirisId");
            entity.Property(e => e.AdminId).HasColumnName("adminId");
            entity.Property(e => e.BasariDurumu).HasColumnName("basariDurumu");
            entity.Property(e => e.Tarih)
                .HasColumnType("datetime")
                .HasColumnName("tarih");

            entity.HasOne(d => d.AdminGiris).WithMany(p => p.AdminCikislars)
                .HasForeignKey(d => d.AdminGirisId)
                .HasConstraintName("FK__AdminCiki__admin__41B8C09B");

            entity.HasOne(d => d.Admin).WithMany(p => p.AdminCikislars)
                .HasForeignKey(d => d.AdminId)
                .HasConstraintName("FK__AdminCiki__admin__40C49C62");
        });

        modelBuilder.Entity<AdminLoginGirisler>(entity =>
        {
            entity.HasKey(e => e.GirisId).HasName("PK__AdminLog__F8F62BEFAE8A079D");

            entity.ToTable("AdminLoginGirisler");

            entity.Property(e => e.GirisId).HasColumnName("girisId");
            entity.Property(e => e.AdminId).HasColumnName("adminId");
            entity.Property(e => e.Basari).HasColumnName("basari");
            entity.Property(e => e.Tarih)
                .HasColumnType("datetime")
                .HasColumnName("tarih");

            entity.HasOne(d => d.Admin).WithMany(p => p.AdminLoginGirislers)
                .HasForeignKey(d => d.AdminId)
                .HasConstraintName("FK__AdminLogi__admin__38996AB5");
        });

        modelBuilder.Entity<AdminMailGirisler>(entity =>
        {
            entity.HasKey(e => e.GirisId).HasName("PK__AdminMai__F8F62BEFC1B67F91");

            entity.ToTable("AdminMailGirisler");

            entity.Property(e => e.GirisId).HasColumnName("girisId");
            entity.Property(e => e.AdminId).HasColumnName("adminId");
            entity.Property(e => e.Basari).HasColumnName("basari");
            entity.Property(e => e.Tarih)
                .HasColumnType("datetime")
                .HasColumnName("tarih");

            entity.HasOne(d => d.Admin).WithMany(p => p.AdminMailGirislers)
                .HasForeignKey(d => d.AdminId)
                .HasConstraintName("FK__AdminMail__admin__3B75D760");
        });

        modelBuilder.Entity<AdmindenFirmayaMesaj>(entity =>
        {
            entity.HasKey(e => e.MesajId).HasName("PK__Adminden__FFB37EE487EBD3A7");

            entity.ToTable("AdmindenFirmayaMesaj");

            entity.Property(e => e.MesajId).HasColumnName("mesajId");
            entity.Property(e => e.AdminId).HasColumnName("adminId");
            entity.Property(e => e.FirmaId).HasColumnName("firmaId");
            entity.Property(e => e.Mesaj)
                .HasMaxLength(500)
                .HasColumnName("mesaj");
            entity.Property(e => e.MesajBaslik)
                .HasMaxLength(20)
                .HasColumnName("mesajBaslik");
            entity.Property(e => e.MesajlasmaId).HasColumnName("mesajlasmaId");
            entity.Property(e => e.OkunduBilgisi).HasColumnName("okunduBilgisi");
            entity.Property(e => e.Tarih)
                .HasColumnType("datetime")
                .HasColumnName("tarih");

            entity.HasOne(d => d.Admin).WithMany(p => p.AdmindenFirmayaMesajs)
                .HasForeignKey(d => d.AdminId)
                .HasConstraintName("FK__AdmindenF__admin__4316F928");

            entity.HasOne(d => d.Firma).WithMany(p => p.AdmindenFirmayaMesajs)
                .HasForeignKey(d => d.FirmaId)
                .HasConstraintName("FK__AdmindenF__firma__4222D4EF");

            entity.HasOne(d => d.Mesajlasma).WithMany(p => p.AdmindenFirmayaMesajs)
                .HasForeignKey(d => d.MesajlasmaId)
                .HasConstraintName("FK__AdmindenF__mesaj__440B1D61");
        });

        modelBuilder.Entity<AdmindenKargoFirmasinaBilgilendirme>(entity =>
        {
            entity.HasKey(e => e.BilgilendirmeId).HasName("PK__Adminden__00348F3AEF765600");

            entity.ToTable("AdmindenKargoFirmasinaBilgilendirme");

            entity.Property(e => e.BilgilendirmeId).HasColumnName("bilgilendirmeId");
            entity.Property(e => e.AdminId).HasColumnName("adminId");
            entity.Property(e => e.Aktiflik).HasColumnName("aktiflik");
            entity.Property(e => e.BilgilendirmeBaslik)
                .HasMaxLength(20)
                .HasColumnName("bilgilendirmeBaslik");
            entity.Property(e => e.BilgilendirmeMetin)
                .HasMaxLength(1000)
                .HasColumnName("bilgilendirmeMetin");
            entity.Property(e => e.KargoFirmaId).HasColumnName("kargoFirmaId");
            entity.Property(e => e.OkunduBilgisi).HasColumnName("okunduBilgisi");
            entity.Property(e => e.Tarih)
                .HasColumnType("datetime")
                .HasColumnName("tarih");

            entity.HasOne(d => d.Admin).WithMany(p => p.AdmindenKargoFirmasinaBilgilendirmes)
                .HasForeignKey(d => d.AdminId)
                .HasConstraintName("FK__AdmindenK__admin__3F9B6DFF");

            entity.HasOne(d => d.KargoFirma).WithMany(p => p.AdmindenKargoFirmasinaBilgilendirmes)
                .HasForeignKey(d => d.KargoFirmaId)
                .HasConstraintName("FK__AdmindenK__kargo__408F9238");
        });

        modelBuilder.Entity<AdmindenKullaniciyaMesaj>(entity =>
        {
            entity.HasKey(e => e.MesajId).HasName("PK__Adminden__FFB37EE4C6DF9BE2");

            entity.ToTable("AdmindenKullaniciyaMesaj");

            entity.Property(e => e.MesajId).HasColumnName("mesajId");
            entity.Property(e => e.AdminId).HasColumnName("adminId");
            entity.Property(e => e.KullaniciId).HasColumnName("kullaniciId");
            entity.Property(e => e.Mesaj)
                .HasMaxLength(500)
                .HasColumnName("mesaj");
            entity.Property(e => e.MesajBaslik)
                .HasMaxLength(20)
                .HasColumnName("mesajBaslik");
            entity.Property(e => e.MesajlasmaId).HasColumnName("mesajlasmaId");
            entity.Property(e => e.OkunduBilgisi).HasColumnName("okunduBilgisi");
            entity.Property(e => e.Tarih)
                .HasColumnType("datetime")
                .HasColumnName("tarih");

            entity.HasOne(d => d.Admin).WithMany(p => p.AdmindenKullaniciyaMesajs)
                .HasForeignKey(d => d.AdminId)
                .HasConstraintName("FK__AdmindenK__admin__4BAC3F29");

            entity.HasOne(d => d.Kullanici).WithMany(p => p.AdmindenKullaniciyaMesajs)
                .HasForeignKey(d => d.KullaniciId)
                .HasConstraintName("FK__AdmindenK__kulla__4CA06362");

            entity.HasOne(d => d.Mesajlasma).WithMany(p => p.AdmindenKullaniciyaMesajs)
                .HasForeignKey(d => d.MesajlasmaId)
                .HasConstraintName("FK__AdmindenK__mesaj__4AB81AF0");
        });

        modelBuilder.Entity<AdmindenTeknikDestegeMesaj>(entity =>
        {
            entity.HasKey(e => e.MesajId).HasName("PK__Adminden__FFB37EE4B09F53B6");

            entity.ToTable("AdmindenTeknikDestegeMesaj");

            entity.Property(e => e.MesajId).HasColumnName("mesajId");
            entity.Property(e => e.AdminId).HasColumnName("adminId");
            entity.Property(e => e.ElemanId).HasColumnName("elemanId");
            entity.Property(e => e.Mesaj)
                .HasMaxLength(500)
                .HasColumnName("mesaj");
            entity.Property(e => e.MesajBaslik)
                .HasMaxLength(20)
                .HasColumnName("mesajBaslik");
            entity.Property(e => e.MesajlasmaId).HasColumnName("mesajlasmaId");
            entity.Property(e => e.OkunduBilgisi).HasColumnName("okunduBilgisi");
            entity.Property(e => e.Tarih)
                .HasColumnType("datetime")
                .HasColumnName("tarih");

            entity.HasOne(d => d.Admin).WithMany(p => p.AdmindenTeknikDestegeMesajs)
                .HasForeignKey(d => d.AdminId)
                .HasConstraintName("FK__AdmindenT__admin__5070F446");

            entity.HasOne(d => d.Eleman).WithMany(p => p.AdmindenTeknikDestegeMesajs)
                .HasForeignKey(d => d.ElemanId)
                .HasConstraintName("FK__AdmindenT__elema__4F7CD00D");

            entity.HasOne(d => d.Mesajlasma).WithMany(p => p.AdmindenTeknikDestegeMesajs)
                .HasForeignKey(d => d.MesajlasmaId)
                .HasConstraintName("FK__AdmindenT__mesaj__5165187F");
        });

        modelBuilder.Entity<ArananKelimeler>(entity =>
        {
            entity.HasKey(e => e.AramaId).HasName("PK__ArananKe__CAB4D12098AC7ABA");

            entity.ToTable("ArananKelimeler");

            entity.Property(e => e.AramaId).HasColumnName("aramaId");
            entity.Property(e => e.Aktiflik).HasColumnName("aktiflik");
            entity.Property(e => e.Kelime)
                .HasMaxLength(200)
                .HasColumnName("kelime");
            entity.Property(e => e.Tarih)
                .HasColumnType("datetime")
                .HasColumnName("tarih");
        });

        modelBuilder.Entity<Cekili>(entity =>
        {
            entity.HasKey(e => e.CekilisId).HasName("PK__Cekilis__292DE5CF29494404");

            entity.Property(e => e.CekilisId).HasColumnName("cekilisId");
            entity.Property(e => e.Aktiflik).HasColumnName("aktiflik");
            entity.Property(e => e.BaslangicTarih)
                .HasColumnType("datetime")
                .HasColumnName("baslangicTarih");
            entity.Property(e => e.BitisTarih)
                .HasColumnType("datetime")
                .HasColumnName("bitisTarih");
            entity.Property(e => e.CekilisAciklama)
                .HasMaxLength(2000)
                .HasColumnName("cekilisAciklama");
            entity.Property(e => e.CekilisAd)
                .HasMaxLength(50)
                .HasColumnName("cekilisAd");
        });

        modelBuilder.Entity<CekilisKazananlar>(entity =>
        {
            entity.HasKey(e => e.KazanmaId).HasName("PK__CekilisK__5F4DA5D552C135E4");

            entity.ToTable("CekilisKazananlar");

            entity.Property(e => e.KazanmaId).HasColumnName("kazanmaId");
            entity.Property(e => e.CekilisId).HasColumnName("cekilisId");
            entity.Property(e => e.KazanmaTarihi)
                .HasColumnType("datetime")
                .HasColumnName("kazanmaTarihi");
            entity.Property(e => e.KullaniciId).HasColumnName("kullaniciId");

            entity.HasOne(d => d.Cekilis).WithMany(p => p.CekilisKazananlars)
                .HasForeignKey(d => d.CekilisId)
                .HasConstraintName("FK__CekilisKa__cekil__15DA3E5D");

            entity.HasOne(d => d.Kullanici).WithMany(p => p.CekilisKazananlars)
                .HasForeignKey(d => d.KullaniciId)
                .HasConstraintName("FK__CekilisKa__kulla__14E61A24");
        });

        modelBuilder.Entity<CekiliseKatılanlar>(entity =>
        {
            entity.HasKey(e => e.KatilimId).HasName("PK__Cekilise__B2983A6018919767");

            entity.ToTable("CekiliseKatılanlar");

            entity.Property(e => e.KatilimId).HasColumnName("katilimId");
            entity.Property(e => e.CekilisId).HasColumnName("cekilisId");
            entity.Property(e => e.KatilimTarihi)
                .HasColumnType("datetime")
                .HasColumnName("katilimTarihi");
            entity.Property(e => e.KullaniciId).HasColumnName("kullaniciId");

            entity.HasOne(d => d.Cekilis).WithMany(p => p.CekiliseKatılanlars)
                .HasForeignKey(d => d.CekilisId)
                .HasConstraintName("FK__CekiliseK__cekil__11158940");

            entity.HasOne(d => d.Kullanici).WithMany(p => p.CekiliseKatılanlars)
                .HasForeignKey(d => d.KullaniciId)
                .HasConstraintName("FK__CekiliseK__kulla__1209AD79");
        });

        modelBuilder.Entity<EnCokArananKategori>(entity =>
        {
            entity.HasKey(e => e.EnCokAranmaId).HasName("PK__EnCokAra__667C649455DB7B81");

            entity.ToTable("EnCokArananKategori");

            entity.Property(e => e.EnCokAranmaId).HasColumnName("enCokAranmaId");
            entity.Property(e => e.Aktiflik).HasColumnName("aktiflik");
            entity.Property(e => e.AranmaSayisi).HasColumnName("aranmaSayisi");
            entity.Property(e => e.KategoriAd)
                .HasMaxLength(100)
                .HasColumnName("kategoriAd");
            entity.Property(e => e.KategoriId).HasColumnName("kategoriId");

            entity.HasOne(d => d.Kategori).WithMany(p => p.EnCokArananKategoris)
                .HasForeignKey(d => d.KategoriId)
                .HasConstraintName("FK__EnCokAran__kateg__4B0D20AB");
        });

        modelBuilder.Entity<EnCokArananKelimeler>(entity =>
        {
            entity.HasKey(e => e.EncokArananKelimeId).HasName("PK__EnCokAra__919A632152F0B2F3");

            entity.ToTable("EnCokArananKelimeler");

            entity.Property(e => e.EncokArananKelimeId).HasColumnName("encokArananKelimeId");
            entity.Property(e => e.Aktiflik).HasColumnName("aktiflik");
            entity.Property(e => e.AramaId).HasColumnName("aramaId");
            entity.Property(e => e.AranmaSayisi).HasColumnName("aranmaSayisi");
            entity.Property(e => e.Kelime)
                .HasMaxLength(200)
                .HasColumnName("kelime");

            entity.HasOne(d => d.Arama).WithMany(p => p.EnCokArananKelimelers)
                .HasForeignKey(d => d.AramaId)
                .HasConstraintName("FK__EnCokAran__arama__45544755");
        });

        modelBuilder.Entity<EnCokArananUrun>(entity =>
        {
            entity.HasKey(e => e.EnCokArananUrunId).HasName("PK__EnCokAra__FFAEA3F60B7AC54D");

            entity.ToTable("EnCokArananUrun");

            entity.Property(e => e.EnCokArananUrunId).HasColumnName("enCokArananUrunId");
            entity.Property(e => e.Aktiflik).HasColumnName("aktiflik");
            entity.Property(e => e.AranmaSayisi).HasColumnName("aranmaSayisi");
            entity.Property(e => e.UrunAd)
                .HasMaxLength(100)
                .HasColumnName("urunAd");
            entity.Property(e => e.UrunId).HasColumnName("urunId");

            entity.HasOne(d => d.Urun).WithMany(p => p.EnCokArananUruns)
                .HasForeignKey(d => d.UrunId)
                .HasConstraintName("FK__EnCokAran__urunI__4830B400");
        });

        modelBuilder.Entity<FavoriCikarma>(entity =>
        {
            entity.HasKey(e => e.CikarmaId).HasName("PK__FavoriCi__D774D75ADD70D466");

            entity.ToTable("FavoriCikarma");

            entity.Property(e => e.CikarmaId).HasColumnName("cikarmaId");
            entity.Property(e => e.FavoriId).HasColumnName("favoriId");
            entity.Property(e => e.Tarih)
                .HasColumnType("datetime")
                .HasColumnName("tarih");

            entity.HasOne(d => d.Favori).WithMany(p => p.FavoriCikarmas)
                .HasForeignKey(d => d.FavoriId)
                .HasConstraintName("FK__FavoriCik__favor__5772F790");
        });

        modelBuilder.Entity<FavoriEklenme>(entity =>
        {
            entity.HasKey(e => e.EklenmeId).HasName("PK__FavoriEk__9F681FCE612ED236");

            entity.ToTable("FavoriEklenme");

            entity.Property(e => e.EklenmeId).HasColumnName("eklenmeId");
            entity.Property(e => e.FavoriId).HasColumnName("favoriId");
            entity.Property(e => e.Tarih)
                .HasColumnType("datetime")
                .HasColumnName("tarih");

            entity.HasOne(d => d.Favori).WithMany(p => p.FavoriEklenmes)
                .HasForeignKey(d => d.FavoriId)
                .HasConstraintName("FK__FavoriEkl__favor__54968AE5");
        });

        modelBuilder.Entity<Favoriler>(entity =>
        {
            entity.HasKey(e => e.FavoriId).HasName("PK__Favorile__F8885B6AA79666EA");

            entity.ToTable("Favoriler");

            entity.Property(e => e.FavoriId).HasColumnName("favoriId");
            entity.Property(e => e.Aktiflik).HasColumnName("aktiflik");
            entity.Property(e => e.KullaniciId).HasColumnName("kullaniciId");
            entity.Property(e => e.UrunId).HasColumnName("urunId");

            entity.HasOne(d => d.Kullanici).WithMany(p => p.Favorilers)
                .HasForeignKey(d => d.KullaniciId)
                .HasConstraintName("FK__Favoriler__kulla__51BA1E3A");

            entity.HasOne(d => d.Urun).WithMany(p => p.Favorilers)
                .HasForeignKey(d => d.UrunId)
                .HasConstraintName("FK__Favoriler__urunI__50C5FA01");
        });

        modelBuilder.Entity<Firma>(entity =>
        {
            entity.HasKey(e => e.FirmaId).HasName("PK__Firma__1455FFC23886D0EF");

            entity.ToTable("Firma");

            entity.Property(e => e.FirmaId).HasColumnName("firmaId");
            entity.Property(e => e.Aktiflik).HasColumnName("aktiflik");
            entity.Property(e => e.CoinMiktari).HasColumnName("coinMiktari");
            entity.Property(e => e.FirmaAd)
                .HasMaxLength(200)
                .HasColumnName("firmaAd");
            entity.Property(e => e.FirmaAdres)
                .HasMaxLength(500)
                .HasColumnName("firmaAdres");
            entity.Property(e => e.Mail)
                .HasMaxLength(50)
                .HasColumnName("mail");
            entity.Property(e => e.MailSifre)
                .HasMaxLength(50)
                .HasColumnName("mailSifre");
            entity.Property(e => e.Puan).HasColumnName("puan");
            entity.Property(e => e.SatisSayisi).HasColumnName("satisSayisi");
            entity.Property(e => e.Sifre)
                .HasMaxLength(20)
                .HasColumnName("sifre");
            entity.Property(e => e.SosyalSorumlulukKatılımSayisi).HasColumnName("sosyalSorumlulukKatılımSayisi");
            entity.Property(e => e.TelefonNumarasi)
                .HasMaxLength(20)
                .HasColumnName("telefonNumarasi");
        });

        modelBuilder.Entity<FirmaBasvuru>(entity =>
        {
            entity.HasKey(e => e.BasvuruId).HasName("PK__FirmaBas__197B744932CAC551");

            entity.ToTable("FirmaBasvuru");

            entity.Property(e => e.BasvuruId).HasColumnName("basvuruId");
            entity.Property(e => e.Aktiflik).HasColumnName("aktiflik");
            entity.Property(e => e.BasvuruTarih)
                .HasColumnType("datetime")
                .HasColumnName("basvuruTarih");
            entity.Property(e => e.FirmaAciklama)
                .HasMaxLength(1000)
                .HasColumnName("firmaAciklama");
            entity.Property(e => e.FirmaAd)
                .HasMaxLength(200)
                .HasColumnName("firmaAd");
            entity.Property(e => e.FirmaAdres)
                .HasMaxLength(500)
                .HasColumnName("firmaAdres");
            entity.Property(e => e.FirmaSektor)
                .HasMaxLength(100)
                .HasColumnName("firmaSektor");
            entity.Property(e => e.FirmaTel)
                .HasMaxLength(20)
                .HasColumnName("firmaTel");
            entity.Property(e => e.KurulusTarihi)
                .HasColumnType("datetime")
                .HasColumnName("kurulusTarihi");
            entity.Property(e => e.Mail)
                .HasMaxLength(100)
                .HasColumnName("mail");
        });

        modelBuilder.Entity<FirmaCikislar>(entity =>
        {
            entity.HasKey(e => e.FirmaCikisId).HasName("PK__FirmaCik__93D27D293C32273B");

            entity.ToTable("FirmaCikislar");

            entity.Property(e => e.FirmaCikisId).HasColumnName("firmaCikisId");
            entity.Property(e => e.BasariDurumu).HasColumnName("basariDurumu");
            entity.Property(e => e.FirmaGirisId).HasColumnName("firmaGirisId");
            entity.Property(e => e.FirmaId).HasColumnName("firmaId");
            entity.Property(e => e.Tarih)
                .HasColumnType("datetime")
                .HasColumnName("tarih");

            entity.HasOne(d => d.FirmaGiris).WithMany(p => p.FirmaCikislars)
                .HasForeignKey(d => d.FirmaGirisId)
                .HasConstraintName("FK__FirmaCiki__firma__59904A2C");

            entity.HasOne(d => d.Firma).WithMany(p => p.FirmaCikislars)
                .HasForeignKey(d => d.FirmaId)
                .HasConstraintName("FK__FirmaCiki__firma__589C25F3");
        });

        modelBuilder.Entity<FirmaGirisler>(entity =>
        {
            entity.HasKey(e => e.GirisId).HasName("PK__FirmaGir__F8F62BEF33854469");

            entity.ToTable("FirmaGirisler");

            entity.Property(e => e.GirisId).HasColumnName("girisId");
            entity.Property(e => e.Basari).HasColumnName("basari");
            entity.Property(e => e.FirmaId).HasColumnName("firmaId");
            entity.Property(e => e.Tarih)
                .HasColumnType("datetime")
                .HasColumnName("tarih");

            entity.HasOne(d => d.Firma).WithMany(p => p.FirmaGirislers)
                .HasForeignKey(d => d.FirmaId)
                .HasConstraintName("FK__FirmaGiri__firma__3493CFA7");
        });

        modelBuilder.Entity<FirmaIban>(entity =>
        {
            entity.HasKey(e => e.FirmaIbanId).HasName("PK__FirmaIba__3AC4E4165EEAB9BF");

            entity.ToTable("FirmaIban");

            entity.Property(e => e.FirmaIbanId).HasColumnName("firmaIbanId");
            entity.Property(e => e.Aktiflik).HasColumnName("aktiflik");
            entity.Property(e => e.AliciIsim)
                .HasMaxLength(100)
                .HasColumnName("aliciIsim");
            entity.Property(e => e.EklenmeTarihi)
                .HasColumnType("datetime")
                .HasColumnName("eklenmeTarihi");
            entity.Property(e => e.FirmaId).HasColumnName("firmaId");
            entity.Property(e => e.Iban)
                .HasMaxLength(20)
                .HasColumnName("iban");

            entity.HasOne(d => d.Firma).WithMany(p => p.FirmaIbans)
                .HasForeignKey(d => d.FirmaId)
                .HasConstraintName("FK__FirmaIban__firma__7F2BE32F");
        });

        modelBuilder.Entity<FirmaKampanyalar>(entity =>
        {
            entity.HasKey(e => e.KampanyaId).HasName("PK__FirmaKam__CE61BFDC6E933055");

            entity.ToTable("FirmaKampanyalar");

            entity.Property(e => e.KampanyaId).HasColumnName("kampanyaId");
            entity.Property(e => e.Aktiflik).HasColumnName("aktiflik");
            entity.Property(e => e.BaslangicTarihi)
                .HasColumnType("datetime")
                .HasColumnName("baslangicTarihi");
            entity.Property(e => e.BitisTarihi)
                .HasColumnType("datetime")
                .HasColumnName("bitisTarihi");
            entity.Property(e => e.FirmaId).HasColumnName("firmaId");
            entity.Property(e => e.IndirimMiktari).HasColumnName("indirimMiktari");
            entity.Property(e => e.KampanyaAciklama)
                .HasMaxLength(2000)
                .HasColumnName("kampanyaAciklama");
            entity.Property(e => e.KampanyaBaslik)
                .HasMaxLength(100)
                .HasColumnName("kampanyaBaslik");

            entity.HasOne(d => d.Firma).WithMany(p => p.FirmaKampanyalars)
                .HasForeignKey(d => d.FirmaId)
                .HasConstraintName("FK__FirmaKamp__firma__22751F6C");
        });

        modelBuilder.Entity<FirmaPuanlama>(entity =>
        {
            entity.HasKey(e => e.FirmaPuanlamaId).HasName("PK__FirmaPua__069CA3CA4899698D");

            entity.ToTable("FirmaPuanlama");

            entity.Property(e => e.FirmaPuanlamaId).HasColumnName("firmaPuanlamaId");
            entity.Property(e => e.Aktiflik).HasColumnName("aktiflik");
            entity.Property(e => e.FirmaId).HasColumnName("firmaId");
            entity.Property(e => e.KullaniciId).HasColumnName("kullaniciId");
            entity.Property(e => e.Puan).HasColumnName("puan");
            entity.Property(e => e.Tarih)
                .HasColumnType("datetime")
                .HasColumnName("tarih");

            entity.HasOne(d => d.Firma).WithMany(p => p.FirmaPuanlamas)
                .HasForeignKey(d => d.FirmaId)
                .HasConstraintName("FK__FirmaPuan__firma__7AF13DF7");

            entity.HasOne(d => d.Kullanici).WithMany(p => p.FirmaPuanlamas)
                .HasForeignKey(d => d.KullaniciId)
                .HasConstraintName("FK__FirmaPuan__kulla__79FD19BE");
        });

        modelBuilder.Entity<FirmaSosyalMedyalar>(entity =>
        {
            entity.HasKey(e => e.FirmaSosyalMedyaId).HasName("PK__FirmaSos__9AE4BF0CA695DC89");

            entity.ToTable("FirmaSosyalMedyalar");

            entity.Property(e => e.FirmaSosyalMedyaId).HasColumnName("firmaSosyalMedyaId");
            entity.Property(e => e.Aktiflik).HasColumnName("aktiflik");
            entity.Property(e => e.EklenmeTarihi)
                .HasColumnType("datetime")
                .HasColumnName("eklenmeTarihi");
            entity.Property(e => e.FirmaId).HasColumnName("firmaId");
            entity.Property(e => e.SosyalMedyaIsmi)
                .HasMaxLength(50)
                .HasColumnName("sosyalMedyaIsmi");
            entity.Property(e => e.UrlAdresi)
                .HasMaxLength(500)
                .HasColumnName("urlAdresi");

            entity.HasOne(d => d.Firma).WithMany(p => p.FirmaSosyalMedyalars)
                .HasForeignKey(d => d.FirmaId)
                .HasConstraintName("FK__FirmaSosy__firma__4DE98D56");
        });

        modelBuilder.Entity<FirmaYarismaKazanlar>(entity =>
        {
            entity.HasKey(e => e.KazanmaId).HasName("PK__FirmaYar__5F4DA5D5A272F282");

            entity.ToTable("FirmaYarismaKazanlar");

            entity.Property(e => e.KazanmaId).HasColumnName("kazanmaId");
            entity.Property(e => e.Aktiflik).HasColumnName("aktiflik");
            entity.Property(e => e.FirmaId).HasColumnName("firmaId");
            entity.Property(e => e.FirmayarismaId).HasColumnName("firmayarismaId");
            entity.Property(e => e.KazanmaTarih)
                .HasColumnType("datetime")
                .HasColumnName("kazanmaTarih");

            entity.HasOne(d => d.Firma).WithMany(p => p.FirmaYarismaKazanlars)
                .HasForeignKey(d => d.FirmaId)
                .HasConstraintName("FK__FirmaYari__firma__1E6F845E");

            entity.HasOne(d => d.Firmayarisma).WithMany(p => p.FirmaYarismaKazanlars)
                .HasForeignKey(d => d.FirmayarismaId)
                .HasConstraintName("FK__FirmaYari__firma__1F63A897");
        });

        modelBuilder.Entity<FirmaYarismalar>(entity =>
        {
            entity.HasKey(e => e.FirmayarismaId).HasName("PK__FirmaYar__5657A36B06F78EBB");

            entity.ToTable("FirmaYarismalar");

            entity.Property(e => e.FirmayarismaId).HasColumnName("firmayarismaId");
            entity.Property(e => e.Aktiflik).HasColumnName("aktiflik");
            entity.Property(e => e.BaslangicTarih)
                .HasColumnType("datetime")
                .HasColumnName("baslangicTarih");
            entity.Property(e => e.BitisTarih)
                .HasColumnType("datetime")
                .HasColumnName("bitisTarih");
            entity.Property(e => e.YarismaAciklama)
                .HasMaxLength(3000)
                .HasColumnName("yarismaAciklama");
            entity.Property(e => e.YarismaBaslik)
                .HasMaxLength(30)
                .HasColumnName("yarismaBaslik");
        });

        modelBuilder.Entity<FirmaYarismasiKatilanlar>(entity =>
        {
            entity.HasKey(e => e.KatilimId).HasName("PK__FirmaYar__B2983A60214C5B47");

            entity.ToTable("FirmaYarismasiKatilanlar");

            entity.Property(e => e.KatilimId).HasColumnName("katilimId");
            entity.Property(e => e.Aktiflik).HasColumnName("aktiflik");
            entity.Property(e => e.FirmaId).HasColumnName("firmaId");
            entity.Property(e => e.FirmayarismaId).HasColumnName("firmayarismaId");
            entity.Property(e => e.KatilmaTarih)
                .HasColumnType("datetime")
                .HasColumnName("katilmaTarih");

            entity.HasOne(d => d.Firma).WithMany(p => p.FirmaYarismasiKatilanlars)
                .HasForeignKey(d => d.FirmaId)
                .HasConstraintName("FK__FirmaYari__firma__1A9EF37A");

            entity.HasOne(d => d.Firmayarisma).WithMany(p => p.FirmaYarismasiKatilanlars)
                .HasForeignKey(d => d.FirmayarismaId)
                .HasConstraintName("FK__FirmaYari__firma__1B9317B3");
        });

        modelBuilder.Entity<FirmaYorumCevap>(entity =>
        {
            entity.HasKey(e => e.CevapId).HasName("PK__FirmaYor__63A47692E10BDF5E");

            entity.ToTable("FirmaYorumCevap");

            entity.Property(e => e.CevapId).HasColumnName("cevapId");
            entity.Property(e => e.Aktiflik).HasColumnName("aktiflik");
            entity.Property(e => e.Cevap)
                .HasMaxLength(200)
                .HasColumnName("cevap");
            entity.Property(e => e.FirmaId).HasColumnName("firmaId");
            entity.Property(e => e.Tarih)
                .HasColumnType("datetime")
                .HasColumnName("tarih");
            entity.Property(e => e.YorumId).HasColumnName("yorumId");

            entity.HasOne(d => d.Firma).WithMany(p => p.FirmaYorumCevaps)
                .HasForeignKey(d => d.FirmaId)
                .HasConstraintName("FK__FirmaYoru__firma__30C33EC3");

            entity.HasOne(d => d.Yorum).WithMany(p => p.FirmaYorumCevaps)
                .HasForeignKey(d => d.YorumId)
                .HasConstraintName("FK__FirmaYoru__yorum__2FCF1A8A");
        });

        modelBuilder.Entity<FirmadanKullaniciyaMesaj>(entity =>
        {
            entity.HasKey(e => e.MesajId).HasName("PK__Firmadan__FFB37EE47B5AA920");

            entity.ToTable("FirmadanKullaniciyaMesaj");

            entity.Property(e => e.MesajId).HasColumnName("mesajId");
            entity.Property(e => e.Aktiflik).HasColumnName("aktiflik");
            entity.Property(e => e.FirmaId).HasColumnName("firmaId");
            entity.Property(e => e.KullaniciId).HasColumnName("kullaniciId");
            entity.Property(e => e.Mesaj)
                .HasMaxLength(500)
                .HasColumnName("mesaj");
            entity.Property(e => e.MesajBaslik)
                .HasMaxLength(20)
                .HasColumnName("mesajBaslik");
            entity.Property(e => e.MesajlasmaId).HasColumnName("mesajlasmaId");
            entity.Property(e => e.OkunduBilgisi).HasColumnName("okunduBilgisi");
            entity.Property(e => e.Tarih)
                .HasColumnType("datetime")
                .HasColumnName("tarih");

            entity.HasOne(d => d.Firma).WithMany(p => p.FirmadanKullaniciyaMesajs)
                .HasForeignKey(d => d.FirmaId)
                .HasConstraintName("FK__FirmadanK__firma__3D2915A8");

            entity.HasOne(d => d.Kullanici).WithMany(p => p.FirmadanKullaniciyaMesajs)
                .HasForeignKey(d => d.KullaniciId)
                .HasConstraintName("FK__FirmadanK__kulla__3E1D39E1");

            entity.HasOne(d => d.Mesajlasma).WithMany(p => p.FirmadanKullaniciyaMesajs)
                .HasForeignKey(d => d.MesajlasmaId)
                .HasConstraintName("FK__FirmadanK__mesaj__3C34F16F");
        });

        modelBuilder.Entity<FirmadanKullaniciyaSikayet>(entity =>
        {
            entity.HasKey(e => e.SikayetId).HasName("PK__Firmadan__BBDC1CC65DEED9D0");

            entity.ToTable("FirmadanKullaniciyaSikayet");

            entity.Property(e => e.SikayetId).HasColumnName("sikayetId");
            entity.Property(e => e.Aktiflik).HasColumnName("aktiflik");
            entity.Property(e => e.FirmaId).HasColumnName("firmaId");
            entity.Property(e => e.KullaniciId).HasColumnName("kullaniciId");
            entity.Property(e => e.SikayetBaslik)
                .HasMaxLength(20)
                .HasColumnName("sikayetBaslik");
            entity.Property(e => e.SikayetMetni)
                .HasMaxLength(500)
                .HasColumnName("sikayetMetni");
            entity.Property(e => e.Tarih)
                .HasColumnType("datetime")
                .HasColumnName("tarih");

            entity.HasOne(d => d.Firma).WithMany(p => p.FirmadanKullaniciyaSikayets)
                .HasForeignKey(d => d.FirmaId)
                .HasConstraintName("FK__FirmadanK__firma__489AC854");

            entity.HasOne(d => d.Kullanici).WithMany(p => p.FirmadanKullaniciyaSikayets)
                .HasForeignKey(d => d.KullaniciId)
                .HasConstraintName("FK__FirmadanK__kulla__498EEC8D");
        });

        modelBuilder.Entity<FirmadanKullaniciyaYorumCevapSikayet>(entity =>
        {
            entity.HasKey(e => e.FirmaYorumCevapSikayetId).HasName("PK__Firmadan__7B199D19A9428EDB");

            entity.ToTable("FirmadanKullaniciyaYorumCevapSikayet");

            entity.Property(e => e.Aktiflik).HasColumnName("aktiflik");
            entity.Property(e => e.FirmaId).HasColumnName("firmaId");
            entity.Property(e => e.KullaniciId).HasColumnName("kullaniciId");
            entity.Property(e => e.SikayetBaslik)
                .HasMaxLength(20)
                .HasColumnName("sikayetBaslik");
            entity.Property(e => e.SikayetMetni)
                .HasMaxLength(500)
                .HasColumnName("sikayetMetni");
            entity.Property(e => e.Tarih)
                .HasColumnType("datetime")
                .HasColumnName("tarih");
            entity.Property(e => e.YorumCevapId).HasColumnName("yorumCevapId");

            entity.HasOne(d => d.Firma).WithMany(p => p.FirmadanKullaniciyaYorumCevapSikayets)
                .HasForeignKey(d => d.FirmaId)
                .HasConstraintName("FK__FirmadanK__firma__6FB49575");

            entity.HasOne(d => d.Kullanici).WithMany(p => p.FirmadanKullaniciyaYorumCevapSikayets)
                .HasForeignKey(d => d.KullaniciId)
                .HasConstraintName("FK__FirmadanK__kulla__6EC0713C");

            entity.HasOne(d => d.YorumCevap).WithMany(p => p.FirmadanKullaniciyaYorumCevapSikayets)
                .HasForeignKey(d => d.YorumCevapId)
                .HasConstraintName("FK__FirmadanK__yorum__6DCC4D03");
        });

        modelBuilder.Entity<FirmadanSiteOneriler>(entity =>
        {
            entity.HasKey(e => e.OneriId).HasName("PK__Firmadan__B97B4C5D19C00FA1");

            entity.ToTable("FirmadanSiteOneriler");

            entity.Property(e => e.OneriId).HasColumnName("oneriId");
            entity.Property(e => e.Aktiflik).HasColumnName("aktiflik");
            entity.Property(e => e.FirmaId).HasColumnName("firmaId");
            entity.Property(e => e.OneriBaslik)
                .HasMaxLength(20)
                .HasColumnName("oneriBaslik");
            entity.Property(e => e.OneriMetin)
                .HasMaxLength(500)
                .HasColumnName("oneriMetin");
            entity.Property(e => e.Tarih)
                .HasColumnType("datetime")
                .HasColumnName("tarih");

            entity.HasOne(d => d.Firma).WithMany(p => p.FirmadanSiteOnerilers)
                .HasForeignKey(d => d.FirmaId)
                .HasConstraintName("FK__FirmadanS__firma__76619304");
        });

        modelBuilder.Entity<FirmadanTeknikElemanaMesaj>(entity =>
        {
            entity.HasKey(e => e.MesajId).HasName("PK__Firmadan__FFB37EE4AC78D73A");

            entity.ToTable("FirmadanTeknikElemanaMesaj");

            entity.Property(e => e.MesajId).HasColumnName("mesajId");
            entity.Property(e => e.Aktiflik).HasColumnName("aktiflik");
            entity.Property(e => e.FirmaId).HasColumnName("firmaId");
            entity.Property(e => e.Mesaj)
                .HasMaxLength(300)
                .HasColumnName("mesaj");
            entity.Property(e => e.MesajBaslik)
                .HasMaxLength(20)
                .HasColumnName("mesajBaslik");
            entity.Property(e => e.MesajlasmaId).HasColumnName("mesajlasmaId");
            entity.Property(e => e.OkunduBilgisi).HasColumnName("okunduBilgisi");
            entity.Property(e => e.Tarih)
                .HasColumnType("datetime")
                .HasColumnName("tarih");
            entity.Property(e => e.TeknikElemanId).HasColumnName("teknikElemanId");

            entity.HasOne(d => d.Firma).WithMany(p => p.FirmadanTeknikElemanaMesajs)
                .HasForeignKey(d => d.FirmaId)
                .HasConstraintName("FK__FirmadanT__firma__3864608B");

            entity.HasOne(d => d.Mesajlasma).WithMany(p => p.FirmadanTeknikElemanaMesajs)
                .HasForeignKey(d => d.MesajlasmaId)
                .HasConstraintName("FK__FirmadanT__mesaj__37703C52");

            entity.HasOne(d => d.TeknikEleman).WithMany(p => p.FirmadanTeknikElemanaMesajs)
                .HasForeignKey(d => d.TeknikElemanId)
                .HasConstraintName("FK__FirmadanT__tekni__395884C4");
        });

        modelBuilder.Entity<FirmadanTeknikElemanaSikayet>(entity =>
        {
            entity.HasKey(e => e.SikayetId).HasName("PK__Firmadan__BBDC1CC6E161F8EF");

            entity.ToTable("FirmadanTeknikElemanaSikayet");

            entity.Property(e => e.SikayetId).HasColumnName("sikayetId");
            entity.Property(e => e.Aktiflik).HasColumnName("aktiflik");
            entity.Property(e => e.FirmaId).HasColumnName("firmaId");
            entity.Property(e => e.SikayetBaslik)
                .HasMaxLength(20)
                .HasColumnName("sikayetBaslik");
            entity.Property(e => e.SikayetMetni)
                .HasMaxLength(500)
                .HasColumnName("sikayetMetni");
            entity.Property(e => e.Tarih)
                .HasColumnType("datetime")
                .HasColumnName("tarih");
            entity.Property(e => e.TeknikElemanId).HasColumnName("teknikElemanId");

            entity.HasOne(d => d.Firma).WithMany(p => p.FirmadanTeknikElemanaSikayets)
                .HasForeignKey(d => d.FirmaId)
                .HasConstraintName("FK__FirmadanT__firma__4C6B5938");

            entity.HasOne(d => d.TeknikEleman).WithMany(p => p.FirmadanTeknikElemanaSikayets)
                .HasForeignKey(d => d.TeknikElemanId)
                .HasConstraintName("FK__FirmadanT__tekni__4D5F7D71");
        });

        modelBuilder.Entity<FirmadanYorumSikayet>(entity =>
        {
            entity.HasKey(e => e.YorumSikayetId).HasName("PK__Firmadan__DAB3D68F037223DA");

            entity.ToTable("FirmadanYorumSikayet");

            entity.Property(e => e.YorumSikayetId).HasColumnName("yorumSikayetId");
            entity.Property(e => e.Aktiflik).HasColumnName("aktiflik");
            entity.Property(e => e.FirmaId).HasColumnName("firmaId");
            entity.Property(e => e.KullaniciId).HasColumnName("kullaniciId");
            entity.Property(e => e.SikayetBaslik)
                .HasMaxLength(20)
                .HasColumnName("sikayetBaslik");
            entity.Property(e => e.SikayetMetni)
                .HasMaxLength(500)
                .HasColumnName("sikayetMetni");
            entity.Property(e => e.Tarih)
                .HasColumnType("datetime")
                .HasColumnName("tarih");
            entity.Property(e => e.YorumId).HasColumnName("yorumId");

            entity.HasOne(d => d.Firma).WithMany(p => p.FirmadanYorumSikayets)
                .HasForeignKey(d => d.FirmaId)
                .HasConstraintName("FK__FirmadanY__firma__58D1301D");

            entity.HasOne(d => d.Kullanici).WithMany(p => p.FirmadanYorumSikayets)
                .HasForeignKey(d => d.KullaniciId)
                .HasConstraintName("FK__FirmadanY__kulla__59C55456");

            entity.HasOne(d => d.Yorum).WithMany(p => p.FirmadanYorumSikayets)
                .HasForeignKey(d => d.YorumId)
                .HasConstraintName("FK__FirmadanY__yorum__57DD0BE4");
        });

        modelBuilder.Entity<GenelKampanyalar>(entity =>
        {
            entity.HasKey(e => e.KampanyaId).HasName("PK__GenelKam__CE61BFDCDCDD0960");

            entity.ToTable("GenelKampanyalar");

            entity.Property(e => e.KampanyaId).HasColumnName("kampanyaId");
            entity.Property(e => e.Aktiflik).HasColumnName("aktiflik");
            entity.Property(e => e.BaslangicTarihi)
                .HasColumnType("datetime")
                .HasColumnName("baslangicTarihi");
            entity.Property(e => e.BitisTarihi)
                .HasColumnType("datetime")
                .HasColumnName("bitisTarihi");
            entity.Property(e => e.IndirimMiktari).HasColumnName("indirimMiktari");
            entity.Property(e => e.KampanyaAciklama)
                .HasMaxLength(2000)
                .HasColumnName("kampanyaAciklama");
            entity.Property(e => e.KampanyaBaslik)
                .HasMaxLength(100)
                .HasColumnName("kampanyaBaslik");
        });

        modelBuilder.Entity<GonderilenKargolar>(entity =>
        {
            entity.HasKey(e => e.GonderilenKargoId).HasName("PK__Gonderil__85345393AB6DD57B");

            entity.ToTable("GonderilenKargolar");

            entity.Property(e => e.GonderilenKargoId).HasColumnName("gonderilenKargoId");
            entity.Property(e => e.AliciId).HasColumnName("aliciId");
            entity.Property(e => e.FirmaId).HasColumnName("firmaId");
            entity.Property(e => e.GidisAdresiId).HasColumnName("gidisAdresiId");
            entity.Property(e => e.GonderimTarihi)
                .HasColumnType("datetime")
                .HasColumnName("gonderimTarihi");
            entity.Property(e => e.IadeTalebi).HasColumnName("iadeTalebi");
            entity.Property(e => e.IstenenKargoId).HasColumnName("istenenKargoId");
            entity.Property(e => e.KargoFirmaId).HasColumnName("kargoFirmaId");
            entity.Property(e => e.KargoFirmaSubeId).HasColumnName("kargoFirmaSubeId");
            entity.Property(e => e.TahminiTeslimTarihi)
                .HasColumnType("datetime")
                .HasColumnName("tahminiTeslimTarihi");
            entity.Property(e => e.Tarih)
                .HasColumnType("datetime")
                .HasColumnName("tarih");

            entity.HasOne(d => d.Alici).WithMany(p => p.GonderilenKargolars)
                .HasForeignKey(d => d.AliciId)
                .HasConstraintName("FK__Gonderile__alici__11D4A34F");

            entity.HasOne(d => d.Firma).WithMany(p => p.GonderilenKargolars)
                .HasForeignKey(d => d.FirmaId)
                .HasConstraintName("FK__Gonderile__firma__0FEC5ADD");

            entity.HasOne(d => d.GidisAdresi).WithMany(p => p.GonderilenKargolars)
                .HasForeignKey(d => d.GidisAdresiId)
                .HasConstraintName("FK__Gonderile__gidis__12C8C788");

            entity.HasOne(d => d.IstenenKargo).WithMany(p => p.GonderilenKargolars)
                .HasForeignKey(d => d.IstenenKargoId)
                .HasConstraintName("FK__Gonderile__isten__0E04126B");

            entity.HasOne(d => d.KargoFirma).WithMany(p => p.GonderilenKargolars)
                .HasForeignKey(d => d.KargoFirmaId)
                .HasConstraintName("FK__Gonderile__kargo__0EF836A4");

            entity.HasOne(d => d.KargoFirmaSube).WithMany(p => p.GonderilenKargolars)
                .HasForeignKey(d => d.KargoFirmaSubeId)
                .HasConstraintName("FK__Gonderile__kargo__10E07F16");
        });

        modelBuilder.Entity<IadeTalep>(entity =>
        {
            entity.HasKey(e => e.TalepId).HasName("PK__IadeTale__8CD4AA2664402F9E");

            entity.ToTable("IadeTalep");

            entity.Property(e => e.TalepId).HasColumnName("talepId");
            entity.Property(e => e.Aktiflik).HasColumnName("aktiflik");
            entity.Property(e => e.KullaniciId).HasColumnName("kullaniciId");
            entity.Property(e => e.OdemeId).HasColumnName("odemeId");
            entity.Property(e => e.Onay).HasColumnName("onay");
            entity.Property(e => e.Sebep)
                .HasMaxLength(500)
                .HasColumnName("sebep");
            entity.Property(e => e.Tarih)
                .HasColumnType("datetime")
                .HasColumnName("tarih");

            entity.HasOne(d => d.Kullanici).WithMany(p => p.IadeTaleps)
                .HasForeignKey(d => d.KullaniciId)
                .HasConstraintName("FK__IadeTalep__kulla__0880433F");

            entity.HasOne(d => d.Odeme).WithMany(p => p.IadeTaleps)
                .HasForeignKey(d => d.OdemeId)
                .HasConstraintName("FK__IadeTalep__odeme__078C1F06");
        });

        modelBuilder.Entity<Iadeler>(entity =>
        {
            entity.HasKey(e => e.IadeId).HasName("PK__Iadeler__A794D3D583BCA226");

            entity.ToTable("Iadeler");

            entity.Property(e => e.IadeId).HasColumnName("iadeId");
            entity.Property(e => e.IadeTalepId).HasColumnName("iadeTalepId");
            entity.Property(e => e.IadeTutarı).HasColumnName("iadeTutarı");
            entity.Property(e => e.KullaniciId).HasColumnName("kullaniciId");
            entity.Property(e => e.Tarih)
                .HasColumnType("datetime")
                .HasColumnName("tarih");

            entity.HasOne(d => d.IadeTalep).WithMany(p => p.Iadelers)
                .HasForeignKey(d => d.IadeTalepId)
                .HasConstraintName("FK__Iadeler__iadeTal__0B5CAFEA");

            entity.HasOne(d => d.Kullanici).WithMany(p => p.Iadelers)
                .HasForeignKey(d => d.KullaniciId)
                .HasConstraintName("FK__Iadeler__kullani__0C50D423");
        });

        modelBuilder.Entity<IstenenKargolar>(entity =>
        {
            entity.HasKey(e => e.IstekKargoId).HasName("PK__IstenenK__282365D32FAD8BA9");

            entity.ToTable("IstenenKargolar");

            entity.Property(e => e.IstekKargoId).HasColumnName("istekKargoId");
            entity.Property(e => e.Akitflik).HasColumnName("akitflik");
            entity.Property(e => e.KargoFirmaId).HasColumnName("kargoFirmaId");
            entity.Property(e => e.SatisId).HasColumnName("satisId");
            entity.Property(e => e.SatisiciFirmaId).HasColumnName("satisiciFirmaId");
            entity.Property(e => e.Tarih)
                .HasColumnType("datetime")
                .HasColumnName("tarih");

            entity.HasOne(d => d.KargoFirma).WithMany(p => p.IstenenKargolars)
                .HasForeignKey(d => d.KargoFirmaId)
                .HasConstraintName("FK__IstenenKa__kargo__075714DC");

            entity.HasOne(d => d.Satis).WithMany(p => p.IstenenKargolars)
                .HasForeignKey(d => d.SatisId)
                .HasConstraintName("FK__IstenenKa__satis__0662F0A3");

            entity.HasOne(d => d.SatisiciFirma).WithMany(p => p.IstenenKargolars)
                .HasForeignKey(d => d.SatisiciFirmaId)
                .HasConstraintName("FK__IstenenKa__satis__084B3915");
        });

        modelBuilder.Entity<KargoBildirimler>(entity =>
        {
            entity.HasKey(e => e.KargoBildirimId).HasName("PK__KargoBil__8646FDE21E0E8428");

            entity.ToTable("KargoBildirimler");

            entity.Property(e => e.KargoBildirimId).HasColumnName("kargoBildirimId");
            entity.Property(e => e.Aktiflik).HasColumnName("aktiflik");
            entity.Property(e => e.KargoBildirim)
                .HasMaxLength(500)
                .HasColumnName("kargoBildirim");
            entity.Property(e => e.KargoBildirimBaslik)
                .HasMaxLength(30)
                .HasColumnName("kargoBildirimBaslik");
            entity.Property(e => e.KargoFirmaId).HasColumnName("kargoFirmaId");
            entity.Property(e => e.KullaniciId).HasColumnName("kullaniciId");
            entity.Property(e => e.OkunduBilgisi).HasColumnName("okunduBilgisi");
            entity.Property(e => e.Tarih)
                .HasColumnType("datetime")
                .HasColumnName("tarih");

            entity.HasOne(d => d.KargoFirma).WithMany(p => p.KargoBildirimlers)
                .HasForeignKey(d => d.KargoFirmaId)
                .HasConstraintName("FK__KargoBild__kargo__22FF2F51");

            entity.HasOne(d => d.Kullanici).WithMany(p => p.KargoBildirimlers)
                .HasForeignKey(d => d.KullaniciId)
                .HasConstraintName("FK__KargoBild__kulla__23F3538A");
        });

        modelBuilder.Entity<KargoFirma>(entity =>
        {
            entity.HasKey(e => e.KargoFirmaId).HasName("PK__KargoFir__BEB765C872ABB98A");

            entity.ToTable("KargoFirma");

            entity.Property(e => e.KargoFirmaId).HasColumnName("kargoFirmaId");
            entity.Property(e => e.Aktiflik).HasColumnName("aktiflik");
            entity.Property(e => e.FirmaMerkezAdres)
                .HasMaxLength(500)
                .HasColumnName("firmaMerkezAdres");
            entity.Property(e => e.KargoFirmaAd)
                .HasMaxLength(100)
                .HasColumnName("kargoFirmaAd");
            entity.Property(e => e.KargoFirmaEmail)
                .HasMaxLength(100)
                .HasColumnName("kargoFirmaEmail");
            entity.Property(e => e.KargoFirmaTel)
                .HasMaxLength(20)
                .HasColumnName("kargoFirmaTel");
            entity.Property(e => e.Ulke)
                .HasMaxLength(100)
                .HasColumnName("ulke");
        });

        modelBuilder.Entity<KargoFirmaSubeler>(entity =>
        {
            entity.HasKey(e => e.KargoFirmaSubeId).HasName("PK__KargoFir__B2FFBB4D3379083A");

            entity.ToTable("KargoFirmaSubeler");

            entity.Property(e => e.KargoFirmaSubeId).HasColumnName("kargoFirmaSubeId");
            entity.Property(e => e.Adress)
                .HasMaxLength(500)
                .HasColumnName("adress");
            entity.Property(e => e.Aktiflik).HasColumnName("aktiflik");
            entity.Property(e => e.EklenmeTarihi)
                .HasColumnType("datetime")
                .HasColumnName("eklenmeTarihi");
            entity.Property(e => e.KargoFirmaId).HasColumnName("kargoFirmaId");

            entity.HasOne(d => d.KargoFirma).WithMany(p => p.KargoFirmaSubelers)
                .HasForeignKey(d => d.KargoFirmaId)
                .HasConstraintName("FK__KargoFirm__kargo__7FB5F314");
        });

        modelBuilder.Entity<KargoFirmadanTeknikElmanSikayeti>(entity =>
        {
            entity.HasKey(e => e.SikayetId).HasName("PK__kargoFir__BBDC1CC6722413DC");

            entity.ToTable("KargoFirmadanTeknikElmanSikayeti");

            entity.Property(e => e.SikayetId).HasColumnName("sikayetId");
            entity.Property(e => e.Aktiflik).HasColumnName("aktiflik");
            entity.Property(e => e.KargoFirmaId).HasColumnName("kargoFirmaId");
            entity.Property(e => e.SikayetBaslik)
                .HasMaxLength(20)
                .HasColumnName("sikayetBaslik");
            entity.Property(e => e.SikayetMetni)
                .HasMaxLength(500)
                .HasColumnName("sikayetMetni");
            entity.Property(e => e.Tarih)
                .HasColumnType("datetime")
                .HasColumnName("tarih");
            entity.Property(e => e.TeknikElemanId).HasColumnName("teknikElemanId");

            entity.HasOne(d => d.KargoFirma).WithMany(p => p.KargoFirmadanTeknikElmanSikayetis)
                .HasForeignKey(d => d.KargoFirmaId)
                .HasConstraintName("FK__kargoFirm__kargo__3429BB53");

            entity.HasOne(d => d.TeknikEleman).WithMany(p => p.KargoFirmadanTeknikElmanSikayetis)
                .HasForeignKey(d => d.TeknikElemanId)
                .HasConstraintName("FK__kargoFirm__tekni__351DDF8C");
        });

        modelBuilder.Entity<KargoPuanlama>(entity =>
        {
            entity.HasKey(e => e.KargoPuanlamaId).HasName("PK__KargoPua__5D65CAEBA372C2C7");

            entity.ToTable("KargoPuanlama");

            entity.Property(e => e.KargoPuanlamaId).HasColumnName("kargoPuanlamaId");
            entity.Property(e => e.Aktiflik).HasColumnName("aktiflik");
            entity.Property(e => e.KargoFirmaId).HasColumnName("kargoFirmaId");
            entity.Property(e => e.KullaniciId).HasColumnName("kullaniciId");
            entity.Property(e => e.Puan).HasColumnName("puan");
            entity.Property(e => e.Tarih)
                .HasColumnType("datetime")
                .HasColumnName("tarih");

            entity.HasOne(d => d.KargoFirma).WithMany(p => p.KargoPuanlamas)
                .HasForeignKey(d => d.KargoFirmaId)
                .HasConstraintName("FK__KargoPuan__kargo__038683F8");

            entity.HasOne(d => d.Kullanici).WithMany(p => p.KargoPuanlamas)
                .HasForeignKey(d => d.KullaniciId)
                .HasConstraintName("FK__KargoPuan__kulla__02925FBF");
        });

        modelBuilder.Entity<KargodanTeknikElemanaMesaj>(entity =>
        {
            entity.HasKey(e => e.MesajId).HasName("PK__Kargodan__FFB37EE4FE135B5A");

            entity.ToTable("KargodanTeknikElemanaMesaj");

            entity.Property(e => e.MesajId).HasColumnName("mesajId");
            entity.Property(e => e.Aktiflik).HasColumnName("aktiflik");
            entity.Property(e => e.KargoFirmaId).HasColumnName("kargoFirmaId");
            entity.Property(e => e.Mesaj)
                .HasMaxLength(1000)
                .HasColumnName("mesaj");
            entity.Property(e => e.MesajBaslik)
                .HasMaxLength(20)
                .HasColumnName("mesajBaslik");
            entity.Property(e => e.MesajlasmaId).HasColumnName("mesajlasmaId");
            entity.Property(e => e.OkunduBilgisi).HasColumnName("okunduBilgisi");
            entity.Property(e => e.Tarih)
                .HasColumnType("datetime")
                .HasColumnName("tarih");
            entity.Property(e => e.TeknikElemanId).HasColumnName("teknikElemanId");

            entity.HasOne(d => d.KargoFirma).WithMany(p => p.KargodanTeknikElemanaMesajs)
                .HasForeignKey(d => d.KargoFirmaId)
                .HasConstraintName("FK__KargodanT__kargo__1B5E0D89");

            entity.HasOne(d => d.Mesajlasma).WithMany(p => p.KargodanTeknikElemanaMesajs)
                .HasForeignKey(d => d.MesajlasmaId)
                .HasConstraintName("FK_Orders_Customers");

            entity.HasOne(d => d.TeknikEleman).WithMany(p => p.KargodanTeknikElemanaMesajs)
                .HasForeignKey(d => d.TeknikElemanId)
                .HasConstraintName("FK__KargodanT__tekni__1A69E950");
        });

        modelBuilder.Entity<Kategori>(entity =>
        {
            entity.HasKey(e => e.KategoriId).HasName("PK__Kategori__1D91819D28B2EB33");

            entity.ToTable("Kategori");

            entity.Property(e => e.KategoriId).HasColumnName("kategoriId");
            entity.Property(e => e.Aktiflik).HasColumnName("aktiflik");
            entity.Property(e => e.KategoriAciklama)
                .HasMaxLength(500)
                .HasColumnName("kategoriAciklama");
            entity.Property(e => e.KategoriAd)
                .HasMaxLength(100)
                .HasColumnName("kategoriAd");
        });

        modelBuilder.Entity<KategoriKampanyalar>(entity =>
        {
            entity.HasKey(e => e.KampanyaId).HasName("PK__Kategori__CE61BFDCBDF22CB9");

            entity.ToTable("KategoriKampanyalar");

            entity.Property(e => e.KampanyaId).HasColumnName("kampanyaId");
            entity.Property(e => e.Aktiflik).HasColumnName("aktiflik");
            entity.Property(e => e.BaslangicTarihi)
                .HasColumnType("datetime")
                .HasColumnName("baslangicTarihi");
            entity.Property(e => e.BitisTarihi)
                .HasColumnType("datetime")
                .HasColumnName("bitisTarihi");
            entity.Property(e => e.IndirimMiktari).HasColumnName("indirimMiktari");
            entity.Property(e => e.KampanyaAciklama)
                .HasMaxLength(2000)
                .HasColumnName("kampanyaAciklama");
            entity.Property(e => e.KampanyaBaslik)
                .HasMaxLength(100)
                .HasColumnName("kampanyaBaslik");
            entity.Property(e => e.KategoriId).HasColumnName("kategoriId");

            entity.HasOne(d => d.Kategori).WithMany(p => p.KategoriKampanyalars)
                .HasForeignKey(d => d.KategoriId)
                .HasConstraintName("FK__KategoriK__kateg__1CBC4616");
        });

        modelBuilder.Entity<Kullanici>(entity =>
        {
            entity.HasKey(e => e.KullaniciId).HasName("PK__Kullanic__848DC56BD99BCF9C");

            entity.ToTable("Kullanici");

            entity.Property(e => e.KullaniciId).HasColumnName("kullaniciId");
            entity.Property(e => e.Adres)
                .HasMaxLength(300)
                .HasColumnName("adres");
            entity.Property(e => e.Aktiflik).HasColumnName("aktiflik");
            entity.Property(e => e.CoinMiktari).HasColumnName("coinMiktari");
            entity.Property(e => e.KayitTarihi)
                .HasColumnType("datetime")
                .HasColumnName("kayitTarihi");
            entity.Property(e => e.KullaniciAd)
                .HasMaxLength(100)
                .HasColumnName("kullaniciAd");
            entity.Property(e => e.KullaniciResim)
                .HasMaxLength(200)
                .HasColumnName("kullaniciResim");
            entity.Property(e => e.Mail)
                .HasMaxLength(100)
                .HasColumnName("mail");
            entity.Property(e => e.MailSifre)
                .HasMaxLength(20)
                .HasColumnName("mailSifre");
            entity.Property(e => e.ReferansKullaniciAd)
                .HasMaxLength(100)
                .HasColumnName("referansKullaniciAd");
            entity.Property(e => e.ReferansMail)
                .HasMaxLength(100)
                .HasColumnName("referansMail");
            entity.Property(e => e.ReferansOlmaSayisi).HasColumnName("referansOlmaSayisi");
            entity.Property(e => e.Sifre)
                .HasMaxLength(20)
                .HasColumnName("sifre");
            entity.Property(e => e.SosyalSorumlulukKatilimSayisi).HasColumnName("sosyalSorumlulukKatilimSayisi");
            entity.Property(e => e.YorumCevapSayisi).HasColumnName("yorumCevapSayisi");
            entity.Property(e => e.YorumSayisi).HasColumnName("yorumSayisi");
        });

        modelBuilder.Entity<KullaniciAdresler>(entity =>
        {
            entity.HasKey(e => e.KullaniciAdresId).HasName("PK__Kullanic__6FEA7E621C552BC6");

            entity.ToTable("KullaniciAdresler");

            entity.Property(e => e.KullaniciAdresId).HasColumnName("kullaniciAdresId");
            entity.Property(e => e.Adres)
                .HasMaxLength(500)
                .HasColumnName("adres");
            entity.Property(e => e.AdresBaslik)
                .HasMaxLength(30)
                .HasColumnName("adresBaslik");
            entity.Property(e => e.Aktiflik).HasColumnName("aktiflik");
            entity.Property(e => e.EklenmeTarihi)
                .HasColumnType("datetime")
                .HasColumnName("eklenmeTarihi");
            entity.Property(e => e.KullaniciId).HasColumnName("kullaniciId");
            entity.Property(e => e.Sehir)
                .HasMaxLength(100)
                .HasColumnName("sehir");
            entity.Property(e => e.Ulke)
                .HasMaxLength(100)
                .HasColumnName("ulke");

            entity.HasOne(d => d.Kullanici).WithMany(p => p.KullaniciAdreslers)
                .HasForeignKey(d => d.KullaniciId)
                .HasConstraintName("FK__Kullanici__kulla__0B27A5C0");
        });

        modelBuilder.Entity<KullaniciCikislar>(entity =>
        {
            entity.HasKey(e => e.KullaniciCikisId).HasName("PK__Kullanic__399D860F0964300A");

            entity.ToTable("KullaniciCikislar");

            entity.Property(e => e.KullaniciCikisId).HasColumnName("kullaniciCikisId");
            entity.Property(e => e.BasariDurumu).HasColumnName("basariDurumu");
            entity.Property(e => e.KullaniciGirisId).HasColumnName("kullaniciGirisId");
            entity.Property(e => e.KullaniciId).HasColumnName("kullaniciId");
            entity.Property(e => e.Tarih)
                .HasColumnType("datetime")
                .HasColumnName("tarih");

            entity.HasOne(d => d.KullaniciGiris).WithMany(p => p.KullaniciCikislars)
                .HasForeignKey(d => d.KullaniciGirisId)
                .HasConstraintName("FK__Kullanici__kulla__3DE82FB7");

            entity.HasOne(d => d.Kullanici).WithMany(p => p.KullaniciCikislars)
                .HasForeignKey(d => d.KullaniciId)
                .HasConstraintName("FK__Kullanici__kulla__3CF40B7E");
        });

        modelBuilder.Entity<KullaniciGirisler>(entity =>
        {
            entity.HasKey(e => e.GirisId).HasName("PK__Kullanic__F8F62BEF9193DEC7");

            entity.ToTable("KullaniciGirisler");

            entity.Property(e => e.GirisId).HasColumnName("girisId");
            entity.Property(e => e.BasariDurumu).HasColumnName("basariDurumu");
            entity.Property(e => e.KullaniciId).HasColumnName("kullaniciId");
            entity.Property(e => e.Tarih)
                .HasColumnType("datetime")
                .HasColumnName("tarih");
        });

        modelBuilder.Entity<KullaniciKartBilgileri>(entity =>
        {
            entity.HasKey(e => e.KartId).HasName("PK__Kullanic__24621F9229B73A01");

            entity.ToTable("KullaniciKartBilgileri");

            entity.Property(e => e.KartId).HasColumnName("kartId");
            entity.Property(e => e.Aciklama)
                .HasMaxLength(100)
                .HasColumnName("aciklama");
            entity.Property(e => e.Aktiflik).HasColumnName("aktiflik");
            entity.Property(e => e.Cvv)
                .HasMaxLength(3)
                .HasColumnName("cvv");
            entity.Property(e => e.EklenmeTarihi)
                .HasColumnType("datetime")
                .HasColumnName("eklenmeTarihi");
            entity.Property(e => e.GecerlilikTarihi)
                .HasMaxLength(5)
                .HasColumnName("gecerlilikTarihi");
            entity.Property(e => e.KartNumarasi)
                .HasMaxLength(16)
                .HasColumnName("kartNumarasi");
            entity.Property(e => e.KullaniciId).HasColumnName("kullaniciId");

            entity.HasOne(d => d.Kullanici).WithMany(p => p.KullaniciKartBilgileris)
                .HasForeignKey(d => d.KullaniciId)
                .HasConstraintName("FK__Kullanici__kulla__5441852A");
        });

        modelBuilder.Entity<KullaniciSiteOneriler>(entity =>
        {
            entity.HasKey(e => e.OneriId).HasName("PK__Kullanic__B97B4C5DAE873B07");

            entity.ToTable("KullaniciSiteOneriler");

            entity.Property(e => e.OneriId).HasColumnName("oneriId");
            entity.Property(e => e.Aktiflik).HasColumnName("aktiflik");
            entity.Property(e => e.KullaniciId).HasColumnName("kullaniciId");
            entity.Property(e => e.OneriBaslik)
                .HasMaxLength(20)
                .HasColumnName("oneriBaslik");
            entity.Property(e => e.OneriMetin)
                .HasMaxLength(500)
                .HasColumnName("oneriMetin");
            entity.Property(e => e.Tarih)
                .HasColumnType("datetime")
                .HasColumnName("tarih");

            entity.HasOne(d => d.Kullanici).WithMany(p => p.KullaniciSiteOnerilers)
                .HasForeignKey(d => d.KullaniciId)
                .HasConstraintName("FK__Kullanici__kulla__73852659");
        });

        modelBuilder.Entity<KullaniciYarismaKatilanlar>(entity =>
        {
            entity.HasKey(e => e.KatilimId).HasName("PK__Kullanic__B2983A60001AF575");

            entity.ToTable("KullaniciYarismaKatilanlar");

            entity.Property(e => e.KatilimId).HasColumnName("katilimId");
            entity.Property(e => e.Aktiflik).HasColumnName("aktiflik");
            entity.Property(e => e.KatilmaTarih)
                .HasColumnType("datetime")
                .HasColumnName("katilmaTarih");
            entity.Property(e => e.KullaniciId).HasColumnName("kullaniciId");
            entity.Property(e => e.KullaniciYarismaId).HasColumnName("kullaniciYarismaId");

            entity.HasOne(d => d.Kullanici).WithMany(p => p.KullaniciYarismaKatilanlars)
                .HasForeignKey(d => d.KullaniciId)
                .HasConstraintName("FK__Kullanici__kulla__24285DB4");

            entity.HasOne(d => d.KullaniciYarisma).WithMany(p => p.KullaniciYarismaKatilanlars)
                .HasForeignKey(d => d.KullaniciYarismaId)
                .HasConstraintName("FK__Kullanici__kulla__251C81ED");
        });

        modelBuilder.Entity<KullaniciYarismaKazananlar>(entity =>
        {
            entity.HasKey(e => e.KazanmaId).HasName("PK__Kullanic__5F4DA5D58F970C1C");

            entity.ToTable("KullaniciYarismaKazananlar");

            entity.Property(e => e.KazanmaId).HasColumnName("kazanmaId");
            entity.Property(e => e.KazanmaTarih)
                .HasColumnType("datetime")
                .HasColumnName("kazanmaTarih");
            entity.Property(e => e.KullaniciId).HasColumnName("kullaniciId");
            entity.Property(e => e.KullaniciYarismaId).HasColumnName("kullaniciYarismaId");

            entity.HasOne(d => d.Kullanici).WithMany(p => p.KullaniciYarismaKazananlars)
                .HasForeignKey(d => d.KullaniciId)
                .HasConstraintName("FK__Kullanici__kulla__27F8EE98");

            entity.HasOne(d => d.KullaniciYarisma).WithMany(p => p.KullaniciYarismaKazananlars)
                .HasForeignKey(d => d.KullaniciYarismaId)
                .HasConstraintName("FK__Kullanici__kulla__28ED12D1");
        });

        modelBuilder.Entity<KullaniciYarismalar>(entity =>
        {
            entity.HasKey(e => e.KullaniciYarismaId).HasName("PK__Kullanic__69252C173EEB132B");

            entity.ToTable("KullaniciYarismalar");

            entity.Property(e => e.KullaniciYarismaId).HasColumnName("kullaniciYarismaId");
            entity.Property(e => e.Aktiflik).HasColumnName("aktiflik");
            entity.Property(e => e.BaslangicTarih)
                .HasColumnType("datetime")
                .HasColumnName("baslangicTarih");
            entity.Property(e => e.BitisTarih)
                .HasColumnType("datetime")
                .HasColumnName("bitisTarih");
            entity.Property(e => e.YarismaAciklama)
                .HasMaxLength(3000)
                .HasColumnName("yarismaAciklama");
            entity.Property(e => e.YarismaBaslik)
                .HasMaxLength(30)
                .HasColumnName("yarismaBaslik");
        });

        modelBuilder.Entity<KullaniciYorumCevap>(entity =>
        {
            entity.HasKey(e => e.CevapId).HasName("PK__Kullanic__63A47692AA53AE2F");

            entity.ToTable("KullaniciYorumCevap");

            entity.Property(e => e.CevapId).HasColumnName("cevapId");
            entity.Property(e => e.Aktiflik).HasColumnName("aktiflik");
            entity.Property(e => e.Cevap)
                .HasMaxLength(300)
                .HasColumnName("cevap");
            entity.Property(e => e.KullaniciId).HasColumnName("kullaniciId");
            entity.Property(e => e.Tarih)
                .HasColumnType("datetime")
                .HasColumnName("tarih");
            entity.Property(e => e.YorumId).HasColumnName("yorumId");

            entity.HasOne(d => d.Kullanici).WithMany(p => p.KullaniciYorumCevaps)
                .HasForeignKey(d => d.KullaniciId)
                .HasConstraintName("FK__Kullanici__kulla__65370702");

            entity.HasOne(d => d.Yorum).WithMany(p => p.KullaniciYorumCevaps)
                .HasForeignKey(d => d.YorumId)
                .HasConstraintName("FK__Kullanici__yorum__662B2B3B");
        });

        modelBuilder.Entity<KullanicidanFirmayaSikayet>(entity =>
        {
            entity.HasKey(e => e.SikayetId).HasName("PK__Kullanic__BBDC1CC618AE5DB8");

            entity.ToTable("KullanicidanFirmayaSikayet");

            entity.Property(e => e.SikayetId).HasColumnName("sikayetId");
            entity.Property(e => e.Aktiflik).HasColumnName("aktiflik");
            entity.Property(e => e.FirmaId).HasColumnName("firmaId");
            entity.Property(e => e.SikayetBaslik)
                .HasMaxLength(20)
                .HasColumnName("sikayetBaslik");
            entity.Property(e => e.SikayetMetni)
                .HasMaxLength(500)
                .HasColumnName("sikayetMetni");
            entity.Property(e => e.SikayetciId).HasColumnName("sikayetciId");
            entity.Property(e => e.Tarih)
                .HasColumnType("datetime")
                .HasColumnName("tarih");

            entity.HasOne(d => d.Firma).WithMany(p => p.KullanicidanFirmayaSikayets)
                .HasForeignKey(d => d.FirmaId)
                .HasConstraintName("FK__Kullanici__firma__45BE5BA9");

            entity.HasOne(d => d.Sikayetci).WithMany(p => p.KullanicidanFirmayaSikayets)
                .HasForeignKey(d => d.SikayetciId)
                .HasConstraintName("FK__Kullanici__sikay__44CA3770");
        });

        modelBuilder.Entity<KullanicidanFirmayaYorumCevapSikayet>(entity =>
        {
            entity.HasKey(e => e.KullaniciYorumCevapSikayetId).HasName("PK__Kullanic__46FC2D03FF23C02C");

            entity.ToTable("KullanicidanFirmayaYorumCevapSikayet");

            entity.Property(e => e.KullaniciYorumCevapSikayetId).HasColumnName("kullaniciYorumCevapSikayetId");
            entity.Property(e => e.Aktiflik).HasColumnName("aktiflik");
            entity.Property(e => e.FirmaId).HasColumnName("firmaId");
            entity.Property(e => e.KullaniciId).HasColumnName("kullaniciId");
            entity.Property(e => e.SikayetBaslik)
                .HasMaxLength(20)
                .HasColumnName("sikayetBaslik");
            entity.Property(e => e.SikayetMetni)
                .HasMaxLength(500)
                .HasColumnName("sikayetMetni");
            entity.Property(e => e.Tarih)
                .HasColumnType("datetime")
                .HasColumnName("tarih");
            entity.Property(e => e.YorumCevapId).HasColumnName("yorumCevapId");

            entity.HasOne(d => d.Firma).WithMany(p => p.KullanicidanFirmayaYorumCevapSikayets)
                .HasForeignKey(d => d.FirmaId)
                .HasConstraintName("FK__Kullanici__firma__6AEFE058");

            entity.HasOne(d => d.Kullanici).WithMany(p => p.KullanicidanFirmayaYorumCevapSikayets)
                .HasForeignKey(d => d.KullaniciId)
                .HasConstraintName("FK__Kullanici__kulla__69FBBC1F");

            entity.HasOne(d => d.YorumCevap).WithMany(p => p.KullanicidanFirmayaYorumCevapSikayets)
                .HasForeignKey(d => d.YorumCevapId)
                .HasConstraintName("FK__Kullanici__yorum__690797E6");
        });

        modelBuilder.Entity<KullanicidanKargoFirmasiSikayeti>(entity =>
        {
            entity.HasKey(e => e.SikayetId).HasName("PK__Kullanic__BBDC1CC6EF49D954");

            entity.ToTable("KullanicidanKargoFirmasiSikayeti");

            entity.Property(e => e.SikayetId).HasColumnName("sikayetId");
            entity.Property(e => e.Aktiflik).HasColumnName("aktiflik");
            entity.Property(e => e.KargoFirmaId).HasColumnName("kargoFirmaId");
            entity.Property(e => e.KullaniciId).HasColumnName("kullaniciId");
            entity.Property(e => e.SikayetBaslik)
                .HasMaxLength(20)
                .HasColumnName("sikayetBaslik");
            entity.Property(e => e.SikayetMetni)
                .HasMaxLength(500)
                .HasColumnName("sikayetMetni");
            entity.Property(e => e.Tarih)
                .HasColumnType("datetime")
                .HasColumnName("tarih");

            entity.HasOne(d => d.KargoFirma).WithMany(p => p.KullanicidanKargoFirmasiSikayetis)
                .HasForeignKey(d => d.KargoFirmaId)
                .HasConstraintName("FK__Kullanici__kargo__3BCADD1B");

            entity.HasOne(d => d.Kullanici).WithMany(p => p.KullanicidanKargoFirmasiSikayetis)
                .HasForeignKey(d => d.KullaniciId)
                .HasConstraintName("FK__Kullanici__kulla__3CBF0154");
        });

        modelBuilder.Entity<KullanicidanTeknikDestegeMesaj>(entity =>
        {
            entity.HasKey(e => e.MesajId).HasName("PK__kullanic__FFB37EE4D098F577");

            entity.ToTable("kullanicidanTeknikDestegeMesaj");

            entity.Property(e => e.MesajId).HasColumnName("mesajId");
            entity.Property(e => e.Aktiflik).HasColumnName("aktiflik");
            entity.Property(e => e.KullaniciId).HasColumnName("kullaniciId");
            entity.Property(e => e.Mesaj)
                .HasMaxLength(500)
                .HasColumnName("mesaj");
            entity.Property(e => e.MesajBaslik)
                .HasMaxLength(20)
                .HasColumnName("mesajBaslik");
            entity.Property(e => e.MesajlasmaId).HasColumnName("mesajlasmaId");
            entity.Property(e => e.OkunduBilgisi).HasColumnName("okunduBilgisi");
            entity.Property(e => e.Tarih)
                .HasColumnType("datetime")
                .HasColumnName("tarih");
            entity.Property(e => e.TeknikElemanId).HasColumnName("teknikElemanId");

            entity.HasOne(d => d.Kullanici).WithMany(p => p.KullanicidanTeknikDestegeMesajs)
                .HasForeignKey(d => d.KullaniciId)
                .HasConstraintName("FK__kullanici__kulla__6D0D32F4");

            entity.HasOne(d => d.Mesajlasma).WithMany(p => p.KullanicidanTeknikDestegeMesajs)
                .HasForeignKey(d => d.MesajlasmaId)
                .HasConstraintName("FK__kullanici__mesaj__6C190EBB");

            entity.HasOne(d => d.TeknikEleman).WithMany(p => p.KullanicidanTeknikDestegeMesajs)
                .HasForeignKey(d => d.TeknikElemanId)
                .HasConstraintName("FK__kullanici__tekni__6E01572D");
        });

        modelBuilder.Entity<KullanicidanTeknikElemanaSikayet>(entity =>
        {
            entity.HasKey(e => e.SikayetId).HasName("PK__Kullanic__BBDC1CC624067D0D");

            entity.ToTable("KullanicidanTeknikElemanaSikayet");

            entity.Property(e => e.SikayetId).HasColumnName("sikayetId");
            entity.Property(e => e.Aktiflik).HasColumnName("aktiflik");
            entity.Property(e => e.KullaniciId).HasColumnName("kullaniciId");
            entity.Property(e => e.SikayetBaslik)
                .HasMaxLength(20)
                .HasColumnName("sikayetBaslik");
            entity.Property(e => e.SikayetMetni)
                .HasMaxLength(500)
                .HasColumnName("sikayetMetni");
            entity.Property(e => e.Tarih)
                .HasColumnType("datetime")
                .HasColumnName("tarih");
            entity.Property(e => e.TeknikElemanId).HasColumnName("teknikElemanId");

            entity.HasOne(d => d.Kullanici).WithMany(p => p.KullanicidanTeknikElemanaSikayets)
                .HasForeignKey(d => d.KullaniciId)
                .HasConstraintName("FK__Kullanici__kulla__503BEA1C");

            entity.HasOne(d => d.TeknikEleman).WithMany(p => p.KullanicidanTeknikElemanaSikayets)
                .HasForeignKey(d => d.TeknikElemanId)
                .HasConstraintName("FK__Kullanici__tekni__51300E55");
        });

        modelBuilder.Entity<KullanicidanYorumSikayet>(entity =>
        {
            entity.HasKey(e => e.YorumSikayetId).HasName("PK__Kullanic__DAB3D68F16126BB2");

            entity.ToTable("KullanicidanYorumSikayet");

            entity.Property(e => e.YorumSikayetId).HasColumnName("yorumSikayetId");
            entity.Property(e => e.Aktiflik).HasColumnName("aktiflik");
            entity.Property(e => e.BildirilenKullaniciId).HasColumnName("bildirilenKullaniciId");
            entity.Property(e => e.SikayetBaslik)
                .HasMaxLength(20)
                .HasColumnName("sikayetBaslik");
            entity.Property(e => e.SikayetMetni)
                .HasMaxLength(500)
                .HasColumnName("sikayetMetni");
            entity.Property(e => e.SikayetciKullaniciId).HasColumnName("sikayetciKullaniciId");
            entity.Property(e => e.Tarih)
                .HasColumnType("datetime")
                .HasColumnName("tarih");
            entity.Property(e => e.UrunId).HasColumnName("urunId");
            entity.Property(e => e.YorumId).HasColumnName("yorumId");

            entity.HasOne(d => d.BildirilenKullanici).WithMany(p => p.KullanicidanYorumSikayetBildirilenKullanicis)
                .HasForeignKey(d => d.BildirilenKullaniciId)
                .HasConstraintName("FK__Kullanici__bildi__5E8A0973");

            entity.HasOne(d => d.SikayetciKullanici).WithMany(p => p.KullanicidanYorumSikayetSikayetciKullanicis)
                .HasForeignKey(d => d.SikayetciKullaniciId)
                .HasConstraintName("FK__Kullanici__sikay__5D95E53A");

            entity.HasOne(d => d.Urun).WithMany(p => p.KullanicidanYorumSikayets)
                .HasForeignKey(d => d.UrunId)
                .HasConstraintName("FK__Kullanici__urunI__5F7E2DAC");

            entity.HasOne(d => d.Yorum).WithMany(p => p.KullanicidanYorumSikayets)
                .HasForeignKey(d => d.YorumId)
                .HasConstraintName("FK__Kullanici__yorum__5CA1C101");
        });

        modelBuilder.Entity<KullanicilarArasiMesaj>(entity =>
        {
            entity.HasKey(e => e.MesajId).HasName("PK__kullanic__FFB37EE45D834F86");

            entity.ToTable("kullanicilarArasiMesaj");

            entity.Property(e => e.MesajId).HasColumnName("mesajId");
            entity.Property(e => e.Aktiflik).HasColumnName("aktiflik");
            entity.Property(e => e.AliciKullaniciId).HasColumnName("aliciKullaniciId");
            entity.Property(e => e.GonderenKullaniciId).HasColumnName("gonderenKullaniciId");
            entity.Property(e => e.Mesaj)
                .HasMaxLength(500)
                .HasColumnName("mesaj");
            entity.Property(e => e.MesajBaslik)
                .HasMaxLength(20)
                .HasColumnName("mesajBaslik");
            entity.Property(e => e.MesajlasmaId).HasColumnName("mesajlasmaId");
            entity.Property(e => e.OkunduBilgisi).HasColumnName("okunduBilgisi");
            entity.Property(e => e.Tarih)
                .HasColumnType("datetime")
                .HasColumnName("tarih");

            entity.HasOne(d => d.AliciKullanici).WithMany(p => p.KullanicilarArasiMesajAliciKullanicis)
                .HasForeignKey(d => d.AliciKullaniciId)
                .HasConstraintName("FK__kullanici__alici__71D1E811");

            entity.HasOne(d => d.GonderenKullanici).WithMany(p => p.KullanicilarArasiMesajGonderenKullanicis)
                .HasForeignKey(d => d.GonderenKullaniciId)
                .HasConstraintName("FK__kullanici__gonde__72C60C4A");

            entity.HasOne(d => d.Mesajlasma).WithMany(p => p.KullanicilarArasiMesajs)
                .HasForeignKey(d => d.MesajlasmaId)
                .HasConstraintName("FK__kullanici__mesaj__70DDC3D8");
        });

        modelBuilder.Entity<Mesajlasma>(entity =>
        {
            entity.HasKey(e => e.MesajlasmaId).HasName("PK__Mesajlas__310854E153A46D8F");

            entity.ToTable("Mesajlasma");

            entity.Property(e => e.MesajlasmaId).HasColumnName("mesajlasmaId");
            entity.Property(e => e.Tarih)
                .HasColumnType("datetime")
                .HasColumnName("tarih");
        });

        modelBuilder.Entity<Odemeler>(entity =>
        {
            entity.HasKey(e => e.OdemeId).HasName("PK__Odemeler__BD94AC567CAC2FD7");

            entity.ToTable("Odemeler");

            entity.Property(e => e.OdemeId).HasColumnName("odemeId");
            entity.Property(e => e.KullaniciId).HasColumnName("kullaniciId");
            entity.Property(e => e.KuponKod)
                .HasMaxLength(20)
                .HasColumnName("kuponKod");
            entity.Property(e => e.Onay).HasColumnName("onay");
            entity.Property(e => e.SiparisId).HasColumnName("siparisId");
            entity.Property(e => e.Tarih)
                .HasColumnType("datetime")
                .HasColumnName("tarih");

            entity.HasOne(d => d.Kullanici).WithMany(p => p.Odemelers)
                .HasForeignKey(d => d.KullaniciId)
                .HasConstraintName("FK__Odemeler__kullan__7A3223E8");

            entity.HasOne(d => d.Siparis).WithMany(p => p.Odemelers)
                .HasForeignKey(d => d.SiparisId)
                .HasConstraintName("FK__Odemeler__sipari__793DFFAF");
        });

        modelBuilder.Entity<OnaysızSiparisIptal>(entity =>
        {
            entity.HasKey(e => e.IptalId).HasName("PK__OnaysızS__96E9B3A6907E9932");

            entity.ToTable("OnaysızSiparisIptal");

            entity.Property(e => e.IptalId).HasColumnName("iptalId");
            entity.Property(e => e.Fiyat).HasColumnName("fiyat");
            entity.Property(e => e.KullaniciId).HasColumnName("kullaniciId");
            entity.Property(e => e.SiparisId).HasColumnName("siparisId");
            entity.Property(e => e.Tarih)
                .HasColumnType("datetime")
                .HasColumnName("tarih");
            entity.Property(e => e.UrunId).HasColumnName("urunId");

            entity.HasOne(d => d.Kullanici).WithMany(p => p.OnaysızSiparisIptals)
                .HasForeignKey(d => d.KullaniciId)
                .HasConstraintName("FK__OnaysızSi__kulla__03BB8E22");

            entity.HasOne(d => d.Siparis).WithMany(p => p.OnaysızSiparisIptals)
                .HasForeignKey(d => d.SiparisId)
                .HasConstraintName("FK__OnaysızSi__sipar__02C769E9");

            entity.HasOne(d => d.Urun).WithMany(p => p.OnaysızSiparisIptals)
                .HasForeignKey(d => d.UrunId)
                .HasConstraintName("FK__OnaysızSi__urunI__04AFB25B");
        });

        modelBuilder.Entity<ReddedilenSiparisler>(entity =>
        {
            entity.HasKey(e => e.ReddedilenSiparisId).HasName("PK__Reddedil__E925224B3FEC5941");

            entity.ToTable("ReddedilenSiparisler");

            entity.Property(e => e.ReddedilenSiparisId).HasColumnName("reddedilenSiparisId");
            entity.Property(e => e.Fiyat).HasColumnName("fiyat");
            entity.Property(e => e.Sebep)
                .HasMaxLength(500)
                .HasColumnName("sebep");
            entity.Property(e => e.SiparisId).HasColumnName("siparisId");
            entity.Property(e => e.Tarih)
                .HasColumnType("datetime")
                .HasColumnName("tarih");

            entity.HasOne(d => d.Siparis).WithMany(p => p.ReddedilenSiparislers)
                .HasForeignKey(d => d.SiparisId)
                .HasConstraintName("FK__Reddedile__sipar__6383C8BA");
        });

        modelBuilder.Entity<ReferansOlmusKullanicilar>(entity =>
        {
            entity.HasKey(e => e.ReferansOlmaId).HasName("PK__Referans__576779C23045C924");

            entity.ToTable("ReferansOlmusKullanicilar");

            entity.Property(e => e.ReferansOlmaId).HasColumnName("referansOlmaId");
            entity.Property(e => e.Aktiflik).HasColumnName("aktiflik");
            entity.Property(e => e.KayıtOlanKullaniciId).HasColumnName("kayıtOlanKullaniciId");
            entity.Property(e => e.ReferansKullaniciId).HasColumnName("referansKullaniciId");
            entity.Property(e => e.Tarih)
                .HasColumnType("datetime")
                .HasColumnName("tarih");

            entity.HasOne(d => d.KayıtOlanKullanici).WithMany(p => p.ReferansOlmusKullanicilarKayıtOlanKullanicis)
                .HasForeignKey(d => d.KayıtOlanKullaniciId)
                .HasConstraintName("FK__ReferansO__kayıt__1E05700A");

            entity.HasOne(d => d.ReferansKullanici).WithMany(p => p.ReferansOlmusKullanicilarReferansKullanicis)
                .HasForeignKey(d => d.ReferansKullaniciId)
                .HasConstraintName("FK__ReferansO__refer__1D114BD1");
        });

        modelBuilder.Entity<SatisRed>(entity =>
        {
            entity.HasKey(e => e.RedId).HasName("PK__SatisRed__19057567C0A08A64");

            entity.ToTable("SatisRed");

            entity.Property(e => e.RedId).HasColumnName("redId");
            entity.Property(e => e.FirmaId).HasColumnName("firmaId");
            entity.Property(e => e.Fiyat).HasColumnName("fiyat");
            entity.Property(e => e.KullaniciId).HasColumnName("kullaniciId");
            entity.Property(e => e.OdemeId).HasColumnName("odemeId");
            entity.Property(e => e.SiparisId).HasColumnName("siparisId");
            entity.Property(e => e.Tarih)
                .HasColumnType("datetime")
                .HasColumnName("tarih");

            entity.HasOne(d => d.Firma).WithMany(p => p.SatisReds)
                .HasForeignKey(d => d.FirmaId)
                .HasConstraintName("FK__SatisRed__firmaI__7FEAFD3E");

            entity.HasOne(d => d.Kullanici).WithMany(p => p.SatisReds)
                .HasForeignKey(d => d.KullaniciId)
                .HasConstraintName("FK__SatisRed__kullan__7EF6D905");

            entity.HasOne(d => d.Odeme).WithMany(p => p.SatisReds)
                .HasForeignKey(d => d.OdemeId)
                .HasConstraintName("FK__SatisRed__odemeI__7D0E9093");

            entity.HasOne(d => d.Siparis).WithMany(p => p.SatisReds)
                .HasForeignKey(d => d.SiparisId)
                .HasConstraintName("FK__SatisRed__sipari__7E02B4CC");
        });

        modelBuilder.Entity<Satislar>(entity =>
        {
            entity.HasKey(e => e.SatisId).HasName("PK__Satislar__E4F33F4182280AF7");

            entity.ToTable("Satislar");

            entity.Property(e => e.SatisId).HasColumnName("satisId");
            entity.Property(e => e.FaturaAdresi)
                .HasMaxLength(200)
                .HasColumnName("faturaAdresi");
            entity.Property(e => e.FirmaId).HasColumnName("firmaId");
            entity.Property(e => e.GonderiAdresi)
                .HasMaxLength(200)
                .HasColumnName("gonderiAdresi");
            entity.Property(e => e.KullaniciId).HasColumnName("kullaniciId");
            entity.Property(e => e.SiparisId).HasColumnName("siparisId");
            entity.Property(e => e.Tarih)
                .HasColumnType("datetime")
                .HasColumnName("tarih");

            entity.HasOne(d => d.Firma).WithMany(p => p.Satislars)
                .HasForeignKey(d => d.FirmaId)
                .HasConstraintName("FK__Satislar__firmaI__02FC7413");

            entity.HasOne(d => d.Kullanici).WithMany(p => p.Satislars)
                .HasForeignKey(d => d.KullaniciId)
                .HasConstraintName("FK__Satislar__kullan__03F0984C");

            entity.HasOne(d => d.Siparis).WithMany(p => p.Satislars)
                .HasForeignKey(d => d.SiparisId)
                .HasConstraintName("FK__Satislar__sipari__02084FDA");
        });

        modelBuilder.Entity<Sepet>(entity =>
        {
            entity.HasKey(e => e.SepetId).HasName("PK__Sepet__C3AC20841FD02F00");

            entity.ToTable("Sepet");

            entity.Property(e => e.SepetId).HasColumnName("sepetId");
            entity.Property(e => e.AcilmaTarih)
                .HasColumnType("datetime")
                .HasColumnName("acilmaTarih");
            entity.Property(e => e.Aktiflik).HasColumnName("aktiflik");
            entity.Property(e => e.KullaniciId).HasColumnName("kullaniciId");
            entity.Property(e => e.SonGuncelleme)
                .HasColumnType("datetime")
                .HasColumnName("sonGuncelleme");
            entity.Property(e => e.UrunSayisi).HasColumnName("urunSayisi");

            entity.HasOne(d => d.Kullanici).WithMany(p => p.Sepets)
                .HasForeignKey(d => d.KullaniciId)
                .HasConstraintName("FK__Sepet__kullanici__5CD6CB2B");
        });

        modelBuilder.Entity<SepeteEklenme>(entity =>
        {
            entity.HasKey(e => e.EklenmeId).HasName("PK__SepeteEk__9F681FCE75ECF1C0");

            entity.ToTable("SepeteEklenme");

            entity.Property(e => e.EklenmeId).HasColumnName("eklenmeId");
            entity.Property(e => e.KullaniciId).HasColumnName("kullaniciId");
            entity.Property(e => e.SatisBasari).HasColumnName("satisBasari");
            entity.Property(e => e.SepetId).HasColumnName("sepetId");
            entity.Property(e => e.Tarih)
                .HasColumnType("datetime")
                .HasColumnName("tarih");

            entity.HasOne(d => d.Kullanici).WithMany(p => p.SepeteEklenmes)
                .HasForeignKey(d => d.KullaniciId)
                .HasConstraintName("FK__SepeteEkl__kulla__5B438874");

            entity.HasOne(d => d.Sepet).WithMany(p => p.SepeteEklenmes)
                .HasForeignKey(d => d.SepetId)
                .HasConstraintName("FK__SepeteEkl__sepet__5A4F643B");
        });

        modelBuilder.Entity<SepettenCikarma>(entity =>
        {
            entity.HasKey(e => e.CikarmaId).HasName("PK__Sepetten__D774D75A5FD86660");

            entity.ToTable("SepettenCikarma");

            entity.Property(e => e.CikarmaId).HasColumnName("cikarmaId");
            entity.Property(e => e.KullaniciId).HasColumnName("kullaniciId");
            entity.Property(e => e.SatisBasari).HasColumnName("satisBasari");
            entity.Property(e => e.SepetId).HasColumnName("sepetId");
            entity.Property(e => e.Tarih)
                .HasColumnType("datetime")
                .HasColumnName("tarih");

            entity.HasOne(d => d.Kullanici).WithMany(p => p.SepettenCikarmas)
                .HasForeignKey(d => d.KullaniciId)
                .HasConstraintName("FK__SepettenC__kulla__5F141958");

            entity.HasOne(d => d.Sepet).WithMany(p => p.SepettenCikarmas)
                .HasForeignKey(d => d.SepetId)
                .HasConstraintName("FK__SepettenC__sepet__5E1FF51F");
        });

        modelBuilder.Entity<SikcaSorulanlar>(entity =>
        {
            entity.HasKey(e => e.SorulmaId).HasName("PK__SikcaSor__E959DE13EEBAC9D8");

            entity.ToTable("SikcaSorulanlar");

            entity.Property(e => e.SorulmaId).HasColumnName("sorulmaId");
            entity.Property(e => e.Aktiflik).HasColumnName("aktiflik");
            entity.Property(e => e.Cevap)
                .HasMaxLength(3000)
                .HasColumnName("cevap");
            entity.Property(e => e.Soru)
                .HasMaxLength(500)
                .HasColumnName("soru");
        });

        modelBuilder.Entity<SiparisKalemler>(entity =>
        {
            entity.HasKey(e => e.SipariskalemId).HasName("PK__SiparisK__055B7592F9D19BFF");

            entity.ToTable("SiparisKalemler");

            entity.Property(e => e.SipariskalemId).HasColumnName("sipariskalemId");
            entity.Property(e => e.BirimFiyat).HasColumnName("birimFiyat");
            entity.Property(e => e.Miktar).HasColumnName("miktar");
            entity.Property(e => e.SiparisId).HasColumnName("siparisId");
            entity.Property(e => e.UrunId).HasColumnName("urunId");

            entity.HasOne(d => d.Siparis).WithMany(p => p.SiparisKalemlers)
                .HasForeignKey(d => d.SiparisId)
                .HasConstraintName("FK__SiparisKa__sipar__66603565");

            entity.HasOne(d => d.Urun).WithMany(p => p.SiparisKalemlers)
                .HasForeignKey(d => d.UrunId)
                .HasConstraintName("FK__SiparisKa__urunI__6754599E");
        });

        modelBuilder.Entity<Siparisler>(entity =>
        {
            entity.HasKey(e => e.SiparisId).HasName("PK__Siparisl__70545DFC589ACF13");

            entity.ToTable("Siparisler");

            entity.Property(e => e.SiparisId).HasColumnName("siparisId");
            entity.Property(e => e.FaturaAdresi)
                .HasMaxLength(200)
                .HasColumnName("faturaAdresi");
            entity.Property(e => e.GonderiAdresi)
                .HasMaxLength(200)
                .HasColumnName("gonderiAdresi");
            entity.Property(e => e.KargoDurumu).HasColumnName("kargoDurumu");
            entity.Property(e => e.KullaniciId).HasColumnName("kullaniciId");
            entity.Property(e => e.KuponKod)
                .HasMaxLength(20)
                .HasColumnName("kuponKod");
            entity.Property(e => e.Onay).HasColumnName("onay");
            entity.Property(e => e.SepetId).HasColumnName("sepetId");

            entity.HasOne(d => d.Kullanici).WithMany(p => p.Siparislers)
                .HasForeignKey(d => d.KullaniciId)
                .HasConstraintName("FK__Siparisle__kulla__60A75C0F");

            entity.HasOne(d => d.Sepet).WithMany(p => p.Siparislers)
                .HasForeignKey(d => d.SepetId)
                .HasConstraintName("FK__Siparisle__sepet__5FB337D6");
        });

        modelBuilder.Entity<SosyalSorumlulukGorevi>(entity =>
        {
            entity.HasKey(e => e.GorevId).HasName("PK__SosyalSo__E28D07CF862586EF");

            entity.ToTable("SosyalSorumlulukGorevi");

            entity.Property(e => e.GorevId).HasColumnName("gorevId");
            entity.Property(e => e.Aktiflik).HasColumnName("aktiflik");
            entity.Property(e => e.BaslangicTarihi)
                .HasColumnType("datetime")
                .HasColumnName("baslangicTarihi");
            entity.Property(e => e.BitisTarihi)
                .HasColumnType("datetime")
                .HasColumnName("bitisTarihi");
            entity.Property(e => e.GorevAciklama)
                .HasMaxLength(3000)
                .HasColumnName("gorevAciklama");
            entity.Property(e => e.GorevAd)
                .HasMaxLength(50)
                .HasColumnName("gorevAd");
        });

        modelBuilder.Entity<SosyalSorumlulukKatilanFirmalar>(entity =>
        {
            entity.HasKey(e => e.KatilimId).HasName("PK__SosyalSo__B2983A60E0D255A2");

            entity.ToTable("SosyalSorumlulukKatilanFirmalar");

            entity.Property(e => e.KatilimId).HasColumnName("katilimId");
            entity.Property(e => e.Aktiflik).HasColumnName("aktiflik");
            entity.Property(e => e.FirmaId).HasColumnName("firmaId");
            entity.Property(e => e.GorevId).HasColumnName("gorevId");
            entity.Property(e => e.KatilimTarihi)
                .HasColumnType("datetime")
                .HasColumnName("katilimTarihi");
            entity.Property(e => e.Puan).HasColumnName("puan");

            entity.HasOne(d => d.Firma).WithMany(p => p.SosyalSorumlulukKatilanFirmalars)
                .HasForeignKey(d => d.FirmaId)
                .HasConstraintName("FK__SosyalSor__firma__2DB1C7EE");

            entity.HasOne(d => d.Gorev).WithMany(p => p.SosyalSorumlulukKatilanFirmalars)
                .HasForeignKey(d => d.GorevId)
                .HasConstraintName("FK__SosyalSor__gorev__2EA5EC27");
        });

        modelBuilder.Entity<SosyalSorumlulukKatilanKullanicilar>(entity =>
        {
            entity.HasKey(e => e.KatilimId).HasName("PK__SosyalSo__B2983A60E2393D42");

            entity.ToTable("SosyalSorumlulukKatilanKullanicilar");

            entity.Property(e => e.KatilimId).HasColumnName("katilimId");
            entity.Property(e => e.Aktiflik).HasColumnName("aktiflik");
            entity.Property(e => e.GorevId).HasColumnName("gorevId");
            entity.Property(e => e.KatilimTarihi)
                .HasColumnType("datetime")
                .HasColumnName("katilimTarihi");
            entity.Property(e => e.KullaniciId).HasColumnName("kullaniciId");
            entity.Property(e => e.Puan).HasColumnName("puan");

            entity.HasOne(d => d.Gorev).WithMany(p => p.SosyalSorumlulukKatilanKullanicilars)
                .HasForeignKey(d => d.GorevId)
                .HasConstraintName("FK__SosyalSor__gorev__32767D0B");

            entity.HasOne(d => d.Kullanici).WithMany(p => p.SosyalSorumlulukKatilanKullanicilars)
                .HasForeignKey(d => d.KullaniciId)
                .HasConstraintName("FK__SosyalSor__kulla__318258D2");
        });

        modelBuilder.Entity<SosyalSorumlulukTalepFirma>(entity =>
        {
            entity.HasKey(e => e.TalepId).HasName("PK__SosyalSo__8CD4AA26E0E4B799");

            entity.ToTable("SosyalSorumlulukTalepFirma");

            entity.Property(e => e.TalepId).HasColumnName("talepId");
            entity.Property(e => e.Aktiflik).HasColumnName("aktiflik");
            entity.Property(e => e.FirmaId).HasColumnName("firmaId");
            entity.Property(e => e.TalepBaslik)
                .HasMaxLength(20)
                .HasColumnName("talepBaslik");
            entity.Property(e => e.TalepMetin)
                .HasMaxLength(3000)
                .HasColumnName("talepMetin");
            entity.Property(e => e.Tarih)
                .HasColumnType("datetime")
                .HasColumnName("tarih");

            entity.HasOne(d => d.Firma).WithMany(p => p.SosyalSorumlulukTalepFirmas)
                .HasForeignKey(d => d.FirmaId)
                .HasConstraintName("FK__SosyalSor__firma__373B3228");
        });

        modelBuilder.Entity<SosyalSorumlulukTalepKullanici>(entity =>
        {
            entity.HasKey(e => e.TalepId).HasName("PK__SosyalSo__8CD4AA26179DEC38");

            entity.ToTable("SosyalSorumlulukTalepKullanici");

            entity.Property(e => e.TalepId).HasColumnName("talepId");
            entity.Property(e => e.Aktiflik).HasColumnName("aktiflik");
            entity.Property(e => e.KullaniciId).HasColumnName("kullaniciId");
            entity.Property(e => e.TalepBaslik)
                .HasMaxLength(20)
                .HasColumnName("talepBaslik");
            entity.Property(e => e.TalepMetin)
                .HasMaxLength(3000)
                .HasColumnName("talepMetin");
            entity.Property(e => e.Tarih)
                .HasColumnType("datetime")
                .HasColumnName("tarih");

            entity.HasOne(d => d.Kullanici).WithMany(p => p.SosyalSorumlulukTalepKullanicis)
                .HasForeignKey(d => d.KullaniciId)
                .HasConstraintName("FK__SosyalSor__kulla__3A179ED3");
        });

        modelBuilder.Entity<SureliKuponlar>(entity =>
        {
            entity.HasKey(e => e.KuponId).HasName("PK__SureliKu__7C6770EE83A247F8");

            entity.ToTable("SureliKuponlar");

            entity.Property(e => e.KuponId).HasColumnName("kuponId");
            entity.Property(e => e.Aktiflik).HasColumnName("aktiflik");
            entity.Property(e => e.BaslangicTarihi)
                .HasColumnType("datetime")
                .HasColumnName("baslangicTarihi");
            entity.Property(e => e.BitisTarihi)
                .HasColumnType("datetime")
                .HasColumnName("bitisTarihi");
            entity.Property(e => e.IndirimMiktari).HasColumnName("indirimMiktari");
            entity.Property(e => e.KuponAciklama)
                .HasMaxLength(2000)
                .HasColumnName("kuponAciklama");
            entity.Property(e => e.KuponBaslik)
                .HasMaxLength(100)
                .HasColumnName("kuponBaslik");
        });

        modelBuilder.Entity<Talepler>(entity =>
        {
            entity.HasKey(e => e.TalepId).HasName("PK__Talepler__8CD4AA26F6138103");

            entity.ToTable("Talepler");

            entity.Property(e => e.TalepId).HasColumnName("talepId");
            entity.Property(e => e.Aktiflik).HasColumnName("aktiflik");
            entity.Property(e => e.KullaniciId).HasColumnName("kullaniciId");
            entity.Property(e => e.Talep)
                .HasMaxLength(500)
                .HasColumnName("talep");
            entity.Property(e => e.TalepBaslik)
                .HasMaxLength(20)
                .HasColumnName("talepBaslik");
            entity.Property(e => e.Tarih)
                .HasColumnType("datetime")
                .HasColumnName("tarih");

            entity.HasOne(d => d.Kullanici).WithMany(p => p.Taleplers)
                .HasForeignKey(d => d.KullaniciId)
                .HasConstraintName("FK__Talepler__kullan__7C4F7684");
        });

        modelBuilder.Entity<TeknikDenKargoyaMesaj>(entity =>
        {
            entity.HasKey(e => e.MesajId).HasName("PK__TeknikDe__FFB37EE4A8834DE4");

            entity.ToTable("TeknikDenKargoyaMesaj");

            entity.Property(e => e.MesajId).HasColumnName("mesajId");
            entity.Property(e => e.Aktiflik).HasColumnName("aktiflik");
            entity.Property(e => e.KargoFirmaId).HasColumnName("kargoFirmaId");
            entity.Property(e => e.Mesaj)
                .HasMaxLength(1000)
                .HasColumnName("mesaj");
            entity.Property(e => e.MesajBaslik)
                .HasMaxLength(20)
                .HasColumnName("mesajBaslik");
            entity.Property(e => e.MesajlasmaId).HasColumnName("mesajlasmaId");
            entity.Property(e => e.OkunduBilgisi).HasColumnName("okunduBilgisi");
            entity.Property(e => e.Tarih)
                .HasColumnType("datetime")
                .HasColumnName("tarih");
            entity.Property(e => e.TeknikElemanId).HasColumnName("teknikElemanId");

            entity.HasOne(d => d.KargoFirma).WithMany(p => p.TeknikDenKargoyaMesajs)
                .HasForeignKey(d => d.KargoFirmaId)
                .HasConstraintName("FK__TeknikDen__kargo__2022C2A6");

            entity.HasOne(d => d.Mesajlasma).WithMany(p => p.TeknikDenKargoyaMesajs)
                .HasForeignKey(d => d.MesajlasmaId)
                .HasConstraintName("FK__TeknikDen__mesaj__1E3A7A34");

            entity.HasOne(d => d.TeknikEleman).WithMany(p => p.TeknikDenKargoyaMesajs)
                .HasForeignKey(d => d.TeknikElemanId)
                .HasConstraintName("FK__TeknikDen__tekni__1F2E9E6D");
        });

        modelBuilder.Entity<TeknikElemanBasvuru>(entity =>
        {
            entity.HasKey(e => e.BasvuruId).HasName("PK__TeknikEl__197B7449C51BCB27");

            entity.ToTable("TeknikElemanBasvuru");

            entity.Property(e => e.BasvuruId).HasColumnName("basvuruId");
            entity.Property(e => e.Ad)
                .HasMaxLength(100)
                .HasColumnName("ad");
            entity.Property(e => e.Adres)
                .HasMaxLength(500)
                .HasColumnName("adres");
            entity.Property(e => e.Cinsiyet)
                .HasMaxLength(5)
                .HasColumnName("cinsiyet");
            entity.Property(e => e.DogumTarihi).HasColumnName("dogumTarihi");
            entity.Property(e => e.Mail)
                .HasMaxLength(100)
                .HasColumnName("mail");
            entity.Property(e => e.MezuniyetDurumu)
                .HasMaxLength(200)
                .HasColumnName("mezuniyetDurumu");
            entity.Property(e => e.Ozgecmis).HasColumnName("ozgecmis");
            entity.Property(e => e.Soyad)
                .HasMaxLength(100)
                .HasColumnName("soyad");
            entity.Property(e => e.TcNo)
                .HasMaxLength(12)
                .HasColumnName("tcNo");
            entity.Property(e => e.TelefonNumarasi)
                .HasMaxLength(15)
                .HasColumnName("telefonNumarasi");
        });

        modelBuilder.Entity<TeknikElemanCikislar>(entity =>
        {
            entity.HasKey(e => e.TeknikElemanCikisId).HasName("PK__TeknikEl__68FA06A981D538A5");

            entity.ToTable("TeknikElemanCikislar");

            entity.Property(e => e.TeknikElemanCikisId).HasColumnName("teknikElemanCikisId");
            entity.Property(e => e.BasariDurumu).HasColumnName("basariDurumu");
            entity.Property(e => e.Tarih)
                .HasColumnType("datetime")
                .HasColumnName("tarih");
            entity.Property(e => e.TeknikElemanGirisId).HasColumnName("teknikElemanGirisId");
            entity.Property(e => e.TeknikElemanId).HasColumnName("teknikElemanId");

            entity.HasOne(d => d.TeknikElemanGiris).WithMany(p => p.TeknikElemanCikislars)
                .HasForeignKey(d => d.TeknikElemanGirisId)
                .HasConstraintName("FK__TeknikEle__tekni__55BFB948");

            entity.HasOne(d => d.TeknikEleman).WithMany(p => p.TeknikElemanCikislars)
                .HasForeignKey(d => d.TeknikElemanId)
                .HasConstraintName("FK__TeknikEle__tekni__54CB950F");
        });

        modelBuilder.Entity<TeknikElemanGirisler>(entity =>
        {
            entity.HasKey(e => e.GirisId).HasName("PK__TeknikEl__F8F62BEF9CF87344");

            entity.ToTable("TeknikElemanGirisler");

            entity.Property(e => e.GirisId).HasColumnName("girisId");
            entity.Property(e => e.ElemanId).HasColumnName("elemanId");
            entity.Property(e => e.GirisBasariDurumu).HasColumnName("girisBasariDurumu");
            entity.Property(e => e.Tarih)
                .HasColumnType("datetime")
                .HasColumnName("tarih");

            entity.HasOne(d => d.Eleman).WithMany(p => p.TeknikElemanGirislers)
                .HasForeignKey(d => d.ElemanId)
                .HasConstraintName("FK__TeknikEle__elema__151B244E");
        });

        modelBuilder.Entity<TeknikElemandanKargoSikayeti>(entity =>
        {
            entity.HasKey(e => e.SikayetId).HasName("PK__teknikEl__BBDC1CC646CC2713");

            entity.ToTable("TeknikElemandanKargoSikayeti");

            entity.Property(e => e.SikayetId).HasColumnName("sikayetId");
            entity.Property(e => e.Aktiflik).HasColumnName("aktiflik");
            entity.Property(e => e.KargoFirmaId).HasColumnName("kargoFirmaId");
            entity.Property(e => e.SikayetBaslik)
                .HasMaxLength(20)
                .HasColumnName("sikayetBaslik");
            entity.Property(e => e.SikayetMetni)
                .HasMaxLength(500)
                .HasColumnName("sikayetMetni");
            entity.Property(e => e.Tarih)
                .HasColumnType("datetime")
                .HasColumnName("tarih");
            entity.Property(e => e.TeknikElemanId).HasColumnName("teknikElemanId");

            entity.HasOne(d => d.KargoFirma).WithMany(p => p.TeknikElemandanKargoSikayetis)
                .HasForeignKey(d => d.KargoFirmaId)
                .HasConstraintName("FK__teknikEle__kargo__37FA4C37");

            entity.HasOne(d => d.TeknikEleman).WithMany(p => p.TeknikElemandanKargoSikayetis)
                .HasForeignKey(d => d.TeknikElemanId)
                .HasConstraintName("FK__teknikEle__tekni__38EE7070");
        });

        modelBuilder.Entity<TeknikElemanlar>(entity =>
        {
            entity.HasKey(e => e.TeknikElemanId).HasName("PK__TeknikEl__FBB78B2744328932");

            entity.ToTable("TeknikElemanlar");

            entity.Property(e => e.TeknikElemanId).HasColumnName("teknikElemanId");
            entity.Property(e => e.Aktiflik).HasColumnName("aktiflik");
            entity.Property(e => e.ElemanAd)
                .HasMaxLength(100)
                .HasColumnName("elemanAd");
            entity.Property(e => e.GirisTarihi)
                .HasColumnType("datetime")
                .HasColumnName("girisTarihi");
            entity.Property(e => e.Mail)
                .HasMaxLength(100)
                .HasColumnName("mail");
            entity.Property(e => e.Puan).HasColumnName("puan");
            entity.Property(e => e.Sifre)
                .HasMaxLength(20)
                .HasColumnName("sifre");
            entity.Property(e => e.Unvan)
                .HasMaxLength(100)
                .HasColumnName("unvan");
        });

        modelBuilder.Entity<TeknikElemanlarArasıMesaj>(entity =>
        {
            entity.HasKey(e => e.MesajId).HasName("PK__TeknikEl__FFB37EE4D351A40F");

            entity.ToTable("TeknikElemanlarArasıMesaj");

            entity.Property(e => e.MesajId).HasColumnName("mesajId");
            entity.Property(e => e.Aktiflik).HasColumnName("aktiflik");
            entity.Property(e => e.AlıcıEleman).HasColumnName("alıcıEleman");
            entity.Property(e => e.GonderenEleman).HasColumnName("gonderenEleman");
            entity.Property(e => e.Mesaj)
                .HasMaxLength(500)
                .HasColumnName("mesaj");
            entity.Property(e => e.MesajBaslik)
                .HasMaxLength(20)
                .HasColumnName("mesajBaslik");
            entity.Property(e => e.MesajlasmaId).HasColumnName("mesajlasmaId");
            entity.Property(e => e.OkunduBilgisi).HasColumnName("okunduBilgisi");
            entity.Property(e => e.Tarih)
                .HasColumnType("datetime")
                .HasColumnName("tarih");

            entity.HasOne(d => d.AlıcıElemanNavigation).WithMany(p => p.TeknikElemanlarArasıMesajAlıcıElemanNavigations)
                .HasForeignKey(d => d.AlıcıEleman)
                .HasConstraintName("FK__TeknikEle__alıcı__19DFD96B");

            entity.HasOne(d => d.GonderenElemanNavigation).WithMany(p => p.TeknikElemanlarArasıMesajGonderenElemanNavigations)
                .HasForeignKey(d => d.GonderenEleman)
                .HasConstraintName("FK__TeknikEle__gonde__18EBB532");

            entity.HasOne(d => d.Mesajlasma).WithMany(p => p.TeknikElemanlarArasıMesajs)
                .HasForeignKey(d => d.MesajlasmaId)
                .HasConstraintName("FK__TeknikEle__mesaj__17F790F9");
        });

        modelBuilder.Entity<TeknikdenAdmineMesaj>(entity =>
        {
            entity.HasKey(e => e.MesajId).HasName("PK__Teknikde__FFB37EE475355CD1");

            entity.ToTable("TeknikdenAdmineMesaj");

            entity.Property(e => e.MesajId).HasColumnName("mesajId");
            entity.Property(e => e.AdminId).HasColumnName("adminId");
            entity.Property(e => e.Aktiflik).HasColumnName("aktiflik");
            entity.Property(e => e.Mesaj)
                .HasMaxLength(500)
                .HasColumnName("mesaj");
            entity.Property(e => e.MesajBaslik)
                .HasMaxLength(20)
                .HasColumnName("mesajBaslik");
            entity.Property(e => e.MesajlasmaId).HasColumnName("mesajlasmaId");
            entity.Property(e => e.OkunduBilgisi).HasColumnName("okunduBilgisi");
            entity.Property(e => e.Tarih)
                .HasColumnType("datetime")
                .HasColumnName("tarih");
            entity.Property(e => e.TeknikId).HasColumnName("teknikId");

            entity.HasOne(d => d.Admin).WithMany(p => p.TeknikdenAdmineMesajs)
                .HasForeignKey(d => d.AdminId)
                .HasConstraintName("FK__Teknikden__admin__114A936A");

            entity.HasOne(d => d.Mesajlasma).WithMany(p => p.TeknikdenAdmineMesajs)
                .HasForeignKey(d => d.MesajlasmaId)
                .HasConstraintName("FK__Teknikden__mesaj__123EB7A3");

            entity.HasOne(d => d.Teknik).WithMany(p => p.TeknikdenAdmineMesajs)
                .HasForeignKey(d => d.TeknikId)
                .HasConstraintName("FK__Teknikden__tekni__10566F31");
        });

        modelBuilder.Entity<TeknikdenFirmayaMesaj>(entity =>
        {
            entity.HasKey(e => e.MesajId).HasName("PK__Teknikde__FFB37EE41CCBA989");

            entity.ToTable("TeknikdenFirmayaMesaj");

            entity.Property(e => e.MesajId).HasColumnName("mesajId");
            entity.Property(e => e.Aktiflik).HasColumnName("aktiflik");
            entity.Property(e => e.FirmaId).HasColumnName("firmaId");
            entity.Property(e => e.Mesaj)
                .HasMaxLength(500)
                .HasColumnName("mesaj");
            entity.Property(e => e.MesajBaslik)
                .HasMaxLength(20)
                .HasColumnName("mesajBaslik");
            entity.Property(e => e.MesajlasmaId).HasColumnName("mesajlasmaId");
            entity.Property(e => e.OkunduBilgisi).HasColumnName("okunduBilgisi");
            entity.Property(e => e.Tarih)
                .HasColumnType("datetime")
                .HasColumnName("tarih");
            entity.Property(e => e.TeknikId).HasColumnName("teknikId");

            entity.HasOne(d => d.Firma).WithMany(p => p.TeknikdenFirmayaMesajs)
                .HasForeignKey(d => d.FirmaId)
                .HasConstraintName("FK__Teknikden__firma__07C12930");

            entity.HasOne(d => d.Mesajlasma).WithMany(p => p.TeknikdenFirmayaMesajs)
                .HasForeignKey(d => d.MesajlasmaId)
                .HasConstraintName("FK__Teknikden__mesaj__08B54D69");

            entity.HasOne(d => d.Teknik).WithMany(p => p.TeknikdenFirmayaMesajs)
                .HasForeignKey(d => d.TeknikId)
                .HasConstraintName("FK__Teknikden__tekni__06CD04F7");
        });

        modelBuilder.Entity<TeknikdenKullaniciyaMesaj>(entity =>
        {
            entity.HasKey(e => e.MesajId).HasName("PK__Teknikde__FFB37EE47B224830");

            entity.ToTable("TeknikdenKullaniciyaMesaj");

            entity.Property(e => e.MesajId).HasColumnName("mesajId");
            entity.Property(e => e.Aktiflik).HasColumnName("aktiflik");
            entity.Property(e => e.KullaniciId).HasColumnName("kullaniciId");
            entity.Property(e => e.Mesaj)
                .HasMaxLength(500)
                .HasColumnName("mesaj");
            entity.Property(e => e.MesajBaslik)
                .HasMaxLength(20)
                .HasColumnName("mesajBaslik");
            entity.Property(e => e.MesajlasmaId).HasColumnName("mesajlasmaId");
            entity.Property(e => e.OkunduBilgisi).HasColumnName("okunduBilgisi");
            entity.Property(e => e.Tarih)
                .HasColumnType("datetime")
                .HasColumnName("tarih");
            entity.Property(e => e.TeknikId).HasColumnName("teknikId");

            entity.HasOne(d => d.Kullanici).WithMany(p => p.TeknikdenKullaniciyaMesajs)
                .HasForeignKey(d => d.KullaniciId)
                .HasConstraintName("FK__Teknikden__kulla__0C85DE4D");

            entity.HasOne(d => d.Mesajlasma).WithMany(p => p.TeknikdenKullaniciyaMesajs)
                .HasForeignKey(d => d.MesajlasmaId)
                .HasConstraintName("FK__Teknikden__mesaj__0D7A0286");

            entity.HasOne(d => d.Teknik).WithMany(p => p.TeknikdenKullaniciyaMesajs)
                .HasForeignKey(d => d.TeknikId)
                .HasConstraintName("FK__Teknikden__tekni__0B91BA14");
        });

        modelBuilder.Entity<Urun>(entity =>
        {
            entity.HasKey(e => e.UrunId).HasName("PK__Urun__30BE5343CB659918");

            entity.ToTable("Urun");

            entity.Property(e => e.UrunId).HasColumnName("urunId");
            entity.Property(e => e.Aciklama)
                .HasMaxLength(1000)
                .HasColumnName("aciklama");
            entity.Property(e => e.Aktiflik).HasColumnName("aktiflik");
            entity.Property(e => e.EklenmeTarihi)
                .HasColumnType("datetime")
                .HasColumnName("eklenmeTarihi");
            entity.Property(e => e.FirmaId).HasColumnName("firmaId");
            entity.Property(e => e.Fiyat).HasColumnName("fiyat");
            entity.Property(e => e.KategoriId).HasColumnName("kategoriId");
            entity.Property(e => e.SatisSayisi).HasColumnName("satisSayisi");
            entity.Property(e => e.SepeteEklemeSayisi).HasColumnName("sepeteEklemeSayisi");
            entity.Property(e => e.Stok).HasColumnName("stok");
            entity.Property(e => e.UrunAd)
                .HasMaxLength(100)
                .HasColumnName("urunAd");
            entity.Property(e => e.UrunResim)
                .HasMaxLength(300)
                .HasColumnName("urunResim");

            entity.HasOne(d => d.Firma).WithMany(p => p.Uruns)
                .HasForeignKey(d => d.FirmaId)
                .HasConstraintName("FK__Urun__firmaId__59063A47");

            entity.HasOne(d => d.Kategori).WithMany(p => p.Uruns)
                .HasForeignKey(d => d.KategoriId)
                .HasConstraintName("FK__Urun__kategoriId__59FA5E80");
        });

        modelBuilder.Entity<UrunGoruntulenme>(entity =>
        {
            entity.HasKey(e => e.GoruntulenmeId).HasName("PK__UrunGoru__9C98B34EE6E5D5C7");

            entity.ToTable("UrunGoruntulenme");

            entity.Property(e => e.GoruntulenmeId).HasColumnName("goruntulenmeId");
            entity.Property(e => e.Aktiflik).HasColumnName("aktiflik");
            entity.Property(e => e.GoruntulenmeSayisi).HasColumnName("goruntulenmeSayisi");
            entity.Property(e => e.IlkGoruntulenmeTarih)
                .HasColumnType("datetime")
                .HasColumnName("ilkGoruntulenmeTarih");
            entity.Property(e => e.SonGoruntulenmeTarih)
                .HasColumnType("datetime")
                .HasColumnName("sonGoruntulenmeTarih");
            entity.Property(e => e.UrunId).HasColumnName("urunId");

            entity.HasOne(d => d.Urun).WithMany(p => p.UrunGoruntulenmes)
                .HasForeignKey(d => d.UrunId)
                .HasConstraintName("FK__UrunGorun__urunI__61F08603");
        });

        modelBuilder.Entity<UrunKampanyalar>(entity =>
        {
            entity.HasKey(e => e.KapmanyaId).HasName("PK__UrunKamp__1D21FC83AFE987B8");

            entity.ToTable("UrunKampanyalar");

            entity.Property(e => e.KapmanyaId).HasColumnName("kapmanyaId");
            entity.Property(e => e.Aktiflik).HasColumnName("aktiflik");
            entity.Property(e => e.BaslangicTarihi)
                .HasColumnType("datetime")
                .HasColumnName("baslangicTarihi");
            entity.Property(e => e.BitisTarihi)
                .HasColumnType("datetime")
                .HasColumnName("bitisTarihi");
            entity.Property(e => e.IndirimMiktari).HasColumnName("indirimMiktari");
            entity.Property(e => e.KampanyaAciklama)
                .HasMaxLength(2000)
                .HasColumnName("kampanyaAciklama");
            entity.Property(e => e.KampanyaBaslik)
                .HasMaxLength(100)
                .HasColumnName("kampanyaBaslik");
            entity.Property(e => e.UrunId).HasColumnName("urunId");

            entity.HasOne(d => d.Urun).WithMany(p => p.UrunKampanyalars)
                .HasForeignKey(d => d.UrunId)
                .HasConstraintName("FK__UrunKampa__urunI__1F98B2C1");
        });

        modelBuilder.Entity<UrunPuanlama>(entity =>
        {
            entity.HasKey(e => e.UrunPuanlamaId).HasName("PK__UrunPuan__DE2568B66B2A537B");

            entity.ToTable("UrunPuanlama");

            entity.Property(e => e.UrunPuanlamaId).HasColumnName("urunPuanlamaId");
            entity.Property(e => e.Aktiflik).HasColumnName("aktiflik");
            entity.Property(e => e.KullaniciId).HasColumnName("kullaniciId");
            entity.Property(e => e.Puan).HasColumnName("puan");
            entity.Property(e => e.Tarih)
                .HasColumnType("datetime")
                .HasColumnName("tarih");
            entity.Property(e => e.UrunId).HasColumnName("urunId");

            entity.HasOne(d => d.Kullanici).WithMany(p => p.UrunPuanlamas)
                .HasForeignKey(d => d.KullaniciId)
                .HasConstraintName("FK__UrunPuanl__kulla__762C88DA");

            entity.HasOne(d => d.Urun).WithMany(p => p.UrunPuanlamas)
                .HasForeignKey(d => d.UrunId)
                .HasConstraintName("FK__UrunPuanl__urunI__7720AD13");
        });

        modelBuilder.Entity<UrunSikayet>(entity =>
        {
            entity.HasKey(e => e.UrunsikayetId).HasName("PK__UrunSika__3A8AB8516847906C");

            entity.ToTable("UrunSikayet");

            entity.Property(e => e.UrunsikayetId).HasColumnName("urunsikayetId");
            entity.Property(e => e.Aktiflik).HasColumnName("aktiflik");
            entity.Property(e => e.KullaniciId).HasColumnName("kullaniciId");
            entity.Property(e => e.SikayetBaslik)
                .HasMaxLength(20)
                .HasColumnName("sikayetBaslik");
            entity.Property(e => e.SikayetMetni)
                .HasMaxLength(500)
                .HasColumnName("sikayetMetni");
            entity.Property(e => e.Tarih)
                .HasColumnType("datetime")
                .HasColumnName("tarih");
            entity.Property(e => e.UrunId).HasColumnName("urunId");

            entity.HasOne(d => d.Kullanici).WithMany(p => p.UrunSikayets)
                .HasForeignKey(d => d.KullaniciId)
                .HasConstraintName("FK__UrunSikay__kulla__55009F39");

            entity.HasOne(d => d.Urun).WithMany(p => p.UrunSikayets)
                .HasForeignKey(d => d.UrunId)
                .HasConstraintName("FK__UrunSikay__urunI__540C7B00");
        });

        modelBuilder.Entity<UyeOlmayanBagiscilar>(entity =>
        {
            entity.HasKey(e => e.BagisId).HasName("PK__UyeOlmay__28A4E90FDA8C317D");

            entity.ToTable("UyeOlmayanBagiscilar");

            entity.Property(e => e.BagisId).HasColumnName("bagisId");
            entity.Property(e => e.Aktiflik).HasColumnName("aktiflik");
            entity.Property(e => e.BagisciAd)
                .HasMaxLength(100)
                .HasColumnName("bagisciAd");
            entity.Property(e => e.Cvv)
                .HasMaxLength(3)
                .HasColumnName("cvv");
            entity.Property(e => e.KartNumarasi)
                .HasMaxLength(16)
                .HasColumnName("kartNumarasi");
            entity.Property(e => e.Miktar).HasColumnName("miktar");
            entity.Property(e => e.Onay).HasColumnName("onay");
            entity.Property(e => e.SonGecerlilikTarihi)
                .HasMaxLength(5)
                .HasColumnName("sonGecerlilikTarihi");
            entity.Property(e => e.Tarih)
                .HasColumnType("datetime")
                .HasColumnName("tarih");
        });

        modelBuilder.Entity<YoldaIadeTalebi>(entity =>
        {
            entity.HasKey(e => e.YoldaIadeTalebiId).HasName("PK__YoldaIad__6C9F81CF9CE4DEF8");

            entity.ToTable("YoldaIadeTalebi");

            entity.Property(e => e.YoldaIadeTalebiId).HasColumnName("yoldaIadeTalebiId");
            entity.Property(e => e.FirmaId).HasColumnName("firmaId");
            entity.Property(e => e.GonderilenKargoId).HasColumnName("gonderilenKargoId");
            entity.Property(e => e.IadeAciklama)
                .HasMaxLength(500)
                .HasColumnName("iadeAciklama");
            entity.Property(e => e.KullaniciId).HasColumnName("kullaniciId");
            entity.Property(e => e.Onay).HasColumnName("onay");
            entity.Property(e => e.Tarih)
                .HasColumnType("datetime")
                .HasColumnName("tarih");

            entity.HasOne(d => d.Firma).WithMany(p => p.YoldaIadeTalebis)
                .HasForeignKey(d => d.FirmaId)
                .HasConstraintName("FK__YoldaIade__firma__178D7CA5");

            entity.HasOne(d => d.GonderilenKargo).WithMany(p => p.YoldaIadeTalebis)
                .HasForeignKey(d => d.GonderilenKargoId)
                .HasConstraintName("FK__YoldaIade__gonde__15A53433");

            entity.HasOne(d => d.Kullanici).WithMany(p => p.YoldaIadeTalebis)
                .HasForeignKey(d => d.KullaniciId)
                .HasConstraintName("FK__YoldaIade__kulla__1699586C");
        });

        modelBuilder.Entity<Yorumlar>(entity =>
        {
            entity.HasKey(e => e.YorumId);

            entity.ToTable("Yorumlar");

            entity.Property(e => e.YorumId)
                .ValueGeneratedNever()
                .HasColumnName("yorumId");
            entity.Property(e => e.Aktiflik).HasColumnName("aktiflik");
            entity.Property(e => e.KullaniciId).HasColumnName("kullaniciId");
            entity.Property(e => e.Tarih)
                .HasColumnType("datetime")
                .HasColumnName("tarih");
            entity.Property(e => e.UrunId).HasColumnName("urunId");
            entity.Property(e => e.Yorum)
                .HasMaxLength(300)
                .HasColumnName("yorum");

            entity.HasOne(d => d.Kullanici).WithMany(p => p.Yorumlars)
                .HasForeignKey(d => d.KullaniciId)
                .HasConstraintName("FK__Yorumlar__kullan__75A278F5");

            entity.HasOne(d => d.Urun).WithMany(p => p.Yorumlars)
                .HasForeignKey(d => d.UrunId)
                .HasConstraintName("FK__Yorumlar__urunId__74AE54BC");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
