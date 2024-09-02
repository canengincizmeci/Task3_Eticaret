namespace SatisPaneli.Models
{
    public class CompanyCampaignModel
    {
        public int CampaignId { get; set; }

        public string? CampaignTitle { get; set; }

        public string? CampaignDescription { get; set; }


        public int? CompanyId { get; set; }
        public string? CompanyName { get; set; }


        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }


        public bool? ActivityStatus { get; set; }

        public float? DiscountAmount { get; set; }
    }
}
