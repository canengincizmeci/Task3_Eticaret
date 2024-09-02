using DB.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SatisPaneli.Models
{
    public class CampaignsViewComponentModel
    {
        public List<KategoriKampanyalar?>? categoryCampaigns { get; set; }
        public List<FirmaKampanyalar>? companyCampaigns { get; set; }
        public List<GenelKampanyalar>? generalCampaigns { get; set; }
        public List<UrunKampanyalar>? productCampaigns { get; set; }

    }
}
