namespace SaticiFirmaPaneli.Models
{
    public class ReturnsModel
    {
        public int ReturnId { get; set; }

        public int? ReturnRequestId { get; set; }

        public int? UserId { get; set; }
        public string? UserName { get; set; }
        public List<int>? CompanyIds { get; set; }
        public List<string>? CompanyNames { get; set; }
        public List<string>? CompanyAdresses { get; set; }
        public List<int>? ProductIds { get; set; }
        public List<string>? ProductNames { get; set; }

        public float? ReturnAmount { get; set; }

        public DateTime? Date { get; set; }
    }
}
