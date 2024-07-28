using System;
using System.Collections.Generic;

namespace DB.Models;

public partial class Mesajlasma
{
    public int MesajlasmaId { get; set; }

    public DateTime? Tarih { get; set; }

    public virtual ICollection<AdmindenFirmayaMesaj> AdmindenFirmayaMesajs { get; set; } = new List<AdmindenFirmayaMesaj>();

    public virtual ICollection<AdmindenKullaniciyaMesaj> AdmindenKullaniciyaMesajs { get; set; } = new List<AdmindenKullaniciyaMesaj>();

    public virtual ICollection<AdmindenTeknikDestegeMesaj> AdmindenTeknikDestegeMesajs { get; set; } = new List<AdmindenTeknikDestegeMesaj>();

    public virtual ICollection<FirmadanKullaniciyaMesaj> FirmadanKullaniciyaMesajs { get; set; } = new List<FirmadanKullaniciyaMesaj>();

    public virtual ICollection<FirmadanTeknikElemanaMesaj> FirmadanTeknikElemanaMesajs { get; set; } = new List<FirmadanTeknikElemanaMesaj>();

    public virtual ICollection<KargodanTeknikElemanaMesaj> KargodanTeknikElemanaMesajs { get; set; } = new List<KargodanTeknikElemanaMesaj>();

    public virtual ICollection<KullanicidanTeknikDestegeMesaj> KullanicidanTeknikDestegeMesajs { get; set; } = new List<KullanicidanTeknikDestegeMesaj>();

    public virtual ICollection<KullanicilarArasiMesaj> KullanicilarArasiMesajs { get; set; } = new List<KullanicilarArasiMesaj>();

    public virtual ICollection<TeknikDenKargoyaMesaj> TeknikDenKargoyaMesajs { get; set; } = new List<TeknikDenKargoyaMesaj>();

    public virtual ICollection<TeknikElemanlarArasıMesaj> TeknikElemanlarArasıMesajs { get; set; } = new List<TeknikElemanlarArasıMesaj>();

    public virtual ICollection<TeknikdenAdmineMesaj> TeknikdenAdmineMesajs { get; set; } = new List<TeknikdenAdmineMesaj>();

    public virtual ICollection<TeknikdenFirmayaMesaj> TeknikdenFirmayaMesajs { get; set; } = new List<TeknikdenFirmayaMesaj>();

    public virtual ICollection<TeknikdenKullaniciyaMesaj> TeknikdenKullaniciyaMesajs { get; set; } = new List<TeknikdenKullaniciyaMesaj>();
}
