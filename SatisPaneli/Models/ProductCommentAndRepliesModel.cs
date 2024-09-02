namespace SatisPaneli.Models
{
    public class ProductCommentAndRepliesModel
    {
        public List<CommentsModel> commentsList { get; set; }

        public List<CommentRepliesModel>? repliesList { get; set; }
    }
}
