using System;
using System.Collections.Generic;

namespace DB.Models;

public partial class Admin
{
    public int AdminId { get; set; }

    public string? AdminAd { get; set; }

    public string? AdminSifre { get; set; }

    public string? Mail { get; set; }

    public string? MailSifre { get; set; }

    public bool? Aktiflik { get; set; }

    public virtual ICollection<AdminCikislar> AdminCikislars { get; set; } = new List<AdminCikislar>();

    public virtual ICollection<AdminLoginGirisler> AdminLoginGirislers { get; set; } = new List<AdminLoginGirisler>();

    public virtual ICollection<AdminMailGirisler> AdminMailGirislers { get; set; } = new List<AdminMailGirisler>();

    public virtual ICollection<AdmindenFirmayaMesaj> AdmindenFirmayaMesajs { get; set; } = new List<AdmindenFirmayaMesaj>();

    public virtual ICollection<AdmindenKargoFirmasinaBilgilendirme> AdmindenKargoFirmasinaBilgilendirmes { get; set; } = new List<AdmindenKargoFirmasinaBilgilendirme>();

    public virtual ICollection<AdmindenKullaniciyaMesaj> AdmindenKullaniciyaMesajs { get; set; } = new List<AdmindenKullaniciyaMesaj>();

    public virtual ICollection<AdmindenTeknikDestegeMesaj> AdmindenTeknikDestegeMesajs { get; set; } = new List<AdmindenTeknikDestegeMesaj>();

    public virtual ICollection<TeknikdenAdmineMesaj> TeknikdenAdmineMesajs { get; set; } = new List<TeknikdenAdmineMesaj>();
}
