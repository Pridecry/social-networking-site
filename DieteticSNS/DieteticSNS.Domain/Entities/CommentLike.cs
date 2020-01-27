namespace DieteticSNS.Domain.Entities
{
    public class CommentLike : Like
    {
        public int CommentId { get; set; }
        public virtual Comment Comment { get; set; }
    }
}
