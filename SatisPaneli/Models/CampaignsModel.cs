using DB.Models;

namespace SatisPaneli.Models
{
    public class CampaignsModel
    {
        public List<CategoryCampaingsModel>? categoryCampaigns { get; set; }
        public List<CompanyCampaignModel>? companyCampaigns { get; set; }
        public List<GenelKampanyalar>? generalCampaigns { get; set; }
        public List<ProductCampaignModel>? productCampaigns { get; set; }
    }
}
