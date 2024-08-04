using DB.Models;

namespace KargoFirmasiPaneli.Models
{
    public class CompanyAndSupportMessagingModel
    {
        public List<MessagingBetweenCompanyAndSupportListModel> messagesList { get; set; }
        public int? supportId { get; set; }
        public int messageId { get; set; }
        public int? messagingId { get; set; }

    }
}
