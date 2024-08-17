namespace SaticiFirmaPaneli.Models
{
    public class CategoryCampaignsModel
    {
        public int CampaignId { get; set; }

        public string? CampaignTitle { get; set; }

        public string? CampaignDescription { get; set; }


        public int? CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public bool? ActivityStatus { get; set; }

        public float? DiscountAmount { get; set; }
    }
}
