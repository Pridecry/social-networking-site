namespace DieteticSNS.Application.Models.Posts.Queries.GetPostList
{
    public class CommentLikeDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int? CommentId { get; set; }
    }
}
