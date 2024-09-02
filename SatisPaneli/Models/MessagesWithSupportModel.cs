namespace SatisPaneli.Models
{
    public class MessagesWithSupportModel
    {
        public int MessageId { get; set; }

        public string? MessageTitle { get; set; }

        public string? Message { get; set; }

        public int? SupportId { get; set; }
        public string? SupportName { get; set; }
        public int? UserId { get; set; }
        public string? UserName { get; set; }


        public int? MessagingId { get; set; }

        public DateTime? Date { get; set; }

        public bool? ActivityStatus { get; set; }

        public bool? ReadStatus { get; set; }

        public bool? Role { get; set; }
    }
}
