using System;
using System.Collections.Generic;

namespace DieteticSNS.Application.Models.Posts.Queries.GetPostList
{
    public class PostCommentDto
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public int UserId { get; set; }
        public string Content { get; set; }
        public int PostId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AvatarPath { get; set; }

        public List<CommentLikeDto> CommentLikes { get; set; } = new List<CommentLikeDto>();
        public List<CommentReportDto> CommentReports { get; set; } = new List<CommentReportDto>();
    }
}
