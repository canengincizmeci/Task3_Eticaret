namespace SatisPaneli.Models
{
    public class CommentRepliesModel
    {
        public int ReplyId { get; set; }

        public string? Reply { get; set; }

        public int? UserId { get; set; }
        public string? UserName { get; set; }

        public int? CommentId { get; set; }
        public int? CompanyId { get; set; }
        public string? CompanyName { get; set; }

        public bool? ActivityStatus { get; set; }

        public DateTime? Date { get; set; }
    }
}
