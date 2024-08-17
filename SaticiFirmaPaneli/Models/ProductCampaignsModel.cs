namespace SaticiFirmaPaneli.Models
{
    public class ProductCampaignsModel
    {
        public int CampaignId { get; set; }

        public string? CampaignTitle { get; set; }

        public string? CampaignDescription { get; set; }

        public int? ProductId { get; set; }
        public string? ProductName { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public bool? ActivityStatus { get; set; }

        public float? DiscountAmount { get; set; }

    }
}
