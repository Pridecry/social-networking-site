using System;
using System.Collections.Generic;

namespace DieteticSNS.Application.Models.Users.Queries.GetUserProfile
{
    public class ProfilePostCommentDto
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public int UserId { get; set; }
        public string Content { get; set; }
        public int PostId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AvatarPath { get; set; }

        public List<ProfileCommentLikeDto> CommentLikes { get; set; } = new List<ProfileCommentLikeDto>();
        public List<ProfileCommentReportDto> CommentReports { get; set; } = new List<ProfileCommentReportDto>();
    }
}
