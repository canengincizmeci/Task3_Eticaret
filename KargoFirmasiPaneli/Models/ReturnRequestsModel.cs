namespace KargoFirmasiPaneli.Models
{
    public class ReturnRequestsModel
    {
        public int RequestId { get; set; }

        public int? PaymnetId { get; set; }

        public int? UserId { get; set; }

        public string? Reason { get; set; }

        public DateTime? Date { get; set; }
        public List<int>? ProductsId { get; set; }
        public List<string>? ProductsName { get; set; }

        public bool? Approval { get; set; }

        public bool? ActivityStatus { get; set; }
        public List<int>? CompanyIds { get; set; }
        public List<string>? CompanyNames { get; set; }
        public string? Adress { get; set; }
        public List<string>? CompanyAdress { get; set; }


    }
}
