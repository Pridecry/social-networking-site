using System;

namespace DieteticSNS.Application.Models.Posts.Queries.GetPostList
{
    public class PostLikeDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int? CommentId { get; set; }
        public int? PostId { get; set; }
    }
}
