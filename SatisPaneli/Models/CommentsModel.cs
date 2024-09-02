namespace SatisPaneli.Models
{
    public class CommentsModel
    {
        public int CommentId { get; set; }

        public string? Comment { get; set; }


        public int? UserId { get; set; }
        public string? UserName { get; set; }
        public int? ProductId { get; set; }

        public DateTime? Date { get; set; }

        public bool? ActivityStatus { get; set; }
    }
}
